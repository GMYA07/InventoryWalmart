using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Interfaces
{
    internal interface traerReportes<T>
    {
        void Exportar(List<T> datos, string ruta);

    }
}
