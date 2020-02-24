using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    public class TreatmentPlan
    {
        public int ID { get; set; }
        public int AssignerDoctorID { get; set; }
        public int PatientID { get; set; }
        public Nullable<System.DateTime> DateOfCreate { get; set; }
        public Nullable<System.DateTime> DateOfEdit { get; set; }
        public Nullable<System.DateTime> DateOfDelete { get; set; }

        public TreatmentPlan() { }
    }
}
