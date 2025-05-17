using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class Customer_CardDAO
    {
        public Customer_CardDAO() { }

        public Customer_Card obtenerCustomer_CardWithCardNumber(string CardNumber)
        {

            Customer_Card customerCardEncontrado = new Customer_Card();

            string query = "SELECT id_card,id_customer,card_number,issue_date,expiration_date,points_balance,status FROM CUSTOMER_CARD WHERE card_number = '" + CardNumber + "'";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, coon))
                {

                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                customerCardEncontrado.IdCard = reader.GetInt32(0);
                                customerCardEncontrado.IdCustomer = reader.GetInt32(1);
                                customerCardEncontrado.CardNumber = reader.GetString(2);
                                customerCardEncontrado.IssueDate = reader.GetDateTime(3);
                                customerCardEncontrado.ExpirationDate = reader.GetDateTime(4);
                                customerCardEncontrado.PointsBalance = reader.GetInt32(5);
                                customerCardEncontrado.Status = reader.GetString(6);

                                return customerCardEncontrado;
                            }
                            else
                            {
                                Console.WriteLine("No se encontro la targeta del cliente");
                                return null;
                            }

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

        public Boolean verificarAsociacionTargetaDuiDAO(string targetaCliente, string id_customer)
        {
            Customer_Card customer_Card = new Customer_Card();

            string query = "SELECT cc.id_customer FROM CUSTOMER_CARD as cc";
                   query += " INNER JOIN CUSTOMERS as c on cc.id_customer = c.id_customer";
                   query += " WHERE cc.id_customer = '"+id_customer+"' AND cc.card_number = '"+targetaCliente+"'";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, coon))
                {

                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Console.WriteLine("Se encontro la asociacion de la targeta con el dui");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("No se encontro la asociacion de la targeta con el dui");
                                return false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return false;
                    }

                }
            }

        }
    }
}
