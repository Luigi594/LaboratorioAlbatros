using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DataCliente
    {
        private ClsConexionBd conexion = new ClsConexionBd();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;

        // método para listar los clientes
        public DataTable ListarClientes()
        {
            DataTable tabla = new DataTable();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "Select * from Clientes";
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            tabla.Load(reader);
            command.Connection = conexion.CerrarConexion();
            return tabla;
        }

        // método para insertar el registro de cliente
        public void InsertarCliente(string nombre, string rtn, string direccion)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "InsertarClientes";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@rtn", rtn);
            command.Parameters.AddWithValue("@direccion", direccion);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }

        // verificar si ya existe un registro
        public int ExistenciaCliente(string rtn)
        {
            int existe = 0;
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "VerificarExistenciaCliente";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@rtn", rtn);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                // en el procedimiento le di un alias al resultado que trae, en caso que
                // el registro existaa
                existe = Convert.ToInt32(reader["Existente"]);
            }

            reader.Close();
            command.Connection = conexion.CerrarConexion();

            return existe;
        }

        // método para modificar los registros
        public void EditarCliente(string nombre, string rtn, string direccion, int codigo)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "ActualizarCliente";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_cliente", codigo);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@rtn", rtn);
            command.Parameters.AddWithValue("@direccion", direccion);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion();
        }

        // eliminar registro
        public void EliminarCliente(int codigo)
        {
            command.Parameters.Clear();
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "EliminarCliente";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_cliente", codigo);
            command.ExecuteNonQuery();
            command.Connection = conexion.CerrarConexion(); 
        }
    }
}
