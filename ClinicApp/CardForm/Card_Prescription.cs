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
    public partial class Card_Prescription : Form
    {
        PrescriptionOfDrug pres = new PrescriptionOfDrug(); // Экземпляр PrescriptionOfDrug
        TreatmentPlan pln = new TreatmentPlan(); // Экземпляр TreatmentPlan

        public Card_Prescription(TreatmentPlan pl)
        {
            pln = pl; // передача плана лечения из грида главной формы

            InitializeComponent();

            textBox1.Text = Convert.ToString(pln.ID); // Передача ID плана лечения в textbox
        }

        // Второй конструктор нужный для формы выбора лекарства (по другому не работает)
        public Card_Prescription()
        {
            InitializeComponent();
        }

        // Метод заполнения полей лекарства (когда выбираем)
        public void DrugField(Drug drug)
        {
            textBox3.Text = Convert.ToString(drug.ID);
            textBox4.Text = drug.Name;
        }

        // Кнопка "Сохранить"
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckField() == 2)
            {
                pres.DrugID = Convert.ToInt32(textBox3.Text);
                pres.PlanID = Convert.ToInt32(textBox1.Text);
                pres.Quantity = (int)numericUpDown1.Value;
                pres.StartTimeOfTaken = dateTimePicker1.Value;
                pres.FinishTimeOfTaken = dateTimePicker2.Value;

                OperationsOfPrescriptionsOfDrugs.Add(pres);
                MessageBox.Show("Назначение лекарства добавлено");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
            }            
        }

        // Кнопка выбора лекарства
        private void button1_Click(object sender, EventArgs e)
        {
            ChoiceForm.Choice_Drug drug = new ChoiceForm.Choice_Drug(this);
            drug.ShowDialog();
        }

        // Метод проверки полей, возвращает цифру 2, если все 2 поля проходят проверку
        // Если нет, то над полями не прошедшими проверку появляется надпись
        private int CheckField()
        {
            int check = 0;

            if (textBox3.Text != "") { check++; }
            else { toolTip1.Show("Выберите лекарство", button1, new Point(0, 20), 1000); }

            if (numericUpDown1.Value != 0) { check++; }
            else { toolTip2.Show("Введите количество", numericUpDown1, new Point(0, 20), 1000); }

            return check;
        }
    }
}
