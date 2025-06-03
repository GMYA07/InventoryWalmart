using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    public class Returns
    {
        private int id_return;
        private int? id_customer;
        private int id_sale;
        private DateTime return_date;
        private string description;
        private string status;

        public Returns() { }

        public Returns(int id_return, int? id_customer, int id_sale, DateTime return_date, string description, string status)
        {
            this.id_return = id_return;
            this.id_customer = id_customer;
            this.id_sale = id_sale;
            this.return_date = return_date;
            this.description = description;
            this.status = status;
        }

        public int IdReturn
        {
            get { return id_return; }
            set { id_return = value; }
        }

        public int? IdCustomer
        {
            get { return id_customer; }
            set { id_customer = value; }
        }

        public int IdSale
        {
            get { return id_sale; }
            set { id_sale = value; }
        }

        public DateTime ReturnDate
        {
            get { return return_date; }
            set { return_date = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }



    }
}
