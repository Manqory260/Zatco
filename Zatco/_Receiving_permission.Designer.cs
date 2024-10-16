using System.Drawing;

namespace Zatco
{
    partial class Receiving_permission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receiving_permission));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._engine_combo = new System.Windows.Forms.ComboBox();
            this._boat_combo = new System.Windows.Forms.ComboBox();
            this._company_combo = new System.Windows.Forms.ComboBox();
            this._Tital_label = new System.Windows.Forms.Label();
            this._total_text = new System.Windows.Forms.TextBox();
            this._total_label = new System.Windows.Forms.Label();
            this._INV_NUM_Text = new System.Windows.Forms.TextBox();
            this._date_picker = new System.Windows.Forms.DateTimePicker();
            this.INV_PrintPReview = new System.Windows.Forms.PrintPreviewDialog();
            this._data_grid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.oPenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copy_selected_row_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cop_all_rowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.INV_Docment = new System.Drawing.Printing.PrintDocument();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveAsEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this._Boat_pictureBox = new System.Windows.Forms.PictureBox();
            this._Engine_pictureBox = new System.Windows.Forms.PictureBox();
            this._Company_pictureBox = new System.Windows.Forms.PictureBox();
            this._engine_label = new System.Windows.Forms.Label();
            this._boat_label = new System.Windows.Forms.Label();
            this._company_label = new System.Windows.Forms.Label();
            this._date_label = new System.Windows.Forms.Label();
            this.part_TaxesTableAdapter = new Zatco.ZatcoDBDataSet1TableAdapters.Part_TaxesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._data_grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Boat_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Engine_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Company_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _engine_combo
            // 
            this._engine_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._engine_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._engine_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._engine_combo.BackColor = System.Drawing.SystemColors.Info;
            this._engine_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._engine_combo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._engine_combo.Font = new System.Drawing.Font("Tahoma", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._engine_combo.FormattingEnabled = true;
            this._engine_combo.Location = new System.Drawing.Point(609, 109);
            this._engine_combo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._engine_combo.Name = "_engine_combo";
            this._engine_combo.Size = new System.Drawing.Size(197, 27);
            this._engine_combo.TabIndex = 30;
            // 
            // _boat_combo
            // 
            this._boat_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._boat_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._boat_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._boat_combo.BackColor = System.Drawing.SystemColors.Info;
            this._boat_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._boat_combo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._boat_combo.Font = new System.Drawing.Font("Tahoma", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._boat_combo.FormattingEnabled = true;
            this._boat_combo.Location = new System.Drawing.Point(609, 79);
            this._boat_combo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._boat_combo.Name = "_boat_combo";
            this._boat_combo.Size = new System.Drawing.Size(197, 27);
            this._boat_combo.TabIndex = 29;
            this._boat_combo.SelectedIndexChanged += new System.EventHandler(this._boat_combo_SelectedIndexChanged);
            // 
            // _company_combo
            // 
            this._company_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._company_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._company_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._company_combo.BackColor = System.Drawing.SystemColors.Info;
            this._company_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._company_combo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._company_combo.Font = new System.Drawing.Font("Tahoma", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._company_combo.FormattingEnabled = true;
            this._company_combo.Location = new System.Drawing.Point(609, 49);
            this._company_combo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._company_combo.Name = "_company_combo";
            this._company_combo.Size = new System.Drawing.Size(197, 27);
            this._company_combo.TabIndex = 28;
            this._company_combo.SelectedIndexChanged += new System.EventHandler(this._company_combo_SelectedIndexChanged);
            // 
            // _Tital_label
            // 
            this._Tital_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._Tital_label.AutoSize = true;
            this._Tital_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Tital_label.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tital_label.Location = new System.Drawing.Point(242, 12);
            this._Tital_label.Name = "_Tital_label";
            this._Tital_label.Size = new System.Drawing.Size(304, 34);
            this._Tital_label.TabIndex = 8;
            this._Tital_label.Text = "Receiving Permission";
            // 
            // _total_text
            // 
            this._total_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._total_text.BackColor = System.Drawing.Color.White;
            this._total_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._total_text.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._total_text.ForeColor = System.Drawing.Color.Maroon;
            this._total_text.Location = new System.Drawing.Point(97, 730);
            this._total_text.Name = "_total_text";
            this._total_text.Size = new System.Drawing.Size(99, 23);
            this._total_text.TabIndex = 18;
            this._total_text.Text = "0";
            // 
            // _total_label
            // 
            this._total_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._total_label.AutoSize = true;
            this._total_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._total_label.ForeColor = System.Drawing.Color.Black;
            this._total_label.Location = new System.Drawing.Point(7, 727);
            this._total_label.Name = "_total_label";
            this._total_label.Size = new System.Drawing.Size(58, 25);
            this._total_label.TabIndex = 14;
            this._total_label.Text = "Total";
            // 
            // _INV_NUM_Text
            // 
            this._INV_NUM_Text.BackColor = System.Drawing.Color.Silver;
            this._INV_NUM_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._INV_NUM_Text.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._INV_NUM_Text.ForeColor = System.Drawing.Color.Black;
            this._INV_NUM_Text.Location = new System.Drawing.Point(68, 21);
            this._INV_NUM_Text.Name = "_INV_NUM_Text";
            this._INV_NUM_Text.Size = new System.Drawing.Size(93, 25);
            this._INV_NUM_Text.TabIndex = 0;
            this._INV_NUM_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this._INV_NUM_Text_KeyDown);
            this._INV_NUM_Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._INV_NUM_Text_KeyPress);
            this._INV_NUM_Text.Leave += new System.EventHandler(this._INV_NUM_Text_Leave);
            // 
            // _date_picker
            // 
            this._date_picker.CustomFormat = "dd/MM/yyyy";
            this._date_picker.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._date_picker.Location = new System.Drawing.Point(40, 56);
            this._date_picker.Name = "_date_picker";
            this._date_picker.Size = new System.Drawing.Size(183, 26);
            this._date_picker.TabIndex = 0;
            // 
            // INV_PrintPReview
            // 
            this.INV_PrintPReview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.INV_PrintPReview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.INV_PrintPReview.ClientSize = new System.Drawing.Size(400, 300);
            this.INV_PrintPReview.Enabled = true;
            this.INV_PrintPReview.Icon = ((System.Drawing.Icon)(resources.GetObject("INV_PrintPReview.Icon")));
            this.INV_PrintPReview.Name = "printPreviewDialog1";
            this.INV_PrintPReview.ShowIcon = false;
            this.INV_PrintPReview.Visible = false;
            // 
            // _data_grid
            // 
            this._data_grid.AllowDrop = true;
            this._data_grid.AllowUserToOrderColumns = true;
            this._data_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._data_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._data_grid.BackgroundColor = System.Drawing.SystemColors.Info;
            this._data_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._data_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._data_grid.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._data_grid.DefaultCellStyle = dataGridViewCellStyle2;
            this._data_grid.GridColor = System.Drawing.Color.AntiqueWhite;
            this._data_grid.Location = new System.Drawing.Point(3, 138);
            this._data_grid.Name = "_data_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._data_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._data_grid.RowHeadersWidth = 20;
            this._data_grid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._data_grid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this._data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._data_grid.ShowCellToolTips = false;
            this._data_grid.Size = new System.Drawing.Size(815, 586);
            this._data_grid.TabIndex = 4;
            this._data_grid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Data_grid_CellMouseDown);
            this._data_grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this._data_grid_CellValidating);
            this._data_grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this._data_grid_DataError);
            this._data_grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Data_grid_EditingControlShowing);
            this._data_grid.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this._data_grid_RowLeave);
            this._data_grid.SelectionChanged += new System.EventHandler(this._data_grid_SelectionChanged);
            this._data_grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_grid_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPenToolStripMenuItem,
            this.copy_selected_row_ToolStripMenuItem,
            this.cop_all_rowToolStripMenuItem,
            this.pastToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 134);
            // 
            // oPenToolStripMenuItem
            // 
            this.oPenToolStripMenuItem.Image = global::Zatco.Properties.Resources.search32;
            this.oPenToolStripMenuItem.Name = "oPenToolStripMenuItem";
            this.oPenToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.oPenToolStripMenuItem.Text = "Search In Parts";
            this.oPenToolStripMenuItem.Click += new System.EventHandler(this.OPenToolStripMenuItem_Click);
            // 
            // copy_selected_row_ToolStripMenuItem
            // 
            this.copy_selected_row_ToolStripMenuItem.Image = global::Zatco.Properties.Resources.copy;
            this.copy_selected_row_ToolStripMenuItem.Name = "copy_selected_row_ToolStripMenuItem";
            this.copy_selected_row_ToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.copy_selected_row_ToolStripMenuItem.Text = "Copy Selected Row";
            this.copy_selected_row_ToolStripMenuItem.Click += new System.EventHandler(this.Copy_selected_row_ToolStripMenuItem_Click);
            // 
            // cop_all_rowToolStripMenuItem
            // 
            this.cop_all_rowToolStripMenuItem.Image = global::Zatco.Properties.Resources.copyall;
            this.cop_all_rowToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.cop_all_rowToolStripMenuItem.Name = "cop_all_rowToolStripMenuItem";
            this.cop_all_rowToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cop_all_rowToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.cop_all_rowToolStripMenuItem.Text = "Copy ";
            this.cop_all_rowToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripButton_Click);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Image = global::Zatco.Properties.Resources.Past;
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.pastToolStripMenuItem.Text = "Past";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Zatco.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // INV_Docment
            // 
            this.INV_Docment.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.INV_Docment_PrintPage);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Silver;
            this.toolStripContainer1.ContentPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Boat_pictureBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Engine_pictureBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Company_pictureBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._engine_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._boat_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._company_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Tital_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._total_text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._total_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._data_grid);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._INV_NUM_Text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._date_picker);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._engine_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._boat_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._company_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._date_label);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(818, 768);
            this.toolStripContainer1.ContentPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripContainer1_ContentPanel_MouseDown);
            this.toolStripContainer1.ContentPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripContainer1_ContentPanel_MouseMove);
            this.toolStripContainer1.ContentPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripContainer1_ContentPanel_MouseUp);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(818, 793);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.PaleGreen;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Zatco.Properties.Resources.minimize1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(751, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 39;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.helpToolStripButton,
            this.toolStripSeparator,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.cutToolStripButton,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 109);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(282, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Checked = true;
            this.newToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Edit";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::Zatco.Properties.Resources.save31;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.helpToolStripButton.Text = "Print Preview";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.CopyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.PasteToolStripButton_Click);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cutToolStripButton.Text = "Delete this invoice";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsEToolStripMenuItem,
            this.openExcelToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(33, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // saveAsEToolStripMenuItem
            // 
            this.saveAsEToolStripMenuItem.Image = global::Zatco.Properties.Resources.save31;
            this.saveAsEToolStripMenuItem.Name = "saveAsEToolStripMenuItem";
            this.saveAsEToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.saveAsEToolStripMenuItem.Text = "Save As Excel";
            this.saveAsEToolStripMenuItem.Click += new System.EventHandler(this.SaveAsEToolStripMenuItem_Click);
            // 
            // openExcelToolStripMenuItem
            // 
            this.openExcelToolStripMenuItem.Image = global::Zatco.Properties.Resources.excel_xls_icon__1_;
            this.openExcelToolStripMenuItem.Name = "openExcelToolStripMenuItem";
            this.openExcelToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openExcelToolStripMenuItem.Text = "Open Excel";
            this.openExcelToolStripMenuItem.Click += new System.EventHandler(this.OpenExcelToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Zatco.Properties.Resources.close;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(782, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 38;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _Boat_pictureBox
            // 
            this._Boat_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Boat_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Boat_pictureBox.Image = global::Zatco.Properties.Resources.plus_sign5;
            this._Boat_pictureBox.Location = new System.Drawing.Point(490, 85);
            this._Boat_pictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Boat_pictureBox.Name = "_Boat_pictureBox";
            this._Boat_pictureBox.Size = new System.Drawing.Size(16, 16);
            this._Boat_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._Boat_pictureBox.TabIndex = 32;
            this._Boat_pictureBox.TabStop = false;
            this._Boat_pictureBox.Click += new System.EventHandler(this._Boat_pictureBox_Click);
            // 
            // _Engine_pictureBox
            // 
            this._Engine_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Engine_pictureBox.BackColor = System.Drawing.Color.Silver;
            this._Engine_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Engine_pictureBox.Image = global::Zatco.Properties.Resources.plus_sign5;
            this._Engine_pictureBox.Location = new System.Drawing.Point(490, 113);
            this._Engine_pictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Engine_pictureBox.Name = "_Engine_pictureBox";
            this._Engine_pictureBox.Size = new System.Drawing.Size(16, 16);
            this._Engine_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._Engine_pictureBox.TabIndex = 31;
            this._Engine_pictureBox.TabStop = false;
            this._Engine_pictureBox.Click += new System.EventHandler(this.Engine_pictureBox_Click);
            // 
            // _Company_pictureBox
            // 
            this._Company_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Company_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Company_pictureBox.Image = global::Zatco.Properties.Resources.plus_sign5;
            this._Company_pictureBox.Location = new System.Drawing.Point(490, 56);
            this._Company_pictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Company_pictureBox.Name = "_Company_pictureBox";
            this._Company_pictureBox.Size = new System.Drawing.Size(16, 16);
            this._Company_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._Company_pictureBox.TabIndex = 3;
            this._Company_pictureBox.TabStop = false;
            this._Company_pictureBox.Click += new System.EventHandler(this._Company_pictureBox_Click);
            // 
            // _engine_label
            // 
            this._engine_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._engine_label.AutoSize = true;
            this._engine_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._engine_label.Location = new System.Drawing.Point(512, 115);
            this._engine_label.Name = "_engine_label";
            this._engine_label.Size = new System.Drawing.Size(65, 16);
            this._engine_label.TabIndex = 13;
            this._engine_label.Text = "Engine SN";
            // 
            // _boat_label
            // 
            this._boat_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._boat_label.AutoSize = true;
            this._boat_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._boat_label.Location = new System.Drawing.Point(512, 85);
            this._boat_label.Name = "_boat_label";
            this._boat_label.Size = new System.Drawing.Size(69, 16);
            this._boat_label.TabIndex = 12;
            this._boat_label.Text = "Boat Name";
            // 
            // _company_label
            // 
            this._company_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._company_label.AutoSize = true;
            this._company_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._company_label.Location = new System.Drawing.Point(508, 55);
            this._company_label.Name = "_company_label";
            this._company_label.Size = new System.Drawing.Size(97, 16);
            this._company_label.TabIndex = 11;
            this._company_label.Text = "Company Name";
            // 
            // _date_label
            // 
            this._date_label.AutoSize = true;
            this._date_label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._date_label.ForeColor = System.Drawing.Color.Red;
            this._date_label.Location = new System.Drawing.Point(34, 74);
            this._date_label.Name = "_date_label";
            this._date_label.Size = new System.Drawing.Size(0, 18);
            this._date_label.TabIndex = 9;
            // 
            // part_TaxesTableAdapter
            // 
            this.part_TaxesTableAdapter.ClearBeforeFill = true;
            // 
            // Receiving_permission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 793);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.MaximizeBox = false;
            this.Name = "Receiving_permission";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Receiving Permission";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Load += new System.EventHandler(this._Receiving_permission_Load);
            ((System.ComponentModel.ISupportInitialize)(this._data_grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Boat_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Engine_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Company_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox _engine_combo;
        private System.Windows.Forms.ComboBox _boat_combo;
        private System.Windows.Forms.ComboBox _company_combo;
        private System.Windows.Forms.Label _Tital_label;
        private System.Windows.Forms.TextBox _total_text;
        private System.Windows.Forms.Label _total_label;
        private System.Windows.Forms.TextBox _INV_NUM_Text;
        private System.Windows.Forms.DateTimePicker _date_picker;
        private System.Windows.Forms.PrintPreviewDialog INV_PrintPReview;
        private System.Windows.Forms.DataGridView _data_grid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copy_selected_row_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cop_all_rowToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument INV_Docment;
        private ZatcoDBDataSet1TableAdapters.Part_TaxesTableAdapter part_TaxesTableAdapter;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label _engine_label;
        private System.Windows.Forms.Label _boat_label;
        private System.Windows.Forms.Label _company_label;
        private System.Windows.Forms.Label _date_label;
        private System.Windows.Forms.PictureBox _Boat_pictureBox;
        private System.Windows.Forms.PictureBox _Engine_pictureBox;
        private System.Windows.Forms.PictureBox _Company_pictureBox;
        private System.Windows.Forms.ToolStripMenuItem pastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPenToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem saveAsEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExcelToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}