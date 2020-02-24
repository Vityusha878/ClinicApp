namespace ClinicApp.ChoiceForm
{
    partial class Choice_Drug
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
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.number6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDrug = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfCreate6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfEdit6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.AllowUserToOrderColumns = true;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number6,
            this.nameDrug,
            this.Column4,
            this.measure,
            this.dateOfCreate6,
            this.dateOfEdit6});
            this.dataGridView6.Location = new System.Drawing.Point(1, 2);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.Size = new System.Drawing.Size(682, 298);
            this.dataGridView6.TabIndex = 1;
            this.dataGridView6.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView6_CellClick);
            // 
            // number6
            // 
            this.number6.HeaderText = "№";
            this.number6.Name = "number6";
            this.number6.ReadOnly = true;
            this.number6.Width = 30;
            // 
            // nameDrug
            // 
            this.nameDrug.HeaderText = "Название";
            this.nameDrug.Name = "nameDrug";
            this.nameDrug.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Количество";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // measure
            // 
            this.measure.HeaderText = "Мера измерения";
            this.measure.Name = "measure";
            this.measure.ReadOnly = true;
            // 
            // dateOfCreate6
            // 
            this.dateOfCreate6.HeaderText = "Дата создания";
            this.dateOfCreate6.Name = "dateOfCreate6";
            this.dateOfCreate6.ReadOnly = true;
            // 
            // dateOfEdit6
            // 
            this.dateOfEdit6.HeaderText = "Дата изменения";
            this.dateOfEdit6.Name = "dateOfEdit6";
            this.dateOfEdit6.ReadOnly = true;
            // 
            // Choice_Drug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 328);
            this.Controls.Add(this.dataGridView6);
            this.Name = "Choice_Drug";
            this.Text = "Drug";
            this.Load += new System.EventHandler(this.Choice_Drug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.DataGridViewTextBoxColumn number6;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDrug;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn measure;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfCreate6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfEdit6;
    }
}