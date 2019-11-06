namespace Coffee_ManageMent
{
    partial class frmShow_Check_Pardakht
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow_Check_Pardakht));
            this.picClose = new System.Windows.Forms.PictureBox();
            this.mnuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShow_All = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvStore = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Of_Arrivall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dar_Vajh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecive = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDaryaft = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.mnuChange_State = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Coffee_ManageMent.Properties.Resources.closeicon;
            this.picClose.Location = new System.Drawing.Point(17, 11);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 18);
            this.picClose.TabIndex = 12;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // mnuBack
            // 
            this.mnuBack.Image = global::Coffee_ManageMent.Properties.Resources._008;
            this.mnuBack.Name = "mnuBack";
            this.mnuBack.Size = new System.Drawing.Size(251, 24);
            this.mnuBack.Text = "برگشت";
            this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuShow_All
            // 
            this.mnuShow_All.Image = global::Coffee_ManageMent.Properties.Resources.com_riteshsahu_SMSBackupRestore;
            this.mnuShow_All.Name = "mnuShow_All";
            this.mnuShow_All.Size = new System.Drawing.Size(251, 24);
            this.mnuShow_All.Text = "نمایش همه چک ها";
            this.mnuShow_All.Click += new System.EventHandler(this.mnuShow_All_Click);
            // 
            // dgvStore
            // 
            this.dgvStore.AllowUserToAddRows = false;
            this.dgvStore.AllowUserToDeleteRows = false;
            this.dgvStore.AllowUserToResizeColumns = false;
            this.dgvStore.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStore.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Check_Number,
            this.ID_Check,
            this.Date_Of_Arrivall,
            this.Price,
            this.Bank,
            this.ID_Bank,
            this.Description,
            this.Code,
            this.Dar_Vajh,
            this.Date,
            this.Type_Name,
            this.State_Name});
            this.dgvStore.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStore.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStore.Location = new System.Drawing.Point(11, 112);
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.ReadOnly = true;
            this.dgvStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStore.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStore.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStore.Size = new System.Drawing.Size(1330, 554);
            this.dgvStore.TabIndex = 55762;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 76.09799F;
            this.ID.HeaderText = "عطف سند";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Check_Number
            // 
            this.Check_Number.DataPropertyName = "Check_Number";
            this.Check_Number.FillWeight = 66.2716F;
            this.Check_Number.HeaderText = "شماره چک";
            this.Check_Number.Name = "Check_Number";
            this.Check_Number.ReadOnly = true;
            // 
            // ID_Check
            // 
            this.ID_Check.DataPropertyName = "ID_Check";
            this.ID_Check.HeaderText = "ID_Check";
            this.ID_Check.Name = "ID_Check";
            this.ID_Check.ReadOnly = true;
            this.ID_Check.Visible = false;
            // 
            // Date_Of_Arrivall
            // 
            this.Date_Of_Arrivall.DataPropertyName = "Date_Of_Arrivall";
            this.Date_Of_Arrivall.FillWeight = 86.48489F;
            this.Date_Of_Arrivall.HeaderText = "سررسید";
            this.Date_Of_Arrivall.Name = "Date_Of_Arrivall";
            this.Date_Of_Arrivall.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.FillWeight = 104.6999F;
            this.Price.HeaderText = "مبلغ";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Payer";
            this.Bank.FillWeight = 109.1441F;
            this.Bank.HeaderText = "صادرکننده";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            // 
            // ID_Bank
            // 
            this.ID_Bank.DataPropertyName = "ID_Bank";
            this.ID_Bank.HeaderText = "ID_Bank";
            this.ID_Bank.Name = "ID_Bank";
            this.ID_Bank.ReadOnly = true;
            this.ID_Bank.Visible = false;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 154.6734F;
            this.Description.HeaderText = "دریافت کننده";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Acc_Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Visible = false;
            // 
            // Dar_Vajh
            // 
            this.Dar_Vajh.DataPropertyName = "Dar_Vajh";
            this.Dar_Vajh.FillWeight = 84.68877F;
            this.Dar_Vajh.HeaderText = "در وجه";
            this.Dar_Vajh.Name = "Dar_Vajh";
            this.Dar_Vajh.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.FillWeight = 111.2093F;
            this.Date.HeaderText = "تاریخ صدور";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Type_Name
            // 
            this.Type_Name.DataPropertyName = "Type_Name";
            this.Type_Name.FillWeight = 111.2093F;
            this.Type_Name.HeaderText = "نوع چک";
            this.Type_Name.Name = "Type_Name";
            this.Type_Name.ReadOnly = true;
            // 
            // State_Name
            // 
            this.State_Name.DataPropertyName = "State_Name";
            this.State_Name.FillWeight = 111.2093F;
            this.State_Name.HeaderText = "وضعیت";
            this.State_Name.Name = "State_Name";
            this.State_Name.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert,
            this.mnuRecive,
            this.mnuDelete,
            this.toolStripMenuItem2,
            this.mnuView,
            this.toolStripMenuItem1,
            this.mnuReceipt,
            this.toolStripMenuItem3,
            this.mnuDaryaft,
            this.mnuBack,
            this.mnuChange_State,
            this.toolStripMenuItem4,
            this.mnuShow_All});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(252, 266);
            // 
            // mnuInsert
            // 
            this.mnuInsert.Image = global::Coffee_ManageMent.Properties.Resources._0457;
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.Size = new System.Drawing.Size(251, 24);
            this.mnuInsert.Text = "ایجاد چک پرداختنی جدید";
            this.mnuInsert.Click += new System.EventHandler(this.mnuInsert_Click);
            // 
            // mnuRecive
            // 
            this.mnuRecive.Image = global::Coffee_ManageMent.Properties.Resources.edit;
            this.mnuRecive.Name = "mnuRecive";
            this.mnuRecive.Size = new System.Drawing.Size(251, 24);
            this.mnuRecive.Text = "ویرایش اطلاعات چک پرداختنی جاری";
            this.mnuRecive.Click += new System.EventHandler(this.mnuRecive_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Coffee_ManageMent.Properties.Resources.delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(251, 24);
            this.mnuDelete.Text = "حدف چک پرداختنی جاری";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Coffee_ManageMent.Properties.Resources._02;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(251, 24);
            this.mnuView.Text = "مشاهده";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuReceipt
            // 
            this.mnuReceipt.Image = global::Coffee_ManageMent.Properties.Resources.list__3_;
            this.mnuReceipt.Name = "mnuReceipt";
            this.mnuReceipt.Size = new System.Drawing.Size(251, 24);
            this.mnuReceipt.Text = "رسید";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuDaryaft
            // 
            this.mnuDaryaft.Image = global::Coffee_ManageMent.Properties.Resources._001;
            this.mnuDaryaft.Name = "mnuDaryaft";
            this.mnuDaryaft.Size = new System.Drawing.Size(251, 24);
            this.mnuDaryaft.Text = "پاس";
            this.mnuDaryaft.Click += new System.EventHandler(this.mnuDaryaft_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(920, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(337, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "نمایش اسناد پرداختنی";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(3, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1346, 43);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BackgroundImage = global::Coffee_ManageMent.Properties.Resources.HeaderBack;
            this.panelEx1.Style.BackgroundImageAlpha = ((byte)(125));
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.Gainsboro;
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 55764;
            this.panelEx1.Click += new System.EventHandler(this.panelEx1_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.lblCounter);
            this.panelEx3.Controls.Add(this.label1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(3, 669);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1346, 43);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.Gainsboro;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.Color.Gainsboro;
            this.panelEx3.Style.BackgroundImageAlpha = ((byte)(125));
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx3.Style.BorderWidth = 2;
            this.panelEx3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 55766;
            // 
            // lblCounter
            // 
            this.lblCounter.Font = new System.Drawing.Font("B Yekan", 12F);
            this.lblCounter.Location = new System.Drawing.Point(550, 11);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(46, 20);
            this.lblCounter.TabIndex = 55620;
            this.lblCounter.Text = "00";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label1.Location = new System.Drawing.Point(626, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 20);
            this.label1.TabIndex = 55621;
            this.label1.Text = "تعداد سند ثبت شده:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(374, 79);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(593, 27);
            this.txtSearch.TabIndex = 55763;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.BackColor = System.Drawing.Color.Transparent;
            this.lblHour.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHour.Location = new System.Drawing.Point(28, 27);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(19, 20);
            this.lblHour.TabIndex = 26;
            this.lblHour.Text = "00";
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewDate
            // 
            this.lblNewDate.AutoSize = true;
            this.lblNewDate.BackColor = System.Drawing.Color.Transparent;
            this.lblNewDate.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNewDate.Location = new System.Drawing.Point(91, 27);
            this.lblNewDate.Name = "lblNewDate";
            this.lblNewDate.Size = new System.Drawing.Size(19, 20);
            this.lblNewDate.TabIndex = 27;
            this.lblNewDate.Text = "00";
            this.lblNewDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.BackColor = System.Drawing.Color.Transparent;
            this.lblSec.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSec.Location = new System.Drawing.Point(45, 27);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(12, 20);
            this.lblSec.TabIndex = 23;
            this.lblSec.Text = ":";
            this.lblSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.BackColor = System.Drawing.Color.Transparent;
            this.lblDay.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDay.Location = new System.Drawing.Point(168, 27);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(19, 20);
            this.lblDay.TabIndex = 24;
            this.lblDay.Text = "00";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMin.Location = new System.Drawing.Point(54, 27);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(19, 20);
            this.lblMin.TabIndex = 25;
            this.lblMin.Text = "00";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.lblHour);
            this.panelEx2.Controls.Add(this.lblNewDate);
            this.panelEx2.Controls.Add(this.lblSec);
            this.panelEx2.Controls.Add(this.lblDay);
            this.panelEx2.Controls.Add(this.lblMin);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(579, 19);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(214, 56);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.panelEx2.Style.BackgroundImageAlpha = ((byte)(125));
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.Gainsboro;
            this.panelEx2.Style.BorderWidth = 2;
            this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 55765;
            // 
            // mnuChange_State
            // 
            this.mnuChange_State.Image = global::Coffee_ManageMent.Properties.Resources._100;
            this.mnuChange_State.Name = "mnuChange_State";
            this.mnuChange_State.Size = new System.Drawing.Size(251, 24);
            this.mnuChange_State.Text = "تغییر وضعیت";
            this.mnuChange_State.Click += new System.EventHandler(this.mnuChange_State_Click);
            // 
            // frmShow_Check_Pardakht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.panelEx1;
            this.ClientSize = new System.Drawing.Size(1352, 712);
            this.Controls.Add(this.dgvStore);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShow_Check_Pardakht";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmShow_Check_Pardakht_Activated);
            this.Load += new System.EventHandler(this.frmShow_Check_Pardakht_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.ToolStripMenuItem mnuBack;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuShow_All;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvStore;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuRecive;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuReceipt;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuDaryaft;
        public System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Of_Arrivall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dar_Vajh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn State_Name;
        private System.Windows.Forms.ToolStripMenuItem mnuChange_State;
    }
}