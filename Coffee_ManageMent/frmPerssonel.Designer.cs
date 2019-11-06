namespace Coffee_ManageMent
{
    partial class frmPerssonel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerssonel));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.grpPerssonel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDate_Birth = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.cmbGroup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chbState = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMobile = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.btnSearchAcc = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonnelCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFather_Name = new System.Windows.Forms.TextBox();
            this.txtPlace_Birth = new System.Windows.Forms.TextBox();
            this.txtNat_Code = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.grpPerssonel.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(3, 3);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(940, 43);
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
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(552, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "مدیریت پرسنل";
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
            this.panelEx2.Location = new System.Drawing.Point(372, 22);
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
            // grpPerssonel
            // 
            this.grpPerssonel.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPerssonel.Controls.Add(this.txtDate_Birth);
            this.grpPerssonel.Controls.Add(this.cmbGroup);
            this.grpPerssonel.Controls.Add(this.chbState);
            this.grpPerssonel.Controls.Add(this.txtNotice);
            this.grpPerssonel.Controls.Add(this.txtAddress);
            this.grpPerssonel.Controls.Add(this.txtEmail);
            this.grpPerssonel.Controls.Add(this.txtMobile);
            this.grpPerssonel.Controls.Add(this.rbtnFemale);
            this.grpPerssonel.Controls.Add(this.rbtnMale);
            this.grpPerssonel.Controls.Add(this.btnSearchAcc);
            this.grpPerssonel.Controls.Add(this.label10);
            this.grpPerssonel.Controls.Add(this.label12);
            this.grpPerssonel.Controls.Add(this.label2);
            this.grpPerssonel.Controls.Add(this.label14);
            this.grpPerssonel.Controls.Add(this.label1);
            this.grpPerssonel.Controls.Add(this.txtPersonnelCode);
            this.grpPerssonel.Controls.Add(this.label13);
            this.grpPerssonel.Controls.Add(this.label11);
            this.grpPerssonel.Controls.Add(this.label9);
            this.grpPerssonel.Controls.Add(this.label8);
            this.grpPerssonel.Controls.Add(this.label5);
            this.grpPerssonel.Controls.Add(this.label6);
            this.grpPerssonel.Controls.Add(this.label3);
            this.grpPerssonel.Controls.Add(this.label7);
            this.grpPerssonel.Controls.Add(this.txtName);
            this.grpPerssonel.Controls.Add(this.txtPhone);
            this.grpPerssonel.Controls.Add(this.txtFather_Name);
            this.grpPerssonel.Controls.Add(this.txtPlace_Birth);
            this.grpPerssonel.Controls.Add(this.txtNat_Code);
            this.grpPerssonel.Controls.Add(this.txtCode);
            this.grpPerssonel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPerssonel.Location = new System.Drawing.Point(3, 84);
            this.grpPerssonel.Name = "grpPerssonel";
            this.grpPerssonel.Size = new System.Drawing.Size(940, 338);
            // 
            // 
            // 
            this.grpPerssonel.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpPerssonel.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grpPerssonel.Style.BackColorGradientAngle = 90;
            this.grpPerssonel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPerssonel.Style.BorderBottomWidth = 1;
            this.grpPerssonel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpPerssonel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPerssonel.Style.BorderLeftWidth = 1;
            this.grpPerssonel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPerssonel.Style.BorderRightWidth = 1;
            this.grpPerssonel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPerssonel.Style.BorderTopWidth = 1;
            this.grpPerssonel.Style.CornerDiameter = 4;
            this.grpPerssonel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpPerssonel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpPerssonel.Style.TextColor = System.Drawing.Color.Black;
            this.grpPerssonel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpPerssonel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpPerssonel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpPerssonel.TabIndex = 0;
            // 
            // txtDate_Birth
            // 
            // 
            // 
            // 
            this.txtDate_Birth.BackgroundStyle.Class = "TextBoxBorder";
            this.txtDate_Birth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate_Birth.ButtonClear.Visible = true;
            this.txtDate_Birth.Location = new System.Drawing.Point(31, 60);
            this.txtDate_Birth.Mask = "0000/00/00";
            this.txtDate_Birth.Name = "txtDate_Birth";
            this.txtDate_Birth.Size = new System.Drawing.Size(184, 26);
            this.txtDate_Birth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtDate_Birth.TabIndex = 8;
            this.txtDate_Birth.Text = "";
            this.txtDate_Birth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbGroup
            // 
            this.cmbGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbGroup.DisplayMember = "Text";
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.ForeColor = System.Drawing.Color.Black;
            this.cmbGroup.ItemHeight = 20;
            this.cmbGroup.Location = new System.Drawing.Point(31, 159);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(184, 28);
            this.cmbGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbGroup.TabIndex = 14;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            this.cmbGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGroup_KeyDown);
            // 
            // chbState
            // 
            this.chbState.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbState.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbState.Location = new System.Drawing.Point(654, 297);
            this.chbState.Name = "chbState";
            this.chbState.Size = new System.Drawing.Size(209, 23);
            this.chbState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbState.TabIndex = 17;
            this.chbState.Text = "فعال سازی وضعیت کاری";
            this.chbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chbState_KeyDown);
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(31, 209);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(184, 119);
            this.txtNotice.TabIndex = 16;
            this.txtNotice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotice_KeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(370, 209);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(493, 72);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.Location = new System.Drawing.Point(662, 159);
            this.txtEmail.MaxLength = 25;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PreventEnterBeep = true;
            this.txtEmail.Size = new System.Drawing.Size(201, 27);
            this.txtEmail.TabIndex = 12;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.WatermarkText = "Arad_enj@Yahoo.com";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtMobile
            // 
            this.txtMobile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMobile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtMobile.Border.Class = "TextBoxBorder";
            this.txtMobile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMobile.Location = new System.Drawing.Point(31, 110);
            this.txtMobile.MaxLength = 12;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.PreventEnterBeep = true;
            this.txtMobile.Size = new System.Drawing.Size(186, 27);
            this.txtMobile.TabIndex = 11;
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMobile.WatermarkText = "09xx-xxx-xxxx";
            this.txtMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyDown);
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.BackColor = System.Drawing.Color.Transparent;
            this.rbtnFemale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnFemale.Location = new System.Drawing.Point(371, 60);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(49, 24);
            this.rbtnFemale.TabIndex = 7;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "خانم";
            this.rbtnFemale.UseVisualStyleBackColor = false;
            // 
            // btnSearchAcc
            // 
            this.btnSearchAcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchAcc.Location = new System.Drawing.Point(723, 9);
            this.btnSearchAcc.Name = "btnSearchAcc";
            this.btnSearchAcc.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSearchAcc.Size = new System.Drawing.Size(35, 27);
            this.btnSearchAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSearchAcc.TabIndex = 1;
            this.btnSearchAcc.Text = "+";
            this.btnSearchAcc.Click += new System.EventHandler(this.btnSearchAcc_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(588, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "تماس:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(879, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "EMAIL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(225, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "گروه کاری:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(565, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "کد پرسنلی:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(227, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "توضیحات:";
            // 
            // txtPersonnelCode
            // 
            this.txtPersonnelCode.Location = new System.Drawing.Point(371, 159);
            this.txtPersonnelCode.Name = "txtPersonnelCode";
            this.txtPersonnelCode.Size = new System.Drawing.Size(189, 27);
            this.txtPersonnelCode.TabIndex = 13;
            this.txtPersonnelCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPersonnelCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPersonnelCode_KeyDown);
            this.txtPersonnelCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonnelCode_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(888, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "آدرس:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(244, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "همراه:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(874, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "محل تولد:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(225, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "تاریخ تولد:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(884, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "نام پدر:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(578, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "جنسیت:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(223, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "شماره ملی:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(878, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "شناسایی:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(370, 9);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(347, 27);
            this.txtName.TabIndex = 2;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(371, 108);
            this.txtPhone.MaxLength = 8;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(189, 27);
            this.txtPhone.TabIndex = 10;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtFather_Name
            // 
            this.txtFather_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFather_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFather_Name.Location = new System.Drawing.Point(662, 59);
            this.txtFather_Name.Name = "txtFather_Name";
            this.txtFather_Name.Size = new System.Drawing.Size(201, 27);
            this.txtFather_Name.TabIndex = 4;
            this.txtFather_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFather_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFather_Name_KeyDown);
            // 
            // txtPlace_Birth
            // 
            this.txtPlace_Birth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPlace_Birth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPlace_Birth.Location = new System.Drawing.Point(662, 109);
            this.txtPlace_Birth.Name = "txtPlace_Birth";
            this.txtPlace_Birth.Size = new System.Drawing.Size(201, 27);
            this.txtPlace_Birth.TabIndex = 9;
            this.txtPlace_Birth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlace_Birth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlace_Birth_KeyDown);
            // 
            // txtNat_Code
            // 
            this.txtNat_Code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNat_Code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNat_Code.Location = new System.Drawing.Point(31, 9);
            this.txtNat_Code.Name = "txtNat_Code";
            this.txtNat_Code.Size = new System.Drawing.Size(186, 27);
            this.txtNat_Code.TabIndex = 3;
            this.txtNat_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNat_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNat_Code_KeyDown);
            this.txtNat_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNat_Code_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(764, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(99, 27);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnClose);
            this.panelEx3.Controls.Add(this.btnFinish);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(3, 428);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(940, 43);
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
            this.btnFinish.Location = new System.Drawing.Point(788, 8);
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
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.BackColor = System.Drawing.Color.Transparent;
            this.rbtnMale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnMale.Location = new System.Drawing.Point(471, 60);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(40, 24);
            this.rbtnMale.TabIndex = 6;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "آقا";
            this.rbtnMale.UseVisualStyleBackColor = false;
            this.rbtnMale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbtnMale_KeyDown);
            // 
            // frmPerssonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(944, 472);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.grpPerssonel);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPerssonel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPerssonel_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grpPerssonel.ResumeLayout(false);
            this.grpPerssonel.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        public DevComponents.DotNetBar.Controls.GroupPanel grpPerssonel;
        public System.Windows.Forms.TextBox txtAddress;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMobile;
        private System.Windows.Forms.RadioButton rbtnFemale;
        public DevComponents.DotNetBar.ButtonX btnSearchAcc;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtPersonnelCode;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.TextBox txtFather_Name;
        public System.Windows.Forms.TextBox txtPlace_Birth;
        public System.Windows.Forms.TextBox txtNat_Code;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbState;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbGroup;
        public System.Windows.Forms.TextBox txtNotice;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtDate_Birth;
        private System.Windows.Forms.RadioButton rbtnMale;
    }
}