using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClinicApp.Model
{
    // Паттерн однопоточный синглетон
    public class Singleton
    {        
        private static Person person; // Одно приватное поле
        // Получаем залогинившегося человека
        public static Person getPerson()
        {
            if (person == null) // Если такого нет(еще не залогинился) - создаем его
            {
                person = new Person();
            }
            return person; // Если есть - возвращаем
        }

        // Удаляем человека(при выходе из системы)
        public static Person delPerson()
        {
            person = null;
            return person;
        }
        // Получаем логин и пароль залогинившегося человека
        public static Person inputPerson(string login, string password)
        {
            using (Context db = new Context())
            {
                person = db.People.Where(x => x.Login == login & x.Password == password).FirstOrDefault<Person>();

                return person;
            }
        }
    }

    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Roles
    {        
        // Получаем роль по ID
        public static Role RoleID(int id)
        {
            using (Context context = new Context())
            {
                Role v = context.Roles.Where(x => x.ID == id).FirstOrDefault<Role>();

                return v;
            }
        }                
    }

    // Полномочия
    public class Authority
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    // Запреты
    public class Prohibition
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int AuthorityID { get; set; }

        public static bool Banned(string name) // Возвращает true -  если нет запрета на органичение функционала, false - запрет есть
        {
            using (Context db = new Context())
            {
                Person person = Singleton.getPerson();
                Authority action = new Authority();
                action = db.Authorities.Where(x => x.Name == name).FirstOrDefault<Authority>();
                if (action != null)
                {                    
                    Prohibition v = db.Prohibitions.Where(x => x.RoleID == person.Role && x.AuthorityID == action.ID).FirstOrDefault<Prohibition>();
                    if (v != null) // Если v - пустое значение, значит запрета нет! возвращаем true
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
