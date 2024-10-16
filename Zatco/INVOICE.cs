using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Zatco
{
    public partial class INVOICE : Form
    {
        public bool _grid_selection_changed_event = true;
        // move form by double click
        private bool isDragging = false;
        private bool isHandlingEvent = false;
        private Point lastCursor;
        private Point lastForm;
        private bool _isProcessingRowLeave = false;
        private bool _isProcessingSelectionChange = false;
        public DataTable Table { get; set; }

        public INVOICE()
        {
            InitializeComponent();
            Storg();
            Company_Mathod();
            Boat();
            Eng();
            New_Num();
            BindingInvoice(int.Parse(_INV_NUM_Text.Text), Move());
        }
        public INVOICE(int _inv_num, int move)
        {
            
            _grid_selection_changed_event = false;
            InitializeComponent();
            if (move == 1)
            {
                _taxes_radio.Checked = true;
                _nunTaxes_radio.Checked = false;
            }
            else if (move == 2)
            {
                _taxes_radio.Checked = false;
                _nunTaxes_radio.Checked = true;
            }
            Company_Mathod();
            Boat();
            Eng();
            Storg();
            _INV_NUM_Text.Text = _inv_num.ToString();
            BindingInvoice(_inv_num, move);
        }
        //
        int datagridrow = 0;
        int mosal = 1;

        public TextBox InvText
        {
            set { _INV_NUM_Text = value; }
            get { return _INV_NUM_Text; }
        }

        public bool Check_taxes
        {
            set
            {
                if (value)
                {
                    _taxes_radio.Checked = false;
                    _nunTaxes_radio.Checked = true;
                }
                else if (value)
                {
                    _taxes_radio.Checked = true;
                    _nunTaxes_radio.Checked = false;
                }
            }
        }

        private static readonly SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        SqlDataAdapter _adapter = sqlDataAdapter;
        DataTable _table_parts = new DataTable();
        DataTable _table_invoice = new DataTable();
        DataTable _tabel_storge = new DataTable();
        DataTable copy_select = new DataTable();

        // Sql connection with Zatco DB
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        // change Part Type to combo
        DataTable ReverseRowsInDataTable(DataTable inputTable)
        {
            DataTable outputTable = inputTable.Clone();

            for (int i = inputTable.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(inputTable.Rows[i]);
            }

            return outputTable;
        }
        /// <receiving Permission mathod>
        public void Receiving(int ID, int Receiving_Number)
        {
            SqlCommand Main_Requset = new SqlCommand("Receiving_inv_get", con);
            Main_Requset.CommandType = CommandType.StoredProcedure;
            Main_Requset.Parameters.AddWithValue("@inv", Receiving_Number);
            DataTable Supplier_table = new DataTable();
            SqlDataAdapter Supplier_adbter = new SqlDataAdapter(Main_Requset);
            Supplier_adbter.Fill(Supplier_table);
            _date_picker.Value = DateTime.Parse(Supplier_table.Rows[0][1].ToString());
            _company_combo.SelectedValue = Supplier_table.Rows[0][2];
            _boat_combo.SelectedValue = Supplier_table.Rows[0][3];
            _engine_combo.SelectedValue = Supplier_table.Rows[0][4];



            SqlCommand Part_Get = new SqlCommand("[ID_part_get]", con);
            Part_Get.CommandType = CommandType.StoredProcedure;
            Part_Get.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter Part_get_Adapter = new SqlDataAdapter(Part_Get);
            Part_get_Adapter.Fill(_table_parts);


            for (int i = 0; i < _table_parts.Rows.Count; i++)
            {
                _table_parts.Rows[i]["INV_Num"] = _table_parts.Columns["INV_Num"].DefaultValue;
                _table_parts.Rows[i]["Move_Num"] = _table_parts.Columns["Move_Num"].DefaultValue;
            }
            Math();
        }

        /// </receiving Permission mathod>


        private void Add_Update_Invoice()
        {
            ///(@inv,@d,@CI,@BI,@E,@UI,@TOT,@DIS,@TAX)
            ///
            Table = Application.OpenForms.OfType<Form1>().FirstOrDefault().Table;
            SqlCommand com = new SqlCommand("Add_Update_Invoice_Num", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@inv", int.Parse(_INV_NUM_Text.Text));
            com.Parameters.AddWithValue("@d", _date_picker.Text);
            com.Parameters.AddWithValue("@CI", _company_combo.SelectedValue);
            com.Parameters.AddWithValue("@BI", _boat_combo.SelectedValue);
            com.Parameters.AddWithValue("@E", _engine_combo.SelectedValue);
            com.Parameters.AddWithValue("@UI", Table.Rows[0][0]);
            if (_taxes_radio.Checked) com.Parameters.AddWithValue("@ToT", float.Parse(_overall_text.Text));
            else com.Parameters.AddWithValue("@ToT", float.Parse(_total_text.Text));
            if (_nunTaxes_radio.Checked) { com.Parameters.AddWithValue("@DIS", DBNull.Value); }
            else com.Parameters.AddWithValue("@DIS", float.Parse(_discount_text.Text));
            if (_nunTaxes_radio.Checked) { com.Parameters.AddWithValue("@TAX", DBNull.Value); }
            else { com.Parameters.AddWithValue("@TAX", float.Parse(_taxes_text.Text)); }
            com.Parameters.AddWithValue("@MOV", Move());
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // math mathod
        private void Math()
        {
            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "")
            {
                _total_text.Text = "0.00";
            }
            float total = float.Parse(_total_text.Text);
            float discount = (total * 1 / 2) / 100;
            float taxes = ((total - discount ) * 13 / 100);
            _discount_text.Text = discount.ToString();
            _taxes_text.Text = taxes.ToString();
            _overall_text.Text = (total + taxes - discount).ToString();
        }

        //
        public void BindingInvoice(int _inv_num, int _move)
        {
            SqlCommand invo = new SqlCommand("get_invoice_date", con);
            invo.CommandType = CommandType.StoredProcedure;
            invo.Parameters.AddWithValue("@inv", _inv_num);
            invo.Parameters.AddWithValue("@mov", _move);
            SqlDataAdapter invoice = new SqlDataAdapter(invo);
            _table_invoice.Clear();
            invoice.Fill(_table_invoice);
            if (_table_invoice.Rows.Count > 0)
            {
                _date_picker.Value = Convert.ToDateTime(_table_invoice.Rows[0][1]);
                _company_combo.SelectedValue = _table_invoice.Rows[0][7];
                _boat_combo.SelectedValue = _table_invoice.Rows[0][9];
                _engine_combo.SelectedValue = _table_invoice.Rows[0][2];
                _overall_text.Text = _table_invoice.Rows[0][3].ToString();
                _discount_text.Text = _table_invoice.Rows[0][5].ToString();
                _taxes_text.Text = _table_invoice.Rows[0][4].ToString();
            }
            // select Command
            SqlCommand _select_parts_com = new SqlCommand("Invoice_Edite", con);
            _select_parts_com.CommandType = CommandType.StoredProcedure;
            _select_parts_com.Parameters.AddWithValue("@inv", _inv_num);
            _select_parts_com.Parameters.AddWithValue("@mov", _move);
            _adapter.SelectCommand = _select_parts_com;

            // insert command  (@PN varchar(50),@PT varchar(50),@QN int ,@Dis varchar (50),@Price money ,@inv int,@MOV int)
            //p.PartType,p.Quantity,p.Discription,p.Price,p.INV_Num,p.Move_Num
            SqlCommand _insert_parts_com = new SqlCommand("tax_Part", con);
            _insert_parts_com.CommandType = CommandType.StoredProcedure;
            _insert_parts_com.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _insert_parts_com.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _insert_parts_com.Parameters.Add("@QN", SqlDbType.Int, 4, "Quantity");
            _insert_parts_com.Parameters.Add("@Dis", SqlDbType.VarChar, 50, "Discription");
            _insert_parts_com.Parameters.Add("@Price", SqlDbType.Money, 5, "Price");
            _insert_parts_com.Parameters.Add("@inv", SqlDbType.Int, 4, "INV_Num");
            _insert_parts_com.Parameters.Add("@MOV", SqlDbType.Int, 4, "Move_Num");
            _adapter.InsertCommand = _insert_parts_com;

            //Update Command @ID int,@PN varchar(50),@PT varchar(50), @Quan int ,@Disc  varchar (50),@Pr money , @inv int ,@mov int
            SqlCommand _update_parts_com = new SqlCommand("update_part", con);
            _update_parts_com.CommandType = CommandType.StoredProcedure;
            _update_parts_com.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _update_parts_com.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _update_parts_com.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _update_parts_com.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            _update_parts_com.Parameters.Add("@Disc", SqlDbType.VarChar, 50, "Discription");
            _update_parts_com.Parameters.Add("@pr", SqlDbType.Money, 5, "Price");
            _update_parts_com.Parameters.Add("@inv", SqlDbType.Int, 4, "INV_Num");
            _update_parts_com.Parameters.Add("@mov", SqlDbType.Int, 4, "Move_Num");
            _adapter.UpdateCommand = _update_parts_com;


            _table_parts.Clear();
            _adapter.Fill(_table_parts);
            if (_table_parts.Columns.Count < 10) _table_parts.Columns.Add("Total", typeof(float));
            _table_parts.Columns["Total"].Expression = "(Quantity)*(Price)";
            _table_parts.Columns["INV_Num"].DefaultValue = _inv_num;
            _table_parts.Columns["Move_Num"].DefaultValue = _move;
            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "") { _total_text.Text = "0.00"; }


            _data_grid.DataSource = null;
            _data_grid.ClearSelection();
            _data_grid.DataSource = _table_parts;
            _data_grid.Columns["ID"].Visible = false;
            _data_grid.Columns["INV_Num"].Visible = false;
            _data_grid.Columns["Move_Num"].Visible = false;
            _data_grid.Columns["Receiving_Num"].Visible = false;
            _data_grid.Columns["Total"].ReadOnly = true;
            _data_grid.Columns["Price"].DefaultCellStyle.Format = "0.0";

            // Delete Command
            SqlCommand _delete_part_com = new SqlCommand("dete_Part", con);
            _delete_part_com.CommandType = CommandType.StoredProcedure;
            _delete_part_com.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _adapter.DeleteCommand = _delete_part_com;
            this.ActiveControl = null;
        }
        // all storge Part'S
        public void Storg()
        {
            // all Parts Table
            SqlCommand added = new SqlCommand("Show_all_storge", con);
            added.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter gon = new SqlDataAdapter();
            gon.SelectCommand = added;
            gon.Fill(_tabel_storge);

        }
        public void Company_Mathod()
        {
            SqlCommand nee = new SqlCommand("[comp]", con);
            nee.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            SqlDataAdapter dts = new SqlDataAdapter();
            dts.SelectCommand = nee;
            dts.Fill(data);
            _company_combo.DataSource = data;
            _company_combo.ValueMember = "Com_ID";
            _company_combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _company_combo.AutoCompleteSource = AutoCompleteSource.ListItems; _company_combo.DisplayMember = "Name";
        }

        public void Boat()
        {
            _company_combo.DisplayMember = "Name";
            _company_combo.ValueMember = "Com_ID";
            if (_company_combo.SelectedValue != null)
            {
                SqlCommand com = new SqlCommand("NumBoate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Com", _company_combo.SelectedValue);
                SqlDataAdapter dts = new SqlDataAdapter();
                DataTable ne = new DataTable();
                dts.SelectCommand = com;
                dts.Fill(ne);
                DataRow data = ne.NewRow();
                data[0] = DBNull.Value;
                data[2] = "Null";
                ne.Rows.InsertAt(data, 0);
                _boat_combo.DataSource = ne;
                _boat_combo.DisplayMember = "Name";
                _boat_combo.ValueMember = "Boat_ID";
            }
        }
        public void Eng()
        {
            _boat_combo.DisplayMember = "Name";
            _boat_combo.ValueMember = "Boat_ID";
            if (_boat_combo.SelectedValue != null)
            {
                SqlCommand nee = new SqlCommand("Engine_SN", con);
                nee.CommandType = CommandType.StoredProcedure;
                if (_boat_combo.SelectedValue != DBNull.Value)
                {
                    nee.Parameters.AddWithValue("@BI", _boat_combo.SelectedValue);
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
                _engine_combo.DataSource = ne;
                _engine_combo.DisplayMember = "display";
                _engine_combo.ValueMember = "Engine_SN";
            }

        }
        // new invoice number mathod
        private void New_Num()
        {
            switch (_taxes_radio.Checked)
            {
                case true:
                    SqlCommand follen = new SqlCommand("follen", con);
                    follen.CommandType = CommandType.StoredProcedure;
                    follen.Parameters.AddWithValue("@mov", 1);
                    SqlDataAdapter sda = new SqlDataAdapter(follen);
                    DataTable dat = new DataTable();
                    sda.Fill(dat);
                    if (dat.Rows[0][0] != DBNull.Value)
                    {
                        _INV_NUM_Text.Text = dat.Rows[0][0].ToString();
                    }
                    else
                    {
                        SqlCommand com = new SqlCommand("Inv_Num_", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@mov", 1);
                        con.Open();
                        _INV_NUM_Text.Text = com.ExecuteScalar().ToString();
                        con.Close();
                    }
                    break;
                case false:
                    follen = new SqlCommand("follen", con);
                    follen.CommandType = CommandType.StoredProcedure;
                    follen.Parameters.AddWithValue("@mov", 2);
                    sda = new SqlDataAdapter(follen);
                    dat = new DataTable();
                    sda.Fill(dat);
                    if (dat.Rows[0][0] != DBNull.Value)
                    {
                        _INV_NUM_Text.Text = dat.Rows[0][0].ToString();
                    }
                    else
                    {
                        SqlCommand com = new SqlCommand("Inv_Num_", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@mov", 2);
                        con.Open();
                        _INV_NUM_Text.Text = com.ExecuteScalar().ToString();
                        con.Close();
                    }
                    break;
            }
        }
        //Move Mathod
        public new int Move()
        {
            int status;
            if (_taxes_radio.Checked) { status = 1; }
            else
            { status = 2; }

            return status;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boat();
            Eng();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eng();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter&& _INV_NUM_Text.Text!="")
            {
                BindingInvoice(int.Parse(_INV_NUM_Text.Text),Move());
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control && _INV_NUM_Text.Text != "")
            {
                SaveToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.O && Control.ModifierKeys == Keys.Control )
            {
                OpenToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                NewToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
            {
                CutToolStripButton_Click(sender, e);
            }

        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            _data_grid.Focus();
            if (_INV_NUM_Text.Text != "")
            {
                if (_company_combo.SelectedValue == null || _company_combo.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Plesse enter castomer name", "New Invoice", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    try
                    {
                        Add_Update_Invoice();
                        _data_grid.EndEdit();
                        _adapter.Update(_table_parts);
                        BindingInvoice(int.Parse(_INV_NUM_Text.Text), Move());
                        MessageBox.Show("The Invoice has been saved successfully", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void Data_grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox prodCode = e.Control as TextBox;
            if (_data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Number"].Index)
            {
                SqlCommand part_Comp = new SqlCommand("comp_part", con);
                part_Comp.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = part_Comp;
                ad.Fill(data);
                string[] arr = new string[data.Rows.Count];
                con.Open();
                SqlDataReader read = part_Comp.ExecuteReader();
                int i = 0;
                while (read.Read())
                {
                    arr[i] = read["PartNum"].ToString();
                    i++;
                }
                con.Close();
                var source = new AutoCompleteStringCollection();
                source.AddRange(arr);
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteCustomSource = source;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }
            }
            else if (_data_grid.CurrentCell.ColumnIndex != _data_grid.Columns["Part Number"].Index && _data_grid.CurrentCell.ColumnIndex != _data_grid.Columns["Part Type"].Index)
            { prodCode.AutoCompleteCustomSource = null; }
        }

        private void Data_grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = _data_grid.Columns[e.ColumnIndex] as DataGridViewColumn;
            if (col.Name == "Quantity")
            {
                DataGridViewTextBoxCell cell = _data_grid[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell != null)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false)
                        {
                            MessageBox.Show("Please enter a correct value", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
            if (col.Name == "Price")
            {
                DataGridViewTextBoxCell cell = _data_grid[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell != null)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false && c != '.')
                        {
                            MessageBox.Show("Please enter a correct value", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }

        }

        private void Data_grid_SelectionChanged(object sender, EventArgs e)
        {
            // data change part type cell to combo box cell 

            if (_data_grid.CurrentCell != null && _grid_selection_changed_event && _tabel_storge.Rows.Count !=0 )
            {
                if (_data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Type"].Index 
                    || _data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Number"].Index)
                {
                    if (_data_grid.SelectedCells.Count > 0 && con.State != ConnectionState.Open)
                    {
                        if (_isProcessingSelectionChange) return; // Prevent recursive calls
                        _isProcessingSelectionChange = true;

                        try
                        {
                            DataView data = new DataView(_tabel_storge)
                            {
                                RowFilter = String.Format("[Part Number] LIKE '{0}'", _data_grid.CurrentRow.Cells["Part Number"].Value)
                            };
                            DataTable dataTable = new DataTable();
                            using (DataTable res = dataTable)
                            {
                            }

                            DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell
                            {
                                DataSource = data,
                                DisplayMember = _tabel_storge.Columns["Part Type"].ToString(),
                                ValueMember = _tabel_storge.Columns["Part Type"].ToString(),
                                FlatStyle = FlatStyle.Flat
                            };
                            _data_grid.CurrentRow.Cells["Part Type"] = cell;
                        }
                        finally
                        {
                            _isProcessingSelectionChange = false;
                        }
                        // F1 storge information
                        if (_data_grid.CurrentRow.Cells[1].Value != null)
                            {
                            string PN = _data_grid.CurrentRow.Cells[1].Value.ToString();
                                if (Application.OpenForms.OfType<Part_info>().Count() == 1)
                                {
                                Application.OpenForms.OfType<Part_info>().First().Serch_anther(PN);
                                Application.OpenForms.OfType<Part_info>().First().Location =
                                    new Point(this.Location.X + this.Width, this.Location.Y + 125);
                                 }
                            
                            }
                         }
                }
                if (_data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Type"].Index || _data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Number"].Index)
                {
                    if (_data_grid.CurrentRow.Cells["Part Number"].Value != _table_parts.Columns["Part Number"].DefaultValue )
                    {
                        if (_data_grid.CurrentRow.Cells["Part Type"].Value != _table_parts.Columns["Part Type"].DefaultValue && _company_combo.SelectedValue != null && _data_grid.CurrentRow.Cells["Price"].Value == _table_parts.Columns["Price"].DefaultValue)
                        {
                            SqlCommand quan = new SqlCommand("Last_price", con);
                            quan.CommandType = CommandType.StoredProcedure;
                            quan.Parameters.AddWithValue("@PN", _data_grid.CurrentRow.Cells["Part Number"].Value);
                            quan.Parameters.AddWithValue("@PT", _data_grid.CurrentRow.Cells["Part Type"].Value);
                            quan.Parameters.AddWithValue("@CID", _company_combo.SelectedValue);
                            DataTable data = new DataTable();
                            SqlDataAdapter adp = new SqlDataAdapter(quan);
                            adp.Fill(data);
                            if (data.Rows.Count != 0)
                            {
                                _data_grid.CurrentRow.Cells["Price"].Value = data.Rows[0]["Price"];
                            }
                        }

                        if (_data_grid.CurrentRow.Cells["Discription"].Value == _table_parts.Columns["Discription"].DefaultValue )
                        {
                            String _sqlWhere = "[Part Number] = '" + _data_grid.CurrentRow.Cells["Part Number"].Value + "'";
                            String _sqlOrder = "[Part Number]";
                            try
                            {
                                DataTable _newDataTable = _tabel_storge.Select(_sqlWhere, _sqlOrder).CopyToDataTable();
                                _data_grid.CurrentRow.Cells["Discription"].Value = _newDataTable.Rows[0]["Discription"].ToString();
                            }
                            catch
                            { MessageBox.Show("This Part Number is not in our storge", "We Don't have", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                        }
                    }
                }
            }
            Math();
        }
        private void Taxes_radio_CheckedChanged(object sender, EventArgs e)
        {
            New_Num();
            BindingInvoice(int.Parse(_INV_NUM_Text.Text), Move());
            if (_taxes_radio.Checked)
            {
                _discount_text.Visible = true;
                _discount_label.Visible = true;
                _taxes_text.Visible = true;
                _taxes_label.Visible = true;
                _overall_text.Visible = true;
                _overall_label.Visible = true;
            }
            else
            {
                _discount_text.Visible = false;
                _discount_label.Visible = false;
                _taxes_text.Visible = false;
                _taxes_label.Visible = false;
                _overall_text.Visible = false;
                _overall_label.Visible = false;

            }
        }
        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            New_Num();
            BindingInvoice(int.Parse(_INV_NUM_Text.Text), Move());
        }
       
        private void Dollar_check_CheckedChanged(object sender, EventArgs e)
        {
            //_dollar_text.Visible = true;
            //_dollar_text.Text = "0";
            //_table_parts.Columns.Add("$Priceddd",typeof(double));
            //_table_parts.Columns.Add("DollarText",typeof(float));
            //_table_parts.Columns["DollarText"].DefaultValue =float.Parse(_dollar_text.Text);
            //_table_parts.Columns["Price"].Expression = "(DollarText)*($Priceddd)";
        }

        private void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Split the clipboard text into lines (rows)
                string[] rows = clipboardText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Iterate through each row from the clipboard
                foreach (string rowText in rows)
                {
                    // Split the row text into cells based on the tab delimiter
                    string[] cells = rowText.Split('\t');

                    // Create a new row in the DataTable
                    DataRow newRow = _table_parts.NewRow();
                    newRow[1]= cells[0];
                    newRow[2]= cells[1];
                    newRow[3]= cells[2];
                    newRow[4]= cells[3];
                    newRow[5]= cells[4];
                    newRow[9]= cells[5];
                    _table_parts.Rows.Add(newRow);

                    // Populate the cells of the new row
                    //for (int i = 0; i < cells.Length; i++)
                    //{


                    //// Get the column type
                    //Type columnType = _table_parts.Columns[i].DataType;

                    //// Check if the value matches the expected type
                    //if (columnType == typeof(int))
                    //{
                    //    // Try to parse the value as an integer
                    //    if (int.TryParse(cells[i], out int intValue))
                    //    {
                    //        newRow[i] = intValue;
                    //    }
                    //    else
                    //    {
                    //        // If parsing fails, assign a default value or handle it as needed
                    //        newRow[i] = DBNull.Value; // or use a default integer value like 0
                    //    }
                    //}
                    //else if (columnType == typeof(string))
                    //{
                    //    newRow[i] = cells[i];
                    //}
                    //else
                    //{
                    //    // Handle other types if needed
                    //    newRow[i] = cells[i];
                    //}
                    //}

                    // Add the new row to the DataTable

                }

                // Bind the DataGridView to the DataTable if not already bound
                //_data_grid.DataSource = _table_parts;

                // Refresh the DataGridView to make sure the new data is shown
                //_data_grid.Refresh();

                // Inform the user
                MessageBox.Show("Rows pasted into the DataGridView!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                MessageBox.Show("Error pasting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            if (_data_grid.SelectedRows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                // Iterate through each selected row
                for (int t = 0;t < _data_grid.SelectedRows.Count; t++)
                {
                    // Iterate through the cells in the row
                    foreach (DataGridViewCell cell in _data_grid.Rows[t].Cells)
                    {
                        if (cell != _data_grid.Rows[t].Cells[0] && cell != _data_grid.Rows[t].Cells[6]
                            && cell != _data_grid.Rows[t].Cells[7] && cell != _data_grid.Rows[t].Cells[8])
                        {   
                            // Append each cell's value separated by a tab character
                            sb.Append(cell.Value?.ToString() ?? string.Empty).Append("\t");
                        }
                    }

                    // Remove the last tab character for the current row
                    if (sb.Length > 0)
                        sb.Length--;

                    // Add a newline after each row (to separate rows visually in the clipboard)
                    sb.AppendLine();
                }

                // Copy the formatted string containing all selected rows to the clipboard
                Clipboard.SetText(sb.ToString());

                // Inform the user
                MessageBox.Show("Selected rows copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // No rows are selected
                MessageBox.Show("Please select at least one row to copy.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CutToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you want to delete this invoice", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlCommand delete = new SqlCommand("Delete_all_Parts", con);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.AddWithValue("@inv", int.Parse(_INV_NUM_Text.Text));
                delete.Parameters.AddWithValue("@mov", Move());
                con.Open();
                delete.ExecuteNonQuery();
                con.Close();
                BindingInvoice(int.Parse(_INV_NUM_Text.Text), Move());
            }
        }

        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            datagridrow = 0;
            mosal = 1;
            INV_PrintPReview.Document = INV_Docment;
            INV_PrintPReview.ShowDialog();
        }

        private void PrintToolStripButton_Click(object sender, EventArgs e)
        {
            datagridrow = 0;
            mosal = 1;
            printDialog1.Document = INV_Docment;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                INV_Docment.Print();
            }

        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            Edit_Invoice frm = new Edit_Invoice
            {
                Owner = this
            };
            frm.ShowDialog();

        }

        private void INV_Docment_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Height;
            if (datagridrow == 0)
            {
                e.Graphics.DrawString("Parts Invoice", new Font("Georgia", 25, FontStyle.Underline), Brushes.Black, new Point(315, 120));
                e.Graphics.DrawString("Customer Name : " + _company_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 175));
                if (_boat_combo.SelectedValue != DBNull.Value) { e.Graphics.DrawString("Boat Name : " + _boat_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 200)); }
                if (_engine_combo.SelectedValue != DBNull.Value) { e.Graphics.DrawString("Eng SN : " + _engine_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 225)); }
                if (_taxes_radio.Checked == true) { e.Graphics.DrawString("Invoice : T" + _INV_NUM_Text.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(570, 175)); }
                else e.Graphics.DrawString("Invoice : N" + _INV_NUM_Text.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(570, 175));
                e.Graphics.DrawString("Date : " + _date_picker.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(570, 200));
                e.Graphics.DrawLine(Pens.Black, new Point(15, 270), new Point(785, 270));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular),
                    Brushes.Black, new Point(20, 275));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(190, 275));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 275));
                e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 275));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(730, 275));
                e.Graphics.DrawLine(Pens.Black, new Point(15, 300), new Point(785, 300));
                Height = 310;
                mosal = 1;
            }
            else
            {
                e.Graphics.DrawLine(Pens.Black, new Point(15, 130), new Point(785, 130));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20, 135));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(190, 135));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 135));
                e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 135));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(730, 135));
                e.Graphics.DrawLine(Pens.Black, new Point(15, 160), new Point(785, 160));
                Height = 180;
            }
            while (datagridrow < _data_grid.Rows.Count - 1)
            {
                if (Height < e.PageSettings.PrintableArea.Height - 120)
                {
                    if (_data_grid.Rows[datagridrow].Cells[4].Value != null && _data_grid.Rows[datagridrow].Cells[5].Value != null && _data_grid.Rows[datagridrow].Cells[3].Value != null && _data_grid.Rows[datagridrow].Cells[0].Value != null && _data_grid.Rows[datagridrow].Cells[2].Value != null)
                    {
                        e.Graphics.DrawString((mosal).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(15, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Part Number"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(45, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Discription"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(190, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Quantity"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(450, Height));
                        e.Graphics.DrawString(System.Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Price"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(550, Height));
                        e.Graphics.DrawString(System.Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Total"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(730, Height));
                        mosal += 1;
                    }
                    else continue;
                    Height += 25;
                    datagridrow += 1;
                    e.HasMorePages = false;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(15, 990), new Point(785, 990));
                    e.HasMorePages = true;
                    Height = 200;
                    return;
                }
            }
            //if(dataGridView1.Rows.Count-1>4) 
            e.Graphics.DrawLine(Pens.Black, new Point(15, Height + 10), new Point(785, Height + 10));
            e.Graphics.DrawString("Total : " + _total_text.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, Height + 25));
            if (_taxes_radio.Checked == true)
            {
                e.Graphics.DrawString("Discount : " + _discount_text.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, Height + 50));
                e.Graphics.DrawString("Taxes : " + _taxes_text.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, Height + 75));
                e.Graphics.DrawString("Over All : " + _overall_text.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, Height + 100));
            }

            //e.Graphics.DrawString("Refaat Elsaady", new Font("SketchFlow Print", 12, FontStyle.Italic), Brushes.Black, new Point(45, Height + 25));
            e.Graphics.DrawString("Recipient :", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, Height + 55));
            e.Graphics.DrawString("Sign :", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, Height + 85));

        }

        private void INV_NUM_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void INV_NUM_Text_Leave(object sender, EventArgs e)
        {
            if (_INV_NUM_Text.Text=="")
            {
                New_Num();
            }
            _table_parts.Columns["INV_Num"].DefaultValue = int.Parse(_INV_NUM_Text.Text);
            _table_parts.Columns["Move_Num"].DefaultValue = Move();
            for (int i = 0; i < _table_parts.Rows.Count; i++)
            {
                _table_parts.Rows[i]["INV_Num"] = _table_parts.Columns["INV_Num"].DefaultValue;
                _table_parts.Rows[i]["Move_Num"] = _table_parts.Columns["Move_Num"].DefaultValue;
            }

        }

        private void Data_grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void Data_grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                SaveToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.O && Control.ModifierKeys == Keys.Control)
            {
                OpenToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                NewToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
            {
                CutToolStripButton_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1 && _data_grid.CurrentRow.Cells[0].Value != null)
            {
                string PN = _data_grid.CurrentRow.Cells[1].Value.ToString();

                if (Application.OpenForms.OfType<Part_info>().Count() == 1 )
                {
                    Application.OpenForms.OfType<Part_info>().First().Serch_anther(PN);
                    Application.OpenForms.OfType<Part_info>().First().Location =
                        new Point(this.Location.X +this.Width, this.Location.Y + 125);
                }
                else if (_data_grid.SelectedRows.Count > 0) 
                {
                    Part_info info = new Part_info(PN)
                    {Owner = this};
                    info.Show();
                    info.Location = new Point(this.Location.X + this.Width, this.Location.Y + 125);
                }
            }
            
        }

        private void Company_pictureBox_Click(object sender, EventArgs e)
        {
            Company start = new Company
            {
                TopLevel = true
            };
            start.ShowDialog(this);
            Company_Mathod();
        }

        private void Boat_pictureBox_Click(object sender, EventArgs e)
        {
            Boats start = new Boats();
            start.TopLevel = true;
            start.ShowDialog(this);
            Boat();
        }

        private void Engine_pictureBox_Click(object sender, EventArgs e)
        {
            Engines start = new Engines();
            start.TopLevel = true;
            start.ShowDialog(this);
            Eng();
        }

        private void Copy_selected_row_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 parint = (Form1)Application.OpenForms.OfType<Form1>().First();
            copy_select = ((DataTable)_data_grid.DataSource).Clone();
            foreach (DataGridViewRow row in _data_grid.SelectedRows)
            {
                copy_select.ImportRow(((DataTable)_data_grid.DataSource).Rows[row.Index]);
            }
            copy_select.AcceptChanges();
            parint.Copy = ReverseRowsInDataTable(copy_select).Copy();

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_data_grid.SelectedRows.Count > 0 && _data_grid.SelectedRows[0].Index != _data_grid.NewRowIndex)
            {
                _data_grid.Rows.RemoveAt(_data_grid.SelectedRows[0].Index);
            }

        }

        private void SaveAsExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveToolStripButton_Click(sender, e);
                string newpath = "";
                string Old_file = "";

                if (_taxes_radio.Checked)
                {
                    newpath = ConfigurationManager.AppSettings["PathINV"];
                    Old_file = ConfigurationManager.AppSettings["PathfileT"];

                }
                else
                {
                    newpath = ConfigurationManager.AppSettings["PathNT"];
                    Old_file = ConfigurationManager.AppSettings["PathfileN"];
                }
                if (_data_grid.Rows.Count > 0)
                {
                    FileInfo f1 = new FileInfo(Old_file);

                    if (!Directory.Exists(newpath))
                    {
                        Directory.CreateDirectory(newpath);
                    }
                    try
                    {
                        f1.CopyTo(string.Format("{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension));
                        //// 
                        //DSOFile.OleDocumentProperties documentProperties = new DSOFile.OleDocumentProperties();
                        //DSOFile.SummaryProperties summaryProperties;

                        //try
                        //{
                        //    documentProperties.Open(string.Format(@"{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension));
                        //    summaryProperties = documentProperties.SummaryProperties;
                        //    summaryProperties.Comments = "Hamada";
                        //    documentProperties.Save();
                        //}
                        //finally
                        //{
                        //    summaryProperties = null;
                        //    documentProperties = null;
                        //}
                        ////
                    }

                    catch (Exception)
                    {
                        if (MessageBox.Show("are you want to Replace this file", "Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (File.Exists(string.Format("{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension)))
                            {
                                File.Delete(string.Format("{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension));
                            }
                            f1.CopyTo(string.Format("{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension));

                            //DSOFile.OleDocumentProperties documentProperties = new DSOFile.OleDocumentProperties();
                            //DSOFile.SummaryProperties summaryProperties;

                            //try
                            //{
                            //    documentProperties.Open(string.Format(@"{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension));
                            //    summaryProperties = documentProperties.SummaryProperties;
                            //    summaryProperties.Comments = "Hamada";
                            //    documentProperties.Save();
                            //}
                            //finally
                            //{
                            //    summaryProperties = null;
                            //    documentProperties = null;
                            //}

                        }
                    }

                    Excel.Application INV = new Excel.Application();
                    Excel.Workbook sheet = INV.Workbooks.Open(string.Format("{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension));
                    Excel.Worksheet x = INV.ActiveSheet as Excel.Worksheet;

                    int PartNum = 12;
                    if (_boat_combo.SelectedIndex != 0)
                    {
                        x.Cells[7, 3] = _boat_combo.Text;
                    }
                    else
                    {
                        x.Cells[7, 3] = _company_combo.Text;
                    }
                    x.Cells[8, 3] = _date_picker.Text;
                    if (_taxes_radio.Checked)
                    {
                        x.Cells[9, 3] = "P" + _date_picker.Value.ToString("yy") + "00" + _INV_NUM_Text.Text;

                    }
                    else
                    {
                        x.Cells[9, 3] = "N" + _date_picker.Value.ToString("yy") + "00" + _INV_NUM_Text.Text;
                    }
                    if (_engine_combo.SelectedIndex != 0)
                    {
                        x.Cells[10, 3] = _engine_combo.Text;
                    }
                    for (int R = 0; R < _data_grid.RowCount - 1; R++, PartNum++)
                    {
                        x.Cells[PartNum, 2] = _data_grid.Rows[R].Cells[1].Value;
                    }
                    PartNum = 12;
                    for (int R = 0; R < _data_grid.RowCount - 1; R++, PartNum++)
                    {
                        x.Cells[PartNum, 3] = _data_grid.Rows[R].Cells[3].Value;
                    }
                    PartNum = 12;
                    for (int R = 0; R < _data_grid.RowCount - 1; R++, PartNum++)
                    {
                        x.Cells[PartNum, 4] = _data_grid.Rows[R].Cells[4].Value;
                    }
                    PartNum = 12;
                    for (int R = 0; R < _data_grid.RowCount - 1; R++, PartNum++)
                    {
                        x.Cells[PartNum, 5] = _data_grid.Rows[R].Cells[5].Value;
                    }

                    sheet.Close(true, Type.Missing, Type.Missing);
                    INV.Quit();
                    string filePath = string.Format("{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension);
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = filePath;
                    myProcess.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OpenExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string newpath = "";
                if (_taxes_radio.Checked)
                {
                    newpath = ConfigurationManager.AppSettings["PathINV"];

                }
                else
                {
                    newpath = ConfigurationManager.AppSettings["PathNT"];
                   
                }
                DirectoryInfo diSource = new DirectoryInfo(newpath);
                string ExactFilename = string.Empty;

                foreach (FileInfo file in diSource.GetFiles(string.Format("{0}.*",_INV_NUM_Text.Text), SearchOption.TopDirectoryOnly))
                {
                    ExactFilename = file.FullName;
                }


                if (_INV_NUM_Text.Text != string.Empty)
                {
                    Process.Start(ExactFilename);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void OPenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<search_Part>().Count() == 1 && _data_grid.SelectedRows.Count > 0)
            {
                Application.OpenForms.OfType<search_Part>().First().search(_data_grid.SelectedRows[0].Cells["Part Number"]
                    .Value.ToString(), _data_grid.SelectedRows[0].Cells["Part Type"].
                    Value.ToString());

            }
            else if (_data_grid.SelectedRows.Count > 0)
            {
                search_Part form = new search_Part(_data_grid.SelectedRows[0].Cells["Part Number"].Value.ToString()
                    , _data_grid.SelectedRows[0].Cells["Part Type"].Value.ToString());
                form.TopLevel = true;
                form.Show(this);
            }
        }

        private void Data_grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    _data_grid.ClearSelection();
                    this._data_grid.Rows[rowSelected].Selected = true;
                }
            }
        }

        private DataTable PN_Search_Connection (string part_num)
        {
            DataTable data = new DataTable();   
            SqlCommand type = new SqlCommand("Storge_Search", con);
            type.CommandType = CommandType.StoredProcedure;
            type.Parameters.AddWithValue("@part_num", part_num);
            SqlDataAdapter type_ad = new SqlDataAdapter
            {SelectCommand = type};
            type_ad.Fill(data);
            con.Close();
            return data;

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Edite_Receiving play = new Edite_Receiving();
            play.TopLevel = true;
            play.Show(this);
        }

        private void ToolStripContainer1_ContentPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if it's a double-click on the form body
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
                this.Cursor = Cursors.SizeAll;
            }
        }

        private void ToolStripContainer1_ContentPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point cursorDiff = Point.Subtract(Cursor.Position, new Size(lastCursor));
                this.Location = Point.Add(lastForm, new Size(cursorDiff));
                if (Application.OpenForms.OfType<Part_info>().Count() == 1)
                {
                    Application.OpenForms.OfType<Part_info>().First().Location =
                        new Point(this.Location.X + this.Width, this.Location.Y + 125);
                }
            }
        }

        private void ToolStripContainer1_ContentPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            Cursor = Cursors.Default;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void INVOICE_Load(object sender, EventArgs e)
        {
            // احصل على حجم الشاشة
            var screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            var screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // احسب موقع النافذة
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);


        }

        private void Data_grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        //    try
        //    {
        //        if (sender is DataGridView dataGridView && e.RowIndex >= 0
        //            && e.ColumnIndex >= 0
        //            && e.ColumnIndex == _data_grid.Columns["Part Type"].Index)
        //        {
        //            DataView data = new DataView(_tabel_storge)
        //            {
        //                RowFilter = string.Format("[Part Number] LIKE '{0}'", _data_grid.CurrentRow.Cells["Part Number"].Value)
        //            };

        //            DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell
        //            {
        //                DataSource = data,
        //                DisplayMember = _tabel_storge.Columns["Part Type"].ToString(),
        //                ValueMember = _tabel_storge.Columns["Part Type"].ToString(),
        //                FlatStyle = FlatStyle.Flat
        //            };

        //            _data_grid.CurrentRow.Cells["Part Type"] = comboBoxCell;
        //        }
        //    }
        //    catch (Exception EX)
        //    {
        //        MessageBox.Show(EX.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
         }
    }

}   
