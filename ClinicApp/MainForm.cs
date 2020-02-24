using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicApp
{
    public partial class MainFormClinic : Form
    {
        public MainFormClinic()
        {
            InitializeComponent();
        }

        public int countRecords = 10; // Количество записей на гриде
        public int currentPage = 1; // Текущая выбранная страница по умолчанию всегда первая
        public int maxpage; // Максимальное количество записей на гриде        


        int status = ClinicApp.Model.Singleton.getPerson().Role; // Должность зашедшего в систему
        int personID = ClinicApp.Model.Singleton.getPerson().ID; // ID зашедшего в систему

        // Рабочий метод разделения доступа для ролей
        // Сделан вручную, а не по паттерну Singleton
        // Да, не правильно, не профессионально
        // Было лень переделывать под паттерн всю главную форму
        // Да простит меня Бог
        //
        //p.s. в отдельных формах есть паттерн
        private void Access()
        {
            switch (status)
            {
                case 1:                  
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);

                    DefaultGridWithEmployees();
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    dateTimePicker5.Enabled = false;
                    dateTimePicker6.Enabled = false;

                    GridWithPatients();
                    dateTimePicker3.Enabled = false;
                    dateTimePicker4.Enabled = false;
                    dateTimePicker7.Enabled = false;
                    dateTimePicker8.Enabled = false;
                    break;
                case 2:
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage6);                                       

                    Plans_Doctor();
                    dateTimePicker9.Enabled = false;
                    dateTimePicker10.Enabled = false;
                    dateTimePicker21.Enabled = false;
                    dateTimePicker22.Enabled = false;

                    Pres_Doctor();
                    dateTimePicker11.Enabled = false;
                    dateTimePicker12.Enabled = false;
                    dateTimePicker15.Enabled = false;
                    dateTimePicker16.Enabled = false;
                    dateTimePicker25.Enabled = false;
                    dateTimePicker26.Enabled = false;
                    dateTimePicker23.Enabled = false;
                    dateTimePicker24.Enabled = false;

                    AllDispensing();
                    dateTimePicker13.Enabled = false;
                    dateTimePicker14.Enabled = false;
                    dateTimePicker17.Enabled = false;
                    dateTimePicker18.Enabled = false;
                    dateTimePicker19.Enabled = false;
                    dateTimePicker20.Enabled = false;
                    break;
                case 3:
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage6);

                    dataGridView5.Columns[9].Visible = false; // Сокрытие кнопки удаления от медсестры                                       

                    AllDispensing();
                    dateTimePicker13.Enabled = false;
                    dateTimePicker14.Enabled = false;
                    dateTimePicker17.Enabled = false;
                    dateTimePicker18.Enabled = false;
                    dateTimePicker19.Enabled = false;
                    dateTimePicker20.Enabled = false;
                    break;
                case 4:
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);

                    AllDrug();
                    dateTimePicker31.Enabled = false;
                    dateTimePicker32.Enabled = false;
                    dateTimePicker27.Enabled = false;
                    dateTimePicker28.Enabled = false;
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                    break;
                case 5:                   
                    // Сокрытие элементов управления от владельца клиники
                    EmployeeAddButton.Visible = false; // Добавление работника
                    dataGridEmployee.Columns[8].Visible = false; // Удаление работника
                    button9.Visible = false; // Добавление пациента
                    dataGridView2.Columns[7].Visible = false; // Удаление пациента
                    button21.Visible = false; // Добавление плана лечения
                    dataGridView3.Columns[5].Visible = false; // Удаление плана лечения
                    dataGridView4.Columns[8].Visible = false; // Удаление назначения лекарства
                    dataGridView5.Columns[9].Visible = false; // Удаление события выдачи лекарств
                    button40.Visible = false; // Добавление лекарства
                    dataGridView6.Columns[6].Visible = false; // Удаление лекарства

                    DefaultGridWithEmployees();
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    dateTimePicker5.Enabled = false;
                    dateTimePicker6.Enabled = false;

                    GridWithPatients();
                    dateTimePicker3.Enabled = false;
                    dateTimePicker4.Enabled = false;
                    dateTimePicker7.Enabled = false;
                    dateTimePicker8.Enabled = false;

                    AllPlans();
                    dateTimePicker9.Enabled = false;
                    dateTimePicker10.Enabled = false;
                    dateTimePicker21.Enabled = false;
                    dateTimePicker22.Enabled = false;

                    AllPrescription();
                    dateTimePicker11.Enabled = false;
                    dateTimePicker12.Enabled = false;
                    dateTimePicker15.Enabled = false;
                    dateTimePicker16.Enabled = false;
                    dateTimePicker25.Enabled = false;
                    dateTimePicker26.Enabled = false;
                    dateTimePicker23.Enabled = false;
                    dateTimePicker24.Enabled = false;

                    AllDispensing();
                    dateTimePicker13.Enabled = false;
                    dateTimePicker14.Enabled = false;
                    dateTimePicker17.Enabled = false;
                    dateTimePicker18.Enabled = false;
                    dateTimePicker19.Enabled = false;
                    dateTimePicker20.Enabled = false;

                    AllDrug();
                    dateTimePicker31.Enabled = false;
                    dateTimePicker32.Enabled = false;
                    dateTimePicker27.Enabled = false;
                    dateTimePicker28.Enabled = false;
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                    break;
                case 6:                   
                    DefaultGridWithEmployees();
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    dateTimePicker5.Enabled = false;
                    dateTimePicker6.Enabled = false;

                    GridWithPatients();
                    dateTimePicker3.Enabled = false;
                    dateTimePicker4.Enabled = false;
                    dateTimePicker7.Enabled = false;
                    dateTimePicker8.Enabled = false;

                    AllPlans();
                    dateTimePicker9.Enabled = false;
                    dateTimePicker10.Enabled = false;
                    dateTimePicker21.Enabled = false;
                    dateTimePicker22.Enabled = false;

                    AllPrescription();
                    dateTimePicker11.Enabled = false;
                    dateTimePicker12.Enabled = false;
                    dateTimePicker15.Enabled = false;
                    dateTimePicker16.Enabled = false;
                    dateTimePicker25.Enabled = false;
                    dateTimePicker26.Enabled = false;
                    dateTimePicker23.Enabled = false;
                    dateTimePicker24.Enabled = false;

                    AllDispensing();
                    dateTimePicker13.Enabled = false;
                    dateTimePicker14.Enabled = false;
                    dateTimePicker17.Enabled = false;
                    dateTimePicker18.Enabled = false;
                    dateTimePicker19.Enabled = false;
                    dateTimePicker20.Enabled = false;

                    AllDrug();
                    dateTimePicker31.Enabled = false;
                    dateTimePicker32.Enabled = false;
                    dateTimePicker27.Enabled = false;
                    dateTimePicker28.Enabled = false;
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                    break;
            }
        }
        // Последняя вкладка с личной информацией зашедшего в систему
        private void PersonInformation()
        {
            label74.Text = OperationsOfPersons.FindByID(personID).Surname;
            label75.Text = OperationsOfPersons.FindByID(personID).Name;
            label77.Text = OperationsOfPersons.FindByID(personID).Patronymic;
            label78.Text = Model.Roles.RoleID(status).Name;
            label79.Text = OperationsOfPersons.FindByID(personID).Phone;
            label80.Text = OperationsOfPersons.FindByID(personID).Login;
            label82.Text = OperationsOfPersons.FindByID(personID).Password;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            PersonInformation();
            Access();
        }



        /* КОНЦЕПЦИИ ПРОГРАММЫ
         * 
         * Проблема с пагинацией 1
         * Была проблема с определением максимального количества страниц на гриде, maxpage
         * За каждый грид отвечает ОДНА функция, вбирающая в себя значения с формы(под гридом) как параметры функции
         * Так как пагинация уже была зашита в метод то на форме возникали некорректности
         * Я решил эту проблему перегрузкой этих методов без параметров пагинации для подсчета maxpage
         * Как видно ниже сначала вызывается метод без пагинации для подсчета maxpage
         * А далее уже с пагинацией, все нормально отображается
         * 
         * Проблема с пагинацией 2
         * Под гридом имеется счетчик страниц
         * Для его корректного отображения были написаны множественные проверки
         * Я не знаю как решить проблему по другому и из за этого код становится грязным
         * Да, работает, но я думаю эту проблему можно решить более профессионально
         */
                        

        #region Employee
        ////////////////////////////////// EMPLOYEE \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        // FindAll работников, вбирающий в себя дефолтные значения полей из загруженной формы  
        // А так же измененные значения полей при поиске/фильтрации/сортировке работников
        public void DefaultGridWithEmployees()
        {
            dataGridEmployee.Rows.Clear();

            int records = countRecords;

            Person patient = new Person();
            Person person = new Person();
            if (textBox4.Text != "" && textBox4.Text != "Фамилия")
            {
                person.Surname = textBox4.Text;
            }
            if (textBox11.Text != "" && textBox11.Text != "Имя")
            {
                person.Name = textBox11.Text;
            }
            if (textBox13.Text != "" && textBox13.Text != "Отчество")
            {
                person.Patronymic = textBox13.Text;
            }
            if (textBox14.Text != "" && textBox14.Text != "Телефон")
            {
                person.Phone = textBox14.Text;
            }
            Drug drug = new Drug();

            bool checkCreate1 = checkBox38.Checked;
            bool checkCreate2 = checkBox39.Checked;
            bool checkEdit1 = checkBox40.Checked;
            bool checkEdit2 = checkBox41.Checked;
            bool doct = checkBox1.Checked;
            bool nurs = checkBox2.Checked;

            DateTime create1 = dateTimePicker1.Value;
            DateTime create2 = dateTimePicker2.Value;
            DateTime edit1 = dateTimePicker5.Value;
            DateTime edit2 = dateTimePicker6.Value;

            // Перегруженный метод без пареметров пагинации
            // Для подсчета maxpage
            List<Person> e = OperationsOfPersons.FindAllEmployee(doct, nurs, person, patient, drug, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2);
            maxpage = e.Count() / records;

            // Множество проверок пагинации, учитывающие все случаи
            // Чтобы не возникли ошибки
            if (e.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 - добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей вообще нет - будет 1 страница

            if (currentPage < maxpage) { button24.Enabled = true; } // Если текущая выбранная страница < максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая страница > максимальной, они приравнимаются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button24.Enabled = false;
            }
            if (currentPage == maxpage) { button24.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button19.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label34.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<Person> emp = OperationsOfPersons.FindAllEmployee(doct, nurs, person, patient, drug, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2, currentPage, records);

            foreach (Person p in emp)
            {
                dataGridEmployee.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, ClinicApp.Model.Roles.RoleID(p.Role).Name, p.DateOfCreate, p.DateOfEdit);
            }
        }        

        // Кнопка переключения страниц назад <<
        private void button19_Click(object sender, EventArgs e)
        {
            button24.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button19.Enabled = false;
            }
            DefaultGridWithEmployees();
            label34.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        // Кнопка переключения страниц вперед >>
        private void button24_Click(object sender, EventArgs e)
        {
            button19.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button24.Enabled = false;
            }
            DefaultGridWithEmployees();
            label34.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        // Кнопка добавления работника
        private void EmployeeAddButton_Click(object sender, EventArgs e)
        {
            Card_Employee emp = new Card_Employee();
            emp.ShowDialog();
            DefaultGridWithEmployees(); // Вызываем метод для авто обновления грида
        }

        // Двойной клик по любой строке
        private void dataGridEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Удаление записи при клике по кнопке удаления
            if (e.ColumnIndex == 8)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridEmployee.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        const string message = "Хотите удалить работника?";
                        const string caption = "Удаление";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            // Выдергивание id работника из строки
                            int k = Convert.ToInt32(dataGridEmployee.Rows[l].Cells[0].Value);
                            // Удаление этой строки из грида
                            dataGridEmployee.Rows.Remove(dataGridEmployee.Rows[l]);
                            // Удаление работника с найденным id из БД
                            OperationsOfPersons.Del(k);
                            DefaultGridWithEmployees();
                            // Авто удаление планов лечения этого врача
                            AllPlans();
                            // Авто удаление выдачи лекарств этой медсестры
                            AllDispensing();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
            // Открытие карточки работника при клике везде кроме кнопки удаления
            else
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridEmployee.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id работника из строки
                        int k = Convert.ToInt32(dataGridEmployee.Rows[l].Cells[0].Value);
                        // Вызов конструктора формы с данными строки(работника) на которую мы кликнули объектом главной формы
                        InfoForm.Info_Employee f = new InfoForm.Info_Employee(OperationsOfPersons.FindByID(k));
                        f.ShowDialog();
                        DefaultGridWithEmployees(); // Авто обновления грида
                    }
                }
            }
        }

        // Кнопка обновления DataGrid работников(при изменении значений полей формы)
        private void ResetButton_Employee_Click(object sender, EventArgs e)
        {
            DefaultGridWithEmployees();
        }

        // Place holder для поля "Фамилия"
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Фамилия")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Фамилия";
                textBox4.ForeColor = Color.Gray;
            }
        }

        // Place holder для поля "Имя"
        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Text == "Имя")
            {
                textBox11.Text = "";
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                textBox11.Text = "Имя";
                textBox11.ForeColor = Color.Gray;
            }
        }

        // Place holder для поля "Отчество"
        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Text == "Отчество")
            {
                textBox13.Text = "";
                textBox13.ForeColor = Color.Black;
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                textBox13.Text = "Отчество";
                textBox13.ForeColor = Color.Gray;
            }
        }

        // Place holder для поля "Телефон"
        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Text == "Телефон")
            {
                textBox14.Text = "";
                textBox14.ForeColor = Color.Black;
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                textBox14.Text = "Телефон";
                textBox14.ForeColor = Color.Gray;
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox38.Checked == false)
            {                
                dateTimePicker1.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox39.Checked == false)
            {                
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker2.Enabled = true;
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox40.Checked == false)
            {                
                dateTimePicker5.Enabled = false;
            }
            else
            {
                dateTimePicker5.Enabled = true;
            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox41.Checked == false)
            {                
                dateTimePicker6.Enabled = false;
            }
            else
            {
                dateTimePicker6.Enabled = true;
            }
        }
        #endregion

        #region Patient
        ////////////////////////////////// PATIENT \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public void GridWithPatients()
        {
            dataGridView2.Rows.Clear();

            int records = countRecords;

            Person doctor = new Person();
            Person nurse = new Person();
            Person person = new Person();
            if (textBox34.Text != "" && textBox34.Text != "Фамилия")
            {
                person.Surname = textBox34.Text;
            }
            if (textBox35.Text != "" && textBox35.Text != "Имя")
            {
                person.Name = textBox35.Text;
            }
            if (textBox36.Text != "" && textBox36.Text != "Отчество")
            {
                person.Patronymic = textBox36.Text;
            }
            if (textBox37.Text != "" && textBox37.Text != "Телефон")
            {
                person.Phone = textBox37.Text;
            }
            Drug drug = new Drug();

            bool checkCreate1 = checkBox8.Checked;
            bool checkCreate2 = checkBox7.Checked;
            bool checkEdit1 = checkBox44.Checked;
            bool checkEdit2 = checkBox43.Checked;

            DateTime create1 = dateTimePicker3.Value;
            DateTime create2 = dateTimePicker4.Value;
            DateTime edit1 = dateTimePicker7.Value;
            DateTime edit2 = dateTimePicker8.Value;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<Person> pn = OperationsOfPersons.FindAllPatient(person, doctor, nurse, drug, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2);
            maxpage = pn.Count() / records;
            if (pn.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button10.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button10.Enabled = false;
            }
            if (currentPage == maxpage) { button10.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button11.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label38.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<Person> patient = OperationsOfPersons.FindAllPatient(person, doctor, nurse, drug, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2, currentPage, records);

            foreach (Person p in patient)
            {
                dataGridView2.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.DateOfCreate, p.DateOfEdit);
            }
        }        

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Удаление записи при клике по кнопке удаления
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView2.RowCount - 1 >= e.RowIndex)
                    {
                        int l = e.RowIndex; // Находим индекс строки, где был клик
                        const string message = "Хотите удалить пациента?";
                        const string caption = "Удаление";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            int k = Convert.ToInt32(dataGridView2.Rows[l].Cells[0].Value); // Выдергивание id пациента из строки
                            dataGridView2.Rows.Remove(dataGridView2.Rows[l]); // Удаление этой строки из грида                            
                            OperationsOfPersons.Del(k); // Удаление пацинта с найденным id из БД
                            AllPlans(); // Авто удаление планов лечения этого пациента
                            GridWithPatients();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
            // Открытие карточки пациента при клике везде кроме кнопки удаления
            else
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView2.RowCount - 1 >= e.RowIndex)
                    {
                        int l = e.RowIndex; // Находим индекс строки, где был клик
                        int k = Convert.ToInt32(dataGridView2.Rows[l].Cells[0].Value); // Выдергивание id пациента из строки
                        InfoForm.Info_Patient f = new InfoForm.Info_Patient(OperationsOfPersons.FindByID(k)); // Вызов конструктора формы с данными строки(пациента) на которую мы кликнули
                        f.ShowDialog();
                        GridWithPatients(); // Обновление грида пациентов
                    }
                }
            }
        }
        // Кнопка добавления
        private void button9_Click(object sender, EventArgs e)
        {
            Card_Patient patient = new Card_Patient();
            patient.ShowDialog();
            GridWithPatients(); // Обновление грида пациентов
        }
        // Кнопка обновления грида с изменившимися параметрами
        private void button8_Click(object sender, EventArgs e)
        {
            GridWithPatients();
        }

        // Place holder для поля "Фамилия" на гриде пациентов
        private void textBox34_Enter(object sender, EventArgs e)
        {
            if (textBox34.Text == "Фамилия")
            {
                textBox34.Text = "";
                textBox34.ForeColor = Color.Black;
            }
        }
        private void textBox34_Leave(object sender, EventArgs e)
        {
            if (textBox34.Text == "")
            {
                textBox34.Text = "Фамилия";
                textBox34.ForeColor = Color.Gray;
            }
        }

        // Place holder для поля "Имя" на гриде пациентов
        private void textBox35_Enter(object sender, EventArgs e)
        {
            if (textBox35.Text == "Имя")
            {
                textBox35.Text = "";
                textBox35.ForeColor = Color.Black;
            }
        }
        private void textBox35_Leave(object sender, EventArgs e)
        {
            if (textBox35.Text == "")
            {
                textBox35.Text = "Имя";
                textBox35.ForeColor = Color.Gray;
            }
        }

        // Place holder для поля "Отчество" на гриде пациентов
        private void textBox36_Enter(object sender, EventArgs e)
        {
            if (textBox36.Text == "Отчество")
            {
                textBox36.Text = "";
                textBox36.ForeColor = Color.Black;
            }
        }
        private void textBox36_Leave(object sender, EventArgs e)
        {
            if (textBox36.Text == "")
            {
                textBox36.Text = "Отчество";
                textBox36.ForeColor = Color.Gray;
            }
        }

        // Place holder для поля "Телефон" на гриде пациентов
        private void textBox37_Enter(object sender, EventArgs e)
        {
            if (textBox37.Text == "Телефон")
            {
                textBox37.Text = "";
                textBox37.ForeColor = Color.Black;
            }
        }
        private void textBox37_Leave(object sender, EventArgs e)
        {
            if (textBox37.Text == "")
            {
                textBox37.Text = "Телефон";
                textBox37.ForeColor = Color.Gray;
            }
        }
        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox8.Checked == false)
            {
                dateTimePicker3.Enabled = false;
            }
            else
            {
                dateTimePicker3.Enabled = true;
            }
        }

        private void checkBox7_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox7.Checked == false)
            {
                dateTimePicker4.Enabled = false;
            }
            else
            {
                dateTimePicker4.Enabled = true;
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox44.Checked == false)
            {
                dateTimePicker7.Enabled = false;
            }
            else
            {
                dateTimePicker7.Enabled = true;
            }
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox43.Checked == false)
            {
                dateTimePicker8.Enabled = false;
            }
            else
            {
                dateTimePicker8.Enabled = true;
            }
        }
        // Кнопка переключения страниц назад <<
        private void button11_Click(object sender, EventArgs e)
        {
            button10.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button11.Enabled = false;
            }
            GridWithPatients();
            label38.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка переключения страниц вперед >>
        private void button10_Click(object sender, EventArgs e)
        {
            button11.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button10.Enabled = false;
            }
            GridWithPatients();
            label38.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        #endregion

        #region TreatmentPlan
        public void AllPlans()
        {
            dataGridView3.Rows.Clear();

            int records = countRecords;

            TreatmentPlan plan = new TreatmentPlan();

            if (numericUpDown3.Value != 0)
            {
                plan.ID = (int)numericUpDown3.Value;
            }

            bool checkCreate1 = checkBox16.Checked;
            bool checkCreate2 = checkBox15.Checked;
            bool checkEdit1 = checkBox47.Checked;
            bool checkEdit2 = checkBox46.Checked;

            DateTime create1 = dateTimePicker9.Value;
            DateTime create2 = dateTimePicker10.Value;
            DateTime edit1 = dateTimePicker21.Value;
            DateTime edit2 = dateTimePicker22.Value;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<TreatmentPlan> pl = OperationsOfTreatmentPlans.FindAllPlan(plan, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2);
            maxpage = pl.Count() / records;
            if (pl.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button25.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button25.Enabled = false;
            }
            if (currentPage == maxpage) { button25.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button26.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label39.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<TreatmentPlan> plans = OperationsOfTreatmentPlans.FindAllPlan(plan, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2, currentPage, records);
            foreach (var t in plans)
            {
                dataGridView3.Rows.Add(t.ID, OperationsOfPersons.FindByID(t.AssignerDoctorID).Surname + " "
                    + OperationsOfPersons.FindByID(t.AssignerDoctorID).Name + " "
                    + OperationsOfPersons.FindByID(t.AssignerDoctorID).Patronymic,
                    OperationsOfPersons.FindByID(t.PatientID).Surname + " "
                    + OperationsOfPersons.FindByID(t.PatientID).Name + " "
                    + OperationsOfPersons.FindByID(t.PatientID).Patronymic,
                    t.DateOfCreate, t.DateOfEdit);
            }
        }

        public void Plans_Doctor()
        {
            dataGridView3.Rows.Clear();

            int records = countRecords;
            int docID = personID;

            TreatmentPlan plan = new TreatmentPlan();

            if (numericUpDown3.Value != 0)
            {
                plan.ID = (int)numericUpDown3.Value;
            }

            bool checkCreate1 = checkBox16.Checked;
            bool checkCreate2 = checkBox15.Checked;
            bool checkEdit1 = checkBox47.Checked;
            bool checkEdit2 = checkBox46.Checked;

            DateTime create1 = dateTimePicker9.Value;
            DateTime create2 = dateTimePicker10.Value;
            DateTime edit1 = dateTimePicker21.Value;
            DateTime edit2 = dateTimePicker22.Value;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<TreatmentPlan> pl = OperationsOfTreatmentPlans.Plans_Doctor(plan, docID, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2);
            maxpage = pl.Count() / records;
            if (pl.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button25.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button25.Enabled = false;
            }
            if (currentPage == maxpage) { button25.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button26.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label39.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<TreatmentPlan> plans = OperationsOfTreatmentPlans.Plans_Doctor(plan, docID, checkCreate1, checkCreate2, checkEdit1, checkEdit2, create1, create2, edit1, edit2, currentPage, records);
            foreach (var t in plans)
            {
                dataGridView3.Rows.Add(t.ID, OperationsOfPersons.FindByID(t.AssignerDoctorID).Surname + " "
                    + OperationsOfPersons.FindByID(t.AssignerDoctorID).Name + " "
                    + OperationsOfPersons.FindByID(t.AssignerDoctorID).Patronymic,
                    OperationsOfPersons.FindByID(t.PatientID).Surname + " "
                    + OperationsOfPersons.FindByID(t.PatientID).Name + " "
                    + OperationsOfPersons.FindByID(t.PatientID).Patronymic,
                    t.DateOfCreate, t.DateOfEdit);
            }
        }
        
        // Кнопка обновления гридов
        private void button20_Click(object sender, EventArgs e)
        {
            if (status == 2) { Plans_Doctor(); }
            else { AllPlans(); }

        }
        // Кнопка добавления плана
        private void button21_Click(object sender, EventArgs e)
        {
            if (status == 2)
            {
                Card_TreatmentPlan plan = new Card_TreatmentPlan();
                plan.ShowDialog();
                Plans_Doctor(); // Обновление грида
            }
            if (status == 6)
            {
                Card_TreatmentPlan plan = new Card_TreatmentPlan();
                plan.ShowDialog();
                AllPlans(); // Обновление грида
            }
        }
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Удаление записи при клике по кнопке удаления
            if (e.ColumnIndex == 5)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView3.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        const string message = "Хотите удалить план лечения?";
                        const string caption = "Удаление";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            // Выдергивание id работника из строки
                            int k = Convert.ToInt32(dataGridView3.Rows[l].Cells[0].Value);
                            // Удаление этой строки из грида
                            dataGridView3.Rows.Remove(dataGridView3.Rows[l]);
                            // Удаление работника с найденным id из БД
                            OperationsOfPersons.Del(k);
                            if (status == 2)
                            {
                                Pres_Doctor();
                                Dis_Doctor();
                            }
                            else
                            {
                                AllPrescription();
                                AllDispensing();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
            // Открытие карточки плана при клике везде кроме кнопки удаления
            else
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView3.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id работника из строки
                        int k = Convert.ToInt32(dataGridView3.Rows[l].Cells[0].Value);
                        //int p = Convert.ToInt32(dataGridView4.Rows[l].Cells[2].Value);
                        // Вызов конструктора формы с данными строки(работника) на которую мы кликнули объектом главной формы
                        InfoForm.Info_TreatmentPlan f = new InfoForm.Info_TreatmentPlan(OperationsOfTreatmentPlans.FindByID(k));
                        f.ShowDialog();
                        if (status == 2) 
                        { 
                            Plans_Doctor();
                            Pres_Doctor();
                        }
                        else 
                        { 
                            AllPlans();
                            AllPrescription();
                        }
                    }
                }
            }
        }
        private void checkBox16_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox16.Checked == false) { dateTimePicker9.Enabled = false; }
            else { dateTimePicker9.Enabled = true; }
        }

        private void checkBox15_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox15.Checked == false) { dateTimePicker10.Enabled = false; }
            else { dateTimePicker10.Enabled = true; }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox47.Checked == false) { dateTimePicker21.Enabled = false; }
            else { dateTimePicker21.Enabled = true; }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox46.Checked == false) { dateTimePicker22.Enabled = false; }
            else { dateTimePicker22.Enabled = true; }
        }
        // Кнопки пагинации
        // НАЗАД
        private void button26_Click(object sender, EventArgs e)
        {
            button25.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button26.Enabled = false;
            }
            if (status == 2) { Plans_Doctor(); }
            else { AllPlans(); }
            label39.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        // ВПЕРЕД
        private void button25_Click(object sender, EventArgs e)
        {
            button26.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button25.Enabled = false;
            }
            if (status == 2) { Plans_Doctor(); }
            else { AllPlans(); }
            label39.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        #endregion

        #region Prescription
        public void AllPrescription()
        {
            dataGridView4.Rows.Clear();

            int records = countRecords;

            PrescriptionOfDrug pres = new PrescriptionOfDrug();

            if (numericUpDown4.Value != 0)
            {
                pres.ID = (int)numericUpDown4.Value;
            }

            bool checkCreate1 = checkBox22.Checked;
            bool checkEdit1 = checkBox50.Checked;
            bool checkStartTake1 = checkBox52.Checked;
            bool checkFinishTake1 = checkBox24.Checked;
            bool checkCreate2 = checkBox21.Checked;
            bool checkEdit2 = checkBox49.Checked;
            bool checkStartTake2 = checkBox51.Checked;
            bool checkFinishTake2 = checkBox23.Checked;

            DateTime create1 = dateTimePicker11.Value;
            DateTime create2 = dateTimePicker12.Value;
            DateTime edit1 = dateTimePicker15.Value;
            DateTime edit2 = dateTimePicker16.Value;
            DateTime startTake1 = dateTimePicker25.Value;
            DateTime startTake2 = dateTimePicker26.Value;
            DateTime finishTake1 = dateTimePicker23.Value;
            DateTime finishTake2 = dateTimePicker24.Value;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<PrescriptionOfDrug> pr = OperationsOfPrescriptionsOfDrugs.FindAllPrescription(pres, checkCreate1, checkCreate2, checkEdit1, checkEdit2,
                checkStartTake1, checkStartTake2, checkFinishTake1, checkFinishTake2, create1, create2, edit1, edit2, startTake1, startTake2,
                finishTake1, finishTake2);

            maxpage = pr.Count() / records;
            if (pr.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button27.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button27.Enabled = false;
            }
            if (currentPage == maxpage) { button27.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button28.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label40.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<PrescriptionOfDrug> prescription = OperationsOfPrescriptionsOfDrugs.FindAllPrescription(pres, checkCreate1, checkCreate2, checkEdit1, checkEdit2,
                checkStartTake1, checkStartTake2, checkFinishTake1, checkFinishTake2, create1, create2, edit1, edit2, startTake1, startTake2,
                finishTake1, finishTake2, currentPage, records);
            foreach (var t in prescription)
            {
                dataGridView4.Rows.Add(t.ID, t.PlanID, OperationsOfDrugs.FindByID(t.DrugID).Name, t.Quantity, t.StartTimeOfTaken, t.FinishTimeOfTaken, t.DateOfCreate, t.DateOfEdit);
            }
        }

        public void Pres_Doctor()
        {
            dataGridView4.Rows.Clear();

            int records = countRecords;
            int docID = personID;

            PrescriptionOfDrug pres = new PrescriptionOfDrug();

            if (numericUpDown4.Value != 0)
            {
                pres.ID = (int)numericUpDown4.Value;
            }

            bool checkCreate1 = checkBox22.Checked;
            bool checkEdit1 = checkBox50.Checked;
            bool checkStartTake1 = checkBox52.Checked;
            bool checkFinishTake1 = checkBox24.Checked;
            bool checkCreate2 = checkBox21.Checked;
            bool checkEdit2 = checkBox49.Checked;
            bool checkStartTake2 = checkBox51.Checked;
            bool checkFinishTake2 = checkBox23.Checked;

            DateTime create1 = dateTimePicker11.Value;
            DateTime create2 = dateTimePicker12.Value;
            DateTime edit1 = dateTimePicker15.Value;
            DateTime edit2 = dateTimePicker16.Value;
            DateTime startTake1 = dateTimePicker25.Value;
            DateTime startTake2 = dateTimePicker26.Value;
            DateTime finishTake1 = dateTimePicker23.Value;
            DateTime finishTake2 = dateTimePicker24.Value;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<PrescriptionOfDrug> pr = OperationsOfPrescriptionsOfDrugs.Pres_Doctor(pres, docID, checkCreate1, checkCreate2, checkEdit1, checkEdit2,
                checkStartTake1, checkStartTake2, checkFinishTake1, checkFinishTake2, create1, create2, edit1, edit2, startTake1, startTake2,
                finishTake1, finishTake2);

            maxpage = pr.Count() / records;
            if (pr.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button27.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button27.Enabled = false;
            }
            if (currentPage == maxpage) { button27.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button28.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label40.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<PrescriptionOfDrug> prescription = OperationsOfPrescriptionsOfDrugs.Pres_Doctor(pres, docID, checkCreate1, checkCreate2, checkEdit1, checkEdit2,
                checkStartTake1, checkStartTake2, checkFinishTake1, checkFinishTake2, create1, create2, edit1, edit2, startTake1, startTake2,
                finishTake1, finishTake2, currentPage, records);
            foreach (var t in prescription)
            {
                dataGridView4.Rows.Add(t.ID, t.PlanID, OperationsOfDrugs.FindByID(t.DrugID).Name, t.Quantity, t.StartTimeOfTaken, t.FinishTimeOfTaken, t.DateOfCreate, t.DateOfEdit);
            }
        }
        
        // Кнопка обновить
        private void button23_Click(object sender, EventArgs e)
        {
            if (status == 2) { Pres_Doctor(); }
            else { AllPrescription(); }

        }
        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Удаление записи при клике по кнопке удаления
            if (e.ColumnIndex == 8)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView5.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        const string message = "Хотите удалить назначение лекарства?";
                        const string caption = "Удаление";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            // Выдергивание id назначения из строки
                            int k = Convert.ToInt32(dataGridView4.Rows[l].Cells[0].Value);
                            // Удаление этой строки из грида
                            dataGridView5.Rows.Remove(dataGridView4.Rows[l]);
                            // Удаление назначения с найденным id из БД
                            OperationsOfPersons.Del(k);
                            if (status == 2) 
                            { 
                                Pres_Doctor();
                                Dis_Doctor();
                            }
                            else 
                            { 
                                AllPrescription();
                                AllDispensing();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
            // Открытие карточки назначения при клике везде кроме кнопки удаления
            else
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView4.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id назначения из строки
                        int k = Convert.ToInt32(dataGridView4.Rows[l].Cells[0].Value);
                        //int p = Convert.ToInt32(dataGridView4.Rows[l].Cells[2].Value);
                        // Вызов конструктора формы с данными строки(назначения) на которую мы кликнули объектом главной формы
                        InfoForm.Info_Prescription f = new InfoForm.Info_Prescription(OperationsOfPrescriptionsOfDrugs.FindByID(k));
                        f.ShowDialog();
                        if (status == 2)
                        {
                            Pres_Doctor();
                            Dis_Doctor();
                        }
                        else
                        {
                            AllPrescription();
                            AllDispensing();
                        }
                    }
                }
            }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            button27.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button28.Enabled = false;
            }
            if (status == 2) { Pres_Doctor(); }
            else { AllPrescription(); }

            label40.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            button28.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button27.Enabled = false;
            }
            if (status == 2) { Pres_Doctor(); }
            else { AllPrescription(); }
            label40.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == false) { dateTimePicker11.Enabled = false; }
            else { dateTimePicker11.Enabled = true; }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == false) { dateTimePicker12.Enabled = false; }
            else { dateTimePicker12.Enabled = true; }
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox50.Checked == false) { dateTimePicker15.Enabled = false; }
            else { dateTimePicker15.Enabled = true; }
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox49.Checked == false) { dateTimePicker16.Enabled = false; }
            else { dateTimePicker16.Enabled = true; }
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox52.Checked == false) { dateTimePicker25.Enabled = false; }
            else { dateTimePicker25.Enabled = true; }
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox51.Checked == false) { dateTimePicker26.Enabled = false; }
            else { dateTimePicker26.Enabled = true; }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == false) { dateTimePicker23.Enabled = false; }
            else { dateTimePicker23.Enabled = true; }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == false) { dateTimePicker24.Enabled = false; }
            else { dateTimePicker24.Enabled = true; }
        }
        #endregion

        #region Dispensing
        public void AllDispensing()
        {
            dataGridView5.Rows.Clear();

            int records = countRecords;

            DispensingDrug dis = new DispensingDrug();

            if (numericUpDown5.Value != 0)
            {
                dis.ID = (int)numericUpDown5.Value;
            }

            bool checkCreate1 = checkBox29.Checked;
            bool checkEdit1 = checkBox53.Checked;
            bool checkTake1 = checkBox55.Checked;
            bool checkCreate2 = checkBox28.Checked;
            bool checkEdit2 = checkBox30.Checked;
            bool checkTake2 = checkBox54.Checked;

            DateTime create1 = dateTimePicker13.Value;
            DateTime create2 = dateTimePicker14.Value;
            DateTime edit1 = dateTimePicker17.Value;
            DateTime edit2 = dateTimePicker18.Value;
            DateTime take1 = dateTimePicker19.Value;
            DateTime take2 = dateTimePicker20.Value;

            bool statusTrue = checkBox4.Checked;
            bool statusFalse = checkBox5.Checked;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<DispensingDrug> disp = OperationsOfDispensingDrugs.FindAllDispensing(dis, checkCreate1, checkEdit1, checkTake1, checkCreate2, checkEdit2, checkTake2,
                create1, create2, edit1, edit2, take1, take2, statusTrue, statusFalse);

            maxpage = disp.Count() / records;
            if (disp.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button29.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button29.Enabled = false;
            }
            if (currentPage == maxpage) { button29.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button30.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<DispensingDrug> dispensing = OperationsOfDispensingDrugs.FindAllDispensing(dis, checkCreate1, checkEdit1, checkTake1, checkCreate2, checkEdit2, checkTake2,
                create1, create2, edit1, edit2, take1, take2, statusTrue, statusFalse, currentPage, records);
            foreach (var t in dispensing)
            {
                if (t.NurseID.HasValue)
                {
                    dataGridView5.Rows.Add(t.ID, OperationsOfPersons.FindByID(t.NurseID.Value).Surname + " "
                    + OperationsOfPersons.FindByID(t.NurseID.Value).Name + " "
                    + OperationsOfPersons.FindByID(t.NurseID.Value).Patronymic,
                    t.PrescriptionID, t.TreatmentPlanID, t.Dosage, t.TimeOfTakeDispense, t.DateOfCreate, t.DateOfEdit, t.Status);
                }
                else
                {
                    dataGridView5.Rows.Add(t.ID, "",
                    t.PrescriptionID, t.TreatmentPlanID, t.Dosage, t.TimeOfTakeDispense, t.DateOfCreate, t.DateOfEdit, t.Status);
                }

            }
        }

        public void Dis_Doctor()
        {
            dataGridView5.Rows.Clear();

            int records = countRecords;
            int docID = personID;

            DispensingDrug dis = new DispensingDrug();

            if (numericUpDown5.Value != 0)
            {
                dis.ID = (int)numericUpDown5.Value;
            }

            bool checkCreate1 = checkBox29.Checked;
            bool checkEdit1 = checkBox53.Checked;
            bool checkTake1 = checkBox55.Checked;
            bool checkCreate2 = checkBox28.Checked;
            bool checkEdit2 = checkBox30.Checked;
            bool checkTake2 = checkBox54.Checked;

            DateTime create1 = dateTimePicker13.Value;
            DateTime create2 = dateTimePicker14.Value;
            DateTime edit1 = dateTimePicker17.Value;
            DateTime edit2 = dateTimePicker18.Value;
            DateTime take1 = dateTimePicker19.Value;
            DateTime take2 = dateTimePicker20.Value;

            bool statusTrue = checkBox4.Checked;
            bool statusFalse = checkBox5.Checked;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<DispensingDrug> disp = OperationsOfDispensingDrugs.Dispensing_Doctor(dis, docID, checkCreate1, checkEdit1, checkTake1, checkCreate2, checkEdit2, checkTake2,
                create1, create2, edit1, edit2, take1, take2, statusTrue, statusFalse);

            maxpage = disp.Count() / records;
            if (disp.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button29.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button29.Enabled = false;
            }
            if (currentPage == maxpage) { button29.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button30.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<DispensingDrug> dispensing = OperationsOfDispensingDrugs.Dispensing_Doctor(dis, docID, checkCreate1, checkEdit1, checkTake1, checkCreate2, checkEdit2, checkTake2,
                create1, create2, edit1, edit2, take1, take2, statusTrue, statusFalse, currentPage, records);
            foreach (var t in dispensing)
            {
                if (t.NurseID.HasValue)
                {
                    dataGridView5.Rows.Add(t.ID, OperationsOfPersons.FindByID(t.NurseID.Value).Surname + " "
                        + OperationsOfPersons.FindByID(t.NurseID.Value).Name + " "
                        + OperationsOfPersons.FindByID(t.NurseID.Value).Patronymic,
                        t.PrescriptionID, t.TreatmentPlanID, t.Dosage, t.TimeOfTakeDispense, t.DateOfCreate, t.DateOfEdit, t.Status);
                }
                else
                {
                    dataGridView5.Rows.Add(t.ID, "",
                        t.PrescriptionID, t.TreatmentPlanID, t.Dosage, t.TimeOfTakeDispense, t.DateOfCreate, t.DateOfEdit, t.Status);
                }
            }
        }      


        // Кнопка обновить
        private void button32_Click(object sender, EventArgs e)
        {
            if (status == 2) { Dis_Doctor(); }
            else { AllDispensing(); }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Удаление записи при клике по кнопке удаления
            if (e.ColumnIndex == 9)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView5.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        const string message = "Хотите удалить событие выдачи лекарства?";
                        const string caption = "Удаление";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            // Выдергивание id события из строки
                            int k = Convert.ToInt32(dataGridView5.Rows[l].Cells[0].Value);
                            // Удаление этой строки из грида
                            dataGridView5.Rows.Remove(dataGridView5.Rows[l]);
                            // Удаление события с найденным id из БД
                            OperationsOfDispensingDrugs.Del(k);
                            if (status == 2) { Dis_Doctor(); }
                            else { AllDispensing(); }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
            // Открытие карточки события при клике везде кроме кнопки удаления
            else
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView5.RowCount - 1 >= e.RowIndex)
                    {
                        // Находим индекс строки, где был клик
                        int l = e.RowIndex;
                        // Выдергивание id работника из строки
                        int k = Convert.ToInt32(dataGridView5.Rows[l].Cells[0].Value);
                        //int p = Convert.ToInt32(dataGridView5.Rows[l].Cells[2].Value);
                        // Вызов конструктора формы с данными строки(работника) на которую мы кликнули объектом главной формы
                        InfoForm.Info_DispensingDrug f = new InfoForm.Info_DispensingDrug(OperationsOfDispensingDrugs.FindByID(k));
                        f.ShowDialog();
                        if (status == 2) { Dis_Doctor(); }
                        else { AllDispensing(); }
                    }
                }
            }
        }
        private void button30_Click(object sender, EventArgs e)
        {
            button29.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button30.Enabled = false;
            }
            if (status == 2) { Dis_Doctor(); }
            else { AllDispensing(); }
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            button30.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button29.Enabled = false;
            }
            if (status == 2) { Dis_Doctor(); }
            else { AllDispensing(); }
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        private void checkBox29_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox29.Checked == false) { dateTimePicker13.Enabled = false; }
            else { dateTimePicker13.Enabled = true; }
        }

        private void checkBox28_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox28.Checked == false) { dateTimePicker14.Enabled = false; }
            else { dateTimePicker14.Enabled = true; }
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox53.Checked == false) { dateTimePicker17.Enabled = false; }
            else { dateTimePicker17.Enabled = true; }
        }

        private void checkBox30_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox30.Checked == false) { dateTimePicker18.Enabled = false; }
            else { dateTimePicker18.Enabled = true; }
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox55.Checked == false) { dateTimePicker19.Enabled = false; }
            else { dateTimePicker19.Enabled = true; }
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox54.Checked == false) { dateTimePicker20.Enabled = false; }
            else { dateTimePicker20.Enabled = true; }
        }
        #endregion

        #region Drugs

        public void AllDrug()
        {
            dataGridView6.Rows.Clear();

            int records = countRecords;

            Drug drug = new Drug();
            if (textBox76.Text != "" && textBox76.Text != "Название")
            {
                drug.Name = textBox76.Text;
            }

            bool checkQuantity1 = checkBox11.Checked;
            bool checkCreate1 = checkBox57.Checked;
            bool checkEdit1 = checkBox6.Checked;
            bool checkQuantity2 = checkBox58.Checked;
            bool checkCreate2 = checkBox56.Checked;
            bool checkEdit2 = checkBox3.Checked;

            DateTime create1 = dateTimePicker31.Value;
            DateTime create2 = dateTimePicker32.Value;
            DateTime edit1 = dateTimePicker27.Value;
            DateTime edit2 = dateTimePicker28.Value;
            decimal quantity1 = numericUpDown1.Value;
            decimal quantity2 = numericUpDown2.Value;

            // Перегруженный метод без параметров пагинации
            // Для подсчета maxpage
            List<Drug> dr = OperationsOfDrugs.FindAllDrug(drug, checkCreate1, checkEdit1, checkQuantity1, checkCreate2, checkEdit2, checkQuantity2, quantity1, quantity2, create1, create2, edit1, edit2);

            maxpage = dr.Count() / records;
            if (dr.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 или 5 то добавляется еще 1 страница

            if (maxpage == 0) { maxpage++; } // Если записей нет - будет 1 страница

            if (currentPage < maxpage) { button31.Enabled = true; } // Если текущая выбранная страница меньше максимальной - активация кнопки ВПЕРЕД

            if (currentPage > maxpage) // Если текущая выбранная страница больше максимальной, они приравниваются, дезоктивация кнопки ВПЕРЕД
            {
                currentPage = maxpage;
                button31.Enabled = false;
            }
            if (currentPage == maxpage) { button31.Enabled = false; } // Если текущая страница = максимальной, дезоктивация кнопки ВПЕРЕД

            if (currentPage == 1) { button33.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

            label42.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;

            // Метод с пагинацией
            List<Drug> drugs = OperationsOfDrugs.FindAllDrug(drug, checkCreate1, checkEdit1, checkQuantity1, checkCreate2, checkEdit2, checkQuantity2, quantity1, quantity2, create1, create2, edit1, edit2, currentPage, records);
            foreach (Drug p in drugs)
            {
                dataGridView6.Rows.Add(p.ID, p.Name, p.Quantity, p.Measure, p.DateOfCreate, p.DateOfEdit);
            }
        }       

        // Place holder для поля "Название"
        private void textBox76_Enter(object sender, EventArgs e)
        {
            if (textBox76.Text == "Название")
            {
                textBox76.Text = "";
                textBox76.ForeColor = Color.Black;
            }
        }
        private void textBox76_Leave(object sender, EventArgs e)
        {
            if (textBox76.Text == "")
            {
                textBox76.Text = "Название";
                textBox76.ForeColor = Color.Gray;
            }
        }

        // Кнопка "Обновить грид"
        private void button39_Click(object sender, EventArgs e)
        {
            AllDrug();
        }

        // Кнопка "Добавить"
        private void button40_Click(object sender, EventArgs e)
        {
            Card_Drug drug = new Card_Drug();
            drug.ShowDialog();
            AllDrug();
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Удаление записи при клике по кнопке удаления
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView6.RowCount - 1 >= e.RowIndex)
                    {
                        int l = e.RowIndex; // Находим индекс строки, где был клик
                        const string message = "Хотите удалить лекарство?";
                        const string caption = "Удаление";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            int k = Convert.ToInt32(dataGridView6.Rows[l].Cells[0].Value); // Выдергивание id лекарства из строки
                            dataGridView6.Rows.Remove(dataGridView6.Rows[l]); // Удаление этой строки из грида                            
                            OperationsOfDrugs.Del(k); // Удаление лекарства с найденным id из БД
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
            // Открытие карточки лекарства при клике везде кроме кнопки удаления
            else
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView6.RowCount - 1 >= e.RowIndex)
                    {
                        int l = e.RowIndex; // Находим индекс строки, где был клик
                        int k = Convert.ToInt32(dataGridView6.Rows[l].Cells[0].Value); // Выдергивание id лекарства из строки
                        InfoForm.Info_Drug f = new InfoForm.Info_Drug(OperationsOfDrugs.FindByID(k)); // Вызов конструктора формы с данными строки(лекарства) на которую мы кликнули
                        f.ShowDialog();
                        AllDrug(); // Авто обновление грида
                    }
                }
            }
        }
        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox57.Checked == false) { dateTimePicker31.Enabled = false; }
            else { dateTimePicker31.Enabled = true; }
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox56.Checked == false) { dateTimePicker32.Enabled = false; }
            else { dateTimePicker32.Enabled = true; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == false) { dateTimePicker27.Enabled = false; }
            else { dateTimePicker27.Enabled = true; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false) { dateTimePicker28.Enabled = false; }
            else { dateTimePicker28.Enabled = true; }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == false) { numericUpDown1.Enabled = false; }
            else { numericUpDown1.Enabled = true; }
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox58.Checked == false) { numericUpDown2.Enabled = false; }
            else { numericUpDown2.Enabled = true; }
        }

        // Кнопки ВПЕРЕД и НАЗАД
        private void button33_Click(object sender, EventArgs e)
        {
            button31.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button33.Enabled = false;
            }
            AllDrug();
            label42.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            button33.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button31.Enabled = false;
            }
            AllDrug();
            label42.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        #endregion

        // Кнопка выхода из системы
        private void Exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Выйти?", "Выход из системы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Model.Singleton.delPerson();
                this.Hide();
                Authorization a = new Authorization();
                a.ShowDialog();
                this.Close();
            }
        }
    }
}

