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
             return dao.insertarUsers(u);
            }
            else
            {
                dao.EditarUser(u);
                return -1;   
            }
        }

    }
}
