using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Configuration;


namespace Zatco
{
    public partial class Engines_data : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        DataTable ta_EN_da = new DataTable();
        public Engines_data()
        {
            InitializeComponent();
            company_Mathod();
            Boat();
            Eng();
            Eng_data();

        }
        public void combo_data(int com, int boat, int eng)
        {
            Com_Combobox.SelectedIndex = com;
            Boat_Combobox.SelectedIndex = boat;
            comboBox1.SelectedIndex = eng;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eng_data();
            DataGrid();
            ReportDataGrid();
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
        public void Eng_data()
        {
            SqlCommand com = new SqlCommand("engine_data_SN", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SN", comboBox1.SelectedValue.ToString());
            SqlDataAdapter ad = new SqlDataAdapter(com);
            ta_EN_da.Clear();
            ad.Fill(ta_EN_da);
            if (ta_EN_da.Rows.Count != 0 && comboBox1.SelectedIndex != 0)
            {
                int s = comboBox1.SelectedIndex - 1;
                Model_Tex.Text = "";
                Model_Tex.Text = ta_EN_da.Rows[0][1].ToString();
                Mark_Text.Text = "";
                Mark_Text.Text = ta_EN_da.Rows[0][2].ToString();
                Loc_Tex.Text = "";
                Loc_Tex.Text = ta_EN_da.Rows[0][4].ToString();
                dateTimePicker1.Value = DateTime.Parse(ta_EN_da.Rows[0][3].ToString());
            }
        }
        public void ReportDataGrid()
        {
            try
            {

                // data grid Reports data 
                SqlCommand com = new SqlCommand("Select_Reports", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@SN", comboBox1.SelectedValue);
                com.Parameters.AddWithValue("@MReport", false);
                DataTable table = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(com);
                ad.Fill(table);
                dataGridView2.DataSource = table;
                dataGridView2.Columns["Link"].Visible = false;
                dataGridView2.Columns["MReport"].Visible = false;
                DataGridViewColumn ID = dataGridView2.Columns["ID"];
                ID.Width = 30;
                DataGridViewColumn NB = dataGridView2.Columns["NB"];
                NB.Width = 250;
                dataGridView2.Columns["NB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                // datagrid m report connction
                SqlCommand Mcom = new SqlCommand("Select_Reports", con);
                Mcom.CommandType = CommandType.StoredProcedure;
                Mcom.Parameters.AddWithValue("@SN", comboBox1.SelectedValue);
                Mcom.Parameters.AddWithValue("@MReport", true);
                DataTable Mtable = new DataTable();
                SqlDataAdapter Mad = new SqlDataAdapter(Mcom);
                Mad.Fill(Mtable);
                datagrid_MReports.DataSource = Mtable;
                datagrid_MReports.Columns["Link"].Visible = false;
                datagrid_MReports.Columns["MReport"].Visible = false;
                DataGridViewColumn MiD = datagrid_MReports.Columns["ID"];
                MiD.Width = 30;
                DataGridViewColumn MNB = datagrid_MReports.Columns["NB"];
                MNB.Width = 250;
                datagrid_MReports.Columns["NB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                // datagrid offers connction

                SqlCommand offe = new SqlCommand("ENG_Offers", con);
                offe.CommandType = CommandType.StoredProcedure;
                offe.Parameters.AddWithValue("@SN", comboBox1.SelectedValue);
                SqlDataAdapter ade = new SqlDataAdapter(offe);
                DataTable tab = new DataTable();
                ade.Fill(tab);
                dataGridView3.DataSource = tab;

            }
            catch { };
        }

        private void DataGrid()
        {
            try
            {
                SqlCommand com = new SqlCommand("Engines_Invoice", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@SN", comboBox1.SelectedValue);
                DataTable r = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(com);
                ad.Fill(r);
                dataGridView1.DataSource = r;
                dataGridView1.Columns[2].Visible = false;
            }
            catch { };
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int Invoice = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            int move = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            INVOICE edit = new INVOICE(Invoice, move);
            edit.TopLevel = true;
            edit.Show(this.Owner);


        }

        private void Com_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boat();
            Eng();
            Eng_data();
        }

        private void Boat_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eng();
            Eng_data();
        }


        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int num = int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
            Offers play = new Offers(num);
            play.TopLevel = true;
            play.Show(this.Owner);

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                try
                {
                    string filePath =ConfigurationManager.AppSettings["Path"] +"\\"+dataGridView2.SelectedRows[0].Cells[0].Value + dataGridView2.SelectedRows[0].Cells[4].Value;
                    FileInfo f1 = new FileInfo(filePath);
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = filePath;
                    myProcess.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void addReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report ne = new Report(Com_Combobox.SelectedIndex, Boat_Combobox.SelectedIndex, comboBox1.SelectedIndex);
            ne.TopLevel = true;
            ne.Show(this);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                try
                {
                    string filePath = ConfigurationManager.AppSettings["Path"]+"\\" + dataGridView2.SelectedRows[0].Cells[0].Value + dataGridView2.SelectedRows[0].Cells[4].Value;
                    FileInfo f1 = new FileInfo(filePath);
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = filePath;
                    myProcess.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void editThisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                Report open = new Report(Com_Combobox.SelectedIndex, Boat_Combobox.SelectedIndex, comboBox1.SelectedIndex);
                open.TopLevel = true;
                open.ID_text.Visible = true;
                open.ID_text.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                open.Nb_text.Text = dataGridView2.SelectedRows[0].Cells["NB"].Value.ToString();
                open.Radio_yes.Checked = Convert.ToBoolean(dataGridView2.SelectedRows[0].Cells["MReport"].Value);
                open.Edit_button = true;
                open.file_path = ConfigurationManager.AppSettings["Path"] + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                open.AcceptButton = open.Edite;
                open.Show(this);
            }
        }

        private void deleteSelectedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                string file_path =ConfigurationManager.AppSettings["Path"] +"\\"+dataGridView2.SelectedRows[0].Cells[0].Value+ dataGridView2.SelectedRows[0].Cells[4].Value;
                DialogResult re = MessageBox.Show("هل تريد حزف هذا التقرير", "حزف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (File.Exists(file_path) & re == DialogResult.Yes)
                {
                    File.Delete(file_path);
                    SqlCommand Update_command = new SqlCommand("Delete_Report", con);
                    Update_command.CommandType = CommandType.StoredProcedure;
                    Update_command.Parameters.AddWithValue("@ID", dataGridView2.SelectedRows[0].Cells[0].Value);
                    con.Open();
                    Update_command.ExecuteNonQuery();
                    con.Close();
                    ReportDataGrid();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (datagrid_MReports.SelectedRows.Count != 0)
            {
                try
                {
                    string filePath = ConfigurationManager.AppSettings["Path"] +"\\"+datagrid_MReports.SelectedRows[0].Cells[0].Value+ datagrid_MReports.SelectedRows[0].Cells[4].Value;
                    FileInfo f1 = new FileInfo(filePath);
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = filePath;
                    myProcess.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Report ne = new Report(Com_Combobox.SelectedIndex, Boat_Combobox.SelectedIndex, comboBox1.SelectedIndex);
            ne.TopLevel = true;
            ne.Radio_yes.Checked = true;
            ne.Show(this);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (datagrid_MReports.SelectedRows.Count != 0)
            {
                string file_path = ConfigurationManager.AppSettings["Path"]+"\\"+ datagrid_MReports.SelectedRows[0].Cells[0].Value + datagrid_MReports.SelectedRows[0].Cells[4].Value;
                DialogResult re = MessageBox.Show("هل تريد حزف هذا التقرير", "حزف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (File.Exists(file_path) & re == DialogResult.Yes)
                {
                    File.Delete(file_path);
                    SqlCommand Update_command = new SqlCommand("Delete_Report", con);
                    Update_command.CommandType = CommandType.StoredProcedure;
                    Update_command.Parameters.AddWithValue("@ID", datagrid_MReports.SelectedRows[0].Cells[0].Value);
                    con.Open();
                    Update_command.ExecuteNonQuery();
                    con.Close();
                    ReportDataGrid();

                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (datagrid_MReports.SelectedRows.Count != 0)
            {
                Report open = new Report(Com_Combobox.SelectedIndex, Boat_Combobox.SelectedIndex, comboBox1.SelectedIndex);
                open.TopLevel = true;
                open.ID_text.Visible = true;
                open.ID_text.Text = datagrid_MReports.SelectedRows[0].Cells[0].Value.ToString();
                open.Nb_text.Text = datagrid_MReports.SelectedRows[0].Cells["NB"].Value.ToString();
                open.Radio_yes.Checked = Convert.ToBoolean(datagrid_MReports.SelectedRows[0].Cells["MReport"].Value);
                open.Edit_button = true;
                open.file_path = ConfigurationManager.AppSettings["Path"] + datagrid_MReports.SelectedRows[0].Cells[0].Value.ToString() + datagrid_MReports.SelectedRows[0].Cells[4].Value.ToString();
                open.AcceptButton = open.Edite;
                open.Show(this);
            }
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dataGridView2.ClearSelection();
                    this.dataGridView2.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void datagrid_MReports_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    datagrid_MReports.ClearSelection();
                    this.datagrid_MReports.Rows[rowSelected].Selected = true;
                }
            }

        }
    }
}