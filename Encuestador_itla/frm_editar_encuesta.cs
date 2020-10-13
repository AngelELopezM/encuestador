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
    public partial class frm_editar_encuesta : Form
    {
        database.databaselogic servicios;
        public int id_pregunta;
        public string nombre_encuesta;
        public int id_encuesta = repositorio_id_encuesta.instancia.id_encuesta;
        public frm_editar_encuesta()
        {
            servicios = new database.databaselogic();
            InitializeComponent();
        }


        #region eventos
        private void frm_editar_encuesta_Load(object sender, EventArgs e)
        {
            Load_data();
            deshabilitar_botones();
            nom_encuesta();
            lb_nombre_encuesta.Text = "EDITAR ENCUESTA : " + nombre_encuesta;
        }
        private void dgv_preguntas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Aqui lo que hacemos es que agregamos toda la info de la pregunta que queremos editar
             a un singleton que tiene un el modelo de preguntas para despues poder editarlas*/
            int index = e.RowIndex;

            if (index >=0)
            {
                preguntas preguntas = new preguntas();

                preguntas.id_pregunta = Convert.ToInt32(dgv_preguntas.Rows[index].Cells[0].Value.ToString());
                preguntas.pregunta = dgv_preguntas.Rows[index].Cells[1].Value.ToString();
                preguntas.respuesta1 = dgv_preguntas.Rows[index].Cells[2].Value.ToString();
                preguntas.respuesta2 = dgv_preguntas.Rows[index].Cells[3].Value.ToString();
                preguntas.respuesta3 = dgv_preguntas.Rows[index].Cells[4].Value.ToString();
                preguntas.respuesta4 = dgv_preguntas.Rows[index].Cells[5].Value.ToString();
                id_pregunta = preguntas.id_pregunta;
                repositorio_preguntas.instancia.preguntas.Add(preguntas);
                habilitar_botones();
            }
            else
            {
                deshabilitar_botones();
            }
            

        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            frm_editar_pregunta epregunta = new frm_editar_pregunta();
            epregunta.Show();
            this.Hide();
        }
        private void btn_eliminar_pregunta_Click(object sender, EventArgs e)
        {
            eliminar_pregunta();
            Load_data();
            MessageBox.Show("Pregunta eliminada exitosamente");
            deshabilitar_botones();

        }
        private void btn_volver_Click(object sender, EventArgs e)
        {
            frm_menu menu = new frm_menu();
            menu.Show();
            this.Hide();
        }
        private void btn_agregar_pregunta_Click(object sender, EventArgs e)
        {
            frm_agregar_pregunta agregar = new frm_agregar_pregunta();
            agregar.Show();
            this.Hide();
        }
        #endregion
        #region metodos
        public void Load_data()
        {
            int id = repositorio_id_encuesta.instancia.id_encuesta;
            dgv_preguntas.DataSource = servicios.Get_preguntas(id);

        }
        public void deshabilitar_botones()
        {
            btn_editar.Enabled = false;
            btn_eliminar_pregunta.Enabled = false;
            
        }
        public void habilitar_botones()
        {
            btn_editar.Enabled = true;
            btn_eliminar_pregunta.Enabled = true;
            btn_agregar_pregunta.Enabled = true;
        }
        public void eliminar_pregunta()
        {
            int id_encuesta = repositorio_id_encuesta.instancia.id_encuesta;
            servicios.eliminar_preguntas(id_encuesta,id_pregunta);
        }

        public void nom_encuesta()
        {
            nombre_encuesta = servicios.get_nombre_encuesta(id_encuesta);
        }



        #endregion

        
    }
}
