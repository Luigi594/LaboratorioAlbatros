using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmProductos : Form
    {
        ClsProducto producto = new ClsProducto();
        private string id_producto = null;
        public FrmProductos()
        {
            InitializeComponent();

            ListarImpuestos();
            cmbImpuesto.SelectedIndex = -1;
        }

        private void ListarProductos()
        {
            ClsProducto producto = new ClsProducto();
            dtvProductos.DataSource = producto.ListaProductos();
        }

        private void ListarImpuestos()
        {
            cmbImpuesto.DataSource = producto.LlenarComboboxImpuesto();
            cmbImpuesto.DisplayMember = "descripcion";
            cmbImpuesto.ValueMember = "id_impuesto";
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void AgregarProducto()
        {
            try
            {
                producto.Descripcion = txtProducto.Text.ToString();
                producto.Precio = txtPrecio.Text.ToString();
                producto.Id_impuesto = Convert.ToInt32(cmbImpuesto.SelectedValue);
                
                producto.InsertarNuevoProducto();
                MessageBox.Show("El producto se agregó correctamente", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarProductos();
                LimpiarTextos();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void LimpiarTextos()
        {
            txtProducto.Text = "";
            txtPrecio.Text = "";
            cmbImpuesto.SelectedIndex = -1;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;

            if (dtvProductos.SelectedRows.Count > 0)
            {
                txtProducto.Text = dtvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text = dtvProductos.CurrentRow.Cells["precio"].Value.ToString();
                cmbImpuesto.Text = dtvProductos.CurrentRow.Cells["impuesto"].Value.ToString();
                id_producto = dtvProductos.CurrentRow.Cells["id_producto"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtProducto.Text == "" || txtPrecio.Text == "" || cmbImpuesto.SelectedIndex < 0)
                {
                    MessageBox.Show("Es necesario llenar todos los espacios", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txtProducto.Text.Length < 3)
                {
                    MessageBox.Show("Ingresar descripcioni del producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtProducto.Focus();
                }
                else if (txtPrecio.Text.Length < 5)
                {
                    MessageBox.Show("Ingresar un precio válido", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPrecio.Focus();
                }
                else
                {
                    producto.Descripcion = txtProducto.Text.ToString();
                    producto.Precio = txtPrecio.Text.ToString();
                    producto.Id_impuesto = Convert.ToInt32(cmbImpuesto.SelectedValue);

                    producto.EditarProducto(id_producto);
                    MessageBox.Show("El registro se modificó correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarProductos();
                    LimpiarTextos();
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de querer eliminar este registro", "Eliminación Producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (respuesta == DialogResult.Yes)
                {
                    producto.EliminarProducto(id_producto);
                    MessageBox.Show("El registro se eliminó correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarProductos();
                    LimpiarTextos();
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            BindingSource filtro = new BindingSource();
            filtro.DataSource = dtvProductos.DataSource;
            filtro.Filter = "descripcion like '%" + txtFiltro.Text + "%'";
            dtvProductos.DataSource = filtro;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Introducir únicamente números para el precio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
