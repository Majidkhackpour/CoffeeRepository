namespace Coffee_ManageMent
{
    partial class frmProduct_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct_Setting));
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
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPatch = new DevComponents.DotNetBar.ButtonX();
            this.txtPatch = new System.Windows.Forms.TextBox();
            this.rbtnTec_Code = new System.Windows.Forms.RadioButton();
            this.rbtnCode = new System.Windows.Forms.RadioButton();
            this.rbtnBarcode = new System.Windows.Forms.RadioButton();
            this.cmbUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chbType_Name = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.grp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(0, 3);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(419, 43);
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
            this.panelEx1.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(173, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "تنظیمات کالا";
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
            this.panelEx2.Location = new System.Drawing.Point(96, 22);
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
            this.panelEx2.TabIndex = 43;
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
            this.panelEx3.Location = new System.Drawing.Point(0, 306);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(419, 43);
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
            // btnFinish1
            // 
            this.btnFinish1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFinish1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish1.Location = new System.Drawing.Point(261, 8);
            this.btnFinish1.Name = "btnFinish1";
            this.btnFinish1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish1.Size = new System.Drawing.Size(142, 25);
            this.btnFinish1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish1.TabIndex = 0;
            this.btnFinish1.Text = "تایید";
            this.btnFinish1.Click += new System.EventHandler(this.btnFinish1_Click);
            // 
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.Controls.Add(this.label5);
            this.grp1.Controls.Add(this.btnPatch);
            this.grp1.Controls.Add(this.txtPatch);
            this.grp1.Controls.Add(this.rbtnTec_Code);
            this.grp1.Controls.Add(this.rbtnCode);
            this.grp1.Controls.Add(this.rbtnBarcode);
            this.grp1.Controls.Add(this.cmbUnit);
            this.grp1.Controls.Add(this.chbType_Name);
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.label3);
            this.grp1.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp1.Location = new System.Drawing.Point(5, 80);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(409, 219);
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
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("B Yekan", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(23, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 48);
            this.label5.TabIndex = 49;
            this.label5.Text = "تذکر\r\nبرای جلوگیری از بروز اشکالات احتمالی، توصیه می شود تصاویر را در درایوی غیر " +
    "از درایو ویندوز ذخیره نمایید.";
            // 
            // btnPatch
            // 
            this.btnPatch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPatch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPatch.Location = new System.Drawing.Point(364, 95);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnPatch.Size = new System.Drawing.Size(35, 27);
            this.btnPatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnPatch.TabIndex = 1;
            this.btnPatch.Text = "+";
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // txtPatch
            // 
            this.txtPatch.Enabled = false;
            this.txtPatch.Font = new System.Drawing.Font("B Homa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPatch.Location = new System.Drawing.Point(4, 95);
            this.txtPatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPatch.Name = "txtPatch";
            this.txtPatch.ReadOnly = true;
            this.txtPatch.Size = new System.Drawing.Size(353, 27);
            this.txtPatch.TabIndex = 55603;
            this.txtPatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnTec_Code
            // 
            this.rbtnTec_Code.AutoSize = true;
            this.rbtnTec_Code.BackColor = System.Drawing.Color.Transparent;
            this.rbtnTec_Code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnTec_Code.Location = new System.Drawing.Point(59, 176);
            this.rbtnTec_Code.Name = "rbtnTec_Code";
            this.rbtnTec_Code.Size = new System.Drawing.Size(60, 24);
            this.rbtnTec_Code.TabIndex = 5;
            this.rbtnTec_Code.TabStop = true;
            this.rbtnTec_Code.Text = "کد فنی";
            this.rbtnTec_Code.UseVisualStyleBackColor = false;
            // 
            // rbtnCode
            // 
            this.rbtnCode.AutoSize = true;
            this.rbtnCode.BackColor = System.Drawing.Color.Transparent;
            this.rbtnCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnCode.Location = new System.Drawing.Point(149, 176);
            this.rbtnCode.Name = "rbtnCode";
            this.rbtnCode.Size = new System.Drawing.Size(57, 24);
            this.rbtnCode.TabIndex = 4;
            this.rbtnCode.TabStop = true;
            this.rbtnCode.Text = "کد کالا";
            this.rbtnCode.UseVisualStyleBackColor = false;
            // 
            // rbtnBarcode
            // 
            this.rbtnBarcode.AutoSize = true;
            this.rbtnBarcode.BackColor = System.Drawing.Color.Transparent;
            this.rbtnBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBarcode.Location = new System.Drawing.Point(236, 176);
            this.rbtnBarcode.Name = "rbtnBarcode";
            this.rbtnBarcode.Size = new System.Drawing.Size(52, 24);
            this.rbtnBarcode.TabIndex = 3;
            this.rbtnBarcode.TabStop = true;
            this.rbtnBarcode.Text = "بارکد";
            this.rbtnBarcode.UseVisualStyleBackColor = false;
            // 
            // cmbUnit
            // 
            this.cmbUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUnit.DisplayMember = "Text";
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.ForeColor = System.Drawing.Color.Black;
            this.cmbUnit.ItemHeight = 20;
            this.cmbUnit.Location = new System.Drawing.Point(59, 133);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(229, 28);
            this.cmbUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbUnit.TabIndex = 2;
            // 
            // chbType_Name
            // 
            this.chbType_Name.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbType_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbType_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbType_Name.Location = new System.Drawing.Point(211, 14);
            this.chbType_Name.Name = "chbType_Name";
            this.chbType_Name.Size = new System.Drawing.Size(188, 23);
            this.chbType_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbType_Name.TabIndex = 0;
            this.chbType_Name.Text = "استفاده از نام طبقه بندی در نام کالا";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(59, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "الگو: نام کالا (نام طبقه بندی)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(324, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "شناسایی کالا:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(310, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "واحد پیش فرض:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(256, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "مسیر ذخیره سازی تصویر کالا";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmProduct_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(420, 349);
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
            this.Name = "frmProduct_Setting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmProduct_Setting_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
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
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish1;
        public DevComponents.DotNetBar.Controls.GroupPanel grp1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbType_Name;
        public System.Windows.Forms.Label label2;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbUnit;
        private System.Windows.Forms.TextBox txtPatch;
        private System.Windows.Forms.RadioButton rbtnCode;
        private System.Windows.Forms.RadioButton rbtnBarcode;
        public DevComponents.DotNetBar.ButtonX btnPatch;
        private System.Windows.Forms.RadioButton rbtnTec_Code;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label5;
    }
}