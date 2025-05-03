using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Utils;
using InventoryWalmart.Model;
using InventoryWalmart.Database;

namespace InventoryWalmart.Controllers
{
    internal class loginController
    {
        Alertas Alerta = new Alertas();

        public void IniciarSesion(string userName, string pass) {

            //encriptaremos la contraseña dada por el usuario para mas seguridad
            Encriptacion encriptacion = new Encriptacion();
            string passEncriptada = encriptacion.EncriptarSHA256(pass);

            Account account = new Account();
            AccountDAO accountDAO = new AccountDAO();

            account = accountDAO.obtenerAccountActiva(userName, passEncriptada);

            if (account != null)
            {
                Alerta.AlertCorrect("Se inicio Sesion", "Se ha podido Iniciar Sesion bro");



            }else
            {
                Alerta.AlertError("No se pudo iniciar Sesion","No se ha podido Iniciar Sesion");
            }
        }
    }
}
