namespace Zatco
{
    partial class chang_pass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chang_pass));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Text_Pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.check_supp = new System.Windows.Forms.CheckBox();
            this.check_customer = new System.Windows.Forms.CheckBox();
            this.check_stores = new System.Windows.Forms.CheckBox();
            this.check_Mac = new System.Windows.Forms.CheckBox();
            this.checkper = new System.Windows.Forms.CheckBox();
            this.checkUser = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Text_User = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(231, 232);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(541, 49);
            this.textBox1.TabIndex = 2;
            this.textBox1.UseSystemPasswordChar = true;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chang_pass_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 240);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(176, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Re Password";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(346, 416);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Text_Pass
            // 
            this.Text_Pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Text_Pass.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Pass.ForeColor = System.Drawing.Color.Red;
            this.Text_Pass.Location = new System.Drawing.Point(231, 133);
            this.Text_Pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_Pass.MaxLength = 50;
            this.Text_Pass.Name = "Text_Pass";
            this.Text_Pass.PasswordChar = '*';
            this.Text_Pass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text_Pass.Size = new System.Drawing.Size(541, 49);
            this.Text_Pass.TabIndex = 1;
            this.Text_Pass.UseSystemPasswordChar = true;
            this.Text_Pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chang_pass_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 141);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(133, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(151, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // check_supp
            // 
            this.check_supp.AutoSize = true;
            this.check_supp.Location = new System.Drawing.Point(661, 338);
            this.check_supp.Name = "check_supp";
            this.check_supp.Size = new System.Drawing.Size(111, 21);
            this.check_supp.TabIndex = 17;
            this.check_supp.Text = "Supplier Data";
            this.check_supp.UseVisualStyleBackColor = true;
            this.check_supp.Visible = false;
            // 
            // check_customer
            // 
            this.check_customer.AutoSize = true;
            this.check_customer.Location = new System.Drawing.Point(422, 381);
            this.check_customer.Name = "check_customer";
            this.check_customer.Size = new System.Drawing.Size(123, 21);
            this.check_customer.TabIndex = 16;
            this.check_customer.Text = "Customer Data";
            this.check_customer.UseVisualStyleBackColor = true;
            this.check_customer.Visible = false;
            // 
            // check_stores
            // 
            this.check_stores.AutoSize = true;
            this.check_stores.Location = new System.Drawing.Point(422, 338);
            this.check_stores.Name = "check_stores";
            this.check_stores.Size = new System.Drawing.Size(69, 21);
            this.check_stores.TabIndex = 15;
            this.check_stores.Text = "Stores";
            this.check_stores.UseVisualStyleBackColor = true;
            this.check_stores.Visible = false;
            // 
            // check_Mac
            // 
            this.check_Mac.AutoSize = true;
            this.check_Mac.Location = new System.Drawing.Point(661, 381);
            this.check_Mac.Name = "check_Mac";
            this.check_Mac.Size = new System.Drawing.Size(85, 21);
            this.check_Mac.TabIndex = 14;
            this.check_Mac.Text = "Machines";
            this.check_Mac.UseVisualStyleBackColor = true;
            this.check_Mac.Visible = false;
            // 
            // checkper
            // 
            this.checkper.AutoSize = true;
            this.checkper.Location = new System.Drawing.Point(231, 381);
            this.checkper.Name = "checkper";
            this.checkper.Size = new System.Drawing.Size(98, 21);
            this.checkper.TabIndex = 13;
            this.checkper.Text = "Permission ";
            this.checkper.UseVisualStyleBackColor = true;
            this.checkper.Visible = false;
            // 
            // checkUser
            // 
            this.checkUser.AutoSize = true;
            this.checkUser.Location = new System.Drawing.Point(231, 338);
            this.checkUser.Name = "checkUser";
            this.checkUser.Size = new System.Drawing.Size(117, 21);
            this.checkUser.TabIndex = 12;
            this.checkUser.Text = "Edit User Data";
            this.checkUser.UseVisualStyleBackColor = true;
            this.checkUser.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 348);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(173, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "terms of reference";
            this.label4.Visible = false;
            // 
            // Text_User
            // 
            this.Text_User.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_User.Location = new System.Drawing.Point(231, 35);
            this.Text_User.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_User.MaxLength = 50;
            this.Text_User.Name = "Text_User";
            this.Text_User.Size = new System.Drawing.Size(541, 49);
            this.Text_User.TabIndex = 0;
            this.Text_User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chang_pass_KeyDown);
            this.Text_User.Leave += new System.EventHandler(this.Text_User_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe Print", 14.25F);
            this.comboBox1.ForeColor = System.Drawing.Color.Red;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(231, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(541, 50);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(717, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Change";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(717, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Change";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // chang_pass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(822, 481);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.check_supp);
            this.Controls.Add(this.check_customer);
            this.Controls.Add(this.check_stores);
            this.Controls.Add(this.check_Mac);
            this.Controls.Add(this.checkper);
            this.Controls.Add(this.checkUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Text_Pass);
            this.Controls.Add(this.Text_User);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "chang_pass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.chang_pass_Load);
            this.Enter += new System.EventHandler(this.button1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chang_pass_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Text_Pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_supp;
        private System.Windows.Forms.CheckBox check_customer;
        private System.Windows.Forms.CheckBox check_stores;
        private System.Windows.Forms.CheckBox check_Mac;
        private System.Windows.Forms.CheckBox checkper;
        private System.Windows.Forms.CheckBox checkUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Text_User;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}