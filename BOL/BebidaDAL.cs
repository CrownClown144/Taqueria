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
    public class BebidaDAL
    {
        private static volatile BebidaDAL instance = null;
        private static readonly object padlock = new object();

        private DataAccess dataAccess = DataAccess.Instance();

        private BebidaDAL() { }

        public static BebidaDAL Instance()
        {
            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new BebidaDAL();
                    }
            }
            return instance;
        }

        public int Adddrink(Bebida bebida)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombre", bebida.nombre);
                parameters[1] = new SqlParameter("@gramaje", bebida.gramaje);
                string query = "adddrink";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Deletedrink(Bebida bebida)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idBebida", bebida.idBebida);
                string query = "deletedrink";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Bebidas Getalldrink()
        {
            try
            {
                string query = "getalldrink";
                DataTable resultado = dataAccess.Query(query);
                Bebidas bebidas = new Bebidas();
                foreach (DataRow item in resultado.Rows)
                {
                    bebidas.Add(new Bebida()
                    {
                        idBebida = (int)item["idBebida"],
                        nombre = (string)item["nombre"],
                        gramaje = (string)item["gramaje"],
                        activo = (bool)item["activo"]
                    });
                }

                return bebidas;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Bebida Getiddrink(Bebida bebida)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idBebida", bebida.idBebida);
                string query = "getiddrink";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    bebida = new Bebida()
                    {
                        idBebida = (int)resultado.Rows[0]["idBebida"],
                        nombre = (string)resultado.Rows[0]["nombre"],
                        gramaje = (string)resultado.Rows[0]["gramaje"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };

                }
                return bebida;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Updatedrink(Bebida bebida)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idBebida", bebida.idBebida);
                parameters[1] = new SqlParameter("nombre", bebida.nombre);
                parameters[2] = new SqlParameter("@gramaje", bebida.gramaje);

                string query = "updatedrink";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }
    }
}
