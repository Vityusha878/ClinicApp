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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string login = LoginTxtBx.Text;
            string password = PswrdTxtBx.Text;
            Person inputPerson = ClinicApp.Model.Singleton.inputPerson(login, password);

            if (inputPerson != null)
            {
                this.Hide();
                MainFormClinic main = new MainFormClinic();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Клиника Ромашка");
            }

        }

        private void ForgotPasswordLnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Обратитесь к вашему системному администратору", "Клиника Ромашка");
        }
    }
}
