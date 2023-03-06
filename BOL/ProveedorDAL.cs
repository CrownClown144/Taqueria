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
    public class ProveedorDAL
    {
        #region Singleton
        private static volatile ProveedorDAL instance = null;
        public static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private ProveedorDAL() { }

        public static ProveedorDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ProveedorDAL();
            return instance;
        }
        #endregion

        #region Metodos
        public int Add(Proveedor proveedor)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@nombre", proveedor.nombre);
                string query = "stp_AddSupplier";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Delete(Proveedor proveedor)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idProveedor", proveedor.idProveedor);
                string query = "stp_DeleteSupplier";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Proveedores GetAll()
        {
            try
            {
                string query = "stp_GetAllSupplier";
                DataTable resultado = dataAccess.Query(query);
                Proveedores proveedores = new Proveedores();
                foreach (DataRow item in resultado.Rows)
                {
                    proveedores.Add(new Proveedor()
                    {
                        idProveedor = (int)item["idProveedor"],
                        nombre = (string)item["Nombre"],
                        activo = (bool)item["Activo"]
                    });
                }
                return proveedores;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Update(Proveedor proveedor)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@idProveedor", proveedor.idProveedor);
                parameters[1] = new SqlParameter("@Nombre", proveedor.nombre);
                string query = "stp_UpdateSupplier";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Proveedores GetByName(Proveedor proveedor)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@nombre", proveedor.nombre);
                string query = "stp_GetByNameSupplier";
                DataTable resultado = dataAccess.Query(query, parameters);

                Proveedores proveedores = new Proveedores();
                foreach (DataRow item in resultado.Rows)
                {
                    proveedores.Add(new Proveedor()
                    {
                        idProveedor = (int)item["idProveedor"],
                        nombre = (string)item["Nombre"],
                        activo = (bool)item["Activo"]
                    });
                }
                return proveedores;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Proveedores GetOnlySupplierActive()
        {
            try
            {
                string query = "stp_GetOnlySupplierActive";
                DataTable resultado = dataAccess.Query(query);
                Proveedores proveedores = new Proveedores();
                foreach (DataRow item in resultado.Rows)
                {
                    proveedores.Add(new Proveedor()
                    {
                        idProveedor = (int)item["idProveedor"],
                        nombre = (string)item["Nombre"],
                        activo = (bool)item["Activo"]
                    });
                }
                return proveedores;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Proveedores GetOnlySupplierInactive()
        {
            try
            {
                string query = "stp_GetOnlySupplierInactive";
                DataTable resultado = dataAccess.Query(query);
                Proveedores proveedores = new Proveedores();
                foreach (DataRow item in resultado.Rows)
                {
                    proveedores.Add(new Proveedor()
                    {
                        idProveedor = (int)item["idProveedor"],
                        nombre = (string)item["Nombre"],
                        activo = (bool)item["Activo"]
                    });
                }
                return proveedores;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Restore(Proveedor proveedor)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idProveedor", proveedor.idProveedor);
                string query = "stp_RestoreSupplier";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }
        public Proveedor GetIdByName(Proveedor proveedor)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@nombre", proveedor.nombre);
                string query = "stp_GetByIdByNameSupplier";
                DataTable resultado = dataAccess.Query(query, parameters);

                Proveedores proveedores = new Proveedores();
                foreach (DataRow item in resultado.Rows)
                {
                    proveedores.Add(new Proveedor()
                    {
                        idProveedor = (int)item["idProveedor"]
                    });
                }
                return proveedor;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }
        #endregion
    }
}
