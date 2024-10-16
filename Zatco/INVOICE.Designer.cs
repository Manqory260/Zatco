using System.Drawing;
using System.Windows.Forms;

namespace Zatco
{
    partial class INVOICE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INVOICE));
            this.part_TaxesTableAdapter = new Zatco.ZatcoDBDataSet1TableAdapters.Part_TaxesTableAdapter();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.oPenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copy_selected_row_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cop_all_rowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveAsExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.button2 = new System.Windows.Forms.Button();
            this._Boat_pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Engine_pictureBox = new System.Windows.Forms.PictureBox();
            this._Company_pictureBox = new System.Windows.Forms.PictureBox();
            this._engine_combo = new System.Windows.Forms.ComboBox();
            this._boat_combo = new System.Windows.Forms.ComboBox();
            this._company_combo = new System.Windows.Forms.ComboBox();
            this._dollar_text = new System.Windows.Forms.TextBox();
            this._dollar_check = new System.Windows.Forms.CheckBox();
            this._Tital_label = new System.Windows.Forms.Label();
            this._nunTaxes_radio = new System.Windows.Forms.RadioButton();
            this._taxes_radio = new System.Windows.Forms.RadioButton();
            this._overall_text = new System.Windows.Forms.TextBox();
            this._overall_label = new System.Windows.Forms.Label();
            this._total_text = new System.Windows.Forms.TextBox();
            this._total_label = new System.Windows.Forms.Label();
            this._taxes_text = new System.Windows.Forms.TextBox();
            this._taxes_label = new System.Windows.Forms.Label();
            this._data_grid = new System.Windows.Forms.DataGridView();
            this._discount_text = new System.Windows.Forms.TextBox();
            this._INV_NUM_Text = new System.Windows.Forms.TextBox();
            this._date_picker = new System.Windows.Forms.DateTimePicker();
            this._discount_label = new System.Windows.Forms.Label();
            this._engine_label = new System.Windows.Forms.Label();
            this._boat_label = new System.Windows.Forms.Label();
            this._company_label = new System.Windows.Forms.Label();
            this.INV_Docment = new System.Drawing.Printing.PrintDocument();
            this.INV_PrintPReview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.zatcoDBDataSet = new Zatco.ZatcoDBDataSet();
            this.companyTableAdapter = new Zatco.ZatcoDBDataSetTableAdapters.CompanyTableAdapter();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Boat_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Engine_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Company_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._data_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatcoDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // part_TaxesTableAdapter
            // 
            this.part_TaxesTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripContainer1.ContentPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Boat_pictureBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Engine_pictureBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Company_pictureBox);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._engine_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._boat_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._company_combo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._dollar_text);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._dollar_check);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._Tital_label);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._nunTaxes_radio);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._taxes_radio);
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
            this.toolStripContainer1.ContentPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(818, 600);
            this.toolStripContainer1.ContentPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStripContainer1_ContentPanel_MouseDown);
            this.toolStripContainer1.ContentPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ToolStripContainer1_ContentPanel_MouseMove);
            this.toolStripContainer1.ContentPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ToolStripContainer1_ContentPanel_MouseUp);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(818, 600);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolStripContainer1.TopToolStripPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripContainer1.TopToolStripPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStripContainer1.TopToolStripPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolStripContainer1.TopToolStripPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
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
            this.oPenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oPenToolStripMenuItem.Image")));
            this.oPenToolStripMenuItem.Name = "oPenToolStripMenuItem";
            this.oPenToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.oPenToolStripMenuItem.Text = "Search in Parts";
            this.oPenToolStripMenuItem.Click += new System.EventHandler(this.OPenToolStripMenuItem_Click);
            // 
            // copy_selected_row_ToolStripMenuItem
            // 
            this.copy_selected_row_ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copy_selected_row_ToolStripMenuItem.Image")));
            this.copy_selected_row_ToolStripMenuItem.Name = "copy_selected_row_ToolStripMenuItem";
            this.copy_selected_row_ToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.copy_selected_row_ToolStripMenuItem.Text = "Copy Selected Row";
            this.copy_selected_row_ToolStripMenuItem.Click += new System.EventHandler(this.Copy_selected_row_ToolStripMenuItem_Click);
            // 
            // cop_all_rowToolStripMenuItem
            // 
            this.cop_all_rowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cop_all_rowToolStripMenuItem.Image")));
            this.cop_all_rowToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.cop_all_rowToolStripMenuItem.Name = "cop_all_rowToolStripMenuItem";
            this.cop_all_rowToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cop_all_rowToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.cop_all_rowToolStripMenuItem.Text = "Copy ";
            this.cop_all_rowToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripButton_Click);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pastToolStripMenuItem.Image")));
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.pastToolStripMenuItem.Text = "Past";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Zatco.Properties.Resources.minimize1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(748, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
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
            this.toolStripDropDownButton1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 99);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(270, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.newToolStripButton.Checked = true;
            this.newToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.openToolStripButton.Checked = true;
            this.openToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = global::Zatco.Properties.Resources.open;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Edit";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.saveToolStripButton.Checked = true;
            this.saveToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::Zatco.Properties.Resources.save31;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.printToolStripButton.Checked = true;
            this.printToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = global::Zatco.Properties.Resources.print44;
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Click += new System.EventHandler(this.PrintToolStripButton_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.helpToolStripButton.Checked = true;
            this.helpToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.helpToolStripButton.Text = "Print Preview";
            this.helpToolStripButton.Click += new System.EventHandler(this.HelpToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.BackColor = System.Drawing.Color.RosyBrown;
            this.toolStripSeparator.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.copyToolStripButton.Checked = true;
            this.copyToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.pasteToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pasteToolStripButton.Checked = true;
            this.pasteToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.cutToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cutToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cutToolStripButton.Checked = true;
            this.cutToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cutToolStripButton.Text = "Delete this invoice";
            this.cutToolStripButton.Click += new System.EventHandler(this.CutToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsExcelToolStripMenuItem,
            this.openExcelToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(33, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // saveAsExcelToolStripMenuItem
            // 
            this.saveAsExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsExcelToolStripMenuItem.Image")));
            this.saveAsExcelToolStripMenuItem.Name = "saveAsExcelToolStripMenuItem";
            this.saveAsExcelToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveAsExcelToolStripMenuItem.Text = "Save As Excel";
            this.saveAsExcelToolStripMenuItem.Click += new System.EventHandler(this.SaveAsExcelToolStripMenuItem_Click);
            // 
            // openExcelToolStripMenuItem
            // 
            this.openExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openExcelToolStripMenuItem.Image")));
            this.openExcelToolStripMenuItem.Name = "openExcelToolStripMenuItem";
            this.openExcelToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.openExcelToolStripMenuItem.Text = "Open Excel";
            this.openExcelToolStripMenuItem.Click += new System.EventHandler(this.OpenExcelToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckOnClick = true;
            this.toolStripButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Zatco.Properties.Resources.close;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(784, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 36;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // _Boat_pictureBox
            // 
            this._Boat_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Boat_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Boat_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_Boat_pictureBox.Image")));
            this._Boat_pictureBox.Location = new System.Drawing.Point(474, 70);
            this._Boat_pictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Boat_pictureBox.Name = "_Boat_pictureBox";
            this._Boat_pictureBox.Size = new System.Drawing.Size(16, 16);
            this._Boat_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._Boat_pictureBox.TabIndex = 35;
            this._Boat_pictureBox.TabStop = false;
            this._Boat_pictureBox.Click += new System.EventHandler(this.Boat_pictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "Date";
            // 
            // _Engine_pictureBox
            // 
            this._Engine_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Engine_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Engine_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_Engine_pictureBox.Image")));
            this._Engine_pictureBox.Location = new System.Drawing.Point(474, 99);
            this._Engine_pictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Engine_pictureBox.Name = "_Engine_pictureBox";
            this._Engine_pictureBox.Size = new System.Drawing.Size(16, 16);
            this._Engine_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._Engine_pictureBox.TabIndex = 34;
            this._Engine_pictureBox.TabStop = false;
            this._Engine_pictureBox.Click += new System.EventHandler(this.Engine_pictureBox_Click);
            // 
            // _Company_pictureBox
            // 
            this._Company_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Company_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Company_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_Company_pictureBox.Image")));
            this._Company_pictureBox.Location = new System.Drawing.Point(474, 41);
            this._Company_pictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Company_pictureBox.Name = "_Company_pictureBox";
            this._Company_pictureBox.Size = new System.Drawing.Size(16, 16);
            this._Company_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._Company_pictureBox.TabIndex = 33;
            this._Company_pictureBox.TabStop = false;
            this._Company_pictureBox.Click += new System.EventHandler(this.Company_pictureBox_Click);
            // 
            // _engine_combo
            // 
            this._engine_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._engine_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._engine_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._engine_combo.BackColor = System.Drawing.SystemColors.Info;
            this._engine_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._engine_combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._engine_combo.FormattingEnabled = true;
            this._engine_combo.Location = new System.Drawing.Point(603, 95);
            this._engine_combo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._engine_combo.Name = "_engine_combo";
            this._engine_combo.Size = new System.Drawing.Size(211, 27);
            this._engine_combo.TabIndex = 30;
            this._engine_combo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_grid_KeyDown);
            // 
            // _boat_combo
            // 
            this._boat_combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._boat_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._boat_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._boat_combo.BackColor = System.Drawing.SystemColors.Info;
            this._boat_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._boat_combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._boat_combo.FormattingEnabled = true;
            this._boat_combo.Location = new System.Drawing.Point(603, 65);
            this._boat_combo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._boat_combo.Name = "_boat_combo";
            this._boat_combo.Size = new System.Drawing.Size(211, 27);
            this._boat_combo.TabIndex = 29;
            this._boat_combo.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            this._boat_combo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_grid_KeyDown);
            // 
            // _company_combo
            // 
            this._company_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._company_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._company_combo.BackColor = System.Drawing.SystemColors.Info;
            this._company_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._company_combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._company_combo.FormattingEnabled = true;
            this._company_combo.Location = new System.Drawing.Point(603, 35);
            this._company_combo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._company_combo.Name = "_company_combo";
            this._company_combo.Size = new System.Drawing.Size(211, 27);
            this._company_combo.TabIndex = 28;
            this._company_combo.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            this._company_combo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_grid_KeyDown);
            // 
            // _dollar_text
            // 
            this._dollar_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._dollar_text.Location = new System.Drawing.Point(559, 529);
            this._dollar_text.Name = "_dollar_text";
            this._dollar_text.PasswordChar = '-';
            this._dollar_text.Size = new System.Drawing.Size(133, 27);
            this._dollar_text.TabIndex = 27;
            this._dollar_text.UseSystemPasswordChar = true;
            this._dollar_text.Visible = false;
            // 
            // _dollar_check
            // 
            this._dollar_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._dollar_check.AutoSize = true;
            this._dollar_check.Location = new System.Drawing.Point(556, 500);
            this._dollar_check.Name = "_dollar_check";
            this._dollar_check.Size = new System.Drawing.Size(191, 23);
            this._dollar_check.TabIndex = 26;
            this._dollar_check.Text = "Pricing using the dollar";
            this._dollar_check.UseVisualStyleBackColor = true;
            this._dollar_check.Visible = false;
            this._dollar_check.CheckedChanged += new System.EventHandler(this.Dollar_check_CheckedChanged);
            // 
            // _Tital_label
            // 
            this._Tital_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._Tital_label.AutoSize = true;
            this._Tital_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Tital_label.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tital_label.Location = new System.Drawing.Point(318, 0);
            this._Tital_label.Name = "_Tital_label";
            this._Tital_label.Size = new System.Drawing.Size(172, 34);
            this._Tital_label.TabIndex = 8;
            this._Tital_label.Text = "Part Invoice";
            // 
            // _nunTaxes_radio
            // 
            this._nunTaxes_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._nunTaxes_radio.AutoSize = true;
            this._nunTaxes_radio.Location = new System.Drawing.Point(575, 468);
            this._nunTaxes_radio.Name = "_nunTaxes_radio";
            this._nunTaxes_radio.Size = new System.Drawing.Size(131, 23);
            this._nunTaxes_radio.TabIndex = 7;
            this._nunTaxes_radio.Text = "with out Taxes";
            this._nunTaxes_radio.UseVisualStyleBackColor = true;
            // 
            // _taxes_radio
            // 
            this._taxes_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._taxes_radio.AutoSize = true;
            this._taxes_radio.Checked = true;
            this._taxes_radio.Location = new System.Drawing.Point(584, 440);
            this._taxes_radio.Name = "_taxes_radio";
            this._taxes_radio.Size = new System.Drawing.Size(103, 23);
            this._taxes_radio.TabIndex = 6;
            this._taxes_radio.TabStop = true;
            this._taxes_radio.Text = "with Taxes";
            this._taxes_radio.UseVisualStyleBackColor = true;
            this._taxes_radio.CheckedChanged += new System.EventHandler(this.Taxes_radio_CheckedChanged);
            // 
            // _overall_text
            // 
            this._overall_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._overall_text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._overall_text.ForeColor = System.Drawing.Color.Maroon;
            this._overall_text.Location = new System.Drawing.Point(136, 535);
            this._overall_text.Name = "_overall_text";
            this._overall_text.Size = new System.Drawing.Size(100, 23);
            this._overall_text.TabIndex = 11;
            this._overall_text.Text = "0";
            // 
            // _overall_label
            // 
            this._overall_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._overall_label.AutoSize = true;
            this._overall_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._overall_label.ForeColor = System.Drawing.Color.Black;
            this._overall_label.Location = new System.Drawing.Point(20, 532);
            this._overall_label.Name = "_overall_label";
            this._overall_label.Size = new System.Drawing.Size(77, 25);
            this._overall_label.TabIndex = 17;
            this._overall_label.Text = "Overall";
            // 
            // _total_text
            // 
            this._total_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._total_text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._total_text.ForeColor = System.Drawing.Color.Maroon;
            this._total_text.Location = new System.Drawing.Point(136, 431);
            this._total_text.Name = "_total_text";
            this._total_text.Size = new System.Drawing.Size(100, 23);
            this._total_text.TabIndex = 18;
            this._total_text.Text = "0";
            // 
            // _total_label
            // 
            this._total_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._total_label.AutoSize = true;
            this._total_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._total_label.ForeColor = System.Drawing.Color.Black;
            this._total_label.Location = new System.Drawing.Point(20, 423);
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
            this._taxes_text.Location = new System.Drawing.Point(136, 466);
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
            this._taxes_label.Location = new System.Drawing.Point(20, 496);
            this._taxes_label.Name = "_taxes_label";
            this._taxes_label.Size = new System.Drawing.Size(65, 25);
            this._taxes_label.TabIndex = 16;
            this._taxes_label.Text = "Taxes";
            // 
            // _data_grid
            // 
            this._data_grid.AllowUserToOrderColumns = true;
            this._data_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._data_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._data_grid.BackgroundColor = System.Drawing.SystemColors.Info;
            this._data_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._data_grid.ContextMenuStrip = this.contextMenuStrip1;
            this._data_grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._data_grid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._data_grid.Location = new System.Drawing.Point(3, 130);
            this._data_grid.Name = "_data_grid";
            this._data_grid.RowHeadersWidth = 20;
            this._data_grid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PeachPuff;
            this._data_grid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this._data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._data_grid.ShowCellToolTips = false;
            this._data_grid.Size = new System.Drawing.Size(811, 290);
            this._data_grid.TabIndex = 4;
            this._data_grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Data_grid_CellValidating);
            this._data_grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Data_grid_DataError);
            this._data_grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Data_grid_EditingControlShowing);
            this._data_grid.SelectionChanged += new System.EventHandler(this.Data_grid_SelectionChanged);
            this._data_grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_grid_KeyDown);
            // 
            // _discount_text
            // 
            this._discount_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._discount_text.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._discount_text.ForeColor = System.Drawing.Color.Maroon;
            this._discount_text.Location = new System.Drawing.Point(136, 500);
            this._discount_text.Name = "_discount_text";
            this._discount_text.Size = new System.Drawing.Size(100, 23);
            this._discount_text.TabIndex = 19;
            this._discount_text.Text = "0";
            // 
            // _INV_NUM_Text
            // 
            this._INV_NUM_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this._INV_NUM_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._INV_NUM_Text.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._INV_NUM_Text.ForeColor = System.Drawing.Color.Red;
            this._INV_NUM_Text.Location = new System.Drawing.Point(136, 59);
            this._INV_NUM_Text.Name = "_INV_NUM_Text";
            this._INV_NUM_Text.Size = new System.Drawing.Size(93, 25);
            this._INV_NUM_Text.TabIndex = 0;
            this._INV_NUM_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            this._INV_NUM_Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.INV_NUM_Text_KeyPress);
            this._INV_NUM_Text.Leave += new System.EventHandler(this.INV_NUM_Text_Leave);
            // 
            // _date_picker
            // 
            this._date_picker.CustomFormat = "dd/MM/yyyy";
            this._date_picker.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._date_picker.Location = new System.Drawing.Point(88, 23);
            this._date_picker.Name = "_date_picker";
            this._date_picker.Size = new System.Drawing.Size(155, 30);
            this._date_picker.TabIndex = 0;
            this._date_picker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_grid_KeyDown);
            // 
            // _discount_label
            // 
            this._discount_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._discount_label.AutoSize = true;
            this._discount_label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._discount_label.ForeColor = System.Drawing.Color.Black;
            this._discount_label.Location = new System.Drawing.Point(20, 461);
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
            this._engine_label.Location = new System.Drawing.Point(500, 101);
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
            this._boat_label.Location = new System.Drawing.Point(496, 71);
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
            this._company_label.Location = new System.Drawing.Point(496, 41);
            this._company_label.Name = "_company_label";
            this._company_label.Size = new System.Drawing.Size(97, 16);
            this._company_label.TabIndex = 11;
            this._company_label.Text = "Company Name";
            // 
            // INV_Docment
            // 
            this.INV_Docment.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.INV_Docment_PrintPage);
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
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // zatcoDBDataSet
            // 
            this.zatcoDBDataSet.DataSetName = "ZatcoDBDataSet";
            this.zatcoDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // companyTableAdapter
            // 
            this.companyTableAdapter.ClearBeforeFill = true;
            // 
            // INVOICE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 600);
            this.Controls.Add(this.toolStripContainer1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.MaximizeBox = false;
            this.Name = "INVOICE";
            this.Text = "INVOICE";
            this.Load += new System.EventHandler(this.INVOICE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Data_grid_KeyDown);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Boat_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Engine_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Company_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._data_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatcoDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ZatcoDBDataSet1TableAdapters.Part_TaxesTableAdapter part_TaxesTableAdapter;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label _Tital_label;
        private System.Windows.Forms.TextBox _total_text;
        private System.Windows.Forms.Label _total_label;
        private System.Windows.Forms.DataGridView _data_grid;
        private System.Windows.Forms.TextBox _INV_NUM_Text;
        private System.Windows.Forms.DateTimePicker _date_picker;
        private System.Windows.Forms.Label _engine_label;
        private System.Windows.Forms.Label _boat_label;
        private System.Windows.Forms.Label _company_label;
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
        private System.Drawing.Printing.PrintDocument INV_Docment;
        private System.Windows.Forms.PrintPreviewDialog INV_PrintPReview;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ComboBox _company_combo;
        private System.Windows.Forms.ComboBox _boat_combo;
        private System.Windows.Forms.ComboBox _engine_combo;
        private System.Windows.Forms.Label _discount_label;
        private System.Windows.Forms.TextBox _discount_text;
        private System.Windows.Forms.Label _taxes_label;
        private System.Windows.Forms.TextBox _taxes_text;
        private System.Windows.Forms.Label _overall_label;
        private System.Windows.Forms.TextBox _overall_text;
        private System.Windows.Forms.RadioButton _taxes_radio;
        private System.Windows.Forms.RadioButton _nunTaxes_radio;
        private System.Windows.Forms.CheckBox _dollar_check;
        private System.Windows.Forms.TextBox _dollar_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox _Boat_pictureBox;
        private System.Windows.Forms.PictureBox _Engine_pictureBox;
        private System.Windows.Forms.PictureBox _Company_pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copy_selected_row_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cop_all_rowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPenToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem saveAsExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExcelToolStripMenuItem;
        private Button button2;
        private ToolStripButton toolStripButton1;
        private Button button1;
        private ZatcoDBDataSet zatcoDBDataSet;
        private ZatcoDBDataSetTableAdapters.CompanyTableAdapter companyTableAdapter;
    }
}