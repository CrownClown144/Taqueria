using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ClienteDAL
    {
        #region Singleton
        private static volatile ClienteDAL instance = null;
        public static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private ClienteDAL() { }

        public static ClienteDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ClienteDAL();
            return instance;
        }
        #endregion

        #region Metodos
        public int Add(Cliente cliente)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@nombre", cliente.nombre);
                parameters[1] = new SqlParameter("@direccion", cliente.direccion);
                parameters[2] = new SqlParameter("@telefono", cliente.telefono);
                string query = "stp_AddClient";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Delete(Cliente cliente)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCliente", cliente.idCliente);
                string query = "stp_DeleteClient";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Clientes GetAll()
        {
            try
            {
                string query = "stp_GetAllClient";
                DataTable resultado = dataAccess.Query(query);
                Clientes clientes = new Clientes();
                foreach (DataRow item in resultado.Rows)
                {
                    clientes.Add(new Cliente()
                    {
                        idCliente = (int)item["idCliente"],
                        nombre = (string)item["Nombre"],
                        direccion = (string)item["Direccion"],
                        telefono = (string)item["Telefono"]
                    });
                }
                return clientes;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Update(Cliente cliente)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@idCliente", cliente.idCliente);
                parameters[1] = new SqlParameter("@Nombre", cliente.nombre);
                parameters[2] = new SqlParameter("@direccion", cliente.direccion);
                parameters[3] = new SqlParameter("@telefono", cliente.telefono);
                string query = "stp_UpdateClient";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Clientes GetByName(Cliente cliente)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@nombre", cliente.nombre);
                string query = "stp_GetByNameClient";
                DataTable resultado = dataAccess.Query(query, parameters);

                Clientes clientes = new Clientes();
                foreach (DataRow item in resultado.Rows)
                {
                    clientes.Add(new Cliente()
                    {
                        idCliente = (int)item["idCliente"],
                        nombre = (string)item["Nombre"],
                        direccion = (string)item["Direccion"],
                        telefono = (string)item["Telefono"]
                    });
                }
                return clientes;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }
        #endregion
    }
}
