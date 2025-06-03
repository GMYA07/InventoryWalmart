using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;

namespace InventoryWalmart.Controllers
{
    internal class SupplierController
    {
        private string connectionString = "Server=localhost; Database=InventoryWalmart; User Id=sa; Password=1234;";

        public List<Supplier> ObtenerProveedores()
        {
            List<Supplier> proveedores = new List<Supplier>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SUPPLIERS", connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Supplier proveedor = new Supplier
                        {
                            id_supplier = (int)reader["id_supplier"],
                            manager_name = (string)reader["manager_name"],
                            company_name = (string)reader["company_name"],
                            email = reader["email"] != DBNull.Value ? (string)reader["email"] : null,
                            phone = (string)reader["phone"],
                            id_department = reader["id_department"] != DBNull.Value ? (int)reader["id_department"] : 0
                        };

                        proveedores.Add(proveedor);
                    }
                }
            }

            return proveedores;
        }
    }

}
