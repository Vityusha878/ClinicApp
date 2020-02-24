using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;

namespace ClinicApp
{
    public class OperationsOfDrugs
    {
        public static void Add(Drug drug)
        {
            using (Context db = new Context())
            {
                drug.DateOfCreate = DateTime.Now;
                db.Drugs.Add(drug);
                db.SaveChanges();
            }
        }
        public static void Edit(Drug drug)
        {
            using (Context db = new Context())
            {
                drug.DateOfEdit = DateTime.Now;
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void Del(int ID)
        {
            using (Context db = new Context())
            {
                var drug = db.Drugs
                    .Single(p => p.ID == ID);
                drug.DateOfDelete = DateTime.Now;
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
            }
            OperationsOfPrescriptionsOfDrugs.HidePrescription_Drug(ID);
        }
        public static Drug FindByID(int ID)
        {
            using (Context db = new Context())
            {
                var drug = db.Drugs
                    .Single(p => p.ID == ID);
                return drug;
            }
        }

        /////////////////////////////ГРИД НА ГЛАВНОЙ ФОРМЕ\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public static List<Drug> FindAllDrug(Drug drug, bool checkCreate1, bool checkEdit1, bool checkQuantity1, bool checkCreate2, bool checkEdit2, bool checkQuantity2,
            decimal quantity1, decimal quantity2, DateTime create1, DateTime create2, DateTime edit1, DateTime edit2, int pageNum, int recordsCount)
        {
            List<Drug> listDrug = new List<Drug>();

            using (Context db = new Context())
            {
                var query = from d in db.Drugs
                            select new
                            {
                                ID = d.ID,                                
                                Name = d.Name,
                                Measure = d.Measure,
                                Quantity = d.Quantity,
                                AddTime = d.DateOfCreate,
                                DelDate = d.DateOfDelete,
                                EditDate = d.DateOfEdit,
                            };

                query = query.Where(x => x.DelDate == null); // Убираем удаленные               

                if (drug.Name != null) // Поиск по названию
                {
                    query = query.Where(x => x.Name == drug.Name);
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


                if (checkQuantity1 == true && checkQuantity2 == false) // Поиск по количеству лекарства(в диапазоне)
                {
                    query = query.Where(x => x.Quantity >= quantity1);
                }
                if (checkQuantity2 == true && checkQuantity1== false)
                {
                    query = query.Where(x => x.Quantity <= quantity2);
                }
                if (checkQuantity1 == true && checkQuantity2== true)
                {
                    query = query.Where(x => x.Quantity >= quantity1 && x.Quantity <= quantity2);
                }

                query = query.OrderBy(x => x.ID);

                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                foreach (var d in query)
                {
                    if (listDrug.Find(x => x.ID == d.ID) == null) // условие предохранения от дубликатов
                    {
                        listDrug.Add(new Drug
                        {
                            ID = d.ID,                            
                            Name = d.Name,
                            Quantity = d.Quantity,
                            Measure = d.Measure,
                            DateOfCreate = d.AddTime,
                            DateOfDelete = d.DelDate,
                            DateOfEdit = d.EditDate

                        }); // добавление лекарства в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
                return listDrug;
            }
        }

        // Перегруженный метод FindAllDrug без параметров пагинации для подсчета максимального числа страниц на гриде в главной форме
        public static List<Drug> FindAllDrug(Drug drug, bool checkCreate1, bool checkEdit1, bool checkQuantity1, bool checkCreate2, bool checkEdit2, bool checkQuantity2,
            decimal quantity1, decimal quantity2, DateTime create1, DateTime create2, DateTime edit1, DateTime edit2)
        {
            List<Drug> listDrug = new List<Drug>();

            using (Context db = new Context())
            {
                var query = from d in db.Drugs
                            select new
                            {
                                ID = d.ID,                                
                                Name = d.Name,
                                Measure = d.Measure,
                                Quantity = d.Quantity,
                                AddTime = d.DateOfCreate,
                                DelDate = d.DateOfDelete,
                                EditDate = d.DateOfEdit,
                            };

                query = query.Where(x => x.DelDate == null); // Убираем удаленные               

                if (drug.Name != null) // Поиск по названию
                {
                    query = query.Where(x => x.Name == drug.Name);
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


                if (checkQuantity1 == true && checkQuantity2 == false) // Поиск по количеству лекарства(в диапазоне)
                {
                    query = query.Where(x => x.Quantity >= quantity1);
                }
                if (checkQuantity2 == true && checkQuantity1 == false)
                {
                    query = query.Where(x => x.Quantity <= quantity2);
                }
                if (checkQuantity1 == true && checkQuantity2 == true)
                {
                    query = query.Where(x => x.Quantity >= quantity1 && x.Quantity <= quantity2);
                }

                foreach (var d in query)
                {
                    if (listDrug.Find(x => x.ID == d.ID) == null) // условие предохранения от дубликатов
                    {
                        listDrug.Add(new Drug
                        {
                            ID = d.ID,                            
                            Name = d.Name,
                            Quantity = d.Quantity,
                            Measure = d.Measure,
                            DateOfCreate = d.AddTime,
                            DateOfDelete = d.DelDate,
                            DateOfEdit = d.EditDate

                        }); // добавление лекарства в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
                return listDrug;
            }
        }

        ///////////////////////////////МОСТЫ ЛЕКАРСТВА\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public static List<Person> Drug_Patient(Drug drug, int pageNum, int recordsCount)
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from pat in db.People
                            join pl in db.TreatmentPlans
                            on pat.ID equals pl.PatientID
                            into pl_temp
                            from plan in pl_temp.DefaultIfEmpty()
                            join pres in db.PrescriptionsOfDrugs
                            on plan.ID equals pres.PlanID
                            into pres_temp
                            from prs in pres_temp.DefaultIfEmpty()
                            join dr in db.Drugs
                            on prs.DrugID equals dr.ID
                            into dr_temp
                            from drg in dr_temp.DefaultIfEmpty()


                            select new
                            {
                                ID = pat.ID,
                                Phone = pat.Phone,
                                Name = pat.Name,
                                Surname = pat.Surname,
                                Patronymic = pat.Patronymic,
                                DateOfCreate = pat.DateOfCreate,
                                DateOfDelete = pat.DateOfDelete,
                                DateOfEdit = pat.DateOfEdit,

                                Drug = drg.ID
                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Drug == drug.ID);

                // Сортировка по id, без OrderBy не работает Skip
                query = query.OrderBy(x => x.ID);
                // Отбираем нужное количество записей
                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                foreach (var e in query)
                {
                    if (list.Find(x => x.ID == e.ID) == null)
                    {
                        list.Add(new Person
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Surname = e.Surname,
                            Patronymic = e.Patronymic,
                            Phone = e.Phone,
                            DateOfCreate = e.DateOfCreate,
                            DateOfEdit = e.DateOfEdit,
                            DateOfDelete = e.DateOfDelete

                        }); // добавление врача в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return list;
        }

        public static List<Person> Drug_Doctor(Drug drug, int pageNum, int recordsCount)
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from doc in db.People
                            join pl in db.TreatmentPlans
                            on doc.ID equals pl.AssignerDoctorID
                            into pl_temp
                            from plan in pl_temp.DefaultIfEmpty()
                            join prs in db.PrescriptionsOfDrugs
                            on plan.ID equals prs.PlanID
                            into prs_temp
                            from pres in prs_temp.DefaultIfEmpty()
                            join dr in db.Drugs
                            on pres.DrugID equals dr.ID
                            into dr_temp
                            from drg in dr_temp.DefaultIfEmpty()


                            select new
                            {
                                ID = doc.ID,
                                Phone = doc.Phone,
                                Name = doc.Name,
                                Surname = doc.Surname,
                                Patronymic = doc.Patronymic,
                                Role = doc.Role,
                                DateOfCreate = doc.DateOfCreate,
                                DateOfDelete = doc.DateOfDelete,
                                DateOfEdit = doc.DateOfEdit,

                                Drug = drg.ID
                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Drug == drug.ID);

                // Сортировка по id, без OrderBy не работает Skip
                query = query.OrderBy(x => x.ID);
                // Отбираем нужное количество записей
                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                foreach (var e in query)
                {
                    if (list.Find(x => x.ID == e.ID) == null)
                    {
                        list.Add(new Person
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Surname = e.Surname,
                            Patronymic = e.Patronymic,
                            Phone = e.Phone,
                            Role = e.Role,
                            DateOfCreate = e.DateOfCreate,
                            DateOfEdit = e.DateOfEdit,
                            DateOfDelete = e.DateOfDelete

                        }); // добавление врача в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return list;
        }



        public static List<Person> Drug_Nurse(Drug drug, int pageNum, int recordsCount)
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from nurse in db.People
                            join dis in db.DispensingDrugs
                            on nurse.ID equals dis.NurseID
                            into dis_temp
                            from disp in dis_temp.DefaultIfEmpty()
                            join prs in db.PrescriptionsOfDrugs
                            on disp.PrescriptionID equals prs.ID
                            into prs_temp
                            from pres in prs_temp.DefaultIfEmpty()
                            join dr in db.Drugs
                            on pres.DrugID equals dr.ID
                            into dr_temp
                            from drg in dr_temp.DefaultIfEmpty()


                            select new
                            {
                                ID = nurse.ID,
                                Phone = nurse.Phone,
                                Name = nurse.Name,
                                Surname = nurse.Surname,
                                Patronymic = nurse.Patronymic,
                                Role = nurse.Role,
                                DateOfCreate = nurse.DateOfCreate,
                                DateOfDelete = nurse.DateOfDelete,
                                DateOfEdit = nurse.DateOfEdit,

                                Drug = drg.ID
                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Drug == drug.ID);

                // Сортировка по id, без OrderBy не работает Skip
                query = query.OrderBy(x => x.ID);
                // Отбираем нужное количество записей
                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                foreach (var e in query)
                {
                    if (list.Find(x => x.ID == e.ID) == null)
                    {
                        list.Add(new Person
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Surname = e.Surname,
                            Patronymic = e.Patronymic,
                            Phone = e.Phone,
                            Role = e.Role,
                            DateOfCreate = e.DateOfCreate,
                            DateOfEdit = e.DateOfEdit,
                            DateOfDelete = e.DateOfDelete

                        }); // добавление врача в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return list;
        }

        //////////////////////ГРИД С ВЫБОРОМ\\\\\\\\\\\\\\\\\\\\\\\\
        public static List<Drug> ChoiceGrid_Drug()
        {
            List<Drug> list = new List<Drug>();

            using (Context db = new Context())
            {
                var query = from drug in db.Drugs
                            
                            select new
                            {
                                ID = drug.ID,
                                Name = drug.Name,
                                Quantity = drug.Quantity,
                                Measure = drug.Measure,
                                DateOfCreate = drug.DateOfCreate,
                                DateOfDelete = drug.DateOfDelete,
                                DateOfEdit = drug.DateOfEdit,                              

                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных               

                foreach (var e in query)
                {
                    if (list.Find(x => x.ID == e.ID) == null)
                    {
                        list.Add(new Drug
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Quantity = e.Quantity,
                            Measure = e.Measure,
                            DateOfCreate = e.DateOfCreate,
                            DateOfEdit = e.DateOfEdit,
                            DateOfDelete = e.DateOfDelete

                        }); // добавление лекарства в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return list;
        }
    }
}

