using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmClientes : Form
    {
        ClsCliente cliente = new ClsCliente();
        private string id_cliente = null;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
            txtNombreCliente.Focus();
        }

        private void ListarClientes()
        {
            ClsCliente cliente = new ClsCliente();
            dtgClientes.DataSource = cliente.ListaClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente();
        }


        private void AgregarCliente()
        {
            try
            {
                if(txtNombreCliente.Text == "" || txtDireccion.Text == "" || txtRtn.Text == "")
                {
                    MessageBox.Show("Es necesario llenar todos los espacios", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(txtNombreCliente.Text.Length < 3)
                {
                    MessageBox.Show("Ingresar nombre completo del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombreCliente.Focus();
                }
                else if(txtRtn.Text.Length < 14)
                {
                    MessageBox.Show("Ingresar RTN completo", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRtn.Focus();
                }
                else if(txtDireccion.Text.Length < 8)
                {
                    MessageBox.Show("Ingresar direccion válida", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDireccion.Focus();
                }
                else
                {
                    cliente.Nombre = txtNombreCliente.Text.ToString();
                    cliente.Rtn = txtRtn.Text.ToString();
                    cliente.Direccion = txtDireccion.Text.ToString();

                    if (cliente.VerificarExistenciaCliente() == 0)
                    {
                        cliente.InsertarNuevoCliente();
                        MessageBox.Show("El registro se agregó correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                        LimpiarTextos();
                    }
                    else
                    {
                        MessageBox.Show("El registro que usted intenta ingresar ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRtn.Focus();
                        cliente.Rtn = txtRtn.Text = "";
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void LimpiarTextos()
        {
            txtNombreCliente.Text = "";
            txtRtn.Text = "";
            txtDireccion.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreCliente.Text == "" || txtDireccion.Text == "" || txtRtn.Text == "")
                {
                    MessageBox.Show("Es necesario llenar todos los espacios", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txtNombreCliente.Text.Length < 3)
                {
                    MessageBox.Show("Ingresar nombre completo del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombreCliente.Focus();
                }
                else if (txtRtn.Text.Length < 14)
                {
                    MessageBox.Show("Ingresar RTN completo", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRtn.Focus();
                }
                else if (txtDireccion.Text.Length < 8)
                {
                    MessageBox.Show("Ingresar direccion válida", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDireccion.Focus();
                }
                else
                {
                    cliente.Nombre = txtNombreCliente.Text.ToString();
                    cliente.Rtn = txtRtn.Text.ToString();
                    cliente.Direccion = txtDireccion.Text.ToString();

                    cliente.EditarCliente(id_cliente);
                    MessageBox.Show("El registro se modificó correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                    LimpiarTextos();
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;

            if (dtgClientes.SelectedRows.Count > 0)
            {
                txtNombreCliente.Text = dtgClientes.CurrentRow.Cells["nombre"].Value.ToString();
                txtRtn.Text = dtgClientes.CurrentRow.Cells["rtn"].Value.ToString();
                txtDireccion.Text = dtgClientes.CurrentRow.Cells["direccion"].Value.ToString();
                id_cliente = dtgClientes.CurrentRow.Cells["id_cliente"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de querer eliminar este registro", "Eliminación Cliente",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if(respuesta == DialogResult.Yes)
                {
                    cliente.EliminarCliente(id_cliente);
                    MessageBox.Show("El registro se eliminó correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                    LimpiarTextos();
                    btnAgregar.Enabled = true;
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            BindingSource filtro = new BindingSource();
            filtro.DataSource = dtgClientes.DataSource;
            filtro.Filter = "nombre like '%" + txtFiltro.Text + "%'" +
                "or rtn '%" + txtFiltro.Text + "%'";
            dtgClientes.DataSource = filtro; 
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                MessageBox.Show("Introducir únicamente letras", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void txtRtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Introducir únicamente números para el RTN", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
