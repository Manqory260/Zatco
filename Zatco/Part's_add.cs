using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Zatco
{
    public partial class Part_s_add : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);


        public Part_s_add()
        {
            InitializeComponent();
          
            AutoComplete();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (Text_PartNum.Text != "" && Text_PartType.Text != "" && Text_Location.Text != "" && Text_Discription.Text != "" && Text_Quantity.Text != "" && Text_Minimum.Text!="" && Text_Price.Text != "")
            {
                SqlCommand insert_command = new SqlCommand("parts_New_add", con);
                insert_command.CommandType = CommandType.StoredProcedure;
                insert_command.Parameters.AddWithValue("@P", Text_PartNum.Text);
                insert_command.Parameters.AddWithValue("@T", Text_PartType.Text);
                insert_command.Parameters.AddWithValue("@L", Text_Location.Text);
                insert_command.Parameters.AddWithValue("@q",Convert.ToInt32(Text_Quantity.Text));
                insert_command.Parameters.AddWithValue("@d", Text_Discription.Text);
                insert_command.Parameters.AddWithValue("@m",Convert.ToInt32(Text_Minimum.Text));
                insert_command.Parameters.AddWithValue("@R",Convert.ToDouble(Text_Price.Text));
                con.Open();
                string messg = insert_command.ExecuteScalar().ToString();
                con.Close();
                MessageBox.Show(messg, "Part's", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (messg == "Part has been added successfully")
                {
                    Text_Minimum.Text = "0";
                    Text_PartNum.Text = "";
                    Text_PartType.Text = "";
                    Text_Price.Text = "0.0";
                    Text_Quantity.Text = "";
                    if (Owner.Name == "parts")
                    {
                        parts parint = (parts)this.Owner;
                        parint.dataBind(sender, e);
                    }
                    AutoComplete();
                    Text_PartNum.Focus();
                }
            }
            else MessageBox.Show("plesse complete Part Data", "part's", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        private void AutoComplete ()
        {
            // Part Number Auto complete

            Text_PartNum.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Text_PartNum.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            SqlCommand auto_com = new SqlCommand("comp_part", con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = auto_com.ExecuteReader();
                while (reader.Read())
                {
                    String PartNum = reader["PartNum"].ToString();
                    source.Add(PartNum);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            Text_PartNum.AutoCompleteCustomSource = source;

            ////////////////////////////////////////////////////////////////////////
            //// auto complete Part Type
        
            Text_PartType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Text_PartType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection PartTypeAuto = new AutoCompleteStringCollection();

            SqlCommand newcom = new SqlCommand("select p.PartType  from Parts p group by p.PartType", con);
            SqlDataReader read;
            try
            {
                con.Open();
                read = newcom.ExecuteReader();
                while (read.Read())
                {
                    string PartType =  read["PartType"].ToString();
                    PartTypeAuto.Add(PartType);
                }
                con.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }
            Text_PartType.AutoCompleteCustomSource = PartTypeAuto;
            //////////////////////////////////////////////////////////////  
            // Auto complete Discription

            Text_Discription.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Text_Discription.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DiscriptionAutoComplete = new AutoCompleteStringCollection();

            SqlCommand Discription_com = new SqlCommand("select p.Discription  from Parts p  group by Discription", con);
            SqlDataReader Discription_reader;
            try
            {
                con.Open();
                Discription_reader = Discription_com.ExecuteReader();
                while (Discription_reader.Read())
                {
                    string Discrption = Discription_reader["Discription"].ToString();
                    DiscriptionAutoComplete.Add(Discrption);
                }
                con.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }
            Text_Discription.AutoCompleteCustomSource = DiscriptionAutoComplete;
            //////////////////////////////////////////////////////////////////////////////
            // auto complete location
            Text_Location.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Text_Location.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection LocationAutoComplete = new AutoCompleteStringCollection();

            SqlCommand Location_com = new SqlCommand("select p.Location  from Parts p  group by Location", con);
            SqlDataReader Location_reader;
            try
            {
                con.Open();
                Location_reader = Location_com.ExecuteReader();
                while (Location_reader.Read())
                {
                    string Location = Location_reader["Location"].ToString();
                    LocationAutoComplete.Add(Location);
                }
                con.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }
            Text_Location.AutoCompleteCustomSource = LocationAutoComplete;
            //

        }

        private void Text_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void Text_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void Text_Discription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_save_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Text_Discription.Text = "";
            Text_Location.Text = "";
            Text_Minimum.Text = "0";
            Text_PartNum.Text = "";
            Text_PartType.Text = "";
            Text_Price.Text = "0.0";
            Text_Quantity.Text = "";
            Text_PartNum.Focus();       
        }

        private void Text_Discription_Enter(object sender, EventArgs e)
        {
            Text_Discription.SelectionStart = 0;
            Text_Discription.SelectionLength = Text_Discription.Text.Length;
        }

        private void Text_Location_Enter(object sender, EventArgs e)
        {
            Text_Discription.SelectionStart = Text_Discription.Text.Length;
            Text_Discription.SelectionLength = Text_Discription.Text.Length;
        }
    }
}