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
using System.Configuration;

namespace Zatco
{
    public partial class all_inventory : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public all_inventory()
        {
            InitializeComponent();
            
        }

        private void all_inventory_Load(object sender, EventArgs e)
        {
            SqlCommand inv_com = new SqlCommand("select_inv_deficit", con);
            inv_com.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader read = inv_com.ExecuteReader();
            while (read.Read())
            {
                ListViewItem lvl = new ListViewItem(read["ID"].ToString());
                lvl.SubItems.Add(DateTime.Parse(read["Date"].ToString()).ToString("dd/MM/yyyy"));
                lvl.SubItems.Add(read["Name"].ToString());
                lvl.SubItems.Add(read["Deficit"].ToString());
                listView1.Items.Add(lvl);
            }
            con.Close();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                Inventory par = (Inventory)this.Owner;
                par.TextBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                par.Update_all();
                System.Media.SystemSounds.Exclamation.Play();
                this.Close();
            }
        }
    }
}
