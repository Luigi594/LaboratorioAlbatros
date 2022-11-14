using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClsFactura
    {
        private DataFactura factura = new DataFactura();

        private int id_cliente;
        private string fecha;
        private double impuesto;
        private double total;
        private int id_producto;
        private int cantidad;
        private double precio;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public double Impuesto { get => impuesto; set => impuesto = value; }
        public double Total { get => total; set => total = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }


        public void InsertarFactura()
        {
            factura.InsertarFactura(id_cliente, Convert.ToDateTime(fecha), impuesto, total);
        }

        public void InsertarDetalleFactura()
        {
            factura.InsertarDetalleFactura(id_producto, cantidad, precio);
        }
    }
}
