using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClinicApp
{
    public class OperationsOfDispensingDrugs
    {
        public static string Add(DispensingDrug dispense)
        {
            string answer = СheckField(dispense);
            if (answer == "Данные корректны!")
            {
                using (Context db = new Context())
                {
                    //drug.DateOfCreate = DateTime.Now;
                    db.DispensingDrugs.Add(dispense);
                    db.SaveChanges();
                    answer = "Произошло добавление";
                }
                return answer;
            }
            return answer;
        }
        public static string Edit(DispensingDrug dispense)
        {
            string answer = СheckField(dispense);
            if (answer == "Данные корректны")
            {
                using (Context db = new Context())
                {
                    //drug.DateOfEdit = DateTime.Now;
                    db.Entry(dispense).State = EntityState.Modified;
                    db.SaveChanges();
                    answer = "Произошло редактирование";
                }
                return answer;
            }
            return answer;
        }
        public static string Del(int ID)
        {
            using (Context db = new Context())
            {
                var drug = db.Drugs
                    .Single(p => p.ID == ID);
                //drug.DateOfDelete = DateTime.Now;
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "Произошло удаление";
        }
        public static DispensingDrug FindByID(int ID)
        {
            using (Context db = new Context())
            {
                var dispense = db.DispensingDrugs
                    .Single(p => p.ID == ID);
                return dispense;
            }
        }
        public static string СheckField(DispensingDrug dispense)
        {
            if (dispense.Dosage == 0)
            {
                return "Введите дозу. Это поле не может быть пустым";
            }

            if (dispense.TimeOfTakeDispense == null)
            {
                return "Введите время приема лекарства. Это поле не может быть пустым";
            }


            using (Context context = new Context())
            {
                DispensingDrug d = new DispensingDrug();
                d = context.DispensingDrugs.Where(x => x.Dosage == dispense.Dosage && x.TimeOfTakeDispense == dispense.TimeOfTakeDispense).FirstOrDefault<DispensingDrug>();
                if (d != null)
                {
                    return "Такое лекарство уже существует в базе под номером " + d.ID;
                }
            }
            return "Данные корректны.";
        }



        public static List<DispensingDrug> FindAllDispensing()

        {
            List<DispensingDrug> listDispensing = new List<DispensingDrug>();

            using (Context db = new Context())
            {
                var query = from d in db.DispensingDrugs
                            select new
                            {
                                ID = d.ID,
                                NurseID = d.NurseID,
                                PrescriptionID = d.PrescriptionID,
                                PlanID = d.TreatmentPlanID,
                                Dosage = d.Dosage,
                                AddTime = d.DateOfCreate,
                                DelDate = d.DateOfDelete,
                                EditDate = d.DateOfEdit,
                                TimeTake = d.TimeOfTakeDispense,
                                Status = d.Status
                            };

                query = query.Where(x => x.DelDate == null); // Убираем удаленные

                foreach (var d in query)
                {
                    if (listDispensing.Find(x => x.ID == d.ID) == null) // условие предохранения от дубликатов
                    {
                        listDispensing.Add(new DispensingDrug
                        {
                            ID = d.ID,
                            NurseID = d.NurseID,
                            PrescriptionID = d.PrescriptionID,
                            TreatmentPlanID = d.PlanID,
                            Dosage = d.Dosage,
                            DateOfCreate = d.AddTime,
                            DateOfDelete = d.DelDate,
                            DateOfEdit = d.EditDate,
                            TimeOfTakeDispense = d.TimeTake,
                            Status = d.Status
                        });
                    }
                }
                return listDispensing;
            }
        }
    }
}
