
namespace LoginSystemClient.Forms
{
    partial class SendMailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ReceiverTextBox = new System.Windows.Forms.TextBox();
            this.ContentTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odbiorca";
            // 
            // ReceiverTextBox
            // 
            this.ReceiverTextBox.Location = new System.Drawing.Point(68, 6);
            this.ReceiverTextBox.Name = "ReceiverTextBox";
            this.ReceiverTextBox.Size = new System.Drawing.Size(275, 20);
            this.ReceiverTextBox.TabIndex = 1;
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.Location = new System.Drawing.Point(12, 51);
            this.ContentTextBox.Multiline = true;
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(331, 191);
            this.ContentTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Treść";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(12, 248);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(331, 23);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Wyślij";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // SendMailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 284);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ContentTextBox);
            this.Controls.Add(this.ReceiverTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SendMailForm";
            this.Text = "SendMailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox ReceiverTextBox;
        public System.Windows.Forms.TextBox ContentTextBox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button SendButton;
    }
}