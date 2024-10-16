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
using System.Text;

namespace Zatco
{
    public partial class Receiving_permission : Form
    {
        public DataTable Table {  get; set; }
       

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        public Receiving_permission()
        {
            InitializeComponent();
            storg();
            company_Mathod();
            Boat();
            Eng();
            new_Num();
            bindingInvoice(int.Parse(_INV_NUM_Text.Text));
        }
        public Receiving_permission(int ReceivingNumber)
        {
            _grid_selection_changed_event = false;
            InitializeComponent();

            storg();
            company_Mathod();
            Boat();
            Eng();
            _INV_NUM_Text.Text = ReceivingNumber.ToString();
            bindingInvoice(ReceivingNumber);

        }

        int datagridrow = 0;
        int mosal = 1;
        public bool _grid_selection_changed_event = true;
        SqlDataAdapter _adapter = new SqlDataAdapter();
        DataTable _table_parts = new DataTable();
        DataTable _table_invoice = new DataTable();
        DataTable _tabel_storge = new DataTable();
        DataTable copy_select= new DataTable();
        // Sql connection with Zatco DB
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        public TextBox _InvText
        {
            set { _INV_NUM_Text = value; }
            get { return _INV_NUM_Text; }
        }

        // change Part Type to combo
        //private void _change_cell_combo(int Row_index)
        //{
        //    if (_data_grid.CurrentCell != null)
        //    {
        //        SqlCommand type = new SqlCommand("get_Part_Storte", con);
        //        type.CommandType = CommandType.StoredProcedure;
        //        type.Parameters.AddWithValue("@PN", _data_grid.CurrentRow.Cells["Part Number"].Value);
        //        SqlDataAdapter ad = new SqlDataAdapter(type);
        //        DataTable data = new DataTable();
        //        ad.Fill(data);
        //        DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
        //        cell.DataSource = data;
        //        cell.DisplayMember = data.Columns["PartType"].ToString();
        //        cell.ValueMember = data.Columns["PartType"].ToString();
        //        cell.FlatStyle = FlatStyle.Flat;
        //        _data_grid.CurrentRow.Cells["Discription"].Value = data.Rows[0]["Discription"];
        //        _data_grid["Part Type", Row_index] = cell;
        //    }
        //}
        //// chang part type From Combo
        //private void _change_cell_text(int Row_index)
        //{
        //    if (_data_grid.CurrentCell != null)
        //    {

        //        DataGridViewTextBoxCell text = new DataGridViewTextBoxCell();
        //        _data_grid["Part Type", Row_index] = text;
        //    }
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Add_Update_Receiving()
        {
            ///(@inv,@d,@CI,@BI,@E,@UI,@TOT,@DIS,@TAX)
            Table = Application.OpenForms.OfType<Form1>().FirstOrDefault().Table;
            SqlCommand com = new SqlCommand("[Add_Update_Receiving_Num]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@inv", int.Parse(_INV_NUM_Text.Text));
            com.Parameters.AddWithValue("@d", _date_picker.Text);
            com.Parameters.AddWithValue("@CI", _company_combo.SelectedValue);
            com.Parameters.AddWithValue("@BI", _boat_combo.SelectedValue);
            com.Parameters.AddWithValue("@E", _engine_combo.SelectedValue);
            com.Parameters.AddWithValue("@UI", Table.Rows[0][0]);
            com.Parameters.AddWithValue("@ToT", int.Parse(_total_text.Text));
            com.Parameters.AddWithValue("@DIS", DBNull.Value);
            com.Parameters.AddWithValue("@TAX", DBNull.Value);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // math mathod
        private void _Math()
        {
            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "")
            {
                _total_text.Text = "0.00";
            }
        }

        //
        public void bindingInvoice(int _inv_num)
        {
            SqlCommand invo = new SqlCommand("Receiving_inv_get", con);
            invo.CommandType = CommandType.StoredProcedure;
            invo.Parameters.AddWithValue("@inv", _inv_num);
            SqlDataAdapter invoice = new SqlDataAdapter(invo);
            _table_invoice.Clear();
            invoice.Fill(_table_invoice);
            if (_table_invoice.Rows.Count > 0)
            {
                _date_picker.Value = Convert.ToDateTime(_table_invoice.Rows[0][1]);
                _company_combo.SelectedValue = _table_invoice.Rows[0][2];
                _boat_combo.SelectedValue = _table_invoice.Rows[0][3];
                _engine_combo.SelectedValue = _table_invoice.Rows[0][4];
                _total_text.Text = _table_invoice.Rows[0][6].ToString();
            }
            // select Command
            SqlCommand _select_parts_com = new SqlCommand("Receving_part_get", con);
            _select_parts_com.CommandType = CommandType.StoredProcedure;
            _select_parts_com.Parameters.AddWithValue("@inv", _inv_num);
            _adapter.SelectCommand = _select_parts_com;

            // insert command  (@PN varchar(50),@PT varchar(50),@QN int ,@Dis varchar (50),@Price money ,@inv int,@MOV int)
            //p.PartType,p.Quantity,p.Discription,p.Price,p.INV_Num,p.Move_Num
            SqlCommand _insert_parts_com = new SqlCommand("receiving_Part", con);
            _insert_parts_com.CommandType = CommandType.StoredProcedure;
            _insert_parts_com.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _insert_parts_com.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _insert_parts_com.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            _insert_parts_com.Parameters.Add("@Dis", SqlDbType.VarChar, 50, "Discription");
            _insert_parts_com.Parameters.Add("@Price", SqlDbType.Money, 5, "Price");
            _insert_parts_com.Parameters.Add("@hand", SqlDbType.Int, 4, "Receiving_Num");
            _adapter.InsertCommand = _insert_parts_com;

            //Update Command @ID int,@PN varchar(50),@PT varchar(50), @Quan int ,@Disc  varchar (50),@Pr money , @inv int ,@mov int
            SqlCommand _update_parts_com = new SqlCommand("[update_Receiving_part]", con);
            _update_parts_com.CommandType = CommandType.StoredProcedure;
            _update_parts_com.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _update_parts_com.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _update_parts_com.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _update_parts_com.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            _update_parts_com.Parameters.Add("@Dis", SqlDbType.VarChar, 50, "Discription");
            _update_parts_com.Parameters.Add("@Price", SqlDbType.Money, 5, "Price");
            _update_parts_com.Parameters.Add("@receiving", SqlDbType.Int, 4, "Receiving_Num");
            _adapter.UpdateCommand = _update_parts_com;


            _table_parts.Clear();
            _adapter.Fill(_table_parts);
            if (_table_parts.Columns.Count < 10) _table_parts.Columns.Add("Total", typeof(float));
            _table_parts.Columns["Total"].Expression = "(Quantity)*(Price)";
            _table_parts.Columns["Receiving_Num"].DefaultValue = _inv_num;
            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "") { _total_text.Text = "0.0"; }


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
            SqlCommand _delete_part_com = new SqlCommand("Delete_receiving_Part", con);
            _delete_part_com.CommandType = CommandType.StoredProcedure;
            _delete_part_com.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _adapter.DeleteCommand = _delete_part_com;
            this.ActiveControl = null;
        }
        // all storge Part'S
        private void storg()
        {
            // all Parts Table
            SqlCommand added = new SqlCommand("Show_all_storge", con);
            added.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter gon = new SqlDataAdapter();
            gon.SelectCommand = added;
            gon.Fill(_tabel_storge);

        }

        // company mathond

        private void company_Mathod()
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

        // boate mathond
        private void Boat()
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
        // Eng mathod
        private void Eng()
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
        private void new_Num()
        {
            SqlCommand com = new SqlCommand("Receving_Num_", con);
            com.CommandType = CommandType.StoredProcedure;
            con.Open();
            _INV_NUM_Text.Text = com.ExecuteScalar().ToString();
            con.Close();
        }
        //Move Mathod

        private void _company_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boat();
            Eng();
        }

        private void _boat_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eng();
        }

        private void _INV_NUM_Text_Leave(object sender, EventArgs e)
        {
            if (_INV_NUM_Text.Text == "")
            {
                new_Num();
            }
            _table_parts.Columns["Receiving_Num"].DefaultValue = int.Parse(_INV_NUM_Text.Text);
            for (int i = 0; i < _table_parts.Rows.Count; i++)
            {
                _table_parts.Rows[i]["Receiving_Num"] = _table_parts.Columns["Receiving_Num"].DefaultValue;
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

        private void Data_grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox prodCode = e.Control as TextBox;
            if (_data_grid.CurrentCell.ColumnIndex == 
                _data_grid.Columns["Part Number"].Index)
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
                        if (_data_grid.CurrentRow.Cells[1].Value != null)
                        {
                            string PN = _data_grid.CurrentRow.Cells[1].Value.ToString();
                            if (Application.OpenForms.OfType<Part_info>().Count() == 1)
                            {
                                Application.OpenForms.OfType<Part_info>().First().Serch_anther(PN);
                                Application.OpenForms.OfType<Part_info>().First().Location =
                                    new Point(this.Location.X + this.Width, this.Location.Y + 135);
                            }

                        }

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

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (_INV_NUM_Text.Text != "")
            {
                if (_company_combo.SelectedValue == null || _company_combo.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Plesse enter castomer name", "New Receiving", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                   // try
                   // {
                    Add_Update_Receiving();
                    _data_grid.EndEdit();
                    _adapter.Update(_table_parts);
                    bindingInvoice(int.Parse(_INV_NUM_Text.Text));
                    MessageBox.Show("The Receiving has been saved successfully", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // }
                   // catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
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

        private void _company_combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            new_Num();
            bindingInvoice(int.Parse(_INV_NUM_Text.Text));
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Edite_Receiving form = new Edite_Receiving();
            form.TopLevel = true;
            form.ShowDialog(this);
        }

        private void INV_Docment_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Height;
            if (datagridrow == 0)
            {
                e.Graphics.DrawString("Receiving Permision", new Font("Georgia", 25, FontStyle.Underline), Brushes.Black, new Point(280, 120));
                e.Graphics.DrawString("Customer Name : " + _company_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 175));
                if (_boat_combo.SelectedValue != DBNull.Value)
                { e.Graphics.DrawString("Boat Name : " + _boat_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 200)); }
                if (_engine_combo.SelectedValue != DBNull.Value)
                { e.Graphics.DrawString("Eng SN : " + _engine_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 225)); }
                e.Graphics.DrawString("Number : R" + _INV_NUM_Text.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(620, 175));
                e.Graphics.DrawString("Date : " + _date_picker.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(620, 200));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 270), new Point(810, 270));
                e.Graphics.DrawString("Part Number", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(80, 275));
                e.Graphics.DrawString("Discription", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(400, 275));
                e.Graphics.DrawString("Quantity", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(690, 275));
                //e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 275));
                //e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(760, 275));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 300), new Point(810, 300));
                Height = 310;
                mosal = 1;
            }
            else
            {
                e.Graphics.DrawLine(Pens.Black, new Point(45, 130), new Point(810, 130));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(80, 135));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(400, 135));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(690, 135));
                //e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 135));
                //e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(760, 135));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 160), new Point(810, 160));
                Height = 170;
            }
            while (datagridrow < _data_grid.Rows.Count - 1)
            {
                if (Height < e.PageSettings.PrintableArea.Height - 120)
                {
                    if (_data_grid.Rows[datagridrow].Cells[4].Value != null && _data_grid.Rows[datagridrow].Cells[5].Value != null && _data_grid.Rows[datagridrow].Cells[3].Value != null && _data_grid.Rows[datagridrow].Cells[0].Value != null && _data_grid.Rows[datagridrow].Cells[2].Value != null)
                    {
                        e.Graphics.DrawString((mosal).ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(15, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Part Number"].Value.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(95, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Discription"].Value.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(410, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Quantity"].Value.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(720, Height));
                        //e.Graphics.DrawString(Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Price"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(590, Height));
                        //e.Graphics.DrawString(Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Total"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(770, Height));
                        mosal += 1;
                    }
                    else continue;
                    Height += 30;
                    e.Graphics.DrawLine(Pens.Black, new Point(80, Height - 5), new Point(780, Height - 5));
                    datagridrow += 1;
                    e.HasMorePages = false;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(45, 1050), new Point(810, 1050));
                    e.HasMorePages = true;
                    Height = 200;
                    return;
                }
            }
            //if(dataGridView1.Rows.Count-1>4) 
            e.Graphics.DrawLine(Pens.Black, new Point(45, Height + 20), new Point(810, Height + 20));
            //e.Graphics.DrawString("Overall : " + _total_text.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(50, Height + 15));
            e.Graphics.DrawString("Recipient :", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, Height + 50));
            e.Graphics.DrawString("Sign :", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(610, Height + 50));
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

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you want to delete this invoice", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlCommand delete = new SqlCommand("Delete_all_rec", con);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.AddWithValue("@rec", int.Parse(_INV_NUM_Text.Text));
                con.Open();
                delete.ExecuteNonQuery();
                con.Close();
                bindingInvoice(int.Parse(_INV_NUM_Text.Text));
            }
        }

        private void _data_grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void _Company_pictureBox_Click(object sender, EventArgs e)
        {
            Company start = new Company();
            start.TopLevel = true;
            start.ShowDialog(this);
            company_Mathod();
        }

        private void _Boat_pictureBox_Click(object sender, EventArgs e)
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

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            if (_data_grid.SelectedRows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                // Iterate through each selected row
                for (int t = 0; t < _data_grid.SelectedRows.Count; t++)
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
                    newRow[1] = cells[0];
                    newRow[2] = cells[1];
                    newRow[3] = cells[2];
                    newRow[4] = cells[3];
                    newRow[5] = cells[4];
                    newRow[9] = cells[5];
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

        private void Copy_selected_row_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 parint = (Form1) Application.OpenForms.OfType<Form1>().FirstOrDefault();
            copy_select = ((DataTable)_data_grid.DataSource).Clone();
            foreach (DataGridViewRow row in _data_grid.SelectedRows)
            {
                copy_select.ImportRow(((DataTable)_data_grid.DataSource).Rows[row.Index]);
            }
            copy_select.AcceptChanges();
            parint.Copy = ReverseRowsInDataTable(copy_select).Copy();
        }

        DataTable ReverseRowsInDataTable(DataTable inputTable)
        {
            DataTable outputTable = inputTable.Clone();

            for (int i = inputTable.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(inputTable.Rows[i]);
            }

            return outputTable;
        }

        private void Data_grid_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.F1 && _data_grid.CurrentRow.Cells[0].Value != null)
            {
                string PN = _data_grid.CurrentRow.Cells[1].Value.ToString();

                if (Application.OpenForms.OfType<Part_info>().Count() == 1)
                {
                    Application.OpenForms.OfType<Part_info>().First().Serch_anther(PN);
                    Application.OpenForms.OfType<Part_info>().First().Location =
                        new Point(this.Location.X + this.Width, this.Location.Y + 135);
                }
                else if (_data_grid.SelectedRows.Count > 0)
                {
                    Part_info info = new Part_info(PN)
                    { Owner = this };
                    info.Show();
                    info.Location = new Point(this.Location.X + this.Width, this.Location.Y + 135);
                }
            }

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Set_Location start = new Set_Location(int.Parse(_INV_NUM_Text.Text),true);
            start.TopLevel = true;
            start.Show(this);

        }

        private void OPenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<search_Part>().Count() == 1 && _data_grid.SelectedRows.Count > 0)
            {
                Application.OpenForms.OfType<search_Part>()
                    .First().search(_data_grid.SelectedRows[0].Cells["Part Number"]
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

        private void SaveAsEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string company;
            try
            {
                string newpath = ConfigurationManager.AppSettings["Reciving_folder"];
                string Old_file = ConfigurationManager.AppSettings["Reciving_xls"];
                if (_data_grid.Rows.Count > 0)
                {
                    FileInfo f1 = new FileInfo(Old_file);
                    
                    if (!Directory.Exists(newpath))
                    {
                        Directory.CreateDirectory(newpath);
                    }
                    try
                    {
                        
                        if (_boat_combo.SelectedIndex != 0)
                        {
                            company = _boat_combo.Text;
                        }
                        else
                        {
                            company = _company_combo.Text;
                        }

                        f1.CopyTo(string.Format("{0}\\{1}{2}", newpath, _INV_NUM_Text.Text, f1.Extension));
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
                    {
                        x.Cells[9, 3] = "R" + _date_picker.Value.ToString("yy") + "00" + _INV_NUM_Text.Text;

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
                string newpath = ConfigurationManager.AppSettings["Reciving_folder"];

                DirectoryInfo diSource = new DirectoryInfo(newpath);
                string ExactFilename = string.Empty;

                foreach (FileInfo file in diSource.GetFiles(string.Format("{0}.*", _INV_NUM_Text.Text), SearchOption.TopDirectoryOnly))
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripContainer1_ContentPanel_MouseDown(object sender, MouseEventArgs e)
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

        private void toolStripContainer1_ContentPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point cursorDiff = Point.Subtract(Cursor.Position, new Size(lastCursor));
                this.Location = Point.Add(lastForm, new Size(cursorDiff));
                if (Application.OpenForms.OfType<Part_info>().Count() == 1)
                {
                    Application.OpenForms.OfType<Part_info>().First().Location =
                        new Point(this.Location.X + this.Width, this.Location.Y + 135);
                }
            }
        }

        private void toolStripContainer1_ContentPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            Cursor = Cursors.Default;
        }

        private void _Receiving_permission_Load(object sender, EventArgs e)
        {
            
                // احصل على حجم الشاشة
                var screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                var screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                // احسب موقع النافذة
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);
            
        }

        private void _data_grid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            _data_grid.CurrentRow.Cells["Part Type"] = cell;
        }
    }
}
