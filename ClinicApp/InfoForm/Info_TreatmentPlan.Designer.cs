namespace ClinicApp.InfoForm
{
    partial class Info_TreatmentPlan
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
            this.button2 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.number4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drugID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeOfTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishTimeOfTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfCreate4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfEdit4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 453);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "Сохранить план";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(12, 453);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(165, 49);
            this.button24.TabIndex = 14;
            this.button24.Text = "Добавить назначение лекарства";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number4,
            this.planID,
            this.drugID,
            this.quantity1,
            this.startTimeOfTaken,
            this.finishTimeOfTaken,
            this.dateOfCreate4,
            this.dateOfEdit4,
            this.Column5});
            this.dataGridView4.Location = new System.Drawing.Point(12, 180);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.Size = new System.Drawing.Size(859, 258);
            this.dataGridView4.TabIndex = 12;
            this.dataGridView4.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellDoubleClick);
            // 
            // number4
            // 
            this.number4.HeaderText = "№";
            this.number4.Name = "number4";
            this.number4.ReadOnly = true;
            this.number4.Width = 30;
            // 
            // planID
            // 
            this.planID.HeaderText = "План лечения";
            this.planID.Name = "planID";
            this.planID.ReadOnly = true;
            // 
            // drugID
            // 
            this.drugID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.drugID.HeaderText = "Лекарство";
            this.drugID.Name = "drugID";
            this.drugID.ReadOnly = true;
            this.drugID.Width = 87;
            // 
            // quantity1
            // 
            this.quantity1.HeaderText = "Количество";
            this.quantity1.Name = "quantity1";
            this.quantity1.ReadOnly = true;
            // 
            // startTimeOfTaken
            // 
            this.startTimeOfTaken.HeaderText = "Начало приема";
            this.startTimeOfTaken.Name = "startTimeOfTaken";
            this.startTimeOfTaken.ReadOnly = true;
            // 
            // finishTimeOfTaken
            // 
            this.finishTimeOfTaken.HeaderText = "Конец приема";
            this.finishTimeOfTaken.Name = "finishTimeOfTaken";
            this.finishTimeOfTaken.ReadOnly = true;
            // 
            // dateOfCreate4
            // 
            this.dateOfCreate4.HeaderText = "Дата создания";
            this.dateOfCreate4.Name = "dateOfCreate4";
            this.dateOfCreate4.ReadOnly = true;
            // 
            // dateOfEdit4
            // 
            this.dateOfEdit4.HeaderText = "Дата изменения";
            this.dateOfEdit4.Name = "dateOfEdit4";
            this.dateOfEdit4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "☠☠☠";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Text = "Удалить";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 70;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(249, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 162);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пациент";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(6, 127);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(146, 20);
            this.textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(6, 101);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(146, 20);
            this.textBox5.TabIndex = 7;
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(7, 49);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(146, 20);
            this.textBox8.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(7, 75);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(146, 20);
            this.textBox6.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Выбрать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 162);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Врач";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(6, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(6, 49);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(146, 20);
            this.textBox7.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(7, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(566, 459);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(66, 13);
            this.label41.TabIndex = 17;
            this.label41.Text = "Страница: /";
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(648, 453);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(35, 23);
            this.button29.TabIndex = 15;
            this.button29.Text = ">>";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(527, 453);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(35, 23);
            this.button30.TabIndex = 16;
            this.button30.Text = "<<";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // Info_TreatmentPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 515);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Info_TreatmentPlan";
            this.Text = "Info_TreatmentPlan";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn number4;
        private System.Windows.Forms.DataGridViewTextBoxColumn planID;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugID;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeOfTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishTimeOfTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfCreate4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfEdit4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}