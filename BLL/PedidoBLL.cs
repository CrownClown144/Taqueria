using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidoBLL
    {
        #region Singleton
        private static volatile PedidoBLL instance = null;
        public static readonly object padlock = new object();
        private PedidoDAL pedidoDAL = PedidoDAL.Instance();

        private PedidoBLL() { }

        public static PedidoBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new PedidoBLL();
            return instance;
        }
        #endregion

        #region Metodos
        public bool Add(Pedido pedido)
        {
            return pedidoDAL.Add(pedido) > 0;
        }

        public bool Delete(Pedido pedido)
        {
            return pedidoDAL.Delete(pedido) > 0;
        }

        public Pedidos GetALL()
        {
            return pedidoDAL.GetAll();
        }

        public Pedido GetById(Pedido pedido)
        {
            return pedidoDAL.GetById(pedido);
        }

        public bool Update(Pedido pedido)
        {
            return pedidoDAL.Update(pedido) > 0;
        }
        #endregion
    }
}
