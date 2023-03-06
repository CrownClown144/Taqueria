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
    public class CarneDAL
    {
        #region Singleton
        private static volatile CarneDAL instance = null;
        private static readonly object padlock = new object();

        private DataAccess dataAccess = DataAccess.Instance();

        private CarneDAL() { }

        public static CarneDAL Instance()
        {

            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new CarneDAL();
                    }
            }
            return instance;
        }
        #endregion

        public int Addmeat(Carne carne)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@nombre", carne.nombre);
                string query = "addmeat";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Deletemeat(Carne carne)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@nombre", carne.nombre);
                string query = "deletemeat";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Carnes Getallmeat()
        {
            try
            {
                string query = "getallmeat";
                DataTable resultado = dataAccess.Query(query);
                Carnes carnes = new Carnes();
                foreach (DataRow item in resultado.Rows)
                {
                    carnes.Add(new Carne()
                    {
                        idCarne = (int)item["idCarne"],
                        nombre = (string)item["nombre"],
                        activo = (bool)item["activo"]
                    });
                }

                return carnes;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Carne Getidmeat(Carne carne)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCarne", carne.idCarne);
                string query = "getidmeat";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    carne = new Carne()
                    {
                        idCarne = (int)resultado.Rows[0]["idCarne"],
                        nombre = (string)resultado.Rows[0]["nombre"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };

                }
                return carne;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }
        public int Updatemeat(Carne carne)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@idCarne", carne.idCarne);
                parameters[1] = new SqlParameter("@nombre", carne.nombre);
                string query = "updatemeat";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }
    }
}
