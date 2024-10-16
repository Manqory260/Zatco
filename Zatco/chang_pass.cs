using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class chang_pass : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        DataTable tabel = new DataTable();
        public chang_pass()
        {
            InitializeComponent();
            
        }

        private void chang_pass_Load(object sender, EventArgs e)
        {
            this.Height = 320;
            label3.Visible = false;
            textBox1.Visible = false;
        }
        private DataTable User()
        {
            SqlCommand select_User = new SqlCommand("select_User", con);
            select_User.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(select_User);
            DataTable select_tabel = new DataTable();
            ad.Fill(select_tabel);
            comboBox1.DataSource = select_tabel;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            return select_tabel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text_User.Text != "" || Text_Pass.Text != "")
            {
                if (textBox1.Visible == false)
                {
                    SqlCommand com = new SqlCommand("user_in", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@N", Text_User.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable user = new DataTable();
                    ad.Fill(user);
                    bool check = Convert.ToBoolean(user.Rows[0][3]);
                    if (user.Rows.Count == 0)
                    {
                        MessageBox.Show("User does not exist","Users",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else if (user.Rows[0][2].ToString() == Text_Pass.Text)
                    {
                        this.Height = 434;
                        button1.Text = "Save";
                        Text_Pass.Text = "";
                        Text_Pass.Focus();
                        label3.Visible = true;
                        textBox1.Visible = true;
                        comboBox1.Visible = true;
                        Text_User.Visible = false;
                        label5.Visible = true;
                        Text_Pass.Enabled = false;
                        textBox1.Enabled = false;
                        label6.Visible = true;
                        User();
                        if (check)
                        {
                            comboBox1.Enabled = true;
                            comboBox1.SelectedValue = user.Rows[0][0]; 
                            check_customer.Visible = true;
                            check_Mac.Visible = true;
                            check_supp.Visible = true;
                            check_stores.Visible = true;
                            checkper.Visible = true;
                            checkUser.Visible = true;
                            label4.Visible = true;
                            this.Height = 530;
                        }
                        else { comboBox1.Enabled = false; comboBox1.SelectedValue = user.Rows[0][0]; }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password","User",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (Text_Pass.Text == textBox1.Text)
                    {
                        if (Text_Pass.TextLength >= 6)
                        {
                            SqlCommand add = new SqlCommand("Update_user", con);
                            add.CommandType = CommandType.StoredProcedure;
                            add.Parameters.AddWithValue("@Name", Text_User.Text);
                            add.Parameters.AddWithValue("@pass", Text_Pass.Text);
                            add.Parameters.AddWithValue("@ID", comboBox1.SelectedValue);
                            add.Parameters.AddWithValue("@user", checkUser.Checked);
                            add.Parameters.AddWithValue("@per", checkper.Checked);
                            add.Parameters.AddWithValue("@stor", check_stores.Checked);
                            add.Parameters.AddWithValue("@customer", check_customer.Checked);
                            add.Parameters.AddWithValue("@supp", check_supp.Checked);
                            add.Parameters.AddWithValue("@Machines",check_Mac.Checked);
                            con.Open();
                            add.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("User data has been changed", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Weak password fewest letters is six", "Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password do not match","Users",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Plesse Enter Possward and User Name","Users",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void chang_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            Text_User.Text = comboBox1.Text;
            SqlCommand User_data = new SqlCommand("user_data", con);
            User_data.CommandType = CommandType.StoredProcedure;
            User_data.Parameters.AddWithValue("@ID",comboBox1.SelectedValue);
            SqlDataAdapter adb = new SqlDataAdapter(User_data);
            tabel.Clear();
            adb.Fill(tabel);
            if (!Convert.ToBoolean(tabel.Rows[0][9]))
            {
                if (tabel.Rows.Count != 0)
                {
                    if (tabel.Rows[0][6] != DBNull.Value) {check_customer.Checked = Convert.ToBoolean(tabel.Rows[0][6]);check_customer.Enabled=true;} else { check_customer.Checked = false; }
                    if (tabel.Rows[0][3] != DBNull.Value) {checkUser.Checked = Convert.ToBoolean(tabel.Rows[0][3]);checkUser.Enabled=true;} else { checkUser.Checked = false; }
                    if (tabel.Rows[0][4] != DBNull.Value) {checkper.Checked = Convert.ToBoolean(tabel.Rows[0][4]);checkper.Enabled = true;} else { checkper.Checked = false; }
                    if (tabel.Rows[0][5] != DBNull.Value) {check_stores.Checked = Convert.ToBoolean(tabel.Rows[0][5]);check_stores.Enabled = true;} else { check_stores.Checked = false; }
                    if (tabel.Rows[0][7] != DBNull.Value) {check_supp.Checked = Convert.ToBoolean(tabel.Rows[0][7]);check_supp.Enabled = true;} else { check_supp.Checked = false; }
                    if (tabel.Rows[0][8] != DBNull.Value) {check_Mac.Checked = Convert.ToBoolean(tabel.Rows[0][8]);check_Mac.Enabled= true;} else { check_Mac.Checked = false; }
                }
            }
            else
            {
                check_customer.Checked = true;
                check_customer.Enabled = false;
                check_Mac.Checked = true;
                check_Mac.Enabled = false;
                check_stores.Enabled = false;
                check_stores.Checked = true;
                check_supp.Enabled = false;
                check_supp.Checked = true;
                checkper.Enabled = false;
                checkper.Checked = true;
                checkUser.Enabled = false;
                checkUser.Checked = true;

            }
            Text_Pass.Text = tabel.Rows[0][2].ToString();
            textBox1.Text = tabel.Rows[0][2].ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Text_User.Visible = true;
            Text_User.Focus();
        }

        private void Text_User_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Visible == true)
            {
                Text_User.Visible = false;
                if (Text_User.Text != comboBox1.Text)
                {
                    label5.Text = Text_User.Text;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (!textBox1.Enabled)
            {
                Text_Pass.Text = "";
                textBox1.Text = "";
                Text_Pass.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                Text_Pass.Enabled = false;
                textBox1.Enabled = false;
                Text_Pass.Text = tabel.Rows[0][2].ToString();
                textBox1.Text = tabel.Rows[0][2].ToString();

            }
        }
    }
}