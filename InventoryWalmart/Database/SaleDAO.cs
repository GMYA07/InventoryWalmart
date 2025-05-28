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
    internal class SaleDAO
    {
        public SaleDAO() { }

        public Sale obtenerVentaConId(int idventa)
        {
            Sale venta = new Sale();
            string query = "SELECT id_sale, id_customer, sale_date, total_amount, id_payment_method, id_discount, id_card, id_user, points_used, points_earned ";
                   query += " FROM SALES WHERE id_sale = @idSale";

            using(SqlConnection con = Connection.ObtenerConexion())
            {
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@idSale",SqlDbType.Int).Value = idventa;

                    con.Open();

                        try
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    venta.SetIdSale(idventa);
                                    venta.SetIdCustomer(reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1));
                                    venta.SetSaleDate(reader.GetDateTime(2));
                                    venta.SetTotalAmount(reader.GetDecimal(3));
                                    venta.SetIdPaymentMethod(reader.GetInt32(4));
                                    venta.SetIdDiscount(reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5));
                                    venta.SetIdCard(reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6));
                                    venta.SetPointUsed(reader.GetInt32(7));
                                    venta.SetPointEarned(reader.GetInt32(8));

                                }
                            }
                            

                            return venta;
                        }
                        catch (Exception ex) { 
                            Console.WriteLine("Error al obtener la venta: " + ex.ToString());
                            return null;
                        }
                    
                }
            }
        }

        public int registrarVenta(Sale nuevaVenta)
        {
            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("insert_Sale", coon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_customer", SqlDbType.Int).Value = (nuevaVenta.GetIdCustomer() != 0) ? (object)nuevaVenta.GetIdCustomer() : DBNull.Value;
                    cmd.Parameters.Add("@sale_date", SqlDbType.Date).Value = nuevaVenta.GetSaleDate();
                    cmd.Parameters.Add("@total_amount",SqlDbType.Decimal).Value = nuevaVenta.GetTotalAmount();
                    cmd.Parameters.Add("@id_payment_method", SqlDbType.Int).Value = nuevaVenta.GetIdPaymentMethod();
                    cmd.Parameters.Add("@id_discount", SqlDbType.Int).Value = (nuevaVenta.GetIdDiscount() != 0)? (object)nuevaVenta.GetIdDiscount() : DBNull.Value;
                    cmd.Parameters.Add("@id_card", SqlDbType.Int).Value = (nuevaVenta.GetIdCard() != 0) ? (object)nuevaVenta.GetIdCard() : DBNull.Value;
                    cmd.Parameters.Add("@points_used",SqlDbType.Int).Value = nuevaVenta.GetPointUsed();
                    cmd.Parameters.Add("@points_earned", SqlDbType.Int).Value = nuevaVenta.GetPointEarned();
                    cmd.Parameters.Add("@id_user",SqlDbType.Int).Value = nuevaVenta.GetIdUser();

                    try
                    {
                        coon.Open();

                        int nuevoId = Convert.ToInt32(cmd.ExecuteScalar()); // Ejecuta y obtén el ID

                        Console.WriteLine($"ID generado: {nuevoId}");
                        return nuevoId;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return 0;
                    }

                }
            }
        }


    }
}
