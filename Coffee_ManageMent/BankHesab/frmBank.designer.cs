namespace Coffee_ManageMent.BankHesab
{
    partial class frmBank
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
            AmirCalendar.FarsiDate farsiDate1 = new AmirCalendar.FarsiDate();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBank));
            this.uC_Date1 = new UC_Date.UC_Date();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAccount = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSearchMoein = new DevComponents.DotNetBar.ButtonX();
            this.txtMoeinCode = new System.Windows.Forms.TextBox();
            this.txtMoeinName = new System.Windows.Forms.TextBox();
            this.cmbAmountMahiat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.chbPoss = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDateEftetah = new AmirCalendar.FarsiCalendar();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodeShobe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHesabNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSahebHesab = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNameShobe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.grpAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // uC_Date1
            // 
            this.uC_Date1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.uC_Date1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_Date1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.uC_Date1.Location = new System.Drawing.Point(0, 0);
            this.uC_Date1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uC_Date1.Name = "uC_Date1";
            this.uC_Date1.Size = new System.Drawing.Size(727, 47);
            this.uC_Date1.TabIndex = 55671;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(548, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 55672;
            this.label1.Text = "مدیریت حساب های بانکی";
            // 
            // grpAccount
            // 
            this.grpAccount.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpAccount.Controls.Add(this.label11);
            this.grpAccount.Controls.Add(this.btnSearchMoein);
            this.grpAccount.Controls.Add(this.txtMoeinCode);
            this.grpAccount.Controls.Add(this.txtMoeinName);
            this.grpAccount.Controls.Add(this.cmbAmountMahiat);
            this.grpAccount.Controls.Add(this.txtAmount);
            this.grpAccount.Controls.Add(this.chbPoss);
            this.grpAccount.Controls.Add(this.label10);
            this.grpAccount.Controls.Add(this.txtDateEftetah);
            this.grpAccount.Controls.Add(this.label9);
            this.grpAccount.Controls.Add(this.txtCodeShobe);
            this.grpAccount.Controls.Add(this.label6);
            this.grpAccount.Controls.Add(this.txtHesabNumber);
            this.grpAccount.Controls.Add(this.label12);
            this.grpAccount.Controls.Add(this.txtSahebHesab);
            this.grpAccount.Controls.Add(this.label8);
            this.grpAccount.Controls.Add(this.txtNameShobe);
            this.grpAccount.Controls.Add(this.label7);
            this.grpAccount.Controls.Add(this.lblCode);
            this.grpAccount.Controls.Add(this.txtCode);
            this.grpAccount.Controls.Add(this.label3);
            this.grpAccount.Controls.Add(this.cmbType);
            this.grpAccount.Controls.Add(this.label5);
            this.grpAccount.Controls.Add(this.txtDescription);
            this.grpAccount.Controls.Add(this.txtName);
            this.grpAccount.Controls.Add(this.label4);
            this.grpAccount.Controls.Add(this.label2);
            this.grpAccount.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpAccount.Location = new System.Drawing.Point(5, 47);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(715, 492);
            // 
            // 
            // 
            this.grpAccount.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.grpAccount.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.grpAccount.Style.BackColorGradientAngle = 90;
            this.grpAccount.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpAccount.Style.BorderBottomWidth = 2;
            this.grpAccount.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grpAccount.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
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
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(196, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 20);
            this.label11.TabIndex = 40;
            this.label11.Text = "حساب معین مانده اول دوره";
            // 
            // btnSearchMoein
            // 
            this.btnSearchMoein.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchMoein.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.btnSearchMoein.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchMoein.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchMoein.Location = new System.Drawing.Point(232, 237);
            this.btnSearchMoein.Name = "btnSearchMoein";
            this.btnSearchMoein.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btnSearchMoein.Size = new System.Drawing.Size(29, 27);
            this.btnSearchMoein.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSearchMoein.TabIndex = 11;
            this.btnSearchMoein.Text = "...";
            this.btnSearchMoein.TextColor = System.Drawing.Color.Silver;
            this.btnSearchMoein.ThemeAware = true;
            this.btnSearchMoein.Click += new System.EventHandler(this.btnSearchMoein_Click);
            // 
            // txtMoeinCode
            // 
            this.txtMoeinCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtMoeinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoeinCode.ForeColor = System.Drawing.Color.Silver;
            this.txtMoeinCode.Location = new System.Drawing.Point(265, 237);
            this.txtMoeinCode.MaxLength = 6;
            this.txtMoeinCode.Name = "txtMoeinCode";
            this.txtMoeinCode.Size = new System.Drawing.Size(80, 27);
            this.txtMoeinCode.TabIndex = 10;
            this.txtMoeinCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoeinCode.TextChanged += new System.EventHandler(this.txtMoeinCode_TextChanged);
            this.txtMoeinCode.Enter += new System.EventHandler(this.txtMoeinCode_Enter);
            this.txtMoeinCode.Leave += new System.EventHandler(this.txtMoeinCode_Leave);
            // 
            // txtMoeinName
            // 
            this.txtMoeinName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtMoeinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoeinName.Enabled = false;
            this.txtMoeinName.ForeColor = System.Drawing.Color.Silver;
            this.txtMoeinName.Location = new System.Drawing.Point(32, 237);
            this.txtMoeinName.MaxLength = 2;
            this.txtMoeinName.Name = "txtMoeinName";
            this.txtMoeinName.ReadOnly = true;
            this.txtMoeinName.Size = new System.Drawing.Size(197, 27);
            this.txtMoeinName.TabIndex = 39;
            this.txtMoeinName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoeinName.Enter += new System.EventHandler(this.txtMoeinName_Enter);
            this.txtMoeinName.Leave += new System.EventHandler(this.txtMoeinName_Leave);
            // 
            // cmbAmountMahiat
            // 
            this.cmbAmountMahiat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAmountMahiat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAmountMahiat.DisplayMember = "Name";
            this.cmbAmountMahiat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmountMahiat.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbAmountMahiat.ForeColor = System.Drawing.Color.Black;
            this.cmbAmountMahiat.ItemHeight = 20;
            this.cmbAmountMahiat.Location = new System.Drawing.Point(378, 236);
            this.cmbAmountMahiat.Name = "cmbAmountMahiat";
            this.cmbAmountMahiat.Size = new System.Drawing.Size(85, 28);
            this.cmbAmountMahiat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAmountMahiat.TabIndex = 9;
            this.cmbAmountMahiat.ValueMember = "Guid";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAmount.ForeColor = System.Drawing.Color.Silver;
            this.txtAmount.HideSelection = false;
            this.txtAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAmount.Location = new System.Drawing.Point(469, 237);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(222, 27);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // chbPoss
            // 
            this.chbPoss.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbPoss.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbPoss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbPoss.Location = new System.Drawing.Point(444, 270);
            this.chbPoss.Name = "chbPoss";
            this.chbPoss.Size = new System.Drawing.Size(247, 23);
            this.chbPoss.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbPoss.TabIndex = 12;
            this.chbPoss.Text = "کارتخوان دارد";
            this.chbPoss.TextColor = System.Drawing.Color.Silver;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(410, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(275, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "مانده اول دوره";
            // 
            // txtDateEftetah
            // 
            this.txtDateEftetah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateEftetah.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDateEftetah.Location = new System.Drawing.Point(378, 78);
            this.txtDateEftetah.Name = "txtDateEftetah";
            this.txtDateEftetah.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDateEftetah.Size = new System.Drawing.Size(313, 21);
            this.txtDateEftetah.TabIndex = 2;
            farsiDate1.FarsiSelectedDate = "1398/08/27";
            this.txtDateEftetah.Value = farsiDate1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(435, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "تاریخ افتتاح حساب";
            // 
            // txtCodeShobe
            // 
            this.txtCodeShobe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeShobe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtCodeShobe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodeShobe.ForeColor = System.Drawing.Color.Silver;
            this.txtCodeShobe.Location = new System.Drawing.Point(378, 128);
            this.txtCodeShobe.MaxLength = 4;
            this.txtCodeShobe.Name = "txtCodeShobe";
            this.txtCodeShobe.Size = new System.Drawing.Size(313, 27);
            this.txtCodeShobe.TabIndex = 4;
            this.txtCodeShobe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodeShobe.Enter += new System.EventHandler(this.txtCodeShobe_Enter);
            this.txtCodeShobe.Leave += new System.EventHandler(this.txtCodeShobe_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(427, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "کد شعبه";
            // 
            // txtHesabNumber
            // 
            this.txtHesabNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtHesabNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHesabNumber.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtHesabNumber.ForeColor = System.Drawing.Color.Silver;
            this.txtHesabNumber.HideSelection = false;
            this.txtHesabNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtHesabNumber.Location = new System.Drawing.Point(32, 181);
            this.txtHesabNumber.Name = "txtHesabNumber";
            this.txtHesabNumber.Size = new System.Drawing.Size(313, 27);
            this.txtHesabNumber.TabIndex = 7;
            this.txtHesabNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHesabNumber.Enter += new System.EventHandler(this.txtHesabNumber_Enter);
            this.txtHesabNumber.Leave += new System.EventHandler(this.txtHesabNumber_Leave);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(84, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(253, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "شماره حساب";
            // 
            // txtSahebHesab
            // 
            this.txtSahebHesab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtSahebHesab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSahebHesab.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSahebHesab.ForeColor = System.Drawing.Color.Silver;
            this.txtSahebHesab.HideSelection = false;
            this.txtSahebHesab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSahebHesab.Location = new System.Drawing.Point(378, 181);
            this.txtSahebHesab.Name = "txtSahebHesab";
            this.txtSahebHesab.Size = new System.Drawing.Size(313, 27);
            this.txtSahebHesab.TabIndex = 6;
            this.txtSahebHesab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSahebHesab.Enter += new System.EventHandler(this.txtSahebHesab_Enter);
            this.txtSahebHesab.Leave += new System.EventHandler(this.txtSahebHesab_Leave);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(432, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(253, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "نام صاحب حساب";
            // 
            // txtNameShobe
            // 
            this.txtNameShobe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtNameShobe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameShobe.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNameShobe.ForeColor = System.Drawing.Color.Silver;
            this.txtNameShobe.HideSelection = false;
            this.txtNameShobe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNameShobe.Location = new System.Drawing.Point(32, 128);
            this.txtNameShobe.Name = "txtNameShobe";
            this.txtNameShobe.Size = new System.Drawing.Size(313, 27);
            this.txtNameShobe.TabIndex = 5;
            this.txtNameShobe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNameShobe.Enter += new System.EventHandler(this.txtNameShobe_Enter);
            this.txtNameShobe.Leave += new System.EventHandler(this.txtNameShobe_Leave);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(84, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "نام شعبه";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCode.ForeColor = System.Drawing.Color.Silver;
            this.lblCode.Location = new System.Drawing.Point(369, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(25, 20);
            this.lblCode.TabIndex = 27;
            this.lblCode.Text = "00";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.ForeColor = System.Drawing.Color.Silver;
            this.txtCode.Location = new System.Drawing.Point(396, 24);
            this.txtCode.MaxLength = 4;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(295, 27);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(427, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "کد شناسایی";
            // 
            // cmbType
            // 
            this.cmbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbType.DisplayMember = "Name";
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbType.ForeColor = System.Drawing.Color.Black;
            this.cmbType.ItemHeight = 20;
            this.cmbType.Location = new System.Drawing.Point(32, 77);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(313, 28);
            this.cmbType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbType.TabIndex = 3;
            this.cmbType.ValueMember = "Guid";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(90, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "نوع حساب";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescription.ForeColor = System.Drawing.Color.Silver;
            this.txtDescription.HideSelection = false;
            this.txtDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDescription.Location = new System.Drawing.Point(32, 327);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(653, 156);
            this.txtDescription.TabIndex = 13;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtName.ForeColor = System.Drawing.Color.Silver;
            this.txtName.HideSelection = false;
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtName.Location = new System.Drawing.Point(32, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(313, 27);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(415, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "توضیحات";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(84, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "عنوان";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Location = new System.Drawing.Point(40, 566);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btnCancel.Size = new System.Drawing.Size(125, 25);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف (ESC)";
            this.btnCancel.TextColor = System.Drawing.Color.Silver;
            this.btnCancel.ThemeAware = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnFinish.Location = new System.Drawing.Point(548, 566);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btnFinish.Size = new System.Drawing.Size(145, 25);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Silver;
            this.btnFinish.ThemeAware = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.Color.Silver;
            this.line1.Location = new System.Drawing.Point(0, 545);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(727, 17);
            this.line1.TabIndex = 55676;
            this.line1.Text = "line1";
            this.line1.Thickness = 2;
            // 
            // frmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(727, 607);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_Date1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBank";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBank_Load);
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC_Date.UC_Date uC_Date1;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.GroupPanel grpAccount;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbPoss;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbType;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCodeShobe;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtNameShobe;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtSahebHesab;
        public System.Windows.Forms.Label label8;
        private AmirCalendar.FarsiCalendar txtDateEftetah;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label11;
        public DevComponents.DotNetBar.ButtonX btnSearchMoein;
        public System.Windows.Forms.TextBox txtMoeinCode;
        public System.Windows.Forms.TextBox txtMoeinName;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbAmountMahiat;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Label label10;
        public DevComponents.DotNetBar.ButtonX btnCancel;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.Controls.Line line1;
        public System.Windows.Forms.TextBox txtHesabNumber;
        public System.Windows.Forms.Label label12;
    }
}