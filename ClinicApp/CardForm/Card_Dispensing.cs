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
    public partial class Card_Dispensing : Form
    {                
        DispensingDrug dis = new DispensingDrug(); // Экземпляр DispensingDrug
        PrescriptionOfDrug pres = new PrescriptionOfDrug(); // Экземпляр PrescriptionOfDrug
        int status = ClinicApp.Model.Singleton.getPerson().Role;

        public Card_Dispensing(PrescriptionOfDrug prs)
        {
            pres = prs; // Передача назначения лекарства из грида главной формы
            //personRole = role;

            InitializeComponent();

            if (status != 6) { button3.Visible = false; }
            
            textBox1.Text = Convert.ToString(pres.PlanID);
            textBox3.Text = Convert.ToString(pres.ID);

        }

        // Заполнение полей медсестры!!!!!
        public void NurseField(Person nurse)
        {
            textBox7.Text = Convert.ToString(nurse.ID);
            textBox4.Text = nurse.Surname;
            textBox5.Text = nurse.Name;
            textBox6.Text = nurse.Patronymic;
        }

        // Кнопка выбора медсестры!!!!
        private void button3_Click(object sender, EventArgs e)
        {
            ChoiceForm.Choice_Nurse nurse = new ChoiceForm.Choice_Nurse(this);
            nurse.ShowDialog();
        }

        // Кнопка "Сохранить"
        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                dis.NurseID = null;
                dis.PrescriptionID = Convert.ToInt32(textBox3.Text);
                dis.TreatmentPlanID = Convert.ToInt32(textBox1.Text);
                dis.Dosage = (double)numericUpDown1.Value;
                dis.Status = Status.Checked;
                dis.TimeOfTakeDispense = Convert.ToDateTime(dateTimePicker1.Value.ToString("D") + " " + dateTimePicker2.Value.ToString("t"));

                OperationsOfDispensingDrugs.Add(dis);
                MessageBox.Show("Событие выдачи лекарства добавлено");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
            }
            else { toolTip1.Show("Введите количество лекарства", numericUpDown1, new Point(0, 20), 1000); }
        }
    }
}
