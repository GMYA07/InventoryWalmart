using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;

namespace InventoryWalmart.Database
{
    internal class AccountDAO
    {
        //contenedor
        public AccountDAO() { } 

        public Account obtenerAccountActiva(string username, string pass)
        {
            //objeto que retornaremos para enviar la informacion
            Account accountObtenida = new Account();

            //Empezamos proceso para obtener la cuenta activa

            string query = "EXEC obtenerAccount '" + username + "', '" + pass + "'";

            using (SqlConnection conn = Connection.ObtenerConexion()) {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    try
                    {
                        //Abrimos la conexion
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {

                            if (reader.Read())
                            {
                                accountObtenida.SetIdAccount(reader.GetInt32(0));
                                accountObtenida.SetIdUser(reader.GetInt32(1));
                                accountObtenida.SetUserName(reader.GetString(2));
                                accountObtenida.SetPassword(reader.GetString(3));
                                accountObtenida.SetStatusAccount(reader.GetBoolean(4));

                                return accountObtenida;
                            }
                            else {
                                Console.WriteLine("Usuario no encontrado");
                                return null;
                            }
                        }

                    }
                    catch (Exception ex) { 
                        Console.WriteLine("Error: " + ex.ToString());
                        return null;
                    }
                
                }
            }
            
        }
    }
}
