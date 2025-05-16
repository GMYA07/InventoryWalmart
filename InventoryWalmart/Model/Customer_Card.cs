using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Customer_Card
    {
        private int id_card;
        private int id_customer;
        private string card_number;
        private DateTime issue_date;
        private DateTime expiration_date;
        private int points_balance;
        private string status;

        public Customer_Card() { }

        public Customer_Card(int id_card, int id_customer, string card_number, DateTime issue_date, DateTime expiration_date, int points_balance, string status)
        {
            this.id_card = id_card;
            this.id_customer = id_customer;
            this.card_number = card_number;
            this.issue_date = issue_date;
            this.expiration_date = expiration_date;
            this.points_balance = points_balance;
            this.status = status;
        }

        public int IdCard
        {
            get { return id_card; }
            set { id_card = value; }
        }

        public int IdCustomer
        {
            get { return id_customer; }
            set { id_customer = value; }
        }

        public string CardNumber
        {
            get { return card_number; }
            set { card_number = value; }
        }

        public DateTime IssueDate
        {
            get { return issue_date; }
            set { issue_date = value; }
        }

        public DateTime ExpirationDate
        {
            get { return expiration_date; }
            set { expiration_date = value; }
        }

        public int PointsBalance
        {
            get { return points_balance; }
            set { points_balance = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
