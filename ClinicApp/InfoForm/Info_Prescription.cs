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
    public partial class Info_Prescription : Form
    {
        public int currentPage = 1; // Текущая страница записей на гриде, всегда первая        
        public int maxpage; // Максимальное количество страниц на гриде

        PrescriptionOfDrug pres = new PrescriptionOfDrug(); // Экземпляр PrescriptionOfDrug

        bool addBan = Model.Prohibition.Banned("dis_add"); // Перменная для хранения доступа к добавлению
        bool editBan = Model.Prohibition.Banned("pres_edit"); // Перменная для хранения доступа к редактированию
        bool delBan = Model.Prohibition.Banned("dis_del"); // Перменная для хранения доступа к удалению

        //MainFormClinic main = new MainFormClinic();

        public Info_Prescription(PrescriptionOfDrug pr)
        {
            InitializeComponent();

            pres = pr; // Передача назначения лекарства из грида главной формы

            // Ограничение функционала в зависимости от роли
            button3.Visible = editBan;
            button2.Visible = editBan;
            button24.Visible = addBan;
            dataGridView5.Columns[9].Visible = delBan;

            textBox1.Text = Convert.ToString(pres.PlanID); // Передача ID плана лечения в textbox
            // Заполнение полей данными из грида главной формы
            int d = pres.DrugID;
            textBox3.Text = Convert.ToString(OperationsOfDrugs.FindByID(d).ID);
            textBox4.Text = Convert.ToString(OperationsOfDrugs.FindByID(d).Name);
            numericUpDown1.Value = (decimal)pres.Quantity;
            dateTimePicker1.Value = pres.StartTimeOfTaken;
            dateTimePicker2.Value = pres.FinishTimeOfTaken;

            // Бан полей
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            numericUpDown1.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            button1.Enabled = false;

            DispensingGrid();
        }

        // Второй конструктор нужный для формы выбора лекарства (по другому не работает)
        public Info_Prescription()
        {
            InitializeComponent();
        }

        // Кнопка "Сохранить"
        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0) // Единственная проверка количества лекарства
            {
                pres.DrugID = Convert.ToInt32(textBox3.Text);
                pres.PlanID = Convert.ToInt32(textBox1.Text);
                pres.Quantity = (int)numericUpDown1.Value;
                pres.StartTimeOfTaken = dateTimePicker1.Value;
                pres.FinishTimeOfTaken = dateTimePicker2.Value;

                OperationsOfPrescriptionsOfDrugs.Edit(pres);
                MessageBox.Show("Назначение лекарства изменено");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
            }
            else { toolTip1.Show("Введите количество лекарства", numericUpDown1, new Point(0, 20), 1000); }
        }

        // Кнопка добавления лекарства
        private void button1_Click(object sender, EventArgs e)
        {
            ChoiceForm.Choice_Drug drug = new ChoiceForm.Choice_Drug(this);
            drug.ShowDialog();
        }

        // Кнопка добавления события выдачи лекарства
        private void button24_Click(object sender, EventArgs e)
        {
            Card_Dispensing dis = new Card_Dispensing(pres);
            dis.ShowDialog();
            DispensingGrid();
        }

        // Заполнение полей лекарства (когда выбираем)
        public void DrugField(Drug drug)
        {
            textBox3.Text = Convert.ToString(drug.ID);
            textBox4.Text = drug.Name;
        }

        public void DispensingGrid()
        {
            dataGridView5.Rows.Clear();
            int records = 10; // Количество записей на гриде

            using (Context db = new Context())
            {
                // Находим все записи
                var d = db.DispensingDrugs.Where(x => x.PrescriptionID == pres.ID && x.DateOfDelete == null).ToList();

                maxpage = d.Count() / records; // Поиск максимального числа страниц

                if (d.Count() % records != 0) { maxpage++; } // Если записи ровно не делятся на 10 - добавляется еще 1 страница

                if (maxpage == 0) { maxpage++; } // Если записей вообще нет - будет 1 страница

                if (currentPage == maxpage) { button29.Enabled = false; } // Если текущая выбранная страница = максимальной - дезоктивация кнопки ВПЕРЕД

                if (currentPage == 1) { button30.Enabled = false; } // Если текущая выбранная страница = 1 - дезоктивация кнопки НАЗАД

                if (currentPage < maxpage) { button29.Enabled = true; } // Если текущая выбранная страница > максимальной - активация кнопки ВПЕРЕД

                label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
            }

            List<DispensingDrug> dis = OperationsOfDispensingDrugs.FindAllDispensing_Prescription(pres, currentPage, records);
                       
            foreach (var pr in dis)
            {
                if (pr.NurseID.HasValue)
                {
                    dataGridView5.Rows.Add(pr.ID, OperationsOfPersons.FindByID(pr.NurseID.Value).Surname + " "
                        + OperationsOfPersons.FindByID(pr.NurseID.Value).Name + " "
                        + OperationsOfPersons.FindByID(pr.NurseID.Value).Patronymic,
                        pr.PrescriptionID, pr.TreatmentPlanID, pr.Dosage, pr.TimeOfTakeDispense, pr.DateOfCreate, pr.DateOfEdit, pr.Status);
                }
                else
                {
                    dataGridView5.Rows.Add(pr.ID, "",
                        pr.PrescriptionID, pr.TreatmentPlanID, pr.Dosage, pr.TimeOfTakeDispense, pr.DateOfCreate, pr.DateOfEdit, pr.Status);
                }
            }
        }

        // Дабл клик по гриду событий выдачи лекарств
        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 9 && e.ColumnIndex != 8) // Просмотр карточки события выдачи
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView5.RowCount - 1 >= e.RowIndex)
                    {
                        int l = e.RowIndex; // Находим индекс строки, где был клик
                        int k = Convert.ToInt32(dataGridView5.Rows[l].Cells[0].Value); // Выдергивание id события из строки
                        InfoForm.Info_DispensingDrug f = new InfoForm.Info_DispensingDrug(OperationsOfDispensingDrugs.FindByID(k)); // Вызов конструктора формы с данными строки(события) на которую мы кликнули
                        f.ShowDialog();
                        DispensingGrid();
                    }
                }
            }
            else // Удаление события выдачи
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
                            DispensingGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эту строку нельзя удалить, в ней нет данных.");
                    }
                }
            }
        }

        // Кнопка смены страницы НАЗАД на гриде событий выдачи
        private void button30_Click(object sender, EventArgs e)
        {
            button29.Enabled = true;
            currentPage--;
            if (currentPage == 1)
            {
                button30.Enabled = false;
            }
            DispensingGrid();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }

        // Кнопка смены страницы ВПЕРЕД на гриде событий выдачи
        private void button29_Click(object sender, EventArgs e)
        {
            button30.Enabled = true;
            currentPage++;
            if (currentPage == maxpage)
            {
                button29.Enabled = false;
            }
            DispensingGrid();
            label41.Text = "Страница:" + Convert.ToString(currentPage) + "/" + maxpage;
        }
        // Кнопка Изменить
        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            numericUpDown1.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            button1.Enabled = true;
        }
    }
}
