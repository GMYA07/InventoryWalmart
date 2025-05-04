using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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



        public void insertarUsers(User u)
        {
            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("insert_User", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@first_name", u.GetFirst_name());
                cmd.Parameters.AddWithValue("@last_name", u.GetLast_name());
                cmd.Parameters.AddWithValue("@date_of_birth", u.GetDate_of_birth());
                cmd.Parameters.AddWithValue("@hire_date", u.GetHire_date());
                cmd.Parameters.AddWithValue("@cellphone", u.GetCellphone());
                cmd.Parameters.AddWithValue("@dui", u.GetDui());
                cmd.Parameters.AddWithValue("@id_department", u.GetIdDepartment());
                cmd.Parameters.AddWithValue("@id_district", u.GetIdDistrict());
                cmd.Parameters.AddWithValue("@id_role", u.GetIdRole());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Usuario insertado correctamente", "Inserción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar el Usuario: " + ex.Message, "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
