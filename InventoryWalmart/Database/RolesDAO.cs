using System;
using System.Collections;
using System.Collections.Generic;
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
            try{
                String query = "INSERT INTO ROLES (role_name, description) VALUES (@rol_name,@description)";

                SqlConnection connection = Connection.ObtenerConexion();
                SqlCommand conn = new SqlCommand(query, connection);

                conn.Parameters.AddWithValue("@rol_name", r.RoleName);
                conn.Parameters.AddWithValue("@description", r.RoleDescription);

                connection.Open();
                conn.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Rol insertada correctamente", "Inserción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar el rol: " + ex.Message, "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
