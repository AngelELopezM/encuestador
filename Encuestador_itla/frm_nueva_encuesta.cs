using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database.repositorios;
namespace Encuestador_itla
{
    public partial class frm_nueva_encuesta : Form
    {
        database.databaselogic servicios;
        public int id_encuesta;
        public int id_pregunta;
        public int usuario_enuso;
        public frm_nueva_encuesta()
        {
            usuario_enuso = usuario_en_uso.instancia.usuario_activo;
            id_pregunta = 1;
            servicios = new database.databaselogic();
            InitializeComponent();
        }

        #region eventos
        private void frm_nueva_encuesta_Load(object sender, EventArgs e)
        {
            /*hacemos que todos tengan un valor vacio solo en caso de que una respuesta tenga que quedar
             vacia asi el stored procedure no va a dar error*/
            
            tb_opcion1.Text = "";
            tb_opcion2.Text = "";
            tb_opcion3.Text = "";
            tb_opcion4.Text = "";
            id_encuesta = servicios.get_ultimo_id_enc();
            servicios.limpiar_encuesta_temporal();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_pregunta.Text) || String.IsNullOrEmpty(tb_nombre_encuesta.Text))
            {
                MessageBox.Show("Para poder seguir debe digitar una pregunta o un nombre para la encuesta");
            }
            else if (tb_opcion1.Text != "" && tb_opcion2.Text != "")
            {
                agregar_nueva_pregunta();
                limpiar_boxes();
                MessageBox.Show("Su pregunta se ha guardado");
                tb_pregunta.Focus();
            }
            else
            {
                MessageBox.Show("Debe digitar por lo menos dos preguntas");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
          /*Aqui guardamos la encuesta y limpiamos la tabla de encuesta temporal*/
            guardar_encuesta();
            servicios.limpiar_encuesta_temporal();
        }
        #endregion

        #region metodos
        public void limpiar_boxes()
        {
            tb_pregunta.Clear();
            tb_opcion1.Text = "";
            tb_opcion2.Text = "";
            tb_opcion3.Text = "";
            tb_opcion4.Text = "";
        }
        public void agregar_nueva_pregunta()
        {
            /*Aqui agregamos la nueva pregunta a la encuesta en el formulario de encuesta_temporal para posteriormente
             agregarla al formulario de encuestas y tambien aumentamos el numero de la pregunta para llevar una secuencia*/
            
            repositorio_encuestas encuesta = new repositorio_encuestas();
                encuesta.id_encuesta = id_encuesta;
                encuesta.id_pregunta = id_pregunta;
                encuesta.id_usuario = usuario_enuso;
                encuesta.nombre_encuesta = tb_nombre_encuesta.Text;
                encuesta.pregunta = tb_pregunta.Text;
                encuesta.respuesta1 = tb_opcion1.Text;
                encuesta.respuesta2 = tb_opcion2.Text;
                encuesta.respuesta3 = tb_opcion3.Text;
                encuesta.respuesta4 = tb_opcion4.Text;

                servicios.agregar_preg_nueva_encuesta(encuesta);
                id_pregunta++;
                 
            

        }
        public void guardar_encuesta()
        {
            /*En este metodo pasamos la encuesta ya terminada de la tabla de encuestas temporales hasta
             la tabla de encuestas terminadas y limpiamos la table de encuesta temporal para la prox*/
            
            var opcion = MessageBox.Show("Seguro que quiere guardar su encuesta?","",MessageBoxButtons.YesNo);
            if (opcion == DialogResult.Yes)
            {
                servicios.guardar_encuesta();
                servicios.limpiar_encuesta_temporal();
                MessageBox.Show("ENCUESTA HA SIDO GUARDADA");
                frm_menu menu = new frm_menu();
                menu.Show();
                this.Hide();
            }
        }

        #endregion

        
    }
}
