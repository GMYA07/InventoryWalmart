using InventoryWalmart.Model;
using System;
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
    }
}
