namespace Coffee_ManageMent.Customers
{
    partial class frmCustomer_PublicInfo
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
            AmirCalendar.FarsiDate farsiDate1 = new AmirCalendar.FarsiDate();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer_PublicInfo));
            this.cusGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cmbGroup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbAmountMahiat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtDateBirth = new AmirCalendar.FarsiCalendar();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtMoeinName = new System.Windows.Forms.TextBox();
            this.txtMoeinCode = new System.Windows.Forms.TextBox();
            this.btnSearchMoein = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchGroup = new DevComponents.DotNetBar.ButtonX();
            this.label11 = new System.Windows.Forms.Label();
            this.grpAccount = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cusGroupBindingSource)).BeginInit();
            this.grpAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // cusGroupBindingSource
            // 
            this.cusGroupBindingSource.DataSource = typeof(DataLayer.Models.Perssonel.PerssonelGroup);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(42, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "عنوان";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(543, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "مانده اول دوره";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(568, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "تاریخ تولد";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(570, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "توضیحات";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtName.ForeColor = System.Drawing.Color.Silver;
            this.txtName.HideSelection = false;
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtName.Location = new System.Drawing.Point(18, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(366, 27);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtName.Enter += new System.EventHandler(this.TxtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.TxtName_Leave);
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
            this.txtAmount.Location = new System.Drawing.Point(570, 148);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(248, 27);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmount.TextChanged += new System.EventHandler(this.TxtAmount_TextChanged);
            this.txtAmount.Enter += new System.EventHandler(this.TxtAmount_Enter);
            this.txtAmount.Leave += new System.EventHandler(this.TxtAmount_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescription.ForeColor = System.Drawing.Color.Silver;
            this.txtDescription.HideSelection = false;
            this.txtDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDescription.Location = new System.Drawing.Point(18, 262);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(800, 103);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescription.Enter += new System.EventHandler(this.TxtDescription_Enter);
            this.txtDescription.Leave += new System.EventHandler(this.TxtDescription_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(553, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "کد شناسایی";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(593, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "گروه";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.ForeColor = System.Drawing.Color.Silver;
            this.txtCode.Location = new System.Drawing.Point(476, 35);
            this.txtCode.MaxLength = 4;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(342, 27);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.Enter += new System.EventHandler(this.TxtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.TxtCode_Leave);
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbGroup.DataSource = this.cusGroupBindingSource;
            this.cmbGroup.DisplayMember = "Name";
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbGroup.ForeColor = System.Drawing.Color.Black;
            this.cmbGroup.ItemHeight = 20;
            this.cmbGroup.Location = new System.Drawing.Point(476, 87);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(342, 28);
            this.cmbGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbGroup.TabIndex = 2;
            this.cmbGroup.ValueMember = "Guid";
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
            this.cmbAmountMahiat.Location = new System.Drawing.Point(458, 147);
            this.cmbAmountMahiat.Name = "cmbAmountMahiat";
            this.cmbAmountMahiat.Size = new System.Drawing.Size(106, 28);
            this.cmbAmountMahiat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAmountMahiat.TabIndex = 9;
            this.cmbAmountMahiat.ValueMember = "Guid";
            // 
            // txtDateBirth
            // 
            this.txtDateBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateBirth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDateBirth.Location = new System.Drawing.Point(458, 204);
            this.txtDateBirth.Name = "txtDateBirth";
            this.txtDateBirth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDateBirth.Size = new System.Drawing.Size(360, 21);
            this.txtDateBirth.TabIndex = 6;
            farsiDate1.FarsiSelectedDate = "1398/08/27";
            this.txtDateBirth.Value = farsiDate1;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCode.ForeColor = System.Drawing.Color.Silver;
            this.lblCode.Location = new System.Drawing.Point(451, 37);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(25, 20);
            this.lblCode.TabIndex = 24;
            this.lblCode.Text = "00";
            // 
            // txtMoeinName
            // 
            this.txtMoeinName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtMoeinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoeinName.Enabled = false;
            this.txtMoeinName.ForeColor = System.Drawing.Color.Silver;
            this.txtMoeinName.Location = new System.Drawing.Point(18, 148);
            this.txtMoeinName.MaxLength = 2;
            this.txtMoeinName.Name = "txtMoeinName";
            this.txtMoeinName.ReadOnly = true;
            this.txtMoeinName.Size = new System.Drawing.Size(252, 27);
            this.txtMoeinName.TabIndex = 27;
            this.txtMoeinName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMoeinCode
            // 
            this.txtMoeinCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtMoeinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoeinCode.ForeColor = System.Drawing.Color.Silver;
            this.txtMoeinCode.Location = new System.Drawing.Point(304, 148);
            this.txtMoeinCode.MaxLength = 6;
            this.txtMoeinCode.Name = "txtMoeinCode";
            this.txtMoeinCode.Size = new System.Drawing.Size(80, 27);
            this.txtMoeinCode.TabIndex = 10;
            this.txtMoeinCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoeinCode.TextChanged += new System.EventHandler(this.TxtMoeinCode_TextChanged);
            // 
            // btnSearchMoein
            // 
            this.btnSearchMoein.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchMoein.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.btnSearchMoein.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchMoein.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchMoein.Location = new System.Drawing.Point(272, 148);
            this.btnSearchMoein.Name = "btnSearchMoein";
            this.btnSearchMoein.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btnSearchMoein.Size = new System.Drawing.Size(29, 27);
            this.btnSearchMoein.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSearchMoein.TabIndex = 26;
            this.btnSearchMoein.Text = "...";
            this.btnSearchMoein.TextColor = System.Drawing.Color.Silver;
            this.btnSearchMoein.ThemeAware = true;
            this.btnSearchMoein.Click += new System.EventHandler(this.BtnSearchMoein_Click);
            // 
            // btnSearchGroup
            // 
            this.btnSearchGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.btnSearchGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchGroup.Location = new System.Drawing.Point(458, 87);
            this.btnSearchGroup.Name = "btnSearchGroup";
            this.btnSearchGroup.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(14);
            this.btnSearchGroup.Size = new System.Drawing.Size(18, 27);
            this.btnSearchGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSearchGroup.TabIndex = 26;
            this.btnSearchGroup.Text = "...";
            this.btnSearchGroup.TextColor = System.Drawing.Color.Silver;
            this.btnSearchGroup.ThemeAware = true;
            this.btnSearchGroup.Click += new System.EventHandler(this.BtnSearchGroup_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(237, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "حساب معین مانده اول دوره";
            // 
            // grpAccount
            // 
            this.grpAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAccount.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpAccount.Controls.Add(this.cmbType);
            this.grpAccount.Controls.Add(this.label6);
            this.grpAccount.Controls.Add(this.label11);
            this.grpAccount.Controls.Add(this.btnSearchMoein);
            this.grpAccount.Controls.Add(this.txtMoeinCode);
            this.grpAccount.Controls.Add(this.txtMoeinName);
            this.grpAccount.Controls.Add(this.txtDescription);
            this.grpAccount.Controls.Add(this.btnSearchGroup);
            this.grpAccount.Controls.Add(this.lblCode);
            this.grpAccount.Controls.Add(this.txtDateBirth);
            this.grpAccount.Controls.Add(this.cmbAmountMahiat);
            this.grpAccount.Controls.Add(this.cmbGroup);
            this.grpAccount.Controls.Add(this.txtCode);
            this.grpAccount.Controls.Add(this.label5);
            this.grpAccount.Controls.Add(this.label3);
            this.grpAccount.Controls.Add(this.txtAmount);
            this.grpAccount.Controls.Add(this.txtName);
            this.grpAccount.Controls.Add(this.label4);
            this.grpAccount.Controls.Add(this.label7);
            this.grpAccount.Controls.Add(this.label1);
            this.grpAccount.Controls.Add(this.label2);
            this.grpAccount.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpAccount.Location = new System.Drawing.Point(12, 12);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(846, 382);
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
            this.grpAccount.TabIndex = 55668;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbType.DisplayMember = "Name";
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbType.ForeColor = System.Drawing.Color.Black;
            this.cmbType.ItemHeight = 20;
            this.cmbType.Location = new System.Drawing.Point(18, 87);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(366, 28);
            this.cmbType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbType.TabIndex = 30;
            this.cmbType.ValueMember = "Guid";
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(16, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(366, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "نوع";
            // 
            // frmCustomer_PublicInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(870, 401);
            this.Controls.Add(this.grpAccount);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer_PublicInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات عمومی";
            this.Load += new System.EventHandler(this.FrmPerssonel_PublicInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPerssonel_PublicInfo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.cusGroupBindingSource)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource cusGroupBindingSource;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCode;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbGroup;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbAmountMahiat;
        private AmirCalendar.FarsiCalendar txtDateBirth;
        public System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.TextBox txtMoeinName;
        public System.Windows.Forms.TextBox txtMoeinCode;
        public DevComponents.DotNetBar.ButtonX btnSearchMoein;
        public DevComponents.DotNetBar.ButtonX btnSearchGroup;
        public System.Windows.Forms.Label label11;
        public DevComponents.DotNetBar.Controls.GroupPanel grpAccount;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbType;
        public System.Windows.Forms.Label label6;
    }
}