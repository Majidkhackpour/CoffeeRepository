namespace Coffee_ManageMent
{
    partial class frmChange_Check_State
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChange_Check_State));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.grpAccount = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbNewState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblCheck_Type = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblBankCode = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblMablaq = new System.Windows.Forms.Label();
            this.lblDateArrivall = new System.Windows.Forms.Label();
            this.lblReciverCode = new System.Windows.Forms.Label();
            this.lblReciver = new System.Windows.Forms.Label();
            this.lblStateNow = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.grpAccount.SuspendLayout();
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
            this.panelEx1.Location = new System.Drawing.Point(5, 3);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(761, 43);
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
            this.panelEx1.TabIndex = 55610;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(161, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(538, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "تغییر وضعیت چک";
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
            this.panelEx2.Location = new System.Drawing.Point(271, 22);
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
            this.panelEx2.TabIndex = 55611;
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
            this.panelEx3.Controls.Add(this.btnClose);
            this.panelEx3.Controls.Add(this.btnFinish);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(5, 256);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(761, 43);
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
            this.panelEx3.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(13, 9);
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
            this.btnFinish.Location = new System.Drawing.Point(602, 9);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish.Size = new System.Drawing.Size(142, 25);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "تایید";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // grpAccount
            // 
            this.grpAccount.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpAccount.Controls.Add(this.cmbNewState);
            this.grpAccount.Controls.Add(this.label7);
            this.grpAccount.Controls.Add(this.lblCode);
            this.grpAccount.Controls.Add(this.lblCheck_Type);
            this.grpAccount.Controls.Add(this.label6);
            this.grpAccount.Controls.Add(this.label3);
            this.grpAccount.Controls.Add(this.lblSerial);
            this.grpAccount.Controls.Add(this.lblBankCode);
            this.grpAccount.Controls.Add(this.lblBankName);
            this.grpAccount.Controls.Add(this.lblMablaq);
            this.grpAccount.Controls.Add(this.lblDateArrivall);
            this.grpAccount.Controls.Add(this.lblReciverCode);
            this.grpAccount.Controls.Add(this.lblReciver);
            this.grpAccount.Controls.Add(this.lblStateNow);
            this.grpAccount.Controls.Add(this.label9);
            this.grpAccount.Controls.Add(this.Label15);
            this.grpAccount.Controls.Add(this.label12);
            this.grpAccount.Controls.Add(this.label8);
            this.grpAccount.Controls.Add(this.label1);
            this.grpAccount.Controls.Add(this.label2);
            this.grpAccount.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpAccount.Location = new System.Drawing.Point(12, 84);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(746, 164);
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
            this.grpAccount.TabIndex = 0;
            // 
            // cmbNewState
            // 
            this.cmbNewState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbNewState.DisplayMember = "Text";
            this.cmbNewState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewState.ForeColor = System.Drawing.Color.Black;
            this.cmbNewState.FormattingEnabled = true;
            this.cmbNewState.ItemHeight = 20;
            this.cmbNewState.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cmbNewState.Location = new System.Drawing.Point(7, 109);
            this.cmbNewState.Name = "cmbNewState";
            this.cmbNewState.Size = new System.Drawing.Size(159, 28);
            this.cmbNewState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbNewState.TabIndex = 0;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "عدم وصول";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "برگشتی";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "پاس شده";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(172, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 8888946;
            this.label7.Text = "وضعیت جدید:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblCode.Location = new System.Drawing.Point(544, 14);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(37, 29);
            this.lblCode.TabIndex = 8888945;
            this.lblCode.Text = "00";
            // 
            // lblCheck_Type
            // 
            this.lblCheck_Type.AutoSize = true;
            this.lblCheck_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblCheck_Type.Location = new System.Drawing.Point(347, 20);
            this.lblCheck_Type.Name = "lblCheck_Type";
            this.lblCheck_Type.Size = new System.Drawing.Size(25, 20);
            this.lblCheck_Type.TabIndex = 8888944;
            this.lblCheck_Type.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(651, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 8888944;
            this.label6.Text = "عطف سند:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(433, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 8888944;
            this.label3.Text = "نوع چک:";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.BackColor = System.Drawing.Color.Transparent;
            this.lblSerial.Location = new System.Drawing.Point(106, 66);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(25, 20);
            this.lblSerial.TabIndex = 8888932;
            this.lblSerial.Text = "00";
            // 
            // lblBankCode
            // 
            this.lblBankCode.AutoSize = true;
            this.lblBankCode.BackColor = System.Drawing.Color.Transparent;
            this.lblBankCode.Location = new System.Drawing.Point(540, 67);
            this.lblBankCode.Name = "lblBankCode";
            this.lblBankCode.Size = new System.Drawing.Size(25, 20);
            this.lblBankCode.TabIndex = 8888933;
            this.lblBankCode.Text = "00";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankName.Location = new System.Drawing.Point(608, 67);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(25, 20);
            this.lblBankName.TabIndex = 8888934;
            this.lblBankName.Text = "00";
            // 
            // lblMablaq
            // 
            this.lblMablaq.AutoSize = true;
            this.lblMablaq.BackColor = System.Drawing.Color.Transparent;
            this.lblMablaq.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMablaq.Location = new System.Drawing.Point(536, 107);
            this.lblMablaq.Name = "lblMablaq";
            this.lblMablaq.Size = new System.Drawing.Size(35, 29);
            this.lblMablaq.TabIndex = 8888935;
            this.lblMablaq.Text = "00";
            // 
            // lblDateArrivall
            // 
            this.lblDateArrivall.AutoSize = true;
            this.lblDateArrivall.BackColor = System.Drawing.Color.Transparent;
            this.lblDateArrivall.Location = new System.Drawing.Point(326, 66);
            this.lblDateArrivall.Name = "lblDateArrivall";
            this.lblDateArrivall.Size = new System.Drawing.Size(25, 20);
            this.lblDateArrivall.TabIndex = 8888936;
            this.lblDateArrivall.Text = "00";
            // 
            // lblReciverCode
            // 
            this.lblReciverCode.AutoSize = true;
            this.lblReciverCode.BackColor = System.Drawing.Color.Transparent;
            this.lblReciverCode.Location = new System.Drawing.Point(22, 20);
            this.lblReciverCode.Name = "lblReciverCode";
            this.lblReciverCode.Size = new System.Drawing.Size(25, 20);
            this.lblReciverCode.TabIndex = 8888930;
            this.lblReciverCode.Text = "00";
            // 
            // lblReciver
            // 
            this.lblReciver.AutoSize = true;
            this.lblReciver.BackColor = System.Drawing.Color.Transparent;
            this.lblReciver.Location = new System.Drawing.Point(106, 20);
            this.lblReciver.Name = "lblReciver";
            this.lblReciver.Size = new System.Drawing.Size(25, 20);
            this.lblReciver.TabIndex = 8888931;
            this.lblReciver.Text = "00";
            // 
            // lblStateNow
            // 
            this.lblStateNow.AutoSize = true;
            this.lblStateNow.BackColor = System.Drawing.Color.Transparent;
            this.lblStateNow.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStateNow.Location = new System.Drawing.Point(289, 107);
            this.lblStateNow.Name = "lblStateNow";
            this.lblStateNow.Size = new System.Drawing.Size(35, 29);
            this.lblStateNow.TabIndex = 8888937;
            this.lblStateNow.Text = "00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(187, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 8888941;
            this.label9.Text = "شماره چک:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Location = new System.Drawing.Point(674, 67);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(35, 20);
            this.Label15.TabIndex = 8888940;
            this.Label15.Text = "بانک:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(676, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 20);
            this.label12.TabIndex = 8888939;
            this.label12.Text = "مبلغ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(429, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 8888938;
            this.label8.Text = "سررسید:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(182, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 8888943;
            this.label1.Text = "طرف حساب:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(404, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 8888942;
            this.label2.Text = "وضعیت کنونی:";
            // 
            // frmChange_Check_State
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(770, 300);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChange_Check_State";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmChange_Check_State_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        public DevComponents.DotNetBar.Controls.GroupPanel grpAccount;
        public System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblCheck_Type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblSerial;
        public System.Windows.Forms.Label lblBankCode;
        public System.Windows.Forms.Label lblBankName;
        public System.Windows.Forms.Label lblMablaq;
        public System.Windows.Forms.Label lblDateArrivall;
        public System.Windows.Forms.Label lblReciverCode;
        public System.Windows.Forms.Label lblReciver;
        public System.Windows.Forms.Label lblStateNow;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbNewState;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private System.Windows.Forms.Label label7;
    }
}