using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zatco
{
    public partial class Con_DB_Get : Form
    {
        public Con_DB_Get()
        {
            InitializeComponent();
        }

        private void Con_DB_Get_Load(object sender, EventArgs e)
        {
            Com_server.Items.Add(".");
            Com_server.Items.Add("(Local)");
            Com_server.Items.Add(@".\SQLEXPRESS");
            Com_server.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            Com_server.SelectedIndex = 3;
        }

        private void butt_Connect_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsBuilder = new SqlConnectionStringBuilder();
            scsBuilder.UserID = text_User.Text;
            scsBuilder.Password = text_Pass.Text;
            scsBuilder.DataSource = Com_server.Text;
            scsBuilder.InitialCatalog = text_DataBase.Text;
            scsBuilder.IntegratedSecurity = false;
            try
            {
                SqlHelper helper = new SqlHelper(scsBuilder.ConnectionString);
                if (helper.Isconnection)
                {
                    if (MessageBox.Show("Test Successfully are you want to save Conniction","SQl Conniction",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AppSetting setting = new AppSetting();
                        setting.SaveConnectionString("Zatco.Properties.Settings.ZatcoDBConnectionString", scsBuilder.ConnectionString);
                        MessageBox.Show("Save Done and Application will be Restart", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butt_save_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsBuilder = new SqlConnectionStringBuilder();
            scsBuilder.UserID = text_User.Text;
            scsBuilder.Password = text_Pass.Text;
            scsBuilder.DataSource = Com_server.Text;
            scsBuilder.InitialCatalog = text_DataBase.Text;
            scsBuilder.IntegratedSecurity = false;
            try
            {
                SqlHelper helper = new SqlHelper(scsBuilder.ConnectionString);
                if (helper.Isconnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("Zatco.Properties.Settings.ZatcoDBConnectionString", scsBuilder.ConnectionString);
                    MessageBox.Show("Save Done and Application will be Restart", "Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Application.Restart();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 pa = (Form1)this.Owner;
            pa.Close();
        }
    }
}
