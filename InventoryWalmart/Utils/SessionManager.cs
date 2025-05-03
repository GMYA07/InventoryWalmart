using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Utils
{
    public static class SessionManager
    {
        // Aquí guardaremos el id del usuario para cualquier accion q necesitemos de el
        public static int UserId { get; set; }
    }
}
