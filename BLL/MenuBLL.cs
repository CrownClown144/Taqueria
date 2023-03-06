using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenuBLL
    {
        #region Singleton
        private static volatile MenuBLL instance = null;
        private static readonly object padlock = new object();


        private MenuDAL menuDAL = MenuDAL.Instance();
        private MenuBLL() { }

        public static MenuBLL Instance()
        {

            if (instance == null)
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new MenuBLL();
                    }
            }
            return instance;
        }
        #endregion

        public bool Add(Menu menu)
        {
            return menuDAL.Addmenu(menu) > 0;
        }

        public bool Delete(Menu menu)
        {
            return menuDAL.Deletemenu(menu) > 0;
        }

        public Menus GetAll()
        {
            return menuDAL.GetAll();
        }

        public Menu GetId(Menu menu)
        {
            return menuDAL.Getidmenu(menu);
        }

        public bool Update(Menu menu)
        {
            return menuDAL.Updatemenu(menu) > 0;
        }

    }
}
