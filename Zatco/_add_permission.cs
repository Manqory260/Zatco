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
using System.Windows.Controls.Primitives;

namespace Zatco
{
    public partial class Add_permission : Form
    {
        public Add_permission()
        {
            InitializeComponent();
            Suppliers();
            NewAddNumber();
            storg();
            add_Type();
            Text_Type_AutoComplet();
            Binding_AddPermission(int.Parse(_INV_NUM_Text.Text));
        }
        public Add_permission(int AddPermissionNumber)
        {
            InitializeComponent();
            Suppliers();
            NewAddNumber();
            storg();
            add_Type();
            Text_Type_AutoComplet();
            Binding_AddPermission(AddPermissionNumber);
            _INV_NUM_Text.Text = AddPermissionNumber.ToString();
        }
        int datagridrow = 0;
        int mosal = 1;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        public bool _grid_selection_changed_event = true;
        SqlDataAdapter _adapter = new SqlDataAdapter();
        DataTable _table_parts = new DataTable();
        DataTable _table_invoice = new DataTable();
        DataTable _tabel_storge = new DataTable();
        DataTable _table_Part_type = new DataTable();

        private bool AddedType
        {
            set { textBox4.Visible = value; button1.Visible = value; }
        }

        public void _OpenAntherPermission(int AddPermissionNumber)
        {
            Binding_AddPermission(AddPermissionNumber);
            _INV_NUM_Text.Text = AddPermissionNumber.ToString();
        }
        private void Text_Type_AutoComplet()
        {
            SqlCommand part_Comp = new SqlCommand("select_ParTyp", con);
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
                arr[i] = read["part_Type"].ToString();
                i++;
            }
            con.Close();
            var comp = new AutoCompleteStringCollection();
            comp.AddRange(arr);
            textBox4.AutoCompleteCustomSource = comp;
            textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        // Sql connection with Zatco DB
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ZatcoDB;Integrated Security=True");

        public TextBox _InvText
        {
            set { _INV_NUM_Text = value; }
            get { return _INV_NUM_Text; }
        }

        void _update_addPermission()
        {
            Form1 add = (Form1)Application.OpenForms.OfType<Form1>().FirstOrDefault();
            SqlCommand insert_Request = new SqlCommand("Added_Update_AddPermission", con);
            insert_Request.CommandType = CommandType.StoredProcedure;
            insert_Request.Parameters.AddWithValue("@inv", int.Parse(_INV_NUM_Text.Text));
            insert_Request.Parameters.AddWithValue("@Date", _date_picker.Text);
            insert_Request.Parameters.AddWithValue("@Us", add.Table.Rows[0][0]);
            insert_Request.Parameters.AddWithValue("@Sup", _Suppler_combo.SelectedValue);
            if (_total_text.Text != "") insert_Request.Parameters.AddWithValue("@total", float.Parse(_total_text.Text)); else { insert_Request.Parameters.AddWithValue("@total", DBNull.Value); }
            if (_Notes.Text != "") { insert_Request.Parameters.AddWithValue("@note", _Notes.Text); } else { insert_Request.Parameters.AddWithValue("@note", DBNull.Value); }
            con.Open();
            insert_Request.ExecuteNonQuery();
            con.Close();
        }

        void _Math()
        {
            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "")
            {
                _total_text.Text = "0.00";
            }

        }

        void add_Type()
        {
            SqlCommand type = new SqlCommand("select_ParTyp", con);
            type.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(type);
            _table_Part_type.Clear();
            ad.Fill(_table_Part_type);
        }

        void storg()
        {
            // all Parts Table
            SqlCommand added = new SqlCommand("Show_all_storge", con);
            added.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter gon = new SqlDataAdapter();
            gon.SelectCommand = added;
            gon.Fill(_tabel_storge);

        }

        // <supplier combo box >
        private void Suppliers()
        {
            SqlCommand combo_com = new SqlCommand("Supplier_Combo", con);
            combo_com.CommandType = CommandType.StoredProcedure;
            DataTable comb_tab = new DataTable();
            SqlDataAdapter combo_adpter = new SqlDataAdapter(combo_com);
            combo_adpter.Fill(comb_tab);
            _Suppler_combo.DataSource = comb_tab;
            _Suppler_combo.ValueMember = "Sup_ID";
            _Suppler_combo.DisplayMember = "Name";
        }
        // </supplier combo box>

        // <New Add Number>
        private void NewAddNumber()
        {
            SqlCommand add_number_com = new SqlCommand("ADD_number", con);
            add_number_com.CommandType = CommandType.StoredProcedure;
            con.Open();
            _INV_NUM_Text.Text = add_number_com.ExecuteScalar().ToString();
            con.Close();
        }

        // </New Add Number>

        public void Binding_AddPermission(int addPerissionNumber)
        {
            toolTip2.SetToolTip(pictureBox1, "Press to add New supller");
            _table_parts.Clear();
            SqlCommand inv = new SqlCommand("Add_Request_Main", con);
            inv.CommandType = CommandType.StoredProcedure;
            inv.Parameters.AddWithValue("@inv", addPerissionNumber);
            SqlDataAdapter add_da = new SqlDataAdapter(inv);
            _table_invoice.Clear();
            add_da.Fill(_table_invoice);
            if (_table_invoice.Rows.Count != 0)
            {
                _Suppler_combo.SelectedValue = _table_invoice.Rows[0]["Sup_ID"];
                _date_picker.Value = Convert.ToDateTime(_table_invoice.Rows[0][1]);
                _total_text.Text = _table_invoice.Rows[0]["Total"].ToString();
                _Notes.Text = _table_invoice.Rows[0]["Notes"].ToString();
            }

            SqlCommand _select_part_command = new SqlCommand("add_part_get", con);
            _select_part_command.CommandType = CommandType.StoredProcedure;
            _select_part_command.Parameters.AddWithValue("@inv", addPerissionNumber);
            _adapter.SelectCommand = _select_part_command;

            //@PN varchar(50) , @PT varchar(50),@Quan int ,@Disc varchar(50),@Pr money ,@inv int
            SqlCommand _insert_part_command = new SqlCommand("Parts_add", con);
            _insert_part_command.CommandType = CommandType.StoredProcedure;
            _insert_part_command.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _insert_part_command.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _insert_part_command.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            _insert_part_command.Parameters.Add("@Disc", SqlDbType.VarChar, 50, "Discription");
            _insert_part_command.Parameters.Add("@Pr", SqlDbType.Money, 5, "Price");
            _insert_part_command.Parameters.Add("@inv", SqlDbType.Int, 4, "INV_Num");
            _adapter.InsertCommand = _insert_part_command;

            //@ID int ,@PN varchar(50),@PT varchar(50),@Quan int ,@Dis varchar(50),@Price money ,@inv int
            SqlCommand _update_part_command = new SqlCommand("Update_add_part", con);
            _update_part_command.CommandType = CommandType.StoredProcedure;
            _update_part_command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _update_part_command.Parameters.Add("@PN", SqlDbType.VarChar, 50, "Part Number");
            _update_part_command.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            _update_part_command.Parameters.Add("@PT", SqlDbType.VarChar, 50, "Part Type");
            _update_part_command.Parameters.Add("@Dis", SqlDbType.VarChar, 50, "Discription");
            _update_part_command.Parameters.Add("@Price", SqlDbType.Money, 5, "Price");
            _update_part_command.Parameters.Add("@inv", SqlDbType.Int, 4, "INV_Num");
            _adapter.UpdateCommand = _update_part_command;

            //@ID int
            SqlCommand _delete_part_command = new SqlCommand("Delete_add_permission", con);
            _delete_part_command.CommandType = CommandType.StoredProcedure;
            _delete_part_command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            _adapter.DeleteCommand = _delete_part_command;

            _adapter.Fill(_table_parts);
            if (_table_parts.Columns.Count < 8) _table_parts.Columns.Add("Total", typeof(float));
            _table_parts.Columns["Total"].Expression = "(Quantity)*(Price)";
            _table_parts.Columns["INV_Num"].DefaultValue = addPerissionNumber;
            _total_text.Text = _table_parts.Compute("SUM(Total)", "").ToString();
            if (_total_text.Text == "") { _total_text.Text = "0.0"; }


            _data_grid.DataSource = null;
            _data_grid.ClearSelection();
            _data_grid.DataSource = _table_parts;
            _data_grid.Columns["ID"].Visible = false;
            _data_grid.Columns["INV_Num"].Visible = false;
            _data_grid.Columns["Total"].ReadOnly = true;
            _data_grid.Columns["Price"].DefaultCellStyle.Format = "0.0";

            if (_table_parts.Columns.Count > 9)
            {
                _data_grid.Columns["PartNum"].Visible = false;
                _data_grid.Columns["PartType"].Visible = false;
                _data_grid.Columns["Minimum_Quantity"].Visible = false;
                _data_grid.Columns["Location"].Visible = false;

            }
        }

        private void _data_grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_data_grid.CurrentCell != null && _grid_selection_changed_event)
            {
                if (_data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Type"].Index || _data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Number"].Index && _table_Part_type.Rows.Count != 0)
                {
                    if (_data_grid.SelectedCells.Count > 0 && con.State != ConnectionState.Open)
                    {
                        DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                        cell.DataSource = _table_Part_type;
                        cell.DisplayMember = "Part_Type";
                        cell.ValueMember = "Part_Type";
                        cell.FlatStyle = FlatStyle.Flat;
                        _data_grid.CurrentRow.Cells["Part Type"] = cell;
                    }
                }
                //
                // Last Purchase Price To datagridView Price cell
                //
                if (_data_grid.CurrentRow.Cells["Part Type"].Value != _table_parts.Columns["Part Type"].DefaultValue && _Suppler_combo.SelectedValue != null && _data_grid.CurrentRow.Cells["Price"].Value == _table_parts.Columns["Price"].DefaultValue)
                {
                    SqlCommand quan = new SqlCommand("Last_purchase_price", con);
                    quan.CommandType = CommandType.StoredProcedure;
                    quan.Parameters.AddWithValue("@PN", _data_grid.CurrentRow.Cells["Part Number"].Value);
                    quan.Parameters.AddWithValue("@PT", _data_grid.CurrentRow.Cells["Part Type"].Value);
                    quan.Parameters.AddWithValue("@SID", _Suppler_combo.SelectedValue);
                    DataTable data = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(quan);
                    adp.Fill(data);
                    if (data.Rows.Count != 0)
                    {
                        _data_grid.CurrentRow.Cells["Price"].Value = data.Rows[0]["Price"];
                    }
                    //
                    //  Min Price Tool Tip
                    //
                    SqlCommand Min_price = new SqlCommand("Min_Price", con);
                    Min_price.CommandType = CommandType.StoredProcedure;
                    Min_price.Parameters.AddWithValue("@PN", _data_grid.CurrentRow.Cells["Part Number"].Value);
                    Min_price.Parameters.AddWithValue("@PT", _data_grid.CurrentRow.Cells["Part Type"].Value);
                    DataTable Min_price_table = new DataTable();
                    SqlDataAdapter MPA = new SqlDataAdapter(Min_price);
                    MPA.Fill(Min_price_table);
                    if (Min_price_table.Rows.Count > 0)
                    {

                        ToolTip MinPrice = new ToolTip();
                        MinPrice.Show(string.Format("Purchased at a price {0} form {1}",
                       Math.Round(Convert.ToDecimal(Min_price_table.Rows[0][2]), 1),
                      Min_price_table.Rows[0][5]),
                                  _data_grid,
                                  _data_grid.CurrentRow.Cells["Price"].ContentBounds.Location.X,
                                  _data_grid.CurrentRow.Cells["Price"].ContentBounds.Location.Y,
                                  4000);
                        _data_grid.ShowCellToolTips = false;
                    }
                }
                if (_data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Type"].Index || _data_grid.CurrentCell.ColumnIndex == _data_grid.Columns["Part Number"].Index)
                {
                    if (_data_grid.CurrentRow.Cells["Part Number"].Value != _table_parts.Columns["Part Number"].DefaultValue)
                    {
                        if (_data_grid.CurrentRow.Cells["Discription"].Value == _table_parts.Columns["Discription"].DefaultValue)
                        {
                            try
                            {
                                String _sqlWhere = "[Part Number] = '" + _data_grid.CurrentRow.Cells["Part Number"].Value + "'";
                                String _sqlOrder = "[Part Number]";
                                DataTable _newDataTable = _tabel_storge.Select(_sqlWhere, _sqlOrder).CopyToDataTable();
                                _data_grid.CurrentRow.Cells["Discription"].Value = _newDataTable.Rows[0]["Discription"].ToString();
                            }
                            catch (Exception) { };
                        }
                    }
                }
            }
            _Math();

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

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            _data_grid.Focus();
            if (_INV_NUM_Text.Text != "")
            {
                if (_Suppler_combo.SelectedValue == null || _Suppler_combo.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Plesse enter castomer name", "New Receiving", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    try
                    {
                        _update_addPermission();
                        _data_grid.EndEdit();
                        _adapter.Update(_table_parts);
                        Binding_AddPermission(int.Parse(_INV_NUM_Text.Text));
                        if (DialogResult.Yes == MessageBox.Show("The Receiving has been saved successfully Are you want to open location", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                        {
                            Set_Location start = new Set_Location(int.Parse(_INV_NUM_Text.Text), false);
                            start.TopLevel = true;
                            start.Show(this);

                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

        }

        private void _INV_NUM_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _INV_NUM_Text.Text != "")
            {
                Binding_AddPermission(int.Parse(_INV_NUM_Text.Text));
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Set_Location start = new Set_Location(int.Parse(_INV_NUM_Text.Text), false);
            start.TopLevel = true;
            start.Show(this);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Edit_Add_permission play = new Edit_Add_permission();
            play.TopLevel = true;
            play.ShowDialog(this);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewAddNumber();
            Binding_AddPermission(int.Parse(_INV_NUM_Text.Text));
        }

        private void INV_Docment_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int Height;
            if (datagridrow == 0)
            {
                e.Graphics.DrawString("Added Permision", new Font("Georgia", 25, FontStyle.Underline), Brushes.Black, new Point(280, 120));
                e.Graphics.DrawString("Suppler Name : " + _Suppler_combo.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(35, 175));
                e.Graphics.DrawString("Number : R" + _INV_NUM_Text.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(620, 175));
                e.Graphics.DrawString("Date : " + _date_picker.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(620, 200));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 270), new Point(810, 270));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 275));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, 275));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 275));
                e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 275));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(760, 275));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 300), new Point(810, 300));
                Height = 310;
                mosal = 1;
            }
            else
            {
                e.Graphics.DrawLine(Pens.Black, new Point(45, 130), new Point(810, 130));
                e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 135));
                e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, 135));
                e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 135));
                e.Graphics.DrawString("Unite Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 135));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(760, 135));
                e.Graphics.DrawLine(Pens.Black, new Point(45, 160), new Point(810, 160));
                Height = 180;
            }
            while (datagridrow < _data_grid.Rows.Count - 1)
            {
                if (Height < e.PageSettings.PrintableArea.Height - 120)
                {
                    if (_data_grid.Rows[datagridrow].Cells[4].Value != null && _data_grid.Rows[datagridrow].Cells[5].Value != null && _data_grid.Rows[datagridrow].Cells[3].Value != null && _data_grid.Rows[datagridrow].Cells[0].Value != null && _data_grid.Rows[datagridrow].Cells[2].Value != null)
                    {
                        e.Graphics.DrawString((mosal).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(15, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Part Number"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(75, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Discription"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(220, Height));
                        e.Graphics.DrawString(_data_grid.Rows[datagridrow].Cells["Quantity"].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(410, Height));
                        e.Graphics.DrawString(Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Price"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(590, Height));
                        e.Graphics.DrawString(Math.Round(float.Parse(_data_grid.Rows[datagridrow].Cells["Total"].Value.ToString()), 2, MidpointRounding.AwayFromZero).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(770, Height));
                        mosal += 1;
                    }
                    else continue;
                    Height += 25;
                    datagridrow += 1;
                    e.HasMorePages = false;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(45, 990), new Point(810, 990));
                    e.HasMorePages = true;
                    Height = 200;
                    return;
                }
            }
            //if(dataGridView1.Rows.Count-1>4) 
            e.Graphics.DrawLine(Pens.Black, new Point(45, Height + 10), new Point(810, Height + 10));
            e.Graphics.DrawString("Overall : " + _total_text.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(50, Height + 15));
            e.Graphics.DrawString("Refaat Elsaady", new Font("SketchFlow Print", 12, FontStyle.Italic), Brushes.Black, new Point(45, Height + 50));
            e.Graphics.DrawString("Recipient :", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(250, Height + 50));
            e.Graphics.DrawString("Sign :", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(610, Height + 50));
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            datagridrow = 0;
            mosal = 1;
            INV_PrintPReview.Document = INV_Docment;
            INV_PrintPReview.ShowDialog();

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                SqlCommand add = new SqlCommand("Delete_partType", con);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.AddWithValue("@PT", textBox4.Text);
                con.Open();
                string res = add.ExecuteScalar().ToString();
                con.Close();
                if (res == "suc")
                {
                    AddedType = true;
                    MessageBox.Show("Delete  successfully", "Part Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.Text = "";
                    add_Type();
                    Text_Type_AutoComplet();
                }
                else MessageBox.Show("Can't delete may by not fond or is allready in use", "Part Type", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                SqlCommand add = new SqlCommand("Insert_partyp", con);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.AddWithValue("@pt", textBox4.Text);
                con.Open();
                add.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added successfully", "Part Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddedType = false;
                textBox4.Text = "";
                add_Type();
                Text_Type_AutoComplet();
            }
            else
            {
                AddedType = false;
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddedType = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            suppliers start = new suppliers();
            start.ShowDialog(this);
            Suppliers();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength > 0) { button1.Text = "save"; }
            else { button1.Text = "Close"; }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("are you want to delete this invoice", "Add Permission", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (mess == DialogResult.Yes)
            {
                SqlCommand com = new SqlCommand("Delete_all_data_of_add_permission", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@add", int.Parse(_InvText.Text));
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Binding_AddPermission(int.Parse(_INV_NUM_Text.Text));
            }
        }

        private void searchInPartsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void _data_grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

        private void Add_permission_Load(object sender, EventArgs e)
        {
            // احصل على حجم الشاشة
            var screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            var screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // احسب موقع النافذة
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);

        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
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
                        if (cell != _data_grid.Rows[t].Cells[6] && cell != _data_grid.Rows[t].Cells[5])
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

        private void ToolStripButton4_Click(object sender, EventArgs e)
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
                    newRow[0] = cells[0];
                    newRow[1] = cells[1];
                    newRow[2] = cells[2];
                    newRow[3] = cells[3];
                    newRow[4] = cells[4];
                    newRow[7] = cells[5];
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

        private void _data_grid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            _data_grid.CurrentRow.Cells["Part Type"] = cell;
        }
    }
}
