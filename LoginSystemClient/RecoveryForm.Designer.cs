
namespace LoginSystemClient
{
    partial class RecoveryForm
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
            this.Question = new System.Windows.Forms.TextBox();
            this.Answer = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Question
            // 
            this.Question.Location = new System.Drawing.Point(12, 12);
            this.Question.Multiline = true;
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.Size = new System.Drawing.Size(284, 83);
            this.Question.TabIndex = 0;
            // 
            // Answer
            // 
            this.Answer.Location = new System.Drawing.Point(12, 101);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(284, 20);
            this.Answer.TabIndex = 1;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(12, 127);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(284, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "Wyślij";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // RecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 158);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.Question);
            this.Name = "RecoveryForm";
            this.Text = "RecoveryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Question;
        private System.Windows.Forms.TextBox Answer;
        private System.Windows.Forms.Button Send;
    }
}