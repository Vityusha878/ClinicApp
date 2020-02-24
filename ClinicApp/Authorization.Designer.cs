namespace ClinicApp
{
    partial class Authorization
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
            this.ForgotPasswordLnkLbl = new System.Windows.Forms.LinkLabel();
            this.PswrdTxtBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTxtBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ForgotPasswordLnkLbl
            // 
            this.ForgotPasswordLnkLbl.AutoSize = true;
            this.ForgotPasswordLnkLbl.Location = new System.Drawing.Point(12, 85);
            this.ForgotPasswordLnkLbl.Name = "ForgotPasswordLnkLbl";
            this.ForgotPasswordLnkLbl.Size = new System.Drawing.Size(91, 13);
            this.ForgotPasswordLnkLbl.TabIndex = 10;
            this.ForgotPasswordLnkLbl.TabStop = true;
            this.ForgotPasswordLnkLbl.Text = "Забыли пароль?";
            this.ForgotPasswordLnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgotPasswordLnkLbl_LinkClicked);
            // 
            // PswrdTxtBx
            // 
            this.PswrdTxtBx.Location = new System.Drawing.Point(102, 39);
            this.PswrdTxtBx.Name = "PswrdTxtBx";
            this.PswrdTxtBx.Size = new System.Drawing.Size(150, 20);
            this.PswrdTxtBx.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // LoginTxtBx
            // 
            this.LoginTxtBx.Location = new System.Drawing.Point(102, 13);
            this.LoginTxtBx.Name = "LoginTxtBx";
            this.LoginTxtBx.Size = new System.Drawing.Size(150, 20);
            this.LoginTxtBx.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Логин";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(138, 80);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 9;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 145);
            this.Controls.Add(this.ForgotPasswordLnkLbl);
            this.Controls.Add(this.PswrdTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginButton);
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ForgotPasswordLnkLbl;
        private System.Windows.Forms.TextBox PswrdTxtBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginTxtBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginButton;
    }
}