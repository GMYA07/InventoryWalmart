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

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria
                        {
                            id_category = (int)reader["id_category"], // Usar 'IdCategory'
                            category_name = (string)reader["category_name"], // Usar 'CategoryName'
                            description = reader["description"] != DBNull.Value ? (string)reader["description"] : null
                        };

                        categorias.Add(categoria);
                    }
                }
            }

            return categorias;
        }
    }
}
