using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Sale_Details
    {
        private int id_sale_detail;
        private int id_sale;
        private int id_product;
        private int quantity;
        private decimal price;

        public Sale_Details(){ }
        public Sale_Details(int id_sale_detail, int id_sale, int id_product, int quantity, decimal price)
        {
            this.id_sale_detail = id_sale_detail;
            this.id_sale = id_sale;
            this.id_product = id_product;
            this.quantity = quantity;
            this.price = price;
        }

        // Propiedades para acceder a los campos privados
        public int IdSaleDetail
        {
            get => id_sale_detail;
            set => id_sale_detail = value;
        }

        public int IdSale
        {
            get => id_sale;
            set => id_sale = value;
        }

        public int IdProduct
        {
            get => id_product;
            set => id_product = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public decimal Price
        {
            get => price;
            set => price = value;
        }


    }
}
