using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;

namespace ClinicApp
{
    public class Context : DbContext
    {
        public Context() : base("DataBase_db") { }

        public DbSet<Person> People { get; set; }
        public DbSet<PrescriptionOfDrug> PrescriptionsOfDrugs { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public DbSet<DispensingDrug> DispensingDrugs { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Model.Role> Roles { get; set; }
        public DbSet<Model.Authority> Authorities { get; set; }
        public DbSet<Model.Prohibition> Prohibitions { get; set; }

    }

}
