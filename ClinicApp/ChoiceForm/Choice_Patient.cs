using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicApp.ChoiceForm
{
    public partial class Choice_Patient : Form
    {
        static MainFormClinic mainForm = new MainFormClinic(); // Экземпляр главной формы, который присваивается переданной главной форме
        Card_TreatmentPlan plan = new Card_TreatmentPlan(); // Экземпляр формы добавления плана лечения
        InfoForm.Info_TreatmentPlan pln = new InfoForm.Info_TreatmentPlan(); // Экземпляр формы просмотра/редактировния плана лечения

        // Конструктор для формы добавления плана лечения
        public Choice_Patient(Card_TreatmentPlan pl)
        {
            plan = pl;

            InitializeComponent();
        }
        // Конструктор для формы просмотра/редактировния плана лечения
        public Choice_Patient(InfoForm.Info_TreatmentPlan pl)
        {
            pln = pl;

            InitializeComponent();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataGridView2.RowCount - 1 >= e.RowIndex)
                {
                    int l = e.RowIndex; // Находим индекс строки, где был клик

                    int k = Convert.ToInt32(dataGridView2.Rows[l].Cells[0].Value); // Выдергивание id пациента из строки

                    Person patient = OperationsOfPersons.FindByID(k);
                    plan.PatientField(patient); // Выбор пациента в форме добавления
                    pln.PatientField(patient); // Выбор пациента в форме просмотра
                    this.Close();
                }
            }
        }
        // Заполнение грида
        private void Choice_Patient_Load(object sender, EventArgs e)
        {
            List<Person> patient = OperationsOfPersons.ChoiceGrid_Patient();
            foreach (var p in patient)
            {
                dataGridView2.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.DateOfCreate, p.DateOfEdit);
            }
        }
    }
}
