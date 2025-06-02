using InventoryWalmart.Model;
using InventoryWalmart.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Customer_Card obtenerCustomer_CardWithDUI(string dui)
        {

            Customer_Card customerCardEncontrado = new Customer_Card();

            string query = "SELECT cc.id_card,cc.id_customer,cc.card_number,cc.issue_date,cc.expiration_date,cc.points_balance,cc.status FROM CUSTOMER_CARD as cc";
            query += " INNER JOIN CUSTOMERS as c on cc.id_customer = c.id_customer";
            query += " WHERE c.dui = @dui_user";
            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, coon))
                {
                    command.Parameters.Add("@dui_user", SqlDbType.VarChar).Value = dui;
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
            query += " WHERE cc.id_customer = '" + id_customer + "' AND cc.card_number = '" + targetaCliente + "'";

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

        public int OperacionPuntosCustomer_CardDAO(string customerCardCode, int ptsRestar)
        {
            string query = "UPDATE CUSTOMER_CARD SET points_balance = @points WHERE card_number = @card";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, coon))
                {

                    cmd.Parameters.Add("@points", SqlDbType.Int).Value = ptsRestar; // variable que contiene los puntos nuevos
                    cmd.Parameters.Add("@card", SqlDbType.VarChar).Value = customerCardCode;

                    try
                    {
                        coon.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        return filasAfectadas;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar puntos: " + ex.Message);
                        return 0;
                    }
                }
            }

        }

        public List<Customer_Card> GetCustomerCard()
        {
            List<Customer_Card> customer_Card = new List<Customer_Card>();

            string query = $@"SELECT
                            cc.id_card,
                            cc.card_number,
                            cc.issue_date,
                            cc.expiration_date,
                            cc.points_balance,
                            cc.status,
                            CONCAT(c.first_name, ' ', last_name) AS nombreC
                        FROM CUSTOMER_CARD AS cc
                        INNER JOIN CUSTOMERS AS c ON c.id_customer = cc.id_customer;";

            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer_Card Customercard = new Customer_Card();

                        Customercard.IdCard = reader.GetInt32(0);
                        Customercard.CardNumber = reader.GetString(1);
                        Customercard.IssueDate = reader.GetDateTime(2);
                        Customercard.ExpirationDate = reader.GetDateTime(3);
                        Customercard.PointsBalance = reader.GetInt32(4);
                        Customercard.Status = reader.GetString(5);
                        Customercard.CustomerName = reader.GetString(6);
                        customer_Card.Add(Customercard);
                    }
                    reader.Close();
                    connection.Close();

                    return customer_Card;
                }
            }
            catch (SqlException ex)
            {
                Alertas.AlertError("ERROR", $"No se ha podido obtener los datos para membresia: {ex.Message}");
            }

            return null;
        }

        public void INSERT_CustomerCard(Customer_Card customerCard)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("insert_CustomerCard", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@card_number", customerCard.CardNumber);
                    command.Parameters.AddWithValue("@issue_date", customerCard.IssueDate);
                    command.Parameters.AddWithValue("@expiration_date", customerCard.ExpirationDate);
                    command.Parameters.AddWithValue("@points_balance", customerCard.PointsBalance);
                    command.Parameters.AddWithValue("@status", customerCard.Status);
                    command.Parameters.AddWithValue("@id_customer", customerCard.IdCustomer);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Alertas.AlertCorrect("Exito", "Tarjeta de cliente agregada correctamente");
                }
            }
            catch (SqlException ex)
            {
                Alertas.AlertError("ERROR", $"No se ha podido registrar la tarjeta del cliente {ex.Message}");
            }
        }

        public int GetidCustomerByDui(string dui)
        {
            int id = 0;

            string query = @"SELECT id_customer
                            FROM CUSTOMERS
                            WHERE dui = @dui;";

            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@dui", dui);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    else {
                        Alertas.AlertError("ERROR", $"No se ha encontrado un ID de cliente con este DUI");
                    }

                    return id;
                }
            } catch (SqlException ex) {
                Alertas.AlertError("ERROR", $"No se ha encontrado un ID de cliente con este DUI: {ex.Message}");
            }
            return 0;
        }

        public void UpdateCustomerCard(Customer_Card customerCard)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("update_CustomerCard", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_card", customerCard.IdCard);
                    command.Parameters.AddWithValue("@card_number", customerCard.CardNumber);
                    command.Parameters.AddWithValue("@issue_date", customerCard.IssueDate);
                    command.Parameters.AddWithValue("@expiration_date", customerCard.ExpirationDate);
                    command.Parameters.AddWithValue("@points_balance", customerCard.PointsBalance);
                    command.Parameters.AddWithValue("@status", customerCard.Status);
                    command.Parameters.AddWithValue("@id_customer", customerCard.IdCustomer);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Alertas.AlertInfo("EXITO", "Se actualizó la tarjeta del cliente correctamente");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"No se pudo actualizar la tarjeta del cliente {ex.Message}", "ERROR");
            }
        }

        public List<Customer_Card> GetCustomerCardById(int idCard)
        {
            List<Customer_Card> customer_Card = new List<Customer_Card>();

                    string query = @"SELECT
                                        cc.id_card,
                                        cc.card_number,
                                        cc.issue_date,
                                        cc.expiration_date,
                                        cc.points_balance,
                                        cc.status,
                                        CONCAT(c.first_name, ' ', c.last_name) AS nombreC
                                    FROM CUSTOMER_CARD AS cc
                                    INNER JOIN CUSTOMERS AS c ON c.id_customer = cc.id_customer
                                    WHERE cc.id_card = @idCard;";

            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idCard", idCard);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer_Card customercard = new Customer_Card
                        {
                            IdCard = reader.GetInt32(0),
                            CardNumber = reader.GetString(1),
                            IssueDate = reader.GetDateTime(2),
                            ExpirationDate = reader.GetDateTime(3),
                            PointsBalance = reader.GetInt32(4),
                            Status = reader.GetString(5),
                            CustomerName = reader.GetString(6)
                        };

                        customer_Card.Add(customercard);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Alertas.AlertError("ERROR", $"No se ha podido obtener la tarjeta: {ex.Message}");
            }

            return customer_Card;
        }



        public int ObtenerContadorCartasDelDia()
        {
            int contador = 1;

            string query = @"SELECT COUNT(*) + 1
                            FROM CUSTOMER_CARD
                            WHERE CAST(issue_date AS DATE) = CAST(GETDATE() AS DATE);";

            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    contador = (int)command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                Alertas.AlertError("ERROR", $"No se pudo contar las cartas del día: {ex.Message}");
            }

            return contador;
        }

    }
}
