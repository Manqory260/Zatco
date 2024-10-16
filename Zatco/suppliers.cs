using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Zatco
{
    public partial class suppliers : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public suppliers()
        {
            InitializeComponent();
        }

        string Name_Of_sup;
        public CheckBox CheckBox1
        {
            set { checkBox2 = value; }
            get { return checkBox2; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Update_supplier();
                SupData();
                MessageBox.Show("Update Successfuly", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!comboBox1.Visible) { ChangeName_Lable_Click(sender, e); }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    ///@Na,@Mo,@OF,@EM,@Add,@BN,@BA,@B2,@Ba2,@B3,@Ba3
                    SqlCommand com = new SqlCommand("suppliers_Add", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Na", textBox1.Text);
                    if (textBox2.Text == "") com.Parameters.AddWithValue("@Mo", DBNull.Value); else com.Parameters.AddWithValue("@Mo", textBox2.Text);
                    if (textBox3.Text == "") com.Parameters.AddWithValue("@OF", DBNull.Value); else com.Parameters.AddWithValue("@OF", textBox3.Text);
                    if (textBox4.Text == "") com.Parameters.AddWithValue("@EM", DBNull.Value); else com.Parameters.AddWithValue("@EM", textBox4.Text);
                    if (textBox5.Text == "") com.Parameters.AddWithValue("@Add", DBNull.Value); else com.Parameters.AddWithValue("Add", textBox5.Text);
                    if (textBox6.Text == "") com.Parameters.AddWithValue("@BN", DBNull.Value); else com.Parameters.AddWithValue("BN", textBox6.Text);
                    if (textBox7.Text == "") com.Parameters.AddWithValue("@BA", DBNull.Value); else com.Parameters.AddWithValue("BA", textBox7.Text);
                    if (textBox8.Text == "") com.Parameters.AddWithValue("@B2", DBNull.Value); else com.Parameters.AddWithValue("B2", textBox8.Text);
                    if (textBox9.Text == "") com.Parameters.AddWithValue("@Ba2", DBNull.Value); else com.Parameters.AddWithValue("Ba2", textBox9.Text);
                    if (textBox10.Text == "") com.Parameters.AddWithValue("@B3", DBNull.Value); else com.Parameters.AddWithValue("B3", textBox10.Text);
                    if (textBox11.Text == "") com.Parameters.AddWithValue("@Ba3", DBNull.Value); else com.Parameters.AddWithValue("Ba3", textBox11.Text);
                    con.Open();
                    string str = com.ExecuteScalar().ToString();
                    con.Close();
                    if (str == "suc")
                    {
                        MessageBox.Show("Added successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Name is already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Supplier Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox1.Visible = true;
                textBox1.Visible = false;
                SupData();
                ChangeName_Lable.Visible = true;
                ChangeName_Lable.Text = "Change Name";
            }
            else
            {
                comboBox1.Visible = false;
                textBox1.Visible = true;
                ChangeName_Lable.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
            }
        }
        private void SupData()
        {
            SqlCommand combo_com = new SqlCommand("Supplier_Combo", con);
            combo_com.CommandType = CommandType.StoredProcedure;
            DataTable comb_tab = new DataTable();
            SqlDataAdapter combo_adpter = new SqlDataAdapter(combo_com);
            combo_adpter.Fill(comb_tab);
            comboBox1.DataSource = comb_tab;
            comboBox1.ValueMember = "Sup_ID";
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Sup_ID";
            comboBox1.DisplayMember = "Name";
            SqlCommand com = new SqlCommand("supplier_data", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", comboBox1.SelectedValue);
            SqlDataAdapter adabt = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            adabt.Fill(data);
            textBox1.Text = data.Rows[0][1].ToString();
            textBox2.Text = data.Rows[0][2].ToString();
            textBox3.Text = data.Rows[0][3].ToString();
            textBox4.Text = data.Rows[0][4].ToString();
            textBox6.Text = data.Rows[0][6].ToString();
            textBox7.Text = data.Rows[0][7].ToString();
            textBox8.Text = data.Rows[0][8].ToString();
            textBox9.Text = data.Rows[0][9].ToString();
            textBox10.Text = data.Rows[0][10].ToString();
            textBox11.Text = data.Rows[0][11].ToString();
            textBox5.Text = data.Rows[0][5].ToString();
        }
        private void Update_supplier()
        {
            SqlCommand com = new SqlCommand("Update_supplier", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Na",textBox1.Text);
            if (textBox2.Text == "") com.Parameters.AddWithValue("@Mo", DBNull.Value); else com.Parameters.AddWithValue("@Mo", textBox2.Text);
            if (textBox3.Text == "") com.Parameters.AddWithValue("@OF", DBNull.Value); else com.Parameters.AddWithValue("@OF", textBox3.Text);
            if (textBox4.Text == "") com.Parameters.AddWithValue("@EM", DBNull.Value); else com.Parameters.AddWithValue("@EM", textBox4.Text);
            if (textBox5.Text == "") com.Parameters.AddWithValue("@Add", DBNull.Value); else com.Parameters.AddWithValue("Add", textBox5.Text);
            if (textBox6.Text == "") com.Parameters.AddWithValue("@BN", DBNull.Value); else com.Parameters.AddWithValue("BN", textBox6.Text);
            if (textBox7.Text == "") com.Parameters.AddWithValue("@BA", DBNull.Value); else com.Parameters.AddWithValue("BA", textBox7.Text);
            if (textBox8.Text == "") com.Parameters.AddWithValue("@B2", DBNull.Value); else com.Parameters.AddWithValue("B2", textBox8.Text);
            if (textBox9.Text == "") com.Parameters.AddWithValue("@Ba2", DBNull.Value); else com.Parameters.AddWithValue("Ba2", textBox9.Text);
            if (textBox10.Text == "") com.Parameters.AddWithValue("@B3", DBNull.Value); else com.Parameters.AddWithValue("B3", textBox10.Text);
            if (textBox11.Text == "") com.Parameters.AddWithValue("@Ba3", DBNull.Value); else com.Parameters.AddWithValue("Ba3", textBox11.Text);
            com.Parameters.AddWithValue("@ID", comboBox1.SelectedValue);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ChangeName_Lable_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible)
            {
                comboBox1.Visible = false;
                textBox1.Visible = true;
                ChangeName_Lable.Text = "Cancel";
                Name_Of_sup = textBox1.Text;
            }
            else
            {
                comboBox1.Visible = true;
                textBox1.Visible = false;
                textBox1.Text = Name_Of_sup;
                ChangeName_Lable.Text = "Change Name";
            }
        }
    }
}