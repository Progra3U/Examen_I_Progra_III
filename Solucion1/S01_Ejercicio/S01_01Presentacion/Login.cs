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
        private int intentos = 3;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*
             try
            {             
                    Usuarios usuarios = new Usuarios();
                    usuarios.nombreUsuario = txtUserName.Text.Trim();
                    usuarios.pass = txtPassword.Text.Trim();


                if (LN.VerificarUsuarios(usuarios)) //Si el usuario esta bien
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
            }*/
            try
            {
                
                Usuarios usuarios = new Usuarios();
                usuarios.nombreUsuario = this.txtUserName.Text.Trim();
                usuarios.pass = this.txtPassword.Text.Trim();
                usuarios.activo = true;
                if (LN.VerificarUsuarios(usuarios))
                {
                    // MessageBox.Show("Usuario si existe");
                    Bienvenida bn = new Bienvenida();
                    bn.ShowDialog();
                    intentos = 3;
                }
                else
                {
                    MessageBox.Show("Usuario no existe");
                    intentos--;
                    if (intentos == 0)
                    {
                        MessageBox.Show("Usuario Bloqueado");
                        usuarios.activo = false;
                        S01_02LogicaNegocio.LN.ModificarUsuarios(usuarios);
                    }

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /* public static void nuevaPantalla()
         {
             Bienvenida bn = new Bienvenida();

             bn.Show();

         }*/

        /*private static void NewMethod1(Usuarios usuarios)
        {
            bool retorno = LN.VerificarUsuarios(usuarios);
            if (retorno != true)
            {
                MessageBox.Show("Usuario no esta activo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                MessageBox.Show("Usuario correcto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nuevaPantalla();
            }

        }*/

    }
}
