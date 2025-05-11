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




        public void eliminarUser(int id)
        {
            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("delete_User", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_user", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Usuario eliminar correctamente", "Eliminacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar el Usuario: " + ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public int insertarUsers(User u)
        {
            int newId = -1;

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
                object result = cmd.ExecuteScalar(); 
                conn.Close();

                if (result != null)
                {
                    newId = Convert.ToInt32(result);
                    Console.WriteLine("Usuario insertado", "Inserción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
              Console.WriteLine("Error al insertar el Usuario: " + ex.Message + "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }




        public static List<User> TraerUsuarios()
        {
            List<User> listaUsuarios = new List<User>();

            string query = @"
	SELECT u.id_user, 
       u.first_name, 
       u.last_name, 
       u.date_of_birth, 
       u.hire_date, 
       u.cellphone, 
       u.dui, 
       d.department_name,  
       dis.district_name,  
       r.role_name,        
	   a.status_account,
	   a.username,
       u.id_department,    
       u.id_district,      
       u.id_role,
	   a.id_account
FROM USERS u	
JOIN DEPARTMENT d ON u.id_department = d.id_department
JOIN DISTRICT dis ON u.id_district = dis.id_district
JOIN ROLES r ON u.id_role = r.id_role
JOIN ACCOUNT a On a.id_user = u.id_user;
";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                User user = new User();
                                user.SetIdUser(reader.GetInt32(0));
                                user.SetFirst_name(reader.GetString(1));
                                user.SetLast_name(reader.GetString(2));
                                user.SetDate_of_birth(reader.GetDateTime(3));
                                user.SetHire_date(reader.GetDateTime(4));
                                user.SetCellphone(reader.GetString(5));
                                user.SetDui(reader.GetString(6));

                                user.DepartmentName = reader.GetString(7); 
                                user.DistrictName = reader.GetString(8);   
                                user.RoleName = reader.GetString(9);       
                                user.status = reader.GetBoolean(10);
                                user.nameUsuario = reader.GetString(11);
                                // Asignar los ID (si los necesitas)
                                user.SetIdDepartment(reader.GetInt32(12));
                                user.SetIdDistrict(reader.GetInt32(13));
                                user.SetIdRole(reader.GetInt32(14));
                                user.idAccount = reader.GetInt32(15);

                                listaUsuarios.Add(user);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.ToString());
                        return new List<User>(); 
                    }
                }
            }

            return listaUsuarios;
        }





        public void EditarUser(User u)
        {
            try
            {
                SqlConnection conn = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("update_User", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_user", u.GetIdUser());
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

                MessageBox.Show("Usuario Editado correctamente", "Edicion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al editar el Usuario: " + ex.Message, "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
