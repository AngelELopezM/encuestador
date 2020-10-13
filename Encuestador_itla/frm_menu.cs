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
    public partial class frm_menu : Form
    {
        databaselogic servicios;
        public int id_encuesta;
        public int index;
        public int id_usuario = usuario_en_uso.instancia.usuario_activo;
        public frm_menu()
        {
            servicios = new databaselogic();
            InitializeComponent();
        }

        #region eventos
        private void btn_salir_Click(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.Show();
            this.Hide();
        }
        private void btn_aplicar_encuesta_Click(object sender, EventArgs e)
        {
            frm_aplicar_encuesta aplicar = new frm_aplicar_encuesta();
            aplicar.Show();
            this.Hide();
        }
        private void frm_menu_Load(object sender, EventArgs e)
        {
            deshabilitar_botones();
            load_dataencuestas();
            dgv_encuestas.ClearSelection();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frm_nueva_encuesta nueva_encuesta = new frm_nueva_encuesta();
            nueva_encuesta.Show();
            this.Hide();
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Esta seguo que desea eliminar esta encuesta?","",MessageBoxButtons.YesNo);
            if (opcion == DialogResult.Yes)
            {

                eliminar_encuesta();
                load_dataencuestas();
                MessageBox.Show("Encuesta eliminada");
            }
            
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            frm_editar_encuesta editar = new frm_editar_encuesta();
            editar.Show();
            this.Hide();
        }
        private void dgv_encuestas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {/*Aqui le paso el id de la encuesta seleccionada al singleton para que asi cuando vayamos al otro
            formulario podamos desplegar la informacion relacionada con la misma encuesta*/
            
            index = e.RowIndex;
            if (index>=0)
            {
                id_encuesta = Convert.ToInt32(dgv_encuestas.Rows[index].Cells[0].Value.ToString());
                repositorio_id_encuesta.instancia.id_encuesta = id_encuesta;
                habilitar_botones();
            }
            else
            {
                dgv_encuestas.ClearSelection();
            }
            
        }
        private void btn_visualizar_Click(object sender, EventArgs e)
        {
            frm_visualizar_encuesta visualizar = new frm_visualizar_encuesta();
            visualizar.Show();
            this.Hide();

        }
        #endregion

        #region metodos
        private void eliminar_encuesta()
        {
            servicios.eliminar_encuesta(id_encuesta, id_usuario);
        }
        private void load_dataencuestas()
        {
            dgv_encuestas.DataSource= servicios.Getencuestas(id_usuario);
        }
        private void deshabilitar_botones()
        {
            btn_aplicar_encuesta.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_visualizar.Enabled = false;
        }
        private void habilitar_botones()
        {
            btn_aplicar_encuesta.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_visualizar.Enabled = true;
        }



        #endregion

        
    }
}
