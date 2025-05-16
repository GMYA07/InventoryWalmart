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
using InventoryWalmart.views.Cajero;

namespace InventoryWalmart.Controllers
{
    internal class loginController
    {

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
                        case 2://cajero
                            indexCajero indexCajero = new indexCajero();
                            indexCajero.Show();
                            return true;
                            break;
                        default:
                            return false; //para cerrar la ventana anterior
                            break;
                    
                    }

                }
                else
                {
                    Alertas.AlertError("No se pudo iniciar Sesion", "No se ha encontrado el usuario en la bdd");
                    return false; //para cerrar la ventana anterior
                }
            }
            else
            {
                Alertas.AlertError("No se pudo iniciar Sesion", "Cuenta o Contraseña Incorrecta");
                return false; //para cerrar la ventana anterior
            }
        }



        public static void pasarPassUser(Account a, string proceso)
        {
            AccountDAO accountDAO = new AccountDAO();
            bool resultado = false;

            if (proceso != "Edit")
            {
                if (a.GetIdUser() != -1)
                {
                    resultado = accountDAO.insertarAccount(a);
                    if (resultado)
                    {
                        Alertas.AlertCorrect("Usuario creado", "El usuario se agregó correctamente.");
                    }
                    else
                    {
                        Alertas.AlertError("Error", "No se pudo crear la cuenta asociada.");
                    }
                }
                else
                {
                    Alertas.AlertError("Error", "No se pudo crear el usuario.");
                }
            }
            else
            {
                 accountDAO.update_account(a);
            }
        }
    }
}
