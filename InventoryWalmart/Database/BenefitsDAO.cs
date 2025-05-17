using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class BenefitsDAO
    {
        public BenefitsDAO() { }

        public List<Benefits> obtenerBeneficiosClientesDAO(string targetaCliente, string duiCliente)
        {
            List<Benefits> benefits = new List<Benefits>();

            string query = "SELECT b.id_benefit, b.benefit_name, b.description, b.points_required, b.discount_percentage,b.start_date, b.end_date FROM CUSTOMERS as c";
            query += " INNER JOIN CUSTOMER_CARD as cd on c.id_customer = cd.id_customer";
            query += " INNER JOIN CARD_BENEFITS as cb on cd.id_card = cb.id_card";
            query += " INNER JOIN BENEFITS as b on cb.id_benefit = b.id_benefit";
            query += " WHERE c.dui = '" + duiCliente + "'";

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

        public Benefits obtenerBeneficioClienteDAO(string targetaCliente)
        {
            Benefits benefit = new Benefits();

            string query = "SELECT b.id_benefit, b.benefit_name, b.description, b.points_required, b.discount_percentage, b.start_date, b.end_date FROM BENEFITS as b";
                   query += " INNER JOIN CARD_BENEFITS as cb on b.id_benefit = cb.id_benefit";
                   query += " INNER JOIN CUSTOMER_CARD as cc on cb.id_card = cc.id_card";
                   query += " WHERE cc.card_number = '"+targetaCliente+"'";

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
    }
}
