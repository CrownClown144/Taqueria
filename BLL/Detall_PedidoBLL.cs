using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Detalle_PedidoBLL
    {
        #region Singleton
        private static volatile Detalle_PedidoBLL instance = null;
        private static readonly object padlock = new object();


        private Detalle_PedidoDAL detalleDAL = Detalle_PedidoDAL.Instance();
        private Detalle_PedidoBLL() { }

        public static Detalle_PedidoBLL Instance()
        {

            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new Detalle_PedidoBLL();
                    }
            }
            return instance;
        }
        #endregion

        public bool Add(Detalle_Pedido detalle)
        {
            return detalleDAL.AddDetail(detalle) > 0;
        }

        public bool Delete(Detalle_Pedido detalle)
        {
            return detalleDAL.Deletedetail(detalle) > 0;
        }

        public Detalle_Pedidos GetAll()
        {
            return detalleDAL.Getalldetail();
        }

        public Detalle_Pedido GetId(Detalle_Pedido detalle)
        {
            return detalleDAL.Getiddetail(detalle);
        }

        public bool Update(Detalle_Pedido detalle)
        {
            return detalleDAL.Updatedetail(detalle) > 0;
        }

    }
}
