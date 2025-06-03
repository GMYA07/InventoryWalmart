using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class UserBuscar
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? HireDate { get; set; }
        public string Cellphone { get; set; }
        public string Dui { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdDistrict { get; set; }
        public int? IdRole { get; set; }

        public UserBuscar() { }
    }
}
