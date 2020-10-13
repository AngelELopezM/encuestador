using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestador_itla
{
    public partial class frm_login : Form
    {
        database.databaselogic servicios;
        public frm_login()
        {
            servicios = new database.databaselogic();
            InitializeComponent();
        }
        #region eventos
        private void frm_login_Load(object sender, EventArgs e)
        {

        }
        private void btn_entrar_Click(object sender, EventArgs e)
        {
            
            login();
        }
        private void linklbl_registrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_usuarios usuario = new frm_usuarios();
            usuario.Show();
            this.Hide();
        }
        private void txt_contrasena_KeyDown(object sender, KeyEventArgs e)
        {/*Este evento lo utilizamos de esta manera para que cuando presionemos la tecla enter
            entonces podamos ejecutar cierta accion*/
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
        #endregion

        #region metodos
        private void login()
        {/*Aqui lo que hacemos es que ejecutamos la consulta y si la consulta nos devuelve un numero
            diferente de cero significa que encontramos un usuario y almacenamos el #ID del usuario
            para hacer poder mostrar las encuestas que pertenecen al mismo*/
            string usuario = txt_usuario.Text, contra = txt_contrasena.Text;
            try
            {
                int id_usuario = servicios.login(usuario, contra);
                if (id_usuario != 0)
                {
                    usuario_en_uso.instancia.usuario_activo = id_usuario;
                    frm_menu menu = new frm_menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña invalidos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error "+ ex);

            }
        }


        #endregion

        
    }
}
