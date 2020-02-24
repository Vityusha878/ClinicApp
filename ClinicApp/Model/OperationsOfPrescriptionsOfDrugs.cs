using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClinicApp
{
    public class OperationsOfPrescriptionsOfDrugs
    {
        public static string Add(PrescriptionOfDrug prescription)
        {
            string answer = СheckField(prescription);
            if (answer == "Данные корректны!")
            {
                using (Context db = new Context())
                {
                    prescription.DateOfCreate = DateTime.Now;
                    db.PrescriptionsOfDrugs.Add(prescription);
                    db.SaveChanges();
                    answer = "Произошло добавление";
                }
                return answer;
            }
            return answer;
        }
        public static string Edit(PrescriptionOfDrug prescription)
        {
            string answer = СheckField(prescription);
            if (answer == "Данные корректны")
            {
                using (Context db = new Context())
                {
                    prescription.DateOfEdit = DateTime.Now;
                    db.Entry(prescription).State = EntityState.Modified;
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
                var prescription = db.PrescriptionsOfDrugs
                    .Single(p => p.ID == ID);
                prescription.DateOfDelete = DateTime.Now;
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "Произошло удаление";
        }
        public static PrescriptionOfDrug FindByID(int ID)
        {
            using (Context db = new Context())
            {
                var prescription = db.PrescriptionsOfDrugs
                    .Single(p => p.ID == ID);
                return prescription;
            }
        }
        public static string СheckField(PrescriptionOfDrug prescription)
        {
            if (prescription.DrugID == 0)
            {
                return "Выберите лекарство. Это поле не может быть пустым";
            }
            if (prescription.PlanID == 0) //?? нужно ли, id плана должен ставиться автоматически под тот план к которому прикреплены назначения
            {
                return "Выберите план лечения. Это поле не может быть пустым";
            }
            if (prescription.Quantity == 0)
            {
                return "Выберите количество лекарства. Это поле не может быть пустым";
            }            

            using (Context context = new Context())
            {
                PrescriptionOfDrug p = new PrescriptionOfDrug();
                p = context.PrescriptionsOfDrugs.Where(x => x.DrugID == prescription.DrugID && x.PlanID == prescription.PlanID && x.Quantity == prescription.Quantity).FirstOrDefault<PrescriptionOfDrug>();
                if (p != null)
                {
                    return "Такое назначение лекарства уже существует в базе под номером " + p.ID;
                }
            }
            return "Данные корректны";
        }




        public static List<PrescriptionOfDrug> FindAllPrescription()
            
        {
            List<PrescriptionOfDrug> listPrescription = new List<PrescriptionOfDrug>();

            using (Context db = new Context())
            {
                var query = from p in db.PrescriptionsOfDrugs
                            select new
                            {
                                ID = p.ID,
                                DrugID = p.DrugID,
                                PlanID = p.PlanID,
                                Quantity = p.Quantity,
                                AddTime = p.DateOfCreate,
                                DelDate = p.DateOfDelete,
                                EditDate = p.DateOfEdit,
                                StartTime = p.StartTimeOfTaken,
                                FinishTime = p.FinishTimeOfTaken
                            };

                query = query.Where(x => x.DelDate == null); // Убираем удаленные

                foreach (var d in query)
                {
                    if (listPrescription.Find(x => x.ID == d.ID) == null) // условие предохранения от дубликатов
                    {
                        listPrescription.Add(new PrescriptionOfDrug
                        {
                            ID = d.ID,
                            DrugID = d.DrugID,
                            PlanID = d.PlanID,
                            Quantity = d.Quantity,
                            DateOfCreate = d.AddTime,
                            DateOfDelete = d.DelDate,
                            DateOfEdit = d.EditDate,
                            StartTimeOfTaken = d.StartTime,
                            FinishTimeOfTaken = d.FinishTime
                        });
                    }
                }
                return listPrescription;
            }
        }
    }
}
