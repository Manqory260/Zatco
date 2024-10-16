using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Zatco
{
    public partial class Report : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public Report()
        {
            InitializeComponent();
            company_Mathod();
            Boat();
            Eng();
        }
        public Button Edite
        {
            set { edit_buttom = value; }
            get { return edit_buttom; }
        }
        public string file_path;
        public Report (int com,int boat,int eng)
        {
            InitializeComponent();
            company_Mathod();
            Boat();
            Eng();
            Add_Company_data(com, boat, eng);
        }
        string file_Name;
        public Label ID_text
        {
            set { id_text = value; }
            get { return id_text; }
        }

        public TextBox Nb_text
        {
            set { nb_text = value; }
            get { return nb_text; }
        }
        public TextBox Loc_text
        {
            set { loc_text = value; }
            get { return loc_text; }
        }
        public RadioButton Radio_yes
        {
            set { radio_yes = value; }
            get { return radio_yes; }
        }
        private void Add_Company_data (int com,int boat,int eng)
        {
            Com_Combobox.SelectedIndex = com;
            Boat_Combobox.SelectedIndex = boat;
            comboBox1.SelectedIndex = eng;
        }

        public bool Edit_button
        {
            set {
                if (value == true)
                {
                    edit_buttom.Visible = value;
                    button_save.Visible = false;
                }
                else { edit_buttom.Visible = false; button_save.Visible = true; }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (edit_buttom.Visible == true)
            {
                DialogResult DR = MessageBox.Show("سوف يتم مسح التقرير السابق", "تحزير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DR == DialogResult.Yes)
                {
                    OpenFileDialog choofdlog = new OpenFileDialog();
                    choofdlog.Filter = "Pdf Files|*.pdf|Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    choofdlog.FilterIndex = 1;

                    if (choofdlog.ShowDialog() == DialogResult.OK)
                    {
                        string sFileName = choofdlog.FileName;
                        loc_text.Text = "";
                        loc_text.Text = sFileName;
                        file_Name = "";
                        file_Name = System.IO.Path.GetFileName(choofdlog.FileName).ToString();
                    }

                }
            }
            else
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "Pdf Files|*.pdf|Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                choofdlog.FilterIndex = 1;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    string sFileName = choofdlog.FileName;
                    loc_text.Text = "";
                    loc_text.Text = sFileName;
                    file_Name = "";
                    file_Name = System.IO.Path.GetFileName(choofdlog.FileName).ToString();
                }
            }
        }
        public void Boat()
        {
            Com_Combobox.DisplayMember = "Name";
            Com_Combobox.ValueMember = "Com_ID";
            if (Com_Combobox.SelectedValue != null)
            {
                SqlCommand com = new SqlCommand("NumBoate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Com", Com_Combobox.SelectedValue);
                SqlDataAdapter dts = new SqlDataAdapter();
                DataTable ne = new DataTable();
                dts.SelectCommand = com;
                dts.Fill(ne);
                DataRow data = ne.NewRow();
                data[0] = DBNull.Value;
                data[2] = "Null";
                ne.Rows.InsertAt(data, 0);
                Boat_Combobox.DataSource = ne;
                Boat_Combobox.DisplayMember = "Name";
                Boat_Combobox.ValueMember = "Boat_ID";
            }
        }

        public void company_Mathod()
        {
            SqlCommand nee = new SqlCommand("[comp]", con);
            nee.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            SqlDataAdapter dts = new SqlDataAdapter();
            dts.SelectCommand = nee;
            dts.Fill(data);
            Com_Combobox.DataSource = data;
            Com_Combobox.DisplayMember = "Name";
            Com_Combobox.ValueMember = "Com_ID";
        }
        public void Eng()
        {
            Boat_Combobox.DisplayMember = "Name";
            Boat_Combobox.ValueMember = "Boat_ID";
            if (Boat_Combobox.SelectedValue != null)
            {
                SqlCommand nee = new SqlCommand("Engine_SN", con);
                nee.CommandType = CommandType.StoredProcedure;
                if (Boat_Combobox.SelectedValue != DBNull.Value)
                {
                    nee.Parameters.AddWithValue("@BI", Boat_Combobox.SelectedValue);
                }
                else
                {
                    nee.Parameters.AddWithValue("@BI", 0);
                }
                DataTable ne = new DataTable();
                SqlDataAdapter dts = new SqlDataAdapter();
                dts.SelectCommand = nee;
                dts.Fill(ne);
                DataRow data = ne.NewRow();
                data[0] = DBNull.Value;
                data[1] = "Null";
                ne.Rows.InsertAt(data, 0);
                comboBox1.DataSource = ne;
                comboBox1.DisplayMember = "display";
                comboBox1.ValueMember = "Engine_SN";
            }

        }

        private void Com_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boat();
            Eng();
        }

        private void Boat_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eng();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPath = loc_text.Text;
                FileInfo f1 = new FileInfo(oldPath);
                string EX= Path.GetExtension(oldPath);
                if (comboBox1.SelectedValue != DBNull.Value && nb_text.Text != "" && f1.Exists)
                {
                    SqlCommand insert_command = new SqlCommand("Add_Report", con);
                    insert_command.CommandType = CommandType.StoredProcedure;
                    insert_command.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                    insert_command.Parameters.AddWithValue("@En", comboBox1.SelectedValue.ToString());
                    insert_command.Parameters.AddWithValue("@NB", nb_text.Text);
                    insert_command.Parameters.AddWithValue("@Link", EX);
                    insert_command.Parameters.AddWithValue("@MReport", radio_yes.Checked);
                    con.Open();
                    string ID_Name = insert_command.ExecuteScalar().ToString();
                    con.Close();


                    string newpath =ConfigurationManager.AppSettings["Path"];
                    string newFileName = @"/" + ID_Name;
                    if (!Directory.Exists(newpath))
                    {
                        Directory.CreateDirectory(newpath);
                    }
                    f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
                    MessageBox.Show("تم الحفظ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loc_text.Text = "";
                    nb_text.Text = "";
                }
                else
                { MessageBox.Show("برجاء ملئ البيانات وأختيار سيريل المحرك", "نقص في المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

            }
            catch { MessageBox.Show("أدخل موقع التقرير","نقص في المعلومات",MessageBoxButtons.OK,MessageBoxIcon.Asterisk); }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (this.Owner.Name == "Engines_data")
            {
                Engines_data eng = (Engines_data)this.Owner;
                eng.combo_data(Com_Combobox.SelectedIndex, Boat_Combobox.SelectedIndex, comboBox1.SelectedIndex);
                eng.ReportDataGrid();
                eng.Show();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void edit_buttom_Click(object sender, EventArgs e)
        {
            if (Loc_text.Text=="")
            {
                SqlCommand Update_command = new SqlCommand("Update_Report", con);
                Update_command.CommandType = CommandType.StoredProcedure;
                Update_command.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                Update_command.Parameters.AddWithValue("@En", comboBox1.SelectedValue.ToString());
                Update_command.Parameters.AddWithValue("@NB", nb_text.Text);
                Update_command.Parameters.AddWithValue("@ID", id_text.Text);
                Update_command.Parameters.AddWithValue("@MReport", radio_yes.Checked);
                con.Open();
                Update_command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    if (File.Exists(file_path))
                    {
                        File.Delete(file_path);
                    }
                    string oldPath = loc_text.Text;
                    FileInfo f1 = new FileInfo(oldPath);
                    string EX = Path.GetExtension(oldPath);
                    if (comboBox1.SelectedValue != DBNull.Value && nb_text.Text != "" && f1.Exists)
                    {
                        SqlCommand insert_command = new SqlCommand("Update_Report_Link", con);
                        insert_command.CommandType = CommandType.StoredProcedure;
                        insert_command.Parameters.AddWithValue("@ID", id_text.Text);
                        insert_command.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                        insert_command.Parameters.AddWithValue("@En", comboBox1.SelectedValue.ToString());
                        insert_command.Parameters.AddWithValue("@NB", nb_text.Text);
                        insert_command.Parameters.AddWithValue("@Link", EX);
                        insert_command.Parameters.AddWithValue("@MReport", radio_yes.Checked);
                        con.Open();
                        insert_command.ExecuteNonQuery();
                        con.Close();


                        string newpath = ConfigurationManager.AppSettings["Path"];
                        string newFileName = @"/" + id_text.Text;
                        if (!Directory.Exists(newpath))
                        {
                            Directory.CreateDirectory(newpath);
                        }
                        f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
                        MessageBox.Show("تم الحفظ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loc_text.Text = "";
                        nb_text.Text = "";
                    }
                    else
                    { MessageBox.Show("برجاء ملئ البيانات وأختيار سيريل المحرك", "نقص في المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                }
                catch(Exception ex)
                { MessageBox.Show(ex.ToString()); }
        }
    }

        private void nb_text_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
        }

        private void Report_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["Path"]=="V1")
            {
                Reports_Loction play = new Reports_Loction();
                play.TopLevel = true;
                play.ShowDialog(this);
            }
        }
    }
}
