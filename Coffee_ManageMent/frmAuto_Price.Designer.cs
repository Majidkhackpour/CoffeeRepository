namespace Coffee_ManageMent
{
    partial class frmAuto_Price
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuto_Price));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lblPattern_Code = new System.Windows.Forms.Label();
            this.lblPattern_Name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.grpProduct = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.grpProduct2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSearchProduct2 = new DevComponents.DotNetBar.ButtonX();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.btnSearchProduct1 = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode2 = new System.Windows.Forms.TextBox();
            this.txtCode1 = new System.Windows.Forms.TextBox();
            this.grpSelect = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnSelect = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.grpPrice = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.grpSelect2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnPrice = new System.Windows.Forms.RadioButton();
            this.rbtnPercent = new System.Windows.Forms.RadioButton();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnBuy_Price = new System.Windows.Forms.RadioButton();
            this.rbtnPrice_Now = new System.Windows.Forms.RadioButton();
            this.txtRound = new System.Windows.Forms.TextBox();
            this.txtDigit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.grpProduct.SuspendLayout();
            this.grpProduct2.SuspendLayout();
            this.grpSelect.SuspendLayout();
            this.grpPrice.SuspendLayout();
            this.grpSelect2.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lblPattern_Code);
            this.panelEx1.Controls.Add(this.lblPattern_Name);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(0, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(914, 43);
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
            this.panelEx1.TabIndex = 55660;
            // 
            // lblPattern_Code
            // 
            this.lblPattern_Code.AutoSize = true;
            this.lblPattern_Code.Font = new System.Drawing.Font("B Yekan", 12F);
            this.lblPattern_Code.Location = new System.Drawing.Point(382, 8);
            this.lblPattern_Code.Name = "lblPattern_Code";
            this.lblPattern_Code.Size = new System.Drawing.Size(28, 24);
            this.lblPattern_Code.TabIndex = 4;
            this.lblPattern_Code.Text = "00";
            // 
            // lblPattern_Name
            // 
            this.lblPattern_Name.AutoSize = true;
            this.lblPattern_Name.Font = new System.Drawing.Font("B Yekan", 12F);
            this.lblPattern_Name.Location = new System.Drawing.Point(580, 8);
            this.lblPattern_Name.Name = "lblPattern_Name";
            this.lblPattern_Name.Size = new System.Drawing.Size(28, 24);
            this.lblPattern_Name.TabIndex = 4;
            this.lblPattern_Name.Text = "00";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label2.Location = new System.Drawing.Point(438, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "کد";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(696, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "ریز قیمت ها- الگوی قیمت";
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
            this.panelEx2.Location = new System.Drawing.Point(360, 20);
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
            this.panelEx2.TabIndex = 55661;
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
            // grpProduct
            // 
            this.grpProduct.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpProduct.Controls.Add(this.grpProduct2);
            this.grpProduct.Controls.Add(this.grpSelect);
            this.grpProduct.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpProduct.Location = new System.Drawing.Point(438, 82);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(471, 150);
            // 
            // 
            // 
            this.grpProduct.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpProduct.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grpProduct.Style.BackColorGradientAngle = 90;
            this.grpProduct.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct.Style.BorderBottomWidth = 1;
            this.grpProduct.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpProduct.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct.Style.BorderLeftWidth = 1;
            this.grpProduct.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct.Style.BorderRightWidth = 1;
            this.grpProduct.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct.Style.BorderTopWidth = 1;
            this.grpProduct.Style.CornerDiameter = 4;
            this.grpProduct.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpProduct.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpProduct.Style.TextColor = System.Drawing.Color.Black;
            this.grpProduct.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpProduct.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpProduct.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpProduct.TabIndex = 0;
            this.grpProduct.Text = "کالا";
            // 
            // grpProduct2
            // 
            this.grpProduct2.BackColor = System.Drawing.Color.Transparent;
            this.grpProduct2.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpProduct2.Controls.Add(this.btnSearchProduct2);
            this.grpProduct2.Controls.Add(this.txtName2);
            this.grpProduct2.Controls.Add(this.txtName1);
            this.grpProduct2.Controls.Add(this.btnSearchProduct1);
            this.grpProduct2.Controls.Add(this.label3);
            this.grpProduct2.Controls.Add(this.label7);
            this.grpProduct2.Controls.Add(this.txtCode2);
            this.grpProduct2.Controls.Add(this.txtCode1);
            this.grpProduct2.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpProduct2.Location = new System.Drawing.Point(2, 6);
            this.grpProduct2.Name = "grpProduct2";
            this.grpProduct2.Size = new System.Drawing.Size(375, 109);
            // 
            // 
            // 
            this.grpProduct2.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpProduct2.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grpProduct2.Style.BackColorGradientAngle = 90;
            this.grpProduct2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct2.Style.BorderBottomWidth = 1;
            this.grpProduct2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpProduct2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct2.Style.BorderLeftWidth = 1;
            this.grpProduct2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct2.Style.BorderRightWidth = 1;
            this.grpProduct2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpProduct2.Style.BorderTopWidth = 1;
            this.grpProduct2.Style.CornerDiameter = 4;
            this.grpProduct2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpProduct2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpProduct2.Style.TextColor = System.Drawing.Color.Black;
            this.grpProduct2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpProduct2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpProduct2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpProduct2.TabIndex = 1;
            // 
            // btnSearchProduct2
            // 
            this.btnSearchProduct2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchProduct2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchProduct2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchProduct2.Location = new System.Drawing.Point(193, 59);
            this.btnSearchProduct2.Name = "btnSearchProduct2";
            this.btnSearchProduct2.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSearchProduct2.Size = new System.Drawing.Size(35, 27);
            this.btnSearchProduct2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSearchProduct2.TabIndex = 3;
            this.btnSearchProduct2.Text = "+";
            this.btnSearchProduct2.Click += new System.EventHandler(this.btnSearchProduct2_Click);
            // 
            // txtName2
            // 
            this.txtName2.Enabled = false;
            this.txtName2.Location = new System.Drawing.Point(16, 58);
            this.txtName2.Name = "txtName2";
            this.txtName2.ReadOnly = true;
            this.txtName2.Size = new System.Drawing.Size(171, 27);
            this.txtName2.TabIndex = 3;
            this.txtName2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtName1
            // 
            this.txtName1.Enabled = false;
            this.txtName1.Location = new System.Drawing.Point(16, 9);
            this.txtName1.Name = "txtName1";
            this.txtName1.ReadOnly = true;
            this.txtName1.Size = new System.Drawing.Size(171, 27);
            this.txtName1.TabIndex = 3;
            this.txtName1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearchProduct1
            // 
            this.btnSearchProduct1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchProduct1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchProduct1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchProduct1.Location = new System.Drawing.Point(193, 9);
            this.btnSearchProduct1.Name = "btnSearchProduct1";
            this.btnSearchProduct1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSearchProduct1.Size = new System.Drawing.Size(35, 27);
            this.btnSearchProduct1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSearchProduct1.TabIndex = 1;
            this.btnSearchProduct1.Text = "+";
            this.btnSearchProduct1.Click += new System.EventHandler(this.btnSearchProduct1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(341, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "از:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(336, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "الی:";
            // 
            // txtCode2
            // 
            this.txtCode2.Location = new System.Drawing.Point(234, 58);
            this.txtCode2.Name = "txtCode2";
            this.txtCode2.Size = new System.Drawing.Size(90, 27);
            this.txtCode2.TabIndex = 2;
            this.txtCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode2.TextChanged += new System.EventHandler(this.txtCode2_TextChanged);
            this.txtCode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode2_KeyDown);
            this.txtCode2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode2_KeyPress);
            // 
            // txtCode1
            // 
            this.txtCode1.Location = new System.Drawing.Point(234, 9);
            this.txtCode1.Name = "txtCode1";
            this.txtCode1.Size = new System.Drawing.Size(90, 27);
            this.txtCode1.TabIndex = 0;
            this.txtCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode1.TextChanged += new System.EventHandler(this.txtCode1_TextChanged);
            this.txtCode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode1_KeyDown);
            this.txtCode1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode1_KeyPress);
            // 
            // grpSelect
            // 
            this.grpSelect.BackColor = System.Drawing.Color.Transparent;
            this.grpSelect.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpSelect.Controls.Add(this.rbtnSelect);
            this.grpSelect.Controls.Add(this.rbtnAll);
            this.grpSelect.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpSelect.Location = new System.Drawing.Point(384, 6);
            this.grpSelect.Name = "grpSelect";
            this.grpSelect.Size = new System.Drawing.Size(78, 109);
            // 
            // 
            // 
            this.grpSelect.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpSelect.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grpSelect.Style.BackColorGradientAngle = 90;
            this.grpSelect.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect.Style.BorderBottomWidth = 1;
            this.grpSelect.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpSelect.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect.Style.BorderLeftWidth = 1;
            this.grpSelect.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect.Style.BorderRightWidth = 1;
            this.grpSelect.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect.Style.BorderTopWidth = 1;
            this.grpSelect.Style.CornerDiameter = 4;
            this.grpSelect.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpSelect.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpSelect.Style.TextColor = System.Drawing.Color.Black;
            this.grpSelect.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpSelect.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpSelect.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpSelect.TabIndex = 0;
            // 
            // rbtnSelect
            // 
            this.rbtnSelect.AutoSize = true;
            this.rbtnSelect.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSelect.Location = new System.Drawing.Point(3, 59);
            this.rbtnSelect.Name = "rbtnSelect";
            this.rbtnSelect.Size = new System.Drawing.Size(63, 24);
            this.rbtnSelect.TabIndex = 1;
            this.rbtnSelect.TabStop = true;
            this.rbtnSelect.Text = "محدوده";
            this.rbtnSelect.UseVisualStyleBackColor = false;
            this.rbtnSelect.CheckedChanged += new System.EventHandler(this.rbtnSelect_CheckedChanged);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.BackColor = System.Drawing.Color.Transparent;
            this.rbtnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAll.Location = new System.Drawing.Point(19, 12);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(47, 24);
            this.rbtnAll.TabIndex = 0;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "همه";
            this.rbtnAll.UseVisualStyleBackColor = false;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // grpPrice
            // 
            this.grpPrice.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPrice.Controls.Add(this.grpSelect2);
            this.grpPrice.Controls.Add(this.groupPanel5);
            this.grpPrice.Controls.Add(this.txtRound);
            this.grpPrice.Controls.Add(this.txtDigit);
            this.grpPrice.Controls.Add(this.label1);
            this.grpPrice.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPrice.Location = new System.Drawing.Point(7, 82);
            this.grpPrice.Name = "grpPrice";
            this.grpPrice.Size = new System.Drawing.Size(425, 150);
            // 
            // 
            // 
            this.grpPrice.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpPrice.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grpPrice.Style.BackColorGradientAngle = 90;
            this.grpPrice.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrice.Style.BorderBottomWidth = 1;
            this.grpPrice.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpPrice.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrice.Style.BorderLeftWidth = 1;
            this.grpPrice.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrice.Style.BorderRightWidth = 1;
            this.grpPrice.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrice.Style.BorderTopWidth = 1;
            this.grpPrice.Style.CornerDiameter = 4;
            this.grpPrice.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpPrice.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpPrice.Style.TextColor = System.Drawing.Color.Black;
            this.grpPrice.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpPrice.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpPrice.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpPrice.TabIndex = 1;
            this.grpPrice.Text = "اصلاح قیمت";
            // 
            // grpSelect2
            // 
            this.grpSelect2.BackColor = System.Drawing.Color.Transparent;
            this.grpSelect2.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpSelect2.Controls.Add(this.rbtnPrice);
            this.grpSelect2.Controls.Add(this.rbtnPercent);
            this.grpSelect2.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpSelect2.Location = new System.Drawing.Point(336, 6);
            this.grpSelect2.Name = "grpSelect2";
            this.grpSelect2.Size = new System.Drawing.Size(78, 109);
            // 
            // 
            // 
            this.grpSelect2.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpSelect2.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grpSelect2.Style.BackColorGradientAngle = 90;
            this.grpSelect2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect2.Style.BorderBottomWidth = 1;
            this.grpSelect2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpSelect2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect2.Style.BorderLeftWidth = 1;
            this.grpSelect2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect2.Style.BorderRightWidth = 1;
            this.grpSelect2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpSelect2.Style.BorderTopWidth = 1;
            this.grpSelect2.Style.CornerDiameter = 4;
            this.grpSelect2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpSelect2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpSelect2.Style.TextColor = System.Drawing.Color.Black;
            this.grpSelect2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpSelect2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpSelect2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpSelect2.TabIndex = 0;
            // 
            // rbtnPrice
            // 
            this.rbtnPrice.AutoSize = true;
            this.rbtnPrice.BackColor = System.Drawing.Color.Transparent;
            this.rbtnPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnPrice.Location = new System.Drawing.Point(22, 59);
            this.rbtnPrice.Name = "rbtnPrice";
            this.rbtnPrice.Size = new System.Drawing.Size(47, 24);
            this.rbtnPrice.TabIndex = 1;
            this.rbtnPrice.TabStop = true;
            this.rbtnPrice.Text = "مبلغ";
            this.rbtnPrice.UseVisualStyleBackColor = false;
            // 
            // rbtnPercent
            // 
            this.rbtnPercent.AutoSize = true;
            this.rbtnPercent.BackColor = System.Drawing.Color.Transparent;
            this.rbtnPercent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnPercent.Location = new System.Drawing.Point(13, 12);
            this.rbtnPercent.Name = "rbtnPercent";
            this.rbtnPercent.Size = new System.Drawing.Size(56, 24);
            this.rbtnPercent.TabIndex = 0;
            this.rbtnPercent.TabStop = true;
            this.rbtnPercent.Text = "درصد";
            this.rbtnPercent.UseVisualStyleBackColor = false;
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.Controls.Add(this.rbtnBuy_Price);
            this.groupPanel5.Controls.Add(this.rbtnPrice_Now);
            this.groupPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel5.Location = new System.Drawing.Point(7, 61);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(310, 54);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupPanel5.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 4;
            // 
            // rbtnBuy_Price
            // 
            this.rbtnBuy_Price.AutoSize = true;
            this.rbtnBuy_Price.BackColor = System.Drawing.Color.Transparent;
            this.rbtnBuy_Price.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBuy_Price.Location = new System.Drawing.Point(51, 11);
            this.rbtnBuy_Price.Name = "rbtnBuy_Price";
            this.rbtnBuy_Price.Size = new System.Drawing.Size(82, 24);
            this.rbtnBuy_Price.TabIndex = 1;
            this.rbtnBuy_Price.TabStop = true;
            this.rbtnBuy_Price.Text = "قیمت خرید";
            this.rbtnBuy_Price.UseVisualStyleBackColor = false;
            // 
            // rbtnPrice_Now
            // 
            this.rbtnPrice_Now.AutoSize = true;
            this.rbtnPrice_Now.BackColor = System.Drawing.Color.Transparent;
            this.rbtnPrice_Now.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnPrice_Now.Location = new System.Drawing.Point(220, 11);
            this.rbtnPrice_Now.Name = "rbtnPrice_Now";
            this.rbtnPrice_Now.Size = new System.Drawing.Size(81, 24);
            this.rbtnPrice_Now.TabIndex = 0;
            this.rbtnPrice_Now.TabStop = true;
            this.rbtnPrice_Now.Text = "قیمت فعلی";
            this.rbtnPrice_Now.UseVisualStyleBackColor = false;
            // 
            // txtRound
            // 
            this.txtRound.Location = new System.Drawing.Point(5, 20);
            this.txtRound.MaxLength = 1;
            this.txtRound.Name = "txtRound";
            this.txtRound.Size = new System.Drawing.Size(52, 27);
            this.txtRound.TabIndex = 2;
            this.txtRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRound.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRound_KeyDown);
            this.txtRound.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRound_KeyPress);
            // 
            // txtDigit
            // 
            this.txtDigit.Location = new System.Drawing.Point(189, 20);
            this.txtDigit.Name = "txtDigit";
            this.txtDigit.Size = new System.Drawing.Size(128, 27);
            this.txtDigit.TabIndex = 3;
            this.txtDigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDigit.TextChanged += new System.EventHandler(this.txtDigit_TextChanged);
            this.txtDigit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDigit_KeyDown);
            this.txtDigit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(61, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "تعداد رقم گرد کردن:";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnClose);
            this.panelEx3.Controls.Add(this.btnFinish);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(1, 237);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(913, 43);
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
            this.btnClose.Location = new System.Drawing.Point(16, 8);
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
            this.btnFinish.Location = new System.Drawing.Point(734, 8);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish.Size = new System.Drawing.Size(142, 25);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "تایید";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            // frmAuto_Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(915, 281);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.grpPrice);
            this.Controls.Add(this.grpProduct);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuto_Price";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAuto_Price_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grpProduct.ResumeLayout(false);
            this.grpProduct2.ResumeLayout(false);
            this.grpProduct2.PerformLayout();
            this.grpSelect.ResumeLayout(false);
            this.grpSelect.PerformLayout();
            this.grpPrice.ResumeLayout(false);
            this.grpPrice.PerformLayout();
            this.grpSelect2.ResumeLayout(false);
            this.grpSelect2.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.Label lblPattern_Code;
        public System.Windows.Forms.Label lblPattern_Name;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        public DevComponents.DotNetBar.Controls.GroupPanel grpProduct;
        public DevComponents.DotNetBar.Controls.GroupPanel grpProduct2;
        public DevComponents.DotNetBar.Controls.GroupPanel grpSelect;
        public DevComponents.DotNetBar.ButtonX btnSearchProduct1;
        public System.Windows.Forms.TextBox txtName1;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCode1;
        public System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.ButtonX btnSearchProduct2;
        public System.Windows.Forms.TextBox txtName2;
        public System.Windows.Forms.TextBox txtCode2;
        private System.Windows.Forms.RadioButton rbtnSelect;
        private System.Windows.Forms.RadioButton rbtnAll;
        public DevComponents.DotNetBar.Controls.GroupPanel grpPrice;
        public DevComponents.DotNetBar.Controls.GroupPanel grpSelect2;
        private System.Windows.Forms.RadioButton rbtnPrice;
        private System.Windows.Forms.RadioButton rbtnPercent;
        public System.Windows.Forms.TextBox txtRound;
        public System.Windows.Forms.TextBox txtDigit;
        public System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private System.Windows.Forms.RadioButton rbtnBuy_Price;
        private System.Windows.Forms.RadioButton rbtnPrice_Now;
    }
}