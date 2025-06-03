using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class gastosClientesTarjeta
    {
        public gastosClientesTarjeta()
        {
        }

        public string nombreCliente {  get; set; }
        public string apellidoCliente { get; set; }
        public string CardNumber { get; set; }             

        public int NumeroCompras { get; set; }             
        public int ProductosComprados { get; set; }        
        public decimal TotalGastado { get; set; }          

        public string nombreCompletoCliente()
        {
            return nombreCliente + " " + apellidoCliente;
        }
    }
}

