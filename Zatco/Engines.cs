using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Engines : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        public Engines()
        {
            InitializeComponent();
           
        }
        public void boat (int com,int boat)
        {
            comboBox1.SelectedValue = com;
            comboBox2.SelectedValue = boat;
        }

        private void Engines_Load(object sender, EventArgs e)
        {
            SqlCommand arr = new SqlCommand("comp", con);
            arr.CommandType= CommandType.StoredProcedure;
            SqlDataAdapter dts = new SqlDataAdapter();
            DataTable ne = new DataTable();
            dts.SelectCommand = arr;
            dts.Fill(ne);       
            comboBox1.DataSource = ne;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Com_ID";
            /// combo box2 company
            int s = 0;
            s = int.Parse(comboBox1.SelectedValue.ToString());
            SqlCommand boat = new SqlCommand("Boat", con);
            boat.CommandType= CommandType.StoredProcedure;
            boat.Parameters.AddWithValue("@CI",s);
            SqlDataAdapter dtr = new SqlDataAdapter();
            DataTable dt = new DataTable();
            dtr.SelectCommand = boat;
            dtr.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Boat_ID";

            Model();
          }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Com_ID";
                SqlCommand boat = new SqlCommand("Boat", con);
                boat.CommandType = CommandType.StoredProcedure;
                boat.Parameters.AddWithValue("@CI", int.Parse(comboBox1.SelectedValue.ToString()));
                SqlDataAdapter dtr = new SqlDataAdapter();
                DataTable dt = new DataTable();
                dtr.SelectCommand = boat;
                dtr.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = DBNull.Value;
            row[1] = "NUll";
            dt.Rows.InsertAt(row, 0);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Boat_ID";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
                if (textBox1.Text != "")
                {
                    ////(@SN,@MO,@Ma,@Da,@CI,@BI,@Loc)
                    SqlCommand add = new SqlCommand("Engine_Num", con);
                    add.CommandType = CommandType.StoredProcedure;
                    add.Parameters.AddWithValue("@SN", textBox1.Text);
                    add.Parameters.AddWithValue("@MO", comboBox3.SelectedValue);
                    if (textBox3.Text == "")
                    {
                        add.Parameters.AddWithValue("Ma", DBNull.Value);
                    }
                    else
                    {
                        add.Parameters.AddWithValue("Ma", textBox3.Text);
                    }
                    add.Parameters.AddWithValue("Da", dateTimePicker1.Text);
                    add.Parameters.AddWithValue("CI", int.Parse(comboBox1.SelectedValue.ToString()));
                    add.Parameters.AddWithValue("BI", int.Parse(comboBox2.SelectedValue.ToString()));
                    if (textBox4.Text == "")
                    {
                        add.Parameters.AddWithValue("Loc", DBNull.Value);
                    }
                    else
                    {
                        add.Parameters.AddWithValue("Loc", textBox4.Text);
                    }
                    con.Open();
                    string str = add.ExecuteScalar().ToString();
                    con.Close();
                    if (str == "suc")
                    {
                        MessageBox.Show("Added successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Name is already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Please insert Engien SN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else MessageBox.Show("Select Boat Name from Combobox","Error" ,MessageBoxButtons.OK, MessageBoxIcon.Stop); comboBox2.Focus();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.FromArgb(255, 255, 128);    
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int com = 0 ;
            if (comboBox3.SelectedValue != DBNull.Value) { com = Convert.ToInt32(comboBox3.SelectedValue); }
            Models add = new Models();
            add.ShowDialog();
            Model();
            if (com != 0)
            {
                comboBox3.SelectedValue = com;

            }
            else comboBox3.SelectedValue = DBNull.Value;
        }

      private void Model ()
        {
            SqlCommand model = new SqlCommand("models_select", con);
            model.CommandType = CommandType.StoredProcedure;
            DataTable model_table = new DataTable();
            SqlDataAdapter mod_ad = new SqlDataAdapter(model);
            mod_ad.Fill(model_table);
            DataRow row = model_table.NewRow();
            row[0] = DBNull.Value;
            row[1] = "Null";
            model_table.Rows.InsertAt(row, 0);
            comboBox3.DataSource = model_table;
            comboBox3.DisplayMember = "Display";
            comboBox3.ValueMember = "Id";
        }
        

    }
}
