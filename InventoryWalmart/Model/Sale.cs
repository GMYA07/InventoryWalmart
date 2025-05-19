using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Sale
    {
        private int idSale;
        private int id_customer;
        private DateTime sale_date;
        private decimal total_amount;
        private int id_payment_method;
        private int? id_discount;
        private int? id_card;
        private int point_used;
        private int point_earned;
        public Sale() { }

        public Sale(int idSale, int id_customer, DateTime sale_date, decimal total_amount, int id_payment_method, int id_discount, int id_card, int point_used, int point_earned)
        {
            this.idSale = idSale;
            this.id_customer = id_customer;
            this.sale_date = sale_date;
            this.total_amount = total_amount;
            this.id_payment_method = id_payment_method;
            this.id_discount = id_discount;
            this.id_card = id_card;
            this.point_used = point_used;
            this.point_earned = point_earned;
        }

        //Genero Los Getters y Setters
        public int GetIdSale()
        {
            return idSale;
        }

        public void SetIdSale(int value)
        {
            idSale = value;
        }

        public int GetIdCustomer()
        {
            return id_customer;
        }

        public void SetIdCustomer(int value)
        {
            id_customer = value;
        }

        public DateTime GetSaleDate()
        {
            return sale_date;
        }

        public void SetSaleDate(DateTime value)
        {
            sale_date = value;
        }

        public decimal GetTotalAmount()
        {
            return total_amount;
        }

        public void SetTotalAmount(decimal value)
        {
            total_amount = value;
        }

        public int GetIdPaymentMethod()
        {
            return id_payment_method;
        }

        public void SetIdPaymentMethod(int value)
        {
            id_payment_method = value;
        }

        public int? GetIdDiscount()
        {
            return id_discount;
        }

        public void SetIdDiscount(int? value)
        {
            id_discount = value;
        }

        public int? GetIdCard()
        {
            return id_card;
        }

        public void SetIdCard(int? value)
        {
            id_card = value;
        }

        public int GetPointUsed()
        {
            return point_used;
        }

        public void SetPointUsed(int value)
        {
            point_used = value;
        }

        public int GetPointEarned()
        {
            return point_earned;
        }

        public void SetPointEarned(int value)
        {
            point_earned = value;
        }


    }
}
