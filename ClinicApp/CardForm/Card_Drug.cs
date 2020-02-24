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
    public partial class Card_Drug : Form
    {
        // Экземпляр Drug который присваивается переданному из грида лекарству
        Drug drug = new Drug();        

        public Card_Drug()
        {
            InitializeComponent();
            
            // По дефолту поле с мерой измерения заблокировано и равняется у.е. - условные единицы
            textBox8.Enabled = false;
            textBox8.Text = "у.е.";
        }

        // Кнопка "Сохранить", при нажатии считывает текстбоксы и заносит их данные в поля объекта + проверка полей
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckField() == 2)
            {
                drug.Name = textBox1.Text;
                drug.Quantity = (int)numericUpDown1.Value;
                drug.Measure = textBox8.Text;

                OperationsOfDrugs.Add(drug);
                MessageBox.Show("Лекарство добавлено");

                // При нажатии кнопки вызывается грид с уже измененными данными(авто обновление) на главной форме
                this.Close();                
            }
        }

        // Метод проверки полей, возвращает цифру 2, если поля проходят проверку
        // Если нет, то над полями не прошедшими проверку появляется надпись
        private int CheckField()
        {
            int check = 0;
            if (Regex.IsMatch(textBox1.Text, @"^[А-Я]{1}[а-я]+[а-я]$")) { check++; }
            else
            {
                toolTip1.Show("Введите название на русском языке с заглавной буквы", textBox1, new Point(0, 20), 1000);
            }
            if (numericUpDown1.Value != 0) { check++; }
            else
            {
                toolTip2.Show("Введите количество лекарства", numericUpDown1, new Point(0, 20), 1000);
            }
            return check;
        }
    }
}
