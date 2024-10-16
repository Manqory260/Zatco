using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace Zatco
{
    public partial class Edit_Invoice : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
       
        public Edit_Invoice()
        {
            InitializeComponent();
            
        }

        private void Edit_Invoice_Load(object sender, EventArgs e)
        {
            SqlCommand inv_com = new SqlCommand("Tax_invoice_view", con);
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


            inv_com = new SqlCommand("non_invoice_view", con);
            inv_com.CommandType = CommandType.StoredProcedure;
            con.Open();
            read = inv_com.ExecuteReader();
            while (read.Read())
            {
                ListViewItem lvl = new ListViewItem(read["INV_Num"].ToString());
                lvl.SubItems.Add(DateTime.Parse(read["Date"].ToString()).ToString("dd/MM/yyyy"));
                lvl.SubItems.Add(read["company"].ToString());
                lvl.SubItems.Add(read["boat"].ToString());
                lvl.SubItems.Add(read["Eng_SN"].ToString());
                listView2.Items.Add(lvl);
            }
            con.Close();
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            int Invoice;
            if (Owner != null)
            {
               Invoice = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
               INVOICE edit = (INVOICE)this.Owner;
               edit.Check_taxes = false;
               edit.InvText.Text = Invoice.ToString();
               edit.BindingInvoice(Invoice, 1);
               this.Close();
            }
            else
            {
                Invoice = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                INVOICE edit = new INVOICE(Invoice, 1);
                edit.TopLevel = true;
                edit.Show();
                edit._grid_selection_changed_event = true;
            }

        }

        private void ListView2_DoubleClick(object sender, EventArgs e)
        {
            int Invoice;
            if ( Owner != null)
            {
                Invoice = Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text);
                INVOICE edit = (INVOICE)this.Owner;
                edit.Check_taxes = true;
                edit.InvText.Text = Invoice.ToString();
                edit.BindingInvoice(Invoice,2);
                this.Close();
            }
            else
            {
                Invoice = Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text);
                INVOICE edit = new INVOICE(Invoice, 2);
                edit.TopLevel = true;
                edit.Show();
                edit._grid_selection_changed_event = true;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Invoice;
            if (Owner.Name == "INVOICE")
            {
                Invoice = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                INVOICE edit = (INVOICE)this.Owner;
                edit.Check_taxes = false;
                edit.InvText.Text = Invoice.ToString();
                edit.BindingInvoice(Invoice, 1);
                this.Close();
            }
            else
            {
                Invoice = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                INVOICE edit = new INVOICE(Invoice, 1);
                edit.TopLevel = true;
                edit.Show(this.Owner);
                edit._grid_selection_changed_event = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int Invoice;
            if (Owner.Name == "INVOICE")
            {
                Invoice = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                INVOICE edit = (INVOICE)this.Owner;
                edit.Check_taxes = false;
                edit.InvText.Text = Invoice.ToString();
                edit.BindingInvoice(Invoice, 1);
                this.Close();
            }
            else
            {
                Invoice = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                INVOICE edit = new INVOICE(Invoice, 1);
                edit.TopLevel = true;
                edit.Show(this.Owner);
                edit._grid_selection_changed_event = true;
            }
        }

        private void openInExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                 
                string newpath = ConfigurationManager.AppSettings["PathINV"];

                DirectoryInfo diSource = new DirectoryInfo(newpath);
                string ExactFilename = string.Empty;

                //foreach (FileInfo file in diSource.GetFiles(@"*.*"))
                foreach (FileInfo file in diSource.GetFiles(string.Format("{0}.*", listView1.SelectedItems[0].SubItems[0].Text), SearchOption.TopDirectoryOnly))
                {
                    ExactFilename = file.FullName;
                }


                if (listView1.SelectedItems[0].SubItems[0].Text != string.Empty)
                {
                    Process.Start(ExactFilename);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {

                string newpath = ConfigurationManager.AppSettings["PathNT"];

                DirectoryInfo diSource = new DirectoryInfo(newpath);
                string ExactFilename = string.Empty;

                //foreach (FileInfo file in diSource.GetFiles(@"*.*"))
                foreach (FileInfo file in diSource.GetFiles(string.Format("{0}.*", listView2.SelectedItems[0].SubItems[0].Text), SearchOption.TopDirectoryOnly))
                {
                    ExactFilename = file.FullName;
                }


                if (listView2.SelectedItems[0].SubItems[0].Text != string.Empty)
                {
                    Process.Start(ExactFilename);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
