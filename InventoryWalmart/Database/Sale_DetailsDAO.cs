using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InventoryWalmart.Database
{
    internal class Sale_DetailsDAO
    {
        public Sale_DetailsDAO() { }

        public bool RegistrarListaVentaDAO(List<Sale_Details> listaVenta)
        {
            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                coon.Open();
                using (SqlTransaction transaction = coon.BeginTransaction()) // hace que todas las sentencias se lleguen a ejecutar, si falla 1 ya no serviria
                {
                    try
                    {
                        int rowsAffected = 0;

                        foreach (Sale_Details producto in listaVenta)
                        {
                            using (SqlCommand cmd = new SqlCommand("insert_SaleDetail", coon, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                // Parámetros del stored procedure
                                cmd.Parameters.Add("@id_sale", SqlDbType.Int).Value = producto.IdSale;
                                cmd.Parameters.Add("@id_product", SqlDbType.Int).Value = producto.IdProduct;
                                cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = producto.Quantity;
                                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = producto.Price;

                                rowsAffected += cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit(); // Confirmar transaccion si todo va bien
                        Console.WriteLine($"Total afectados: {rowsAffected} de {listaVenta.Count}");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public Sale_Details obtenerSaleDetail(int idVenta) 
        { 

            Sale_Details sale_Details = new Sale_Details();

            string query = "SELECT id_sale_detail, id_sale, id_product, quantity, price FROM SALE_DETAILS WHERE id_sale = @idVenta";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon))
                {
                    cmd.Parameters.Add("@idVenta",SqlDbType.Int).Value = idVenta;

                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {

                            if (reader.Read()) { 
                                
                                sale_Details.IdSaleDetail = reader.GetInt32(0);
                                sale_Details.IdSale = reader.GetInt32(1);
                                sale_Details.IdProduct = reader.GetInt32(2);
                                sale_Details.Quantity = reader.GetInt32(3);
                                sale_Details.Price = reader.GetDecimal(4);

                                return sale_Details;
                            }
                            else
                            {
                                Console.WriteLine("El error al seleccionar la sale de la bdd");
                                return null;
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("El error al seleccionar la sale de la bdd fue: " + ex);
                        return null;
                    }
                }
            }

                
        }

        public int obtenerCantidadDeDetallesVenta(int idVenta)
        {
            string query = "SELECT COUNT(*) FROM SALE_DETAILS WHERE id_sale = @idVenta";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon))
                {
                    cmd.Parameters.Add("@idVenta", SqlDbType.Int).Value = idVenta;

                    try
                    {
                        coon.Open();

                        object resultado = cmd.ExecuteScalar();

                        coon.Close();

                        int totalFilas = Convert.ToInt32(resultado);

                        return totalFilas;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("El error al seleccionar la sale de la bdd fue: " + ex);
                        return 0;
                    }
                }
            }
        }
        public Sale_Details obtenerSaleDetails(int idVenta)
        {

            Sale_Details sale_Detail = new Sale_Details();

            string query = "SELECT id_sale_detail, id_sale, id_product, quantity, price FROM SALE_DETAILS WHERE id_sale = @idVenta";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon))
                {
                    cmd.Parameters.Add("@idVenta", SqlDbType.Int).Value = idVenta;

                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                sale_Detail.IdSaleDetail = reader.GetInt32(0);
                                sale_Detail.IdSale = reader.GetInt32(1);
                                sale_Detail.IdProduct = reader.GetInt32(2);
                                sale_Detail.Quantity = reader.GetInt32(3);
                                sale_Detail.Price = reader.GetDecimal(4);

                                return sale_Detail;
                            }
                            else
                            {
                                Console.WriteLine("El error al seleccionar la sale de la bdd");
                                return null;
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("El error al seleccionar la sale de la bdd fue: " + ex);
                        return null;
                    }
                }
            }


        }

        public List<Sale_Details> obtenerListaDeDetallesVentaConTargeta(int idVenta, int idCustomer)
        {
            List<Sale_Details > lista_Detalles_Venta = new List<Sale_Details>();
            
            string query = "SELECT sd.id_sale_detail, sd.id_sale, sd.id_product, sd.quantity, sd.price FROM SALE_DETAILS as sd";
                   query += " INNER JOIN SALES as s on sd.id_sale = s.id_sale";
                   query += " WHERE sd.id_sale = @idVenta AND s.id_customer = @idCustomer";
            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon)) {

                    cmd.Parameters.Add("@idVenta", SqlDbType.Int).Value = idVenta;
                    cmd.Parameters.Add("@idCustomer", SqlDbType.Int).Value = idCustomer;
                    coon.Open();

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Sale_Details sale_Detail = new Sale_Details();

                                sale_Detail.IdSaleDetail = reader.GetInt32(0);
                                sale_Detail.IdSale = reader.GetInt32(1);
                                sale_Detail.IdProduct = reader.GetInt32(2);
                                sale_Detail.Quantity = reader.GetInt32(3);
                                sale_Detail.Price = reader.GetDecimal(4);

                                lista_Detalles_Venta.Add(sale_Detail);
                            }

                        }

                        return lista_Detalles_Venta;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("El error al traer la lista de los detalles de venta fue: " + ex.Message);
                        return null;
                    }

                }

            }

        }

        public List<Sale_Details> obtenerListaDeDetallesVentaSinTargeta(int idVenta)
        {
            List<Sale_Details> lista_Detalles_Venta = new List<Sale_Details>();

            string query = "SELECT sd.id_sale_detail, sd.id_sale, sd.id_product, sd.quantity, sd.price FROM SALE_DETAILS as sd";
            query += " INNER JOIN SALES as s on sd.id_sale = s.id_sale";
            query += " WHERE sd.id_sale = @idVenta";
            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon))
                {

                    cmd.Parameters.Add("@idVenta", SqlDbType.Int).Value = idVenta;
                    coon.Open();

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Sale_Details sale_Detail = new Sale_Details();

                                sale_Detail.IdSaleDetail = reader.GetInt32(0);
                                sale_Detail.IdSale = reader.GetInt32(1);
                                sale_Detail.IdProduct = reader.GetInt32(2);
                                sale_Detail.Quantity = reader.GetInt32(3);
                                sale_Detail.Price = reader.GetDecimal(4);

                                lista_Detalles_Venta.Add(sale_Detail);
                            }

                        }

                        return lista_Detalles_Venta;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("El error al traer la lista de los detalles de venta fue: " + ex.Message);
                        return null;
                    }

                }

            }

        }
    }
}
