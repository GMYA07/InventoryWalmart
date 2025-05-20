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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace InventoryWalmart.Database
{
    internal class CustomerDAO
    {

        public CustomerDAO() { }

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

                    Alertas.AlertCorrect("Exito", "Cliente Agregado correctamente");
                }
            }
            catch (SqlException ex) {
                Alertas.AlertError("ERROR", $"No se ha podido registrar el cliente {ex.Message}");
            }
            
        }

        public Customer obtenerCustomerWithDUI(string dui)
        {
            Customer customerEncontrado = new Customer();

            string query = "SELECT id_customer, first_name,last_name,email,phone,dui,date_of_birth FROM CUSTOMERS WHERE dui = '"+dui+"'";

            using (SqlConnection coon = Connection.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(query, coon)) {

                    try
                    {
                        coon.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read()) { 
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
                    catch (Exception ex) { 
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return customerEncontrado;
        }
    }
}
