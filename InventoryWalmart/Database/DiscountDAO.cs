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
    internal class DiscountDAO
    {
        public DiscountDAO() { }

        public List<Discount> obtenerDescuentos(string estado)
        {
            List<Discount> descuentos = new List<Discount>();

            string query = "SELECT id_discount, discount_code, discount_amount, description, discount_type, status";
                   query += " FROM DISCOUNT WHERE status = @estado";

            using(SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn)) {

                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read()) { 
                                Discount discount = new Discount();
                                discount.IdDiscount = reader.GetInt32(0);
                                discount.DiscountCode = reader.GetString(1);
                                discount.DiscountAmount = reader.GetDecimal(2);
                                discount.Description = reader.GetString(3);
                                discount.DiscountType = reader.GetString(4);
                                discount.Status = reader.GetString(5);

                                descuentos.Add(discount);
                            }

                            return descuentos;
                        }
                    }
                    catch (Exception ex) { 
                        Console.WriteLine("El error al obtener la lista de los descuentos es: " + ex.ToString());
                        return null;
                    }
                }
            }
            
        }

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

        public int insertarDescuento(Discount descuento)
        {
            string query = "INSERT INTO DISCOUNT (discount_code, discount_amount, description, discount_type, status)";
                   query += " VALUES(@codigoDescuento, @cantidadDescuento, @descripcion, @tipoDescuento, @estadoDescuento)";

            using (SqlConnection con = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@codigoDescuento",SqlDbType.VarChar).Value = descuento.DiscountCode;
                    cmd.Parameters.Add("@cantidadDescuento",SqlDbType.Decimal).Value = descuento.DiscountAmount;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value= descuento.Description;
                    cmd.Parameters.Add("@tipoDescuento", SqlDbType.VarChar).Value = descuento.DiscountType;
                    cmd.Parameters.Add("@estadoDescuento", SqlDbType.VarChar).Value = descuento.Status;

                    try
                    {
                        con.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        return filasAfectadas;
                    }
                    catch (Exception ex) { 
                        Console.WriteLine(ex.ToString());
                        return 0;
                    }

                }
            }
        }

        public int modificarDescuento(Discount descuento) 
        {

            string query = "UPDATE DISCOUNT SET discount_code = @codigoDescuento, discount_amount = @cantidadDescuento, description = @descripcion, discount_type = @tipoDescuento, status = @estadoDescuento";
            query += " WHERE id_discount = @id";

            using (SqlConnection con = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@codigoDescuento", SqlDbType.VarChar).Value = descuento.DiscountCode;
                    cmd.Parameters.Add("@cantidadDescuento", SqlDbType.Decimal).Value = descuento.DiscountAmount;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descuento.Description;
                    cmd.Parameters.Add("@tipoDescuento", SqlDbType.VarChar).Value = descuento.DiscountType;
                    cmd.Parameters.Add("@estadoDescuento", SqlDbType.VarChar).Value = descuento.Status;
                    cmd.Parameters.Add("@id",SqlDbType.Int).Value = descuento.IdDiscount;

                    try
                    {
                        con.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        return filasAfectadas;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return 0;
                    }

                }
            }
        }
        public int eliminarDescuento(int idDescuento) 
        {
            string query = "DELETE FROM DISCOUNT";
            query += " WHERE id_discount = @id";

            using (SqlConnection con = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idDescuento;

                    try
                    {
                        con.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        return filasAfectadas;
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
