using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        #region Singleton
        private static volatile ClienteBLL instance = null;
        public static readonly object padlock = new object();
        private ClienteDAL clienteDAL = ClienteDAL.Instance();

        private ClienteBLL() { }

        public static ClienteBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ClienteBLL();
            return instance;
        }
        #endregion

        #region Metodos
        public bool Add(Cliente cliente)
        {
            return clienteDAL.Add(cliente) > 0;
        }

        public bool Delete(Cliente cliente)
        {
            return clienteDAL.Delete(cliente) > 0;
        }

        public Clientes GetALL()
        {
            return clienteDAL.GetAll();
        }

        public bool Update(Cliente cliente)
        {
            return clienteDAL.Update(cliente) > 0;
        }

        public Clientes GetByName(Cliente cliente)
        {
            return clienteDAL.GetByName(cliente);
        }
        #endregion
    }
}
