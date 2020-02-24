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
    public partial class Choice_Doctor : Form
    {
        
        static MainFormClinic mainForm = new MainFormClinic(); // Экземпляр главной формы, который присваивается переданной главной форме
        Card_TreatmentPlan plan = new Card_TreatmentPlan(); // Экземпляр формы добавления плана лечения
        InfoForm.Info_TreatmentPlan pln = new InfoForm.Info_TreatmentPlan(); // Экземпляр формы просмотра/редактировния плана лечения

        // Конструктор для формы добавления плана лечения
        public Choice_Doctor(Card_TreatmentPlan pl)
        {
            plan = pl;

            InitializeComponent();
        }
        // Конструктор для формы просмотра/редактировния плана лечения
        public Choice_Doctor(InfoForm.Info_TreatmentPlan pl)
        {
            pln = pl;

            InitializeComponent();
        }
        // Заполнение грида
        private void Doctor_Load(object sender, EventArgs e)
        {
            List<Person> doctor = OperationsOfPersons.ChoiceGrid_Doctor();
            foreach (var p in doctor)
            {
                dataGridEmployee.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.Role, p.DateOfCreate, p.DateOfEdit);
            }
        }
        // Клик на гриде
        private void dataGridEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataGridEmployee.RowCount - 1 >= e.RowIndex)
                {
                    int l = e.RowIndex; // Находим индекс строки, где был клик

                    int k = Convert.ToInt32(dataGridEmployee.Rows[l].Cells[0].Value); // Выдергивание id врача из строки

                    Person doctor = OperationsOfPersons.FindByID(k);
                    plan.DoctorField(doctor); // Выбор врача в форме добавления
                    pln.DoctorField(doctor); // Выбор врача в форме просмотра
                    this.Close();
                }
            }

        }
    }
}
