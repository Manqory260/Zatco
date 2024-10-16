using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class supplier_data : Form
    {
        public supplier_data()
        {
            InitializeComponent();
            
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Sup_ID";
            comboBox1.DisplayMember = "Name";
            data_phone();
            datagrid_data();
            total_pur();
        }

        private void supplier_data_Load(object sender, EventArgs e)
        {
            SupData();
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
        private void data_phone()
        {
            SqlCommand com = new SqlCommand("supplier_data", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", comboBox1.SelectedValue);
            SqlDataAdapter adabt = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            adabt.Fill(data);
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
        private void datagrid_data ()
        {
            SqlCommand com = new SqlCommand("supplier_pur", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sup", comboBox1.SelectedValue);
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void total_pur()
        {
            SqlCommand tot = new SqlCommand("supplier_sum_total", con);
            tot.CommandType = CommandType.StoredProcedure;
            tot.Parameters.AddWithValue("@sup", comboBox1.SelectedValue);
            SqlDataAdapter ad = new SqlDataAdapter(tot);
            DataTable tab = new DataTable();
            ad.Fill(tab);
            if (tab.Rows.Count != 0) { textBox1.Text = tab.Rows[0][0].ToString(); }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Number = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Add_permission play = new Add_permission(Number);
            play.TopLevel = true;
            play.Show(this.Owner);
        }

    }
}
