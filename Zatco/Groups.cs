using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Zatco
{
    public partial class Groups : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ZatcoDBConnectionString);
        DataTable data = new DataTable();
        public Groups()
        {
            InitializeComponent();
        }
        public bool CheckBox_1
        {
            set { checkBox1.Visible = value; }
            get { return checkBox1.Visible; }
        }

        public bool Button_1
        {
            set { button3.Visible = value; }
            get { return button3.Visible; }
        }
        public bool listView_1
        {
            set { listView1.Enabled = value; }
            get { return listView1.Enabled; }
        }
        private void Groups_Load(object sender, EventArgs e)
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

            SqlCommand Grop_com = new SqlCommand("groups_select", con);
            Grop_com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter gad = new SqlDataAdapter(Grop_com);
            gad.Fill(data);
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][0].Equals(comboBox1.SelectedValue))
                {
                    textBox2.Text = data.Rows[i][2].ToString();
                    textBox1.Text = data.Rows[i][1].ToString();
                }
            }
            for (int f = 0; f < listView1.Items.Count; f++)
            {
                listView1.Items[f].Checked = false;
            }
            SqlCommand model = new SqlCommand("select_model_grop", con);
            model.CommandType = CommandType.StoredProcedure;
            model.Parameters.AddWithValue("@GID", comboBox1.SelectedValue);
            SqlDataAdapter dapt = new SqlDataAdapter(model);
            DataTable table = new DataTable();
            dapt.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int x = 0; x < listView1.Items.Count; x++)
                {
                    if (table.Rows[i][0].Equals(Convert.ToInt32(listView1.Items[x].SubItems[0].Text)))
                    {
                        listView1.Items[x].Checked = true;
                    }
                }
            }
            SqlCommand select_part = new SqlCommand("Select_Gp_Part", con);
            select_part.CommandType = CommandType.StoredProcedure;
            select_part.Parameters.AddWithValue("@GID", comboBox1.SelectedValue);
            SqlDataAdapter adpar = new SqlDataAdapter(select_part);
            DataTable ta = new DataTable();
            ta.Clear();
            dataGridView1.Rows.Clear();
            adpar.Fill(ta);
            for (int i = 0; i < ta.Rows.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                for (int f = 0; f < ta.Columns.Count; f++)
                {
                    row.Cells[f].Value = ta.Rows[i][f].ToString();
                }
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool part_Check = true;
            for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
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
                SqlCommand Group = new SqlCommand("Group_Update", con);
                Group.CommandType = CommandType.StoredProcedure;
                Group.Parameters.AddWithValue("@GN", textBox1.Text);
                Group.Parameters.AddWithValue("@Dis", textBox2.Text);
                Group.Parameters.AddWithValue("@GID", comboBox1.SelectedValue);
                con.Open();
                Group.ExecuteNonQuery();
                con.Close();
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    SqlCommand GP_MO = new SqlCommand("model_group_DR", con);
                    GP_MO.CommandType = CommandType.StoredProcedure;
                    GP_MO.Parameters.AddWithValue("@GID", comboBox1.SelectedValue);
                    GP_MO.Parameters.AddWithValue("@Mo", Convert.ToInt32(listView1.Items[i].SubItems[0].Text));
                    if (listView1.Items[i].Checked == true)
                    {
                        GP_MO.Parameters.AddWithValue("@ch", 1);
                    }
                    else { GP_MO.Parameters.AddWithValue("@ch", 2); }
                    con.Open();
                    GP_MO.ExecuteNonQuery();
                    con.Close();

                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlCommand PG = new SqlCommand("Part_Group", con);
                    PG.CommandType = CommandType.StoredProcedure;
                    PG.Parameters.AddWithValue("@GID", comboBox1.SelectedValue);
                    PG.Parameters.AddWithValue("@PN", dataGridView1.Rows[i].Cells[0].Value);
                    PG.Parameters.AddWithValue("@PT", dataGridView1.Rows[i].Cells[1].Value);
                    con.Open();
                    PG.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Group has been added successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("Please enter the group name and description and Partnumber", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (search_Part AddPart = new search_Part())
            {
                AddPart.Lable_12 = true;
                AddPart.ShowDialog(this);
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Visible = true;
                button2.Visible = true;
                button1.Visible = true;
            }
            else if (checkBox1.Checked == false)
            {
                textBox1.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Owner.Name == "new_inv")
            {
                //new_inv add = (new_inv)this.Owner;
                //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                //{
                //    add.Add_part(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                //}
            }
            else if (Owner.Name == "Receiving_permission")
            {
                //Receiving_permission add = (Receiving_permission)this.Owner;
                //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                //{
                //    add.Add_part(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                //}

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
    }
}
