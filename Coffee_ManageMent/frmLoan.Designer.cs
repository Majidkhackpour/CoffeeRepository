namespace Coffee_ManageMent
{
    partial class frmLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoan));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtDate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.grp2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtExpiration_Date = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirst_Price = new System.Windows.Forms.TextBox();
            this.txtProfit_Price = new System.Windows.Forms.TextBox();
            this.txtInstall_Count = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSearchAcc = new DevComponents.DotNetBar.ButtonX();
            this.txtProfit_Percent = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFirst_Install = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotal_Price = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOther_Install = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grp3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.grp2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.grp1.SuspendLayout();
            this.grp3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Location = new System.Drawing.Point(566, 8);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish.Size = new System.Drawing.Size(142, 25);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "تایید";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnClose);
            this.panelEx3.Controls.Add(this.btnFinish);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(1, 412);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(725, 43);
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
            this.panelEx3.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtDate
            // 
            // 
            // 
            // 
            this.txtDate.BackgroundStyle.Class = "TextBoxBorder";
            this.txtDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.ButtonClear.Visible = true;
            this.txtDate.Location = new System.Drawing.Point(385, 62);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(224, 26);
            this.txtDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtDate.TabIndex = 2;
            this.txtDate.Text = "";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // grp2
            // 
            this.grp2.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp2.Controls.Add(this.label10);
            this.grp2.Controls.Add(this.txtNumber);
            this.grp2.Controls.Add(this.txtExpiration_Date);
            this.grp2.Controls.Add(this.label12);
            this.grp2.Controls.Add(this.txtDate);
            this.grp2.Controls.Add(this.label1);
            this.grp2.Controls.Add(this.label8);
            this.grp2.Controls.Add(this.txtType);
            this.grp2.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp2.Location = new System.Drawing.Point(9, 138);
            this.grp2.Name = "grp2";
            this.grp2.Size = new System.Drawing.Size(710, 113);
            // 
            // 
            // 
            this.grp2.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grp2.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grp2.Style.BackColorGradientAngle = 90;
            this.grp2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderBottomWidth = 1;
            this.grp2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grp2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderLeftWidth = 1;
            this.grp2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderRightWidth = 1;
            this.grp2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderTopWidth = 1;
            this.grp2.Style.CornerDiameter = 4;
            this.grp2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp2.Style.TextColor = System.Drawing.Color.Black;
            this.grp2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(615, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "شماره تسهیلات:";
            // 
            // txtNumber
            // 
            this.txtNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNumber.Location = new System.Drawing.Point(385, 15);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(224, 27);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyDown);
            // 
            // txtExpiration_Date
            // 
            // 
            // 
            // 
            this.txtExpiration_Date.BackgroundStyle.Class = "TextBoxBorder";
            this.txtExpiration_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExpiration_Date.ButtonClear.Visible = true;
            this.txtExpiration_Date.Location = new System.Drawing.Point(28, 62);
            this.txtExpiration_Date.Mask = "0000/00/00";
            this.txtExpiration_Date.Name = "txtExpiration_Date";
            this.txtExpiration_Date.Size = new System.Drawing.Size(224, 26);
            this.txtExpiration_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtExpiration_Date.TabIndex = 3;
            this.txtExpiration_Date.Text = "";
            this.txtExpiration_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExpiration_Date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExpiration_Date_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(250, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 34;
            this.label12.Text = "سررسید نهایی:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(607, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "اولین بازپرداخت:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(258, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "نوع تسهیلات:";
            // 
            // txtType
            // 
            this.txtType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtType.Location = new System.Drawing.Point(28, 15);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(224, 27);
            this.txtType.TabIndex = 1;
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtType_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(355, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "ریال";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(265, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "مبلغ تقسیط:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(460, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "تعداد اقساط:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(634, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "مبلغ اعطایی:";
            // 
            // txtFirst_Price
            // 
            this.txtFirst_Price.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFirst_Price.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFirst_Price.Location = new System.Drawing.Point(394, 11);
            this.txtFirst_Price.Name = "txtFirst_Price";
            this.txtFirst_Price.Size = new System.Drawing.Size(215, 27);
            this.txtFirst_Price.TabIndex = 0;
            this.txtFirst_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFirst_Price.TextChanged += new System.EventHandler(this.txtFirst_Price_TextChanged);
            this.txtFirst_Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirst_Price_KeyDown);
            this.txtFirst_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirst_Price_KeyPress);
            // 
            // txtProfit_Price
            // 
            this.txtProfit_Price.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProfit_Price.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProfit_Price.Location = new System.Drawing.Point(65, 104);
            this.txtProfit_Price.Name = "txtProfit_Price";
            this.txtProfit_Price.Size = new System.Drawing.Size(187, 27);
            this.txtProfit_Price.TabIndex = 6;
            this.txtProfit_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProfit_Price.TextChanged += new System.EventHandler(this.txtProfit_Price_TextChanged);
            this.txtProfit_Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProfit_Price_KeyDown);
            this.txtProfit_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfit_Price_KeyPress);
            // 
            // txtInstall_Count
            // 
            this.txtInstall_Count.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtInstall_Count.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtInstall_Count.Location = new System.Drawing.Point(394, 56);
            this.txtInstall_Count.Name = "txtInstall_Count";
            this.txtInstall_Count.Size = new System.Drawing.Size(60, 27);
            this.txtInstall_Count.TabIndex = 3;
            this.txtInstall_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInstall_Count.TextChanged += new System.EventHandler(this.txtInstall_Count_TextChanged);
            this.txtInstall_Count.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInstall_Count_KeyDown);
            this.txtInstall_Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInstall_Count_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(648, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "شناسایی:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(525, 10);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(99, 27);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(647, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "نرخ سود:";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(1, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(725, 43);
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
            this.panelEx1.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(331, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "مدیریت وام های پرداختنی";
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
            this.panelEx2.Location = new System.Drawing.Point(259, 20);
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
            this.panelEx2.TabIndex = 39;
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
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(28, 10);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(450, 27);
            this.txtName.TabIndex = 2;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.Controls.Add(this.btnSearchAcc);
            this.grp1.Controls.Add(this.txtName);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.txtCode);
            this.grp1.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp1.Location = new System.Drawing.Point(9, 82);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(710, 50);
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
            this.btnSearchAcc.Location = new System.Drawing.Point(484, 10);
            this.btnSearchAcc.Name = "btnSearchAcc";
            this.btnSearchAcc.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSearchAcc.Size = new System.Drawing.Size(35, 27);
            this.btnSearchAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSearchAcc.TabIndex = 1;
            this.btnSearchAcc.Text = "+";
            this.btnSearchAcc.Click += new System.EventHandler(this.btnSearchAcc_Click);
            // 
            // txtProfit_Percent
            // 
            this.txtProfit_Percent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProfit_Percent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProfit_Percent.Location = new System.Drawing.Point(559, 56);
            this.txtProfit_Percent.Name = "txtProfit_Percent";
            this.txtProfit_Percent.Size = new System.Drawing.Size(50, 27);
            this.txtProfit_Percent.TabIndex = 2;
            this.txtProfit_Percent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProfit_Percent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProfit_Percent_KeyDown);
            this.txtProfit_Percent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfit_Percent_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(538, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "%";
            // 
            // txtFirst_Install
            // 
            this.txtFirst_Install.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFirst_Install.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFirst_Install.Location = new System.Drawing.Point(65, 56);
            this.txtFirst_Install.Name = "txtFirst_Install";
            this.txtFirst_Install.Size = new System.Drawing.Size(187, 27);
            this.txtFirst_Install.TabIndex = 4;
            this.txtFirst_Install.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFirst_Install.TextChanged += new System.EventHandler(this.txtFirst_Install_TextChanged);
            this.txtFirst_Install.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirst_Install_KeyDown);
            this.txtFirst_Install.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirst_Install_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(274, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "قسط اول:";
            // 
            // txtTotal_Price
            // 
            this.txtTotal_Price.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTotal_Price.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTotal_Price.Location = new System.Drawing.Point(65, 11);
            this.txtTotal_Price.Name = "txtTotal_Price";
            this.txtTotal_Price.Size = new System.Drawing.Size(187, 27);
            this.txtTotal_Price.TabIndex = 1;
            this.txtTotal_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotal_Price.TextChanged += new System.EventHandler(this.txtTotal_Price_TextChanged);
            this.txtTotal_Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTotal_Price_KeyDown);
            this.txtTotal_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_Price_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(633, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 20);
            this.label14.TabIndex = 34;
            this.label14.Text = "سایر اقساط:";
            // 
            // txtOther_Install
            // 
            this.txtOther_Install.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOther_Install.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtOther_Install.Location = new System.Drawing.Point(394, 104);
            this.txtOther_Install.Name = "txtOther_Install";
            this.txtOther_Install.Size = new System.Drawing.Size(215, 27);
            this.txtOther_Install.TabIndex = 5;
            this.txtOther_Install.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOther_Install.TextChanged += new System.EventHandler(this.txtOther_Install_TextChanged);
            this.txtOther_Install.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOther_Install_KeyDown);
            this.txtOther_Install.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOther_Install_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(256, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "مبلغ پرداختی:";
            // 
            // grp3
            // 
            this.grp3.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp3.Controls.Add(this.label5);
            this.grp3.Controls.Add(this.txtFirst_Price);
            this.grp3.Controls.Add(this.label13);
            this.grp3.Controls.Add(this.txtProfit_Price);
            this.grp3.Controls.Add(this.label14);
            this.grp3.Controls.Add(this.label2);
            this.grp3.Controls.Add(this.label6);
            this.grp3.Controls.Add(this.label19);
            this.grp3.Controls.Add(this.label17);
            this.grp3.Controls.Add(this.label16);
            this.grp3.Controls.Add(this.label18);
            this.grp3.Controls.Add(this.label9);
            this.grp3.Controls.Add(this.txtOther_Install);
            this.grp3.Controls.Add(this.label11);
            this.grp3.Controls.Add(this.txtFirst_Install);
            this.grp3.Controls.Add(this.label15);
            this.grp3.Controls.Add(this.txtTotal_Price);
            this.grp3.Controls.Add(this.label3);
            this.grp3.Controls.Add(this.txtProfit_Percent);
            this.grp3.Controls.Add(this.txtInstall_Count);
            this.grp3.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp3.Location = new System.Drawing.Point(9, 257);
            this.grp3.Name = "grp3";
            this.grp3.Size = new System.Drawing.Size(710, 150);
            // 
            // 
            // 
            this.grp3.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grp3.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grp3.Style.BackColorGradientAngle = 90;
            this.grp3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderBottomWidth = 1;
            this.grp3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grp3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderLeftWidth = 1;
            this.grp3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderRightWidth = 1;
            this.grp3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderTopWidth = 1;
            this.grp3.Style.CornerDiameter = 4;
            this.grp3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp3.Style.TextColor = System.Drawing.Color.Black;
            this.grp3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp3.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(28, 107);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 20);
            this.label19.TabIndex = 39;
            this.label19.Text = "ریال";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(28, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 20);
            this.label17.TabIndex = 39;
            this.label17.Text = "ریال";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(28, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 20);
            this.label16.TabIndex = 39;
            this.label16.Text = "ریال";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(355, 107);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 20);
            this.label18.TabIndex = 39;
            this.label18.Text = "ریال";
            // 
            // frmLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(727, 455);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.grp3);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.grp1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.grp2.ResumeLayout(false);
            this.grp2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.grp3.ResumeLayout(false);
            this.grp3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        public DevComponents.DotNetBar.Controls.GroupPanel grp2;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtDate;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtFirst_Price;
        public System.Windows.Forms.TextBox txtProfit_Price;
        public System.Windows.Forms.TextBox txtNumber;
        public System.Windows.Forms.TextBox txtInstall_Count;
        public System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        public DevComponents.DotNetBar.Controls.GroupPanel grp1;
        public DevComponents.DotNetBar.ButtonX btnSearchAcc;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.TextBox txtType;
        public DevComponents.DotNetBar.Controls.GroupPanel grp3;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtOther_Install;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtFirst_Install;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtTotal_Price;
        public System.Windows.Forms.TextBox txtProfit_Percent;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtExpiration_Date;
        public System.Windows.Forms.Label label12;
    }
}