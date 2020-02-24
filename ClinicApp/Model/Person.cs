using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApp
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> DateOfCreate { get; set; }
        public Nullable<System.DateTime> DateOfDelete { get; set; }
        public Nullable<System.DateTime> DateOfEdit { get; set; }
        public int Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public int PatientID { get; set; }
        [NotMapped]
        public int DrugID { get; set; }

        public Person() { }

    }
}
