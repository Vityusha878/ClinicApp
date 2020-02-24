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
        public static void Add(DispensingDrug dispense)
        {
            using (Context db = new Context())
            {
                dispense.DateOfCreate = DateTime.Now;
                db.DispensingDrugs.Add(dispense);
                db.SaveChanges();
            }
        }

        public static void Edit(DispensingDrug dispense)
        {
            using (Context db = new Context())
            {
                dispense.DateOfEdit = DateTime.Now;
                db.Entry(dispense).State = EntityState.Modified;
                db.SaveChanges();                
            }

        }
        public static void Del(int ID)
        {
            using (Context db = new Context())
            {
                var dispense = db.DispensingDrugs
                    .Single(p => p.ID == ID);
                dispense.DateOfDelete = DateTime.Now;
                db.Entry(dispense).State = EntityState.Modified;
                db.SaveChanges();
            }            
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


        public static void HideDispensing_Nurse(int nurseID)
        {
            using (Context db = new Context())
            {
                var pres = db.DispensingDrugs.Where(p => p.NurseID == nurseID).ToList();

                foreach (var d in pres)
                {
                    d.DateOfDelete = DateTime.Now;
                    db.Entry(d).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public static void HideDispensing_Prescription(int presID)
        {
            using (Context db = new Context())
            {
                var dis = db.DispensingDrugs.Where(p => p.PrescriptionID== presID).ToList();

                foreach (var d in dis)
                {
                    d.DateOfDelete = DateTime.Now;
                    db.Entry(d).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // Грид всех событий выдачи лекарств на главной форме
        public static List<DispensingDrug> FindAllDispensing(DispensingDrug dis, bool checkCreate1, bool checkEdit1, bool checkTake1,
            bool checkCreate2, bool checkEdit2, bool checkTake2, DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime take1, DateTime take2,
            bool statusTrue, bool statusFalse, int pageNum, int recordsCount)

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

                if (dis.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == dis.ID);
                }


                if (statusTrue == true && statusFalse == true) // Поиск по статусу
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
                }
                else if (statusTrue == true && statusFalse == false)
                {
                    query = query.Where(x => x.Status == true);
                }
                else if (statusTrue == false && statusFalse == true)
                {
                    query = query.Where(x => x.Status == false);
                }
                else
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
                }


                if (checkCreate1 == true && checkCreate2== false) // Поиск по дате создания
                {
                    query = query.Where(x => x.AddTime >= create1);
                }
                if (checkCreate2 == true && checkCreate1== false)
                {
                    query = query.Where(x => x.AddTime <= create2);
                }
                if (checkCreate1 == true && checkCreate2== true)
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
                if (checkEdit1== true && checkEdit2== true)
                {
                    query = query.Where(x => x.EditDate >= edit1 && x.EditDate <= edit2);
                }


                if (checkTake1 == true && checkTake2== false) // Поиск по дате/времени принятия лекарства пациентом
                {
                    query = query.Where(x => x.TimeTake >= take1);
                }
                if (checkTake2 == true && checkTake1 == false)
                {
                    query = query.Where(x => x.TimeTake <= take2);
                }
                if (checkTake1 == true && checkTake2 == true)
                {
                    query = query.Where(x => x.TimeTake >= take1 && x.TimeTake <= take2);
                }

                query = query.OrderBy(x => x.ID);

                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

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

        // Перегруженный метод FindAllDispensing без параметров пагинации для подсчета максимального количества страниц на гриде главной формы
        public static List<DispensingDrug> FindAllDispensing(DispensingDrug dis, bool checkCreate1, bool checkEdit1, bool checkTake1,
            bool checkCreate2, bool checkEdit2, bool checkTake2, DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime take1, DateTime take2,
            bool statusTrue, bool statusFalse)

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

                if (dis.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == dis.ID);
                }


                if (statusTrue == true && statusFalse == true) // Поиск по статусу
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
                }
                else if (statusTrue == true && statusFalse == false)
                {
                    query = query.Where(x => x.Status == true);
                }
                else if (statusTrue == false && statusFalse == true)
                {
                    query = query.Where(x => x.Status == false);
                }
                else
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
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


                if (checkTake1 == true && checkTake2 == false) // Поиск по дате/времени принятия лекарства пациентом
                {
                    query = query.Where(x => x.TimeTake >= take1);
                }
                if (checkTake2 == true && checkTake1 == false)
                {
                    query = query.Where(x => x.TimeTake <= take2);
                }
                if (checkTake1 == true && checkTake2 == true)
                {
                    query = query.Where(x => x.TimeTake >= take1 && x.TimeTake <= take2);
                }


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

        // Все события выдачи лекарства ДАННОГО назначения лекарства
        public static List<DispensingDrug> FindAllDispensing_Prescription(PrescriptionOfDrug pres, int pageNum, int recordsCount)
        {
            List<DispensingDrug> list = new List<DispensingDrug>();

            using (Context db = new Context())
            {
                var dis = db.DispensingDrugs.Where(x => x.PrescriptionID == pres.ID && x.DateOfDelete == null)
                                            .OrderBy(x => x.ID).Skip((pageNum - 1) * recordsCount)
                                            .Take(recordsCount).ToList();
                list.AddRange(dis);
            }
            return list;
        }

        // Все выдачи лекарств, выписанные этим врачом
        public static List<DispensingDrug> Dispensing_Doctor(DispensingDrug dis, int docID, bool checkCreate1, bool checkEdit1, bool checkTake1,
            bool checkCreate2, bool checkEdit2, bool checkTake2, DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime take1, DateTime take2,
            bool statusTrue, bool statusFalse, int pageNum, int recordsCount)

        {
            List<DispensingDrug> listDispensing = new List<DispensingDrug>();

            using (Context db = new Context())
            {
                IQueryable<DispensingDrug> query = db.DispensingDrugs;
                List<DispensingDrug> p = new List<DispensingDrug>();
                foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                {
                    p.AddRange(db.DispensingDrugs.Where(x => x.TreatmentPlanID == d.ID && x.DateOfDelete == null));
                }
                query = p.AsQueryable();

                //query = query.Where(x => x.DelDate == null); // Убираем удаленные

                if (dis.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == dis.ID);
                }


                if (statusTrue == true && statusFalse == true) // Поиск по статусу
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
                }
                else if (statusTrue == true && statusFalse == false)
                {
                    query = query.Where(x => x.Status == true);
                }
                else if (statusTrue == false && statusFalse == true)
                {
                    query = query.Where(x => x.Status == false);
                }
                else
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
                }


                if (checkCreate1 == true && checkCreate2== false) // Поиск по дате создания
                {
                    query = query.Where(x => x.DateOfCreate >= create1);
                }
                if (checkCreate2 == true && checkCreate1== false)
                {
                    query = query.Where(x => x.DateOfCreate <= create2);
                }
                if (checkCreate1 == true && checkCreate2== true)
                {
                    query = query.Where(x => x.DateOfCreate >= create1 && x.DateOfCreate <= create2);
                }

                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.DateOfEdit >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.DateOfEdit <= edit2);
                }
                if (checkEdit1== true && checkEdit2== true)
                {
                    query = query.Where(x => x.DateOfEdit >= edit1 && x.DateOfEdit <= edit2);
                }


                if (checkTake1 == true && checkTake2== false) // Поиск по дате/времени принятия лекарства пациентом
                {
                    query = query.Where(x => x.TimeOfTakeDispense >= take1);
                }
                if (checkTake2 == true && checkTake1 == false)
                {
                    query = query.Where(x => x.TimeOfTakeDispense <= take2);
                }
                if (checkTake1 == true && checkTake2 == true)
                {
                    query = query.Where(x => x.TimeOfTakeDispense >= take1 && x.TimeOfTakeDispense <= take2);
                }

                query = query.OrderBy(x => x.ID);

                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                List<DispensingDrug> list = query.ToList();

                return list;
            }
        }

        // Перегруженный метод Dispensing_Doctor без параметров пагинации для подсчета максимального количества страниц на гриде главной формы
        public static List<DispensingDrug> Dispensing_Doctor(DispensingDrug dis, int docID, bool checkCreate1, bool checkEdit1, bool checkTake1,
            bool checkCreate2, bool checkEdit2, bool checkTake2, DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime take1, DateTime take2,
            bool statusTrue, bool statusFalse)

        {
            List<DispensingDrug> listDispensing = new List<DispensingDrug>();

            using (Context db = new Context())
            {
                IQueryable<DispensingDrug> query = db.DispensingDrugs;
                List<DispensingDrug> p = new List<DispensingDrug>();
                foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                {
                    p.AddRange(db.DispensingDrugs.Where(x => x.TreatmentPlanID == d.ID && x.DateOfDelete == null));
                }
                query = p.AsQueryable();

                //query = query.Where(x => x.DelDate == null); // Убираем удаленные

                if (dis.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == dis.ID);
                }


                if (statusTrue == true && statusFalse == true) // Поиск по статусу
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
                }
                else if (statusTrue == true && statusFalse == false)
                {
                    query = query.Where(x => x.Status == true);
                }
                else if (statusTrue == false && statusFalse == true)
                {
                    query = query.Where(x => x.Status == false);
                }
                else
                {
                    query = query.Where(x => x.Status == true || x.Status == false);
                }


                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    query = query.Where(x => x.DateOfCreate >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    query = query.Where(x => x.DateOfCreate <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    query = query.Where(x => x.DateOfCreate >= create1 && x.DateOfCreate <= create2);
                }

                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.DateOfEdit >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.DateOfEdit <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    query = query.Where(x => x.DateOfEdit >= edit1 && x.DateOfEdit <= edit2);
                }


                if (checkTake1 == true && checkTake2 == false) // Поиск по дате/времени принятия лекарства пациентом
                {
                    query = query.Where(x => x.TimeOfTakeDispense >= take1);
                }
                if (checkTake2 == true && checkTake1 == false)
                {
                    query = query.Where(x => x.TimeOfTakeDispense <= take2);
                }
                if (checkTake1 == true && checkTake2 == true)
                {
                    query = query.Where(x => x.TimeOfTakeDispense >= take1 && x.TimeOfTakeDispense <= take2);
                }                

                List<DispensingDrug> list = query.ToList();

                return list;
            }
        }
    }
}
