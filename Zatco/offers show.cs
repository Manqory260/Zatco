using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class offers_show : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        public offers_show()
        {
            InitializeComponent();
            
        }

        private void offers_show_Load(object sender, EventArgs e)
        {
            SqlCommand offers = new SqlCommand("select_offers", con);
            offers.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(offers);
            DataTable offer = new DataTable();
            sda.Fill(offer);
            if (offer.Rows.Count > 0)
            {
                for (int i = 0; i < offer.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(offer.Rows[i][0].ToString());
                    item.SubItems.Add(offer.Rows[i][1].ToString());
                    item.SubItems.Add(offer.Rows[i][2].ToString());
                    item.SubItems.Add(offer.Rows[i][3].ToString());
                    item.SubItems.Add(offer.Rows[i][4].ToString());
                    listView1.Items.Add(item);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (Owner.Name== "Form1")
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int number = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                    Offers start = new Offers(number);
                    start.TopLevel = true;
                    start.Show(this.Owner);
                }
            }
            else if (Owner.Name=="Offers")
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int number = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                    Offers start = (Offers)this.Owner;
                    start._InvText.Text = listView1.SelectedItems[0].SubItems[0].Text;
                    start.bindingInvoice(number);
                    this.Close();
                }
            }
        }
    }
}
