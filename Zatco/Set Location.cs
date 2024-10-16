using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Zatco
{
    public partial class Set_Location : Form
    {
        DataTable data = new DataTable();
        SqlDataAdapter ad = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        public Set_Location()
        {
            InitializeComponent();
            
            all_Un_Stock();
        }
        public Set_Location(int AddPermissionNumber,bool Reciving_bool)
        {
            InitializeComponent();
            
            parts_location(AddPermissionNumber,Reciving_bool);
        }
        private void parts_location(int add_number, bool a)
        {
            if (a)
            {
                SqlCommand location = new SqlCommand("_Reciving_Location", con);
                location.CommandType = CommandType.StoredProcedure;
                location.Parameters.AddWithValue("@RN", add_number);
                ad.SelectCommand = location;
                data.Clear();
                ad.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.Columns["Part Number"].ReadOnly = true;
                dataGridView1.Columns["Part Type"].ReadOnly = true;
                button1.Visible = false;
                button2.Location = button1.Location;
                dataGridView1.ReadOnly = true;

            }
            else
            {
                SqlCommand location = new SqlCommand("_parts_location", con);
                location.CommandType = CommandType.StoredProcedure;
                location.Parameters.AddWithValue("@inv", add_number);
                ad.SelectCommand = location;
                data.Clear();
                ad.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.Columns["Part Number"].ReadOnly = true;
                dataGridView1.Columns["Part Type"].ReadOnly = true;
            }


            SqlCommand com = new SqlCommand("add_Location", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@PN",SqlDbType.VarChar,50,"Part Number");
            com.Parameters.Add("@PT",SqlDbType.VarChar,50,"Part Type");
            com.Parameters.Add("@Loc",SqlDbType.VarChar,50,"Location");
            com.Parameters.Add("@Min",SqlDbType.Int,4, "Minimum Quantity");
            com.Parameters.Add("@Dis", SqlDbType.VarChar, 50, "Discription");

            ad.UpdateCommand = com;
        }

        private void all_Un_Stock()
        {
            SqlCommand location = new SqlCommand("all_parts_location", con);
            location.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            ad.SelectCommand = location;
            ad.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.Columns["Part Number"].ReadOnly = true;
            dataGridView1.Columns["Part Type"].ReadOnly = true;


            SqlCommand com = new SqlCommand("add_Location", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            com.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            com.Parameters.Add("@Loc", SqlDbType.VarChar, 50, "Location");
            com.Parameters.Add("@Min", SqlDbType.Int, 4, "Minimum Quantity");
            com.Parameters.Add("@Dis", SqlDbType.VarChar, 50, "Discription");

            ad.UpdateCommand = com;

        }
        private void Set_Location_Load(object sender, EventArgs e)
        {


        }
        private void button1_Click(object sender, EventArgs e)
        {
            //@PN varchar(50),@PT varchar(50),@Loc Varchar(50),@Min int
            try
            {
                dataGridView1.EndEdit();
                ad.Update(data);
                DialogResult message = MessageBox.Show("Location has been saved are you want to close this windows", "Location", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (message== DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        int datagridrow = 0;
        int mosal = 1;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Height;
            if (datagridrow == 0)
            {
                e.Graphics.DrawString("Location", new Font("Georgia", 25, FontStyle.Underline), Brushes.Black, new Point(280, 120));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 270), new Point(810, 270));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 275));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, 275));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 275));
                e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 275));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(760, 275));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 300), new Point(810, 300));
                Height = 310;
                mosal = 1;
            }
            else
            {
                e.Graphics.DrawLine(Pens.Black, new Point(45, 130), new Point(810, 130));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 135));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, 135));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 135));
                e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 135));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(760, 135));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 160), new Point(810, 160));
                Height = 180;
            }
            while (datagridrow < dataGridView1.Rows.Count - 1)
            {
                if (Height < e.PageSettings.PrintableArea.Height - 120)
                {
                    //if (dataGridView1.Rows[datagridrow].Cells[4].Value != null && dataGridView1.Rows[datagridrow].Cells[5].Value != null && dataGridView1.Rows[datagridrow].Cells[3].Value != null && dataGridView1.Rows[datagridrow].Cells[0].Value != null && dataGridView1.Rows[datagridrow].Cells[2].Value != null)
                    //{
                    //    e.Graphics.DrawString((mosal).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(15, Height));
                    //    e.Graphics.DrawString(dataGridView1.Rows[datagridrow].Cells["Part Number"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(75, Height));
                    //    e.Graphics.DrawString(dataGridView1.Rows[datagridrow].Cells["Discription"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(220, Height));
                    //    e.Graphics.DrawString(dataGridView1.Rows[datagridrow].Cells["Quantity"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(410, Height));
                    //    e.Graphics.DrawString(Math.Round(float.Parse(dataGridView1.Rows[datagridrow].Cells["Price"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(590, Height));
                    //    e.Graphics.DrawString(Math.Round(float.Parse(dataGridView1.Rows[datagridrow].Cells["Total"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(770, Height));
                    //    mosal += 1;
                    //}
                    //else continue;
                    Height += 25;
                    datagridrow += 1; 
                    e.HasMorePages = false;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(45, 990), new Point(810, 990));
                    e.HasMorePages = true;
                    Height = 200;
                    return;
                }
            }
            //if(dataGridView1.Rows.Count-1>4) 
            e.Graphics.DrawLine(Pens.Black, new Point(45, Height + 10), new Point(810, Height + 10));
        }

        private void Print_button_Click(object sender, EventArgs e)
        {
            datagridrow = 0;
            mosal = 1;
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            datagridrow = 0;
            mosal = 1;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}

