using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicApp.InfoForm
{
    public partial class Info_TreatmentPlan : Form
    {        
        bool addBan = Model.Prohibition.Banned("pres_add"); // Перменная для хранения доступа к добавлению
        bool editBan = Model.Prohibition.Banned("plan_edit"); // Перменная для хранения доступа к редактированию
        bool delBan = Model.Prohibition.Banned("pres_del"); // Перменная для хранения доступа к удалению
        int status = ClinicApp.Model.Singleton.getPerson().Role;

        // Текущая страница записей на гриде, всегда первая
        public int currentPage = 1;
        // Максимальное количество страниц на гриде
        public int maxpage;
        // Экземпляр TreatmentPlan
        TreatmentPlan plan = new TreatmentPlan();


        public Info_TreatmentPlan(TreatmentPlan pl)
        {
            InitializeComponent();

            // передача плана лечения из грида главной формы
            plan = pl;
            // Ограничение функционала в зависимости от роли
            button24.Visible = addBan;
            button2.Visible = editBan;
            button3.Visible = editBan;
            button1.Visible = editBan;
            dataGridView4.Columns[8].Visible = delBan;

            // Бан полей врача
            textBox7.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            // Бан полей пациента
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;

            if (status == 2) { button1.Hide(); }

            // Находим ID врача и пациента для заполнения полей
            int d = plan.AssignerDoctorID;
            int p = plan.PatientID;

            // Заполняем поля
            textBox7.Text = Convert.ToString(OperationsOfPersons.FindByID(d).ID);
            textBox1.Text = Convert.ToString(OperationsOfPersons.FindByID(d).Surname);
            textBox2.Text = Convert.ToString(OperationsOfPersons.FindByID(d).Name);
            textBox3.Text = Convert.ToString(OperationsOfPersons.FindByID(d).Patronymic);

            textBox8.Text = Convert.ToString(OperationsOfPersons.FindByID(p).ID);
            textBox6.Text = Convert.ToString(OperationsOfPersons.FindByID(p).Surname);
            textBox5.Text = Convert.ToString(OperationsOfPersons.FindByID(p).Name);
            textBox4.Text = Convert.ToString(OperationsOfPersons.FindByID(p).Patronymic);

            PrescriptionGrid();
        }

        // Второй конструктор для форм с выбором врача и пациента(по другому не работает) и сисадмина
        public Info_TreatmentPlan()
        {
            InitializeComponent();
        }

        // Кнопка "Сохранить"
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "") // Проверка пациента
            {
                plan.AssignerDoctorID = Convert.ToInt32(textBox7.Text);
                plan.PatientID = Convert.ToInt32(textBox8.Text);

                OperationsOfTreatmentPlans.Edit(plan);
                MessageBox.Show("План лечения изменен");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
            }
            else { toolTip1.Show("Выберите пациента", button3, new Point(80, -29), 1000); }
        }

        // Кнопка добавления назначения лекарства
        private void button24_Click(object sender, EventArgs e)
        {
            Card_Prescription pres = new Card_Prescription(plan);
            pres.ShowDialog();
            // Вызываем метод для авто обновления грида
            PrescriptionGrid();
        }

        // Грид с назначениями лекарств
        public void PrescriptionGrid()
        {
            dataGridView4.Rows.Clear();

            // Количество записей на гриде
            int records = 10;

            using (Context db = new Context())
            {
                // Находим все записи
                var p = db.PrescriptionsOfDrugs.Where(x => x.PlanID == plan.ID && x.DateOfDelete == null).ToList();
                // Поиск максимального числа страниц
                maxpage = p.Count() / records;

                // Если записи ровно не делятся на 10 - добавляется еще 1 страница
                if (p.Count() % records != 0) { maxpage++; }

                // Если записей вообще нет - будет 1 страница
                if (maxpage == 0) { maxpage++; }

                // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД
                if (currentPage == maxpage) { button29.Enabled = false; }

                // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД
                if (currentPage == 1) { button30.Enabled = false; }

                // Если текущая выбранная страница > максимальной - активация кнопки ВПЕРЕД
                if (currentPage < maxpage) { button29.Enabled = true; }

                label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
            }

            List<PrescriptionOfDrug> pres = OperationsOfPrescriptionsOfDrugs.FindAllPrescription_Plan(plan, currentPage, records);

            foreach (var pr in pres)
            {
                dataGridView4.Rows.Add(pr.ID, pr.PlanID, OperationsOfDrugs.FindByID(pr.DrugID).Name, pr.Quantity, pr.StartTimeOfTaken, pr.FinishTimeOfTaken, pr.DateOfCreate, pr.DateOfEdit);
            }
        }

        // Кнопка смены страницы НАЗАД на гриде назначений данного плана
        private void button30_Click(object sender, EventArgs e)
        {
            button29.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button30.Enabled = false;
            }
            PrescriptionGrid();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде назначений данного плана
        private void button29_Click(object sender, EventArgs e)
        {
            button30.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button29.Enabled = false;
            }
            PrescriptionGrid();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Двойное нажатие на грид с назначениями - инфо карточка назначения
        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 8) // Просмотр назначения
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView4.RowCount - 1 >= e.RowIndex)
                    {
                        int l = e.RowIndex; // Находим индекс строки, где был клик
                        int k = Convert.ToInt32(dataGridView4.Rows[l].Cells[0].Value); // Выдергивание id назначения из строки
                        InfoForm.Info_Prescription f = new InfoForm.Info_Prescription(OperationsOfPrescriptionsOfDrugs.FindByID(k)); // Вызов конструктора формы с данными строки(назначения) на которую мы кликнули
                        f.ShowDialog();
                    }
                }
            }
            else // Удаление назначения
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView4.RowCount - 1 >= e.RowIndex)
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
                            dataGridView4.Rows.Remove(dataGridView4.Rows[l]);
                            // Удаление назначения с найденным id из БД
                            OperationsOfPrescriptionsOfDrugs.Del(k);
                            OperationsOfDispensingDrugs.HideDispensing_Prescription(k);
                            PrescriptionGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
        }

        // Кнопка выбора врача
        private void button1_Click(object sender, EventArgs e)
        {
            ChoiceForm.Choice_Doctor doc = new ChoiceForm.Choice_Doctor(this);
            doc.ShowDialog();
        }

        // Кнопка выбора пациента
        private void button3_Click(object sender, EventArgs e)
        {
            ChoiceForm.Choice_Patient pati = new ChoiceForm.Choice_Patient(this);
            pati.ShowDialog();
        }

        // Метод заполнения полей врача
        public void DoctorField(Person doctor)
        {
            textBox7.Text = Convert.ToString(doctor.ID);
            textBox1.Text = doctor.Surname;
            textBox2.Text = doctor.Name;
            textBox3.Text = doctor.Patronymic;
        }

        // Метод заполнения полей пациента
        public void PatientField(Person patient)
        {
            textBox8.Text = Convert.ToString(patient.ID);
            textBox6.Text = patient.Surname;
            textBox5.Text = patient.Name;
            textBox4.Text = patient.Patronymic;
        }

    }
}
