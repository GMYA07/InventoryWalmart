using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class points
    {
        public string CardNumber { get; set; }            // de cc.card_number
        public string Customer { get; set; }              // de CONCAT(...) AS customer
        public string Dui { get; set; }                   // de c.dui
        public int PointsBalance { get; set; }            // de cc.points_balance
        public int TotalPointsChange { get; set; }

    }
}
