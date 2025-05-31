using InventoryWalmart.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class ProductDAO
    {
        public ProductDAO() { 
        
        }

        public Product obtenerProducto(int idProducto)
        {
            Product productEncontrado = new Product();

            //Empezamos proceso para obtener la cuenta activa
            string query = "SELECT id_product,name_product,price,stock,id_category,id_supplier, image_product FROM PRODUCTS WHERE id_product = " + idProducto;

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, coon)) {
                    try
                    {
                        //Abrir Conexion

                        coon.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read()) {

                                productEncontrado.SetIdProduct(reader.GetInt32(0));
                                productEncontrado.SetNameProduct(reader.GetString(1));
                                productEncontrado.SetPrice(reader.GetDecimal(2));
                                productEncontrado.SetStock(reader.GetInt32(3));
                                productEncontrado.SetIdCategory(reader.GetInt32(4));
                                productEncontrado.SetIdSupplier(reader.GetInt32(5));
                                //productEncontrado.SetImageProduct(reader.GetString(6));

                                return productEncontrado;
                            }
                            else
                            {
                                Console.WriteLine("Usuario no encontrado");
                                return null;
                            }



                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine("ERROR: " + ex);
                        return null;
                    }
                }
            }
           
        }

        public int actualizarProductoStock(int idProducto, int nuevoStock) {

            string query = "UPDATE PRODUCTS SET stock = @newStock WHERE id_product = @idProducto";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, coon))
                {
                    command.Parameters.Add("@newStock", SqlDbType.Int).Value = nuevoStock;
                    command.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                    try
                    {
                        coon.Open();
                        int filasAfectadas = command.ExecuteNonQuery();

                        return filasAfectadas;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar el stock: " + ex.Message);
                        return 0;
                    }

                }    
            }
               
        }

        public static List<(Product, Categoria)> obtenerProductoPorNombre(string nombreProducto)
        {
            var lista = new List<(Product, Categoria)>(); // lista de tuplas

            string query = "SELECT * FROM dbo.BuscarProducto(@nombre)";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@nombre", nombreProducto);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                // Categoría
                                Categoria cat = new Categoria
                                {
                                    id_category = Convert.ToInt32(reader["id_category"]),
                                    category_name = reader["category_name"].ToString(),
                                    description = reader["description"].ToString()
                                };

                                // Producto
                                Product p = new Product();
                                p.SetNameProduct(reader["name_product"].ToString());
                                p.SetPrice(Convert.ToDecimal(reader["price"]));
                                p.SetStock(Convert.ToInt32(reader["stock"]));
                                p.SetIdCategory(Convert.ToInt32(reader["id_category"]));

                              
                                lista.Add((p, cat)); // Agregar ambos
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                    }
                }
            }

            return lista;
        }


        public static List<(Product, Categoria)> ObtenerProductos()
        {
            var lista = new List<(Product, Categoria)>();

            string query = @"
        SELECT 
            p.name_product,
            p.price,
            c.id_category,
            c.category_name,
            c.description,
            p.stock
        FROM PRODUCTS p
        INNER JOIN CATEGORY c ON c.id_category = p.id_category;";

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
                                // Crear la categoría asociada
                                Categoria categoria = new Categoria
                                {
                                    id_category = Convert.ToInt32(reader["id_category"]),
                                    category_name = reader["category_name"].ToString(),
                                    description = reader["description"].ToString()
                                };

                                // Crear el producto
                                Product p = new Product();
                                p.SetNameProduct(reader["name_product"].ToString());
                                p.SetPrice(Convert.ToDecimal(reader["price"]));
                                p.SetStock(Convert.ToInt32(reader["stock"]));
                                p.SetIdCategory(Convert.ToInt32(reader["id_category"]));

                                // Agregar como tupla
                                lista.Add((p, categoria));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return lista;
        }




    }
}
