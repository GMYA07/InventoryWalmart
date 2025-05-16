using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Discount
    {
        private int id_discount;
        private string discount_code;
        private decimal discount_amount;
        private string description;
        private string discount_type;
        private string status;

        public Discount() { }

        public Discount(int id_discount, string discount_code, decimal discount_amount, string description, string discount_type, string status)
        {
            this.id_discount = id_discount;
            this.discount_code = discount_code;
            this.discount_amount = discount_amount;
            this.description = description;
            this.discount_type = discount_type;
            this.status = status;
        }

        public int IdDiscount
        {
            get { return id_discount; }
            set { id_discount = value; }
        }

        public string DiscountCode
        {
            get { return discount_code; }
            set { discount_code = value; }
        }

        public decimal DiscountAmount
        {
            get { return discount_amount; }
            set { discount_amount = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string DiscountType
        {
            get { return discount_type; }
            set { discount_type = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}
