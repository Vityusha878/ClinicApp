using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    public class Drug
    {
        public int ID { get; set; }        
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Measure { get; set; }
        public Nullable<System.DateTime> DateOfCreate { get; set; }
        public Nullable<System.DateTime> DateOfEdit { get; set; }
        public Nullable<System.DateTime> DateOfDelete { get; set; }

        public Drug() { }

    }
}
