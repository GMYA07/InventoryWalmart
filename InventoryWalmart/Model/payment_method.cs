using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class payment_method
    {

        private int id_payment_method;
        private string metodo_pago;
        private string description;

        public void SetIdPaymentMethod(int id)
        {
            this.id_payment_method = id;
        }

        public void SetMetodoPago(string metodo)
        {
            this.metodo_pago = metodo;
        }

        public void SetDescription(string desc)
        {
            this.description = desc;
        }

        public int GetIdPaymentMethod()
        {
            return this.id_payment_method;
        }

        public string GetMetodoPago()
        {
            return this.metodo_pago;
        }

        public string GetDescription()
        {
            return this.description;
        }
    }
}
