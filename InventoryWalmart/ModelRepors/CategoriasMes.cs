using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class CategoriasMes
    {
        public int IdReporte { get; set; }
        public DateTime FechaReporte { get; set; }
        public string NombreCategoria { get; set; }
        public decimal TotalVentaCategoria { get; set; }
        public int TotalVentas { get; set; }
        public CategoriasMes() { }
    }
}
