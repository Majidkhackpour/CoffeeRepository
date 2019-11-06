namespace Coffee_ManageMent
{
    partial class frmTable_Reservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTable_Reservation));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label1 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch_Acc = new DevComponents.DotNetBar.ButtonX();
            this.txtGuest_Number = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.rbtnDischarge = new System.Windows.Forms.RadioButton();
            this.rbtnReserve = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbTable = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTableCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnShow_Reservation = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.grp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(3, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(521, 43);
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
            this.panelEx1.TabIndex = 55653;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label1.Location = new System.Drawing.Point(305, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "مدیریت میزها";
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
            this.panelEx2.Location = new System.Drawing.Point(153, 19);
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
            this.panelEx2.TabIndex = 55654;
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
            this.panelEx3.Controls.Add(this.btnFinish);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(3, 325);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(521, 43);
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
            this.btnClose.Location = new System.Drawing.Point(17, 8);
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
            this.btnFinish.Location = new System.Drawing.Point(362, 8);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish.Size = new System.Drawing.Size(142, 25);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "تایید";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.Controls.Add(this.label6);
            this.grp1.Controls.Add(this.txtTime);
            this.grp1.Controls.Add(this.txtDate);
            this.grp1.Controls.Add(this.label5);
            this.grp1.Controls.Add(this.txtName);
            this.grp1.Controls.Add(this.btnShow_Reservation);
            this.grp1.Controls.Add(this.btnSearch_Acc);
            this.grp1.Controls.Add(this.txtGuest_Number);
            this.grp1.Controls.Add(this.txtCode);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.label8);
            this.grp1.Controls.Add(this.line1);
            this.grp1.Controls.Add(this.rbtnDischarge);
            this.grp1.Controls.Add(this.rbtnReserve);
            this.grp1.Controls.Add(this.label3);
            this.grp1.Controls.Add(this.lblState);
            this.grp1.Controls.Add(this.cmbTable);
            this.grp1.Controls.Add(this.label4);
            this.grp1.Controls.Add(this.lblTableCode);
            this.grp1.Controls.Add(this.label2);
            this.grp1.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp1.Location = new System.Drawing.Point(12, 78);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(499, 244);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(138, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 4845490;
            this.label6.Text = "زمان رزرو:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(12, 160);
            this.txtTime.Mask = "00:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(106, 27);
            this.txtTime.TabIndex = 6;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTime.ValidatingType = typeof(System.DateTime);
            this.txtTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTime_KeyDown);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(267, 160);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(106, 27);
            this.txtDate.TabIndex = 5;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(406, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 4845489;
            this.label5.Text = "تاریخ رزرو:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(12, 118);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(208, 27);
            this.txtName.TabIndex = 4845487;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch_Acc
            // 
            this.btnSearch_Acc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch_Acc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch_Acc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch_Acc.Location = new System.Drawing.Point(226, 118);
            this.btnSearch_Acc.Name = "btnSearch_Acc";
            this.btnSearch_Acc.Size = new System.Drawing.Size(35, 27);
            this.btnSearch_Acc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch_Acc.TabIndex = 4;
            this.btnSearch_Acc.Text = "+";
            this.btnSearch_Acc.Click += new System.EventHandler(this.btnSearch_Acc_Click);
            // 
            // txtGuest_Number
            // 
            this.txtGuest_Number.Location = new System.Drawing.Point(267, 200);
            this.txtGuest_Number.Name = "txtGuest_Number";
            this.txtGuest_Number.Size = new System.Drawing.Size(106, 27);
            this.txtGuest_Number.TabIndex = 7;
            this.txtGuest_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGuest_Number.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtGuest_Number.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGuest_Number_KeyDown);
            this.txtGuest_Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuest_Number_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(267, 118);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(106, 27);
            this.txtCode.TabIndex = 3;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(398, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 4845486;
            this.label7.Text = "تعداد میهمان:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(405, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 4845486;
            this.label8.Text = "رزرو کننده:";
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Transparent;
            this.line1.Location = new System.Drawing.Point(4, 91);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(484, 23);
            this.line1.TabIndex = 4845483;
            this.line1.Text = "line1";
            // 
            // rbtnDischarge
            // 
            this.rbtnDischarge.AutoSize = true;
            this.rbtnDischarge.BackColor = System.Drawing.Color.Transparent;
            this.rbtnDischarge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnDischarge.Location = new System.Drawing.Point(12, 66);
            this.rbtnDischarge.Name = "rbtnDischarge";
            this.rbtnDischarge.Size = new System.Drawing.Size(73, 24);
            this.rbtnDischarge.TabIndex = 2;
            this.rbtnDischarge.TabStop = true;
            this.rbtnDischarge.Text = "تخلیه میز";
            this.rbtnDischarge.UseVisualStyleBackColor = false;
            this.rbtnDischarge.CheckedChanged += new System.EventHandler(this.rbtnDischarge_CheckedChanged);
            this.rbtnDischarge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbtnDischarge_KeyDown);
            // 
            // rbtnReserve
            // 
            this.rbtnReserve.AutoSize = true;
            this.rbtnReserve.BackColor = System.Drawing.Color.Transparent;
            this.rbtnReserve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnReserve.Location = new System.Drawing.Point(132, 63);
            this.rbtnReserve.Name = "rbtnReserve";
            this.rbtnReserve.Size = new System.Drawing.Size(70, 24);
            this.rbtnReserve.TabIndex = 1;
            this.rbtnReserve.TabStop = true;
            this.rbtnReserve.Text = "رزرو میز";
            this.rbtnReserve.UseVisualStyleBackColor = false;
            this.rbtnReserve.CheckedChanged += new System.EventHandler(this.rbtnReserve_CheckedChanged);
            this.rbtnReserve.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbtnReserve_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(420, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 4845481;
            this.label3.Text = "وضعیت:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("B Yekan", 14F);
            this.lblState.Location = new System.Drawing.Point(281, 62);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 29);
            this.lblState.TabIndex = 4845482;
            this.lblState.Text = "00";
            // 
            // cmbTable
            // 
            this.cmbTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTable.DisplayMember = "Text";
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.ForeColor = System.Drawing.Color.Black;
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.ItemHeight = 20;
            this.cmbTable.Location = new System.Drawing.Point(240, 15);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(141, 28);
            this.cmbTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTable.TabIndex = 0;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            this.cmbTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTable_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(145, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 4845477;
            this.label4.Text = "شماره میز:";
            // 
            // lblTableCode
            // 
            this.lblTableCode.AutoSize = true;
            this.lblTableCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTableCode.Font = new System.Drawing.Font("B Yekan", 14F);
            this.lblTableCode.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTableCode.Location = new System.Drawing.Point(34, 12);
            this.lblTableCode.Name = "lblTableCode";
            this.lblTableCode.Size = new System.Drawing.Size(35, 29);
            this.lblTableCode.TabIndex = 4845478;
            this.lblTableCode.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(401, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 4845479;
            this.label2.Text = "لیست میزها:";
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
            // btnShow_Reservation
            // 
            this.btnShow_Reservation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShow_Reservation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShow_Reservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow_Reservation.Location = new System.Drawing.Point(12, 200);
            this.btnShow_Reservation.Name = "btnShow_Reservation";
            this.btnShow_Reservation.Size = new System.Drawing.Size(208, 27);
            this.btnShow_Reservation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShow_Reservation.TabIndex = 8;
            this.btnShow_Reservation.Text = "نمایش سابقه رزروها";
            this.btnShow_Reservation.Click += new System.EventHandler(this.btnShow_Reservation_Click);
            // 
            // frmTable_Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(523, 370);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTable_Reservation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTable_Reservation_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.Controls.GroupPanel grp1;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        public DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblState;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTableCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnDischarge;
        private System.Windows.Forms.RadioButton rbtnReserve;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.ButtonX btnSearch_Acc;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.MaskedTextBox txtDate;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.MaskedTextBox txtTime;
        public System.Windows.Forms.TextBox txtGuest_Number;
        public System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX btnShow_Reservation;
    }
}