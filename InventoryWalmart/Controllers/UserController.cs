using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryWalmart.Database;
using InventoryWalmart.Model;

namespace InventoryWalmart.Controllers
{
    internal class UserController
    {
        public static int pasarUsuerDdd(User u, String controlador)
        {
            UserDAO dao = new UserDAO();

            if (controlador != "Edit")
            {
                int id;
             return id = dao.insertarUsers(u);
            }
            else
            {
                dao.EditarUser(u);
                return 0;   
            }
        }

        public static void pasarLogin()
        {

        }


        public static void borrarUser(int id)
        {
            UserDAO dao = new UserDAO();
            dao.eliminarUser(id);
        }


    }
}
