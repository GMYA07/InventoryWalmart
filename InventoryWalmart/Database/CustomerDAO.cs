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
    internal class CustomerDAO
    {

        public CustomerDAO() { }

        public static int GetCustomerIdByEmail(string email)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    string query = "SELECT id_customer FROM CUSTOMERS WHERE email = @Email";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID del cliente: " + ex.Message);
            }

            return 0;
        }


        public static List<Customer> SelectCustomers()
        {

            List<Customer> customer = new List<Customer>();

            string query = @"SELECT
                    id_customer,
                    first_name,
                    last_name,
                    email,
                    phone,
                    dui,
                    date_of_birth
                FROM customers;";

            SqlConnection connection = Connection.ObtenerConexion();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer customers = new Customer();

                customers.IdCustomer = reader.GetInt32(0);
                customers.FirstName = reader.GetString(1);
                customers.LastName = reader.GetString(2);
                customers.Email = reader.GetString(3);
                customers.Phone = reader.GetString(4);
                customers.Dui = reader.GetString(5);
                customers.DateOfBirth = reader.GetDateTime(6);

                customer.Add(customers);
            }
            reader.Close();
            connection.Close();

            return customer;
        }

        public void INSERT_Customer(Customer customer)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("insert_Customer", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@first_name", customer.FirstName);
                    command.Parameters.AddWithValue("@last_name", customer.LastName);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@phone", customer.Phone);
                    command.Parameters.AddWithValue("@dui", customer.Dui);
                    command.Parameters.AddWithValue("@date_of_birth", customer.DateOfBirth);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Alertas.AlertCorrect("Exito", "Cliente Agregado correctamente");
                }
            }
            catch (SqlException ex)
            {
                Alertas.AlertError("ERROR", $"No se ha podido registrar el cliente {ex.Message}");
            }

        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("update_Customer", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_customer", customer.IdCustomer);
                    command.Parameters.AddWithValue("@first_name", customer.FirstName);
                    command.Parameters.AddWithValue("@last_name", customer.LastName);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@phone", customer.Phone);
                    command.Parameters.AddWithValue("@dui", customer.Dui);
                    command.Parameters.AddWithValue("@date_of_birth", customer.DateOfBirth);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Alertas.AlertInfo("EXITO", "Se actualizo al cliente correctamente");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"No se pudo actualizar el cliente {ex.Message}", "ERROR");
            }
        }

        public Customer GetInfoCustomer(int id)
        {
            Customer customer = new Customer();

            string query = @"SELECT first_name, last_name, email, phone, dui, date_of_birth 
                FROM customers WHERE id_customer = @id";


            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customers = new Customer();
                        {
                            customers.FirstName = reader.GetString(0);
                            customers.LastName = reader.GetString(1);
                            customers.Email = reader.GetString(2);
                            customers.Phone = reader.GetString(3);
                            customers.Dui = reader.GetString(4);
                            customers.DateOfBirth = reader.GetDateTime(5);

                        };
                        customer = customers;
                    }

                    reader.Close();
                    connection.Close();

                    return customer;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR", $"No se ha podido obtener los datos del cliente {ex.Message}");
            }
            return null;

        }

        public Customer obtenerCustomerWithDUI(string dui)
        {
            Customer customerEncontrado = new Customer();

            string query = "SELECT id_customer, first_name,last_name,email,phone,dui,date_of_birth FROM CUSTOMERS WHERE dui = '" + dui + "'";

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
                                customerEncontrado.IdCustomer = reader.GetInt32(0);
                                customerEncontrado.FirstName = reader.GetString(1);
                                customerEncontrado.LastName = reader.GetString(2);
                                customerEncontrado.Email = reader.GetString(3);
                                customerEncontrado.Phone = reader.GetString(4);
                                customerEncontrado.Dui = reader.GetString(5);
                                customerEncontrado.DateOfBirth = reader.GetDateTime(6);

                                return customerEncontrado;
                            }
                            else
                            {
                                Console.WriteLine("No se encontro ese cliente");
                                return null;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }

        }

        public Customer obtenerCustomerWithId(int id)
        {
            Customer customerEncontrado = new Customer();

            string query = "SELECT id_customer, first_name,last_name,email,phone,dui,date_of_birth FROM CUSTOMERS WHERE id_customer = '" + id + "'";

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
                                customerEncontrado.IdCustomer = reader.GetInt32(0);
                                customerEncontrado.FirstName = reader.GetString(1);
                                customerEncontrado.LastName = reader.GetString(2);
                                customerEncontrado.Email = reader.GetString(3);
                                customerEncontrado.Phone = reader.GetString(4);
                                customerEncontrado.Dui = reader.GetString(5);
                                customerEncontrado.DateOfBirth = reader.GetDateTime(6);

                                return customerEncontrado;
                            }
                            else
                            {
                                Console.WriteLine("No se encontro ese cliente");
                                return null;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }

        }

        public static void DeleteCustomer(int id)
        {
            try
            {
                using (SqlConnection connection = Connection.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand("delete_Customer", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_customer", id);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al eliminar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static List<(Customer, Customer_Card, Benefits)> ObtenerClientesMembresia()
        {
            var lista = new List<(Customer, Customer_Card, Benefits)>();

            string query = @"
        SELECT 
            c.first_name,
            c.last_name,
            cc.card_number,
            cc.expiration_date,
            b.description
        FROM CUSTOMERS c
        JOIN CUSTOMER_CARD cc ON c.id_customer = cc.id_customer
        JOIN CARD_BENEFITS cb ON cb.id_card = cc.id_card
        JOIN BENEFITS b ON b.id_benefit = cb.id_benefit;";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var customer = new Customer
                                {
                                    FirstName = reader["first_name"].ToString(),
                                    LastName = reader["last_name"].ToString()
                                };

                                var card = new Customer_Card
                                {
                                    CardNumber = reader["card_number"].ToString(),
                                    ExpirationDate = Convert.ToDateTime(reader["expiration_date"])
                                };

                                var benefit = new Benefits
                                {
                                    Description = reader["description"].ToString()
                                };

                                lista.Add((customer, card, benefit));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return lista;
        }


        public static List<(Customer, Customer_Card, Benefits)> BuscarClientesMembresiaPorNombre(string filtro)
        {
            var lista = new List<(Customer, Customer_Card, Benefits)>();

            string query = @"
        SELECT 
            c.first_name,
            c.last_name,
            cc.card_number,
            cc.expiration_date,
            b.description
        FROM CUSTOMERS c
        JOIN CUSTOMER_CARD cc ON c.id_customer = cc.id_customer
        JOIN CARD_BENEFITS cb ON cb.id_card = cc.id_card
        JOIN BENEFITS b ON b.id_benefit = cb.id_benefit
        WHERE c.first_name LIKE @filtro OR c.last_name LIKE @filtro;";

            using (SqlConnection conn = Connection.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var customer = new Customer
                                {
                                    FirstName = reader["first_name"].ToString(),
                                    LastName = reader["last_name"].ToString()
                                };

                                var card = new Customer_Card
                                {
                                    CardNumber = reader["card_number"].ToString(),
                                    ExpirationDate = Convert.ToDateTime(reader["expiration_date"])
                                };

                                var benefit = new Benefits
                                {
                                    Description = reader["description"].ToString()
                                };

                                lista.Add((customer, card, benefit));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return lista;
        }



    }
}
