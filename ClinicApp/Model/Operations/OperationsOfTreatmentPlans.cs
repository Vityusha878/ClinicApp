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
        public static void Add(TreatmentPlan plan)
        {
            using (Context db = new Context())
            {
                plan.DateOfCreate = DateTime.Now;
                db.TreatmentPlans.Add(plan);
                db.SaveChanges();
            }
        }
        public static void Edit(TreatmentPlan plan)
        {
            using (Context db = new Context())
            {
                plan.DateOfEdit = DateTime.Now;
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();

            }
        }
        public static void Del(int ID)
        {
            using (Context db = new Context())
            {
                var plan = db.TreatmentPlans
                    .Single(p => p.ID == ID);
                plan.DateOfDelete = DateTime.Now;
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
            }
            OperationsOfPrescriptionsOfDrugs.HidePrescription_Plan(ID);
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

        public static void HidePlan(int personID)
        {
            using (Context db = new Context())
            {
                if (OperationsOfPersons.FindByID(personID).Role == 2) // 2 = врач
                {
                    var plans = db.TreatmentPlans.Where(p => p.AssignerDoctorID == personID).ToList();

                    foreach (var p in plans)
                    {
                        p.DateOfDelete = DateTime.Now;
                        db.Entry(p).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                if (OperationsOfPersons.FindByID(personID).Role == 7) // 7 = пациент
                {
                    var plans = db.TreatmentPlans.Where(p => p.PatientID == personID).ToList();

                    foreach (var p in plans)
                    {
                        p.DateOfDelete = DateTime.Now;
                        db.Entry(p).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }



        public static List<TreatmentPlan> FindAllPlan(TreatmentPlan plan, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2, int pageNum, int recordsCount)
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

                if (plan.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == plan.ID);
                }

                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    query = query.Where(x => x.AddTime >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    query = query.Where(x => x.AddTime <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    query = query.Where(x => x.AddTime >= create1 && x.AddTime <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.EditDate >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.EditDate <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    query = query.Where(x => x.EditDate >= edit1 && x.EditDate <= edit2);
                }

                query = query.OrderBy(x => x.ID);

                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

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

        public static List<TreatmentPlan> FindAllPlan(TreatmentPlan plan, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2)
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

                if (plan.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == plan.ID);
                }

                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    query = query.Where(x => x.AddTime >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    query = query.Where(x => x.AddTime <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    query = query.Where(x => x.AddTime >= create1 && x.AddTime <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.EditDate >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.EditDate <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    query = query.Where(x => x.EditDate >= edit1 && x.EditDate <= edit2);
                }

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

        public static List<TreatmentPlan> Plans_Doctor(TreatmentPlan plan, int docID, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2)
        {
            using (Context db = new Context())
            {
                IEnumerable<TreatmentPlan> plansIQuer = db.TreatmentPlans.Where(x => x.DateOfDelete == null);
                
                var plans = plansIQuer.Where(x => x.AssignerDoctorID == docID);

                if (plan.ID != 0) // Поиск по ID
                {
                    plans = plans.Where(x => x.ID == plan.ID);
                }

                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    plans = plans.Where(x => x.DateOfCreate >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    plans = plans.Where(x => x.DateOfCreate <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    plans = plans.Where(x => x.DateOfCreate >= create1 && x.DateOfCreate <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    plans = plans.Where(x => x.DateOfEdit >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    plans = plans.Where(x => x.DateOfEdit <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    plans = plans.Where(x => x.DateOfEdit >= edit1 && x.DateOfEdit <= edit2);
                }



                //plans = plans.ToList().Cast<TreatmentPlan>;
                List<TreatmentPlan> p = plans.ToList();
                return p;
            }
        }


        public static List<TreatmentPlan> Plans_Doctor(TreatmentPlan plan, int docID, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2, int pageNum, int recordsCount)
        {
            using (Context db = new Context())
            {
                IEnumerable<TreatmentPlan> plansIQuer = db.TreatmentPlans.Where(x => x.DateOfDelete == null);

                var plans = plansIQuer.Where(x => x.AssignerDoctorID == docID);

                if (plan.ID != 0) // Поиск по ID
                {
                    plans = plans.Where(x => x.ID == plan.ID);
                }

                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    plans = plans.Where(x => x.DateOfCreate >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    plans = plans.Where(x => x.DateOfCreate <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    plans = plans.Where(x => x.DateOfCreate >= create1 && x.DateOfCreate <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    plans = plans.Where(x => x.DateOfEdit >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    plans = plans.Where(x => x.DateOfEdit <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    plans = plans.Where(x => x.DateOfEdit >= edit1 && x.DateOfEdit <= edit2);
                }

                plans = plans.OrderBy(x => x.ID);

                plans = plans.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                //plans = plans.ToList().Cast<TreatmentPlan>;
                List<TreatmentPlan> p = plans.ToList();
                return p;
            }
        }
    }
}
