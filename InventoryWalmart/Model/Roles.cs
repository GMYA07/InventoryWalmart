using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Roles
    {
        public int IdRol { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public Roles(int idRol, string roleName, string roleDescription)
        {
            IdRol = idRol;
            RoleName = roleName;
            RoleDescription = roleDescription;
        }
    }
}
