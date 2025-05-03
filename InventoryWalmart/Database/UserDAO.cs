using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;
namespace InventoryWalmart.Database
{

    internal class UserDAO
    {
        //contenedor
        public UserDAO() { }

        public User obtenerUsuario(int id_userEncontrar)
        {
            //Objeto a retornar
            User userEncontrado = new User();

            //Empezamos el proceso para poder obtener el usuario

            string query = "SELECT id_user,first_name,last_name,date_of_birth,hire_date,cellphone,dui,id_department,id_district,id_role " ;
                   query += " FROM USERS WHERE id_user = " + id_userEncontrar;

            using (SqlConnection coon = Connection.ObtenerConexion()) {
                using (SqlCommand cmd = new SqlCommand(query, coon)) {
                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {

                            if (reader.Read()) { 
                                userEncontrado.SetIdUser(reader.GetInt32(0));
                                userEncontrado.SetFirst_name(reader.GetString(1));
                                userEncontrado.SetLast_name(reader.GetString(2));
                                userEncontrado.SetDate_of_birth(reader.GetDateTime(3));
                                userEncontrado.SetHire_date(reader.GetDateTime(4));
                                userEncontrado.SetCellphone(reader.GetString(5));
                                userEncontrado.SetDui(reader.GetString(6));
                                userEncontrado.SetIdDepartment(reader.GetInt32(7));
                                userEncontrado.SetIdDistrict(reader.GetInt32(8));
                                userEncontrado.SetIdRole(reader.GetInt32(9));

                                return userEncontrado;
                            }
                            else
                            {
                                Console.WriteLine("No se encontro");
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
