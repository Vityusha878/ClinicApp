using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClinicApp
{
    public partial class Card_Employee : Form
    {
        // Экземпляр Person который присваивается переданному из грида работнику
        Person person = new Person();
        // Список значений combobox
        List<string> role = new List<string>() { "Врач", "Медсестра" };        

        public Card_Employee()
        {
            InitializeComponent();
            // Определяем стиль ComboBox - только выпадаюший, вводить ничего нельзя
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // Значения ComboBox - список выше (врач и медсестра)
            comboBox1.DataSource = role;            
        }        

        // Кнопка "Сохранить" - проверка полей
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckField() == 6)
            {
                person.Surname = textBox2.Text;
                person.Name = textBox3.Text;
                person.Patronymic = textBox4.Text;
                person.Phone = textBox5.Text;
                if (comboBox1.Text == "Врач") { person.Role = 2; }
                else { person.Role = 3; }
                
                person.Login = textBox6.Text;
                person.Password = textBox7.Text;

                OperationsOfPersons.Add(person);
                MessageBox.Show("Работник добавлен");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
                
            }
        }

        // Метод проверки полей, возвращает цифру 6, если все 6 полей проходят проверку
        // Если нет, то над полями не прошедшими проверку появляется надпись
        private int CheckField()
        {
            int check = 0;
            if (Regex.IsMatch(textBox2.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip1.Show("Введите фамилию на русском языке с заглавной буквы", textBox2, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox3.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip2.Show("Введите имя на русском языке с заглавной буквы", textBox3, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox4.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip3.Show("Введите отчество на русском языке с заглавной буквы", textBox4, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox5.Text, @"^[8]{1}[9]{1}[0-9]{9}")) { check++; }
            else
            {
                toolTip4.Show("Введите номер", textBox5, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox6.Text, @"^[a-zA-Z0-9]*([a-zA-Z0-9])$")) { check++; }
            else
            {
                toolTip5.Show("Введите логин", textBox6, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox7.Text, @"^[a-zA-Z0-9]*([a-zA-Z0-9])$")) { check++; }
            else
            {
                toolTip6.Show("Введите пароль", textBox7, new Point(0, 20), 1000);
            }
            return check;
        }
    }
}
