using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    public class VentaMensual
    {
        public int id_reporte_mes { get; set; }
        public string mes_anio { get; set; } // formato 'YYYY-MM'
        public int cantidad_ventas { get; set; }
        public decimal subtotal { get; set; }
        public decimal total_descuento { get; set; }
        public decimal total_vendido { get; set; }
        public decimal inversion_mes { get; set; }
        public decimal ganancia_mes { get; set; }
        public decimal reinversion_20 { get; set; }

        public VentaMensual() { }
    }
}
