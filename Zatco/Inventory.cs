using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Zatco
{
    public partial class Inventory : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        DataTable inventory = new DataTable();
        SqlDataAdapter ad = new SqlDataAdapter();
        SqlDataAdapter stores = new SqlDataAdapter();
        DataTable stores_table = new DataTable();
        int GridRow;

        public Inventory()
        {
            InitializeComponent();
        }
        public TextBox TextBox1
        {
            set { textBox1= value; }
            get { return textBox1; }

        }
        
        private void new_num()
        {
            Form1 parint = (Form1)this.Owner;
            if (MessageBox.Show("are you shour u want to start new inventory to date "+DateTime.Today.ToShortDateString(), "inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand inv_num = new SqlCommand("next_inventory_num", con);
                inv_num.CommandType = CommandType.StoredProcedure;
                con.Open();
                textBox1.Text = inv_num.ExecuteScalar().ToString();
                con.Close();
                textBox2.Text = parint.Table.Rows[0][1].ToString();
                SqlCommand add = new SqlCommand("[Inventory_insert]", con);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                add.Parameters.AddWithValue("@date", DateTime.Today);
                add.Parameters.AddWithValue("@na", parint.Table.Rows[0][0]);
                con.Open();
                add.ExecuteNonQuery();
                con.Close();
            }
        }
        private void last_num()
        {
            SqlCommand lastnum = new SqlCommand("select max (ID) from Inventory", con);
            SqlDataAdapter ln = new SqlDataAdapter(lastnum);
            DataTable table = new DataTable();
            ln.Fill(table);
            if (table.Rows[0][0]!= DBNull.Value)
            {
                textBox1.Text = table.Rows[0][0].ToString();
            }
            else
            {
                new_num();
            }
        }
        private void Stores_settlement ()
        {
            stores_table.Clear();
            dataGridView5.DataSource = null;
            SqlCommand settlement_com = new SqlCommand("select_Deficit_Part", con);
            settlement_com.CommandType = CommandType.StoredProcedure;
            settlement_com.Parameters.AddWithValue("@INV", Convert.ToInt32(textBox1.Text));
            stores.SelectCommand = settlement_com;
            stores.Fill(stores_table);
            dataGridView5.DataSource = stores_table;

            SqlCommand stores_update = new SqlCommand("Update_Deficit_Part",con);
            stores_update.CommandType = CommandType.StoredProcedure;
            stores_update.Parameters.Add("@PN", SqlDbType.VarChar, 50, "PartNum");
            stores_update.Parameters.Add("@PT", SqlDbType.VarChar, 50, "partType");
            stores_update.Parameters.Add("@INV", SqlDbType.Int, 4, "Inventory_ID");
            stores_update.Parameters.Add("@Quan", SqlDbType.Int, 4, "Deficit_Quantity");
            stores_update.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            stores.UpdateCommand = stores_update;

            SqlCommand delete_com = new SqlCommand("Delete_Deficit_part", con);
            delete_com.CommandType = CommandType.StoredProcedure;
            delete_com.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            stores.DeleteCommand = delete_com;
            dataGridView5.Columns[0].ReadOnly = true ;
            dataGridView5.Columns[1].ReadOnly = true;
            dataGridView5.Columns[2].Visible = false;
            dataGridView5.Columns[4].Visible = false;
        }
        private void databind()
        {
            dataGridView1.DataSource = null;
            inventory.Clear();
            SqlCommand inv_data = new SqlCommand("Inventory_select", con);
            inv_data.CommandType = CommandType.StoredProcedure;
            inv_data.Parameters.AddWithValue("@inv", Convert.ToInt32(textBox1.Text));
            ad.SelectCommand = inv_data;
            SqlCommand insert_part = new SqlCommand("Inventory_part_add", con);
            insert_part.CommandType = CommandType.StoredProcedure;
            insert_part.Parameters.Add("@ID", SqlDbType.Int, 4, "Inventory_ID");
            insert_part.Parameters.Add("@PN", SqlDbType.VarChar, 50, "PartNumber");
            insert_part.Parameters.Add("@PT", SqlDbType.VarChar, 50, "PartType");
            insert_part.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            ad.InsertCommand = insert_part;
            SqlCommand update_part = new SqlCommand("update_inventory", con);
            update_part.CommandType = CommandType.StoredProcedure;
            update_part.Parameters.Add("@PN", SqlDbType.VarChar, 50, "PartNumber");
            update_part.Parameters.Add("@PT", SqlDbType.VarChar, 50, "PartType");
            update_part.Parameters.Add("@Quan", SqlDbType.Int, 4, "Quantity");
            update_part.Parameters.Add("@invID", SqlDbType.Int, 4, "Inventory_ID");
            update_part.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            ad.UpdateCommand = update_part;
            SqlCommand delete_part = new SqlCommand("Delete_inventory", con);
            delete_part.CommandType = CommandType.StoredProcedure;
            delete_part.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            ad.DeleteCommand = delete_part;
            ad.Fill(inventory);
            dataGridView1.DataSource = inventory;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            data_comboBox();
            progress_Bar();
        }
        private void data_inventory(int id)
        {
            SqlCommand inv_data = new SqlCommand("invetory_select1", con);
            inv_data.CommandType = CommandType.StoredProcedure;
            inv_data.Parameters.AddWithValue("@inv", id);
            SqlDataAdapter ad = new SqlDataAdapter(inv_data);
            DataTable t = new DataTable();
            ad.Fill(t);
            if (t.Rows.Count > 0)
            {
                textBox2.Text = t.Rows[0][2].ToString();
                dateTimePicker1.Value = DateTime.Parse(t.Rows[0][1].ToString());
                dateTimePicker1.Enabled = false;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
            }
        }
        private void Deficit()
        {
            dataGridView2.DataSource = null;
            SqlCommand def = new SqlCommand("[Inventory_Search_date]", con);
            def.CommandType = CommandType.StoredProcedure;
            def.Parameters.AddWithValue("@inv_ID", Convert.ToInt32(textBox1.Text));
            def.Parameters.AddWithValue("@edate", dateTimePicker1.Value);
            def.Parameters.AddWithValue("@type", 1);
            SqlDataAdapter ad = new SqlDataAdapter(def);
            DataTable tab = new DataTable();
            ad.Fill(tab);
            dataGridView2.DataSource = tab;
            dataGridView2.Columns[6].Visible = false;
        }
        private void over_part()
        {
            dataGridView3.DataSource = null;
            SqlCommand def = new SqlCommand("[Inventory_Search_date]", con);
            def.CommandType = CommandType.StoredProcedure;
            def.Parameters.AddWithValue("@inv_ID", Convert.ToInt32(textBox1.Text));
            def.Parameters.AddWithValue("@edate", dateTimePicker1.Value);
            def.Parameters.AddWithValue("@type", 2);
            SqlDataAdapter ad = new SqlDataAdapter(def);
            DataTable tab = new DataTable();
            ad.Fill(tab);
            dataGridView3.DataSource = tab;
            dataGridView3.Columns[6].Visible = false;
        }
        private void Part_not_stock(int id)
        {
            dataGridView4.DataSource = null;
            SqlCommand stock = new SqlCommand("Parts_notStock", con);
            stock.CommandType = CommandType.StoredProcedure;
            stock.Parameters.AddWithValue("@inv", id);
            SqlDataAdapter ad = new SqlDataAdapter(stock);
            DataTable tab = new DataTable();
            ad.Fill(tab);
            dataGridView4.DataSource = tab;
            dataGridView4.Columns[6].Visible = false;
        }
        private void progress_Bar ()
        {
            SqlCommand added = new SqlCommand("select * from storg order by Location", con);
            DataTable parts = new DataTable();
            SqlDataAdapter gon = new SqlDataAdapter();
            gon.SelectCommand = added;
            gon.Fill(parts);
            toolStripProgressBar1.Maximum = parts.Rows.Count;
            toolStripProgressBar1.Value = inventory.Rows.Count;
        }
        public void Update_all ()
        {
            Deficit();
            data_inventory(Convert.ToInt32(textBox1.Text));
            databind();
            Part_not_stock(Convert.ToInt32(textBox1.Text));
            over_part();
            Stores_settlement();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            last_num();
            Form1 parint = (Form1)this.Owner;
            Deficit();
            data_inventory(Convert.ToInt32(textBox1.Text));
            databind();            
            Part_not_stock(Convert.ToInt32(textBox1.Text));
            over_part();
            Stores_settlement();
        }


        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            try
            {
                ad.Update(inventory);
            }
            catch { }
            MessageBox.Show("Update Sucssifuly", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Update_all();
        }

        private void data_comboBox()
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                SqlCommand type = new SqlCommand("get_Part_Storte", con);
                type.CommandType = CommandType.StoredProcedure;
                type.Parameters.AddWithValue("@PN", dataGridView1.Rows[i].Cells[0].Value);
                SqlDataAdapter type_in = new SqlDataAdapter(type);
                DataTable data = new DataTable();
                type_in.Fill(data);
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.DataSource = data;
                cell.DisplayMember = data.Columns["PartType"].ToString();
                cell.ValueMember = data.Columns["PartType"].ToString();
                cell.Value = inventory.Rows[i][1];
                cell.FlatStyle = FlatStyle.Flat;
                dataGridView1.Rows[i].Cells[1] = cell;

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0 || dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string ss = DBNull.Value.ToString();
                    string a = Convert.ToString(selectedRow.Cells[0].Value);
                    SqlCommand type = new SqlCommand("get_Part_Storte", con);
                    type.CommandType = CommandType.StoredProcedure;
                    type.Parameters.AddWithValue("@PN", dataGridView1.CurrentRow.Cells[0].Value);
                    SqlDataAdapter ads = new SqlDataAdapter(type);
                    DataTable data = new DataTable();
                    ads.Fill(data);
                    DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                    cell.DataSource = data;
                    cell.DisplayMember = data.Columns["PartType"].ToString();
                    cell.ValueMember = data.Columns["PartType"].ToString();
                    cell.FlatStyle = FlatStyle.Flat;
                    dataGridView1.CurrentRow.Cells[3].Value = textBox1.Text;
                    dataGridView1[1, dataGridView1.CurrentCell.RowIndex] = cell;
                }
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //// //////////////
            BeginInvoke(new Action(delegate
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int x = i + 1; x < dataGridView1.Rows.Count - 1; x++)
                    {
                        if (Convert.ToString(dataGridView1.Rows[x].Cells[0].Value) == Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) && Convert.ToString(dataGridView1.Rows[x].Cells[1].Value) == Convert.ToString(dataGridView1.Rows[i].Cells[1].Value))
                        {
                            MessageBox.Show("Part Number is  allready Stocked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows[x].Index);
                        }
                    }
                }
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                SqlCommand insert_def = new SqlCommand("insert_Deficit", con);
                insert_def.CommandType = CommandType.StoredProcedure;
                insert_def.Parameters.AddWithValue("@inv", Convert.ToInt32(textBox1.Text));
                insert_def.Parameters.AddWithValue("@PN", dataGridView2.Rows[i].Cells[0].Value);
                insert_def.Parameters.AddWithValue("@PT", dataGridView2.Rows[i].Cells[1].Value);
                insert_def.Parameters.AddWithValue("@Quan", Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value) * -1);
                con.Open();
                insert_def.ExecuteNonQuery();
                con.Close();
            }
            Update_all();
            MessageBox.Show("settlement deficit done", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                var source = new AutoCompleteStringCollection();
                source.AddRange(arr);

                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteCustomSource = source;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else
                    prodCode.AutoCompleteCustomSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                SqlCommand insert_def = new SqlCommand("insert_Deficit", con);
                insert_def.CommandType = CommandType.StoredProcedure;
                insert_def.Parameters.AddWithValue("@inv", Convert.ToInt32(textBox1.Text));
                insert_def.Parameters.AddWithValue("@PN", dataGridView3.Rows[i].Cells[0].Value);
                insert_def.Parameters.AddWithValue("@PT", dataGridView3.Rows[i].Cells[1].Value);
                insert_def.Parameters.AddWithValue("@Quan", dataGridView3.Rows[i].Cells[3].Value);
                con.Open();
                insert_def.ExecuteNonQuery();
                con.Close();
            }
            Update_all();
            MessageBox.Show("settlement Over Part Done", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            stores.Update(stores_table);
            Update_all();
        }


        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = dataGridView1.Columns[e.ColumnIndex] as DataGridViewColumn;

            if (col.Name == "Deficit_Quantity")
            {
                DataGridViewTextBoxCell cell = dataGridView1[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell != null)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false)
                        {
                            MessageBox.Show("You have to enter number only");
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            new_num();
            Deficit();
            data_inventory(Convert.ToInt32(textBox1.Text));
            databind();
            Part_not_stock(Convert.ToInt32(textBox1.Text));
            over_part();
            Stores_settlement();
            dateTimePicker1.Value = DateTime.Today;
        }

        private void Dec_Inventory_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (GridRow == 0)
            {
                e.Graphics.DrawString("Inventory", new Font("Georgia", 20, FontStyle.Underline), Brushes.Black, new Point(350, 30));
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, 73), new Point(e.PageSettings.PaperSize.Width - 10, 73));
            e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(60, 75));
            e.Graphics.DrawLine(Pens.Black, new Point(10, 95), new Point(e.PageSettings.PaperSize.Width - 10, 95));
            e.Graphics.DrawString("part Type", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(370, 75));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, 75));
            int hight = 110;
            while (GridRow < dataGridView1.Rows.Count - 1)
            {
                if (hight < e.PageSettings.PrintableArea.Height)
                {
                    if (dataGridView1.Rows[GridRow].Cells[0].Value != null && dataGridView1.Rows[GridRow].Cells[1].Value != null && dataGridView1.Rows[GridRow].Cells[2].Value != null)
                    {
                        e.Graphics.DrawString((GridRow + 1).ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(10, hight));
                        e.Graphics.DrawString(dataGridView1.Rows[GridRow].Cells[0].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(70, hight));
                        e.Graphics.DrawString(dataGridView1.Rows[GridRow].Cells[1].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(380, hight));
                        e.Graphics.DrawString(dataGridView1.Rows[GridRow].Cells[2].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(710, hight));
                    }
                    else
                    {
                        continue;
                    }
                    hight += 30;
                    GridRow += 1;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(15, 990), new Point(785, 990));
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, hight), new Point(e.PageSettings.PaperSize.Width - 10, hight));
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(),"Formatting Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            all_inventory play = new all_inventory();
            play.ShowDialog(this);
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Search_Part_open(dataGridView4);
        }
        // Search Part 
        private void Search_Part_open(DataGridView Grid)
        {
                search_Part play = new search_Part();
                play.TextBox1.Text = Grid.CurrentRow.Cells[0].Value.ToString();
                SqlCommand type = new SqlCommand("get_Part_Storte", con);
                type.CommandType = CommandType.StoredProcedure;
                type.Parameters.AddWithValue("@PN", Grid.CurrentRow.Cells[0].Value.ToString());
                DataTable type_t = new DataTable();
                SqlDataAdapter type_ad = new SqlDataAdapter();
                type_ad.SelectCommand = type;
                type_ad.Fill(type_t);
                play.ComboBox1.DataSource = type_t;
                play.ComboBox1.DisplayMember = "PartType";
                play.ComboBox1.ValueMember = "PartType";
                play.ComboBox1.SelectedValue = Grid.CurrentRow.Cells[1].Value.ToString();
                play.ShowDialog(this);
                System.Media.SystemSounds.Exclamation.Play();
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Search_Part_open(dataGridView2);
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Search_Part_open(dataGridView3);
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Search_Part_open(dataGridView5);
        }

        private void Dec_Deficit_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (GridRow == 0)
            {
                e.Graphics.DrawString("Deficit Parts", new Font("Georgia", 20, FontStyle.Italic), Brushes.Black, new Point(350, 30));
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, 63), new Point(e.PageSettings.PaperSize.Width - 10, 63));
            e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 65));
            e.Graphics.DrawLine(Pens.Black, new Point(10, 85), new Point(e.PageSettings.PaperSize.Width - 10, 85));
            e.Graphics.DrawString("part Type", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(160, 65));
            e.Graphics.DrawString("Location", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(310, 65));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(460, 65));
            e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(610, 65));
            e.Graphics.DrawString("Min Quan", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(760, 65));
            int hight = 100;
            while (GridRow < dataGridView2.Rows.Count)
            {
                if (hight < e.PageSettings.PrintableArea.Height)
                {
                    e.Graphics.DrawString((GridRow + 1).ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(10, hight));
                    e.Graphics.DrawString(dataGridView2.Rows[GridRow].Cells[0].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(40, hight));
                    e.Graphics.DrawString(dataGridView2.Rows[GridRow].Cells[1].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(170, hight));
                    e.Graphics.DrawString(dataGridView2.Rows[GridRow].Cells[2].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(320, hight));
                    e.Graphics.DrawString(dataGridView2.Rows[GridRow].Cells[3].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(470, hight));
                    e.Graphics.DrawString(dataGridView2.Rows[GridRow].Cells[4].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(620, hight));
                    e.Graphics.DrawString(dataGridView2.Rows[GridRow].Cells[5].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(770, hight));
                    GridRow += 1;
                    hight += 30;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(15, 990), new Point(785, 990));
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, hight), new Point(e.PageSettings.PaperSize.Width - 10, hight));

        }
        private void printDeficitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridRow = 0;
            printDialog1.Document = Dec_Deficit;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                Dec_Deficit.Print();
            }

        }

        private void Dec_Over_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (GridRow == 0)
            {
                e.Graphics.DrawString("Over Parts", new Font("Georgia", 20, FontStyle.Italic), Brushes.Black, new Point(350, 30));
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, 63), new Point(e.PageSettings.PaperSize.Width - 10, 63));
            e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 65));
            e.Graphics.DrawLine(Pens.Black, new Point(10, 85), new Point(e.PageSettings.PaperSize.Width - 10, 85));
            e.Graphics.DrawString("part Type", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(160, 65));
            e.Graphics.DrawString("Location", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(310, 65));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(460, 65));
            e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(610, 65));
            e.Graphics.DrawString("Min Quan", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(760, 65));
            int hight = 100;
            while (GridRow < dataGridView3.Rows.Count)
            {
                if (hight < e.PageSettings.PrintableArea.Height)
                {
                    e.Graphics.DrawString((GridRow + 1).ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(10, hight));
                    e.Graphics.DrawString(dataGridView3.Rows[GridRow].Cells[0].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(40, hight));
                    e.Graphics.DrawString(dataGridView3.Rows[GridRow].Cells[1].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(170, hight));
                    e.Graphics.DrawString(dataGridView3.Rows[GridRow].Cells[2].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(320, hight));
                    e.Graphics.DrawString(dataGridView3.Rows[GridRow].Cells[3].Value.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(470, hight));
                    e.Graphics.DrawString(dataGridView3.Rows[GridRow].Cells[4].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(620, hight));
                    e.Graphics.DrawString(dataGridView3.Rows[GridRow].Cells[5].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(770, hight));
                    GridRow += 1;
                    hight += 30;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(15, 990), new Point(785, 990));
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, hight), new Point(e.PageSettings.PaperSize.Width - 10,hight));

        }

        private void printOverPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridRow = 0;
            printDialog1.Document = Dec_Over;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                Dec_Over.Print();
            }

        }

        private void printPartNotStokingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridRow = 0;
            printDialog1.Document =Dec_notStock;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                Dec_notStock.Print();
            }
        }

        private void Dec_notStock_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (GridRow == 0)
            {
                e.Graphics.DrawString("Not Stock Parts", new Font("Georgia", 20, FontStyle.Italic), Brushes.Black, new Point(350, 30));
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, 63), new Point(e.PageSettings.PaperSize.Width - 10, 63));
            e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 65));
            e.Graphics.DrawLine(Pens.Black, new Point(10, 85), new Point(e.PageSettings.PaperSize.Width - 10, 85));
            e.Graphics.DrawString("part Type", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(160, 65));
            e.Graphics.DrawString("Location", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(310, 65));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(460, 65));
            e.Graphics.DrawString("Discription", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(610, 65));
            e.Graphics.DrawString("Min Quan", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(760, 65));
            int hight = 100;
            while (GridRow < dataGridView4.Rows.Count)
            {
                if (hight < e.PageSettings.PrintableArea.Height-40)
                {
                    e.Graphics.DrawString((GridRow + 1).ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(10, hight));
                    e.Graphics.DrawString(dataGridView4.Rows[GridRow].Cells[0].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(40, hight));
                    e.Graphics.DrawString(dataGridView4.Rows[GridRow].Cells[1].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(170, hight));
                    e.Graphics.DrawString(dataGridView4.Rows[GridRow].Cells[2].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(320, hight));
                    e.Graphics.DrawString(dataGridView4.Rows[GridRow].Cells[3].Value.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(470, hight));
                    e.Graphics.DrawString(dataGridView4.Rows[GridRow].Cells[4].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(620, hight));
                    e.Graphics.DrawString(dataGridView4.Rows[GridRow].Cells[5].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(770, hight));
                    GridRow += 1;
                    hight += 30;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(10, hight), new Point(e.PageSettings.PaperSize.Width-10, hight));
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, hight), new Point(e.PageSettings.PaperSize.Width - 10, hight));
        }

        private void printInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridRow = 0;
            printDialog1.Document = Dec_Inventory;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                Dec_Inventory.Print();
            }

        }

        private void Dec_settlement_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (GridRow == 0)
            {
                string sett = "Settlement Parts";
                e.Graphics.DrawString(sett, new Font("Georgia", 20, FontStyle.Underline), Brushes.Black, new Point((e.PageSettings.PaperSize.Width/2), 30));
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, 73), new Point(e.PageSettings.PaperSize.Width - 10, 73));
            e.Graphics.DrawString("Part Number", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(60, 75));
            e.Graphics.DrawLine(Pens.Black, new Point(10, 95), new Point(e.PageSettings.PaperSize.Width - 10, 95));
            e.Graphics.DrawString("part Type", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(370, 75));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, 75));
            int hight = 110;
            while (GridRow < dataGridView5.Rows.Count)
            {
                if (hight < e.PageSettings.PrintableArea.Height)
                {
                    if (dataGridView5.Rows[GridRow].Cells[0].Value != null && dataGridView5.Rows[GridRow].Cells[1].Value != null && dataGridView5.Rows[GridRow].Cells[2].Value != null)
                    {
                        e.Graphics.DrawString((GridRow + 1).ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(10, hight));
                        e.Graphics.DrawString(dataGridView5.Rows[GridRow].Cells[0].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(70, hight));
                        e.Graphics.DrawString(dataGridView5.Rows[GridRow].Cells[1].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(380, hight));
                        e.Graphics.DrawString(dataGridView5.Rows[GridRow].Cells[2].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(710, hight));
                    }
                    else
                    {
                        continue;
                    }
                    hight += 30;
                    GridRow += 1;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(15, 990), new Point(785, 990));
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawLine(Pens.Black, new Point(10, hight), new Point(e.PageSettings.PaperSize.Width - 10, hight));

        }

        private void settleentPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridRow = 0;
            printPreviewDialog1.Document = Dec_settlement;
            printPreviewDialog1.ShowDialog();
        }

        private void deficitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = Dec_Deficit;
            printPreviewDialog1.ShowDialog();
            GridRow = 0;
        }

        private void priToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = Dec_notStock;
            printPreviewDialog1.ShowDialog();
            GridRow = 0;

        }

        private void overPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = Dec_Over;
            printPreviewDialog1.ShowDialog();
            GridRow = 0;

        }

        private void partNotStockingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = Dec_Inventory;
            printPreviewDialog1.ShowDialog();
            GridRow = 0;

        }

        private void printSettlementPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridRow = 0;
            printDialog1.Document = Dec_settlement;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                Dec_settlement.Print();
            }

        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {

        }
        
    }
}
