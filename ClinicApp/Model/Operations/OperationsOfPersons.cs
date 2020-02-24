using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;

namespace ClinicApp
{

    public class OperationsOfPersons
    {
        public static void Add(Person person)
        {
            using (Context db = new Context())
            {
                person.DateOfCreate = DateTime.Now;
                db.People.Add(person);
                db.SaveChanges();
            }
        }
        public static void Edit(Person person)
        {
            using (Context db = new Context())
            {
                person.DateOfEdit = DateTime.Now;
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void Del(int ID)
        {
            using (Context db = new Context())
            {
                var person = db.People
                    .Single(p => p.ID == ID);
                person.DateOfDelete = DateTime.Now;
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
            }
            OperationsOfTreatmentPlans.HidePlan(ID);
            OperationsOfDispensingDrugs.HideDispensing_Nurse(ID);
        }
        public static Person FindByID(int ID)
        {
            using (Context db = new Context())
            {
                var person = db.People
                    .Single(p => p.ID == ID);
                return person;
            }
        }


        ///////////////////////////ГРИДЫ НА ГЛАВНОЙ ФОРМЕ\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public static List<Person> FindAllEmployee(bool doct, bool nurs,
            Person person, Person patient, Drug drug, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2,
            int pageNum, int recordsCount)
        {
            List<Person> employeeList = new List<Person>();

            using (Context db = new Context())
            {
                /*IQueryable<Person> query;
                // Врачи
                query = (from dctr in db.People
                         join pln in db.TreatmentPlans
                         on dctr.ID equals pln.AssignerDoctorID
                         into pln_temp
                         from pl in pln_temp.DefaultIfEmpty()
                         join pcnt in db.People
                         on pl.PatientID equals pcnt.ID
                         into pcnt_temp
                         from pc in pcnt_temp.DefaultIfEmpty()
                         join pres in db.PrescriptionsOfDrugs
                         on pl.ID equals pres.PlanID
                         into pres_temp
                         from prs in pres_temp.DefaultIfEmpty()
                         join drg in db.Drugs
                         on prs.DrugID equals drg.ID
                         into drg_temp
                         from dr in drg_temp.DefaultIfEmpty()

                         select new
                         {
                             ID = dctr.ID,
                             Phone = dctr.Phone,
                             Name = dctr.Name,
                             Surname = dctr.Surname,
                             Patronymic = dctr.Patronymic,
                             DateOfCreate = dctr.DateOfCreate,
                             DateOfDelete = dctr.DateOfDelete,
                             DateOfEdit = dctr.DateOfEdit,
                             Login = dctr.Login,
                             Password = dctr.Password,
                             Role = dctr.Role,
                             PatientID = (pc == null ? 0 : pc.ID),
                             DrugID = (dr == null ? 0 : dr.ID),
                         }).Cast<Person>();


                // Медсестры
                query = (from nrs in db.People
                         join dis in db.DispensingDrugs
                         on nrs.ID equals dis.NurseID
                         into dis_temp
                         from ds in dis_temp.DefaultIfEmpty()
                         join pres in db.PrescriptionsOfDrugs
                         on ds.PrescriptionID equals pres.ID
                         into pres_temp
                         from prs in pres_temp.DefaultIfEmpty()
                         join pln in db.TreatmentPlans
                         on prs.PlanID equals pln.ID
                         into pln_temp
                         from pl in pln_temp.DefaultIfEmpty()
                         join pcnt in db.People
                         on pl.PatientID equals pcnt.ID
                         into pcnt_temp
                         from pc in pcnt_temp.DefaultIfEmpty()
                         join drg in db.Drugs
                         on prs.DrugID equals drg.ID
                         into drg_temp
                         from dr in drg_temp.DefaultIfEmpty()

                         select new
                         {
                             ID = nrs.ID,
                             Phone = nrs.Phone,
                             Name = nrs.Name,
                             Surname = nrs.Surname,
                             Patronymic = nrs.Patronymic,
                             DateOfCreate = nrs.DateOfCreate,
                             DateOfDelete = nrs.DateOfDelete,
                             DateOfEdit = nrs.DateOfEdit,
                             Login = nrs.Login,
                             Password = nrs.Password,
                             Role = nrs.Role,
                             PatientID = (pc == null ? 0 : pc.ID),
                             DrugID = (dr == null ? 0 : dr.ID),
                         }).Cast<Person>();

                //query = 

                //          from employee in db.People
                //          join dispensing in db.DispensingDrugs
                //          on employee.ID equals dispensing.NurseID
                //          into dispensing_temp
                //          from disp in dispensing_temp.DefaultIfEmpty()
                //          join plan in db.TreatmentPlans
                //          on employee.ID equals plan.PatientID
                //          into plan_temp
                //          from pln in plan_temp.DefaultIfEmpty()
                //          join prescription in db.PrescriptionsOfDrugs
                //          on pln.ID equals prescription.PlanID
                //          into pres_temp
                //          from prsn in pres_temp.DefaultIfEmpty()
                //          join dr in db.Drugs
                //          on prsn.DrugID equals dr.ID
                //          into dr_temp
                //          from drg in dr_temp.DefaultIfEmpty()
                //          join empl in db.People
                //          on pln.AssignerDoctorID equals empl.ID
                //          into empl_temp
                //          from e in empl_temp.DefaultIfEmpty()

                //          select new
                //          {
                //              PersonID = e.ID,
                //              PersonPhone = e.Phone,
                //              PersonName = e.Name,
                //              PersonSurname = e.Surname,
                //              PersonPatronymic = e.Patronymic,
                //              PersonAddTime = e.DateOfCreate,
                //              PersonDelDate = e.DateOfDelete,
                //              PersonEditDate = e.DateOfEdit,
                //              PersonLogin = e.Login,
                //              PersonPassword = e.Password,
                //              PersonRole = e.Role,
                //              PatientID = (pln == null ? 0 : pln.PatientID),
                //              DrugID = (drg == null ? 0 : drg.ID),
                //              //DoctorID = (people2 == null ? 0 : people2.ID),
                //              //NurseID = (people2 == null ? 0 : people2.ID)
                //          };



        */
                var query = from e in db.People
                            select new
                            {
                                PersonID = e.ID,
                                PersonPhone = e.Phone,
                                PersonName = e.Name,
                                PersonSurname = e.Surname,
                                PersonPatronymic = e.Patronymic,
                                PersonAddTime = e.DateOfCreate,
                                PersonDelDate = e.DateOfDelete,
                                PersonEditDate = e.DateOfEdit,
                                PersonLogin = e.Login,
                                PersonPassword = e.Password,
                                PersonRole = e.Role,
                            };

                query = query.Where(x => x.PersonDelDate == null); // Убираем удаленных

                if (nurs == true && doct == true) // Поиск по роли
                {
                    query = query.Where(x => x.PersonRole == 2 || x.PersonRole == 3);
                }
                else if (doct == true && nurs == false)
                {
                    query = query.Where(x => x.PersonRole == 2);
                }
                else if (doct == false && nurs == true)
                {
                    query = query.Where(x => x.PersonRole == 3);
                }
                else
                {
                    query = query.Where(x => x.PersonRole == 2 || x.PersonRole == 3);
                }


                if (person.Surname != null) // Поиск по Фамилии
                {
                    query = query.Where(x => x.PersonSurname == person.Surname);
                }
                if (person.Name != null) // Поиск по Имени
                {
                    query = query.Where(x => x.PersonName == person.Name);
                }
                if (person.Patronymic != null) // Поиск по Отчеству
                {
                    query = query.Where(x => x.PersonPatronymic == person.Patronymic);
                }

                if (person.Phone != null) // Поиск по телефону
                {
                    query = query.Where(x => x.PersonPhone == person.Phone);
                }


                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    query = query.Where(x => x.PersonAddTime >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    query = query.Where(x => x.PersonAddTime <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    query = query.Where(x => x.PersonAddTime >= create1 && x.PersonAddTime <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.PersonEditDate >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.PersonEditDate <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    query = query.Where(x => x.PersonEditDate >= edit1 && x.PersonEditDate <= edit2);
                }

                query = query.OrderBy(x => x.PersonID);

                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                foreach (var e in query)
                {
                    if (employeeList.Find(x => x.ID == e.PersonID) == null) // условие предохранения от дубликатов
                    {
                        employeeList.Add(new Person
                        {
                            ID = e.PersonID,
                            Name = e.PersonName,
                            Surname = e.PersonSurname,
                            Patronymic = e.PersonPatronymic,
                            Phone = e.PersonPhone,
                            DateOfCreate = e.PersonAddTime,
                            DateOfEdit = e.PersonEditDate,
                            DateOfDelete = e.PersonDelDate,
                            Login = e.PersonLogin,
                            Password = e.PersonPassword,
                            Role = e.PersonRole

                        }); // добавление работника в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return employeeList;
        }

        // Перешруженный метод FindAllEmployee без параметров пагинации для подсчета максимального числа страниц на гриде в главной форме
        public static List<Person> FindAllEmployee(bool doct, bool nurs,
            Person person, Person patient, Drug drug, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2
            )
        {
            List<Person> employeeList = new List<Person>();

            using (Context db = new Context())
            {

                var query = from e in db.People
                            select new
                            {
                                PersonID = e.ID,
                                PersonPhone = e.Phone,
                                PersonName = e.Name,
                                PersonSurname = e.Surname,
                                PersonPatronymic = e.Patronymic,
                                PersonAddTime = e.DateOfCreate,
                                PersonDelDate = e.DateOfDelete,
                                PersonEditDate = e.DateOfEdit,
                                PersonLogin = e.Login,
                                PersonPassword = e.Password,
                                PersonRole = e.Role,
                            };

                query = query.Where(x => x.PersonDelDate == null); // Убираем удаленных               

                if (nurs == true && doct == true) // Поиск по роли, 2 = врач, 3 = медсестра
                {
                    query = query.Where(x => x.PersonRole == 2 || x.PersonRole == 3);
                }
                else if (doct == true && nurs == false)
                {
                    query = query.Where(x => x.PersonRole == 2);
                }
                else if (doct == false && nurs == true)
                {
                    query = query.Where(x => x.PersonRole == 3);
                }
                else
                {
                    query = query.Where(x => x.PersonRole == 2 || x.PersonRole == 3);
                }


                if (person.Surname != null) // Поиск по Фамилии
                {
                    query = query.Where(x => x.PersonSurname == person.Surname);
                }
                if (person.Name != null) // Поиск по Имени
                {
                    query = query.Where(x => x.PersonName == person.Name);
                }
                if (person.Patronymic != null) // Поиск по Отчеству
                {
                    query = query.Where(x => x.PersonPatronymic == person.Patronymic);
                }

                if (person.Phone != null) // Поиск по телефону
                {
                    query = query.Where(x => x.PersonPhone == person.Phone);
                }


                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    query = query.Where(x => x.PersonAddTime >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    query = query.Where(x => x.PersonAddTime <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    query = query.Where(x => x.PersonAddTime >= create1 && x.PersonAddTime <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.PersonEditDate >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.PersonEditDate <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    query = query.Where(x => x.PersonEditDate >= edit1 && x.PersonEditDate <= edit2);
                }


                foreach (var e in query)
                {
                    if (employeeList.Find(x => x.ID == e.PersonID) == null) // условие предохранения от дубликатов
                    {
                        employeeList.Add(new Person
                        {
                            ID = e.PersonID,
                            Name = e.PersonName,
                            Surname = e.PersonSurname,
                            Patronymic = e.PersonPatronymic,
                            Phone = e.PersonPhone,
                            DateOfCreate = e.PersonAddTime,
                            DateOfEdit = e.PersonEditDate,
                            DateOfDelete = e.PersonDelDate,
                            Login = e.PersonLogin,
                            Password = e.PersonPassword,
                            Role = e.PersonRole

                        }); // добавление работника в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return employeeList;
        }

        public static List<Person> FindAllPatient(Person person, Person doctor, Person nurse,
            Drug drug, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2, int pageNum, int recordsCount)
        {
            List<Person> patientList = new List<Person>();

            using (Context db = new Context())
            {
                var query = from p in db.People
                            select new
                            {
                                PersonID = p.ID,
                                PersonPhone = p.Phone,
                                PersonName = p.Name,
                                PersonSurname = p.Surname,
                                PersonPatronymic = p.Patronymic,
                                PersonAddTime = p.DateOfCreate,
                                PersonDelDate = p.DateOfDelete,
                                PersonEditDate = p.DateOfEdit,
                                PersonLogin = p.Login,
                                PersonPassword = p.Password,
                                PersonRole = p.Role,
                            };
                query = query.Where(x => x.PersonDelDate == null); // Убираем удаленных

                query = query.Where(x => x.PersonRole == 7); // Только пациенты

                if (person.Surname != null) // Поиск по Фамилии
                {
                    query = query.Where(x => x.PersonSurname == person.Surname);
                }
                if (person.Name != null) // Поиск по Имени
                {
                    query = query.Where(x => x.PersonName == person.Name);
                }
                if (person.Patronymic != null) // Поиск по Отчеству
                {
                    query = query.Where(x => x.PersonPatronymic == person.Patronymic);
                }

                if (person.Phone != null) // Поиск по телефону
                {
                    query = query.Where(x => x.PersonPhone == person.Phone);
                }


                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    query = query.Where(x => x.PersonAddTime >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    query = query.Where(x => x.PersonAddTime <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    query = query.Where(x => x.PersonAddTime >= create1 && x.PersonAddTime <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.PersonEditDate >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.PersonEditDate <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    query = query.Where(x => x.PersonEditDate >= edit1 && x.PersonEditDate <= edit2);
                }

                query = query.OrderBy(x => x.PersonID);

                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                foreach (var p in query)
                {
                    if (patientList.Find(x => x.ID == p.PersonID) == null) // условие предохранения от дубликатов
                    {
                        patientList.Add(new Person
                        {
                            ID = p.PersonID,
                            Name = p.PersonName,
                            Surname = p.PersonSurname,
                            Patronymic = p.PersonPatronymic,
                            Phone = p.PersonPhone,
                            DateOfCreate = p.PersonAddTime,
                            DateOfEdit = p.PersonEditDate,
                            DateOfDelete = p.PersonDelDate,
                            Login = p.PersonLogin,
                            Password = p.PersonPassword,
                            Role = p.PersonRole

                        }); // добавление пациента в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return patientList;
        }

        // Перегруженный метод FindAllPatient без параметров пагинации для подсчета максимального числа страниц на гриде в главной форме
        public static List<Person> FindAllPatient(Person person, Person doctor, Person nurse,
            Drug drug, bool checkCreate1, bool checkCreate2, bool checkEdit1, bool checkEdit2,
            DateTime create1, DateTime create2, DateTime edit1, DateTime edit2)
        {
            List<Person> patientList = new List<Person>();

            using (Context db = new Context())
            {
                var query = from p in db.People
                            select new
                            {
                                PersonID = p.ID,
                                PersonPhone = p.Phone,
                                PersonName = p.Name,
                                PersonSurname = p.Surname,
                                PersonPatronymic = p.Patronymic,
                                PersonAddTime = p.DateOfCreate,
                                PersonDelDate = p.DateOfDelete,
                                PersonEditDate = p.DateOfEdit,
                                PersonLogin = p.Login,
                                PersonPassword = p.Password,
                                PersonRole = p.Role,
                            };
                query = query.Where(x => x.PersonDelDate == null); // Убираем удаленных

                query = query.Where(x => x.PersonRole == 7); // Только пациенты

                if (person.Surname != null) // Поиск по Фамилии
                {
                    query = query.Where(x => x.PersonSurname == person.Surname);
                }
                if (person.Name != null) // Поиск по Имени
                {
                    query = query.Where(x => x.PersonName == person.Name);
                }
                if (person.Patronymic != null) // Поиск по Отчеству
                {
                    query = query.Where(x => x.PersonPatronymic == person.Patronymic);
                }

                if (person.Phone != null) // Поиск по телефону
                {
                    query = query.Where(x => x.PersonPhone == person.Phone);
                }


                if (checkCreate1 == true && checkCreate2 == false) // Поиск по дате создания
                {
                    query = query.Where(x => x.PersonAddTime >= create1);
                }
                if (checkCreate2 == true && checkCreate1 == false)
                {
                    query = query.Where(x => x.PersonAddTime <= create2);
                }
                if (checkCreate1 == true && checkCreate2 == true)
                {
                    query = query.Where(x => x.PersonAddTime >= create1 && x.PersonAddTime <= create2);
                }


                if (checkEdit1 == true && checkEdit2 == false) // Поиск по дате изменения
                {
                    query = query.Where(x => x.PersonEditDate >= edit1);
                }
                if (checkEdit2 == true && checkEdit1 == false)
                {
                    query = query.Where(x => x.PersonEditDate <= edit2);
                }
                if (checkEdit1 == true && checkEdit2 == true)
                {
                    query = query.Where(x => x.PersonEditDate >= edit1 && x.PersonEditDate <= edit2);
                }

                foreach (var p in query)
                {
                    if (patientList.Find(x => x.ID == p.PersonID) == null) // условие предохранения от дубликатов
                    {
                        patientList.Add(new Person
                        {
                            ID = p.PersonID,
                            Name = p.PersonName,
                            Surname = p.PersonSurname,
                            Patronymic = p.PersonPatronymic,
                            Phone = p.PersonPhone,
                            DateOfCreate = p.PersonAddTime,
                            DateOfEdit = p.PersonEditDate,
                            DateOfDelete = p.PersonDelDate,
                            Login = p.PersonLogin,
                            Password = p.PersonPassword,
                            Role = p.PersonRole

                        }); // добавление пациента в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return patientList;
        }

        ////////////////МОСТЫ РАБОТНИКА\\\\\\\\\\\\\\\\\\\\\
        // Все пациенты данного работника
        public static List<Person> Employee_Patient(Person person, int pageNum, int recordsCount)
        {
            List<Person> list = new List<Person>();
            using (Context db = new Context())
            {
                if (person.Role == 2) // 2 = врач
                {
                    var query = from patient in db.People
                                join patientID in db.TreatmentPlans
                                on patient.ID equals patientID.PatientID
                                into pln_temp
                                from doctorPlan in pln_temp.DefaultIfEmpty()
                                join doctor in db.People
                                on doctorPlan.AssignerDoctorID equals doctor.ID
                                into people_temp
                                from emp in people_temp.DefaultIfEmpty()

                                select new
                                {
                                    ID = patient.ID,
                                    Phone = patient.Phone,
                                    Name = patient.Name,
                                    Surname = patient.Surname,
                                    Patronymic = patient.Patronymic,
                                    DateOfCreate = patient.DateOfCreate,
                                    DateOfDelete = patient.DateOfDelete,
                                    DateOfEdit = patient.DateOfEdit,

                                    DoctorID = emp.ID,                                    
                                };
                    query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                    query = query.Where(x => x.DoctorID == person.ID);

                    query = query.OrderBy(x => x.ID);
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
                else if (person.Role == 3) // 3 = медсестра
                {
                    var query = from patient in db.People
                                join patientID in db.TreatmentPlans
                                on patient.ID equals patientID.PatientID
                                into pln_temp
                                from pln in pln_temp.DefaultIfEmpty()
                                join dis in db.DispensingDrugs
                                on pln.ID equals dis.TreatmentPlanID
                                into dis_temp
                                from nurse in dis_temp.DefaultIfEmpty()
                                join nur in db.People
                                on nurse.NurseID equals nur.ID
                                into nurse_temp
                                from n in nurse_temp.DefaultIfEmpty()


                                select new
                                {
                                    ID = patient.ID,
                                    Phone = patient.Phone,
                                    Name = patient.Name,
                                    Surname = patient.Surname,
                                    Patronymic = patient.Patronymic,
                                    DateOfCreate = patient.DateOfCreate,
                                    DateOfDelete = patient.DateOfDelete,
                                    DateOfEdit = patient.DateOfEdit,

                                    //DoctorID = emp.ID,
                                    NurseID = n.ID
                                };
                    query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных                    

                    query = query.Where(x => x.NurseID == person.ID);

                    query = query.OrderBy(x => x.ID);
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

                            }); // добавление медсестры в лист, если такого еще нет, это для предохранения от дубликатов
                        }
                    }
                }
            }
            return list;
        }           

        // Все лекарства назначенные/выданные данным работником
        public static List<Drug> Employee_Drug(Person person, int pageNum, int recordsCount)
        {
            List<Drug> list = new List<Drug>();
            using (Context db = new Context())
            {
                if (person.Role == 2) // 2 = врач
                {
                    var query = from drug in db.Drugs
                                join presDrug in db.PrescriptionsOfDrugs
                                on drug.ID equals presDrug.DrugID
                                into pres_temp
                                from prs in pres_temp.DefaultIfEmpty()
                                join plan in db.TreatmentPlans
                                on prs.PlanID equals plan.ID
                                into plan_temp
                                from pln in plan_temp.DefaultIfEmpty()
                                join doctor in db.People
                                on pln.AssignerDoctorID equals doctor.ID
                                into doctor_temp
                                from doc in doctor_temp.DefaultIfEmpty()

                                select new
                                {
                                    ID = drug.ID,
                                    Name = drug.Name,
                                    Measure = drug.Measure,
                                    Quantity = drug.Quantity,
                                    DateOfCreate = drug.DateOfCreate,
                                    DateOfDelete = drug.DateOfDelete,
                                    DateOfEdit = drug.DateOfEdit,

                                    DoctorID = doc.ID                                    
                                };
                    query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                    query = query.Where(x => x.DoctorID == person.ID);

                    query = query.OrderBy(x => x.ID);
                    query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                    foreach (var e in query)
                    {
                        if (list.Find(x => x.ID == e.ID) == null)
                        {
                            list.Add(new Drug
                            {
                                ID = e.ID,
                                Name = e.Name,
                                Measure = e.Measure,
                                Quantity = e.Quantity,
                                DateOfCreate = e.DateOfCreate,
                                DateOfEdit = e.DateOfEdit,
                                DateOfDelete = e.DateOfDelete

                            }); // добавление врача в лист, если такого еще нет, это для предохранения от дубликатов
                        }
                    }
                }
                else if (person.Role == 3) // 3 = медсестра
                {
                    var query = from drug in db.Drugs
                                join presDrug in db.PrescriptionsOfDrugs
                                on drug.ID equals presDrug.DrugID
                                into pres_temp
                                from prs in pres_temp.DefaultIfEmpty()
                                join dis in db.DispensingDrugs
                                on prs.ID equals dis.PrescriptionID
                                into dis_temp
                                from nur in dis_temp.DefaultIfEmpty()
                                join n in db.People
                                on nur.NurseID equals n.ID
                                into nu
                                from nurse in nu.DefaultIfEmpty()

                                select new
                                {
                                    ID = drug.ID,
                                    Name = drug.Name,
                                    Measure = drug.Measure,
                                    Quantity = drug.Quantity,
                                    DateOfCreate = drug.DateOfCreate,
                                    DateOfDelete = drug.DateOfDelete,
                                    DateOfEdit = drug.DateOfEdit,
                                    
                                    NurseID = nurse.ID
                                };
                    query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных
                    
                    query = query.Where(x => x.NurseID == person.ID);

                    query = query.OrderBy(x => x.ID);
                    query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                    foreach (var e in query)
                    {
                        if (list.Find(x => x.ID == e.ID) == null)
                        {
                            list.Add(new Drug
                            {
                                ID = e.ID,
                                Name = e.Name,
                                Measure = e.Measure,
                                Quantity = e.Quantity,
                                DateOfCreate = e.DateOfCreate,
                                DateOfEdit = e.DateOfEdit,
                                DateOfDelete = e.DateOfDelete

                            }); // добавление медсестры в лист, если такого еще нет, это для предохранения от дубликатов
                        }
                    }
                }
            }
            return list;
        }

        

        ////////////////////МОСТЫ ПАЦИЕНТА\\\\\\\\\\\\\\\\\\\\\\
        // Врачи, лечащие данного пациента
        public static List<Person> Patient_Doctor(Person person, int pageNum, int recordsCount)
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from doctor in db.People
                            join pln in db.TreatmentPlans
                            on doctor.ID equals pln.AssignerDoctorID
                            into pln_temp
                            from planPatient in pln_temp.DefaultIfEmpty()
                            join p in db.People
                            on planPatient.PatientID equals p.ID
                            into pati_temp
                            from patient in pati_temp.DefaultIfEmpty()

                            select new
                            {
                                ID = doctor.ID,
                                Phone = doctor.Phone,
                                Name = doctor.Name,
                                Surname = doctor.Surname,
                                Patronymic = doctor.Patronymic,
                                Role = doctor.Role,
                                DateOfCreate = doctor.DateOfCreate,
                                DateOfDelete = doctor.DateOfDelete,
                                DateOfEdit = doctor.DateOfEdit,
                                
                                Patient = patient.ID
                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Patient == person.ID);

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

        // Все медсестры, лечащие данного пациента
        public static List<Person> Patient_Nurse(Person person, int pageNum, int recordsCount)
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from nurse in db.People
                            join dis in db.DispensingDrugs
                            on nurse.ID equals dis.NurseID
                            into dis_temp
                            from ds in dis_temp.DefaultIfEmpty()
                            join plan in db.TreatmentPlans
                            on ds.TreatmentPlanID equals plan.ID
                            into pln_temp
                            from pl in pln_temp.DefaultIfEmpty()
                            join pnt in db.People
                            on pl.PatientID equals pnt.ID
                            into pnt_temp
                            from patient in pnt_temp.DefaultIfEmpty()

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
                                
                                Patient = patient.ID
                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Patient == person.ID);

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

                        }); // добавление медсестры в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
            }
            return list;
        }

        // Все лекарства, назначенные данному пациенту
        public static List<Drug> Patient_Drug(Person person, int pageNum, int recordsCount)
        {
            List<Drug> list = new List<Drug>();

            using (Context db = new Context())
            {
                var query = from drug in db.Drugs
                            join pres in db.PrescriptionsOfDrugs
                            on drug.ID equals pres.DrugID
                            into pres_temp
                            from prs in pres_temp.DefaultIfEmpty()
                            join plan in db.TreatmentPlans
                            on prs.PlanID equals plan.ID
                            into pln_temp
                            from pl in pln_temp.DefaultIfEmpty()
                            join pnt in db.People
                            on pl.PatientID equals pnt.ID
                            into pnt_temp
                            from patient in pnt_temp.DefaultIfEmpty()

                            select new
                            {
                                ID = drug.ID,
                                Name = drug.Name,
                                Measure = drug.Measure,
                                DateOfCreate = drug.DateOfCreate,
                                DateOfDelete = drug.DateOfDelete,
                                DateOfEdit = drug.DateOfEdit,

                                PatientID = patient.ID

                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.PatientID == person.ID);

                // Сортировка по id, без OrderBy не работает Skip
                query = query.OrderBy(x => x.ID);
                // Отбираем нужное количество записей
                query = query.Skip((pageNum - 1) * recordsCount).Take(recordsCount);

                foreach (var e in query)
                {
                    if (list.Find(x => x.ID == e.ID) == null)
                    {
                        list.Add(new Drug
                        {
                            ID = e.ID,
                            Name = e.Name,
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


        /////////////////////ГРИДЫ С ВЫБОРОМ - CHOICE FORM\\\\\\\\\\\\\\\\\\\\\
        // Грид с врачами
        public static List<Person> ChoiceGrid_Doctor()
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from doctor in db.People
                            select new
                            {
                                ID = doctor.ID,
                                Phone = doctor.Phone,
                                Name = doctor.Name,
                                Surname = doctor.Surname,
                                Patronymic = doctor.Patronymic,
                                Role = doctor.Role,
                                DateOfCreate = doctor.DateOfCreate,
                                DateOfDelete = doctor.DateOfDelete,
                                DateOfEdit = doctor.DateOfEdit,

                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Role == 2); // 2 = врач

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
                return list;
            }
        }




        public static List<Person> ChoiceGrid_Patient()
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from patient in db.People
                            select new
                            {
                                ID = patient.ID,
                                Phone = patient.Phone,
                                Name = patient.Name,
                                Surname = patient.Surname,
                                Patronymic = patient.Patronymic,
                                Role = patient.Role,
                                DateOfCreate = patient.DateOfCreate,
                                DateOfDelete = patient.DateOfDelete,
                                DateOfEdit = patient.DateOfEdit,

                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Role == 7); // 7 = пациент

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
                            //Role = e.Role,
                            DateOfCreate = e.DateOfCreate,
                            DateOfEdit = e.DateOfEdit,
                            DateOfDelete = e.DateOfDelete

                        }); // добавление врача в лист, если такого еще нет, это для предохранения от дубликатов
                    }
                }
                return list;
            }
        }


        public static List<Person> ChoiceGrid_Nurse()
        {
            List<Person> list = new List<Person>();

            using (Context db = new Context())
            {
                var query = from nurse in db.People
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

                            };
                query = query.Where(x => x.DateOfDelete == null); // Убираем удаленных

                query = query.Where(x => x.Role == 3); // 3 = медсестра

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
                return list;
            }
        }

    }
}
