using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Product
    {
        private int id_product;
        private string name_product;
        private decimal price;
        private int stock;
        private int id_category;
        private int id_supplier;
        private string image_product;

        public Product() { }

        public Product(int id_product, string name_product, decimal price, int stock, int id_category, int id_supplier, string image_product)
        {
            this.id_product = id_product;
            this.name_product = name_product;
            this.price = price;
            this.stock = stock;
            this.id_category = id_category;
            this.id_supplier = id_supplier;
            this.image_product = image_product;
        }

        //Getters y Setters



        public int GetIdProduct()
        {
            return id_product;
        }

        public void SetIdProduct(int idProducto)
        {
            this.id_product = idProducto;
        }

        public string GetNameProduct()
        {
            return name_product;
        }

        public void SetNameProduct(string nameProducto)
        {
            name_product = nameProducto;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public void SetPrice(decimal value)
        {
            price = value;
        }

        public int GetStock()
        {
            return stock;
        }

        public void SetStock(int value)
        {
            stock = value;
        }

        public int GetIdCategory()
        {
            return id_category;
        }

        public void SetIdCategory(int value)
        {
            id_category = value;
        }

        public int GetIdSupplier()
        {
            return id_supplier;
        }

        public void SetIdSupplier(int value)
        {
            id_supplier = value;
        }

        public string GetImageProduct()
        {
            return image_product;
        }

        public void SetImageProduct(string value)
        {
            image_product = value;
        }



    }


}
