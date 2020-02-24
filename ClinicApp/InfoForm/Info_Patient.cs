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
    public partial class Info_Patient : Form
    {        
        // Текущая страница записей на гриде, всегда первая
        public int currentPage = 1;
        // Максимальное количество страниц на гриде
        public int maxpage;
        // Экземпляр Person который присваивается переданному из грида пациенту
        Person person = new Person();

        bool editBan = Model.Prohibition.Banned("pnt_edit"); // Перменная для хранения доступа к редактированию

        public Info_Patient(Person patient)
        {
            InitializeComponent();

            // передача пациента с грида
            person = patient;
            panel1.Enabled = false;
            // Доступ к редактированию в зависимости от роли
            button6.Enabled = editBan;
            button1.Enabled = editBan;

            textBox1.Text = person.Surname;
            textBox2.Text = person.Name;
            textBox3.Text = person.Patronymic;
            textBox4.Text = person.Phone;

            // Мосты
            // Все врачи данного пациента
            GridWithDoctor();
            // Все медсестры данного пациента
            GridWithNurse();
            // Все назначенные лекарства данного пациента
            GridWithDrug();
        }

        // Кнопка "Сохранить", при нажатии считывает текстбоксы и заносит их данные в поля объекта + проверка полей
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckField() == 4)
            {
                person.Surname = textBox1.Text;
                person.Name = textBox2.Text;
                person.Patronymic = textBox3.Text;
                person.Phone = textBox4.Text;

                OperationsOfPersons.Edit(person);
                MessageBox.Show("Данные о пациенте изменены");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
            }
        }

        private void GridWithDoctor()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridDoctors.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все врачи данного пациента
            List<Person> emp = OperationsOfPersons.Patient_Doctor(person, currentPage, records);

            // Поиск максимального числа страниц
            maxpage = emp.Count() / records;

            // Если записи ровно не делятся на 5/10 - добавляется еще 1 страница
            if (emp.Count() % records != 0) { maxpage++; }

            // Если записей вообще нет - будет 1 страница
            if (maxpage == 0) { maxpage++; }

            // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
            if (currentPage == maxpage) { button29.Enabled = false; }

            // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
            if (currentPage == 1) { button30.Enabled = false; }

            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Заполнение грида с мостом врачей
            foreach (Person p in emp)
            {
                dataGridDoctors.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.Role, p.DateOfCreate, p.DateOfEdit);
            }
        }

        private void GridWithNurse()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridNurses.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все медсестры данного пациента
            List<Person> emp = OperationsOfPersons.Patient_Nurse(person, currentPage, records);

            // Поиск максимального числа страниц
            maxpage = emp.Count() / records;

            // Если записи ровно не делятся на 5/10 - добавляется еще 1 страница
            if (emp.Count() % records != 0) { maxpage++; }

            // Если записей вообще нет - будет 1 страница
            if (maxpage == 0) { maxpage++; }
                        
            // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
            if (currentPage == maxpage) { button2.Enabled = false; }

            // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
            if (currentPage == 1) { button3.Enabled = false; }

            label6.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Заполнение грида с мостом медсестер
            foreach (Person p in emp)
            {
                dataGridNurses.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.Role, p.DateOfCreate, p.DateOfEdit);
            }
        }

        private void GridWithDrug()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridDrugs.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все лекарства данного пациента
            List<Drug> drugs = OperationsOfPersons.Patient_Drug(person, currentPage, records);

            // Поиск максимального числа страниц
            maxpage = drugs.Count() / records;

            // Если записи ровно не делятся на 5/10 - добавляется еще 1 страница
            if (drugs.Count() % records != 0) { maxpage++; }

            // Если записей вообще нет - будет 1 страница
            if (maxpage == 0) { maxpage++; }           

            // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
            if (currentPage == maxpage) { button4.Enabled = false; }

            // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
            if (currentPage == 1) { button5.Enabled = false; }

            label8.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Заполнение грида с мостом лекарств
            foreach (Drug p in drugs)
            {
                dataGridDrugs.Rows.Add(p.ID, p.Name, p.Quantity, p.Measure, p.DateOfCreate, p.DateOfEdit);
            }
        }        

        // Кнопка смены страницы НАЗАД на гриде врачей данного пациента
        private void button30_Click(object sender, EventArgs e)
        {
            button29.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button30.Enabled = false;
            }
            GridWithDoctor();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде врачей данного пациента
        private void button29_Click(object sender, EventArgs e)
        {
            button30.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button29.Enabled = false;
            }
            GridWithDoctor();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы НАЗАД на гриде медсестер данного пациента
        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button3.Enabled = false;
            }
            GridWithNurse();
            label6.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде медсестер данного пациента
        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button2.Enabled = false;
            }
            GridWithNurse();
            label6.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы НАЗАД на гриде лекарств данного пациента
        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button5.Enabled = false;
            }
            GridWithDrug();
            label8.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде лекарств данного пациента
        private void button4_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button4.Enabled = false;
            }
            GridWithDrug();
            label8.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Метод проверки полей, возвращает цифру 4, если все 4 полей проходят проверку
        // Если нет, то над полями не прошедшими проверку появляется надпись
        private int CheckField()
        {
            int check = 0;
            if (Regex.IsMatch(textBox1.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip1.Show("Введите фамилию на русском языке с заглавной буквы", textBox1, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox2.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip2.Show("Введите имя на русском языке с заглавной буквы", textBox2, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox3.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip3.Show("Введите отчество на русском языке с заглавной буквы", textBox3, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox4.Text, @"^[8]{1}[9]{1}[0-9]{9}")) { check++; }
            else
            {
                toolTip4.Show("Введите номер начиная с 89", textBox4, new Point(0, 20), 1000);
            }

            return check;
        }

        // Дабл клик по гриду с врачами
        private void dataGridDoctors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки врача при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridDoctors.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridDoctors.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(врача) на которую мы кликнули
                        InfoForm.Info_Employee f = new InfoForm.Info_Employee(OperationsOfPersons.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида врачей для его авто обновления
                        GridWithDoctor();
                    }                    
                }
            }
        }

        // Дабл клик по гриду с медсестрами
        private void dataGridNurses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки медсестры при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridNurses.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridNurses.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(медсестры) на которую мы кликнули
                        InfoForm.Info_Employee f = new InfoForm.Info_Employee(OperationsOfPersons.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида медсестер для его авто обновления
                        GridWithNurse();
                    }                    
                }
            }
        }

        // Дабл клик по гриду с лекарствами
        private void dataGridDrugs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки лекарства при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridDrugs.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridDrugs.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(пациента) на которую мы кликнули
                        InfoForm.Info_Drug f = new InfoForm.Info_Drug(OperationsOfDrugs.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида лекарств для его авто обновления
                        GridWithDrug();
                    }                    
                }
            }
        }
        // Кнопка Изменить
        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }
    }
}
