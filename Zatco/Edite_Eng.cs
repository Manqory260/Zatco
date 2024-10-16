using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Edite_Eng : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        public Edite_Eng()
        {
            InitializeComponent();
           
        }
        public ComboBox eng_com
        {
            set { comboBox4 = value; }
            get { return comboBox4; }
        }
        public TextBox text_1
        {
            set { textBox3 = value;}
            get { return textBox3; }
        }
        public TextBox tex_2
        {
            get { return textBox4; }
            set { textBox4 = value; }
        }
        public ComboBox comb_cam
        {
            set { comboBox1 = value; }
            get { return comboBox1; }
        }
        public ComboBox comb_Boat
        {
            set { comboBox2 = value; }
            get { return comboBox2; }
        }
        public ComboBox comb_model
        {
            set { comboBox3 = value; }
            get { return comboBox3; }
        }
        public Button but_save
        {
            set { button1 = value; }
            get { return button1; }
        }
        public DateTimePicker date
        {
            set { dateTimePicker1 = value; }
            get { return dateTimePicker1; }
        }
        private void Edite_Eng_Load(object sender, EventArgs e)
        {
            SqlCommand arr = new SqlCommand("comp", con);
            arr.CommandType = CommandType.StoredProcedure;
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
            boat.CommandType = CommandType.StoredProcedure;
            boat.Parameters.AddWithValue("@CI", s);
            SqlDataAdapter dtr = new SqlDataAdapter();
            DataTable dt = new DataTable();
            dtr.SelectCommand = boat;
            dtr.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Boat_ID";

            Model();
            Eng();
        }
        private void Model()
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public void Eng()
        {
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Boat_ID";
            if (comboBox2.SelectedValue != null)
            {
                SqlCommand nee = new SqlCommand("Engine_SN", con);
                nee.CommandType = CommandType.StoredProcedure;
                if (comboBox2.SelectedValue != DBNull.Value)
                {
                    nee.Parameters.AddWithValue("@BI", comboBox2.SelectedValue);
                }
                else
                {
                    nee.Parameters.AddWithValue("@BI", 0);
                }
                DataTable ne = new DataTable();
                SqlDataAdapter dts = new SqlDataAdapter();
                dts.SelectCommand = nee;
                dts.Fill(ne);
                 if (ne.Rows.Count == 0) 
                {
                    DataRow data = ne.NewRow();
                    data[0] = DBNull.Value;
                    data[1] = "Null";
                    ne.Rows.InsertAt(data, 0);
                }
                comboBox4.DataSource = ne;
                comboBox4.DisplayMember = "display";
                comboBox4.ValueMember = "Engine_SN";
            }
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
                if (ne.Rows.Count == 0) 
                {
                    DataRow data = ne.NewRow();
                    data[0] = DBNull.Value;
                    data[2] = "Null";
                    ne.Rows.InsertAt(data, 0);
                }
                comboBox2.DataSource = ne;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Boat_ID";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eng();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.DisplayMember = "display";
            comboBox4.ValueMember = "Engine_SN";
            SqlCommand select = new SqlCommand("Select_eng", con);
            select.CommandType = CommandType.StoredProcedure;
            select.Parameters.AddWithValue("@En", comboBox4.SelectedValue);
            SqlDataAdapter ad = new SqlDataAdapter(select);
            DataTable dat = new DataTable();
            ad.Fill(dat);
            if (dat.Rows.Count != 0)
            {
                if (dat.Rows[0][1] != DBNull.Value) comboBox3.SelectedValue = Convert.ToInt32(dat.Rows[0][1]); else comboBox3.SelectedValue = DBNull.Value;
                if (dat.Rows[0][2] != DBNull.Value) textBox3.Text = dat.Rows[0][2].ToString();
                if (dat.Rows[0][6] != DBNull.Value) textBox4.Text = dat.Rows[0][6].ToString();
                if (dat.Rows[0][3] != DBNull.Value) dateTimePicker1.Value = Convert.ToDateTime(dat.Rows[0][3]);
            }
            else
            {
                comboBox3.SelectedValue = DBNull.Value;
                textBox3.Text = "";
                textBox4.Text = "";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //@En varchar (50) , @mo int ,@date date ,@ma varchar (50),@co int , @bo int , @loc varchar(50)
            SqlCommand update = new SqlCommand("update_eng", con);
            update.CommandType = CommandType.StoredProcedure;
            update.Parameters.AddWithValue("@En", comboBox4.SelectedValue);
            update.Parameters.AddWithValue("@mo", comboBox3.SelectedValue);
            if (textBox3.Text != ""){update.Parameters.AddWithValue("@ma", textBox3.Text);}
            else { update.Parameters.AddWithValue("@ma",DBNull.Value);}
            update.Parameters.AddWithValue("@co", comboBox1.SelectedValue);
            update.Parameters.AddWithValue("@bo", comboBox2.SelectedValue);
            if (textBox4.Text != "") { update.Parameters.AddWithValue("@loc", textBox4.Text); }
            else { update.Parameters.AddWithValue("@loc", DBNull.Value); }
            update.Parameters.AddWithValue("@date", dateTimePicker1.Text);
            con.Open();
            update.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Engine data has been modified successfully", "Edite", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
