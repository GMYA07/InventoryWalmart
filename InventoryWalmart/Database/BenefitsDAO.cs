using InventoryWalmart.Model;
using InventoryWalmart.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class BenefitsDAO
    {
        public BenefitsDAO() { }

        public List<Benefits> obtenerBeneficiosClientesDAO(string duiCliente)
        {
            List<Benefits> benefits = new List<Benefits>();

            string query = "SELECT b.id_benefit, b.benefit_name, b.description, b.points_required, b.discount_percentage,b.start_date, b.end_date FROM CUSTOMERS as c";
            query += " INNER JOIN CUSTOMER_CARD as cd on c.id_customer = cd.id_customer";
            query += " INNER JOIN CARD_BENEFITS as cb on cd.id_card = cb.id_card";
            query += " INNER JOIN BENEFITS as b on cb.id_benefit = b.id_benefit";
            query += " WHERE c.dui = '" + duiCliente + "' AND cb.status_benefit = 'activo'";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, coon))
                {

                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Benefits benefit = new Benefits();
                                //seteamos el objeto
                                benefit.IdBenefit = reader.GetInt32(0);
                                benefit.BenefitName = reader.GetString(1);
                                benefit.Description = reader.GetString(2);
                                benefit.PointsRequierd = reader.GetInt32(3);
                                benefit.DiscountPercent = reader.GetDecimal(4);
                                benefit.StartDate = reader.GetDateTime(5);
                                benefit.EndDate = reader.GetDateTime(6);

                                benefits.Add(benefit); //añado el objeto seteado

                                
                            }

                            return benefits;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }

            }
        }

        public Benefits obtenerBeneficio(int idBeneficio)
        {
            Benefits benefit = new Benefits();

            string query = "SELECT b.id_benefit, b.benefit_name, b.description, b.points_required, b.discount_percentage, b.start_date, b.end_date FROM BENEFITS as b";
                   query += " INNER JOIN CARD_BENEFITS as cb on b.id_benefit = cb.id_benefit";
                   query += " INNER JOIN CUSTOMER_CARD as cc on cb.id_card = cc.id_card";
                   query += " WHERE b.id_benefit = '"+ idBeneficio + "'";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon))
                {
                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {

                            if (reader.Read())
                            {
                                benefit.IdBenefit = reader.GetInt32(0);
                                benefit.BenefitName = reader.GetString(1);
                                benefit.Description = reader.GetString(2);
                                benefit.PointsRequierd = reader.GetInt32(3);
                                benefit.DiscountPercent = reader.GetDecimal(4);
                                benefit.StartDate = reader.GetDateTime(5);
                                benefit.EndDate = reader.GetDateTime(6);

                                return benefit;
                            }
                            else {
                                Console.WriteLine("No se pudo obtener el beneficio");
                                return null;
                            
                            }
                        }
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }

      
        
        public static List<Benefits> SelectBenefits()
        {
            List<Benefits> benefitss = new List<Benefits>();

            string query = @"SELECT
                        id_benefit,
                        benefit_name,
                        description,
                        points_required,
                        discount_percentage,
                        start_date,
                        end_date
                        FROM BENEFITS;";

            using (SqlConnection connection = Connection.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Benefits benefit = new Benefits
                    {
                        IdBenefit = reader.GetInt32(0),
                        BenefitName = reader.GetString(1),
                        Description = reader.GetString(2),
                        PointsRequierd = reader.GetInt32(3),
                        DiscountPercent = reader.GetDecimal(4),
                        StartDate = reader.GetDateTime(5),
                        EndDate = reader.GetDateTime(6)
                    };
                    benefitss.Add(benefit);
                }
                reader.Close();
            }

            return benefitss;
        }

        public static void InsertBenefit(Benefits benefit)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("insertBenefits", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@benefit_name", benefit.BenefitName);
                    command.Parameters.AddWithValue("@description", benefit.Description);
                    command.Parameters.AddWithValue("@points_percentage", benefit.PointsRequierd);
                    command.Parameters.AddWithValue("@discount_percentage", benefit.DiscountPercent);
                    command.Parameters.AddWithValue("@start_date", benefit.StartDate);
                    command.Parameters.AddWithValue("@end_date", benefit.EndDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Alertas.AlertCorrect("Éxito", "Beneficio agregado correctamente.");
                }
            }
            catch (SqlException ex)
            {
                Alertas.AlertError("ERROR", $"No se pudo registrar el beneficio: {ex.Message}");
            }
        }

        public static void UpdateBenefit(Benefits benefit)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("update_Benefits", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_benefit", benefit.IdBenefit);
                    command.Parameters.AddWithValue("@benefit_name", benefit.BenefitName);
                    command.Parameters.AddWithValue("@description", benefit.Description);
                    command.Parameters.AddWithValue("@points_percentage", benefit.PointsRequierd);
                    command.Parameters.AddWithValue("@discount_percentage", benefit.DiscountPercent);
                    command.Parameters.AddWithValue("@start_date", benefit.StartDate);
                    command.Parameters.AddWithValue("@end_date", benefit.EndDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Alertas.AlertInfo("Éxito", "Se actualizó el beneficio correctamente.");
                }
            }
            catch (SqlException ex)
            {
                Alertas.AlertError("ERROR", $"No se pudo actualizar el beneficio: {ex.Message}");
            }
        }

        public static Benefits GetBenefitById(int id)
        {
            Benefits benefit = null;
            try
            {
                SqlConnection connection = Connection.ObtenerConexion();

                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BENEFITS WHERE id_benefit = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    benefit = new Benefits
                    {
                        IdBenefit = Convert.ToInt32(reader["id_benefit"]),
                        BenefitName = reader["benefit_name"].ToString(),
                        Description = reader["description"].ToString(),
                        PointsRequierd = Convert.ToInt32(reader["points_required"]),
                        DiscountPercent = Convert.ToDecimal(reader["discount_percentage"]),
                        StartDate = Convert.ToDateTime(reader["start_date"]),
                        EndDate = Convert.ToDateTime(reader["end_date"])
                    };
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener beneficio: " + ex.Message);
            }

            return benefit;
        }

        public static void InsertCardBenefit(CardBenefits cardBenefits)
        {
            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("insert_CardBenefit", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_card", cardBenefits.id_card);
                    cmd.Parameters.AddWithValue("@id_benefit", cardBenefits.id_benefit);
                    cmd.Parameters.AddWithValue("@date_acquired", cardBenefits.data_acquired);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        Alertas.AlertInfo("EXITO!","Se agrego correctamente");
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al insertar CardBenefit: " + ex.Message);
                    }
                }
            }
        }
    }
}
