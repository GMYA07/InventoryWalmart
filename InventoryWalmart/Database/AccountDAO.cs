using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;
using InventoryWalmart.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryWalmart.Database
{
    internal class AccountDAO
    {
        //contenedor
        public AccountDAO() { }
        Alertas alertas = new Alertas();


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



        public void insertarAccount2(Account acc)
        {
            Account accountObtenida = new Account();
            string query = $"EXEC insert_account '{acc.GetIdUser()}', '{acc.GetUserName()}', '{acc.GetPassword()}', {acc.GetStatusAccount()}";
            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_user", acc.GetIdUser());
                cmd.Parameters.AddWithValue("@username", acc.GetUserName());
                cmd.Parameters.AddWithValue("@status_account", acc.GetStatusAccount());

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();
                Console.WriteLine("Account se ingreso correcta mete");
            }
            catch (Exception ex)
            {
                alertas.AlertError("No se pudo ingresar Account","Error al insertar: " + ex);
            }
        }



        public void insertarAccount(Account acc)
        {
            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("insert_account", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Encriptar la contraseña antes de insertarla
                Encriptacion encriptacion = new Encriptacion();
                string passEncriptada = encriptacion.EncriptarSHA256(acc.GetPassword());

                // Agregar parámetros correctamente
                cmd.Parameters.AddWithValue("@id_user", acc.GetIdUser());
                cmd.Parameters.AddWithValue("@username", acc.GetUserName());
                cmd.Parameters.AddWithValue("@pass", passEncriptada);
                cmd.Parameters.AddWithValue("@status_account", acc.GetStatusAccount());

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                Console.WriteLine("Account se ingresó correctamente");
            }
            catch (Exception ex)
            {
                alertas.AlertError("No se pudo ingresar Account", "Error al insertar: " + ex.Message);
            }
        }
    }
}
