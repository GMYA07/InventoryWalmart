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
    internal class ReturnsDAO
    {

        public ReturnsDAO() { }

        public int insertarNuevaDevolucion(Returns devolucion)
        {
            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("insert_Return", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_customer",SqlDbType.Int).Value = (devolucion.IdCustomer != 0) ? (object)devolucion.IdCustomer : DBNull.Value;
                    cmd.Parameters.Add("@id_sale", SqlDbType.Int).Value = devolucion.IdSale;
                    cmd.Parameters.Add("@return_date", SqlDbType.Date).Value = devolucion.ReturnDate;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = devolucion.Description;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = devolucion.Status;

                    try
                    {
                        conn.Open();

                        int numeroFilasAfectadas = cmd.ExecuteNonQuery(); // Ejecuta y obtén el ID

                        return numeroFilasAfectadas;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("surgio error al insertar la devo: "+ ex.ToString());
                        return 0;
                    }
                }

                
            }
        }
    }
}
