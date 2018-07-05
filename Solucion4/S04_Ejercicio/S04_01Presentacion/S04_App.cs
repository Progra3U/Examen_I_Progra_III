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
    public partial class S04_App : Form
    {
        private string nombreusuario;
        public S04_App()
        {
            InitializeComponent();
        }

        #region Pasar NOMBREUSUARIO
        public string NOMBREUSUARIO
        {
            get { return this.nombreusuario; }
            set { this.nombreusuario = value; }
        }
        #endregion

        #region MostrarNombre
        public void MostrarNombre()
        {
            this.toolStripStatusLabel.Text = nombreusuario;
            //el el pie del formulario
        }
        #endregion

        #region CargarOpcionesMenuSegunPerfil
        public void CargarOpcionesMenuSegunPerfil()
        {
            try
            {
                Usuarios usuarios = new Usuarios();
                usuarios.nombreUsuario = nombreusuario; //Asigno usuario a consultar

                //Carga de perfiles asignados
                List<Perfiles> lstPerfilesAsignados = Logica.ObtenerPerfilesPorUsuario(usuarios);

                //recorrer resultado
                this.administracionToolStripMenuItem.Visible = false;
                this.modulo01ToolStripMenuItem.Visible = false;
                this.modulo02ToolStripMenuItem.Visible = false;
                this.modulo03ToolStripMenuItem.Visible = false;

                this.finanzasToolStripMenuItem.Visible = false;
                this.modulo01ToolStripMenuItem1.Visible = false;
                this.modulo02ToolStripMenuItem1.Visible = false;

                this.proveduriaToolStripMenuItem.Visible = false;
                this.modulo01ToolStripMenuItem2.Visible = false;
                this.modulo02ToolStripMenuItem2.Visible = false;
                this.modulo03ToolStripMenuItem1.Visible = false;

                this.mantenimientoToolStripMenuItem.Visible = false;
                this.usuariosToolStripMenuItem.Visible = false;
                this.perfilesToolStripMenuItem.Visible = false;

                foreach (Perfiles item in lstPerfilesAsignados)
                {
                    //habilitacion segun perfil asignado
                    switch (item.codPerfil)
                    {
                        case 1:
                             {
                                this.administracionToolStripMenuItem.Visible = true;
                                this.modulo01ToolStripMenuItem.Visible = true;
                                this.modulo02ToolStripMenuItem.Visible = true;
                                this.modulo03ToolStripMenuItem.Visible = true;
                                this.finanzasToolStripMenuItem.Visible = true;
                                this.modulo01ToolStripMenuItem1.Visible = true;
                             } break;
                        case 2:
                            {
                                this.finanzasToolStripMenuItem.Visible = true;
                                this.modulo02ToolStripMenuItem1.Visible = true;

                                this.proveduriaToolStripMenuItem.Visible = true;
                                this.modulo01ToolStripMenuItem2.Visible = true;
                                this.modulo02ToolStripMenuItem2.Visible = true;
                                this.modulo03ToolStripMenuItem1.Visible = true;
                            } break;
                        case 3:
                            {
                                this.mantenimientoToolStripMenuItem.Visible = true;
                                this.usuariosToolStripMenuItem.Visible = true;
                                this.perfilesToolStripMenuItem.Visible = true;
                            } break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ToolStripMenuItem
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            S04_Usuarios frm = new S04_Usuarios(); frm.ShowDialog();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            S04_Perfiles frm = new S04_Perfiles(); frm.ShowDialog();
        }
        #endregion

    }
}
