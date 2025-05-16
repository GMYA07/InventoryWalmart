using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Customer
    {
        private int id_customer;
        private string first_name;
        private string last_name;
        private string email;
        private string phone;
        private string dui;
        private DateTime date_of_birth;

        public Customer() { }

        public Customer(int id_customer, string first_name, string last_name, string email, string phone, string dui, DateTime date_of_birth)
        {
            this.id_customer = id_customer;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.phone = phone;
            this.dui = dui;
            this.date_of_birth = date_of_birth;
        }

        public int IdCustomer
        {
            get { return id_customer; }
            set { id_customer = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }

        public DateTime DateOfBirth
        {
            get { return date_of_birth; }
            set { date_of_birth = value; }
        }
    }
}
