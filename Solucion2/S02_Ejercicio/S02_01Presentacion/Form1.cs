using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S02_04Entidades;
using S02_02LogicaNegocio;
using System.Globalization;

namespace S02_01Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region CargarPersonal
        private void CargarPersonal()
        {
            try
            {
                List<RegistroPersonal> lstPersonas = Logica.ObtenerPersonal();

                if (dataGridView.Rows.Count > 0)
                {
                    dataGridView.DataSource = null; //Limpia el gridview
                    dataGridView.Refresh();
                }
                this.dataGridView.DataSource = lstPersonas;
                this.dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region DataGridView_CellClick
         private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtCodigoEmpleado.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtNombre.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txtIdEmpleado.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txtPosicion.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txtArea.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Load del form
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CargarPersonal();
        }
        #endregion

        #region Limpiar
        private void Limpiar()
        {
            txtCodigoEmpleado.Text = "";
            txtNombre.Text = "";
            txtIdEmpleado.Text = "";
            txtPosicion.Text = "";
            txtArea.Text = "";
        }
        #endregion

        #region Accion de botones
        private RegistroPersonal procesobase()
        {
            RegistroPersonal personal = new RegistroPersonal();

            string hora, fecha;
            hora = DateTime.Now.ToString("hh:mm");
            fecha = DateTime.Now.ToString("dd/MM/yyyy");

            personal.codEntrada = Convert.ToInt32(txtCodigoEmpleado.Text.Trim());
            personal.nombreEmpleado = txtNombre.Text.Trim();
            personal.identificacion = Convert.ToInt32(txtIdEmpleado.Text.Trim());
            personal.posicion = txtPosicion.Text.Trim();
            personal.area = txtArea.Text.Trim();
            personal.fechaEntrada = fecha;
            personal.horaEntrada = hora;
            personal.fechaSalida = fecha;
            personal.horaSalida = hora;
            return personal;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RegistroPersonal personal = new RegistroPersonal();
                personal.codEntrada = Convert.ToInt32(txtCodigoEmpleado.Text.Trim());
                personal.nombreEmpleado = txtNombre.Text.Trim();
                personal.identificacion = Convert.ToInt32(txtIdEmpleado.Text.Trim());
                personal.posicion = txtPosicion.Text.Trim();
                personal.area = txtArea.Text.Trim();
                personal.fechaEntrada = "";
                personal.horaEntrada = "";
                personal.fechaSalida = "";
                personal.horaSalida = "";
                S02_02LogicaNegocio.Logica.AgregarPersonal(personal);
                CargarPersonal(); Limpiar();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error \n" + ex.Message + "\nal Guardar Datos en Tabla RegistroPersonal");
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                S02_02LogicaNegocio.Logica.ModificarPersonal(procesobase());
                CargarPersonal(); Limpiar();
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n" + ex.Message + "\nal Editar Datos en Tabla RegistroPersonal");
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoEmpleado.Text.Equals(" "))
                {
                    RegistroPersonal search = new RegistroPersonal();
                    search.identificacion = Convert.ToInt32(txtCodigoEmpleado.Text.Trim());
                    List<RegistroPersonal> lstbusquedas = S02_02LogicaNegocio.Logica.BuscarPersonal(search);

                    this.dataGridView.DataSource = lstbusquedas;
                    this.dataGridView.Refresh();
                }
                else if (txtCodigoEmpleado.Text.Equals(" "))
                {
                    CargarPersonal();
                }
            }
            catch (Exception ex)
            {
                CargarPersonal();
                //MessageBox.Show("Error \n" + ex.Message + "\nal Encontrar Datos en Tabla RegistroPersonal");
            }
            Limpiar();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                RegistroPersonal personal = new RegistroPersonal();

                string hora, fecha;
                hora = DateTime.Now.ToString("hh:mm");
                fecha = DateTime.Now.ToString("dd/MM/yyyy");

                personal.codEntrada = Convert.ToInt32(txtCodigoEmpleado.Text.Trim());
                personal.nombreEmpleado = txtNombre.Text.Trim();
                personal.identificacion = Convert.ToInt32(txtIdEmpleado.Text.Trim());
                personal.posicion = txtPosicion.Text.Trim();
                personal.area = txtArea.Text.Trim();
                personal.fechaEntrada = fecha;
                personal.horaEntrada = hora;
                personal.fechaSalida = "";
                personal.horaSalida = "";
                S02_02LogicaNegocio.Logica.ModificarHoraEntrada(personal);
                CargarPersonal(); Limpiar();
                //MessageBox.Show("Persona Editada");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n" + ex.Message + "\nal Insertar hora de Entrada");
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                S02_02LogicaNegocio.Logica.ModificarHoraSalida(procesobase());
                CargarPersonal(); Limpiar();
                //MessageBox.Show("Persona Editada");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n" + ex.Message + "\nal Insertar hora de Salida");
            }
        }
        #endregion
    }
}
