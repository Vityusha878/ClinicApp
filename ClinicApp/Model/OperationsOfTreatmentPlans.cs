using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;

namespace ClinicApp
{
    public class OperationsOfTreatmentPlans
    {
        public static string Add(TreatmentPlan plan)
        {
            string answer = СheckField(plan);
            if (answer == "Данные корректны!")
            {
                using (Context db = new Context())
                {
                    plan.DateOfCreate = DateTime.Now;
                    db.TreatmentPlans.Add(plan);
                    db.SaveChanges();
                    answer = "Произошло добавление";
                }
                return answer;
            }
            return answer;
        }
        public static string Edit(TreatmentPlan plan)
        {
            string answer = СheckField(plan);
            if (answer == "Данные корректны")
            {
                using (Context db = new Context())
                {
                    plan.DateOfEdit = DateTime.Now;
                    db.Entry(plan).State = EntityState.Modified;
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
                var plan = db.TreatmentPlans
                    .Single(p => p.ID == ID);
                plan.DateOfDelete = DateTime.Now;
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "Произошло удаление";
        }
        public static TreatmentPlan FindByID(int ID)
        {
            using (Context db = new Context())
            {
                var plan = db.TreatmentPlans
                    .Single(p => p.ID == ID);
                return plan;
            }
        }
        public static string СheckField(TreatmentPlan plan)
        {
            if (plan.AssignerDoctorID == 0)
            {
                return "Выберите врача. Это поле не может быть пустым";
            }
            if (plan.PatientID == 0)
            {
                return "Выберите пациента. Это поле не может быть пустым";
            }            

            using (Context context = new Context())
            {
                TreatmentPlan p = new TreatmentPlan();
                p = context.TreatmentPlans.Where(x => x.AssignerDoctorID == plan.AssignerDoctorID && x.PatientID == plan.PatientID).FirstOrDefault<TreatmentPlan>();
                if (p != null)
                {
                    return "Такой план лечения уже существует в базе под номером " + p.ID;
                }
            }
            return "Данные корректны";
        }



        public static List<TreatmentPlan> FindAllPlan()
        {
            List<TreatmentPlan> listPlan = new List<TreatmentPlan>();

            using (Context db = new Context())
            {
                var query = from t in db.TreatmentPlans
                            select new
                            {
                                ID = t.ID,
                                AssignerDoctorID = t.AssignerDoctorID,
                                PatientID = t.PatientID,                     
                                AddTime = t.DateOfCreate,
                                DelDate = t.DateOfDelete,
                                EditDate = t.DateOfEdit,
                            };
               
                query = query.Where(x => x.DelDate == null); // Убираем удаленные
               
                foreach (var d in query)
                {                    
                    if (listPlan.Find(x => x.ID == d.ID) == null) // условие предохранения от дубликатов
                    {
                        listPlan.Add(new TreatmentPlan
                        {
                            ID = d.ID,
                            AssignerDoctorID = d.AssignerDoctorID,                           
                            PatientID = d.PatientID,                            
                            DateOfCreate = d.AddTime,
                            DateOfDelete = d.DelDate,
                            DateOfEdit = d.EditDate

                        });
                    }
                }
                return listPlan;
            }
        }
    }
}
