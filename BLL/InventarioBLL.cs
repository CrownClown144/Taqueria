using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InventarioBLL
    {
        #region Singleton
        private static volatile InventarioBLL instance = null;
        public static readonly object padlock = new object();
        private InventarioDAL inventarioDAL = InventarioDAL.Instance();

        private InventarioBLL() { }

        public static InventarioBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new InventarioBLL();
            return instance;
        }
        #endregion

        #region Metodos
        public bool Add(Inventario inventario)
        {
            return inventarioDAL.Add(inventario) > 0;
        }

        public bool Delete(Inventario inventario)
        {
            return inventarioDAL.Delete(inventario) > 0;
        }

        public Inventarios GetALL()
        {
            return inventarioDAL.GetAll();
        }

        public Inventario GetById(Inventario inventario)
        {
            return inventarioDAL.GetById(inventario);
        }

        public bool Update(Inventario inventario)
        {
            return inventarioDAL.Update(inventario) > 0;
        }

        public Inventario GetByName(Inventario inventario)
        {
            return inventarioDAL.GetByName(inventario);
        }
        #endregion
    }
}
