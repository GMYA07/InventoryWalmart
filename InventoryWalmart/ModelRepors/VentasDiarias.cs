using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class VentasDiarias
    {
        public int id_ventaDia {  get; set; }
       public DateTime fecha_reporte { get; set; }
       public int total_productos { get; set; }
       public Decimal sup_total { get; set; }
       public Decimal total_descuento { get; set; }
       public Decimal total_venta { get; set; }

        public VentasDiarias() { }

        public VentasDiarias(DateTime fecha_reporte, int total_productos, decimal sup_total, decimal total_descuento, decimal total_venta)
        {
            this.fecha_reporte = fecha_reporte;
            this.total_productos = total_productos;
            this.sup_total = sup_total;
            this.total_descuento = total_descuento;
            this.total_venta = total_venta;
        }
    }
}
