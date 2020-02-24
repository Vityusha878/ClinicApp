using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClinicApp.InfoForm
{
    public partial class Info_Employee : Form
    {
        // Текущая страница записей на гриде, всегда первая
        public int currentPage = 1;
        // Максимальное количество страниц на гриде
        public int maxpage;
        // Экземпляр Person который присваивается переданному из грида работнику
        Person person = new Person();
        // Список значений combobox
        List<string> role = new List<string>() { "Врач", "Медсестра" };

        bool editBan = Model.Prohibition.Banned("emp_edit"); // Перменная для хранения доступа к редактированию
                

        public Info_Employee(Person employee)
        {
            InitializeComponent();

            // Определяем стиль ComboBox - только выпадаюший, вводить ничего нельзя
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // Значения ComboBox - список выше (врач и медсестра)
            comboBox1.DataSource = role;
            // Бан полей
            panel1.Enabled = false;
            // Доступ к редактированию в зависимости от роли
            button4.Enabled = editBan;
            button2.Enabled = editBan;

            // передача работника из грида главной формы
            person = employee;            

            // Заполнение textBox значениями переданного объекта Person
            textBox2.Text = person.Surname;
            textBox3.Text = person.Name;
            textBox4.Text = person.Patronymic;
            textBox5.Text = person.Phone;

            if (person.Role == 2) { comboBox1.Text = "Врач"; }
            else { comboBox1.Text = "Медсестра"; }
            
            textBox6.Text = person.Login;
            textBox7.Text = person.Password;

            // Мосты            
            GridWithPatient();
            GridWithDrugs();
        }

        // Кнопка "Сохранить", при нажатии считывает текстбоксы и заносит их данные в поля объекта + проверка полей
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckField() == 6)
            {
                person.Surname = textBox2.Text;
                person.Name = textBox3.Text;
                person.Patronymic = textBox4.Text;
                person.Phone = textBox5.Text;

                if (comboBox1.Text == "Врач") { person.Role = 2; }
                else { person.Role = 3; }

                person.Login = textBox6.Text;
                person.Password = textBox7.Text;

                OperationsOfPersons.Edit(person);
                MessageBox.Show("Данные о работнике изменены");                
            }
        }

        private void GridWithPatient()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridView3.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все пациенты данного работника
            List<Person> emp = OperationsOfPersons.Employee_Patient(person, currentPage, records);

            // Поиск максимального числа страниц
            maxpage = emp.Count() / records;

            // Если записи ровно не делятся на 10 - добавляется еще 1 страница
            if (emp.Count() % records != 0) { maxpage++; }

            // Если записей вообще нет - будет 1 страница
            if (maxpage == 0) { maxpage++; }

            // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
            if (currentPage == maxpage) { button29.Enabled = false; }

            // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
            if (currentPage == 1) { button30.Enabled = false; }

            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
            // Заполнение грида с мостом пациентов
            foreach (Person p in emp)
            {
                dataGridView3.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.DateOfCreate, p.DateOfEdit);
            }
        }
        private void GridWithDrugs()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridView6.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все лекарства назначенные/выданные данным работником
            List<Drug> drugs = OperationsOfPersons.Employee_Drug(person, currentPage, records);

            // Поиск максимального числа страниц
            maxpage = drugs.Count() / records;

            // Если записи ровно не делятся на 5/10 - добавляется еще 1 страница
            if (drugs.Count() % records != 0) { maxpage++; }

            // Если записей вообще нет - будет 1 страница
            if (maxpage == 0) { maxpage++; }           

            // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
            if (currentPage == maxpage) { button1.Enabled = false; }

            // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
            if (currentPage == 1) { button3.Enabled = false; }

            label9.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
            // Заполнение грида с мостом лекарств
            foreach (Drug d in drugs)
            {
                dataGridView6.Rows.Add(d.ID, d.Name, d.Quantity, d.Measure, d.DateOfCreate, d.DateOfEdit);
            }
        }        

        // Кнопка смены страницы НАЗАД на гриде пациентов данного работника
        private void button30_Click(object sender, EventArgs e)
        {
            button29.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button30.Enabled = false;
            }
            GridWithPatient();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде пациентов данного работника
        private void button29_Click(object sender, EventArgs e)
        {
            button30.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button29.Enabled = false;
            }
            GridWithPatient();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы НАЗАД на гриде лекарств назначенных/выданных данным работником
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button3.Enabled = false;
            }
            GridWithDrugs();
            label9.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде лекарств назначенных/выданных данным работником
        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button1.Enabled = false;
            }
            GridWithDrugs();
            label9.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Метод проверки полей, возвращает цифру 6, если все 6 полей проходят проверку
        // Если нет, то над полями не прошедшими проверку появляется надпись
        private int CheckField()
        {
            int check = 0;
            if (Regex.IsMatch(textBox2.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip1.Show("Введите фамилию на русском языке с заглавной буквы", textBox2, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox3.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip2.Show("Введите имя на русском языке с заглавной буквы", textBox3, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox4.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip3.Show("Введите отчество на русском языке с заглавной буквы", textBox4, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox5.Text, @"^[8]{1}[9]{1}[0-9]{9}")) { check++; }
            else
            {
                toolTip4.Show("Введите номер", textBox5, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox6.Text, @"^[a-zA-Z0-9]*([a-zA-Z0-9])$")) { check++; }
            else
            {
                toolTip5.Show("Введите логин", textBox6, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox7.Text, @"^[a-zA-Z0-9]*([a-zA-Z0-9])$")) { check++; }
            else
            {
                toolTip6.Show("Введите пароль", textBox7, new Point(0, 20), 1000);
            }
            return check;
        }

        // Дабл клик по гриду с пациентами
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки пациента при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView3.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridView3.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(пациента) на которую мы кликнули
                        InfoForm.Info_Patient f = new InfoForm.Info_Patient(OperationsOfPersons.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида пациентов для его авто обновления
                        GridWithPatient();
                    }                    
                }
            }
        }

        // Дабл клик по гриду с лекарствами
        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки лекарства при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView6.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridView6.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(лекарства) на которую мы кликнули
                        InfoForm.Info_Drug f = new InfoForm.Info_Drug(OperationsOfDrugs.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида лекарств для его авто обновления
                        GridWithDrugs();
                    }                    
                }
            }
        }
        // Кнопка Изменить
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }
    }
}
