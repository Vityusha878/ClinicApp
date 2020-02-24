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
    public partial class Card_TreatmentPlan : Form
    {
        //// id залогиневшегося врача для подстановки его данных в поля врача
        //public int personID;
        //// Должность залогиневшегося человека для ограничения функционала(бан кнопок и тд)
        //public string personRole;
                
        int status = ClinicApp.Model.Singleton.getPerson().Role;
        int docID = ClinicApp.Model.Singleton.getPerson().ID;
        string docSurname = ClinicApp.Model.Singleton.getPerson().Surname;
        string docName = ClinicApp.Model.Singleton.getPerson().Name;
        string docPatronymic = ClinicApp.Model.Singleton.getPerson().Patronymic;

        // Экземпляр TreatmentPlan
        public TreatmentPlan plan = new TreatmentPlan();
        public Card_TreatmentPlan()
        {
            InitializeComponent();                     
                        
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

            if (status == 2)
            {
                button1.Hide(); // Скрываем кнопку выбора врача

                // Заполняем textBoxы полями врача
                textBox7.Text = Convert.ToString(docID);
                textBox1.Text = docSurname;
                textBox2.Text = docName;
                textBox3.Text = docPatronymic;
            }
        }

        // Второй конструктор для форм с выбором врача и пациента(по другому не работает) и сисадмина
        //public Card_TreatmentPlan()
        //{
        //    InitializeComponent();

        //    // Бан полей врача
        //    textBox7.Enabled = false;
        //    textBox1.Enabled = false;
        //    textBox2.Enabled = false;
        //    textBox3.Enabled = false;
        //    // Бан полей пациента
        //    textBox8.Enabled = false;
        //    textBox6.Enabled = false;
        //    textBox5.Enabled = false;
        //    textBox4.Enabled = false;
        //}

        // Метод заполняющий поля врача, выбранного на гриде выбора
        public void DoctorField(Person doctor)
        {
            textBox7.Text = Convert.ToString(doctor.ID);
            textBox1.Text = doctor.Surname;
            textBox2.Text = doctor.Name;
            textBox3.Text = doctor.Patronymic;
        }

        // Метод заполняющий поля пациента, выбранного на гриде выбора
        public void PatientField(Person patient)
        {
            textBox8.Text = Convert.ToString(patient.ID);
            textBox6.Text = patient.Surname;
            textBox5.Text = patient.Name;
            textBox4.Text = patient.Patronymic;
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

        //Кнопка "Сохранить"
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "") // Проверка пациента
            {
                plan.AssignerDoctorID = Convert.ToInt32(textBox7.Text);
                plan.PatientID = Convert.ToInt32(textBox8.Text);

                OperationsOfTreatmentPlans.Add(plan);
                MessageBox.Show("План лечения добавлен");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
                // При закрытии формы добавления сразу же открывается форма просмотра плана лечения для добавления в него назначений лекарств
                InfoForm.Info_TreatmentPlan InfoPlan = new InfoForm.Info_TreatmentPlan(plan);
                InfoPlan.ShowDialog();
            }
            else { toolTip1.Show("Выберите пациента", button3, new Point(0, 20), 1000); }
        }
    }
}
