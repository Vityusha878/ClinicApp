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
    public partial class Choice_Drug : Form
    {        
        Card_Prescription prs = new Card_Prescription(); // Экземпляр формы добавления назначения лекарства
        InfoForm.Info_Prescription ps = new InfoForm.Info_Prescription(); // Экземпляр формы просмотра/редактировния назначения лекарства

        // Конструктор для формы добавления назначения лекарства
        public Choice_Drug(Card_Prescription pr)
        {
            prs = pr;

            InitializeComponent();
        }
        // Конструктор для формы просмотра/редактировния назначения лекарства
        public Choice_Drug(InfoForm.Info_Prescription p)
        {
            ps = p;

            InitializeComponent();
        }
        // Заполнение грида
        private void Choice_Drug_Load(object sender, EventArgs e)
        {
            List<Drug> drug = OperationsOfDrugs.ChoiceGrid_Drug();
            foreach (var p in drug)
            {
                dataGridView6.Rows.Add(p.ID, p.Name, p.Quantity, p.Measure, p.DateOfCreate, p.DateOfEdit);
            }
        }
        // Клик на гриде
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataGridView6.RowCount - 1 >= e.RowIndex)
                {
                    int l = e.RowIndex; // Находим индекс строки, где был клик

                    int k = Convert.ToInt32(dataGridView6.Rows[l].Cells[0].Value); // Выдергивание id лекарства из строки

                    Drug drug = OperationsOfDrugs.FindByID(k);
                    prs.DrugField(drug); // Выбор лекарства в форме добавления
                    ps.DrugField(drug); // Выбор лекарства в форме просмотра
                    this.Close();
                }
            }
        }
    }
}
