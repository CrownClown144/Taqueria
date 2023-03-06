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
    public class CategoriaDAL
    {
        #region Singleton
        private static volatile CategoriaDAL instance = null;
        public static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private CategoriaDAL() { }

        public static CategoriaDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new CategoriaDAL();
            return instance;
        }
        #endregion

        #region Metodos
        public int Add(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@tipo", categoria.Tipo);
                string query = "stp_AddCategory";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Delete(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCategoria", categoria.idCategoria);
                string query = "stp_DeleteCategory";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Categorias GetAll()
        {
            try
            {
                string query = "stp_GetAllCategory";
                DataTable resultado = dataAccess.Query(query);
                Categorias categorias = new Categorias();
                foreach (DataRow item in resultado.Rows)
                {
                    categorias.Add(new Categoria()
                    {
                        idCategoria = (int)item["idCategoria"],
                        Tipo = (string)item["tipo"],
                        Activo = (bool)item["Activo"]
                    });
                }
                return categorias;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Update(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@idCategoria", categoria.idCategoria);
                parameters[1] = new SqlParameter("@tipo", categoria.Tipo);
                string query = "stp_UpdateCategory";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Categorias GetByType(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Tipo", categoria.Tipo);
                string query = "stp_GetByTypeCategory";
                DataTable resultado = dataAccess.Query(query, parameters);

                Categorias categorias = new Categorias();
                foreach (DataRow item in resultado.Rows)
                {
                    categorias.Add(new Categoria()
                    {
                        idCategoria = (int)item["idCategoria"],
                        Tipo = (string)item["tipo"],
                        Activo = (bool)item["Activo"]
                    });
                }
                return categorias;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Categorias GetOnlyCategoryActive()
        {
            try
            {
                string query = "stp_GetOnlyCategoryActive";
                DataTable resultado = dataAccess.Query(query);
                Categorias categorias = new Categorias();
                foreach (DataRow item in resultado.Rows)
                {
                    categorias.Add(new Categoria()
                    {
                        idCategoria = (int)item["idCategoria"],
                        Tipo = (string)item["tipo"],
                        Activo = (bool)item["Activo"]
                    });
                }
                return categorias;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Categorias GetOnlyCategoryInactive()
        {
            try
            {
                string query = "stp_GetOnlyCategoryInactive";
                DataTable resultado = dataAccess.Query(query);
                Categorias categorias = new Categorias();
                foreach (DataRow item in resultado.Rows)
                {
                    categorias.Add(new Categoria()
                    {
                        idCategoria = (int)item["idCategoria"],
                        Tipo = (string)item["tipo"],
                        Activo = (bool)item["Activo"]
                    });
                }
                return categorias;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Restore(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCategoria", categoria.idCategoria);
                string query = "stp_RestoreCategory";
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
