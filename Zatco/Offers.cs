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

namespace Zatco
{
    public partial class Offers : Form
    {
        public Offers()
        {
            InitializeComponent();
           
            company_Mathod();
            Boat();
            storg();
            Eng();
            New_Qun();
            bindingInvoice(int.Parse(_INV_NUM_Text.Text));
        }
        public Offers(int OfferNumber)
        {
            InitializeComponent();
          
            company_Mathod();
            Boat();
            storg();
            Eng();
            bindingInvoice(OfferNumber);
            _INV_NUM_Text.Text = OfferNumber.ToString();
        }

        public bool _grid_selection_changed_event = true;
        int datagridrow = 0;
        int mosal = 1;

        public TextBox _InvText
        {
            set { _INV_NUM_Text = value; }
            get { return _INV_NUM_Text; }
        }

        private void New_Qun()
        {
            SqlCommand Qun_num = new SqlCommand("Qun_Num", con);
            Qun_num.CommandType = CommandType.StoredProcedure;
            con.Open();
            _INV_NUM_Text.Text = Qun_num.ExecuteScalar().ToString();
            con.Close();
        }


        SqlDataAdapter _adapter = new SqlDataAdapter();
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
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //


        private void Add_Update_Invoice()
        {
            Form1 parint = (Form1)this.Owner;
            ///(@inv,@d,@CI,@BI,@E,@UI,@TOT,@DIS,@TAX)
            SqlCommand com = new SqlCommand("Added_upade_Quan", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@QN", int.Parse(_INV_NUM_Text.Text));
            com.Parameters.AddWithValue("@date", _date_picker.Text);
            com.Parameters.AddWithValue("@CI", _company_combo.SelectedValue);
            com.Parameters.AddWithValue("@BI", _boat_combo.SelectedValue);
            com.Parameters.AddWithValue("@EN", _engine_combo.SelectedValue);
            com.Parameters.AddWithValue("@UI", parint.Table.Rows[0][0]);
            com.Parameters.AddWithValue("@total", float.Parse(_overall_text.Text));
            com.Parameters.AddWithValue("@dis", float.Parse(_discount_text.Text));
            com.Parameters.AddWithValue("@tax", float.Parse(_taxes_text.Text)); 
            //com.Parameters.AddWithValue("@MOV", move());
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // math mathod
        private void _Math()
        {
            //_total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            //if (_total_text.Text == "")
            //{
            //    _total_text.Text = "0.0000";
            //}
            //float total = float.Parse(_total_text.Text);
            //float taxes = (total * 13 / 100);
            //float discount = (total * 1 / 2) / 100;
            //_discount_text.Text = discount.ToString();
            //_taxes_text.Text = taxes.ToString();
            //_overall_text.Text = (total + taxes - discount).ToString();

            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "")
            {
                _total_text.Text = "0.00";
            }
            float total = float.Parse(_total_text.Text);
            float discount = (total * 1 / 2) / 100;
            float taxes = ((total - discount) * 13 / 100);
            _discount_text.Text = discount.ToString();
            _taxes_text.Text = taxes.ToString();
            _overall_text.Text = (total + taxes - discount).ToString();

        }

        //
        public void bindingInvoice(int _inv_num)
        {
            SqlCommand invo = new SqlCommand("Qun_main", con);
            invo.CommandType = CommandType.StoredProcedure;
            invo.Parameters.AddWithValue("@Qun", _inv_num);
            SqlDataAdapter invoice = new SqlDataAdapter(invo);
            _table_invoice.Clear();
            invoice.Fill(_table_invoice);
            if (_table_invoice.Rows.Count > 0)
            {
                _date_picker.Value = Convert.ToDateTime(_table_invoice.Rows[0]["date"]);
                _company_combo.SelectedValue = _table_invoice.Rows[0]["Com_ID"];
                _boat_combo.SelectedValue = _table_invoice.Rows[0]["Boat_ID"];
                _engine_combo.SelectedValue = _table_invoice.Rows[0]["Eng_ID"];
                _overall_text.Text = _table_invoice.Rows[0]["Total"].ToString();
                _discount_text.Text = _table_invoice.Rows[0]["Discount"].ToString();
                _taxes_text.Text = _table_invoice.Rows[0]["taxes"].ToString();
            }
            // select Command
            SqlCommand _select_parts_com = new SqlCommand("Qun_Part_select", con);
            _select_parts_com.CommandType = CommandType.StoredProcedure;
            _select_parts_com.Parameters.AddWithValue("@Qun", _inv_num);
            _adapter.SelectCommand = _select_parts_com;

            // insert command  (@PN varchar(50),@PT varchar(50),@QN int ,@Dis varchar (50),@Price money ,@inv int,@MOV int)
            //p.PartType,p.Quantity,p.Discription,p.Price,p.INV_Num,p.Move_Num
            SqlCommand _insert_parts_com = new SqlCommand("Parts_qun", con);
            _insert_parts_com.CommandType = CommandType.StoredProcedure;
            _insert_parts_com.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _insert_parts_com.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _insert_parts_com.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            _insert_parts_com.Parameters.Add("@Disc", SqlDbType.VarChar, 50, "Discription");
            _insert_parts_com.Parameters.Add("@Pr", SqlDbType.Money, 5, "Price");
            _insert_parts_com.Parameters.Add("@inv", SqlDbType.Int, 4, "INV_Num");
            _adapter.InsertCommand = _insert_parts_com;

            //Update Command @ID int,@PN varchar(50),@PT varchar(50), @Quan int ,@Disc  varchar (50),@Pr money , @inv int ,@mov int
            SqlCommand _update_parts_com = new SqlCommand("update_Qun_part", con);
            _update_parts_com.CommandType = CommandType.StoredProcedure;
            _update_parts_com.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _update_parts_com.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _update_parts_com.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _update_parts_com.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            _update_parts_com.Parameters.Add("@Disc", SqlDbType.VarChar, 50, "Discription");
            _update_parts_com.Parameters.Add("@pr", SqlDbType.Money, 5, "Price");
            _update_parts_com.Parameters.Add("@inv", SqlDbType.Int, 4, "INV_Num");
            _adapter.UpdateCommand = _update_parts_com;


            _table_parts.Clear();
            _adapter.Fill(_table_parts);
            if (_table_parts.Columns.Count < 8) _table_parts.Columns.Add("Total", typeof(float));
            _table_parts.Columns["Total"].Expression = "(Quantity)*(Price)";
            _table_parts.Columns["INV_Num"].DefaultValue = _inv_num;
            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "") { _total_text.Text = "0.0"; }


            _data_grid.DataSource = null;
            _data_grid.ClearSelection();
            _data_grid.DataSource = _table_parts;
            _data_grid.Columns["ID"].Visible = false;
            _data_grid.Columns["INV_Num"].Visible = false;
            _data_grid.Columns["Total"].ReadOnly = true;
            _data_grid.Columns["Price"].DefaultCellStyle.Format = "0.0";

            // Delete Command
            SqlCommand _delete_part_com = new SqlCommand("dete_Qun_Part", con);
            _delete_part_com.CommandType = CommandType.StoredProcedure;
            _delete_part_com.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _adapter.DeleteCommand = _delete_part_com;
            this.ActiveControl = null;
        }
        // all storge Part'S
        public void storg()
        {
            // all Parts Table
            SqlCommand added = new SqlCommand("Show_all_storge", con);
            added.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter gon = new SqlDataAdapter();
            gon.SelectCommand = added;
            gon.Fill(_tabel_storge);

        }

        // company mathond

        public void company_Mathod()
        {
            SqlCommand nee = new SqlCommand("[comp]", con);
            nee.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            SqlDataAdapter dts = new SqlDataAdapter();
            dts.SelectCommand = nee;
            dts.Fill(data);
            _company_combo.DataSource = data;
            _company_combo.DisplayMember = "Name";
            _company_combo.ValueMember = "Com_ID";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // boate mathond
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
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Eng mathod
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

        private void _data_grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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

        private void _data_grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            else if (_data_grid.CurrentCell.ColumnIndex != _data_grid.Columns["Part Number"].Index && _data_grid.CurrentCell.ColumnIndex != _data_grid.Columns["Part Type"].Index) { prodCode.AutoCompleteCustomSource = null; }

        }

        private void _data_grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_data_grid.CurrentCell != null && _grid_selection_changed_event)
            {
                if (_data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Type"].Index || _data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Number"].Index)
                {
                    if (_data_grid.SelectedCells.Count > 0 && con.State != ConnectionState.Open)
                    {
                        DataView data = new DataView(_tabel_storge);
                        data.RowFilter = String.Format("[Part Number] LIKE '{0}'", _data_grid.CurrentRow.Cells["Part Number"].Value);
                        DataTable res = new DataTable();
                        DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                        cell.DataSource = data;
                        cell.DisplayMember = _tabel_storge.Columns["Part Type"].ToString();
                        cell.ValueMember = _tabel_storge.Columns["Part Type"].ToString();
                        cell.FlatStyle = FlatStyle.Flat;
                        _data_grid.CurrentRow.Cells["Part Type"] = cell;

                    }
                }
                if (_data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Type"].Index || _data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Number"].Index)
                {
                    if (_data_grid.CurrentRow.Cells["Part Number"].Value != _table_parts.Columns["Part Number"].DefaultValue)
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

                        if (_data_grid.CurrentRow.Cells["Discription"].Value == _table_parts.Columns["Discription"].DefaultValue)
                        {
                            String _sqlWhere = "[Part Number] = '" + _data_grid.CurrentRow.Cells["Part Number"].Value + "'";
                            String _sqlOrder = "[Part Number]";
                            DataTable _newDataTable = _tabel_storge.Select(_sqlWhere, _sqlOrder).CopyToDataTable();
                            _data_grid.CurrentRow.Cells["Discription"].Value = _newDataTable.Rows[0]["Discription"].ToString();
                        }
                    }
                }
            }
            _Math();

        }

        private void _INV_NUM_Text_Leave(object sender, EventArgs e)
        {
            if (_INV_NUM_Text.Text == "")
            {
                New_Qun();
            }
            _table_parts.Columns["INV_Num"].DefaultValue = int.Parse(_INV_NUM_Text.Text);
            for (int i = 0; i < _table_parts.Rows.Count; i++)
            {
                _table_parts.Rows[i]["INV_Num"] = _table_parts.Columns["INV_Num"].DefaultValue;
            }

        }

        private void _INV_NUM_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _INV_NUM_Text.Text != "")
            {
                bindingInvoice(int.Parse(_INV_NUM_Text.Text));
            }
            else if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control && _INV_NUM_Text.Text != "")
            {
                saveToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.O && Control.ModifierKeys == Keys.Control)
            {
                openToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                newToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
            {
                cutToolStripButton_Click(sender, e);
            }


        }

        private void _INV_NUM_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void _company_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boat();
        }

        private void _boat_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eng();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
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
                    //try
                    //{
                        Add_Update_Invoice();
                        _data_grid.EndEdit();
                        _adapter.Update(_table_parts);
                        bindingInvoice(int.Parse(_INV_NUM_Text.Text));
                        MessageBox.Show("The Offer has been saved successfully", "Offer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //catch (Exception) { }
                }
            }

        }

        private void _data_grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void INV_Docment_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Height;
            if (datagridrow == 0)
            {
                e.Graphics.DrawString("Offer", new Font("Georgia", 25, FontStyle.Underline), Brushes.Black, new Point(315, 120));
                e.Graphics.DrawString("Customer Name : " + _company_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 175));
                if (_boat_combo.SelectedValue != DBNull.Value) { e.Graphics.DrawString("Boat Name : " + _boat_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 200)); }
                if (_engine_combo.SelectedValue != DBNull.Value) { e.Graphics.DrawString("Eng SN : " + _engine_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 225)); }
                e.Graphics.DrawString("Offer Num : Q " + _INV_NUM_Text.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(570, 175));
                e.Graphics.DrawString("Date : " + _date_picker.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(570, 200));
                e.Graphics.DrawLine(Pens.Black, new Point(15, 270), new Point(785, 270));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20, 275));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(190, 275));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(370, 275));
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
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(370, 135));
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
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Quantity"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(370, Height));
                        e.Graphics.DrawString(Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Price"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(550, Height));
                        e.Graphics.DrawString(Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Total"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(730, Height));
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
            e.Graphics.DrawString("Discount : " + _discount_text.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, Height + 50));
            e.Graphics.DrawString("Taxes : " + _taxes_text.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, Height + 75));
            e.Graphics.DrawString("Over All : " + _overall_text.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, Height + 100));

            //e.Graphics.DrawString("Refaat Elsaady", new Font("SketchFlow Print", 12, FontStyle.Italic), Brushes.Black, new Point(45, Height + 25));
            e.Graphics.DrawString("Recipient :", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, Height + 55));
            e.Graphics.DrawString("Sign :", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, Height + 85));

        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            datagridrow = 0;
            mosal = 1;
            INV_PrintPReview.Document = INV_Docment;
            INV_PrintPReview.ShowDialog();

        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            datagridrow = 0;
            mosal = 1;
            printDialog1.Document = INV_Docment;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                INV_Docment.Print();
            }

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            New_Qun();
            bindingInvoice(int.Parse(_INV_NUM_Text.Text));
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            offers_show start = new offers_show();
            start.ShowDialog(this);
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes==MessageBox.Show("Are You Want To Delete This Offer","Offer",MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
            {
                SqlCommand delete = new SqlCommand("Delete_all_Offer", con);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.AddWithValue("@Offer", int.Parse(_INV_NUM_Text.Text));
                con.Open();
                delete.ExecuteNonQuery();
                con.Close();
                bindingInvoice(int.Parse(_INV_NUM_Text.Text));
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 parint = (Form1)this.Owner;
            if (parint.Copy != null) parint.Copy.Clear();
            parint.Copy = this._table_parts.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 parint = (Form1)this.Owner;
            if (parint.Copy.Rows.Count > 0)
            {
                foreach (DataRow row in parint.Copy.Rows)
                {
                    _table_parts.ImportRow(row);
                }
            }

        }

        private void _data_grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                saveToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.O && Control.ModifierKeys == Keys.Control)
            {
                openToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                newToolStripButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
            {
                cutToolStripButton_Click(sender, e);
            }

        }

        private void copy_selected_row_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 parint = (Form1)this.Owner;
            copy_select = ((DataTable)_data_grid.DataSource).Clone();
            foreach (DataGridViewRow row in _data_grid.SelectedRows)
            {
                copy_select.ImportRow(((DataTable)_data_grid.DataSource).Rows[row.Index]);
            }
            copy_select.AcceptChanges();
            parint.Copy = ReverseRowsInDataTable(copy_select).Copy();

        }
    }
}
