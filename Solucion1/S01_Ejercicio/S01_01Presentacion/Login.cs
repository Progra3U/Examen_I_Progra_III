using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S01_01Entidades;
using S01_02LogicaNegocio;


namespace S01_01Presentacion
{
   
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
          
    }
        private int intentos = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {             
                    Usuario usuarios = new Usuario();
                    usuarios.nombreUsuario = txtUserName.Text.Trim();
                    usuarios.pass = txtPassword.Text.Trim();


                if (LN.VerificarUsuario(usuarios)) //Si el usuario esta bien
                {


                    MessageBox.Show("Usuario correcto", "Aviso", MessageBoxButtons.OK);
                    nuevaPantalla();

                }

                else
                {                 
                     MessageBox.Show("Contraseña incorrecta o Usuario inactivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos++;

                    if (intentos == 3)
                    {
                        this.txtUserName.Text = String.Empty;
                        this.txtPassword.Text = String.Empty;
                        usuarios.activo = false;
                        LN.ModificarUsuarios(usuarios);
                        intentos = 0;
                        MessageBox.Show("Usuario Bloqueado comuniquese con su administrador mas cercano", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
                    }

                }
            }
                  catch (Exception ex)
                     {
                         throw ex;
            }
        }

        public static void nuevaPantalla()
        {
            Bienvenida bn = new Bienvenida();

            bn.Show();
            

        }
        private static void NewMethod1(Usuario usuarios)
        {
            bool retorno = LN.VerificarUsuario(usuarios);
            if (retorno != true)
            {
                MessageBox.Show("Usuario no esta activo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                MessageBox.Show("Usuario correcto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nuevaPantalla();
            }

        }

    }
}
