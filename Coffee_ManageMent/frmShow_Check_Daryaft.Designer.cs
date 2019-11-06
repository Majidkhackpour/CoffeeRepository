namespace Coffee_ManageMent
{
    partial class frmShow_Check_Daryaft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow_Check_Daryaft));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecive = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSend_Bank = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSend_Safe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDaryaft = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShow_All = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvStore = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sett_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Safe_Reciver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.mnuChange_State = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.panelEx2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
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
            this.txtSearch.TabIndex = 55751;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            this.panelEx2.TabIndex = 55753;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(246, 6);
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
            this.mnuSend,
            this.mnuDaryaft,
            this.mnuBack,
            this.mnuReturn,
            this.mnuPay,
            this.toolStripMenuItem5,
            this.mnuChange_State,
            this.toolStripMenuItem4,
            this.mnuShow_All});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 344);
            // 
            // mnuInsert
            // 
            this.mnuInsert.Image = global::Coffee_ManageMent.Properties.Resources._0457;
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.Size = new System.Drawing.Size(249, 24);
            this.mnuInsert.Text = "ایجاد چک دریافتنی جدید";
            this.mnuInsert.Click += new System.EventHandler(this.mnuInsert_Click);
            // 
            // mnuRecive
            // 
            this.mnuRecive.Image = global::Coffee_ManageMent.Properties.Resources.edit;
            this.mnuRecive.Name = "mnuRecive";
            this.mnuRecive.Size = new System.Drawing.Size(249, 24);
            this.mnuRecive.Text = "ویرایش اطلاعات چک دریافتنی جاری";
            this.mnuRecive.Click += new System.EventHandler(this.mnuRecive_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Coffee_ManageMent.Properties.Resources.delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(249, 24);
            this.mnuDelete.Text = "حدف چک دریافتنی جاری";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Coffee_ManageMent.Properties.Resources._02;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(249, 24);
            this.mnuView.Text = "مشاهده";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(246, 6);
            // 
            // mnuReceipt
            // 
            this.mnuReceipt.Image = global::Coffee_ManageMent.Properties.Resources.list__3_;
            this.mnuReceipt.Name = "mnuReceipt";
            this.mnuReceipt.Size = new System.Drawing.Size(249, 24);
            this.mnuReceipt.Text = "رسید";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(246, 6);
            // 
            // mnuSend
            // 
            this.mnuSend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSend_Bank,
            this.mnuSend_Safe});
            this.mnuSend.Image = global::Coffee_ManageMent.Properties.Resources.info;
            this.mnuSend.Name = "mnuSend";
            this.mnuSend.Size = new System.Drawing.Size(249, 24);
            this.mnuSend.Text = "واگذار";
            // 
            // mnuSend_Bank
            // 
            this.mnuSend_Bank.Name = "mnuSend_Bank";
            this.mnuSend_Bank.Size = new System.Drawing.Size(128, 24);
            this.mnuSend_Bank.Text = "در بانک";
            this.mnuSend_Bank.Click += new System.EventHandler(this.mnuSend_Bank_Click);
            // 
            // mnuSend_Safe
            // 
            this.mnuSend_Safe.Name = "mnuSend_Safe";
            this.mnuSend_Safe.Size = new System.Drawing.Size(128, 24);
            this.mnuSend_Safe.Text = "در صندوق";
            this.mnuSend_Safe.Click += new System.EventHandler(this.mnuSend_Safe_Click);
            // 
            // mnuDaryaft
            // 
            this.mnuDaryaft.Image = global::Coffee_ManageMent.Properties.Resources._001;
            this.mnuDaryaft.Name = "mnuDaryaft";
            this.mnuDaryaft.Size = new System.Drawing.Size(249, 24);
            this.mnuDaryaft.Text = "وصول";
            this.mnuDaryaft.Click += new System.EventHandler(this.mnuDaryaft_Click);
            // 
            // mnuBack
            // 
            this.mnuBack.Image = global::Coffee_ManageMent.Properties.Resources._008;
            this.mnuBack.Name = "mnuBack";
            this.mnuBack.Size = new System.Drawing.Size(249, 24);
            this.mnuBack.Text = "برگشت";
            this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
            // 
            // mnuReturn
            // 
            this.mnuReturn.Image = global::Coffee_ManageMent.Properties.Resources._019;
            this.mnuReturn.Name = "mnuReturn";
            this.mnuReturn.Size = new System.Drawing.Size(249, 24);
            this.mnuReturn.Text = "استرداد";
            this.mnuReturn.Click += new System.EventHandler(this.mnuReturn_Click);
            // 
            // mnuPay
            // 
            this.mnuPay.Image = global::Coffee_ManageMent.Properties.Resources._015;
            this.mnuPay.Name = "mnuPay";
            this.mnuPay.Size = new System.Drawing.Size(249, 24);
            this.mnuPay.Text = "خرج";
            this.mnuPay.Click += new System.EventHandler(this.mnuPay_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(246, 6);
            // 
            // mnuShow_All
            // 
            this.mnuShow_All.Image = global::Coffee_ManageMent.Properties.Resources.com_riteshsahu_SMSBackupRestore;
            this.mnuShow_All.Name = "mnuShow_All";
            this.mnuShow_All.Size = new System.Drawing.Size(249, 24);
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
            this.Sett_Date,
            this.Price,
            this.Description,
            this.Code,
            this.Safe_Reciver,
            this.Bank,
            this.State_Name,
            this.Type_Name});
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
            this.dgvStore.TabIndex = 55750;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 69.72249F;
            this.ID.HeaderText = "عطف سند";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Check_Number
            // 
            this.Check_Number.DataPropertyName = "Check_Number";
            this.Check_Number.FillWeight = 60.71935F;
            this.Check_Number.HeaderText = "شماره چک";
            this.Check_Number.Name = "Check_Number";
            this.Check_Number.ReadOnly = true;
            // 
            // Sett_Date
            // 
            this.Sett_Date.DataPropertyName = "Sett_Date";
            this.Sett_Date.FillWeight = 79.23916F;
            this.Sett_Date.HeaderText = "سررسید";
            this.Sett_Date.Name = "Sett_Date";
            this.Sett_Date.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.FillWeight = 95.9281F;
            this.Price.HeaderText = "مبلغ";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 226.8095F;
            this.Description.HeaderText = "پرداخت کننده";
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
            // Safe_Reciver
            // 
            this.Safe_Reciver.DataPropertyName = "Safe_Reciver";
            this.Safe_Reciver.FillWeight = 77.59351F;
            this.Safe_Reciver.HeaderText = "دریافت کننده";
            this.Safe_Reciver.Name = "Safe_Reciver";
            this.Safe_Reciver.ReadOnly = true;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Bank";
            this.Bank.FillWeight = 101.8922F;
            this.Bank.HeaderText = "بانک";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            // 
            // State_Name
            // 
            this.State_Name.DataPropertyName = "State_Name";
            this.State_Name.FillWeight = 101.8922F;
            this.State_Name.HeaderText = "وضعیت";
            this.State_Name.Name = "State_Name";
            this.State_Name.ReadOnly = true;
            // 
            // Type_Name
            // 
            this.Type_Name.DataPropertyName = "Type_Name";
            this.Type_Name.FillWeight = 101.8922F;
            this.Type_Name.HeaderText = "نوع چک";
            this.Type_Name.Name = "Type_Name";
            this.Type_Name.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(920, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(337, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "نمایش اسناد دریافتنی";
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
            this.panelEx1.TabIndex = 55752;
            this.panelEx1.Click += new System.EventHandler(this.panelEx1_Click);
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
            this.panelEx3.TabIndex = 55754;
            // 
            // mnuChange_State
            // 
            this.mnuChange_State.Image = global::Coffee_ManageMent.Properties.Resources._100;
            this.mnuChange_State.Name = "mnuChange_State";
            this.mnuChange_State.Size = new System.Drawing.Size(249, 24);
            this.mnuChange_State.Text = "تغییر وضعیت";
            this.mnuChange_State.Click += new System.EventHandler(this.mnuChange_State_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(246, 6);
            // 
            // frmShow_Check_Daryaft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.panelEx1;
            this.ClientSize = new System.Drawing.Size(1352, 712);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvStore);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShow_Check_Daryaft";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmShow_Check_Daryaft_Activated);
            this.Load += new System.EventHandler(this.frmShow_Check_Daryaft_Load);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuRecive;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvStore;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuReceipt;
        private System.Windows.Forms.ToolStripMenuItem mnuSend;
        private System.Windows.Forms.ToolStripMenuItem mnuSend_Bank;
        private System.Windows.Forms.ToolStripMenuItem mnuSend_Safe;
        private System.Windows.Forms.ToolStripMenuItem mnuDaryaft;
        private System.Windows.Forms.ToolStripMenuItem mnuBack;
        private System.Windows.Forms.ToolStripMenuItem mnuReturn;
        private System.Windows.Forms.ToolStripMenuItem mnuPay;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuShow_All;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sett_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Safe_Reciver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn State_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Name;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuChange_State;
    }
}