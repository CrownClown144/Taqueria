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
    public class MenuDAL
    {
        private static volatile MenuDAL instance = null;
        private static readonly object padlock = new object();

        private DataAccess dataAccess = DataAccess.Instance();

        private MenuDAL() { }

        public static MenuDAL Instance()
        {
            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new MenuDAL();
                    }
            }
            return instance;
        }

        public int Addmenu(Menu menu)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@tipo", menu.tipo);
                parameters[1] = new SqlParameter("@preciounitario", menu.preciounitario);
                string query = "addmenu";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Deletemenu(Menu menu)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Tipo", menu.tipo);
                string query = "deletemenu";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }

        }

        public Menus GetAll()
        {
            try
            {
                string query = "getallmenu";
                DataTable resultado = dataAccess.Query(query);
                Menus menus = new Menus();
                foreach (DataRow item in resultado.Rows)
                {
                    menus.Add(new Menu()
                    {
                        idMenu = (int)item["idMenu"],
                        tipo = (string)item["tipo"],
                        preciounitario = (int)item["preciounitario"],
                        activo = (bool)item["activo"]
                    });
                }

                return menus;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Menu Getidmenu(Menu menu)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idMenu", menu.idMenu);
                string query = "getidmenu";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    menu = new Menu()
                    {
                        idMenu = (int)resultado.Rows[0]["idMenu"],
                        tipo = (string)resultado.Rows[0]["tipo"],
                        preciounitario = (int)resultado.Rows[0]["preciounitario"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };

                }
                return menu;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Updatemenu(Menu menu)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idMenu", menu.idMenu);
                parameters[1] = new SqlParameter("@tipo", menu.tipo);
                parameters[2] = new SqlParameter("@preciounitario", menu.preciounitario);

                string query = "updatemenu";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }
    }
}
