namespace Coffee_ManageMent
{
    partial class frmShow_Personnel_Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow_Personnel_Log));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.dgvStore = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.Radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Per_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mounth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ez_Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ez_Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kasr_Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kasr_Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoz_Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoz_Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(1, 0);
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
            this.panelEx1.TabIndex = 55739;
            this.panelEx1.Click += new System.EventHandler(this.panelEx1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(920, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(337, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "نمایش تردد پرسنل";
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
            this.Radif,
            this.Per_ID,
            this.Guid,
            this.Description,
            this.Year,
            this.Mounth,
            this.Day,
            this.Type_Name,
            this.Min,
            this.Hour,
            this.Ez_Min,
            this.Ez_Hour,
            this.Kasr_Min,
            this.Kasr_Hour,
            this.Hoz_Min,
            this.Hoz_Hour});
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
            this.dgvStore.Location = new System.Drawing.Point(9, 112);
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
            this.dgvStore.TabIndex = 55737;
            this.dgvStore.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStore_CellFormatting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView,
            this.mnuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 74);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Coffee_ManageMent.Properties.Resources._02;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(179, 24);
            this.mnuView.Text = "مشاهده فیش حقوقی";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
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
            this.panelEx2.Location = new System.Drawing.Point(577, 19);
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
            this.panelEx2.TabIndex = 55740;
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.lblCounter);
            this.panelEx3.Controls.Add(this.label1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(1, 669);
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
            this.panelEx3.TabIndex = 55741;
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
            this.label1.Text = "تعداد تردد ثبت شده:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(372, 79);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(593, 27);
            this.txtSearch.TabIndex = 55738;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Coffee_ManageMent.Properties.Resources.delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(179, 24);
            this.mnuDelete.Text = "حذف عملیات";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // Radif
            // 
            this.Radif.FillWeight = 35.90965F;
            this.Radif.HeaderText = "ردیف";
            this.Radif.Name = "Radif";
            this.Radif.ReadOnly = true;
            // 
            // Per_ID
            // 
            this.Per_ID.DataPropertyName = "Per_ID";
            this.Per_ID.HeaderText = "Per_ID";
            this.Per_ID.Name = "Per_ID";
            this.Per_ID.ReadOnly = true;
            this.Per_ID.Visible = false;
            // 
            // Guid
            // 
            this.Guid.DataPropertyName = "Guid";
            this.Guid.HeaderText = "Guid";
            this.Guid.Name = "Guid";
            this.Guid.ReadOnly = true;
            this.Guid.Visible = false;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 211.9555F;
            this.Description.HeaderText = "پرسنل";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.FillWeight = 62.89984F;
            this.Year.HeaderText = "سال";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            // 
            // Mounth
            // 
            this.Mounth.DataPropertyName = "Mounth";
            this.Mounth.FillWeight = 82.08472F;
            this.Mounth.HeaderText = "ماه";
            this.Mounth.Name = "Mounth";
            this.Mounth.ReadOnly = true;
            // 
            // Day
            // 
            this.Day.DataPropertyName = "Day";
            dataGridViewCellStyle3.NullValue = null;
            this.Day.DefaultCellStyle = dataGridViewCellStyle3;
            this.Day.FillWeight = 99.37297F;
            this.Day.HeaderText = "روز";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // Type_Name
            // 
            this.Type_Name.DataPropertyName = "Type_Name";
            this.Type_Name.FillWeight = 80.37997F;
            this.Type_Name.HeaderText = "عملیات";
            this.Type_Name.Name = "Type_Name";
            this.Type_Name.ReadOnly = true;
            // 
            // Min
            // 
            this.Min.DataPropertyName = "Min";
            this.Min.FillWeight = 80.37997F;
            this.Min.HeaderText = "دقیقه";
            this.Min.Name = "Min";
            this.Min.ReadOnly = true;
            // 
            // Hour
            // 
            this.Hour.DataPropertyName = "Hour";
            this.Hour.FillWeight = 105.5512F;
            this.Hour.HeaderText = "ساعت";
            this.Hour.Name = "Hour";
            this.Hour.ReadOnly = true;
            // 
            // Ez_Min
            // 
            this.Ez_Min.DataPropertyName = "Ez_Min";
            this.Ez_Min.FillWeight = 105.5512F;
            this.Ez_Min.HeaderText = "دقیقه اضافه";
            this.Ez_Min.Name = "Ez_Min";
            this.Ez_Min.ReadOnly = true;
            // 
            // Ez_Hour
            // 
            this.Ez_Hour.DataPropertyName = "Ez_Hour";
            this.Ez_Hour.FillWeight = 105.5512F;
            this.Ez_Hour.HeaderText = "ساعت اضافه";
            this.Ez_Hour.Name = "Ez_Hour";
            this.Ez_Hour.ReadOnly = true;
            // 
            // Kasr_Min
            // 
            this.Kasr_Min.DataPropertyName = "Kasr_Min";
            this.Kasr_Min.FillWeight = 105.5512F;
            this.Kasr_Min.HeaderText = "دقیقه کسر";
            this.Kasr_Min.Name = "Kasr_Min";
            this.Kasr_Min.ReadOnly = true;
            // 
            // Kasr_Hour
            // 
            this.Kasr_Hour.DataPropertyName = "Kasr_Hour";
            this.Kasr_Hour.FillWeight = 105.5512F;
            this.Kasr_Hour.HeaderText = "ساعت کسر";
            this.Kasr_Hour.Name = "Kasr_Hour";
            this.Kasr_Hour.ReadOnly = true;
            // 
            // Hoz_Min
            // 
            this.Hoz_Min.DataPropertyName = "Hoz_Min";
            this.Hoz_Min.FillWeight = 105.5512F;
            this.Hoz_Min.HeaderText = "دقیقه حضور";
            this.Hoz_Min.Name = "Hoz_Min";
            this.Hoz_Min.ReadOnly = true;
            // 
            // Hoz_Hour
            // 
            this.Hoz_Hour.DataPropertyName = "Hoz_Hour";
            this.Hoz_Hour.FillWeight = 105.5512F;
            this.Hoz_Hour.HeaderText = "ساعت حضور";
            this.Hoz_Hour.Name = "Hoz_Hour";
            this.Hoz_Hour.ReadOnly = true;
            // 
            // frmShow_Personnel_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.panelEx1;
            this.ClientSize = new System.Drawing.Size(1348, 712);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.dgvStore);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShow_Personnel_Log";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmShow_Personnel_Log_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvStore;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Per_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mounth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ez_Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ez_Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kasr_Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kasr_Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoz_Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoz_Hour;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    }
}