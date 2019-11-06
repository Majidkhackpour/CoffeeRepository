namespace Coffee_ManageMent
{
    partial class frmCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheck));
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSearchAcc = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPage_Count = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnd_Page = new System.Windows.Forms.TextBox();
            this.txtStart_Page = new System.Windows.Forms.TextBox();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish1 = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grp1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.Controls.Add(this.btnSearchAcc);
            this.grp1.Controls.Add(this.txtName);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.txtCode);
            this.grp1.Controls.Add(this.txtID);
            this.grp1.Controls.Add(this.label3);
            this.grp1.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp1.Location = new System.Drawing.Point(8, 81);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(476, 84);
            // 
            // 
            // 
            this.grp1.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grp1.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grp1.Style.BackColorGradientAngle = 90;
            this.grp1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp1.Style.BorderBottomWidth = 1;
            this.grp1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grp1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp1.Style.BorderLeftWidth = 1;
            this.grp1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp1.Style.BorderRightWidth = 1;
            this.grp1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp1.Style.BorderTopWidth = 1;
            this.grp1.Style.CornerDiameter = 4;
            this.grp1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp1.Style.TextColor = System.Drawing.Color.Black;
            this.grp1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp1.TabIndex = 0;
            // 
            // btnSearchAcc
            // 
            this.btnSearchAcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchAcc.Location = new System.Drawing.Point(226, 44);
            this.btnSearchAcc.Name = "btnSearchAcc";
            this.btnSearchAcc.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSearchAcc.Size = new System.Drawing.Size(35, 27);
            this.btnSearchAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSearchAcc.TabIndex = 2;
            this.btnSearchAcc.Text = "+";
            this.btnSearchAcc.Click += new System.EventHandler(this.btnSearchAcc_Click);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(21, 44);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(199, 27);
            this.txtName.TabIndex = 3;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(412, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "شناسایی:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(266, 44);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(129, 27);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtID
            // 
            this.txtID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(266, 7);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(129, 27);
            this.txtID.TabIndex = 0;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(407, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "کد حساب:";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtPage_Count);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.txtSeries);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.txtEnd_Page);
            this.groupPanel1.Controls.Add(this.txtStart_Page);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(8, 171);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(476, 118);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupPanel1.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(429, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "سری:";
            // 
            // txtPage_Count
            // 
            this.txtPage_Count.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPage_Count.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPage_Count.Location = new System.Drawing.Point(266, 7);
            this.txtPage_Count.MaxLength = 4;
            this.txtPage_Count.Name = "txtPage_Count";
            this.txtPage_Count.Size = new System.Drawing.Size(129, 27);
            this.txtPage_Count.TabIndex = 0;
            this.txtPage_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPage_Count.TextChanged += new System.EventHandler(this.txtPage_Count_TextChanged);
            this.txtPage_Count.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPage_Count_KeyDown);
            this.txtPage_Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPage_Count_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(401, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "تعداد برگه:";
            // 
            // txtSeries
            // 
            this.txtSeries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSeries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSeries.Location = new System.Drawing.Point(266, 75);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.Size = new System.Drawing.Size(129, 27);
            this.txtSeries.TabIndex = 3;
            this.txtSeries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSeries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSeries_KeyDown);
            this.txtSeries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeries_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(410, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "از شماره:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(184, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "الی:";
            // 
            // txtEnd_Page
            // 
            this.txtEnd_Page.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEnd_Page.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEnd_Page.Enabled = false;
            this.txtEnd_Page.Location = new System.Drawing.Point(21, 41);
            this.txtEnd_Page.Name = "txtEnd_Page";
            this.txtEnd_Page.ReadOnly = true;
            this.txtEnd_Page.Size = new System.Drawing.Size(138, 27);
            this.txtEnd_Page.TabIndex = 2;
            this.txtEnd_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStart_Page
            // 
            this.txtStart_Page.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtStart_Page.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtStart_Page.Location = new System.Drawing.Point(266, 41);
            this.txtStart_Page.Name = "txtStart_Page";
            this.txtStart_Page.Size = new System.Drawing.Size(129, 27);
            this.txtStart_Page.TabIndex = 1;
            this.txtStart_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStart_Page.TextChanged += new System.EventHandler(this.txtStart_Page_TextChanged);
            this.txtStart_Page.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStart_Page_KeyDown);
            this.txtStart_Page.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStart_Page_KeyPress);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(0, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(493, 43);
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
            this.panelEx1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(222, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "مدیریت دسته چک ها";
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
            this.panelEx2.Location = new System.Drawing.Point(125, 21);
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
            this.panelEx2.TabIndex = 36;
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
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnClose);
            this.panelEx3.Controls.Add(this.btnFinish1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(0, 295);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(493, 43);
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
            this.panelEx3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(14, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "انصراف";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFinish1
            // 
            this.btnFinish1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFinish1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish1.Location = new System.Drawing.Point(330, 8);
            this.btnFinish1.Name = "btnFinish1";
            this.btnFinish1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish1.Size = new System.Drawing.Size(142, 25);
            this.btnFinish1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish1.TabIndex = 0;
            this.btnFinish1.Text = "تایید";
            this.btnFinish1.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(493, 338);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.grp1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheck";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCheck_Load);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.Controls.GroupPanel grp1;
        public DevComponents.DotNetBar.ButtonX btnSearchAcc;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPage_Count;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtSeries;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtEnd_Page;
        public System.Windows.Forms.TextBox txtStart_Page;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}