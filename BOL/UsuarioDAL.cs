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
    public class UsuarioDAL
    {
        private static volatile UsuarioDAL instance = null;
        private static readonly object padlock = new object();

        private DataAccess dataAccess = DataAccess.Instance();

        private UsuarioDAL() { }

        public static UsuarioDAL Instance()
        {
            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new UsuarioDAL();
                    }
            }
            return instance;
        }

        public int Adduser(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombre", usuario.nombre);
                parameters[1] = new SqlParameter("@contraseña", usuario.contraseña);
                string query = "adduser";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Deleteuser(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idUsuario", usuario.idUsuario);
                string query = "deleteuser";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Usuarios Getalluser()
        {
            try
            {
                string query = "getalluser";
                DataTable resultado = dataAccess.Query(query);
                Usuarios usuarios = new Usuarios();
                foreach (DataRow item in resultado.Rows)
                {
                    usuarios.Add(new Usuario()
                    {
                        idUsuario = (int)item["idusuario"],
                        nombre = (string)item["nombre"],
                        contraseña = (string)item["contraseña"],
                        activo = (bool)item["activo"]
                    });
                }

                return usuarios;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Usuario Getiduser(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idUsuario", usuario.idUsuario);
                string query = "getiduser";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    usuario = new Usuario()
                    {
                        idUsuario = (int)resultado.Rows[0]["idUsuario"],
                        nombre = (string)resultado.Rows[0]["nombre"],
                        contraseña = (string)resultado.Rows[0]["contraseña"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };

                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Updateuser(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idUsuario", usuario.idUsuario);
                parameters[1] = new SqlParameter("nombre", usuario.nombre);
                parameters[2] = new SqlParameter("@password", usuario.contraseña);

                string query = "updateuser";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Usuario GetLogin(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombre", usuario.nombre);
                parameters[1] = new SqlParameter("@contraseña", usuario.contraseña);
                string query = "usuarios_login";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    Usuario objeto = new Usuario()
                    {
                        idUsuario = (int)resultado.Rows[0]["idUsuario"],
                        nombre = (string)resultado.Rows[0]["nombre"],
                        contraseña = (string)resultado.Rows[0]["contraseña"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                    return objeto;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

    }
}
