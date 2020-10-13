using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database.modelos;
namespace Encuestador_itla
{
    public partial class frm_agregar_pregunta : Form
    {
        database.databaselogic servicios;
        int id_encuesta = repositorio_id_encuesta.instancia.id_encuesta;
        int id_usuario = usuario_en_uso.instancia.usuario_activo;
        string nombre_encuesta;
        public frm_agregar_pregunta()
        {
            
            servicios = new database.databaselogic();
            InitializeComponent();
        }

        #region eventos
        private void frm_agregar_pregunta_Load(object sender, EventArgs e)
        {
            
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            frm_editar_encuesta editar = new frm_editar_encuesta();
            editar.Show();
            this.Hide();
        }
        private void btn_nueva_preg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_pregunta.Text))
            {
                MessageBox.Show("Debe ingresar un nombre a la pregunta");

            }
            else if (string.IsNullOrEmpty(tb_opcion2.Text) || string.IsNullOrEmpty(tb_opcion2.Text))
            {
                MessageBox.Show("La pregunta debe tener minimo 2 opciones");
            }
            else
            {
                agregar_pregunta();
                MessageBox.Show("Tu pregunta ha sido agregada");
                frm_editar_encuesta editar = new frm_editar_encuesta();
                editar.Show();
                this.Hide();
            }
        }
        #endregion
        #region metodos
        private void agregar_pregunta()
        {
            nombre_encuesta = servicios.get_nombre_encuesta(id_encuesta);
            int id_pregunta = servicios.get_last_preg_id(id_encuesta,id_usuario)+1;
            preguntas preguntas = new preguntas();
            preguntas.id_pregunta = id_pregunta;
            preguntas.pregunta = tb_pregunta.Text;
            preguntas.respuesta1 = tb_opcion1.Text;
            preguntas.respuesta2 = tb_opcion2.Text;
            preguntas.respuesta3 = tb_opcion3.Text;
            preguntas.respuesta4 = tb_opcion4.Text;
            servicios.agregar_pregunta_extra(id_encuesta,nombre_encuesta,id_usuario,preguntas);

        }


        #endregion

        
    }
}
