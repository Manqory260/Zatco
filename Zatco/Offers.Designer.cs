namespace Zatco
{
    partial class Offers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Offers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this._engine_combo = new System.Windows.Forms.ComboBox();
            this._boat_combo = new System.Windows.Forms.ComboBox();
            this._company_combo = new System.Windows.Forms.ComboBox();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._Tital_label = new System.Windows.Forms.Label();
            this._overall_label = new System.Windows.Forms.Label();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._overall_text = new System.Windows.Forms.TextBox();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._total_text = new System.Windows.Forms.TextBox();
            this.INV_Docment = new System.Drawing.Printing.PrintDocument();
            this._total_label = new System.Windows.Forms.Label();
            this._taxes_text = new System.Windows.Forms.TextBox();
            this._taxes_label = new System.Windows.Forms.Label();
            this._data_grid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copy_selected_row_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cop_all_rowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.INV_PrintPReview = new System.Windows.Forms.PrintPreviewDialog();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._discount_text = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._INV_NUM_Text = new System.Windows.Forms.TextBox();
            this._date_picker = new System.Windows.Forms.DateTimePicker();
            this._discount_label = new System.Windows.Forms.Label();
            this._engine_label = new System.Windows.Forms.Label();
            this._boat_label = new System.Windows.Forms.Label();
            this._company_label = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.part_TaxesTableAdapter = new Zatco.ZatcoDBDataSet1TableAdapters.Part_TaxesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._data_grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "Date";
            // 
            // _engine_combo
            // 
            this._engine_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._engine_combo.FormattingEnabled = true;
            this._engine_combo.Location = new System.Drawing.Point(607, 103);
            this._engine_combo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._engine_combo.Name = "_engine_combo";
            this._engine_combo.Size = new System.Drawing.Size(155, 21);
            this._engine_combo.TabIndex = 30;
            this._engine_combo.Text = "Choose Engine SN";
            // 
            // _boat_combo
            // 
            this._boat_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._boat_combo.FormattingEnabled = true;
            this._boat_combo.Location = new System.Drawing.Point(607, 74);
            this._boat_combo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._boat_combo.Name = "_boat_combo";
            this._boat_combo.Size = new System.Drawing.Size(155, 21);
            this._boat_combo.TabIndex = 29;
            this._boat_combo.Text = "Choose Boat";
            this._boat_combo.SelectedIndexChanged += new System.EventHandler(this._boat_combo_SelectedIndexChanged);
            // 
            // _company_combo
            // 
            this._company_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._company_combo.FormattingEnabled = true;
            this._company_combo.Location = new System.Drawing.Point(607, 43);
            this._company_combo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._company_combo.Name = "_company_combo";
            this._company_combo.Size = new System.Drawing.Size(155, 21);
            this._company_combo.TabIndex = 28;
            this._company_combo.Text = "Choose Company";
            this._company_combo.SelectedIndexChanged += new System.EventHandler(this._company_combo_SelectedIndexChanged);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = global::Zatco.Properties.Resources.DeleteRed;
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cutToolStripButton.Text = "Delete this invoice";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = global::Zatco.Properties.Resources.untitled_2_;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.helpToolStripButton.Text = "Print Preview";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // _Tital_label
            // 
            this._Tital_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._Tital_label.AutoSize = true;
            this._Tital_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Tital_label.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tital_label.Location = new System.Drawing.Point(291, 9);
            this._Tital_label.Name = "_Tital_label";
            this._Tital_label.Size = new System.Drawing.Size(143, 34);
            this._Tital_label.TabIndex = 8;
            this._Tital_label.Text = "Part Offer";
            // 
            // _overall_label
            // 
            this._overall_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._overall_label.AutoSize = true;
            this._overall_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._overall_label.ForeColor = System.Drawing.Color.Black;
            this._overall_label.Location = new System.Drawing.Point(15, 645);
            this._overall_label.Name = "_overall_label";
            this._overall_label.Size = new System.Drawing.Size(77, 25);
            this._overall_label.TabIndex = 17;
            this._overall_label.Text = "Overall";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
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
            // _overall_text
            // 
            this._overall_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._overall_text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._overall_text.ForeColor = System.Drawing.Color.Maroon;
            this._overall_text.Location = new System.Drawing.Point(141, 650);
            this._overall_text.Name = "_overall_text";
            this._overall_text.Size = new System.Drawing.Size(100, 23);
            this._overall_text.TabIndex = 11;
            this._overall_text.Text = "0";
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
            // _total_text
            // 
            this._total_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._total_text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._total_text.ForeColor = System.Drawing.Color.Maroon;
            this._total_text.Location = new System.Drawing.Point(141, 551);
            this._total_text.Name = "_total_text";
            this._total_text.Size = new System.Drawing.Size(100, 23);
            this._total_text.TabIndex = 18;
            this._total_text.Text = "0";
            // 
            // INV_Docment
            // 
            this.INV_Docment.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.INV_Docment_PrintPage);
            // 
            // _total_label
            // 
            this._total_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._total_label.AutoSize = true;
            this._total_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._total_label.ForeColor = System.Drawing.Color.Black;
            this._total_label.Location = new System.Drawing.Point(15, 551);
            this._total_label.Name = "_total_label";
            this._total_label.Size = new System.Drawing.Size(58, 25);
            this._total_label.TabIndex = 14;
            this._total_label.Text = "Total";
            // 
            // _taxes_text
            // 
            this._taxes_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._taxes_text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._taxes_text.ForeColor = System.Drawing.Color.Maroon;
            this._taxes_text.Location = new System.Drawing.Point(141, 616);
            this._taxes_text.Name = "_taxes_text";
            this._taxes_text.Size = new System.Drawing.Size(100, 23);
            this._taxes_text.TabIndex = 20;
            this._taxes_text.Text = "0";
            // 
            // _taxes_label
            // 
            this._taxes_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._taxes_label.AutoSize = true;
            this._taxes_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._taxes_label.ForeColor = System.Drawing.Color.Black;
            this._taxes_label.Location = new System.Drawing.Point(15, 616);
            this._taxes_label.Name = "_taxes_label";
            this._taxes_label.Size = new System.Drawing.Size(65, 25);
            this._taxes_label.TabIndex = 16;
            this._taxes_label.Text = "Taxes";
            // 
            // _data_grid
            // 
            this._data_grid.AllowUserToOrderColumns = true;
            this._data_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._data_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._data_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._data_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._data_grid.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._data_grid.DefaultCellStyle = dataGridViewCellStyle2;
            this._data_grid.Location = new System.Drawing.Point(0, 129);
            this._data_grid.Name = "_data_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._data_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._data_grid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._data_grid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this._data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._data_grid.Size = new System.Drawing.Size(784, 415);
            this._data_grid.TabIndex = 4;
            this._data_grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this._data_grid_CellValidating);
            this._data_grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this._data_grid_DataError);
            this._data_grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this._data_grid_EditingControlShowing);
            this._data_grid.SelectionChanged += new System.EventHandler(this._data_grid_SelectionChanged);
            this._data_grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this._data_grid_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copy_selected_row_ToolStripMenuItem,
            this.cop_all_rowToolStripMenuItem,
            this.pastToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.oPenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 134);
            // 
            // copy_selected_row_ToolStripMenuItem
            // 
            this.copy_selected_row_ToolStripMenuItem.Image = global::Zatco.Properties.Resources.copy;
            this.copy_selected_row_ToolStripMenuItem.Name = "copy_selected_row_ToolStripMenuItem";
            this.copy_selected_row_ToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.copy_selected_row_ToolStripMenuItem.Text = "Copy Selected Row";
            this.copy_selected_row_ToolStripMenuItem.Click += new System.EventHandler(this.copy_selected_row_ToolStripMenuItem_Click);
            // 
            // cop_all_rowToolStripMenuItem
            // 
            this.cop_all_rowToolStripMenuItem.Image = global::Zatco.Properties.Resources.copyall;
            this.cop_all_rowToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.cop_all_rowToolStripMenuItem.Name = "cop_all_rowToolStripMenuItem";
            this.cop_all_rowToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cop_all_rowToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.cop_all_rowToolStripMenuItem.Text = "Copy ";
            this.cop_all_rowToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Image = global::Zatco.Properties.Resources.Past;
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.pastToolStripMenuItem.Text = "Past";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Zatco.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // oPenToolStripMenuItem
            // 
            this.oPenToolStripMenuItem.Image = global::Zatco.Properties.Resources.open;
            this.oPenToolStripMenuItem.Name = "oPenToolStripMenuItem";
            this.oPenToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.oPenToolStripMenuItem.Text = "Open";
            this.oPenToolStripMenuItem.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Receiving permission";
            // 
            // _discount_text
            // 
            this._discount_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._discount_text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._discount_text.ForeColor = System.Drawing.Color.Maroon;
            this._discount_text.Location = new System.Drawing.Point(141, 584);
            this._discount_text.Name = "_discount_text";
            this._discount_text.Size = new System.Drawing.Size(100, 23);
            this._discount_text.TabIndex = 19;
            this._discount_text.Text = "0";
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
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(213, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // _INV_NUM_Text
            // 
            this._INV_NUM_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this._INV_NUM_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._INV_NUM_Text.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._INV_NUM_Text.ForeColor = System.Drawing.Color.Red;
            this._INV_NUM_Text.Location = new System.Drawing.Point(170, 18);
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
            this._date_picker.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._date_picker.Location = new System.Drawing.Point(75, 89);
            this._date_picker.Name = "_date_picker";
            this._date_picker.Size = new System.Drawing.Size(155, 30);
            this._date_picker.TabIndex = 0;
            // 
            // _discount_label
            // 
            this._discount_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._discount_label.AutoSize = true;
            this._discount_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._discount_label.ForeColor = System.Drawing.Color.Black;
            this._discount_label.Location = new System.Drawing.Point(15, 584);
            this._discount_label.Name = "_discount_label";
            this._discount_label.Size = new System.Drawing.Size(92, 25);
            this._discount_label.TabIndex = 15;
            this._discount_label.Text = "Discount";
            // 
            // _engine_label
            // 
            this._engine_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._engine_label.AutoSize = true;
            this._engine_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._engine_label.Location = new System.Drawing.Point(494, 103);
            this._engine_label.Name = "_engine_label";
            this._engine_label.Size = new System.Drawing.Size(66, 16);
            this._engine_label.TabIndex = 13;
            this._engine_label.Text = "Engine SN";
            // 
            // _boat_label
            // 
            this._boat_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._boat_label.AutoSize = true;
            this._boat_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._boat_label.Location = new System.Drawing.Point(494, 74);
            this._boat_label.Name = "_boat_label";
            this._boat_label.Size = new System.Drawing.Size(70, 16);
            this._boat_label.TabIndex = 12;
            this._boat_label.Text = "Boat Name";
            // 
            // _company_label
            // 
            this._company_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._company_label.AutoSize = true;
            this._company_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._company_label.Location = new System.Drawing.Point(494, 46);
            this._company_label.Name = "_company_label";
            this._company_label.Size = new System.Drawing.Size(98, 16);
            this._company_label.TabIndex = 11;
            this._company_label.Text = "Company Name";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.toolStripContainer1.ContentPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._engine_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._boat_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._company_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Tital_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._overall_text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._overall_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._total_text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._total_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._taxes_text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._taxes_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._data_grid);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._discount_text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._INV_NUM_Text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._date_picker);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._discount_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._engine_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._boat_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._company_label);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 690);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 717);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // part_TaxesTableAdapter
            // 
            this.part_TaxesTableAdapter.ClearBeforeFill = true;
            // 
            // Offers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 717);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Offers";
            this.Text = "Offers";
            ((System.ComponentModel.ISupportInitialize)(this._data_grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _engine_combo;
        private System.Windows.Forms.ComboBox _boat_combo;
        private System.Windows.Forms.ComboBox _company_combo;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Label _Tital_label;
        private System.Windows.Forms.Label _overall_label;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.TextBox _overall_text;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.TextBox _total_text;
        private System.Drawing.Printing.PrintDocument INV_Docment;
        private System.Windows.Forms.Label _total_label;
        private System.Windows.Forms.TextBox _taxes_text;
        private System.Windows.Forms.Label _taxes_label;
        private System.Windows.Forms.DataGridView _data_grid;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.PrintPreviewDialog INV_PrintPReview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox _discount_text;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.TextBox _INV_NUM_Text;
        private System.Windows.Forms.DateTimePicker _date_picker;
        private System.Windows.Forms.Label _discount_label;
        private System.Windows.Forms.Label _engine_label;
        private System.Windows.Forms.Label _boat_label;
        private System.Windows.Forms.Label _company_label;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ZatcoDBDataSet1TableAdapters.Part_TaxesTableAdapter part_TaxesTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copy_selected_row_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cop_all_rowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPenToolStripMenuItem;
    }
}