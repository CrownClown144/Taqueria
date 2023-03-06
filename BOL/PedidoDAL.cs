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
    public class PedidoDAL
    {
        #region Singleton
        private static volatile PedidoDAL instance = null;
        public static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private PedidoDAL() { }

        public static PedidoDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new PedidoDAL();
            return instance;
        }
        #endregion

        #region Metodos
        public int Add(Pedido pedido)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@fecha", pedido.fecha);
                parameters[0] = new SqlParameter("@idCliente", pedido.idCliente);
                parameters[0] = new SqlParameter("@total", pedido.total);
                string query = "stp_AddOrder";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Delete(Pedido pedido)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idPedido", pedido.idPedido);
                string query = "stp_DeleteSupplier";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Pedidos GetAll()
        {
            try
            {
                string query = "stp_GetAllOrder";
                DataTable resultado = dataAccess.Query(query);
                Pedidos pedidos = new Pedidos();
                foreach (DataRow item in resultado.Rows)
                {
                    pedidos.Add(new Pedido()
                    {
                        idPedido = (int)item["idPedido"],
                        fecha = (DateTime)item["Fecha"],
                        idCliente = (int)item["idCliente"],
                        total = (int)item["Total"]
                    });
                }
                return pedidos;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Pedido GetById(Pedido pedido)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idPedido", pedido.idPedido);
                string query = "stp_GetByOrderID";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    pedido = new Pedido()
                    {
                        idPedido = (int)resultado.Rows[0]["idPedido"],
                        fecha = (DateTime)resultado.Rows[0]["Fecha"],
                        idCliente = (int)resultado.Rows[0]["idCliente"],
                        total = (int)resultado.Rows[0]["Total"]
                    };
                }
                return pedido;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }
        
        public int Update(Pedido pedido)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@idPedido", pedido.idPedido);
                parameters[1] = new SqlParameter("@fecha", pedido.fecha);
                parameters[2] = new SqlParameter("@idCliente", pedido.idCliente);
                parameters[3] = new SqlParameter("@total", pedido.total);
                string query = "stp_UpdateOrder";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }
        #endregion

    }
}
