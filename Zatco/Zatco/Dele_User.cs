using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Zatco
{
    public partial class Dele_User : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ZatcoDB;Integrated Security=True");
        public Dele_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Text_User.Text != "" || Text_Pass.Text != "")
            {
                SqlCommand com = new SqlCommand("user_in", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@N", Text_User.Text);
                con.Open();
                var pass = com.ExecuteScalar().ToString();
                con.Close();
                if (pass == "not fond")
                {
                    MessageBox.Show("أسم المستخدم غير موجود");
                }
                else if (pass == Text_Pass.Text)
                {
                    SqlCommand del = new SqlCommand("dele", con);
                    del.CommandType = CommandType.StoredProcedure;
                    del.Parameters.AddWithValue("@N", Text_User.Text);
                    con.Open();
                    del.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم حذف المستخدم");
                }
            }
        }
    }
}
