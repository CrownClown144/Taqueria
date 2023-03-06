using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        #region Singleton
        private static volatile UsuarioBLL instance = null;
        private static readonly object padlock = new object();


        private UsuarioDAL usuarioDAL = UsuarioDAL.Instance();
        private UsuarioBLL() { }

        public static UsuarioBLL Instance()
        {

            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new UsuarioBLL();
                    }
            }
            return instance;
        }
        #endregion

        public bool Add(Usuario usuario)
        {
            return usuarioDAL.Adduser(usuario) > 0;

        }

        public bool Delete(Usuario usuario)
        {
            return usuarioDAL.Deleteuser(usuario) > 0;

        }

        public Usuarios GetAll()
        {
            return usuarioDAL.Getalluser();
        }

        public Usuario GetId(Usuario usuario)
        {
            return usuarioDAL.Getiduser(usuario);
        }

        
        public Usuario GetLogin(Usuario usuario)
        {
            return usuarioDAL.GetLogin(usuario);
        }

        public bool Login(Usuario usuario)
        {

            if (usuarioDAL.GetLogin(usuario) != null)
                return true;
            else
                return false;
        }
        
        public bool Update(Usuario usuario)
        {
            return usuarioDAL.Updateuser(usuario) > 0;
        }
    }
}
