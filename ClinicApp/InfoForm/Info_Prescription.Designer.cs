namespace ClinicApp.InfoForm
{
    partial class Info_Prescription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.number5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prescriptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dosage1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOfTakeDispense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfCreate5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfEdit5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Выбрать лекарство";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 49);
            this.button2.TabIndex = 24;
            this.button2.Text = "Сохранить назначение лекарства";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(11, 458);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(165, 49);
            this.button24.TabIndex = 25;
            this.button24.Text = "Добавить событие выдачи лекарства";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number5,
            this.nurseID,
            this.prescriptionID,
            this.planID2,
            this.dosage1,
            this.timeOfTakeDispense,
            this.dateOfCreate5,
            this.dateOfEdit5,
            this.status1,
            this.Column6});
            this.dataGridView5.Location = new System.Drawing.Point(11, 214);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.Size = new System.Drawing.Size(902, 228);
            this.dataGridView5.TabIndex = 23;
            this.dataGridView5.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView5_CellDoubleClick);
            // 
            // number5
            // 
            this.number5.HeaderText = "№";
            this.number5.Name = "number5";
            this.number5.ReadOnly = true;
            this.number5.Width = 30;
            // 
            // nurseID
            // 
            this.nurseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nurseID.HeaderText = "Медсестра";
            this.nurseID.Name = "nurseID";
            this.nurseID.ReadOnly = true;
            this.nurseID.Width = 88;
            // 
            // prescriptionID
            // 
            this.prescriptionID.HeaderText = "Назначение лекарства";
            this.prescriptionID.Name = "prescriptionID";
            this.prescriptionID.ReadOnly = true;
            this.prescriptionID.Width = 70;
            // 
            // planID2
            // 
            this.planID2.HeaderText = "План лечения";
            this.planID2.Name = "planID2";
            this.planID2.ReadOnly = true;
            this.planID2.Width = 70;
            // 
            // dosage1
            // 
            this.dosage1.HeaderText = "Доза";
            this.dosage1.Name = "dosage1";
            this.dosage1.ReadOnly = true;
            this.dosage1.Width = 40;
            // 
            // timeOfTakeDispense
            // 
            this.timeOfTakeDispense.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.timeOfTakeDispense.HeaderText = "Время принятия";
            this.timeOfTakeDispense.Name = "timeOfTakeDispense";
            this.timeOfTakeDispense.ReadOnly = true;
            this.timeOfTakeDispense.Width = 105;
            // 
            // dateOfCreate5
            // 
            this.dateOfCreate5.HeaderText = "Дата создания";
            this.dateOfCreate5.Name = "dateOfCreate5";
            this.dateOfCreate5.ReadOnly = true;
            // 
            // dateOfEdit5
            // 
            this.dateOfEdit5.HeaderText = "Дата измения";
            this.dateOfEdit5.Name = "dateOfEdit5";
            this.dateOfEdit5.ReadOnly = true;
            // 
            // status1
            // 
            this.status1.HeaderText = "Выдано/Не выдано";
            this.status1.Name = "status1";
            this.status1.ReadOnly = true;
            this.status1.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "☠☠☠";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "Удалить";
            this.Column6.UseColumnTextForButtonValue = true;
            this.Column6.Width = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Дата конца приема лекарства";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Дата начала приема лекарства";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "№ плана лечения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Количество лекарства";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(14, 188);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker2.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(14, 162);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(13, 84);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(199, 20);
            this.textBox4.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(13, 63);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 20);
            this.textBox3.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 20);
            this.textBox1.TabIndex = 15;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(582, 464);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(66, 13);
            this.label41.TabIndex = 29;
            this.label41.Text = "Страница: /";
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(664, 458);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(35, 23);
            this.button29.TabIndex = 27;
            this.button29.Text = ">>";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(543, 458);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(35, 23);
            this.button30.TabIndex = 28;
            this.button30.Text = "<<";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(14, 114);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(198, 20);
            this.numericUpDown1.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "№ лекарства";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Название лекарства";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 458);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 49);
            this.button3.TabIndex = 24;
            this.button3.Text = "Изменить назначение";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Info_Prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 513);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.dataGridView5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Name = "Info_Prescription";
            this.Text = "Info_Prescription";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn number5;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn prescriptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn planID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dosage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOfTakeDispense;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfCreate5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfEdit5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status1;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}