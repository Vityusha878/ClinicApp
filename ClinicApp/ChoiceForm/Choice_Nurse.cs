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
    public partial class Choice_Nurse : Form
    {        
        static PrescriptionOfDrug pres = new PrescriptionOfDrug(); // Экземпляр назначения лекарства
        static MainFormClinic mainForm = new MainFormClinic(); // Экземпляр главной формы, который присваивается переданной главной форме

        Card_Dispensing dis = new Card_Dispensing(pres); // Экземпляр формы добавления события выдачи лекарства
        InfoForm.Info_DispensingDrug dispensing = new InfoForm.Info_DispensingDrug(); // Экземпляр формы просмотра/редактировния события выдачи лекарства

        // Конструктор для формы добавления события выдачи лекарства
        public Choice_Nurse(Card_Dispensing d)
        {
            dis = d;
            InitializeComponent();
        }
        // Конструктор для формы просмотра/редактировния события выдачи лекарства
        public Choice_Nurse(InfoForm.Info_DispensingDrug ds)
        {
            dispensing = ds;
            InitializeComponent();
        }
        // Клик на гриде
        private void dataGridEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataGridEmployee.RowCount - 1 >= e.RowIndex)
                {
                    int l = e.RowIndex; // Находим индекс строки, где был клик

                    int k = Convert.ToInt32(dataGridEmployee.Rows[l].Cells[0].Value); // Выдергивание id медсестры из строки

                    Person nurse = OperationsOfPersons.FindByID(k);
                    dis.NurseField(nurse); // Выбор медсестры в форме добавления
                    dispensing.NurseField(nurse); // Выбор медсестры в форме просмотра
                    this.Close();
                }
            }
        }
        // Заполнение грида
        private void Choice_Nurse_Load(object sender, EventArgs e)
        {
            List<Person> nurse = OperationsOfPersons.ChoiceGrid_Nurse();
            foreach (var p in nurse)
            {
                dataGridEmployee.Rows.Add(p.ID, p.Surname, p.Name, p.Patronymic, p.Phone, p.Role, p.DateOfCreate, p.DateOfEdit);
            }            
        }
    }
}
