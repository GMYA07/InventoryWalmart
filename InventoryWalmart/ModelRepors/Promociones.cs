using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class Promociones
    {
        public String decripcion {  get; set; }
        public decimal discount_amount { get; set; }
        public String codigoDescuento { get; set; }
        public String tipodescuento { get; set; }
        public String status { get; set; }
        public Promociones() { }
    }
}
