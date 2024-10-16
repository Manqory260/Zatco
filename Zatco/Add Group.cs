using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Zatco
{
    public partial class Add_Group : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);

        public Add_Group()
        {
            InitializeComponent();
        }

        public void All_Part(string num)
        {
            SqlCommand part = new SqlCommand("Group_part", con);
            part.CommandType = CommandType.StoredProcedure;
            part.Parameters.AddWithValue("@PN", num);
            SqlDataAdapter adapt = new SqlDataAdapter(part);
            DataTable table = new DataTable();
            adapt.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = table.Rows[i][0].ToString();
                row.Cells[1].Value = table.Rows[i][1].ToString();
                row.Cells[2].Value = table.Rows[i][4].ToString();
                row.Cells[3].Value = table.Rows[i][3].ToString();
                row.Cells[4].Value = table.Rows[i][4].ToString();
                dataGridView1.Rows.Add(row);

            }
        }
        public void part(string Num, string Type)
        {
            SqlCommand part = new SqlCommand("part_storge", con);
            part.CommandType = CommandType.StoredProcedure;
            part.Parameters.AddWithValue("@PN", Num);
            part.Parameters.AddWithValue("@PT", Type);
            SqlDataAdapter adapt = new SqlDataAdapter(part);
            DataTable table = new DataTable();
            adapt.Fill(table);
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = table.Rows[0][0].ToString();
            row.Cells[1].Value = table.Rows[0][1].ToString();
            row.Cells[2].Value = table.Rows[0][4].ToString();
            row.Cells[3].Value = table.Rows[0][3].ToString();
            row.Cells[4].Value = table.Rows[0][4].ToString();
            dataGridView1.Rows.Add(row);

        }

        private void Add_Group_Load(object sender, EventArgs e)
        {
            SqlCommand inv_com = new SqlCommand("models_select", con);
            inv_com.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader read = inv_com.ExecuteReader();
            while (read.Read())
            {
                ListViewItem lvl = new ListViewItem(read["Id"].ToString());
                lvl.SubItems.Add(read["Display"].ToString());
                listView1.Items.Add(lvl);
            }
            con.Close();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.CheckBoxes = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (search_Part AddPart = new search_Part())
            {
                AddPart.Lable_12 = true;
                AddPart.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool part_Check = true;
            for (int x= 0; x < dataGridView1.Rows.Count - 1; x++)
            {
                SqlCommand part = new SqlCommand("get_part", con);
                part.CommandType = CommandType.StoredProcedure;
                part.Parameters.AddWithValue("@PT", dataGridView1.Rows[x].Cells[1].Value.ToString());
                part.Parameters.AddWithValue("@PN", dataGridView1.Rows[x].Cells[0].Value.ToString());
                con.Open();
                string partS = part.ExecuteScalar().ToString();
                con.Close();
                switch (partS)
                {
                    case "Not in":
                        MessageBox.Show("Part Num " + dataGridView1.Rows[x].Cells[0].Value.ToString() + " Type " + dataGridView1.Rows[x].Cells[1].Value.ToString() + " " + dataGridView1.Rows[x].Cells[2].Value.ToString() + " we don't have it and not added", "Part Number not have", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        dataGridView1.Rows.RemoveAt(x);
                        break;
                }
            }
                if (textBox1.Text != "" && textBox2.Text != "" && dataGridView1.Rows.Count != 0 && part_Check)
                {
                    SqlCommand Group = new SqlCommand("Group_add", con);
                    Group.CommandType = CommandType.StoredProcedure;
                    Group.Parameters.AddWithValue("@GN", textBox1.Text);
                    Group.Parameters.AddWithValue("@GD", textBox2.Text);
                    con.Open();
                    string res = Group.ExecuteScalar().ToString();
                    con.Close();

                    if (res == "suc")
                    {
                        SqlCommand ID_com = new SqlCommand("Group_ID", con);
                        ID_com.CommandType = CommandType.StoredProcedure;
                        ID_com.Parameters.AddWithValue("@GN", textBox1.Text);
                        con.Open();
                        int ID = Convert.ToInt32(ID_com.ExecuteScalar());
                        con.Close();
                        for (int i = 0; i <= listView1.Items.Count - 1; i++)
                        {
                            if (listView1.Items[i].Checked == true)
                            {
                                SqlCommand GP_MO = new SqlCommand("Group_Model", con);
                                GP_MO.CommandType = CommandType.StoredProcedure;
                                GP_MO.Parameters.AddWithValue("@GID", ID);
                                GP_MO.Parameters.AddWithValue("@Mo", Convert.ToInt32(listView1.Items[i].SubItems[0].Text));
                                con.Open();
                                GP_MO.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            SqlCommand PG = new SqlCommand("Part_Group", con);
                            PG.CommandType = CommandType.StoredProcedure;
                            PG.Parameters.AddWithValue("@GID", ID);
                            PG.Parameters.AddWithValue("@PN", dataGridView1.Rows[i].Cells[0].Value);
                            PG.Parameters.AddWithValue("@PT", dataGridView1.Rows[i].Cells[1].Value);
                            con.Open();
                            PG.ExecuteNonQuery();
                            con.Close();
                        }
                        MessageBox.Show("Group has been added successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Group name is already used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Please enter the group name and description and Partnumber", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string ss = DBNull.Value.ToString();
                    string a = Convert.ToString(selectedRow.Cells["Part_Number"].Value);
                    if (dataGridView1.CurrentRow.Cells[1].Value != null)
                    {
                        ss = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    }
                    SqlCommand type = new SqlCommand("get_Part_Storte", con);
                    type.CommandType = CommandType.StoredProcedure;
                    type.Parameters.AddWithValue("@PN", a);
                    SqlDataAdapter ad = new SqlDataAdapter(type);
                    DataTable data = new DataTable();
                    ad.Fill(data);
                    DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                    cell.DataSource = data;
                    cell.DisplayMember = data.Columns["PartType"].ToString();
                    cell.ValueMember = data.Columns["PartType"].ToString();
                    cell.FlatStyle = FlatStyle.Flat;
                    dataGridView1.CurrentRow.Cells[2].Value = data.Rows[0]["Discription"].ToString();
                    dataGridView1[1, dataGridView1.CurrentCell.RowIndex] = cell;
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = ss;
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                if (dataGridView1.CurrentRow.Cells[0].Value != null && dataGridView1.CurrentRow.Cells[1].Value != null)
                {
                    SqlCommand quan = new SqlCommand("store_Part_type", con);
                    quan.CommandType = CommandType.StoredProcedure;
                    quan.Parameters.AddWithValue("@PN", dataGridView1.CurrentRow.Cells[0].Value);
                    quan.Parameters.AddWithValue("@PT", dataGridView1.CurrentRow.Cells[1].Value);
                    DataTable data = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(quan);
                    adp.Fill(data);
                    if (data.Rows.Count != 0)
                    {
                        dataGridView1.CurrentRow.Cells[3].Value = data.Rows[0]["Quantity"].ToString();
                        dataGridView1.CurrentRow.Cells[4].Value = data.Rows[0]["Price"].ToString();
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells[3].Value = 0;
                        dataGridView1.CurrentRow.Cells[4].Value = 0;

                    }
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[3].Value = 0;
                    dataGridView1.CurrentRow.Cells[4].Value = 0;

                }
               
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = dataGridView1.Columns[e.ColumnIndex] as DataGridViewColumn;

            if (col.Name == "Quantity")
            {
                DataGridViewTextBoxCell cell = dataGridView1[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell != null)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false)
                        {
                            MessageBox.Show("You have to enter digits only");
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
            if (col.Name == "Price")
            {
                DataGridViewTextBoxCell cell = dataGridView1[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell != null)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false && c != '.')
                        {
                            MessageBox.Show("You have to enter digits only");
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
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
    }
}
