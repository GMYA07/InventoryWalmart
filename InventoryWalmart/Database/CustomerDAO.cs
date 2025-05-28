using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class CustomerDAO
    {

        public CustomerDAO() { }

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
    }
}
