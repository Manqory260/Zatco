using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Zatco
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        private Dictionary<DateTime, List<string>> reminders = new Dictionary<DateTime, List<string>>();



        DataTable table = new DataTable();
        DataTable copy = new DataTable();
        public SqlConnection Con
        {
            get { return con;}
        }
        public DataTable Copy
        {
            set { if (value.Rows.Count != 0) copy = value; }
            get { return copy; }
        }

        bool states = true;
        public bool Stat
        {
            set { states = value; }
            get { return states; }
        }
        public void Shutdown ()
        { this.Close(); }
        public DataTable Table
        {
            set { table = value; }
            get { return table; }
        }

        public void Login()
        {
            table.Clear();
            إضافةمستخدمجديدToolStripMenuItem.Enabled = true;
            فاتورةToolStripMenuItem.Enabled = true;
            المخازنToolStripMenuItem.Enabled = true;
            العملاءToolStripMenuItem.Enabled = true;
            الموردينToolStripMenuItem.Enabled = true;
            المحركاتToolStripMenuItem.Enabled = true;
            عروضالسعرToolStripMenuItem.Enabled = true;
            groupsToolStripMenuItem.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;
            newInv.Enabled = true;
            receiving.Enabled = true;
            NewOffer.Enabled = true;
            stores.Enabled = true;
            Groups.Enabled = true;
            invoice.Enabled = true;
            addPermission.Enabled = true;

            Login play = new Login();
            play.TopLevel = true;
            play.ShowDialog(this);
            if (states) this.Close();
            if (table.Rows.Count != 0)
            {
                label1.Text = table.Rows[0][1].ToString();
                if (!Convert.ToBoolean(table.Rows[0][9]))
                {
                    إضافةمستخدمجديدToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][3]);
                    فاتورةToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    المخازنToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][5]);
                    العملاءToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][6]);
                    الموردينToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][7]);
                    المحركاتToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][8]);
                    عروضالسعرToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    groupsToolStripMenuItem.Enabled = Convert.ToBoolean(table.Rows[0][5]);
                    pictureBox2.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    pictureBox3.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    pictureBox4.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    pictureBox5.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    pictureBox6.Enabled = Convert.ToBoolean(table.Rows[0][5]);
                    pictureBox7.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    pictureBox8.Enabled = Convert.ToBoolean(table.Rows[0][5]);
                    newInv.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    receiving.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    NewOffer.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    stores.Enabled = Convert.ToBoolean(table.Rows[0][5]);
                    Groups.Enabled = Convert.ToBoolean(table.Rows[0][5]);
                    invoice.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                    addPermission.Enabled = invoice.Enabled = Convert.ToBoolean(table.Rows[0][4]);
                }
            }
        }
        public void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Group start = new Add_Group();
            start.TopLevel = true;
            start.Show();
            Sound_Click();
        }

        private void editInGroupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Groups start = new Groups();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void عرضسعرجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Offers start = new Offers();
            start.TopLevel = true;
            start.Show();
Sound_Click();

        }

        private void تعديلعرضسعرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            offers_show start = new offers_show();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void أضافةبياناتمحركToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Engines start = new Engines();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void تعديلفيبياناتالمحركToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edite_Eng start = new Edite_Eng();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void إضافةبياناتموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            suppliers start= new suppliers();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void عميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company start = new Company();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void تعديلبياناتالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company start = new Company();
            start.check.Checked = true;
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void إضافةمركبجديدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boats start = new Boats();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void تعديلفيبياناتالمركبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boats start = new Boats();
            start.check_box.Checked = true;
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void customersDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perview_company start = new Perview_company();
            start.TopLevel = true;
            start.Show();
Sound_Click();

        }

        ///
        private void start()
        {
            SqlCommand user = new SqlCommand("select_User", con);
            user.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(user);
            DataTable users = new DataTable();
            ad.Fill(users);
            if (users.Rows.Count == 0)
            {
                bool add = true;
                while (add)
                {
                    Add_User play = new Add_User();
                    play.TopLevel = true;
                    play.admin.Checked = true;
                    play.admin.Visible = true;
                    play.check_custom.Enabled = false;
                    play.check_mac.Enabled = false;
                    play.check_per.Enabled = false;
                    play.check_Stores.Enabled = false;
                    play.check_Supplier.Enabled = false;
                    play.check_user.Enabled = false;
                    play.StartPosition = FormStartPosition.CenterScreen;
                    play.ShowDialog(this);
                    add = play.check;
                }
            }
        }
       
                //
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlHelper helper = new SqlHelper(Properties.Settings.Default.ZatcoDBConnectionString);
                if (helper.Isconnection)
                {
                    start();
                    Login();
                }
                else
                {
                    Login();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Con_DB_Get db = new Con_DB_Get();
                db.TopLevel = true;
                db.ShowDialog(this);
            }
        }

        private void PictureBox2_DoubleClick(object sender, EventArgs e)
        {
            Sound_Click();
            INVOICE start = new INVOICE();
            start.TopLevel = true;
            start.Table = this.table;
            start.Show();   
        }

        private void PictureBox3_DoubleClick(object sender, EventArgs e)
            
        {
            Sound_Click();
            Edit_Invoice start = new Edit_Invoice();
            start.TopLevel = true;
            start.Show();
        }

        private void PictureBox4_DoubleClick(object sender, EventArgs e)
        {
            Sound_Click();
            Receiving_permission start = new Receiving_permission();
            start.TopLevel = true;
            start.Show();
        }

        private void PictureBox5_DoubleClick(object sender, EventArgs e)
        {
            Sound_Click(); 
            Add_permission start = new Add_permission();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void PictureBox6_DoubleClick(object sender, EventArgs e)
        {
            Sound_Click();
            search_Part start = new search_Part();
            start.TopLevel = true;
            start.Show();
Sound_Click();
        }

        private void pictureBox7_DoubleClick(object sender, EventArgs e)
        {
            Sound_Click();
            Offers start = new Offers();
            start.TopLevel = true;
            start.Show();

        }

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {
            Sound_Click();
            Groups start = new Groups();
            start.TopLevel = true;
            start.Show();
        }

        private void كارتالصنفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (System.Net.Mime.MediaTypeNames.Application.OpenForms.OfType<parts>().Count() == 1)
            //{
            //    Application.OpenForms.OfType<parts>().First().WindowState = FormWindowState.Maximized;
            //}
            //else
            //{
                
            //    parts play = new parts();
            //    play.TopLevel = true;
            //    play.Show();
            //}
        }

        private void بحثعنقطعةغيارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            search_Part play = new search_Part();
            play.TopLevel = true;
            play.Show();
      
        }

        private void النواقصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Need_added play = new Need_added();
            play.TopLevel = true;
            play.Show();
Sound_Click();
        }

        private void جردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory play = new Inventory();
            play.TopLevel = true;
            play.Show();
Sound_Click();
        }

        private void نواقصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set_Location play = new Set_Location();
            play.TopLevel = true;
            play.Show();
Sound_Click();
        }


        private void showAllInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Edit_Invoice play =  new Edit_Invoice();
            play.TopLevel = true;
            play.Show();
        }

        private void newPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Receiving_permission play = new Receiving_permission();
            play.TopLevel = true;
            play.Show();
        }

        private void newPermissionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Add_permission play = new Add_permission();
            play.TopLevel = true;
            play.Show();
        }

        private void تغييركلمةالسرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            chang_pass play = new chang_pass();
            play.TopLevel = true;
            play.Show();
        }

        private void إضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Add_User play = new Add_User();
            play.TopLevel = true;
            play.Show();
        }

        private void allPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Edite_Receiving play = new Edite_Receiving();
            play.TopLevel = true;
            play.Show();
        }

        private void allAddPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Edit_Add_permission play = new Edit_Add_permission();
            play.TopLevel = true;
            play.Show();
        }


       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void newInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            INVOICE play = new INVOICE();
            play.TopLevel = true;
            play.Show();
        }

        private void تعديلبياناتموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            suppliers play = new suppliers();
            play.TopLevel = true;
            play.Show();
            play.CheckBox1.Checked = true;
        }

        private void بحثفيالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            supplier_data play = new supplier_data();
            play.TopLevel = true;
            play.Show();
        }

        private void machineDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Engines_data play = new Engines_data();
            play.TopLevel = true;
            play.Show();

        }

        private void showAllPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound_Click();
            Storge_show play = new Storge_show();
            play.TopLevel = true;
            play.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void addReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report play = new Report();
            play.TopLevel = true;
            play.Show();
        }

        private void dataBaseSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Con_DB_Get play = new Con_DB_Get();
            play.TopLevel = true;
            play.ShowDialog(this);
        }

        private void reportLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Loction play = new Reports_Loction();
            play.TopLevel = true;
            play.ShowDialog(this);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Sound_Click();
            parts play = new parts();
            play.TopLevel = true;  
            play.ShowDialog();
        }

        private void pictureBox10_DoubleClick(object sender, EventArgs e)
        {
            Sound_Click();
            Edite_Receiving play = new Edite_Receiving();
            play.TopLevel = true;
            play.ShowDialog();
        }
        private void Open_sound ()
        {
            System.IO.Stream str = Properties.Resources.Open_sound;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
        private void Sound_Click ()
        {
            System.IO.Stream str = Properties.Resources.New_click;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.button3.ImageIndex = 3;
            }
            else { this.WindowState = FormWindowState.Normal;this.button3.ImageIndex = 2; }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
                this.Cursor = Cursors.SizeAll;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point cursorDiff = Point.Subtract(Cursor.Position, new Size(lastCursor));
                this.Location = Point.Add(lastForm, new Size(cursorDiff));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;   
        }

       
    }
}   