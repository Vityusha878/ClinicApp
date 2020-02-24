using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    public class DispensingDrug
    {
        public int ID { get; set; }
        public Nullable<int> NurseID { get; set; }
        public int PrescriptionID { get; set; }
        public int TreatmentPlanID { get; set; }
        public Nullable<double> Dosage { get; set; }
        public Nullable<DateTime> DateOfCreate { get; set; }
        public Nullable<DateTime> DateOfEdit { get; set; }
        public Nullable<DateTime> DateOfDelete { get; set; }
        public DateTime TimeOfTakeDispense { get; set; }
        public bool Status { get; set; }

        public DispensingDrug() { }
    }
}
