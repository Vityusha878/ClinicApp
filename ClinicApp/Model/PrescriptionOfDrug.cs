using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    public class PrescriptionOfDrug
    {
        public int ID { get; set; }
        public int DrugID { get; set; }
        public int PlanID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> DateOfCreate { get; set; }
        public Nullable<System.DateTime> DateOfEdit { get; set; }
        public Nullable<System.DateTime> DateOfDelete { get; set; }
        public DateTime StartTimeOfTaken { get; set; }
        public DateTime FinishTimeOfTaken { get; set; }

        public PrescriptionOfDrug() { }
    }
}
