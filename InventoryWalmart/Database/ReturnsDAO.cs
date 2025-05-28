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

        public List<Returns> obtenerDevoluciones(string estado)
        {
            List<Returns> listaDevoluciones = new List<Returns>();

            string query = "SELECT id_return, id_customer, id_sale, return_date, description, status FROM RETURNS";
                   query += " WHERE status = @estado";

            using(SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.Add("@estado",SqlDbType.VarChar).Value = estado;

                    conn.Open();

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) { 
                                
                                Returns devolucion = new Returns();

                                devolucion.IdReturn = reader.GetInt32(0);
                                devolucion.IdCustomer = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                                devolucion.IdSale = reader.GetInt32(2);
                                devolucion.ReturnDate = reader.GetDateTime(3);
                                devolucion.Description = reader.GetString(4);
                                devolucion.Status = reader.GetString(5);
                                
                                listaDevoluciones.Add(devolucion);
                            }

                            return listaDevoluciones;
                            
                        }
                    }
                    catch (Exception ex) { 
                        Console.WriteLine("Error al mostrar las devoluciones: " + ex.ToString());
                        return null;
                    }
                }
            }
        }

        public List<Returns> obtenerDevolucionesEspecificasDeUnaVenta_Aceptada(string estado, int id_sale)
        {
            List<Returns> listaDevoluciones = new List<Returns>();

            string query = "SELECT id_return, id_customer, id_sale, return_date, description, status FROM RETURNS";
            query += " WHERE status = @estado and id_sale = @idVenta";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
                    cmd.Parameters.Add("@idVenta", SqlDbType.VarChar).Value = id_sale;

                    conn.Open();

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                Returns devolucion = new Returns();

                                devolucion.IdReturn = reader.GetInt32(0);
                                devolucion.IdCustomer = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                                devolucion.IdSale = reader.GetInt32(2);
                                devolucion.ReturnDate = reader.GetDateTime(3);
                                devolucion.Description = reader.GetString(4);
                                devolucion.Status = reader.GetString(5);

                                listaDevoluciones.Add(devolucion);
                            }

                            return listaDevoluciones;

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al mostrar las devoluciones: " + ex.ToString());
                        return null;
                    }
                }
            }
        }

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

        public int actualizarDevolucion(Returns devolucion)
        {
            string query = "UPDATE RETURNS SET id_customer = @id_customer, id_sale = @id_sale, return_date = @return_date, description = @description, status = @status";
                   query += " WHERE id_return = @idDevo";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id_customer", SqlDbType.Int).Value = devolucion.IdCustomer.HasValue ? (object)devolucion.IdCustomer.Value : DBNull.Value;
                    cmd.Parameters.Add("@id_sale", SqlDbType.Int).Value = devolucion.IdSale;
                    cmd.Parameters.Add("@return_date", SqlDbType.Date).Value = devolucion.ReturnDate;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = devolucion.Description;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = devolucion.Status;
                    cmd.Parameters.Add("@idDevo", SqlDbType.Int).Value = devolucion.IdReturn;

                    try
                    {
                        conn.Open();

                        int numeroFilasAfectadas = cmd.ExecuteNonQuery(); // Ejecuta y obtén el ID

                        return numeroFilasAfectadas;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("surgio error al actualizar la devo: " + ex.ToString());
                        return 0;
                    }

                }
            }
        }
    }
}
