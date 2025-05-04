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

    }
}
