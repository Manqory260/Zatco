using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Insert_to_invoice: Form
    {
        public Insert_to_invoice(int Receiving_Number)
        {
            InitializeComponent();
            Receiving(Receiving_Number);
        }
        // Sql connection with Zatco DB
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        DataTable _table_parts = new DataTable();

        public void Receiving(int Receiving_Number)
        {
            _table_parts.Clear();
            SqlCommand Part_Get = new SqlCommand("Receving_part_get", con);
            Part_Get.CommandType = CommandType.StoredProcedure;
            Part_Get.Parameters.AddWithValue("@inv", Receiving_Number);
            SqlDataAdapter Part_get_Adapter = new SqlDataAdapter(Part_Get);
            Part_get_Adapter.Fill(_table_parts);
            dataGridView1.DataSource = _table_parts;
            if (_table_parts.Columns.Count < 10) _table_parts.Columns.Add("Total", typeof(float));
            _table_parts.Columns["Total"].Expression = "(Quantity)*(Price)";
            dataGridView1.DataSource = _table_parts;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["INV_Num"].Visible = false;
            dataGridView1.Columns["Move_Num"].Visible = false;
            dataGridView1.Columns["Receiving_Num"].Visible = false;
            dataGridView1.Columns["Total"].ReadOnly = true;
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "0.0";
            DataGridViewDisableButtonColumn button = new DataGridViewDisableButtonColumn();
            button.Name = "Insert";
            button.UseColumnTextForButtonValue = true;
            button.Text = "Insert";
            dataGridView1.Columns.Add(button);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewDisableButtonCell Check =
                (DataGridViewDisableButtonCell)dataGridView1.
                Rows[e.RowIndex].Cells["Insert"];

            if (e.ColumnIndex == dataGridView1.Columns["Insert"].Index && e.RowIndex >= 0 && Check.Enabled == true)
            {
                int ID = 
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                int Receiving = 
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Receiving_Num"].Value);

                INVOICE play = (INVOICE)this.Owner;
                play.Receiving(ID, Receiving);
                DataGridViewDisableButtonCell buttonCell =
                    (DataGridViewDisableButtonCell)dataGridView1.Rows[e.RowIndex].Cells["Insert"];
                buttonCell.Enabled = false;
            }
        }

        private void Insert_to_invoice_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["INV_Num"].Value != DBNull.Value)
                {
                    DataGridViewDisableButtonCell buttonCell = 
                        (DataGridViewDisableButtonCell)item.Cells["Insert"];
                    buttonCell.Enabled = false;
                    dataGridView1.Invalidate();
                }
            }

        }
    }
}
