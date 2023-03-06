using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaBLL
    {
        #region Singleton
        private static volatile CategoriaBLL instance = null;
        public static readonly object padlock = new object();
        private CategoriaDAL categoriaDAL = CategoriaDAL.Instance();

        private CategoriaBLL() { }

        public static CategoriaBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new CategoriaBLL();
            return instance;
        }
        #endregion

        #region Metodos
        public bool Add(Categoria categoria)
        {
            return categoriaDAL.Add(categoria) > 0; 
        }

        public bool Delete(Categoria categoria) 
        { 
            return categoriaDAL.Delete(categoria) > 0;
        }

        public Categorias GetALL()
        {
            return categoriaDAL.GetAll();
        }

        public bool Update(Categoria categoria)
        {
            return categoriaDAL.Update(categoria) > 0;
        }

        public Categorias GetByType(Categoria categoria)
        {
            return categoriaDAL.GetByType(categoria);
        }

        public Categorias GetOnlyCategoryActive()
        {
            return categoriaDAL.GetOnlyCategoryActive();
        }

        public Categorias GetOnlyCategorInactive()
        {
            return categoriaDAL.GetOnlyCategoryInactive();
        }

        public bool Restore(Categoria categoria)
        {
            return categoriaDAL.Restore(categoria) > 0;
        }
        #endregion
    }
}
