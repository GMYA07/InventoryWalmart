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

        public int registrarVenta(Sale nuevaVenta)
        {
            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("insert_Sale", coon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_customer", SqlDbType.Int).Value = nuevaVenta.GetIdCustomer();
                    cmd.Parameters.Add("@sale_date", SqlDbType.Date).Value = nuevaVenta.GetSaleDate();
                    cmd.Parameters.Add("@total_amount",SqlDbType.Decimal).Value = nuevaVenta.GetTotalAmount();
                    cmd.Parameters.Add("@id_payment_method", SqlDbType.Int).Value = nuevaVenta.GetIdPaymentMethod();
                    cmd.Parameters.Add("@id_discount", SqlDbType.Int).Value = (nuevaVenta.GetIdDiscount() != 0)? (object)nuevaVenta.GetIdDiscount() : DBNull.Value;
                    cmd.Parameters.Add("@id_card", SqlDbType.Int).Value = (nuevaVenta.GetIdCard() != 0) ? (object)nuevaVenta.GetIdCard() : DBNull.Value;
                    cmd.Parameters.Add("@points_used",SqlDbType.Int).Value = nuevaVenta.GetPointUsed();
                    cmd.Parameters.Add("@points_earned", SqlDbType.Int).Value = nuevaVenta.GetPointEarned();

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
