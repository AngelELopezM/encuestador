using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;
namespace Encuestador_itla
{
    public partial class frm_visualizar_encuesta : Form
    {
        databaselogic servicios;
        int id_encuesta = repositorio_id_encuesta.instancia.id_encuesta;
        int encuestado;
        public frm_visualizar_encuesta()
        {
            servicios = new databaselogic();
            InitializeComponent();
        }
        #region eventos
        private void btn_volver_Click(object sender, EventArgs e)
        {
            frm_menu menu = new frm_menu();
            menu.Show();
            this.Hide();
        }
        private void frm_visualizar_encuesta_Load(object sender, EventArgs e)
        {
            dgv_encuestas.DataSource = servicios.get_encuestados(id_encuesta);
            label1.Text = "Visualizar encuesta : " + servicios.get_nombre_encuesta(id_encuesta);
            dgv_encuestas.ClearSelection();
            label2.Text = "Double click en un nombre para ver sus respuestas";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*Aqui lo que hacemos es volver al listado de las personas encuestadas,
             y volvemos a mostrar las lineas que ocultamos para que se vea toda la info*/
            dgv_encuestas.DataSource = servicios.get_encuestados(id_encuesta);
            dgv_encuestas.Columns[0].Visible = true;
            dgv_encuestas.Columns[1].Visible = true;
            label2.Text = "Double click en un nombre para ver sus respuestas";
            button1.Enabled = false;
            dgv_encuestas.ClearSelection();
        }
        private void dgv_encuestas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {/*Al hacer doble click sobre una persona lo que hacemos es que traemos todas las respuestas
            que dio esa persona y ocultamos las columnas 1 y 2 para que no sea vea el nombre del encuestado
            ni el id de manera repetida*/
            int index = e.RowIndex;
            if (index>=0)
            {
                button1.Enabled = true;
                encuestado = Convert.ToInt32(dgv_encuestas.Rows[index].Cells[0].Value.ToString());
                label2.Text = "Encuestado : " + dgv_encuestas.Rows[index].Cells[1].Value.ToString();
                dgv_encuestas.DataSource = servicios.get_respuestas(encuestado, id_encuesta);
                dgv_encuestas.Columns[0].Visible = false;
                dgv_encuestas.Columns[1].Visible = false;
                dgv_encuestas.Columns[2].Visible = false;
                
            }
            

        }
        #endregion


    }
}
