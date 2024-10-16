using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class search_Part : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public search_Part()
        {
            InitializeComponent();
        }
        public search_Part (string PartNumber, string parttype)
        {
            InitializeComponent();
            textBox1.Text = PartNumber;
            TextBoxChange();
            PartQuan();
        }


        public void search (string PartNumber, string parttype)
        {
            textBox1.Text = PartNumber;
            TextBoxChange();
        }
        public TextBox TextBox1
        {
            set { textBox1 = value; }
            get { return textBox1; }
        }
        
        public bool Lable_12
        { set { label12.Visible = value; } get { return label12.Visible; } }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBoxChange();

        }
        private void TextBoxChange()
        {
            SqlCommand type = new SqlCommand("get_Part_Storte", con);
            type.CommandType = CommandType.StoredProcedure;
            type.Parameters.AddWithValue("@PN", textBox1.Text);
            DataTable type_t = new DataTable();
            SqlDataAdapter type_ad = new SqlDataAdapter();
            type_ad.SelectCommand = type;
            type_ad.Fill(type_t);
            Data_Grid_PartType.DataSource = type_t;
       }
        private void PartQuan()
        {
            SqlCommand com = new SqlCommand("part_storge", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PN", textBox1.Text);
            com.Parameters.AddWithValue("@PT", Data_Grid_PartType.CurrentRow.Cells[1].Value);
            con.Open();
            SqlDataReader data = com.ExecuteReader();
            con.Close();

            ///////////////////////////////////////////////////////


            switch (checkBox1.Checked)
            {
                case false:
                    SqlCommand grid_Com = new SqlCommand("Out_part", con);
                    grid_Com.CommandType = CommandType.StoredProcedure;
                    grid_Com.Parameters.AddWithValue("@PN", textBox1.Text);
                    grid_Com.Parameters.AddWithValue("@PT", Data_Grid_PartType.CurrentRow.Cells[1].Value);
                    DataTable Out = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(grid_Com);
                    sda.Fill(Out);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Out;

                    SqlCommand IN_COM = new SqlCommand("in_Part", con);
                    IN_COM.CommandType = CommandType.StoredProcedure;
                    IN_COM.Parameters.AddWithValue("@PN", textBox1.Text);
                    IN_COM.Parameters.AddWithValue("@PT", Data_Grid_PartType.CurrentRow.Cells[1].Value);
                    DataTable IN = new DataTable();
                    SqlDataAdapter IN_sda = new SqlDataAdapter(IN_COM);
                    IN_sda.Fill(IN);
                    Datagrid_IN.DataSource = null;
                    Datagrid_IN.DataSource = IN;

                    break;

                case true:
                    SqlCommand Date_grid_Com = new SqlCommand("Date_Out_part", con);
                    Date_grid_Com.CommandType = CommandType.StoredProcedure;
                    Date_grid_Com.Parameters.AddWithValue("@PN", textBox1.Text);
                    Date_grid_Com.Parameters.AddWithValue("@PT", Data_Grid_PartType.CurrentRow.Cells[1].Value);
                    Date_grid_Com.Parameters.AddWithValue("@df", dateTimePicker1.Text);
                    Date_grid_Com.Parameters.AddWithValue("@dt", dateTimePicker2.Text);
                    DataTable Table_Out = new DataTable();
                    SqlDataAdapter Date_Sda = new SqlDataAdapter(Date_grid_Com);
                    Date_Sda.Fill(Table_Out);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Table_Out;

                    SqlCommand d_grid_Com = new SqlCommand("date_in_Part", con);
                    d_grid_Com.CommandType = CommandType.StoredProcedure;
                    d_grid_Com.Parameters.AddWithValue("@PN", textBox1.Text);
                    d_grid_Com.Parameters.AddWithValue("@PT", Data_Grid_PartType.CurrentRow.Cells[1].Value);
                    d_grid_Com.Parameters.AddWithValue("@df", dateTimePicker1.Text);
                    d_grid_Com.Parameters.AddWithValue("@dt", dateTimePicker2.Text);
                    DataTable d_IN = new DataTable();
                    SqlDataAdapter d_sda = new SqlDataAdapter(d_grid_Com);
                    d_sda.Fill(d_IN);
                    Datagrid_IN.DataSource = null;
                    Datagrid_IN.DataSource = d_IN;
                    break;
            }

        }


        private void search_Part_Load(object sender, EventArgs e)
        {
            SqlCommand part_Comp = new SqlCommand("comp_part", con);
            part_Comp.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = part_Comp;
            ad.Fill(data);
            string[] arr = new string[data.Rows.Count];
            con.Open();
            SqlDataReader read = part_Comp.ExecuteReader();
            int i = 0;
            while (read.Read())
            {
                arr[i] = read["PartNum"].ToString();
                i++;
            }
            con.Close();
            var comp = new AutoCompleteStringCollection();
            comp.AddRange(arr);
            textBox1.AutoCompleteCustomSource = comp;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
        }
      

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            PartQuan();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            PartQuan();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            PartQuan();
        }


        private void label12_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
            if (Owner.Name == "Groups")
            {
                Groups add = (Groups)this.Owner;
                DialogResult choise = MessageBox.Show("are You whant to add all type having this Part", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (choise == DialogResult.Yes)
                {
                    add.All_Part(textBox1.Text);
                }
                else if (choise == DialogResult.No)
                {
                    //add.part(textBox1.Text, comboBox1.SelectedValue.ToString());
                }
            }
            else if (Owner.Name == "Add_Group")
            {
                Add_Group add = (Add_Group)this.Owner;
                DialogResult choise = MessageBox.Show("are You whant to add all type having this Part", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (choise == DialogResult.Yes)
                {
                    add.All_Part(textBox1.Text);
                }
                else if (choise == DialogResult.No)
                {
                    //add.part(textBox1.Text, comboBox1.SelectedValue.ToString());
                }
            }
            else if (Owner.Name == "new_inv")
            {
                //new_inv add = (new_inv)this.Owner;
                //add.Add_part(textBox1.Text, comboBox1.Text, label9.Text);
            }
            else if (Owner.Name == "Receiving_permission")
            {
                //Receiving_permission play = (Receiving_permission)this.Owner;
                //play.Add_part(textBox1.Text, comboBox1.Text, label9.Text);
            } }
    

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBoxChange();
            }
        }


        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            TextBoxChange();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if ( dataGridView1.SelectedRows.Count!=0)
                {
                    int INV_Num = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
                    switch (dataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                    {
                        case "Tax inv":
                            INVOICE play = new INVOICE(INV_Num,1);
                            play.TopLevel = true;
                            play.Show();
                        play.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);

                        break;
                        case "Non Tax Inv":
                            INVOICE non = new INVOICE(INV_Num,2);
                            non.TopLevel = true;
                            non.Top = 1;
                        non.Show();
                        non.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
                            break;
                        case "Receiving Permission":
                            Receiving_permission start = new Receiving_permission(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value));
                            start.TopLevel = true;
                            start.Show();
                            start._grid_selection_changed_event = true;
                        start.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
                        break;
                    }
                }
            
            else
            {
                if ( dataGridView1.SelectedRows.Count != 0)
                {
                    int number = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
                    switch (dataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                    {
                        case "Tax inv":
                            INVOICE play = new INVOICE(number, 1);
                            play.TopLevel = true;
                            play.Show(this.Owner.Owner);
                            play._grid_selection_changed_event = true;
                            play.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
                            break;
                        case "Non Tax Inv":
                            INVOICE non = new INVOICE(number,2);
                            non.TopLevel = true;
                            non.Show(this.Owner.Owner);
                            non._grid_selection_changed_event = true;
                            non.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
                            break;
                        case "Receiving Permission":
                            Receiving_permission start = new Receiving_permission(number);
                            start.TopLevel = true;
                            start.Show(this.Owner.Owner);
                            start._grid_selection_changed_event = true;
                            start.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
                            break;
                    }
                }
            }

        }


        private void Datagrid_IN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
                    int INV_Num = Convert.ToInt32(Datagrid_IN.SelectedRows[0].Cells[2].Value);
                 if ( Datagrid_IN.SelectedRows.Count != 0)
                {
                    int inv = Convert.ToInt32(Datagrid_IN.SelectedRows[0].Cells[2].Value);
                    Add_permission play = new Add_permission(inv);
                    play.TopLevel = true;
                    play.Show();
                }
           
            

        }

        private void Data_Grid_PartType_CurrentCellChanged(object sender, EventArgs e)
        {
            PartQuan();
        }
    }
}
