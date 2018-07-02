using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S03_02LogicaNegocio;
using S03_04Entidades;

namespace S03_01Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CargarPersonas()
        {
            try
            {
                List<RegistroPersonas> lstPersonas = Logica.ObtenerPersonas();

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

        private void Limpiar()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtemail.Text = "";
            txtTelefono.Text = "";
            txtPais.Text = "";
            txtCiudad.Text = "";
            txtDetalles.Text = "";
            txtBuscarId.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CargarPersonas();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtIdentificacion.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtNombre.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txtApellido.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txtEdad.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txtemail.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txtTelefono.Text = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.txtPais.Text = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.txtCiudad.Text = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.txtDetalles.Text = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private RegistroPersonas procesobase()
        {
            RegistroPersonas persona = new RegistroPersonas();
            persona.identificacion = Convert.ToInt32(txtIdentificacion.Text.Trim());
            persona.nombre = txtNombre.Text.Trim();
            persona.apellido = txtApellido.Text.Trim();
            persona.edad = Convert.ToInt32(txtEdad.Text.Trim());
            persona.correo = txtemail.Text.Trim();
            persona.tetefono = Convert.ToInt32(txtTelefono.Text.Trim());
            persona.pais = txtPais.Text.Trim();
            persona.ciudad = txtCiudad.Text.Trim();
            persona.detalles = txtDetalles.Text.Trim();
            return persona;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Logica.ValidarCampoPorPatron(@"^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", txtemail.Text.Trim()))
                {
                    if (Logica.ValidarCampoPorPatron(@"^[0-9]{8,8}$", txtTelefono.Text.Trim()))
                    {
                        if (Logica.ValidarCampoPorPatron(@"^[a-zA-Z]+[a-zA-Z]$", txtNombre.Text.Trim()))
                        {
                            if (Logica.ValidarCampoPorPatron(@"^[a-zA-Z]+[a-zA-Z]$", txtApellido.Text.Trim()))
                            {
                                if (Convert.ToInt32(txtEdad.Text.Trim()) > 0 && Convert.ToInt32(txtEdad.Text.Trim()) <= 99)
                                {
                                    S03_02LogicaNegocio.Logica.AgregarPersona(procesobase());
                                    CargarPersonas(); Limpiar();
                                    //MessageBox.Show("Persona Agregada");
                                }
                                else
                                    MessageBox.Show("Formato de Edad incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("Formato de Apellido incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Formato de Nombre incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Formato de telefono incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Formato de Correo incorrecto","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error \n" + ex.Message + "\nal Guardar Datos en Tabla RegistroPersonas");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Logica.ValidarCampoPorPatron(@"^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", txtemail.Text.Trim()))
                {
                    if (Logica.ValidarCampoPorPatron(@"^[0-9]{8,8}$", txtTelefono.Text.Trim()))
                    {
                        if (Logica.ValidarCampoPorPatron(@"^[a-zA-Z]+[a-zA-Z]$", txtNombre.Text.Trim()))
                        {
                            if (Logica.ValidarCampoPorPatron(@"^[a-zA-Z]+[a-zA-Z]$", txtApellido.Text.Trim()))
                            {
                                if (Convert.ToInt32(txtEdad.Text.Trim()) > 0 && Convert.ToInt32(txtEdad.Text.Trim()) <= 99)
                                {
                                    S03_02LogicaNegocio.Logica.ModificarPersona(procesobase());
                                    CargarPersonas(); Limpiar();
                                    //MessageBox.Show("Persona Editada");
                                }
                                else
                                    MessageBox.Show("Formato de Edad incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("Formato de Apellido incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Formato de Nombre incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Formato de telefono incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Formato de Correo incorrecto","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n" + ex.Message + "\nal Editar Datos en Tabla RegistroPersonas");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                S03_02LogicaNegocio.Logica.EliminarPersona(procesobase());
                CargarPersonas(); Limpiar();
                this.dataGridView.Refresh();
                //MessageBox.Show("Persona Editada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n" + ex.Message + "\nal Eliminar Datos en Tabla RegistroPersonas");
            }
        }

        private void btnBuscarPorId_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtBuscarId.Text.Equals(""))
                {
                    RegistroPersonas search = new RegistroPersonas();
                    search.identificacion = Convert.ToInt32(txtBuscarId.Text.Trim());
                    List<RegistroPersonas> lstbusquedas = S03_02LogicaNegocio.Logica.BuscarPersona(search);

                    this.dataGridView.DataSource = lstbusquedas;
                    this.dataGridView.Refresh();

                }
                else if (txtBuscarId.Text.Equals(""))
                {
                    CargarPersonas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n" + ex.Message + "\nal Encontrar Datos en Tabla RegistroPersonas");
            }
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
