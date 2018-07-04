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
    public partial class S04_Perfiles : Form
    {
        public S04_Perfiles()
        {
            InitializeComponent();
        }

        #region CargarPerfiles
        private void CargarPerfiles()
        {
            try
            {
                DataTable dt = new DataTable(); //Variable de tipo tabla en memoria

                //Definir las columnas a mostrar
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Perfil");
                dt.Columns.Add("Estado");

                //Carga en memoria registros de BD
                List<Perfiles> lstperfiles = Logica.ObtenerPerfiles();

                if (dgvPerfiles.Rows.Count > 0)
                {
                    dgvPerfiles.DataSource = null; //Limpia el gridview
                    dgvPerfiles.Refresh();
                }

                foreach (Perfiles item in lstperfiles)
                {
                    string estado = String.Empty;
                    if (item.activo)
                        estado = "Activo";
                    else
                        estado = "Inactivo";
                    //Aqui se agrega a la Tabla en memoria el registro
                    dt.Rows.Add(item.codPerfil, item.nombrePerfil, estado);
                }
                this.dgvPerfiles.DataSource = dt; //Se asigna la tabla formateada al grid
                this.dgvPerfiles.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Limpiar
        private void Limpiar()
        {
            this.txtCodigo.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.cboEstado.SelectedIndex = 0;
            this.txtCodigo.Focus();
        }
        #endregion

        #region Accion Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Perfiles objperfiles = new Perfiles();

                objperfiles.codPerfil = Convert.ToInt32(txtCodigo.Text.Trim());
                objperfiles.nombrePerfil = txtNombre.Text.Trim();
                if (this.cboEstado.Text.Equals("Activo"))
                    objperfiles.activo = true;
                else
                    objperfiles.activo = false;

                S04_02LogicaNegocio.Logica.AgregarPerfil(objperfiles);
                MessageBox.Show("Perfil agregado");
                CargarPerfiles();
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
                Perfiles objperfiles = new Perfiles();

                objperfiles.codPerfil = Convert.ToInt32(txtCodigo.Text.Trim());
                objperfiles.nombrePerfil = txtNombre.Text.Trim();
                if (this.cboEstado.Text.Equals("Activo"))
                    objperfiles.activo = true;
                else
                    objperfiles.activo = false;

                S04_02LogicaNegocio.Logica.ModificarPerfil(objperfiles);
                MessageBox.Show("Perfil actualizado");
                CargarPerfiles();
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
                Perfiles objperfiles = new Perfiles();

                objperfiles.codPerfil = Convert.ToInt32(txtCodigo.Text.Trim());

               S04_02LogicaNegocio.Logica.EliminarPerfil(objperfiles);
                MessageBox.Show("Perfil eliminado");
                CargarPerfiles();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region evento CellClick
        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtCodigo.Text = dgvPerfiles.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtNombre.Text = dgvPerfiles.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvPerfiles.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("Activo"))
                    this.cboEstado.Text = "Activo";
                else
                    this.cboEstado.Text = "Inactivo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void S04_Perfiles_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
        }
    }
}
