using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataFactura
    {
        private ClsConexionBd conexion = new ClsConexionBd();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;

        public void InsertarFactura(int id_cliente, DateTime fecha, double impuesto, double subtotal)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "InsertarFactura";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_cliente", id_cliente);
            command.Parameters.AddWithValue("@fecha", fecha);
            command.Parameters.AddWithValue("@impuesto", impuesto);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }

        public void InsertarDetalleFactura(int id_producto, int cantidad, double precio)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "InsertarDetalleFactura";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", id_producto);
            command.Parameters.AddWithValue("@cantidad", cantidad);
            command.Parameters.AddWithValue("@precio", precio);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }
    }
}
