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
    public partial class frm_usuarios : Form
    {
        database.databaselogic servicios;
        public frm_usuarios()
        {
            servicios = new database.databaselogic();
            InitializeComponent();
        }

        #region eventos
        private void frm_usuarios_Load(object sender, EventArgs e)
        {

        }
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            bool existe = validar_usuario();
            if (existe == true)
            {
                MessageBox.Show("Este usuario ya existe");
                txtusuario.Clear();
            }
            else if (txtcontrasena.Text != txtconfirmarcontra.Text)
            {
                MessageBox.Show("Las contrasenas deben ser iguales");
                txtcontrasena.Clear();
                txtconfirmarcontra.Clear();
            }
            else
            {
                agregar_usuario();
                MessageBox.Show("USUARIO AGREGADO");
                frm_login login = new frm_login();
                login.Show();
                this.Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.Show();
            this.Hide();
        }

        #endregion
        #region eventos
        private void agregar_usuario()
        {
            usuarios usuario = new usuarios();
            usuario.nombre = txtnombre.Text;
            usuario.apellido = txtapellido.Text;
            usuario.contra = txtcontrasena.Text;
            usuario.usuario = txtusuario.Text;

            servicios.agregar_usuario(usuario);
        }
        private bool validar_usuario()
        {
            string usuario = txtusuario.Text;
          return  servicios.validar_noombre_usuario(usuario);
        }

        #endregion

        
    }
}
