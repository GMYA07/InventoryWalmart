using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryWalmart.Database
{
    internal class Connection
    {
        private static string connectionString = "Server=BRIANLAPTOP;Database=inventoryWalmart;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }


        public static void prueba()
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("¡Conexión exitosa desde la clase!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }

        }
    }
}
