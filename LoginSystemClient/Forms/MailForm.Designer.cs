
namespace LoginSystemClient.Forms
{
    partial class MailForm
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.napiszWiadomośćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmieńHasłoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmieńPytanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odświeżToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wylogujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjdźToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.AnswerButton = new System.Windows.Forms.Button();
            this.NextSendButton = new System.Windows.Forms.Button();
            this.MessageList = new System.Windows.Forms.ListView();
            this.Nadawca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.napiszWiadomośćToolStripMenuItem,
            this.opcjeToolStripMenuItem,
            this.odświeżToolStripMenuItem,
            this.wylogujToolStripMenuItem,
            this.wyjdźToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(600, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // napiszWiadomośćToolStripMenuItem
            // 
            this.napiszWiadomośćToolStripMenuItem.Name = "napiszWiadomośćToolStripMenuItem";
            this.napiszWiadomośćToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.napiszWiadomośćToolStripMenuItem.Text = "Napisz wiadomość";
            this.napiszWiadomośćToolStripMenuItem.Click += new System.EventHandler(this.napiszWiadomośćToolStripMenuItem_Click);
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmieńHasłoToolStripMenuItem,
            this.zmieńPytanieToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // zmieńHasłoToolStripMenuItem
            // 
            this.zmieńHasłoToolStripMenuItem.Name = "zmieńHasłoToolStripMenuItem";
            this.zmieńHasłoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zmieńHasłoToolStripMenuItem.Text = "Zmień hasło";
            this.zmieńHasłoToolStripMenuItem.Click += new System.EventHandler(this.zmieńHasłoToolStripMenuItem_Click);
            // 
            // zmieńPytanieToolStripMenuItem
            // 
            this.zmieńPytanieToolStripMenuItem.Name = "zmieńPytanieToolStripMenuItem";
            this.zmieńPytanieToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zmieńPytanieToolStripMenuItem.Text = "Zmień pytanie";
            this.zmieńPytanieToolStripMenuItem.Click += new System.EventHandler(this.zmieńPytanieToolStripMenuItem_Click);
            // 
            // odświeżToolStripMenuItem
            // 
            this.odświeżToolStripMenuItem.Name = "odświeżToolStripMenuItem";
            this.odświeżToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.odświeżToolStripMenuItem.Text = "Odśwież";
            this.odświeżToolStripMenuItem.Click += new System.EventHandler(this.odświeżToolStripMenuItem_Click);
            // 
            // wylogujToolStripMenuItem
            // 
            this.wylogujToolStripMenuItem.Name = "wylogujToolStripMenuItem";
            this.wylogujToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.wylogujToolStripMenuItem.Text = "Wyloguj";
            this.wylogujToolStripMenuItem.Click += new System.EventHandler(this.wylogujToolStripMenuItem_Click);
            // 
            // wyjdźToolStripMenuItem
            // 
            this.wyjdźToolStripMenuItem.Name = "wyjdźToolStripMenuItem";
            this.wyjdźToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.wyjdźToolStripMenuItem.Text = "Wyjdź";
            this.wyjdźToolStripMenuItem.Click += new System.EventHandler(this.wyjdźToolStripMenuItem_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.Location = new System.Drawing.Point(202, 27);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(381, 354);
            this.MessageTextBox.TabIndex = 2;
            // 
            // AnswerButton
            // 
            this.AnswerButton.Location = new System.Drawing.Point(202, 387);
            this.AnswerButton.Name = "AnswerButton";
            this.AnswerButton.Size = new System.Drawing.Size(182, 23);
            this.AnswerButton.TabIndex = 3;
            this.AnswerButton.Text = "Odpowiedz";
            this.AnswerButton.UseVisualStyleBackColor = true;
            this.AnswerButton.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // NextSendButton
            // 
            this.NextSendButton.Location = new System.Drawing.Point(401, 387);
            this.NextSendButton.Name = "NextSendButton";
            this.NextSendButton.Size = new System.Drawing.Size(182, 23);
            this.NextSendButton.TabIndex = 4;
            this.NextSendButton.Text = "Przekaż dalej";
            this.NextSendButton.UseVisualStyleBackColor = true;
            this.NextSendButton.Click += new System.EventHandler(this.NextSendButton_Click);
            // 
            // MessageList
            // 
            this.MessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nadawca,
            this.Data});
            this.MessageList.HideSelection = false;
            this.MessageList.Location = new System.Drawing.Point(12, 27);
            this.MessageList.MultiSelect = false;
            this.MessageList.Name = "MessageList";
            this.MessageList.Size = new System.Drawing.Size(184, 383);
            this.MessageList.TabIndex = 5;
            this.MessageList.UseCompatibleStateImageBehavior = false;
            this.MessageList.View = System.Windows.Forms.View.Details;
            this.MessageList.SelectedIndexChanged += new System.EventHandler(this.MessageList_SelectedIndexChanged);
            // 
            // Nadawca
            // 
            this.Nadawca.Text = "Nadawca";
            this.Nadawca.Width = 91;
            // 
            // Data
            // 
            this.Data.Text = "Data";
            this.Data.Width = 89;
            // 
            // MailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 422);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.NextSendButton);
            this.Controls.Add(this.AnswerButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MailForm";
            this.Text = "MailForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MailForm_FormClosing);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip MainMenu;
        public System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem odświeżToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem wylogujToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem napiszWiadomośćToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem zmieńHasłoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem zmieńPytanieToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem wyjdźToolStripMenuItem;
        public System.Windows.Forms.TextBox MessageTextBox;
        public System.Windows.Forms.Button AnswerButton;
        public System.Windows.Forms.Button NextSendButton;
        public System.Windows.Forms.ListView MessageList;
        private System.Windows.Forms.ColumnHeader Nadawca;
        private System.Windows.Forms.ColumnHeader Data;
    }
}