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
    public partial class Info_Drug : Form
    {        
        // Текущая страница записей на гриде, всегда первая
        public int currentPage = 1;
        // Максимальное количество страниц на гриде
        public int maxpage;
        // Экземпляр Person который присваивается переданному из грида пациенту
        Drug drug = new Drug();
        bool editBan = Model.Prohibition.Banned("pnt_edit"); // Перменная для хранения доступа к редактированию

        public Info_Drug(Drug drg)
        {
            InitializeComponent();

            // передача пациента с грида
            drug = drg;
            button2.Visible = editBan;
            button6.Visible = editBan;
            
            textBox8.Enabled = false;
            panel1.Enabled = false;

            textBox1.Text = drug.Name;
            numericUpDown1.Value = (Decimal)drug.Quantity;
            textBox8.Text = drug.Measure;                       

            // Мосты          
            // Все врачи данного лекарства
            GridWithDoctor();
            // Все медсестры данного лекарства
            GridWithNurse();
            // Все пациенты данного лекарства
            GridWithPatient();            
        }

        // Кнопка "Сохранить", при нажатии считывает текстбоксы и заносит их данные в поля объекта + проверка полей
        private void button2_Click(object sender, EventArgs e)
        {           
            if (CheckField() == 2)
            {
                drug.Name = textBox1.Text;
                drug.Quantity = (int)numericUpDown1.Value;
                drug.Measure = textBox8.Text;

                OperationsOfDrugs.Edit(drug);
                MessageBox.Show("Данные о лекарстве изменены");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
            }
        }

        private void GridWithPatient()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridView2.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все пациенты данного лекарства
            List<Person> emp = OperationsOfDrugs.Drug_Patient(drug, currentPage, records);

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
                dataGridView2.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.DateOfCreate, p.DateOfEdit);
            }
        }

        private void GridWithDoctor()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridEmployee.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все врачи данного пациента
            List<Person> emp = OperationsOfDrugs.Drug_Doctor(drug, currentPage, records);

            // Поиск максимального числа страниц
            maxpage = emp.Count() / records;

            // Если записи ровно не делятся на 10 - добавляется еще 1 страница
            if (emp.Count() % records != 0) { maxpage++; }

            // Если записей вообще нет - будет 1 страница
            if (maxpage == 0) { maxpage++; }

            // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
            if (currentPage == maxpage) { button1.Enabled = false; }

            // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
            if (currentPage == 1) { button3.Enabled = false; }

            label3.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Заполнение грида с мостом врачей
            foreach (Person p in emp)
            {
                dataGridEmployee.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.Role, p.DateOfCreate, p.DateOfEdit);
            }
        }

        private void GridWithNurse()
        {
            // Очистка грида чтобы записи не дублировались
            dataGridView1.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            // Все врачи данного пациента
            List<Person> emp = OperationsOfDrugs.Drug_Nurse(drug, currentPage, records);

            // Поиск максимального числа страниц
            maxpage = emp.Count() / records;

            // Если записи ровно не делятся на 10 - добавляется еще 1 страница
            if (emp.Count() % records != 0) { maxpage++; }

            // Если записей вообще нет - будет 1 страница
            if (maxpage == 0) { maxpage++; }

            // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
            if (currentPage == maxpage) { button4.Enabled = false; }

            // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
            if (currentPage == 1) { button5.Enabled = false; }

            label5.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Заполнение грида с мостом медсестер
            foreach (Person p in emp)
            {
                dataGridView1.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.Role, p.DateOfCreate, p.DateOfEdit);
            }
        }        

        // Кнопка смены страницы НАЗАД на гриде пациентов данного лекарства
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

        // Кнопка смены страницы ВПЕРЕД на гриде пациентов данного лекарства
        private void button29_Click(object sender, EventArgs e)
        {
            button30.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button29.Enabled = false;
            }
            GridWithPatient();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы НАЗАД на гриде врачей данного лекарства
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button3.Enabled = false;
            }
            GridWithDoctor();
            label3.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде врачей данного лекарства
        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button1.Enabled = false;
            }
            GridWithDoctor();
            label3.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы НАЗАД на гриде медсестер данного лекарства
        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button5.Enabled = false;
            }
            GridWithNurse();
            label5.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде медсестер данного лекарства
        private void button4_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button4.Enabled = false;
            }
            GridWithNurse();
            label5.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Дабл клик по гриду с пациентами
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки пациента при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView2.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridView2.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(врача) на которую мы кликнули
                        InfoForm.Info_Patient f = new InfoForm.Info_Patient(OperationsOfPersons.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида пациентов для его авто обновления
                        GridWithPatient();
                    }                    
                }
            }
        }

        // Дабл клик по гриду с врачами
        private void dataGridEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки врача при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridEmployee.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridEmployee.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(врача) на которую мы кликнули
                        InfoForm.Info_Employee f = new InfoForm.Info_Employee(OperationsOfPersons.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида пациентов для его авто обновления
                        GridWithDoctor();
                    }
                }
            }
        }
        // Дабл клик по гриду с медсестрами
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Открытие карточки медсестры при клике везде на гриде
            if (e.ColumnIndex != 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView1.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id пациента из строки
                        int k = Convert.ToInt32(dataGridView1.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(врача) на которую мы кликнули
                        InfoForm.Info_Employee f = new InfoForm.Info_Employee(OperationsOfPersons.FindByID(k));
                        f.ShowDialog();
                        // Вызов функции грида пациентов для его авто обновления
                        GridWithNurse();
                    }
                }
            }
        }

        // Метод проверки полей, возвращает цифру 2, если поля проходят проверку
        // Если нет, то над полями не прошедшими проверку появляется надпись
        private int CheckField()
        {
            int check = 0;
            if (Regex.IsMatch(textBox1.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip1.Show("Введите название на русском языке с заглавной буквы", textBox1, new Point(0, 20), 1000);
            }
            if (numericUpDown1.Value != 0) { check++; }
            else
            {
                toolTip2.Show("Введите количество лекарства", numericUpDown1, new Point(0, 20), 1000);
            }
            return check;
        }

        // Кнопка изменить
        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }
    }
}
