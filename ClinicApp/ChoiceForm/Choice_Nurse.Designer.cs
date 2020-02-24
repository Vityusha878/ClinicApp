namespace ClinicApp.ChoiceForm
{
    partial class Choice_Nurse
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
            this.dataGridEmployee = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имя = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridEmployee
            // 
            this.dataGridEmployee.AllowUserToAddRows = false;
            this.dataGridEmployee.AllowUserToDeleteRows = false;
            this.dataGridEmployee.AllowUserToOrderColumns = true;
            this.dataGridEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.Surname,
            this.имя,
            this.Patronymic,
            this.Phone,
            this.Role,
            this.DateOfCreate,
            this.DateOfEdit});
            this.dataGridEmployee.Location = new System.Drawing.Point(12, 12);
            this.dataGridEmployee.Name = "dataGridEmployee";
            this.dataGridEmployee.ReadOnly = true;
            this.dataGridEmployee.Size = new System.Drawing.Size(857, 288);
            this.dataGridEmployee.TabIndex = 2;
            this.dataGridEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEmployee_CellClick);
            // 
            // number
            // 
            this.number.HeaderText = "№";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 30;
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Фамилия";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            this.Surname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // имя
            // 
            this.имя.HeaderText = "Имя";
            this.имя.Name = "имя";
            this.имя.ReadOnly = true;
            // 
            // Patronymic
            // 
            this.Patronymic.HeaderText = "Отчество";
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Телефон";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Role
            // 
            this.Role.HeaderText = "Должность";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // DateOfCreate
            // 
            this.DateOfCreate.HeaderText = "Дата создания";
            this.DateOfCreate.Name = "DateOfCreate";
            this.DateOfCreate.ReadOnly = true;
            // 
            // DateOfEdit
            // 
            this.DateOfEdit.HeaderText = "Дата изменения";
            this.DateOfEdit.Name = "DateOfEdit";
            this.DateOfEdit.ReadOnly = true;
            // 
            // Choice_Nurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 332);
            this.Controls.Add(this.dataGridEmployee);
            this.Name = "Choice_Nurse";
            this.Text = "Nurse";
            this.Load += new System.EventHandler(this.Choice_Nurse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn имя;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfEdit;
    }
}