using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Utils;
using InventoryWalmart.Model;
using InventoryWalmart.Database;
using System.ComponentModel;
using System.Windows.Forms;

namespace InventoryWalmart.Controllers
{
    internal class loginController
    {
        Alertas Alerta = new Alertas();

        public Boolean IniciarSesion(string userName, string pass) {

            //encriptaremos la contraseña dada por el usuario para mas seguridad
            Encriptacion encriptacion = new Encriptacion();
            string passEncriptada = encriptacion.EncriptarSHA256(pass);

            Account account = new Account();
            AccountDAO accountDAO = new AccountDAO();

            account = accountDAO.obtenerAccountActiva(userName, passEncriptada);

            if (account != null)
            {
                User user = new User();
                UserDAO userDAO = new UserDAO();

                user = userDAO.obtenerUsuario(account.GetIdUser());

                if (user != null) {

                    //Aqui asignamos un valor a la variable global de userID
                    SessionManager.UserId = user.GetIdUser();

                    switch (user.GetIdRole()) {

                        case 1: //admin
                            dashboard dashboard = new dashboard();
                            dashboard.Show();
                            return true; //para cerrar la ventana anterior
                            break;
                        default:
                            return false; //para cerrar la ventana anterior
                            break;
                    
                    }

                }
                else
                {
                    Alerta.AlertError("No se pudo iniciar Sesion", "No se ha encontrado el usuario en la bdd");
                    return false; //para cerrar la ventana anterior
                }
            }
            else
            {
                Alerta.AlertError("No se pudo iniciar Sesion","No se ha podido Iniciar Sesion");
                return false; //para cerrar la ventana anterior
            }
        }



        public static Boolean pasarPassUser(Account a, String proseso)
        {
            AccountDAO accountDAO = new AccountDAO();
            if (proseso != "Edit")
            {
                accountDAO.insertarAccount(a);
                return false;
            }
            else
            {
             return  accountDAO.update_account(a);
            }

        }
    }
}
