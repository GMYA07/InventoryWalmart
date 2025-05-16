using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Benefits
    {
        private int id_benefit;
        private string benefitName;
        private string description;
        private int points_requierd;
        private int discount_percent;
        private DateTime start_date;
        private DateTime end_date;

        public Benefits() { }

        public Benefits(int id_benefit, string benefitName, string description, int points_requierd, int discount_percent, DateTime start_date, DateTime end_date)
        {
            this.id_benefit = id_benefit;
            this.benefitName = benefitName;
            this.description = description;
            this.points_requierd = points_requierd;
            this.discount_percent = discount_percent;
            this.start_date = start_date;
            this.end_date = end_date;
        }

        
        public int IdBenefit
        {
            get { return id_benefit; }
            set { id_benefit = value; }
        }

        public string BenefitName
        {
            get { return benefitName; }
            set { benefitName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int PointsRequierd
        {
            get { return points_requierd; }
            set { points_requierd = value; }
        }

        public int DiscountPercent
        {
            get { return discount_percent; }
            set { discount_percent = value; }
        }

        public DateTime StartDate
        {
            get { return start_date; }
            set { start_date = value; }
        }

        public DateTime EndDate
        {
            get { return end_date; }
            set { end_date = value; }
        }


    }
}
