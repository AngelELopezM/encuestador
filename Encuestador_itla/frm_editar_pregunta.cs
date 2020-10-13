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
using database.repositorios;
namespace Encuestador_itla
{
    public partial class frm_editar_pregunta : Form
    {
        preguntas preguntas;
        database.databaselogic servicios;
        public int id_encuesta;
        public frm_editar_pregunta()
        {
            id_encuesta = repositorio_id_encuesta.instancia.id_encuesta;
            servicios = new database.databaselogic();
            preguntas = new preguntas();
            InitializeComponent();
        }

        #region eventos
        private void frm_editar_pregunta_Load(object sender, EventArgs e)
        {
            convertir_list();
            load_boxes();
        }
        private void btn_editar_preg_Click(object sender, EventArgs e)
        {
            editar();
            MessageBox.Show("pregunta editada");
            frm_editar_encuesta editar1 = new frm_editar_encuesta();
            editar1.Show();
            this.Hide();
        }
        #endregion
        #region metodos
        private void convertir_list()
        {
            /*Con este metodo convierto el contenido que tiene el list a un objeto para hacer
             poder ponerselo a los tb que tenemos y tambien borro el list porque ya no lo vamos a utilizar*/
            foreach (var item in repositorio_preguntas.instancia.preguntas)
            {
                preguntas.id_pregunta = item.id_pregunta;
                preguntas.pregunta = item.pregunta;
                preguntas.respuesta1 = item.respuesta1;
                preguntas.respuesta2 = item.respuesta2;
                preguntas.respuesta3 = item.respuesta3;
                preguntas.respuesta4 = item.respuesta4;
            }
            repositorio_preguntas.instancia.preguntas.RemoveAt(0);
        }
        private void load_boxes()
        {
            tb_pregunta.Text = preguntas.pregunta;
            tb_opcion1.Text = preguntas.respuesta1;
            tb_opcion2.Text = preguntas.respuesta2;
            tb_opcion3.Text = preguntas.respuesta3;
            tb_opcion4.Text = preguntas.respuesta4;
        }
        private void editar()
        {
            preguntas.pregunta = tb_pregunta.Text;
            preguntas.respuesta1 = tb_opcion1.Text ;
            preguntas.respuesta2 = tb_opcion2.Text ;
             preguntas.respuesta3 = tb_opcion3.Text ;
            preguntas.respuesta4 = tb_opcion4.Text ;
            servicios.editar_pregunta(id_encuesta,preguntas);

        }
        #endregion

        
    }
}
