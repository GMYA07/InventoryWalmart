using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;

namespace InventoryWalmart.Controllers
{
    internal class CategoriaController
    {
        private string connectionString = "Server=localhost; Database=InventoryWalmart; User Id=sa; Password=1234;";

        public List<Category> ObtenerCategorias()
        {
            List<Category> categorias = new List<Category>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category categoria = new Category
                        {
                            IdCategory = (int)reader["id_category"], // Usar 'IdCategory'
                            CategoryName = (string)reader["category_name"], // Usar 'CategoryName'
                            Description = reader["description"] != DBNull.Value ? (string)reader["description"] : null
                        };

                        categorias.Add(categoria);
                    }
                }
            }

            return categorias;
        }
    }
}
