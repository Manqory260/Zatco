using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Need_added : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        int i;
        public Need_added()
        {
            InitializeComponent();
            
        }

        private void Need_added_Load(object sender, EventArgs e)
        {
            SqlCommand added = new SqlCommand("need_added", con);
            DataTable parts = new DataTable();
            SqlDataAdapter gon = new SqlDataAdapter();
            gon.SelectCommand = added;
            gon.Fill(parts);
            dataGridView1.DataSource = parts;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Incomplete", new Font("Georgia", 25, FontStyle.Bold), Brushes.Black, new Point(315, 10));
            e.Graphics.DrawLine(Pens.Black, new Point(45, 60), new Point(810, 60));
            e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 65));
            e.Graphics.DrawString("Part Type", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, 65));
            e.Graphics.DrawString("Location", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(310, 65));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 65));
            e.Graphics.DrawString("Minimum", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 65));
            e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(680, 65));
            e.Graphics.DrawLine(Pens.Black, new Point(45, 90), new Point(810, 90));
            e.Graphics.DrawLine(Pens.Black, new Point(45, 1050), new Point(810, 1050));
            int hight = 100;
            while (i < dataGridView1.RowCount)
            {
                if (hight <= e.PageSettings.PrintableArea.Height - 60)
                {
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(50, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(180, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(310, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(465, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[5].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(570, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(680, hight));
                    hight += 25;
                    i += 1;
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                    hight = 100;
                    return;
                }

            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 0;
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 0;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
