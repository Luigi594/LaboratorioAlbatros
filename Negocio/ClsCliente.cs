using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClsCliente
    {
        private DataCliente cliente = new DataCliente();

        private string nombre;
        private string rtn;
        private string direccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Rtn { get => rtn; set => rtn = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        // mostras todos los clientes en el form
        public DataTable ListaClientes()
        {
            DataTable dt = new DataTable();
            dt = cliente.ListarClientes();
            return dt;
        }

        // insertar un nuevo cliente
        public void InsertarNuevoCliente()
        {
            cliente.InsertarCliente(nombre, rtn, direccion);
        }

        // este método es para verificar si un registro ya existe
        public int VerificarExistenciaCliente()
        {
            cliente = new DataCliente();
            int existe = cliente.ExistenciaCliente(rtn);
            return existe;
        }

        // actualizar el cliente
        public void EditarCliente(string codigo)
        {
            cliente.EditarCliente(nombre, rtn, direccion, Convert.ToInt32(codigo));
        }

        // eliminar cliente
        public void EliminarCliente(string codigo)
        {
            cliente.EliminarCliente(Convert.ToInt32(codigo));
        }
    }
}
