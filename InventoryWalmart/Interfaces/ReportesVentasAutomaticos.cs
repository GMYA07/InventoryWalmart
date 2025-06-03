using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Interfaces
{
    internal interface ReportesVentasAutomaticos<T1, T2>
    {
        void Exportar(List<T1> tabla1, List<T2> tabla2, string ruta);
    }
}
