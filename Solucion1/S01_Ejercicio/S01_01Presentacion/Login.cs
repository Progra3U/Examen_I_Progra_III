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
       // private int intentos = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

             
                    Usuario usuarios = new Usuario();
                    usuarios.nombreUsuario = txtUserName.Text.Trim();
                    usuarios.pass = txtPassword.Text.Trim();

            
                    if (LN.VerificarUsuario(usuarios)) //Si el usuario esta bien
                    {
                    this.DialogResult = DialogResult.OK;
                    //  FrmMenu frm = new FrmMenu();
                    Bienvenida bn = new Bienvenida();
                 
                     bn.Show();
                     this.Hide();
                    }
                    else
                   
                     MessageBox.Show("Usuario incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
