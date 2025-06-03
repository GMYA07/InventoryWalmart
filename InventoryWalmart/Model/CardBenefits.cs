using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Database
{
    internal class CardBenefits
    {
        public int id_card_benefit {  get; set; }

        public int id_card { get; set; }

        public int id_benefit { get; set; }

        public DateTime data_acquired { get; set; } = DateTime.Today;

    }
}
