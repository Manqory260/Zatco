using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Zatco
{
    public partial class Add_User : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public Add_User()
        {
            InitializeComponent();
        }
        public bool check = true;
        public CheckBox admin
        {
            set { checkBox1 = value;}
            get { return checkBox1; }
        }
        public CheckBox check_user
        {
            set { checkUser = value;}
            get { return checkUser; }
        }
        public CheckBox check_per
        {
            set { checkper = value; }
            get { return checkper; }
        }
        public CheckBox check_mac
        {
            set { check_Mac = value; }
            get { return check_Mac; }
        }
        public CheckBox check_custom
        {
            set { check_customer = value; }
            get { return check_customer; }
        }
        public CheckBox check_Stores
        {
            set { check_stores = value; }
            get { return check_stores; }
        }
        public CheckBox check_Supplier
        {
            set { check_supp = value; }
            get { return check_supp; }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (Text_User.Text == "" || Text_Pass.Text == "")
            { MessageBox.Show("Plesse enter user Name and Password","User",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
            else
            {
                if (Text_Pass.Text == textBox1.Text)
                {
                    SqlCommand user = new SqlCommand("user_n", con);
                    user.CommandType = CommandType.StoredProcedure;
                    user.Parameters.AddWithValue("@N", Text_User.Text);
                    user.Parameters.AddWithValue("@p", Text_Pass.Text);
                    user.Parameters.AddWithValue("@user", checkUser.Checked);
                    user.Parameters.AddWithValue("@per", checkper.Checked);
                    user.Parameters.AddWithValue("@sto", check_stores.Checked);
                    user.Parameters.AddWithValue("@cus", check_customer.Checked);
                    user.Parameters.AddWithValue("@sup", check_supp.Checked);
                    user.Parameters.AddWithValue("@mac", check_Mac.Checked);
                    user.Parameters.AddWithValue("@admin", checkBox1.Checked);
                    con.Open();
                    var sr = user.ExecuteScalar().ToString();
                    con.Close();
                    if (sr == "suc")
                    {
                        MessageBox.Show("The user has been added successfully","User",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else if (sr == "name is on")
                        MessageBox.Show("User already exists","User",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("password does not match", "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked== true)
            {
                check_supp.Checked = true;
                check_stores.Checked = true;
                check_Mac.Checked = true;
                check_customer.Checked = true;
                checkper.Checked = true;
                checkUser.Checked = true; ;
            }
            else
            {
                check_supp.Checked = false;
                check_stores.Checked = false;
                check_Mac.Checked = false;
                check_customer.Checked = false;
                checkper.Checked = false;
                checkUser.Checked = false; ;

            }
        }
    }
}
