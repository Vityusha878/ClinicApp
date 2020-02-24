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
        public static void Add(PrescriptionOfDrug prescription)
        {
            using (Context db = new Context())
            {
                prescription.DateOfCreate = DateTime.Now;
                db.PrescriptionsOfDrugs.Add(prescription);
                db.SaveChanges();
            }
        }
        public static void Edit(PrescriptionOfDrug prescription)
        {
            using (Context db = new Context())
            {
                prescription.DateOfEdit = DateTime.Now;
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void Del(int ID)
        {
            using (Context db = new Context())
            {
                var prescription = db.PrescriptionsOfDrugs
                    .Single(p => p.ID == ID);
                prescription.DateOfDelete = DateTime.Now;
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
            }
            OperationsOfDispensingDrugs.HideDispensing_Prescription(ID);
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

        public static void HidePrescription_Plan(int planID)
        {
            using (Context db = new Context())
            {
                var pres = db.PrescriptionsOfDrugs.Where(p => p.PlanID == planID).ToList();

                foreach (var p in pres)
                {
                    p.DateOfDelete = DateTime.Now;
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public static void HidePrescription_Drug(int drugID)
        {
            using (Context db = new Context())
            {
                var pres = db.PrescriptionsOfDrugs.Where(p => p.DrugID == drugID).ToList();

                foreach (var p in pres)
                {
                    p.DateOfDelete = DateTime.Now;
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // Перегруженный метод FindAllPrescription без параметров пагинации для поиска максимального числа страниц на гриде главной формы
        public static List<PrescriptionOfDrug> FindAllPrescription(PrescriptionOfDrug pres, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            bool checkStartTake1, bool checkStartTake2, bool checkFinishTake1, bool checkFinishTake2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime startTake1, DateTime startTake2, DateTime finishTake1, DateTime finishTake2)

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

                if (pres.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == pres.ID);
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

                if (checkStartTake1 == true && checkStartTake2 == false) // Поиск по дате начала приема лекарства
                {
                    query = query.Where(x => x.StartTime >= startTake1);
                }
                if (checkStartTake2 == true && checkStartTake1 == false)
                {
                    query = query.Where(x => x.StartTime <= startTake2);
                }
                if (checkStartTake1 == true && checkStartTake2 == true)
                {
                    query = query.Where(x => x.StartTime >= startTake1 && x.StartTime <= startTake2);
                }


                if (checkFinishTake1 == true && checkFinishTake2 == false) // Поиск по дате конца приема лекарства
                {
                    query = query.Where(x => x.FinishTime >= finishTake1);
                }
                if (checkFinishTake2 == true && checkFinishTake1 == false)
                {
                    query = query.Where(x => x.FinishTime <= finishTake2);
                }
                if (checkFinishTake1 == true && checkFinishTake2 == true)
                {
                    query = query.Where(x => x.FinishTime >= finishTake1 && x.FinishTime <= finishTake2);
                }


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

        public static List<PrescriptionOfDrug> FindAllPrescription(PrescriptionOfDrug pres, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            bool checkStartTake1, bool checkStartTake2, bool checkFinishTake1, bool checkFinishTake2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime startTake1, DateTime startTake2, DateTime finishTake1, DateTime finishTake2, int pageNum, int recordsCount)

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

                if (pres.ID != 0) // Поиск по ID
                {
                    query = query.Where(x => x.ID == pres.ID);
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

                if (checkStartTake1 == true && checkStartTake2 == false) // Поиск по дате начала приема лекарства
                {
                    query = query.Where(x => x.StartTime >= startTake1);
                }
                if (checkStartTake2 == true && checkStartTake1 == false)
                {
                    query = query.Where(x => x.StartTime <= startTake2);
                }
                if (checkStartTake1 == true && checkStartTake2 == true)
                {
                    query = query.Where(x => x.StartTime >= startTake1 && x.StartTime <= startTake2);
                }


                if (checkFinishTake1 == true && checkFinishTake2 == false) // Поиск по дате конца приема лекарства
                {
                    query = query.Where(x => x.FinishTime >= finishTake1);
                }
                if (checkFinishTake2 == true && checkFinishTake1 == false)
                {
                    query = query.Where(x => x.FinishTime <= finishTake2);
                }
                if (checkFinishTake1 == true && checkFinishTake2 == true)
                {
                    query = query.Where(x => x.FinishTime >= finishTake1 && x.FinishTime <= finishTake2);
                }

                query = query.OrderBy(x => x.ID);

                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

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

        public static List<PrescriptionOfDrug> FindAllPrescription_Plan(TreatmentPlan plan, int pageNum, int recordsCount)
        {
            List<PrescriptionOfDrug> listPrescription = new List<PrescriptionOfDrug>();

            using (Context db = new Context())
            {
                var pres = db.PrescriptionsOfDrugs.Where(x => x.PlanID == plan.ID && x.DateOfDelete == null);

                // Сортировка по id, без OrderBy не работает Skip
                pres = pres.OrderBy(x => x.ID);
                // Отбираем нужное количество записей
                pres = pres.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                listPrescription.AddRange(pres);
            }
            return listPrescription;
        }

        public static List<PrescriptionOfDrug> Pres_Doctor(PrescriptionOfDrug pres, int docID, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            bool checkStartTake1, bool checkStartTake2, bool checkFinishTake1, bool checkFinishTake2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime startTake1, DateTime startTake2, DateTime finishTake1, DateTime finishTake2, int pageNum, int recordsCount)
        {
            using (Context db = new Context())
            {
                //IEnumerable<PrescriptionOfDrug> pr = db.PrescriptionsOfDrugs;
                //IQueryable<PrescriptionOfDrug> presIQuer = db.PrescriptionsOfDrugs;
                //var pr = db.PrescriptionsOfDrugs.AsQueryable();
                //foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                //{
                //    pr = pr.Where(x => x.PlanID == d.ID);
                //}

                //var d = db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID);
                //foreach (var p in d.Where(x => x.ID == docID))
                //{
                //    var pr = presIQuer.Where(x => x.PlanID == d.ID);
                //}
                //var pr = from p in db.PrescriptionsOfDrugs
                //         join pp in db.TreatmentPlans
                //         on p.PlanID equals pp.ID
                //         into pp_temp
                //         from plan in pp_temp.DefaultIfEmpty()
                //         join doc in db.People
                //         on plan.AssignerDoctorID equals doc.ID
                //         into doc_temp
                //         from dd in doc_temp.DefaultIfEmpty()
                //         select new
                //         {
                //             ID = p.ID,
                //             DrugID = p.DrugID,
                //             PlanID = p.PlanID,
                //             Quantity = p.Quantity,
                //             AddTime = p.DateOfCreate,
                //             DelDate = p.DateOfDelete,
                //             EditDate = p.DateOfEdit,
                //             StartTime = p.StartTimeOfTaken,
                //             FinishTime = p.FinishTimeOfTaken,

                //             DocID = dd.ID
                //         };

                IQueryable<PrescriptionOfDrug> pr = db.PrescriptionsOfDrugs;
                List<PrescriptionOfDrug> p = new List<PrescriptionOfDrug>();
                foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                {
                    p.AddRange(db.PrescriptionsOfDrugs.Where(x => x.PlanID == d.ID));
                }
                pr = p.AsQueryable();

                pr = pr.Where(x => x.DateOfDelete == null);

                if (pres.ID != 0) // Поиск по ID
                {
                    pr = pr.Where(x => x.ID == pres.ID);
                }

                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    pr = pr.Where(x => x.DateOfCreate >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    pr = pr.Where(x => x.DateOfCreate <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    pr = pr.Where(x => x.DateOfCreate >= create1 && x.DateOfCreate <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    pr = pr.Where(x => x.DateOfEdit >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    pr = pr.Where(x => x.DateOfEdit <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    pr = pr.Where(x => x.DateOfEdit >= edit1 && x.DateOfEdit <= edit2);
                }

                if (checkStartTake1 == true && checkStartTake2 == false) // Поиск по дате начала приема лекарства
                {
                    pr = pr.Where(x => x.StartTimeOfTaken >= startTake1);
                }
                if (checkStartTake2 == true && checkStartTake1 == false)
                {
                    pr = pr.Where(x => x.StartTimeOfTaken <= startTake2);
                }
                if (checkStartTake1 == true && checkStartTake2 == true)
                {
                    pr = pr.Where(x => x.StartTimeOfTaken >= startTake1 && x.StartTimeOfTaken <= startTake2);
                }


                if (checkFinishTake1 == true && checkFinishTake2 == false) // Поиск по дате конца приема лекарства
                {
                    pr = pr.Where(x => x.FinishTimeOfTaken >= finishTake1);
                }
                if (checkFinishTake2 == true && checkFinishTake1 == false)
                {
                    pr = pr.Where(x => x.FinishTimeOfTaken <= finishTake2);
                }
                if (checkFinishTake1 == true && checkFinishTake2 == true)
                {
                    pr = pr.Where(x => x.FinishTimeOfTaken >= finishTake1 && x.FinishTimeOfTaken <= finishTake2);
                }

                pr = pr.OrderBy(x => x.ID);

                pr = pr.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                List<PrescriptionOfDrug> list = pr.ToList();

                return list;

                //List<PrescriptionOfDrug> list = new List<PrescriptionOfDrug>();

                //foreach (var d in pr)
                //{
                //    if (list.Find(x => x.ID == d.ID) == null) // условие предохранения от дубликатов
                //    {
                //        list.Add(new PrescriptionOfDrug
                //        {
                //            ID = d.ID,
                //            DrugID = d.DrugID,
                //            PlanID = d.PlanID,
                //            Quantity = d.Quantity,
                //            DateOfCreate = d.AddTime,
                //            DateOfDelete = d.DelDate,
                //            DateOfEdit = d.EditDate,
                //            StartTimeOfTaken = d.StartTime,
                //            FinishTimeOfTaken = d.FinishTime
                //        });
                //    }
                //}

                //return list;
            }
        }

        public static List<PrescriptionOfDrug> Pres_Doctor(PrescriptionOfDrug pres, int docID, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            bool checkStartTake1, bool checkStartTake2, bool checkFinishTake1, bool checkFinishTake2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            DateTime startTake1, DateTime startTake2, DateTime finishTake1, DateTime finishTake2)
        {
            using (Context db = new Context())
            {
                //IEnumerable<PrescriptionOfDrug> pr = db.PrescriptionsOfDrugs;
                //var t = db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID).ToList();
                //var p = db.PrescriptionsOfDrugs.Where(x => x.PlanID == t.)
                //IEnumerable<PrescriptionOfDrug> presIQuer = db.PrescriptionsOfDrugs.Where(x => x.DateOfDelete == null);
                //IEnumerable<PrescriptionOfDrug> pr = db.PrescriptionsOfDrugs;
                //foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                //{
                //    pr = pr.Where(x => x.PlanID == d.ID)
                //           .Where(x => x.DateOfDelete == null);
                //}

                //var pr = db.PrescriptionsOfDrugs.AsQueryable();
                //foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                //{
                //    pr = pr.Where(x => x.PlanID == d.ID);
                //}

                //List<PrescriptionOfDrug> pr = new List<PrescriptionOfDrug>();
                //foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                //{
                //    pr.AddRange(db.PrescriptionsOfDrugs.Where(x => x.PlanID == d.ID));
                //}

                //pr = pr.AsQueryable();

                IQueryable<PrescriptionOfDrug> pr = db.PrescriptionsOfDrugs;
                List<PrescriptionOfDrug> p = new List<PrescriptionOfDrug>();
                foreach (var d in db.TreatmentPlans.Where(x => x.AssignerDoctorID == docID))
                {
                    p.AddRange(db.PrescriptionsOfDrugs.Where(x => x.PlanID == d.ID));
                }
                pr = p.AsQueryable();

                pr = pr.Where(x => x.DateOfDelete == null);

                if (pres.ID != 0) // Поиск по ID
                {
                    pr = pr.Where(x => x.ID == pres.ID);
                }

                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    pr = pr.Where(x => x.DateOfCreate >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    pr = pr.Where(x => x.DateOfCreate <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    pr = pr.Where(x => x.DateOfCreate >= create1 && x.DateOfCreate <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    pr = pr.Where(x => x.DateOfEdit >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    pr = pr.Where(x => x.DateOfEdit <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    pr = pr.Where(x => x.DateOfEdit >= edit1 && x.DateOfEdit <= edit2);
                }

                if (checkStartTake1 == true && checkStartTake2 == false) // Поиск по дате начала приема лекарства
                {
                    pr = pr.Where(x => x.StartTimeOfTaken >= startTake1);
                }
                if (checkStartTake2 == true && checkStartTake1 == false)
                {
                    pr = pr.Where(x => x.StartTimeOfTaken <= startTake2);
                }
                if (checkStartTake1 == true && checkStartTake2 == true)
                {
                    pr = pr.Where(x => x.StartTimeOfTaken >= startTake1 && x.StartTimeOfTaken <= startTake2);
                }


                if (checkFinishTake1 == true && checkFinishTake2 == false) // Поиск по дате конца приема лекарства
                {
                    pr = pr.Where(x => x.FinishTimeOfTaken >= finishTake1);
                }
                if (checkFinishTake2 == true && checkFinishTake1 == false)
                {
                    pr = pr.Where(x => x.FinishTimeOfTaken <= finishTake2);
                }
                if (checkFinishTake1 == true && checkFinishTake2 == true)
                {
                    pr = pr.Where(x => x.FinishTimeOfTaken >= finishTake1 && x.FinishTimeOfTaken <= finishTake2);
                }

                List<PrescriptionOfDrug> list = pr.ToList();

                return list;
            }
        }
    }
}
