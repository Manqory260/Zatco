using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Edite_Receiving : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public Edite_Receiving()
        {
            InitializeComponent();
        
        }

        private void Edite_Receiving_Load(object sender, EventArgs e)
        {
            SqlCommand inv_com = new SqlCommand("Show_Receiving", con);
            inv_com.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader read = inv_com.ExecuteReader();
            while (read.Read())
            {
                ListViewItem lvl = new ListViewItem(read["INV_Num"].ToString());
                lvl.SubItems.Add(DateTime.Parse(read["Date"].ToString()).ToString("dd/MM/yyyy"));
                lvl.SubItems.Add(read["company"].ToString());
                lvl.SubItems.Add(read["boat"].ToString());
                lvl.SubItems.Add(read["Eng_SN"].ToString());
                listView1.Items.Add(lvl);
            }
            con.Close();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }


        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                if (Owner.Name == "Receiving_permission")
                {
                    Receiving_permission edit = (Receiving_permission)this.Owner;
                    edit._InvText.Text = listView1.SelectedItems[0].SubItems[0].Text;
                    edit.bindingInvoice(int.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                    this.Close();
                }
                else if (Owner.Name == "INVOICE")
                {
                    int number = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    Insert_to_invoice play = new Insert_to_invoice(number);
                    play.TopLevel = true;
                    play.StartPosition = FormStartPosition.Manual;
                    play.Location = this.Location;
                    play.Show(this.Owner);
                    this.Close();
                }
            }
            else
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    Receiving_permission edit = new Receiving_permission(int.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                    edit.TopLevel = true;
                    edit.Show();
                    edit._grid_selection_changed_event = true;
                }
            }

        }
    }
}
