using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Zatco
{
    public partial class Boats : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public Boats()
        {
            InitializeComponent();
        }
        public void Company(int value )
        {
            comboBox1.SelectedValue = value;
        }
        public CheckBox check_box
        {
            set { checkBox1 = value; }
            get { return checkBox1; }
        }
        public  ComboBox Com_boat
        {
            set { comboBox2 = value; }
            get { return comboBox2; }
        }
        public ComboBox com_company
        {
            set { comboBox1 = value; }
            get { return comboBox1; }
        }
        public void Boate()
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Com_ID";
            if (comboBox1.SelectedValue != null)
            {
                SqlCommand com = new SqlCommand("NumBoate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Com", comboBox1.SelectedValue);
                SqlDataAdapter dts = new SqlDataAdapter();
                DataTable ne = new DataTable();
                dts.SelectCommand = com;
                dts.Fill(ne);
                DataRow data = ne.NewRow();
                data[0] = DBNull.Value;
                data[2] = "Null";
                ne.Rows.InsertAt(data, 0);
                comboBox2.DataSource = ne;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Boat_ID";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (textBox1.Text != "")
                {
                    SqlCommand com = new SqlCommand("BOAT_ADD", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ID", int.Parse(comboBox1.SelectedValue.ToString()));
                    com.Parameters.AddWithValue("@N", textBox1.Text);
                    com.Parameters.AddWithValue("@A", textBox2.Text);
                    com.Parameters.AddWithValue("@P", textBox3.Text);
                    com.Parameters.AddWithValue("@MN", textBox4.Text);
                    com.Parameters.AddWithValue("@MP", textBox5.Text);
                    con.Open();
                    string str = com.ExecuteScalar().ToString();
                    con.Close();
                    switch (str)
                    {
                        case "suc":
                            MessageBox.Show("Added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            break;
                        case "it in":
                            MessageBox.Show("Boat name is in database", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            break;
                    }
                }
                else
                    MessageBox.Show("plez Enter Boat Name", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                SqlCommand update_com = new SqlCommand("boat_update", con);
                update_com.CommandType = CommandType.StoredProcedure;
                update_com.Parameters.AddWithValue("@CID", int.Parse(comboBox1.SelectedValue.ToString()));
                if (textBox1.Text != "") update_com.Parameters.AddWithValue("@N", textBox1.Text);
                else update_com.Parameters.AddWithValue("@N", comboBox2.Text);
                update_com.Parameters.AddWithValue("@A", textBox2.Text);
                update_com.Parameters.AddWithValue("@P", textBox3.Text);
                update_com.Parameters.AddWithValue("@MN", textBox4.Text);
                update_com.Parameters.AddWithValue("@MP", textBox5.Text);
                update_com.Parameters.AddWithValue("@ID",Convert.ToInt32(comboBox2.SelectedValue));
                con.Open();
                update_com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Modified successfully", "Modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int index = comboBox2.SelectedIndex;
                Boate();
                comboBox2.SelectedIndex = index;
            }
        }

        private void Boats_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zatcoDBDataSet.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.zatcoDBDataSet.Company);
            Boate();

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            comboBox2.Location = new Point(339, 109);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Boat_ID";
            SqlCommand Boat_data = new SqlCommand("sales_inv", con);
            Boat_data.CommandType = CommandType.StoredProcedure;
            if(comboBox2.SelectedValue != null) Boat_data.Parameters.AddWithValue("@BID", comboBox2.SelectedValue);
            else { Boat_data.Parameters.AddWithValue("@BID",DBNull.Value); }
            SqlDataAdapter adpt = new SqlDataAdapter(Boat_data);
            DataTable boat_data = new DataTable();
            adpt.Fill(boat_data);
            if (boat_data.Rows.Count > 0)
            {
                textBox2.Text = boat_data.Rows[0][3].ToString();
                textBox3.Text = boat_data.Rows[0][4].ToString();
                textBox4.Text = boat_data.Rows[0][5].ToString();
                textBox5.Text = boat_data.Rows[0][6].ToString();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox2.Visible = true;
                textBox1.Visible = false;
                label8.Visible = true;
                comboBox2.Location = textBox1.Location;
            }
            else
            { 
                textBox1.Visible = true; 
                comboBox2.Visible = false; 
                label8.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boate();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
