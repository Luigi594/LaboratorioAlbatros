using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataProducto
    {

        private ClsConexionBd conexion = new ClsConexionBd();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;

        // este método se utilizará para llenar los campos del combobox para 
        // seleccionar el impuesto
        public DataTable LlenarComboBoxImpuesto()
        {
            DataTable cmb = new DataTable();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "Select * from Impuesto";
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            cmb.Load(reader);
            reader.Close();
            command.Connection = conexion.CerrarConexion();

            return cmb;
        }

        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "Select p.id_producto, i.descripcion as impuesto, p.descripcion, p.precio " +
                "from Productos p inner join Impuesto i on p.id_impuesto = i.id_impuesto";
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            tabla.Load(reader);
            command.Connection = conexion.CerrarConexion();
            return tabla;
        }

        /*public void BuscarProductos(string descripcion)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "BuscarProducto";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@descripcion", descripcion);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }*/

        public void InsertarProductos(string descripcion, double precio, int id_impuesto)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "InsertarProductos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@descripcion", descripcion);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@id_impuesto", id_impuesto);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }

        public void EditarProducto(int id_producto, string descripcion, double precio, int id_impuesto)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "EditarProducto";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", id_producto);
            command.Parameters.AddWithValue("@descripcion", descripcion);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@id_impuesto", id_impuesto);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }

        public void EliminarProducto(int codigo)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "EliminarProducto";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", codigo);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }
    }
}
