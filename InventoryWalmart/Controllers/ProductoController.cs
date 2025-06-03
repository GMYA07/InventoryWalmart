using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Model;
using System.Windows.Forms;

namespace InventoryWalmart.Controllers
{
    internal class ProductoController
    {
        private string connectionString = "Server=localhost; Database=InventoryWalmart; User Id=sa; Password=1234;";

        public void AgregarProducto(Product producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert_Product", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name_product", producto.GetNameProduct());
                cmd.Parameters.AddWithValue("@price", producto.GetPrice());
                cmd.Parameters.AddWithValue("@priceSup", producto.GetPriceSup());
                cmd.Parameters.AddWithValue("@stock", producto.GetStock());
                cmd.Parameters.AddWithValue("@id_category", producto.GetIdCategory());
                cmd.Parameters.AddWithValue("@id_supplier", producto.GetIdSupplier());
                cmd.Parameters.AddWithValue("@image_product", producto.GetImageProduct() ?? (object)DBNull.Value);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Product> ObtenerProductos()
        {
            List<Product> productos = new List<Product>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTS", conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product producto = new Product();
                        producto.SetIdProduct((int)reader["id_product"]);
                        producto.SetNameProduct((string)reader["name_product"]);
                        producto.SetPrice((decimal)reader["price"]);
                        producto.SetPriceSup((decimal)reader["priceSup"]);
                        producto.SetStock((int)reader["stock"]);
                        producto.SetIdCategory(reader["id_category"] != DBNull.Value ? (int)reader["id_category"] : 0);
                        producto.SetIdSupplier(reader["id_supplier"] != DBNull.Value ? (int)reader["id_supplier"] : 0);
                        producto.SetImageProduct(reader["image_product"] != DBNull.Value ? (string)reader["image_product"] : null);

                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

        public void ActualizarProducto(Product producto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("update_Product", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_product", producto.GetIdProduct());
                    cmd.Parameters.AddWithValue("@name_product", producto.GetNameProduct());
                    cmd.Parameters.AddWithValue("@price", producto.GetPrice());
                    cmd.Parameters.AddWithValue("@priceSup", producto.GetPriceSup());
                    cmd.Parameters.AddWithValue("@stock", producto.GetStock());
                    cmd.Parameters.AddWithValue("@id_category", producto.GetIdCategory());
                    cmd.Parameters.AddWithValue("@id_supplier", producto.GetIdSupplier());
                    cmd.Parameters.AddWithValue("@image_product", producto.GetImageProduct() ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto: " + ex.Message);
            }
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("delete_Product", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_product", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Manejo de error, puedes lanzar una excepción o mostrar un mensaje
                    MessageBox.Show(ex.Message, "Error al eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Product ObtenerProductoPorId(int id)
        {
            Product producto = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTS WHERE id_product = @id_product", conn);
                cmd.Parameters.AddWithValue("@id_product", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Product();
                        producto.SetIdProduct((int)reader["id_product"]);
                        producto.SetNameProduct((string)reader["name_product"]);
                        producto.SetPrice((decimal)reader["price"]);
                        producto.SetPriceSup((decimal)reader["priceSup"]);
                        producto.SetStock((int)reader["stock"]);
                        producto.SetIdCategory(reader["id_category"] != DBNull.Value ? (int)reader["id_category"] : 0);
                        producto.SetIdSupplier(reader["id_supplier"] != DBNull.Value ? (int)reader["id_supplier"] : 0);
                        producto.SetImageProduct(reader["image_product"] != DBNull.Value ? (string)reader["image_product"] : null);
                    }
                }
            }

            return producto;
        }
    }
}
