using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zatco
{
    public partial class Part_info : Form
    {

        public Part_info(string Part_number)
        {
            InitializeComponent();
            dataGridView1.DataSource = PN_Search_Connection(Part_number);
            this.Height = dataGridView1.RowCount  * dataGridView1.RowHeadersWidth;
        }
        private DataTable PN_Search_Connection(string PN)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
            DataTable data = new DataTable();
            SqlCommand type = new SqlCommand("Storge_Search", con);
            type.CommandType = CommandType.StoredProcedure;
            type.Parameters.AddWithValue("@part_num", PN);
            SqlDataAdapter type_ad = new SqlDataAdapter
            { SelectCommand = type };
            type_ad.Fill(data);
            con.Close();
            return data;
        }
        public void Serch_anther(string Serch)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = PN_Search_Connection(Serch);
            this.Height = dataGridView1.RowCount  * dataGridView1.RowHeadersWidth;
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }
        }
    }
}
