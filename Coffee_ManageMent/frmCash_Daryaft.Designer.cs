namespace Coffee_ManageMent
{
    partial class frmCash_Daryaft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCash_Daryaft));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.grpAccount = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtTafsili = new System.Windows.Forms.TextBox();
            this.txtMoeen_Code = new System.Windows.Forms.TextBox();
            this.txtBabat_Code = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLetterCash = new System.Windows.Forms.TextBox();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTafsili_Name = new System.Windows.Forms.TextBox();
            this.txtMoeen_Name = new System.Windows.Forms.TextBox();
            this.txtBabat_Name = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch_Tafsili = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch_Moeen = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch_Babat = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch_Acc = new DevComponents.DotNetBar.ButtonX();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSafe = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.line3 = new DevComponents.DotNetBar.Controls.Line();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.grpAccount.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(2, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(530, 43);
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
            this.panelEx1.TabIndex = 23;
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
            this.label4.Location = new System.Drawing.Point(220, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "دریافت نقدی";
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
            this.panelEx2.Location = new System.Drawing.Point(160, 20);
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
            this.panelEx2.TabIndex = 24;
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
            // grpAccount
            // 
            this.grpAccount.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpAccount.Controls.Add(this.txtTafsili);
            this.grpAccount.Controls.Add(this.txtMoeen_Code);
            this.grpAccount.Controls.Add(this.txtBabat_Code);
            this.grpAccount.Controls.Add(this.label6);
            this.grpAccount.Controls.Add(this.label11);
            this.grpAccount.Controls.Add(this.label7);
            this.grpAccount.Controls.Add(this.label10);
            this.grpAccount.Controls.Add(this.txtLetterCash);
            this.grpAccount.Controls.Add(this.txtCash);
            this.grpAccount.Controls.Add(this.label9);
            this.grpAccount.Controls.Add(this.txtTafsili_Name);
            this.grpAccount.Controls.Add(this.txtMoeen_Name);
            this.grpAccount.Controls.Add(this.txtBabat_Name);
            this.grpAccount.Controls.Add(this.txtName);
            this.grpAccount.Controls.Add(this.btnSearch_Tafsili);
            this.grpAccount.Controls.Add(this.btnSearch_Moeen);
            this.grpAccount.Controls.Add(this.btnSearch_Babat);
            this.grpAccount.Controls.Add(this.btnSearch_Acc);
            this.grpAccount.Controls.Add(this.txtCode);
            this.grpAccount.Controls.Add(this.label5);
            this.grpAccount.Controls.Add(this.cmbSafe);
            this.grpAccount.Controls.Add(this.label8);
            this.grpAccount.Controls.Add(this.line3);
            this.grpAccount.Controls.Add(this.line2);
            this.grpAccount.Controls.Add(this.line1);
            this.grpAccount.Controls.Add(this.txtDate);
            this.grpAccount.Controls.Add(this.label2);
            this.grpAccount.Controls.Add(this.label1);
            this.grpAccount.Controls.Add(this.lblTime);
            this.grpAccount.Controls.Add(this.label3);
            this.grpAccount.Controls.Add(this.lblID);
            this.grpAccount.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpAccount.Location = new System.Drawing.Point(8, 82);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(516, 339);
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
            // txtTafsili
            // 
            this.txtTafsili.Location = new System.Drawing.Point(297, 291);
            this.txtTafsili.Name = "txtTafsili";
            this.txtTafsili.Size = new System.Drawing.Size(106, 27);
            this.txtTafsili.TabIndex = 9;
            this.txtTafsili.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTafsili.TextChanged += new System.EventHandler(this.txtTafsili_TextChanged);
            this.txtTafsili.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTafsili_KeyDown);
            // 
            // txtMoeen_Code
            // 
            this.txtMoeen_Code.Location = new System.Drawing.Point(297, 255);
            this.txtMoeen_Code.Name = "txtMoeen_Code";
            this.txtMoeen_Code.Size = new System.Drawing.Size(106, 27);
            this.txtMoeen_Code.TabIndex = 7;
            this.txtMoeen_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoeen_Code.TextChanged += new System.EventHandler(this.txtMoeen_Code_TextChanged);
            this.txtMoeen_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMoeen_Code_KeyDown);
            // 
            // txtBabat_Code
            // 
            this.txtBabat_Code.Location = new System.Drawing.Point(297, 192);
            this.txtBabat_Code.Name = "txtBabat_Code";
            this.txtBabat_Code.Size = new System.Drawing.Size(106, 27);
            this.txtBabat_Code.TabIndex = 5;
            this.txtBabat_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBabat_Code.TextChanged += new System.EventHandler(this.txtBabat_Code_TextChanged);
            this.txtBabat_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBabat_Code_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(418, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 2555602;
            this.label6.Text = "تشخیص حساب";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(451, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 20);
            this.label11.TabIndex = 2555602;
            this.label11.Text = "تفضیلی:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(465, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 2555602;
            this.label7.Text = "معین:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(465, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 2555602;
            this.label10.Text = "بابت:";
            // 
            // txtLetterCash
            // 
            this.txtLetterCash.Enabled = false;
            this.txtLetterCash.Location = new System.Drawing.Point(12, 155);
            this.txtLetterCash.Name = "txtLetterCash";
            this.txtLetterCash.ReadOnly = true;
            this.txtLetterCash.Size = new System.Drawing.Size(279, 27);
            this.txtLetterCash.TabIndex = 2555601;
            this.txtLetterCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(297, 155);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(106, 27);
            this.txtCash.TabIndex = 4;
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCash.TextChanged += new System.EventHandler(this.txtCash_TextChanged);
            this.txtCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCash_KeyDown);
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(467, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 20);
            this.label9.TabIndex = 2555600;
            this.label9.Text = "مبلغ:";
            // 
            // txtTafsili_Name
            // 
            this.txtTafsili_Name.Enabled = false;
            this.txtTafsili_Name.Location = new System.Drawing.Point(12, 291);
            this.txtTafsili_Name.Name = "txtTafsili_Name";
            this.txtTafsili_Name.ReadOnly = true;
            this.txtTafsili_Name.Size = new System.Drawing.Size(238, 27);
            this.txtTafsili_Name.TabIndex = 2555598;
            this.txtTafsili_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMoeen_Name
            // 
            this.txtMoeen_Name.Enabled = false;
            this.txtMoeen_Name.Location = new System.Drawing.Point(12, 255);
            this.txtMoeen_Name.Name = "txtMoeen_Name";
            this.txtMoeen_Name.ReadOnly = true;
            this.txtMoeen_Name.Size = new System.Drawing.Size(238, 27);
            this.txtMoeen_Name.TabIndex = 2555598;
            this.txtMoeen_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBabat_Name
            // 
            this.txtBabat_Name.Enabled = false;
            this.txtBabat_Name.Location = new System.Drawing.Point(12, 192);
            this.txtBabat_Name.Name = "txtBabat_Name";
            this.txtBabat_Name.ReadOnly = true;
            this.txtBabat_Name.Size = new System.Drawing.Size(238, 27);
            this.txtBabat_Name.TabIndex = 2555598;
            this.txtBabat_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(12, 101);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(238, 27);
            this.txtName.TabIndex = 2555598;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch_Tafsili
            // 
            this.btnSearch_Tafsili.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch_Tafsili.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch_Tafsili.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch_Tafsili.Location = new System.Drawing.Point(256, 291);
            this.btnSearch_Tafsili.Name = "btnSearch_Tafsili";
            this.btnSearch_Tafsili.Size = new System.Drawing.Size(35, 27);
            this.btnSearch_Tafsili.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch_Tafsili.TabIndex = 10;
            this.btnSearch_Tafsili.Text = "+";
            this.btnSearch_Tafsili.Click += new System.EventHandler(this.btnSearch_Tafsili_Click);
            // 
            // btnSearch_Moeen
            // 
            this.btnSearch_Moeen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch_Moeen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch_Moeen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch_Moeen.Location = new System.Drawing.Point(256, 255);
            this.btnSearch_Moeen.Name = "btnSearch_Moeen";
            this.btnSearch_Moeen.Size = new System.Drawing.Size(35, 27);
            this.btnSearch_Moeen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch_Moeen.TabIndex = 8;
            this.btnSearch_Moeen.Text = "+";
            this.btnSearch_Moeen.Click += new System.EventHandler(this.btnSearch_Moeen_Click);
            // 
            // btnSearch_Babat
            // 
            this.btnSearch_Babat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch_Babat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch_Babat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch_Babat.Location = new System.Drawing.Point(256, 192);
            this.btnSearch_Babat.Name = "btnSearch_Babat";
            this.btnSearch_Babat.Size = new System.Drawing.Size(35, 27);
            this.btnSearch_Babat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch_Babat.TabIndex = 6;
            this.btnSearch_Babat.Text = "+";
            this.btnSearch_Babat.Click += new System.EventHandler(this.btnSearch_Babat_Click);
            // 
            // btnSearch_Acc
            // 
            this.btnSearch_Acc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch_Acc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch_Acc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch_Acc.Location = new System.Drawing.Point(256, 101);
            this.btnSearch_Acc.Name = "btnSearch_Acc";
            this.btnSearch_Acc.Size = new System.Drawing.Size(35, 27);
            this.btnSearch_Acc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch_Acc.TabIndex = 3;
            this.btnSearch_Acc.Text = "+";
            this.btnSearch_Acc.Click += new System.EventHandler(this.btnSearch_Acc_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(297, 101);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(106, 27);
            this.txtCode.TabIndex = 2;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(421, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 2555597;
            this.label5.Text = "دریافت کننده:";
            // 
            // cmbSafe
            // 
            this.cmbSafe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSafe.DisplayMember = "Text";
            this.cmbSafe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSafe.ForeColor = System.Drawing.Color.Black;
            this.cmbSafe.FormattingEnabled = true;
            this.cmbSafe.ItemHeight = 20;
            this.cmbSafe.Location = new System.Drawing.Point(164, 61);
            this.cmbSafe.Name = "cmbSafe";
            this.cmbSafe.Size = new System.Drawing.Size(251, 28);
            this.cmbSafe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSafe.TabIndex = 1;
            this.cmbSafe.SelectedIndexChanged += new System.EventHandler(this.cmbSafe_SelectedIndexChanged);
            this.cmbSafe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSafe_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(421, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 2555593;
            this.label8.Text = "پرداخت کننده:";
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.Color.Transparent;
            this.line3.Location = new System.Drawing.Point(12, 226);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(391, 23);
            this.line3.TabIndex = 2555592;
            this.line3.Text = "line1";
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.Transparent;
            this.line2.Location = new System.Drawing.Point(12, 132);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(484, 23);
            this.line2.TabIndex = 2555592;
            this.line2.Text = "line1";
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Transparent;
            this.line1.Location = new System.Drawing.Point(12, 38);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(484, 23);
            this.line1.TabIndex = 2555592;
            this.line1.Text = "line1";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(164, 11);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(127, 27);
            this.txtDate.TabIndex = 0;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(297, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 2555590;
            this.label2.Text = "تاریخ ثبت:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(110, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 2555588;
            this.label1.Text = "زمان:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Location = new System.Drawing.Point(12, 14);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(25, 20);
            this.lblTime.TabIndex = 2555586;
            this.lblTime.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(433, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 2555589;
            this.label3.Text = "شماره برگه:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("B Yekan", 12F);
            this.lblID.ForeColor = System.Drawing.Color.Red;
            this.lblID.Location = new System.Drawing.Point(379, 11);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 24);
            this.lblID.TabIndex = 2555587;
            this.lblID.Text = "00";
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
            this.panelEx3.Size = new System.Drawing.Size(530, 43);
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
            this.btnFinish.Location = new System.Drawing.Point(369, 8);
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
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmCash_Daryaft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(533, 473);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCash_Daryaft";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCash_Daryaft_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

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
        public DevComponents.DotNetBar.Controls.GroupPanel grpAccount;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        public System.Windows.Forms.MaskedTextBox txtDate;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblID;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSafe;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtName;
        private DevComponents.DotNetBar.ButtonX btnSearch_Acc;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.Line line2;
        public System.Windows.Forms.TextBox txtLetterCash;
        public System.Windows.Forms.TextBox txtCash;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtBabat_Code;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtBabat_Name;
        private DevComponents.DotNetBar.ButtonX btnSearch_Babat;
        public System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.Line line3;
        public System.Windows.Forms.TextBox txtTafsili;
        public System.Windows.Forms.TextBox txtMoeen_Code;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtTafsili_Name;
        public System.Windows.Forms.TextBox txtMoeen_Name;
        private DevComponents.DotNetBar.ButtonX btnSearch_Tafsili;
        private DevComponents.DotNetBar.ButtonX btnSearch_Moeen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer2;
    }
}