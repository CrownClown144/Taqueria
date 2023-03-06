using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProveedorBLL
    {
        #region Singleton
        private static volatile ProveedorBLL instance = null;
        public static readonly object padlock = new object();
        private ProveedorDAL proveedorDAL = ProveedorDAL.Instance();

        private ProveedorBLL() { }

        public static ProveedorBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ProveedorBLL();
            return instance;
        }
        #endregion

        #region Metodos
        public bool Add(Proveedor proveedor)
        {
            return proveedorDAL.Add(proveedor) > 0;
        }

        public bool Delete(Proveedor proveedor)
        {
            return proveedorDAL.Delete(proveedor) > 0;
        }

        public Proveedores GetALL()
        {
            return proveedorDAL.GetAll();
        }

        public bool Update(Proveedor proveedor)
        {
            return proveedorDAL.Update(proveedor) > 0;
        }

        public Proveedores GetByName(Proveedor proveedor)
        {
            return proveedorDAL.GetByName(proveedor);
        }

        public Proveedores GetOnlySupplierActive()
        {
            return proveedorDAL.GetOnlySupplierActive();
        }

        public Proveedores GetOnlySupplierInactive()
        {
            return proveedorDAL.GetOnlySupplierInactive();
        }

        public bool Restore(Proveedor proveedor)
        {
            return proveedorDAL.Restore(proveedor) > 0;
        }

        public Proveedor GetIdByName(Proveedor proveedor)
        {
            return proveedorDAL.GetIdByName(proveedor);
        }
        #endregion
    }
}
