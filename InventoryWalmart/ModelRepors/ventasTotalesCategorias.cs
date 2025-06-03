using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class ventasTotalesCategorias
    {
        public string nombreCategoria { get; set; }
        public Double totalPrecioVenta { get; set; }
        public int totalVentas { get; set; }

        public ventasTotalesCategorias(){ }

        public ventasTotalesCategorias(string nombreCategoria, Double totalPrecioVenta, int totalVentas)
        {
            this.nombreCategoria = nombreCategoria;
            this.totalPrecioVenta = totalPrecioVenta;
            this.totalVentas = totalVentas;
        }
    }


}
