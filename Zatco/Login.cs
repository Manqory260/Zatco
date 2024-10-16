using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        int CountOfEnter = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text_User.Text != "" || Text_Pass.Text != "")
            {
                if (CountOfEnter <6)
                {
                    SqlCommand com = new SqlCommand("user_in", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@N", Text_User.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable table = new DataTable();
                    ad.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("An error in the user's name  " + (5 - CountOfEnter).ToString(), "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CountOfEnter += 1;
                    }
                    else if (Text_Pass.Text != table.Rows[0][2].ToString())
                    {
                        MessageBox.Show("An error in the user's Password  " + (5 - CountOfEnter).ToString(), "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CountOfEnter += 1;
                    }
                    else if (Text_Pass.Text == table.Rows[0][2].ToString())
                    {
                        Form1 get = (Form1)this.Owner;
                        get.Table = table;
                        get.Stat = false;
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
                MessageBox.Show("Enter User and Password");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 play = (Form1)this.Owner;
            play.button1_Click_1(sender, e);
            this.Close();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Text_Pass.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Text_Pass.UseSystemPasswordChar = true;
        }

    }
}
