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
        public static void pasarUsuerDdd(User u, String controlador)
        {
            UserDAO dao = new UserDAO();

            if (controlador != "Edit")
            {
                dao.insertarUsers(u);
            }
            else
            {
                dao.EditarUser(u);
            }
                


        }

        public static void borrarUser(int id)
        {
            UserDAO dao = new UserDAO();
            dao.eliminarUser(id);
        }

        public static void editarUser (User user, String controlador){
            UserDAO dao = new UserDAO();

        }

    }
}
