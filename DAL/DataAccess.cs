using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace DAL
{
    public class DataAccess
    {
        #region Singleton
        private static volatile DataAccess instance = null;
        private static readonly object padlock = new object();

        //DESKTOP-VM2CIUF
        private String conString = "Data Source = CROWNCLOWN-PC;Initial Catalog = taqueria; Integrated Security = true";

        private DataAccess() { }

        public static DataAccess Instance()
        {
            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new DataAccess();
                    }
            }
            return instance;
        }
        #endregion

        #region Query/Execute

        public DataTable Query(String query)
        {

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();
                DataTable resultado = new DataTable();
                resultado.Load(cmd.ExecuteReader());
                return resultado;
            }
        }

        public DataTable Query(string query, SqlParameter[] parameters)
        {

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {

                con.Open();
                DataTable resultado = new DataTable();
                cmd.Parameters.AddRange(parameters);
                resultado.Load(cmd.ExecuteReader());
                return resultado;
            }
        }

        public int Execute(String query, SqlParameter[] parameters)
        {

            using (var con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {


                con.Open();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
