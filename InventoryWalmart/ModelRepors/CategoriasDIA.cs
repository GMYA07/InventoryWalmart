using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class CategoriasDIA : VentasDiarias
    {
        public DateTime? fecha {  get; set; }
        public String nombreCategoria { get; set; }
        public decimal ? dineroVentas { get; set; }
        public int totalVentas { get; set; }


        public CategoriasDIA() { }

        public CategoriasDIA(DateTime? fecha, string nombreCategoria, decimal? dineroVentas, int totalVentas)
        {
            this.fecha = fecha;
            this.nombreCategoria = nombreCategoria;
            this.dineroVentas = dineroVentas;
            this.totalVentas = totalVentas;
        }
    }
}
