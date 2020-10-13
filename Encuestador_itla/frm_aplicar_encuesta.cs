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
    public partial class frm_aplicar_encuesta : Form
    {
        public List<preguntas> preguntas = new List<preguntas>();
        database.databaselogic servicios;
        int id_encuesta = repositorio_id_encuesta.instancia.id_encuesta;
        int num_preg = 0;
        int id_pregunta;
        string encuestado, respuesta;
        int id_encuestado;
        public frm_aplicar_encuesta()
        {
            
            servicios = new database.databaselogic();
            InitializeComponent();
        }

        #region eventos
        private void frm_aplicar_encuesta_Load(object sender, EventArgs e)
        {
            get_preguntas();
            lb_nombre_encuesta.Text ="Aplicando encuesta : " + preguntas[0].nombre_encuesta;
            llenar_opciones();
            deshabilitar_rb_vacios();
            servicios.limpiar_respuesta_temporal();



        }
        private void btn_siguiente_Click(object sender, EventArgs e)    
        {/*Aqui vamos a llenar las respuestas temporales, despues vamos a llenar las opciones
            con la pregunta siguiente y vamos a deshabilitar las opciones que tengamos vacias*/
            try
            {
                if (string.IsNullOrEmpty(tb_encuestado.Text))
                {
                    MessageBox.Show("Debe llenar el campo del encuestado");
                }
                else
                {
                    id_encuestado = servicios.get_last_encuestado_id();
                    id_encuestado++;
                    encuestado = tb_encuestado.Text;
                    servicios.capturar_respuesta_temporal(id_encuesta,id_encuestado, encuestado, id_pregunta, respuesta);
                    llenar_opciones();
                    deshabilitar_rb_vacios();
                    tb_encuestado.Enabled = false;
                }
                

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("La encuesta ha terminado");
                btn_someter.Enabled = true;
                btn_siguiente.Enabled = false;
            }

        }
        private void rb_opcion1_CheckedChanged(object sender, EventArgs e)
        {
            opcion_seleccionada();
        }

        private void rb_opcion2_CheckedChanged(object sender, EventArgs e)
        {
            opcion_seleccionada();
        }

        private void rb_opcion3_CheckedChanged(object sender, EventArgs e)
        {
            opcion_seleccionada();
        }

        private void rb_opcion4_CheckedChanged(object sender, EventArgs e)
        {
            opcion_seleccionada();
        }
        private void btn_someter_Click(object sender, EventArgs e)
        {
            servicios.capturar_respuestas();
            MessageBox.Show("SU APLICACION HA SIDO SOMETIDA");
            frm_menu menu = new frm_menu();
            menu.Show();
            this.Hide();
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            frm_menu menu = new frm_menu();
            menu.Show();
            this.Hide();
        }
        #endregion
        #region metodos
        private void get_preguntas()
        {
            /*Me quede aqui se supone que voy a agregar todas las preguntas de la encuestas que necesito
             a este list para luego cuando vaya a aplicar las preguntas pasar campo por campo a tomar
             las preguntas*/
            preguntas = servicios.get_preguntas_para_aplicar(id_encuesta);
        }
        private void llenar_opciones()
        {
            /*Aqui lleno lleno todas las diferentes opciones que tenemos para preguntar
             y al final aumento el numero de la pregunta para que cuando se llame la proxima ver
             me traiga otra pregunta*/
            groupBox1.Text = preguntas[num_preg].pregunta;
            rb_opcion1.Text = preguntas[num_preg].respuesta1;
            rb_opcion2.Text = preguntas[num_preg].respuesta2;
            rb_opcion3.Text = preguntas[num_preg].respuesta3;
            rb_opcion4.Text = preguntas[num_preg].respuesta4;
            id_pregunta = preguntas[num_preg].id_pregunta;

            num_preg++;
        }
        private void deshabilitar_rb_vacios()
        {
            if (rb_opcion1.Text == "")
            {
                rb_opcion1.Enabled = false;
            }
            else
            {
                rb_opcion1.Enabled = true;
            }
            if (rb_opcion2.Text == "")
            {
                rb_opcion2.Enabled = false;
            }
            else
            {
                rb_opcion2.Enabled = true;
            }
            if (rb_opcion3.Text == "")
            {
                rb_opcion3.Enabled = false;
            }
            else
            {
                rb_opcion3.Enabled = true;
            }
            if (rb_opcion4.Text == "")
            {
                rb_opcion4.Enabled = false;
            }
            else
            {
                rb_opcion4.Enabled = true;
            }
        }

        

        private void opcion_seleccionada()
        {
            /*Aqui vamos a asignarle un valor numero a los ration button asi cuando seleccionemos uno
             pues ya sabremo que respuesta hemos seleccionado*/
            if (rb_opcion1.Checked)
            {
                respuesta = rb_opcion1.Text;
            }
            else if (rb_opcion2.Checked)
            {
                respuesta = rb_opcion2.Text;
            }
            else if (rb_opcion3.Checked)
            {
                respuesta = rb_opcion3.Text;
            }
            else if(rb_opcion4.Checked)
            {
                respuesta = rb_opcion4.Text;
            }

        }
        #endregion

       
    }
}
