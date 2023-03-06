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
    public class Detalle_PedidoDAL
    {
        private static volatile Detalle_PedidoDAL instance = null;
        private static readonly object padlock = new object();

        private DataAccess dataAccess = DataAccess.Instance();

        private Detalle_PedidoDAL() { }

        public static Detalle_PedidoDAL Instance()
        {
            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new Detalle_PedidoDAL();
                    }
            }
            return instance;
        }

        public int AddDetail(Detalle_Pedido detalle)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@idBebida", detalle.idBebida);
                parameters[1] = new SqlParameter("@idCarne", detalle.idCarne);
                parameters[2] = new SqlParameter("@cantidadB", detalle.CantidadB);
                parameters[3] = new SqlParameter("@cantidadC", detalle.CantidadC);
                parameters[4] = new SqlParameter("@idMenu", detalle.idMenu);
                parameters[5] = new SqlParameter("@subTotal", detalle.subTotal);

                string query = "addetail";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Deletedetail(Detalle_Pedido detalle)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idDetalle", detalle.idDetalle);
                string query = "deletedetail";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Detalle_Pedidos Getalldetail()
        {
            try
            {
                string query = "getalldetail";
                DataTable resultado = dataAccess.Query(query);
                Detalle_Pedidos usuarios = new Detalle_Pedidos();
                foreach (DataRow item in resultado.Rows)
                {
                    usuarios.Add(new Detalle_Pedido()
                    {
                        idDetalle = (int)item["idDetalle"],
                        idBebida = (int)item["idBebida"],
                        idCarne = (int)item["idCarne"],
                        CantidadB = (int)item["CantidadB"],
                        CantidadC = (int)item["CantidadC"],
                        idMenu = (int)item["idMenu"],
                        subTotal = (int)item["subTotal"]
                    });
                }

                return usuarios;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Detalle_Pedido Getiddetail(Detalle_Pedido detalle)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idDetalle", detalle.idDetalle);
                string query = "getiddetail";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    detalle = new Detalle_Pedido()
                    {
                        idDetalle = (int)resultado.Rows[0]["idDetalle"],
                        idBebida = (int)resultado.Rows[0]["idBebida"],
                        idCarne = (int)resultado.Rows[0]["idCarne"],
                        CantidadB = (int)resultado.Rows[0]["CantidadB"],
                        CantidadC = (int)resultado.Rows[0]["CantidadC"],
                        idMenu = (int)resultado.Rows[0]["idMenu"],
                        subTotal = (int)resultado.Rows[0]["subTotal"]

                    };

                }
                return detalle;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Updatedetail(Detalle_Pedido detalle)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idDetalle", detalle.idDetalle);
                parameters[1] = new SqlParameter("@idBebida", detalle.idBebida);
                parameters[3] = new SqlParameter("@idCarne", detalle.idCarne);
                parameters[4] = new SqlParameter("@CantidadB", detalle.CantidadC);
                parameters[5] = new SqlParameter("@CantidadC", detalle.CantidadB);
                parameters[6] = new SqlParameter("@idMenu", detalle.idMenu);
                parameters[2] = new SqlParameter("@subTotal", detalle.subTotal);

                string query = "updatedetail";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

    }
}
