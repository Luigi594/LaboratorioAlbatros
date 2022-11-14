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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormHijo(new FrmClientes());
        }

        private void FormHijo(object formHijo)
        {
            // si existe un control previo
            if(panelContenedor.Controls.Count > 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }

            Form hijo = formHijo as Form;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(hijo);
            panelContenedor.Tag = hijo;
            hijo.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormHijo(new FrmProductos());
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            FormHijo(new FrmFactura());
        }
    }
}
