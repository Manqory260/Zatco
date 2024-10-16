using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace Zatco
{
    public partial class parts : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        SqlDataAdapter Part_ad = new SqlDataAdapter();
        DataTable Part_table = new DataTable();
        DataView  dv;
        public parts()
        {
            InitializeComponent();
           
        }
        public TextBox Part_text
        {
            set { textBox1 = value; }
            get { return textBox1; }
        }
        public void dataBind (Object sender ,EventArgs e)
        {
            Part_table.Clear();
            SqlCommand select_command = new SqlCommand("Select_Parts", con);
            select_command.CommandType = CommandType.StoredProcedure;
            Part_ad.SelectCommand = select_command;

            SqlCommand insert_command = new SqlCommand("parts_New", con);
            insert_command.CommandType = CommandType.StoredProcedure;
            insert_command.Parameters.Add("@P", SqlDbType.VarChar, 50, "PartNum");
            insert_command.Parameters.Add("@T", SqlDbType.VarChar, 50, "PartType");
            insert_command.Parameters.Add("@L", SqlDbType.VarChar, 50, "Location");
            insert_command.Parameters.Add("@q", SqlDbType.Int, 4, "Quantity");
            insert_command.Parameters.Add("@d", SqlDbType.VarChar, 50, "Discription");
            insert_command.Parameters.Add("@m", SqlDbType.Int, 4, "Minimum_Quantity");
            insert_command.Parameters.Add("@R", SqlDbType.Money, 5, "Price");
            Part_ad.InsertCommand = insert_command;

            SqlCommand update_command = new SqlCommand("Update_Parts", con);
            update_command.CommandType = CommandType.StoredProcedure;
            update_command.Parameters.Add("@PN", SqlDbType.VarChar, 50, "PartNum");
            update_command.Parameters.Add("@PT", SqlDbType.VarChar, 50, "PartType");
            update_command.Parameters.Add("@Loc", SqlDbType.VarChar, 50, "Location");
            update_command.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            update_command.Parameters.Add("@Des", SqlDbType.VarChar, 50, "Discription");
            update_command.Parameters.Add("@Min", SqlDbType.Int, 4, "Minimum_Quantity");
            update_command.Parameters.Add("@Price", SqlDbType.Money, 5, "Price");
            update_command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            Part_ad.UpdateCommand = update_command;

            SqlCommand delete_command = new SqlCommand("delete_Parts", con);
            delete_command.CommandType = CommandType.StoredProcedure;
            delete_command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            Part_ad.DeleteCommand = delete_command;

            Part_ad.Fill(Part_table);

            dataGridView1.DataSource = Part_table;
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "0.0";
            dataGridView1.Columns[7].Visible = false;

            textBox1_TextChanged(sender, e);

        }
        private void parts_Load(object sender, EventArgs e)
        {
            dataBind(sender,e);
        }


        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(Part_table);
            dv.RowFilter = String.Format("PartNum LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            try
            {
                Part_ad.Update(Part_table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Update Done", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBind(sender ,e);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Part_s_add>().Count() == 1)
            {
                Application.OpenForms.OfType<Part_s_add>().First().WindowState = FormWindowState.Normal;
            }
            else
            {
                Part_s_add play = new Part_s_add();
                play.TopLevel = true;
                play.Show(this);
                System.Media.SystemSounds.Exclamation.Play();
            }

        }
    }
}
