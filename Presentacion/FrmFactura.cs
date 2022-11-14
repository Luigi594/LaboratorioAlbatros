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
    public partial class FrmFactura : Form
    {
        ClsCliente cliente = new ClsCliente();
        ClsProducto producto = new ClsProducto();

        public FrmFactura()
        {
            InitializeComponent();
            ListarClientesDisponibles();
            cmbClientes.SelectedIndex = -1;
        }

        private void ListarClientesDisponibles()
        {
            cmbClientes.DataSource = cliente.ListaClientes();
            cmbClientes.DisplayMember = "nombre";
            cmbClientes.ValueMember = "id_cliente";
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            ListarClientesDisponibles();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
