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
    public partial class Info_DispensingDrug : Form
    {                
        DispensingDrug dis = new DispensingDrug(); // Экземпляр DispensingDrug
        int status = ClinicApp.Model.Singleton.getPerson().Role; // Должность зашедшего в систему
        int nurID = ClinicApp.Model.Singleton.getPerson().ID; // ID зашедшего в систему

        bool editBan = Model.Prohibition.Banned("dis_edit"); // Перменная для хранения доступа к редактированию
        
        public Info_DispensingDrug(DispensingDrug ds)
        {
            InitializeComponent();

            // Бан полей
            textBox7.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            numericUpDown1.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            Status.Enabled = false;

            // Ограничение функционала
            button2.Visible = editBan;
            button1.Visible = editBan;

            dis = ds; // Передача назначения лекарства            

            if (status != 6) { button3.Hide(); }
            if (status == 3) 
            {
                Status.Enabled = true;
                button2.Hide(); 
            }

            // Заполнение всех полей
            if (dis.NurseID.HasValue) 
            { 
                textBox7.Text = Convert.ToString(dis.NurseID.Value);
                textBox4.Text = OperationsOfPersons.FindByID(dis.NurseID.Value).Surname;
                textBox5.Text = OperationsOfPersons.FindByID(dis.NurseID.Value).Name;
                textBox6.Text = OperationsOfPersons.FindByID(dis.NurseID.Value).Patronymic;
            }
            else
            {
                textBox7.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }                       
            
            numericUpDown1.Value = (decimal)dis.Dosage;
            textBox1.Text = Convert.ToString(dis.TreatmentPlanID);
            textBox3.Text = Convert.ToString(dis.PrescriptionID);

            string[] time = Convert.ToString(dis.TimeOfTakeDispense).Split(' ');
            dateTimePicker1.Value = Convert.ToDateTime(time[0]);
            dateTimePicker2.Value = Convert.ToDateTime(time[1]);

            Status.Checked = dis.Status;
        }
        // Второй конструктор для выбора медсестры
        public Info_DispensingDrug()
        {
            InitializeComponent();
        }
        // Заполнение полей медсестры!!!!!
        public void NurseField(Person nurse)
        {
            textBox7.Text = Convert.ToString(nurse.ID);
            textBox4.Text = nurse.Surname;
            textBox5.Text = nurse.Name;
            textBox6.Text = nurse.Patronymic;
        }

        // Кнопка выбора медсестры!!!!!
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
                dis.NurseID = Convert.ToInt32(textBox7.Text);
                dis.PrescriptionID = Convert.ToInt32(textBox3.Text);
                dis.TreatmentPlanID = Convert.ToInt32(textBox1.Text);
                dis.Dosage = (double)numericUpDown1.Value;
                dis.Status = Status.Checked;
                dis.TimeOfTakeDispense = Convert.ToDateTime(dateTimePicker1.Value.ToString("D") + " " + dateTimePicker2.Value.ToString("t"));

                OperationsOfDispensingDrugs.Edit(dis);
                MessageBox.Show("Событие выдачи лекарства изменено");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
            }
            else { toolTip1.Show("Введите количество лекарства", numericUpDown1, new Point(0, 20), 1000); }
        }

        // Кнопка Изменить
        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            numericUpDown1.Enabled = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            Status.Enabled = true;
        }

        // Смена статуса выдано/не выдано
        private void Status_CheckedChanged(object sender, EventArgs e)
        {
            if (status == 3 && Status.Checked == true)
            {
                textBox7.Text = Convert.ToString(nurID);
                textBox4.Text = OperationsOfPersons.FindByID(nurID).Surname;
                textBox5.Text = OperationsOfPersons.FindByID(nurID).Name;
                textBox6.Text = OperationsOfPersons.FindByID(nurID).Patronymic;
            }
            else
            {
                if (status == 3 && Status.Checked == false)
                {
                    textBox7.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
            }
        }
    }
}
