using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CarneBLL
    {
        #region Singleton
        private static volatile CarneBLL instance = null;
        private static readonly object padlock = new object();


        private CarneDAL carneDAL = CarneDAL.Instance();
        private CarneBLL() { }

        public static CarneBLL Instance()
        {

            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new CarneBLL();
                    }
            }
            return instance;
        }
        #endregion

        public bool Add(Carne carne)
        {
            return carneDAL.Addmeat(carne) > 0;
        }

        public bool Delete(Carne carne)
        {
            return carneDAL.Deletemeat(carne) > 0;
        }

        public Carnes GetAll()
        {
            return carneDAL.Getallmeat();
        }

        public Carne Getidmeat(Carne carne)
        {
            return carneDAL.Getidmeat(carne);
        }

        public bool Update(Carne carne)
        {
            return carneDAL.Updatemeat(carne) > 0;

        }
    }
}
