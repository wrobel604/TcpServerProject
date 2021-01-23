
namespace LoginSystemClient
{
    partial class RegisterUserForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.LoginInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordRepeatInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.QuestionInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AnswerInput = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Login";
            // 
            // LoginInput
            // 
            this.LoginInput.Location = new System.Drawing.Point(12, 25);
            this.LoginInput.Name = "LoginInput";
            this.LoginInput.PasswordChar = '#';
            this.LoginInput.Size = new System.Drawing.Size(184, 20);
            this.LoginInput.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hasło";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(12, 68);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '#';
            this.PasswordInput.Size = new System.Drawing.Size(184, 20);
            this.PasswordInput.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Powtórz hasło";
            // 
            // PasswordRepeatInput
            // 
            this.PasswordRepeatInput.Location = new System.Drawing.Point(12, 115);
            this.PasswordRepeatInput.Name = "PasswordRepeatInput";
            this.PasswordRepeatInput.PasswordChar = '#';
            this.PasswordRepeatInput.Size = new System.Drawing.Size(184, 20);
            this.PasswordRepeatInput.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pytanie";
            // 
            // QuestionInput
            // 
            this.QuestionInput.Location = new System.Drawing.Point(12, 160);
            this.QuestionInput.Name = "QuestionInput";
            this.QuestionInput.PasswordChar = '#';
            this.QuestionInput.Size = new System.Drawing.Size(184, 20);
            this.QuestionInput.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Odpowiedź";
            // 
            // AnswerInput
            // 
            this.AnswerInput.Location = new System.Drawing.Point(12, 204);
            this.AnswerInput.Name = "AnswerInput";
            this.AnswerInput.PasswordChar = '#';
            this.AnswerInput.Size = new System.Drawing.Size(184, 20);
            this.AnswerInput.TabIndex = 16;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(13, 235);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(184, 23);
            this.RegisterButton.TabIndex = 18;
            this.RegisterButton.Text = "Zarejestruj się";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 270);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AnswerInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QuestionInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordRepeatInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginInput);
            this.Name = "RegisterUser";
            this.Text = "RegisterUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordRepeatInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox QuestionInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AnswerInput;
        private System.Windows.Forms.Button RegisterButton;
    }
}