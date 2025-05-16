using InventoryWalmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class Customer_CardDAO
    {
        public Customer_CardDAO() { }

        public Customer_Card obtenerCustomer_CardWithCardNumber(string CardNumber) {

            Customer_Card customerCardEncontrado = new Customer_Card();
            return customerCardEncontrado;
        }
    }
}
