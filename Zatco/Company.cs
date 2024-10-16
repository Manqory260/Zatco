using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Company : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public Company()
        {
            InitializeComponent();
        }
        public void company_Mathod()
        {
            SqlCommand nee = new SqlCommand("[comp]", con);
            nee.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            SqlDataAdapter dts = new SqlDataAdapter();
            dts.SelectCommand = nee;
            dts.Fill(data);
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Com_ID";
        }
        public CheckBox check
        {
            set { checkBox1 = value; }
            get { return checkBox1; }
        }
        public ComboBox com_combo
        {
            set { comboBox1 = value; }
            get { return comboBox1; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (textBox9.Text != "" && textBox9.Text!= null)
                {
                    SqlCommand com = new SqlCommand("COM_ADD", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@N", textBox9.Text);
                    if (textBox4.Text != "") com.Parameters.AddWithValue("@P1", textBox4.Text);
                    else com.Parameters.AddWithValue("@P1", DBNull.Value);
                    if (textBox3.Text != "") com.Parameters.AddWithValue("@P2", textBox3.Text);
                    else com.Parameters.AddWithValue("@P2", DBNull.Value);
                    if (textBox8.Text != "") com.Parameters.AddWithValue("@OP", textBox8.Text);
                    else com.Parameters.AddWithValue("@OP", DBNull.Value);
                    if (textBox5.Text != "") com.Parameters.AddWithValue("@MP", textBox5.Text);
                    else com.Parameters.AddWithValue("@MP", DBNull.Value);
                    if (textBox6.Text != "") com.Parameters.AddWithValue("@EM", textBox6.Text);
                    else com.Parameters.AddWithValue("@EM", DBNull.Value);
                    if (textBox1.Text != "") com.Parameters.AddWithValue("@ADD", textBox1.Text);
                    else com.Parameters.AddWithValue("@ADD", DBNull.Value);
                    if (textBox2.Text != "") com.Parameters.AddWithValue("@MN", textBox2.Text);
                    else com.Parameters.AddWithValue("@MN", DBNull.Value);
                    if (textBox7.Text != "") com.Parameters.AddWithValue("@MAP", textBox7.Text);
                    else com.Parameters.AddWithValue("@MAP", DBNull.Value);
                    con.Open();
                    string s = com.ExecuteScalar().ToString();
                    con.Close();
                    switch (s)
                    {
                        case "name is in":
                            MessageBox.Show("Company Name Is In");
                            break;
                        case "suc":
                            MessageBox.Show("Added successfully", "added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            break;
                    }
                }
                else
                    MessageBox.Show("Please enter your company name", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand com = new SqlCommand("COM_update", con);
                com.CommandType = CommandType.StoredProcedure;
                if (textBox9.Text != "") com.Parameters.AddWithValue("@N", textBox9.Text);
                else com.Parameters.AddWithValue("@N", comboBox1.Text);
                if (textBox4.Text != "") com.Parameters.AddWithValue("@P1", textBox4.Text);
                else com.Parameters.AddWithValue("@P1", DBNull.Value);
                if (textBox3.Text != "") com.Parameters.AddWithValue("@P2", textBox3.Text);
                else com.Parameters.AddWithValue("@P2", DBNull.Value);
                if (textBox8.Text != "") com.Parameters.AddWithValue("@OP", textBox8.Text);
                else com.Parameters.AddWithValue("@OP", DBNull.Value);
                if (textBox5.Text != "") com.Parameters.AddWithValue("@MP", textBox5.Text);
                else com.Parameters.AddWithValue("@MP", DBNull.Value);
                if (textBox6.Text != "") com.Parameters.AddWithValue("@EM", textBox6.Text);
                else com.Parameters.AddWithValue("@EM", DBNull.Value);
                if (textBox1.Text != "") com.Parameters.AddWithValue("@ADD", textBox1.Text);
                else com.Parameters.AddWithValue("@ADD", DBNull.Value);
                if (textBox2.Text != "") com.Parameters.AddWithValue("@MN", textBox2.Text);
                else com.Parameters.AddWithValue("@MN", DBNull.Value);
                if (textBox7.Text != "") com.Parameters.AddWithValue("@MAP", textBox7.Text);
                else com.Parameters.AddWithValue("@MAP", DBNull.Value);
                com.Parameters.AddWithValue("@CID", comboBox1.SelectedValue);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Modified successfully", "Modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int index = comboBox1.SelectedIndex;
                company_Mathod();
                comboBox1.SelectedIndex = index;
            }
        }

        private void Company_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Visible = true;
                comboBox1.Location = textBox9.Location;
                label8.Visible = true;
                textBox9.Visible = false;
                company_Mathod();
            }
            else
            {
                comboBox1.Visible = false;
                label8.Visible = false;
                textBox9.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Com_ID";
            SqlCommand company_data = new SqlCommand("Company_select", con);
            company_data.CommandType = CommandType.StoredProcedure;
            company_data.Parameters.AddWithValue("@ID", comboBox1.SelectedValue);
            SqlDataAdapter ada = new SqlDataAdapter(company_data);
            DataTable tabel = new DataTable();
            ada.Fill(tabel);
            if (tabel.Rows.Count > 0)
            {
                textBox1.Text = tabel.Rows[0][7].ToString();
                textBox4.Text = tabel.Rows[0][2].ToString();
                textBox3.Text = tabel.Rows[0][3].ToString();
                textBox8.Text = tabel.Rows[0][4].ToString();
                textBox5.Text = tabel.Rows[0][5].ToString();
                textBox6.Text = tabel.Rows[0][6].ToString();
                textBox2.Text = tabel.Rows[0][8].ToString();
                textBox7.Text = tabel.Rows[0][9].ToString();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change the company name", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBox9.Visible = true;
                comboBox1.Location = new Point(155, 18);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
   

