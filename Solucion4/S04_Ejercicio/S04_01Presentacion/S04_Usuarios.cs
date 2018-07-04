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
    public partial class S04_Usuarios : Form
    {

        private void CargarUsuarios()
        {
            try
            {
                DataTable dt = new DataTable(); //Variable de tipo tabla en memoria

                //Definir las columnas a mostrar
                dt.Columns.Add("Usuario");
                dt.Columns.Add("Clave");
                dt.Columns.Add("Estado");

                //Carga en memoria registros de BD
                List<Usuarios> lstusuarios = Logica.ObtenerUsuarios();

                if (dgvUsuarios.Rows.Count > 0)
                {
                    dgvUsuarios.DataSource = null; //Limpia el gridview
                    dgvUsuarios.Refresh();
                }

                foreach (Usuarios item in lstusuarios)
                {
                    string estado = String.Empty;
                    if (item.activo)
                        estado = "Activo";
                    else
                        estado = "Inactivo";
                    //Aqui se agrega a la Tabla en memoria el registro
                    dt.Rows.Add(item.nombreUsuario, item.pass, estado);
                }
                this.dgvUsuarios.DataSource = dt; //Se asigna la tabla formateada al grid
                this.dgvUsuarios.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Limpiar()
        {
            this.txtUsuario.Text = String.Empty;
            this.txtClave.Text = String.Empty;
            this.cboEstado.SelectedIndex = 0;
            this.txtUsuario.Focus();
        }
        public S04_Usuarios()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios objusuario = new Usuarios();

                objusuario.nombreUsuario = txtUsuario.Text.Trim();
                objusuario.pass = txtClave.Text.Trim();
                if (this.cboEstado.Text.Equals("Activo"))
                    objusuario.activo = true;
                else
                    objusuario.activo = false;

                S04_02LogicaNegocio.Logica.AgregarUsuario(objusuario);
                MessageBox.Show("Usuario guardado");
                CargarUsuarios();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios objusuario = new Usuarios();

                objusuario.nombreUsuario = txtUsuario.Text.Trim();
                objusuario.pass = txtClave.Text.Trim();
                if (this.cboEstado.Text.Equals("Activo"))
                    objusuario.activo = true;
                else
                    objusuario.activo = false;

                S04_02LogicaNegocio.Logica.ModificarUsuarios(objusuario);
                MessageBox.Show("Usuario actualizado");
                CargarUsuarios();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios objusuario = new Usuarios();

                objusuario.nombreUsuario = txtUsuario.Text.Trim();

               S04_02LogicaNegocio.Logica.EliminarUsuarios(objusuario);
                MessageBox.Show("Usuario eliminado");
                CargarUsuarios();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
    }
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtClave.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("Activo"))
                    this.cboEstado.Text = "Activo";
                else
                    this.cboEstado.Text = "Inactivo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
