using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class ClsProducto
    {
        private DataProducto producto = new DataProducto();

        private string descripcion;
        private string precio;
        private int id_impuesto;

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Precio { get => precio; set => precio = value; }
        public int Id_impuesto { get => id_impuesto; set => id_impuesto = value; }

        // método para llenar el combobox de los impuestos
        public DataTable LlenarComboboxImpuesto()
        {
            DataTable tabla = new DataTable();
            tabla = producto.LlenarComboBoxImpuesto();
            return tabla;
        }

        public DataTable ListaProductos()
        {
            DataTable dt = new DataTable();
            dt = producto.ListarProductos();
            return dt;
        }

        /*public void BuscarProductos()
        {
            producto.BuscarProductos(descripcion);
        }*/

        public void InsertarNuevoProducto()
        {
            producto.InsertarProductos(descripcion, Convert.ToDouble(precio), id_impuesto);
        }

        public void EditarProducto(string codigo)
        {
            producto.EditarProducto(Convert.ToInt32(codigo), descripcion, Convert.ToDouble(precio), id_impuesto);
        }

        public void EliminarProducto(string codigo)
        {
            producto.EliminarProducto(Convert.ToInt32(codigo));
        }
    }
}
