using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class DiscountDAO
    {
        public DiscountDAO() { }

        public Discount obtenerDescuentoActivo(string discount_code)
        {
            Discount descuentoEncontrado = new Discount();

            string query = "SELECT id_discount,discount_code,discount_amount,description,discount_type,status FROM DISCOUNT WHERE status = 'activo' AND discount_code = '"+discount_code+"'";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon)) {
                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {

                            if (reader.Read()) { 
                                
                                descuentoEncontrado.IdDiscount = reader.GetInt32(0);
                                descuentoEncontrado.DiscountCode = reader.GetString(1);
                                descuentoEncontrado.DiscountAmount = reader.GetDecimal(2);
                                descuentoEncontrado.Description = reader.GetString(3);
                                descuentoEncontrado.DiscountType = reader.GetString(4);
                                descuentoEncontrado.Status = reader.GetString(5);

                                return descuentoEncontrado;
                            }
                            else
                            {
                                Console.WriteLine("Descuento no encontrado");
                                return null;
                            }

                        }
                    }
                    catch (Exception ex) { 
                        ex.ToString();
                        return null;
                    }
                    
                }
            }
        }
    }
}
