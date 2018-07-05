using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S04_04Entidades;
using S04_02LogicaNegocio;

namespace S04_01Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios usuarios = new Usuarios();
                usuarios.nombreUsuario = txtUserName.Text.Trim();
                usuarios.pass = txtPassword.Text.Trim();

                if (Logica.VerificarUsuario(usuarios)) //Si el usuario esta bien
                {
                   S04_App frm = new S04_App();

                    frm.NOMBREUSUARIO = txtUserName.Text.Trim(); //Asigna usuario de inicio de sesion
                    frm.MostrarNombre(); //Muestrelo en la parte inferior del menu
                    frm.CargarOpcionesMenuSegunPerfil();

                    frm.Show();

                    this.Hide();
                }
                else
                    MessageBox.Show("Usuario incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n"+ex);
            }
        }
    }
}

