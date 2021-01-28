
namespace LoginSystemClient.Forms
{
    partial class ChangeForm
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
            this.Input2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Input1 = new System.Windows.Forms.TextBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Powtórz hasło";
            // 
            // Input2
            // 
            this.Input2.Location = new System.Drawing.Point(15, 72);
            this.Input2.Name = "Input2";
            this.Input2.PasswordChar = '#';
            this.Input2.Size = new System.Drawing.Size(184, 20);
            this.Input2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nowe hasło";
            // 
            // Input1
            // 
            this.Input1.Location = new System.Drawing.Point(15, 25);
            this.Input1.Name = "Input1";
            this.Input1.PasswordChar = '#';
            this.Input1.Size = new System.Drawing.Size(184, 20);
            this.Input1.TabIndex = 14;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(12, 98);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(187, 23);
            this.AcceptButton.TabIndex = 18;
            this.AcceptButton.Text = "Zmień hasło";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 129);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Input2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Input1);
            this.Name = "ChangeForm";
            this.Text = "ChangePasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox Input2;
        public System.Windows.Forms.TextBox Input1;
        public System.Windows.Forms.Button AcceptButton;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
    }
}