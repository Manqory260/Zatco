using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Storge_show : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        int i;
        public Storge_show()
        {
            InitializeComponent();
            
        }
        DataTable _tabel_parts;
        private void Storge_show_Load(object sender, EventArgs e)
        {
            SqlCommand added = new SqlCommand("Show_all_storge", con);
            added.CommandType = CommandType.StoredProcedure;
             _tabel_parts = new DataTable();
            SqlDataAdapter gon = new SqlDataAdapter();
            gon.SelectCommand = added;
            gon.Fill(_tabel_parts);
            dataGridView1.DataSource = _tabel_parts;
            dataGridView1.Columns["price"].DefaultCellStyle.Format = "0.0";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Inventory", new Font("Georgia", 25, FontStyle.Bold), Brushes.Black, new Point(350, 10));
            e.Graphics.DrawLine(Pens.Black, new Point(45,60), new Point(810, 60));
            e.Graphics.DrawString("Part Number", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(50, 65));
            e.Graphics.DrawString("Part Type", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(210, 65));
            e.Graphics.DrawString("Location", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(360, 65));
            e.Graphics.DrawString("Quantity", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(530, 65));
            e.Graphics.DrawString("Discription", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(680, 65));
            e.Graphics.DrawLine(Pens.Black, new Point(45, 90), new Point(810, 90));
            e.Graphics.DrawLine(Pens.Black, new Point(45, 1050), new Point(810, 1050));
            int hight = 100;
            while (i < dataGridView1.RowCount)
            {
                if (hight <= e.PageSettings.PrintableArea.Height -60)
                {
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(50, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(210, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(360, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(530, hight));
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(680, hight));
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
            if (printDialog1.ShowDialog()==DialogResult.OK)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(_tabel_parts);
            DV.RowFilter = String.Format("[Part Number] LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }
    }
}
