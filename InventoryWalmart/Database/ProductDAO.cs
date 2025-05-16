using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
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
    }
}
