using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Models : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        public Models()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand model_com = new SqlCommand("Model_add", con);
            model_com.CommandType = CommandType.StoredProcedure;
            model_com.Parameters.AddWithValue("@mo", textBox1.Text);
            model_com.Parameters.AddWithValue("@Des", textBox2.Text);
            con.Open();
            string res = Convert.ToString(model_com.ExecuteScalar());
            if (res == "not allow")
                MessageBox.Show("Model Is already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Model Add done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            con.Close();
        }
    }
}
