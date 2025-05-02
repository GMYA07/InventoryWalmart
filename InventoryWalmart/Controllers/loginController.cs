using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Utils;

namespace InventoryWalmart.Controllers
{
    internal class loginController
    {

        public void IniciarSesion(string userName, string pass) {

            //encriptaremos la contraseña dada por el usuario para mas seguridad
            Encriptacion encriptacion = new Encriptacion();
            string passEncriptada = encriptacion.EncriptarSHA256(pass);

        }
    }
}
