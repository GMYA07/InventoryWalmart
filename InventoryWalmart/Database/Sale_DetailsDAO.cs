using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        return rowsAffected == listaVenta.Count; // Verifica que todos se insertaron
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
