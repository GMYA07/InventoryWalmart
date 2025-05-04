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
        public static void pasarUsuerDdd(User u)
        {
           UserDAO dao = new UserDAO();
            dao.insertarUsers(u);
        }
    }
}
