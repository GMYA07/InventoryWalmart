using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Supplier
    {
        public int id_supplier { get; set; }

        public string manager_name { get; set; }

        public string company_name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public int id_department { get; set; }

        public string department_name { get; set; }
    }
}
