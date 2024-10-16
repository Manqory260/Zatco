using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zatco
{
    public partial class Reports_Loction : Form
    {
        public Reports_Loction()
        {
            InitializeComponent();
            Get_Location();
            
        }
        private void Button_loc_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog()==DialogResult.OK)
            {
                Text_Loc.Text = "";
                Text_Loc.Text = folder.SelectedPath;
            }

        }
        private void Get_Location ()
        {
            Text_Loc.Text = ConfigurationManager.AppSettings["Path"];
            Text_InvoiceStander.Text= ConfigurationManager.AppSettings["PathfileT"];
            Text_Invoice.Text= ConfigurationManager.AppSettings["PathINV"];
            Text_Non_xls.Text= ConfigurationManager.AppSettings["PathfileN"];
            Text_Non_folder.Text= ConfigurationManager.AppSettings["PathNT"];
            tb_reciving_ex.Text = ConfigurationManager.AppSettings["Reciving_xls"];
            tb_reciving_folder.Text = ConfigurationManager.AppSettings["Reciving_folder"];
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (Text_Loc.Text != "V1")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("Path");
                config.AppSettings.Settings.Add("Path", Text_Loc.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            if (Text_InvoiceStander.Text != "V2")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("PathfileT");
                config.AppSettings.Settings.Add("PathfileT", Text_InvoiceStander.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            if (Text_Invoice.Text != "V3")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("PathINV");
                config.AppSettings.Settings.Add("PathINV", Text_Invoice.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            if (Text_Non_xls.Text != "V4")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("PathfileN");
                config.AppSettings.Settings.Add("PathfileN", Text_Non_xls.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            if (Text_Non_folder.Text != "V5")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("PathNT");
                config.AppSettings.Settings.Add("PathNT", Text_Non_folder.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            if(tb_reciving_ex.Text != "")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("Reciving_xls");
                config.AppSettings.Settings.Add("Reciving_xls", tb_reciving_ex.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            if (tb_reciving_folder.Text != "")
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("Reciving_folder");
                config.AppSettings.Settings.Add("Reciving_folder", tb_reciving_folder.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }


            MessageBox.Show("Save Done", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx) | *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Text_InvoiceStander.Text = "";
                Text_InvoiceStander.Text = Dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fold = new FolderBrowserDialog();
            if (fold.ShowDialog()== DialogResult.OK)
            {
                Text_Invoice.Text = "";
                Text_Invoice.Text = fold.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx) | *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Text_Non_xls.Text = "";
                Text_Non_xls.Text = Dialog.FileName;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fold = new FolderBrowserDialog();
            if (fold.ShowDialog() == DialogResult.OK)
            {
                Text_Non_folder.Clear();
                Text_Non_folder.Text = fold.SelectedPath;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fold = new FolderBrowserDialog();
            if (fold.ShowDialog() == DialogResult.OK)
            {
                tb_reciving_folder.Clear();
                tb_reciving_folder.Text = fold.SelectedPath;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx) | *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                tb_reciving_ex.Text = "";
                tb_reciving_ex.Text = Dialog.FileName;
            }
        }
    }
}
