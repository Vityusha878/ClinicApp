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
    public partial class Card_Patient : Form
    {
        // Экземпляр Person который присваивается переданному из грида пациенту
        Person person = new Person();        
        public Card_Patient()
        {
            InitializeComponent();            
        }

        // Кнопка "Сохранить", при нажатии считывает текстбоксы и заносит их данные в поля объекта + проверка полей
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckField() == 4)
            {
                person.Surname = textBox1.Text;
                person.Name = textBox2.Text;
                person.Patronymic = textBox3.Text;
                person.Phone = textBox4.Text;
                person.Role = 7; // 7 = пациент

                OperationsOfPersons.Add(person);
                MessageBox.Show("Пациент добавлен");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();
            }
        }

        // Метод проверки полей, возвращает цифру 4, если все 4 полей проходят проверку
        // Если нет, то над полями не прошедшими проверку появляется надпись
        private int CheckField()
        {
            int check = 0;
            if (Regex.IsMatch(textBox1.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip1.Show("Введите фамилию на русском языке с заглавной буквы", textBox1, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox2.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip2.Show("Введите имя на русском языке с заглавной буквы", textBox2, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox3.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip3.Show("Введите отчество на русском языке с заглавной буквы", textBox3, new Point(0, 20), 1000);
            }

            if (Regex.IsMatch(textBox4.Text, @"^[8]{1}[9]{1}[0-9]{9}")) { check++; }
            else
            {
                toolTip4.Show("Введите номер начиная с 89", textBox4, new Point(0, 20), 1000);
            }

            return check;
        }
    }
}
