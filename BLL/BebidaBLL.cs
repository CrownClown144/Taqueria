using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BebidaBLL
    {
        #region Singleton
        private static volatile BebidaBLL instance = null;
        private static readonly object padlock = new object();


        private BebidaDAL bebidaDAL = BebidaDAL.Instance();
        private BebidaBLL() { }

        public static BebidaBLL Instance()
        {

            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new BebidaBLL();
                    }
            }
            return instance;
        }
        #endregion

        public bool Add(Bebida bebida)
        {
            return bebidaDAL.Adddrink(bebida) > 0;
        }

        public bool Delete(Bebida bebida)
        {
            return bebidaDAL.Deletedrink(bebida) > 0;
        }

        public Bebidas GetAll()
        {
            return bebidaDAL.Getalldrink();
        }

        public Bebida GetId(Bebida bebida)
        {
            return bebidaDAL.Getiddrink(bebida);
        }

        public bool Update(Bebida bebida)
        {
            return bebidaDAL.Updatedrink(bebida) > 0;
        }
    }
}
