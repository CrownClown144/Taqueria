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
    public class InventarioDAL
    {
        #region Singleton
        private static volatile InventarioDAL instance = null;
        public static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private InventarioDAL() { }

        public static InventarioDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new InventarioDAL();
            return instance;
        }
        #endregion

        #region Metodos
        public int Add(Inventario inventario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@nombre", inventario.nombre);
                parameters[1] = new SqlParameter("@idCategoria", inventario.idCategoria);
                parameters[2] = new SqlParameter("@idProveedor", inventario.idProveedor);
                parameters[3] = new SqlParameter("@cantidad", inventario.cantidad);
                parameters[4] = new SqlParameter("@gramaje", inventario.gramaje);
                parameters[5] = new SqlParameter("@fecha", inventario.fecha);
                parameters[6] = new SqlParameter("@costo", inventario.costo);
                string query = "stp_AddInventory";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Delete(Inventario inventario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idInventario", inventario.idInventario);
                string query = "stp_DeleteInventory";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Inventarios GetAll()
        {
            try
            {
                string query = "stp_GetAllInventory";
                DataTable resultado = dataAccess.Query(query);
                Inventarios inventarios = new Inventarios();
                foreach (DataRow item in resultado.Rows)
                {
                    inventarios.Add(new Inventario()
                    {
                        idInventario = (int)item["idInventario"],
                        nombre = (string)item["Nombre"],
                        idCategoria = (int)item["idCategoria"],
                        idProveedor = (int)item["idProveedor"],
                        cantidad = (int)item["Cantidad"],
                        gramaje = (string)item["Gramaje"],
                        fecha = (DateTime)item["Fecha"],
                        costo = (double)item["Costo"],
                        Activo = (bool)item["Activo"]
                    });
                }
                return inventarios;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Inventario GetById(Inventario inventario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idInventario", inventario.idInventario);
                string query = "stp_GetByInventoryID";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    inventario = new Inventario()
                    {
                        idInventario = (int)resultado.Rows[0]["idInventario"],
                        nombre = (string)resultado.Rows[0]["Nombre"],
                        idCategoria = (int)resultado.Rows[0]["idCtegoria"],
                        idProveedor = (int)resultado.Rows[0]["idProveedor"],
                        cantidad = (int)resultado.Rows[0]["Cantidad"],
                        gramaje = (string)resultado.Rows[0]["Gramaje"],
                        fecha = (DateTime)resultado.Rows[0]["Fecha"],
                        costo = (double)resultado.Rows[0]["Costo"],
                        Activo = (bool)resultado.Rows[0]["Activo"]
                    };
                }
                return inventario;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Update(Inventario inventario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[8];
                parameters[0] = new SqlParameter("@idInventario", inventario.idInventario);
                parameters[1] = new SqlParameter("@Nombre", inventario.nombre);
                parameters[2] = new SqlParameter("@idCategoria", inventario.idCategoria);
                parameters[3] = new SqlParameter("@idProveedor", inventario.idProveedor);
                parameters[4] = new SqlParameter("@cantidad", inventario.cantidad);
                parameters[5] = new SqlParameter("@gramaje", inventario.gramaje);
                parameters[6] = new SqlParameter("@fecha", inventario.fecha);
                parameters[7] = new SqlParameter("@costo", inventario.costo);
                string query = "stp_UpdateInventory";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Inventario GetByName(Inventario inventario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@nombre", inventario.nombre);
                string query = "stp_GetByNameInventory";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    inventario = new Inventario()
                    {
                        idInventario = (int)resultado.Rows[0]["idInventario"],
                        nombre = (string)resultado.Rows[0]["Nombre"],
                        idCategoria = (int)resultado.Rows[0]["idCtegoria"],
                        idProveedor = (int)resultado.Rows[0]["idProveedor"],
                        cantidad = (int)resultado.Rows[0]["Cantidad"],
                        gramaje = (string)resultado.Rows[0]["Gramaje"],
                        fecha = (DateTime)resultado.Rows[0]["Fecha"],
                        costo = (double)resultado.Rows[0]["Costo"],
                        Activo = (bool)resultado.Rows[0]["Activo"]
                    };
                }
                return inventario;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }
        #endregion
    }

}
