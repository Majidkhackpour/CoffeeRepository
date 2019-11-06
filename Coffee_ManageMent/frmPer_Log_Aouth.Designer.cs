namespace Coffee_ManageMent
{
    partial class frmPer_Log_Aouth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPer_Log_Aouth));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpAccount = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAccount = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblEsfand = new System.Windows.Forms.Label();
            this.lblAzar = new System.Windows.Forms.Label();
            this.lblShahrivar = new System.Windows.Forms.Label();
            this.lblKhordad = new System.Windows.Forms.Label();
            this.lblBahman = new System.Windows.Forms.Label();
            this.lblAban = new System.Windows.Forms.Label();
            this.lblMordad = new System.Windows.Forms.Label();
            this.lblOrdibehesht = new System.Windows.Forms.Label();
            this.lblDey = new System.Windows.Forms.Label();
            this.lblMehr = new System.Windows.Forms.Label();
            this.lblTir = new System.Windows.Forms.Label();
            this.lblFarvardin = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblMounth = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.grpAccount.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(388, 43);
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
            this.panelEx1.TabIndex = 14;
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Coffee_ManageMent.Properties.Resources.closeicon;
            this.picClose.Location = new System.Drawing.Point(18, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 18);
            this.picClose.TabIndex = 12;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(88, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "انتخاب مشخصات فیش حقوقی";
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
            this.panelEx2.Location = new System.Drawing.Point(90, 21);
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
            this.panelEx2.TabIndex = 15;
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
            this.lblDay.Location = new System.Drawing.Point(171, 27);
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
            this.panelEx3.Controls.Add(this.btnFinish);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(2, 382);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(388, 43);
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
            this.panelEx3.TabIndex = 19;
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
            this.btnFinish.Location = new System.Drawing.Point(231, 8);
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
            // grpAccount
            // 
            this.grpAccount.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpAccount.Controls.Add(this.txtDescription);
            this.grpAccount.Controls.Add(this.txtAccCode);
            this.grpAccount.Controls.Add(this.label3);
            this.grpAccount.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpAccount.Enabled = false;
            this.grpAccount.Location = new System.Drawing.Point(2, 82);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(388, 46);
            // 
            // 
            // 
            this.grpAccount.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpAccount.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grpAccount.Style.BackColorGradientAngle = 90;
            this.grpAccount.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpAccount.Style.BorderBottomWidth = 1;
            this.grpAccount.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpAccount.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpAccount.Style.BorderLeftWidth = 1;
            this.grpAccount.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpAccount.Style.BorderRightWidth = 1;
            this.grpAccount.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpAccount.Style.BorderTopWidth = 1;
            this.grpAccount.Style.CornerDiameter = 4;
            this.grpAccount.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpAccount.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpAccount.Style.TextColor = System.Drawing.Color.Black;
            this.grpAccount.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpAccount.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpAccount.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpAccount.TabIndex = 20;
            // 
            // txtDescription
            // 
            this.txtDescription.HideSelection = false;
            this.txtDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDescription.Location = new System.Drawing.Point(3, 7);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(205, 27);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAccCode
            // 
            this.txtAccCode.Enabled = false;
            this.txtAccCode.Location = new System.Drawing.Point(214, 7);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.ReadOnly = true;
            this.txtAccCode.Size = new System.Drawing.Size(100, 27);
            this.txtAccCode.TabIndex = 1;
            this.txtAccCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(322, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "شناسایی:";
            // 
            // cmbAccount
            // 
            this.cmbAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAccount.DisplayMember = "Text";
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.ForeColor = System.Drawing.Color.Black;
            this.cmbAccount.ItemHeight = 20;
            this.cmbAccount.Location = new System.Drawing.Point(124, 7);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(141, 28);
            this.cmbAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAccount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(271, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "انتخاب سال مالی:";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.Controls.Add(this.cmbAccount);
            this.groupPanel1.Controls.Add(this.lblEsfand);
            this.groupPanel1.Controls.Add(this.lblAzar);
            this.groupPanel1.Controls.Add(this.lblShahrivar);
            this.groupPanel1.Controls.Add(this.lblKhordad);
            this.groupPanel1.Controls.Add(this.lblBahman);
            this.groupPanel1.Controls.Add(this.lblAban);
            this.groupPanel1.Controls.Add(this.lblMordad);
            this.groupPanel1.Controls.Add(this.lblOrdibehesht);
            this.groupPanel1.Controls.Add(this.lblDey);
            this.groupPanel1.Controls.Add(this.lblMehr);
            this.groupPanel1.Controls.Add(this.lblTir);
            this.groupPanel1.Controls.Add(this.lblFarvardin);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(2, 134);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(388, 208);
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
            this.groupPanel1.TabIndex = 20;
            // 
            // lblEsfand
            // 
            this.lblEsfand.AutoSize = true;
            this.lblEsfand.BackColor = System.Drawing.Color.Transparent;
            this.lblEsfand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEsfand.Location = new System.Drawing.Point(7, 171);
            this.lblEsfand.Name = "lblEsfand";
            this.lblEsfand.Size = new System.Drawing.Size(75, 20);
            this.lblEsfand.TabIndex = 12;
            this.lblEsfand.Text = "اسفند (F12)";
            this.lblEsfand.Click += new System.EventHandler(this.lblEsfand_Click);
            this.lblEsfand.MouseEnter += new System.EventHandler(this.lblEsfand_MouseEnter);
            this.lblEsfand.MouseLeave += new System.EventHandler(this.lblEsfand_MouseLeave);
            // 
            // lblAzar
            // 
            this.lblAzar.AutoSize = true;
            this.lblAzar.BackColor = System.Drawing.Color.Transparent;
            this.lblAzar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAzar.Location = new System.Drawing.Point(28, 134);
            this.lblAzar.Name = "lblAzar";
            this.lblAzar.Size = new System.Drawing.Size(54, 20);
            this.lblAzar.TabIndex = 12;
            this.lblAzar.Text = "آذر (F9)";
            this.lblAzar.Click += new System.EventHandler(this.lblAzar_Click);
            this.lblAzar.MouseEnter += new System.EventHandler(this.lblAzar_MouseEnter);
            this.lblAzar.MouseLeave += new System.EventHandler(this.lblAzar_MouseLeave);
            // 
            // lblShahrivar
            // 
            this.lblShahrivar.AutoSize = true;
            this.lblShahrivar.BackColor = System.Drawing.Color.Transparent;
            this.lblShahrivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShahrivar.Location = new System.Drawing.Point(8, 98);
            this.lblShahrivar.Name = "lblShahrivar";
            this.lblShahrivar.Size = new System.Drawing.Size(74, 20);
            this.lblShahrivar.TabIndex = 12;
            this.lblShahrivar.Text = "شهریور (F6)";
            this.lblShahrivar.Click += new System.EventHandler(this.lblShahrivar_Click);
            this.lblShahrivar.MouseEnter += new System.EventHandler(this.lblShahrivar_MouseEnter);
            this.lblShahrivar.MouseLeave += new System.EventHandler(this.lblShahrivar_MouseLeave);
            // 
            // lblKhordad
            // 
            this.lblKhordad.AutoSize = true;
            this.lblKhordad.BackColor = System.Drawing.Color.Transparent;
            this.lblKhordad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKhordad.Location = new System.Drawing.Point(15, 62);
            this.lblKhordad.Name = "lblKhordad";
            this.lblKhordad.Size = new System.Drawing.Size(67, 20);
            this.lblKhordad.TabIndex = 12;
            this.lblKhordad.Text = "خرداد (F3)";
            this.lblKhordad.Click += new System.EventHandler(this.lblKhordad_Click);
            this.lblKhordad.MouseEnter += new System.EventHandler(this.lblKhordad_MouseEnter);
            this.lblKhordad.MouseLeave += new System.EventHandler(this.lblKhordad_MouseLeave);
            // 
            // lblBahman
            // 
            this.lblBahman.AutoSize = true;
            this.lblBahman.BackColor = System.Drawing.Color.Transparent;
            this.lblBahman.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBahman.Location = new System.Drawing.Point(156, 171);
            this.lblBahman.Name = "lblBahman";
            this.lblBahman.Size = new System.Drawing.Size(70, 20);
            this.lblBahman.TabIndex = 12;
            this.lblBahman.Text = "بهمن (F11)";
            this.lblBahman.Click += new System.EventHandler(this.lblBahman_Click);
            this.lblBahman.MouseEnter += new System.EventHandler(this.lblBahman_MouseEnter);
            this.lblBahman.MouseLeave += new System.EventHandler(this.lblBahman_MouseLeave);
            // 
            // lblAban
            // 
            this.lblAban.AutoSize = true;
            this.lblAban.BackColor = System.Drawing.Color.Transparent;
            this.lblAban.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAban.Location = new System.Drawing.Point(169, 134);
            this.lblAban.Name = "lblAban";
            this.lblAban.Size = new System.Drawing.Size(57, 20);
            this.lblAban.TabIndex = 12;
            this.lblAban.Text = "آبان (F8)";
            this.lblAban.Click += new System.EventHandler(this.lblAban_Click);
            this.lblAban.MouseEnter += new System.EventHandler(this.lblAban_MouseEnter);
            this.lblAban.MouseLeave += new System.EventHandler(this.lblAban_MouseLeave);
            // 
            // lblMordad
            // 
            this.lblMordad.AutoSize = true;
            this.lblMordad.BackColor = System.Drawing.Color.Transparent;
            this.lblMordad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMordad.Location = new System.Drawing.Point(161, 98);
            this.lblMordad.Name = "lblMordad";
            this.lblMordad.Size = new System.Drawing.Size(65, 20);
            this.lblMordad.TabIndex = 12;
            this.lblMordad.Text = "مرداد (F5)";
            this.lblMordad.Click += new System.EventHandler(this.lblMordad_Click);
            this.lblMordad.MouseEnter += new System.EventHandler(this.lblMordad_MouseEnter);
            this.lblMordad.MouseLeave += new System.EventHandler(this.lblMordad_MouseLeave);
            // 
            // lblOrdibehesht
            // 
            this.lblOrdibehesht.AutoSize = true;
            this.lblOrdibehesht.BackColor = System.Drawing.Color.Transparent;
            this.lblOrdibehesht.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOrdibehesht.Location = new System.Drawing.Point(138, 62);
            this.lblOrdibehesht.Name = "lblOrdibehesht";
            this.lblOrdibehesht.Size = new System.Drawing.Size(88, 20);
            this.lblOrdibehesht.TabIndex = 12;
            this.lblOrdibehesht.Text = "اردیبهشت (F2)";
            this.lblOrdibehesht.Click += new System.EventHandler(this.lblOrdibehesht_Click);
            this.lblOrdibehesht.MouseEnter += new System.EventHandler(this.lblOrdibehesht_MouseEnter);
            this.lblOrdibehesht.MouseLeave += new System.EventHandler(this.lblOrdibehesht_MouseLeave);
            // 
            // lblDey
            // 
            this.lblDey.AutoSize = true;
            this.lblDey.BackColor = System.Drawing.Color.Transparent;
            this.lblDey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDey.Location = new System.Drawing.Point(303, 171);
            this.lblDey.Name = "lblDey";
            this.lblDey.Size = new System.Drawing.Size(60, 20);
            this.lblDey.TabIndex = 12;
            this.lblDey.Text = "دی (F10)";
            this.lblDey.Click += new System.EventHandler(this.lblDey_Click);
            this.lblDey.MouseEnter += new System.EventHandler(this.lblDey_MouseEnter);
            this.lblDey.MouseLeave += new System.EventHandler(this.lblDey_MouseLeave);
            // 
            // lblMehr
            // 
            this.lblMehr.AutoSize = true;
            this.lblMehr.BackColor = System.Drawing.Color.Transparent;
            this.lblMehr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMehr.Location = new System.Drawing.Point(309, 134);
            this.lblMehr.Name = "lblMehr";
            this.lblMehr.Size = new System.Drawing.Size(54, 20);
            this.lblMehr.TabIndex = 12;
            this.lblMehr.Text = "مهر (F7)";
            this.lblMehr.Click += new System.EventHandler(this.lblMehr_Click);
            this.lblMehr.MouseEnter += new System.EventHandler(this.lblMehr_MouseEnter);
            this.lblMehr.MouseLeave += new System.EventHandler(this.lblMehr_MouseLeave);
            // 
            // lblTir
            // 
            this.lblTir.AutoSize = true;
            this.lblTir.BackColor = System.Drawing.Color.Transparent;
            this.lblTir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTir.Location = new System.Drawing.Point(310, 98);
            this.lblTir.Name = "lblTir";
            this.lblTir.Size = new System.Drawing.Size(53, 20);
            this.lblTir.TabIndex = 12;
            this.lblTir.Text = "تیر (F4)";
            this.lblTir.Click += new System.EventHandler(this.lblTir_Click);
            this.lblTir.MouseEnter += new System.EventHandler(this.lblTir_MouseEnter);
            this.lblTir.MouseLeave += new System.EventHandler(this.lblTir_MouseLeave);
            // 
            // lblFarvardin
            // 
            this.lblFarvardin.AutoSize = true;
            this.lblFarvardin.BackColor = System.Drawing.Color.Transparent;
            this.lblFarvardin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFarvardin.Location = new System.Drawing.Point(282, 62);
            this.lblFarvardin.Name = "lblFarvardin";
            this.lblFarvardin.Size = new System.Drawing.Size(81, 20);
            this.lblFarvardin.TabIndex = 12;
            this.lblFarvardin.Text = "فروردین (F1)";
            this.lblFarvardin.Click += new System.EventHandler(this.lblFarvardin_Click);
            this.lblFarvardin.MouseEnter += new System.EventHandler(this.lblFarvardin_MouseEnter);
            this.lblFarvardin.MouseLeave += new System.EventHandler(this.lblFarvardin_MouseLeave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(238, 352);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 20);
            this.label16.TabIndex = 12;
            this.label16.Text = "ماه انتخاب شده:";
            // 
            // lblMounth
            // 
            this.lblMounth.AutoSize = true;
            this.lblMounth.BackColor = System.Drawing.Color.Transparent;
            this.lblMounth.Font = new System.Drawing.Font("B Yekan", 12F);
            this.lblMounth.Location = new System.Drawing.Point(161, 349);
            this.lblMounth.Name = "lblMounth";
            this.lblMounth.Size = new System.Drawing.Size(28, 24);
            this.lblMounth.TabIndex = 12;
            this.lblMounth.Text = "00";
            // 
            // frmPer_Log_Aouth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(392, 425);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.lblMounth);
            this.Controls.Add(this.label16);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPer_Log_Aouth";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPer_Log_Aouth_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPer_Log_Aouth_KeyDown);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.PictureBox picClose;
        public System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.Timer timer1;
        public DevComponents.DotNetBar.Controls.GroupPanel grpAccount;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtAccCode;
        public System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbAccount;
        public System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public System.Windows.Forms.Label lblEsfand;
        public System.Windows.Forms.Label lblAzar;
        public System.Windows.Forms.Label lblShahrivar;
        public System.Windows.Forms.Label lblKhordad;
        public System.Windows.Forms.Label lblBahman;
        public System.Windows.Forms.Label lblAban;
        public System.Windows.Forms.Label lblMordad;
        public System.Windows.Forms.Label lblOrdibehesht;
        public System.Windows.Forms.Label lblDey;
        public System.Windows.Forms.Label lblMehr;
        public System.Windows.Forms.Label lblTir;
        public System.Windows.Forms.Label lblFarvardin;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label lblMounth;
    }
}