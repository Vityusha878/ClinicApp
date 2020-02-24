namespace ClinicApp.ChoiceForm
{
    partial class Choice_Patient
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.number2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymic2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfCreate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfEdit2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number2,
            this.surname2,
            this.name2,
            this.patronymic2,
            this.phone2,
            this.dateOfCreate2,
            this.dateOfEdit2});
            this.dataGridView2.Location = new System.Drawing.Point(2, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(767, 306);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // number2
            // 
            this.number2.HeaderText = "№";
            this.number2.Name = "number2";
            this.number2.ReadOnly = true;
            this.number2.Width = 30;
            // 
            // surname2
            // 
            this.surname2.HeaderText = "Фамилия";
            this.surname2.Name = "surname2";
            this.surname2.ReadOnly = true;
            // 
            // name2
            // 
            this.name2.HeaderText = "Имя";
            this.name2.Name = "name2";
            this.name2.ReadOnly = true;
            // 
            // patronymic2
            // 
            this.patronymic2.HeaderText = "Отчество";
            this.patronymic2.Name = "patronymic2";
            this.patronymic2.ReadOnly = true;
            // 
            // phone2
            // 
            this.phone2.HeaderText = "Телефон";
            this.phone2.Name = "phone2";
            this.phone2.ReadOnly = true;
            // 
            // dateOfCreate2
            // 
            this.dateOfCreate2.HeaderText = "Дата создания";
            this.dateOfCreate2.Name = "dateOfCreate2";
            this.dateOfCreate2.ReadOnly = true;
            // 
            // dateOfEdit2
            // 
            this.dateOfEdit2.HeaderText = "Дата изменения";
            this.dateOfEdit2.Name = "dateOfEdit2";
            this.dateOfEdit2.ReadOnly = true;
            // 
            // Choice_Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 338);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Choice_Patient";
            this.Text = "Patient";
            this.Load += new System.EventHandler(this.Choice_Patient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn number2;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname2;
        private System.Windows.Forms.DataGridViewTextBoxColumn name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymic2;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfCreate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfEdit2;
    }
}