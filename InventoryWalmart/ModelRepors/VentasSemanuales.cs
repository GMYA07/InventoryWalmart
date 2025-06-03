using System;

namespace InventoryWalmart.ModelRepors
{
    internal class VentasSemanuales
    {
        public int id_reporte { get; set; }
        public DateTime inicio_semana { get; set; }
        public DateTime fin_semana { get; set; }
        public int cantidad_ventas { get; set; }
        public decimal inversion { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
        public DateTime fecha_generacion { get; set; }

        // Constructor vacío opcional
        public VentasSemanuales() { }
    }
}
