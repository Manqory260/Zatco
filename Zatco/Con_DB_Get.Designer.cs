namespace Zatco
{
    partial class Con_DB_Get
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Con_DB_Get));
            this.text_DataBase = new System.Windows.Forms.TextBox();
            this.text_User = new System.Windows.Forms.TextBox();
            this.text_Pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Com_server = new System.Windows.Forms.ComboBox();
            this.butt_Connect = new System.Windows.Forms.Button();
            this.butt_save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_DataBase
            // 
            this.text_DataBase.Location = new System.Drawing.Point(111, 65);
            this.text_DataBase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_DataBase.Name = "text_DataBase";
            this.text_DataBase.Size = new System.Drawing.Size(255, 24);
            this.text_DataBase.TabIndex = 2;
            // 
            // text_User
            // 
            this.text_User.Location = new System.Drawing.Point(111, 110);
            this.text_User.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_User.Name = "text_User";
            this.text_User.Size = new System.Drawing.Size(255, 24);
            this.text_User.TabIndex = 3;
            // 
            // text_Pass
            // 
            this.text_Pass.Location = new System.Drawing.Point(111, 151);
            this.text_Pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_Pass.Name = "text_Pass";
            this.text_Pass.PasswordChar = '*';
            this.text_Pass.Size = new System.Drawing.Size(255, 24);
            this.text_Pass.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Base";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pass";
            // 
            // Com_server
            // 
            this.Com_server.FormattingEnabled = true;
            this.Com_server.Location = new System.Drawing.Point(111, 26);
            this.Com_server.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Com_server.Name = "Com_server";
            this.Com_server.Size = new System.Drawing.Size(255, 24);
            this.Com_server.TabIndex = 1;
            // 
            // butt_Connect
            // 
            this.butt_Connect.Location = new System.Drawing.Point(81, 215);
            this.butt_Connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butt_Connect.Name = "butt_Connect";
            this.butt_Connect.Size = new System.Drawing.Size(87, 28);
            this.butt_Connect.TabIndex = 5;
            this.butt_Connect.Text = "&Connect";
            this.butt_Connect.UseVisualStyleBackColor = true;
            this.butt_Connect.Click += new System.EventHandler(this.butt_Connect_Click);
            // 
            // butt_save
            // 
            this.butt_save.Location = new System.Drawing.Point(175, 215);
            this.butt_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butt_save.Name = "butt_save";
            this.butt_save.Size = new System.Drawing.Size(87, 28);
            this.butt_save.TabIndex = 6;
            this.butt_save.Text = "&Save";
            this.butt_save.UseVisualStyleBackColor = true;
            this.butt_save.Click += new System.EventHandler(this.butt_save_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(270, 215);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "&Shut Down";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Con_DB_Get
            // 
            this.AcceptButton = this.butt_Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(393, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.butt_save);
            this.Controls.Add(this.butt_Connect);
            this.Controls.Add(this.Com_server);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_Pass);
            this.Controls.Add(this.text_User);
            this.Controls.Add(this.text_DataBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Con_DB_Get";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to Data base";
            this.Load += new System.EventHandler(this.Con_DB_Get_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_DataBase;
        private System.Windows.Forms.TextBox text_User;
        private System.Windows.Forms.TextBox text_Pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Com_server;
        private System.Windows.Forms.Button butt_Connect;
        private System.Windows.Forms.Button butt_save;
        private System.Windows.Forms.Button button1;
    }
}