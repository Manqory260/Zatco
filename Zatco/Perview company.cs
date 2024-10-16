using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Perview_company : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        DataTable tabel = new DataTable();
        public Perview_company()
        {
            InitializeComponent();
            
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // company mathond
        public void campany_Mathod()
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
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
         //boate mathond
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
                treeView1.Nodes.Clear();
                for (int i = 0; i <ne.Rows.Count; i++)
                {
                    SqlCommand count = new SqlCommand("count_Inv", con);
                    count.CommandType = CommandType.StoredProcedure;
                    count.Parameters.AddWithValue("@BID", ne.Rows[i][0]);
                    SqlDataAdapter cou = new SqlDataAdapter(count);
                    DataTable cout_tab = new DataTable();
                    cou.Fill(cout_tab);



                    treeView1.Nodes.Add(ne.Rows[i][2].ToString()+"   "+cout_tab.Rows[0][0].ToString());
            
                    SqlCommand nee = new SqlCommand("Engine_SN", con);
                    nee.CommandType = CommandType.StoredProcedure;
                    nee.Parameters.AddWithValue("@BI",ne.Rows[i][0]);
                    DataTable Eng = new DataTable();
                    SqlDataAdapter adbt = new SqlDataAdapter();
                    adbt.SelectCommand = nee;
                    adbt.Fill(Eng);
                    for (int e = 0; e < Eng.Rows.Count; e++)
                    {
                        treeView1.Nodes[i].Nodes.Add(Eng.Rows[e][0].ToString());
                    }
                }
            }
        }
        
        private void Invoices ()
        {
            SqlCommand inv = new SqlCommand("Invoice_Sales", con);
            inv.CommandType = CommandType.StoredProcedure;
            inv.Parameters.AddWithValue("@CID", comboBox1.SelectedValue);
            SqlDataAdapter ad = new SqlDataAdapter(inv);
            DataTable tab = new DataTable();
            ad.Fill(tab);
            dataGridView2.DataSource = tab;
            dataGridView2.Columns[6].Visible = false;
        }
        private void offers ()
        {
            SqlCommand offe = new SqlCommand("Offers", con);
            offe.CommandType = CommandType.StoredProcedure;
            offe.Parameters.AddWithValue("@CID", comboBox1.SelectedValue);
            SqlDataAdapter ade = new SqlDataAdapter(offe);
            DataTable tab= new DataTable();
            ade.Fill(tab);
            dataGridView3.DataSource = tab;
        }

        private void Total()
        {
            SqlCommand total = new SqlCommand("Total_Sales", con);
            total.CommandType = CommandType.StoredProcedure;
            total.Parameters.AddWithValue("@CID", comboBox1.SelectedValue);
            SqlDataAdapter ad = new SqlDataAdapter(total);
            DataTable tot = new DataTable();
            ad.Fill(tot);
            if (tot.Rows.Count > 0)
            {
                if (tot.Rows[0][0] != DBNull.Value)
                    textBox9.Text = Math.Round(Convert.ToDouble(tot.Rows[0][0].ToString()), 2, MidpointRounding.AwayFromZero).ToString();
                else textBox9.Text = "";
            }
        }
   
        private void BoatCombo()
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
                if (ne.Rows.Count > 0)
                {
                    comboBox2.DataSource = ne;
                    comboBox2.DisplayMember = "Name";
                    comboBox2.ValueMember = "Boat_ID";
                }
            }
        }
        private void Boat_Sales ()
        {
            SqlCommand Sales = new SqlCommand("Boate_inv_sales", con);
            Sales.CommandType = CommandType.StoredProcedure;
            Sales.Parameters.AddWithValue("@BID", comboBox2.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(Sales);
            DataTable t_sales = new DataTable();
            sda.Fill(t_sales);
            dataGridView1.DataSource = t_sales;
            dataGridView1.Columns[5].Visible = false;
        }

        private void Perview_company_Load(object sender, EventArgs e)
        {
            campany_Mathod();
            BoatCombo();
            tex_address.BackColor = tex_address.BackColor;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Com_ID";
            SqlCommand company_data = new SqlCommand("Company_select", con);
            company_data.CommandType = CommandType.StoredProcedure;
            company_data.Parameters.AddWithValue("@ID",comboBox1.SelectedValue);
            SqlDataAdapter ada = new SqlDataAdapter(company_data);
            tabel.Clear();
            ada.Fill(tabel);
            if (tabel.Rows.Count>0)
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
            Boate();
            Invoices();
            offers();
            Total();
            BoatCombo();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Boat_ID";
            SqlCommand Boat_data = new SqlCommand("sales_inv", con);
            Boat_data.CommandType = CommandType.StoredProcedure;
            Boat_data.Parameters.AddWithValue("@BID", comboBox2.SelectedValue);
            SqlDataAdapter adpt = new SqlDataAdapter(Boat_data);
            DataTable boat_data = new DataTable();
            adpt.Fill(boat_data);
            if (boat_data.Rows.Count>0)
            {
                tex_address.Text = boat_data.Rows[0][3].ToString();
                tex_office_num.Text = boat_data.Rows[0][4].ToString();
                tex_Manger.Text = boat_data.Rows[0][5].ToString();
                tex_mange_phone.Text = boat_data.Rows[0][6].ToString();

                SqlCommand Total_Boat = new SqlCommand("Boat_sales", con);
                Total_Boat.CommandType = CommandType.StoredProcedure;
                Total_Boat.Parameters.AddWithValue("@BID", comboBox2.SelectedValue);
                SqlDataAdapter sda = new SqlDataAdapter(Total_Boat);
                DataTable Boat_table = new DataTable();
                sda.Fill(Boat_table);
                if (Boat_table.Rows.Count > 0)
                {
                    if (Boat_table.Rows[0][0] != DBNull.Value)
                    {
                        tex_sales.Text = Math.Round(Convert.ToDouble(Boat_table.Rows[0][0])).ToString();
                    }
                    
                }
            }
            Boat_Sales();

            /// lisview add
            SqlCommand list = new SqlCommand("Engine_SN", con);
            list.CommandType = CommandType.StoredProcedure;
            list.Parameters.AddWithValue("@BI", comboBox2.SelectedValue);
            SqlDataAdapter lis = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            lis.Fill(dt);
            listView1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem eng = new ListViewItem(dt.Rows[i][0].ToString());
                listView1.Items.Add(eng);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button1.Visible = false;
            treeView1.Enabled = true;
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                Edite_Eng ne = new Edite_Eng();
                ne.TopLevel = true;
                ne.Show(this.Owner);
                ne.comb_cam.SelectedValue = comboBox1.SelectedValue;
                ne.comb_cam.DropDownStyle = ComboBoxStyle.Simple;
                ne.comb_cam.Enabled = false;
                ne.comb_Boat.SelectedIndex = comboBox2.SelectedIndex;
                ne.comb_Boat.DropDownStyle = ComboBoxStyle.Simple;
                ne.comb_Boat.Enabled = false;
                ne.eng_com.SelectedValue = listView1.SelectedItems[0].SubItems[0].Text;
                ne.eng_com.Enabled = false;
                ne.eng_com.DropDownStyle = ComboBoxStyle.Simple;
                ne.comb_model.DropDownStyle = ComboBoxStyle.Simple;
                ne.comb_model.Enabled = false;
                ne.but_save.Visible = false;
                ne.date.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Company es = new Company();
            es.TopLevel = true;
            es.Show(this.Owner);
            es.check.Checked = true;
            es.com_combo.SelectedValue = comboBox1.SelectedValue;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Boats update = new Boats();
            update.TopLevel = true;
            update.Show(this.Owner);
            update.check_box.Checked = true;
            update.com_company.SelectedValue = comboBox1.SelectedValue;
            update.Com_boat.SelectedValue = comboBox2.SelectedValue;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int inv = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int move = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                INVOICE start = new INVOICE(inv, move);
                start.TopLevel = true;
                start.Show(this.Owner);
                start._grid_selection_changed_event = true;
                //string Invoice = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //new_inv edit = new new_inv();
                //edit.TopLevel = true;
                //edit.Show(this.Owner);
                //edit.Edit(int.Parse(Invoice), Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));
                //if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value) == 1)
                //{
                //    edit.Tax_Invoice = true;
                //    edit.Non_Invoice = false;
                //}
                //else { edit.Tax_Invoice = false; edit.Non_Invoice = true; }
                //edit.Text = Invoice;
            }

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int inv = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                int move = Convert.ToInt32(dataGridView2.CurrentRow.Cells[6].Value);
                INVOICE start = new INVOICE(inv, move);
                start.TopLevel = true;
                start.Show(this.Owner);
                start._grid_selection_changed_event = true;


                //string Invoice = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //new_inv edit = new new_inv();
                //edit.TopLevel = true;
                //edit.Show(this.Owner);
                //edit.Edit(int.Parse(Invoice), Convert.ToInt32(dataGridView2.CurrentRow.Cells[6].Value));
                //if (Convert.ToInt32(dataGridView2.CurrentRow.Cells[6].Value) == 1)
                //{
                //    edit.Tax_Invoice = true;
                //    edit.Non_Invoice = false;
                //}
                //else { edit.Tax_Invoice = false; edit.Non_Invoice = true; }
                //edit.Text = Invoice;
            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.SelectedRows.Count != 0)
            {
                int num = int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
                Offers play = new Offers(num);
                play.TopLevel = true;
                play.Show(this.Owner);

            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            panel2.Enabled = true;
            panel2.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            listView1.Enabled = true;
            comboBox2.SelectedIndex = treeView1.SelectedNode.Index;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
