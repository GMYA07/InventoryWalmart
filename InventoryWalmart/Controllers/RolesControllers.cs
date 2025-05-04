using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Database;

namespace InventoryWalmart.Controllers
{
    internal class RolesControllers
    {

        public static void enviarRolBdd(Roles rol)
        {
            RolesDAO rolesDAO = new RolesDAO();
            rolesDAO.InsertarRol(new Roles(0,rol.RoleName,rol.RoleDescription));
        }


    }
}
