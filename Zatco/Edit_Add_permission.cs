using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Edit_Add_permission : Form
    {
#pragma warning disable IDE0044 // Add readonly modifier
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
#pragma warning restore IDE0044 // Add readonly modifier

        public Edit_Add_permission()
        {
            InitializeComponent();
            
            ListviewData();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        private void ListviewData ()
        {
            SqlCommand inv_com = new SqlCommand("Show_add_permission", con);
            inv_com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(inv_com);
            DataTable read = new DataTable();
            ad.Fill(read);

            for (int i = 0; i < read.Rows.Count; i++)
            {
                ListViewItem lvl = new ListViewItem(read.Rows[i]["INV_Num"].ToString());
                lvl.SubItems.Add(DateTime.Parse(read.Rows[i]["Date"].ToString()).ToString("dd/MM/yyyy"));
                lvl.SubItems.Add(read.Rows[i]["Name"].ToString());
                if (read.Rows[i]["Total"] != DBNull.Value) lvl.SubItems.Add(Math.Round(Convert.ToDouble(read.Rows[i]["Total"].ToString()), 2, MidpointRounding.AwayFromZero).ToString());
                else lvl.SubItems.Add(read.Rows[i]["Total"].ToString());
                listView1.Items.Add(lvl);
            }
            con.Close();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Edit_Add_permission_Load(object sender, EventArgs e)
        {
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            if (Owner != null)
            {
                int add_number = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                Add_permission play = (Add_permission)this.Owner;
                play._OpenAntherPermission(add_number);
                Close();
            }
            else
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int add_number = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    Add_permission play = new Add_permission(add_number);
                    play.TopLevel = true;
                    play.Show(this.Owner);
                }
            }

        }
    }
}
