using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class HistorialVentas
    {
        public DateTime periodo { get; set; }
        public int cantidadVentas { get; set; }
        public double totalVendido { get; set; }
        public double totalInvertido { get; set; }
        public double ganancia { get; set; }

        public HistorialVentas() { }
    }
}
