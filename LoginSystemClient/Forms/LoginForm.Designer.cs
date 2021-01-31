
namespace LoginSystemClient
{
    partial class LoginForm
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
            this.LoginInputTextBox = new System.Windows.Forms.TextBox();
            this.PasswordInputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RecoveryLink = new System.Windows.Forms.LinkLabel();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginInputTextBox
            // 
            this.LoginInputTextBox.Location = new System.Drawing.Point(12, 26);
            this.LoginInputTextBox.Name = "LoginInputTextBox";
            this.LoginInputTextBox.Size = new System.Drawing.Size(184, 20);
            this.LoginInputTextBox.TabIndex = 0;
            // 
            // PasswordInputTextBox
            // 
            this.PasswordInputTextBox.Location = new System.Drawing.Point(12, 65);
            this.PasswordInputTextBox.Name = "PasswordInputTextBox";
            this.PasswordInputTextBox.Size = new System.Drawing.Size(184, 20);
            this.PasswordInputTextBox.TabIndex = 1;
            this.PasswordInputTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasło";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 113);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(184, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Zaloguj się";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RecoveryLink
            // 
            this.RecoveryLink.AutoSize = true;
            this.RecoveryLink.Location = new System.Drawing.Point(9, 88);
            this.RecoveryLink.Name = "RecoveryLink";
            this.RecoveryLink.Size = new System.Drawing.Size(147, 13);
            this.RecoveryLink.TabIndex = 5;
            this.RecoveryLink.TabStop = true;
            this.RecoveryLink.Text = "Przypomnij hasło (podaj login)";
            this.RecoveryLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecoveryLink_LinkClicked);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(12, 142);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(184, 23);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Zarejestruj się";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 175);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.RecoveryLink);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordInputTextBox);
            this.Controls.Add(this.LoginInputTextBox);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox LoginInputTextBox;
        public System.Windows.Forms.TextBox PasswordInputTextBox;
        public System.Windows.Forms.Button LoginButton;
        public System.Windows.Forms.LinkLabel RecoveryLink;
        public System.Windows.Forms.Button RegisterButton;
    }
}