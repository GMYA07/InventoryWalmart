using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.ModelRepors
{
    internal class ventasPorCajero
    {
        public ventasPorCajero()
        {
        }

        public string nombreCajero {  get; set; }
        public string apellidoCajero { get; set; }
        public int numeroTranscciones { get; set; }
        public int productosVendidos { get; set; }
        public double totalVendidos { get; set;}
        public double promedioVentas { get; set; }

        public string nombreCajeroCompleto()
        {
            return nombreCajero + " " + apellidoCajero;
        }
    }

}
