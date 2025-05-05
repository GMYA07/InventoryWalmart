using System;
using System.Collections;
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
    internal class RolesDAO
    {
        //ingresar rol a al base de datos

        public void InsertarRol(Roles r)
        {
            try
            {
                SqlConnection connection = Connection.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("insert_Roles", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@role_name", r.RoleName);
                cmd.Parameters.AddWithValue("@description", r.RoleDescription);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Rol insertado correctamente", "Inserción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar el rol: " + ex.Message, "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<Roles> TraerRol()
        {
            List<Roles> lista = new List<Roles>();

            string query = "SELECT id_role, role_name, description FROM roles";
            SqlConnection connection = Connection.ObtenerConexion();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Roles dept = new Roles
                {
                    IdRol = reader.GetInt32(0),
                    RoleName = reader.GetString(1),
                    RoleDescription = reader.GetString(2)
                };
                lista.Add(dept);
            }

            reader.Close();
            connection.Close();

            return lista;
        }

    }
}
