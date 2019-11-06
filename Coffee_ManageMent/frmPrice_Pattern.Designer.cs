namespace Coffee_ManageMent
{
    partial class frmPrice_Pattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrice_Pattern));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtExpiration_Date = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtStart_Date = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.chbState = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.grp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.btnFinish.Location = new System.Drawing.Point(384, 8);
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
            this.panelEx3.Location = new System.Drawing.Point(1, 366);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(557, 43);
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
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label27.Location = new System.Drawing.Point(275, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(237, 20);
            this.label27.TabIndex = 4;
            this.label27.Text = "مدیریت الگوی قیمت";
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
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.label27);
            this.panelEx1.Controls.Add(this.picClose);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(1, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(557, 43);
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
            this.panelEx1.TabIndex = 58;
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
            this.panelEx2.Location = new System.Drawing.Point(178, 20);
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
            this.panelEx2.TabIndex = 59;
            // 
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.Controls.Add(this.txtExpiration_Date);
            this.grp1.Controls.Add(this.txtStart_Date);
            this.grp1.Controls.Add(this.chbState);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Controls.Add(this.label10);
            this.grp1.Controls.Add(this.txtNotice);
            this.grp1.Controls.Add(this.txtDescription);
            this.grp1.Controls.Add(this.label4);
            this.grp1.Controls.Add(this.txtCode);
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.label3);
            this.grp1.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp1.Location = new System.Drawing.Point(7, 82);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(543, 281);
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
            // txtExpiration_Date
            // 
            // 
            // 
            // 
            this.txtExpiration_Date.BackgroundStyle.Class = "TextBoxBorder";
            this.txtExpiration_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExpiration_Date.ButtonClear.Visible = true;
            this.txtExpiration_Date.Location = new System.Drawing.Point(39, 108);
            this.txtExpiration_Date.Mask = "0000/00/00";
            this.txtExpiration_Date.Name = "txtExpiration_Date";
            this.txtExpiration_Date.Size = new System.Drawing.Size(148, 26);
            this.txtExpiration_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtExpiration_Date.TabIndex = 4;
            this.txtExpiration_Date.Text = "";
            this.txtExpiration_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExpiration_Date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExpiration_Date_KeyDown);
            // 
            // txtStart_Date
            // 
            // 
            // 
            // 
            this.txtStart_Date.BackgroundStyle.Class = "TextBoxBorder";
            this.txtStart_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStart_Date.ButtonClear.Visible = true;
            this.txtStart_Date.Location = new System.Drawing.Point(283, 108);
            this.txtStart_Date.Mask = "0000/00/00";
            this.txtStart_Date.Name = "txtStart_Date";
            this.txtStart_Date.Size = new System.Drawing.Size(138, 26);
            this.txtStart_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtStart_Date.TabIndex = 3;
            this.txtStart_Date.Text = "";
            this.txtStart_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStart_Date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStart_Date_KeyDown);
            // 
            // chbState
            // 
            this.chbState.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbState.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbState.Location = new System.Drawing.Point(99, 21);
            this.chbState.Name = "chbState";
            this.chbState.Size = new System.Drawing.Size(78, 23);
            this.chbState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbState.TabIndex = 1;
            this.chbState.Text = "فعال";
            this.chbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chbState_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(193, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "تاریخ خاتمه:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(436, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "تاریخ شروع:";
            // 
            // txtNotice
            // 
            this.txtNotice.HideSelection = false;
            this.txtNotice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNotice.Location = new System.Drawing.Point(39, 149);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(382, 114);
            this.txtNotice.TabIndex = 5;
            this.txtNotice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotice_KeyDown);
            // 
            // txtDescription
            // 
            this.txtDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDescription.HideSelection = false;
            this.txtDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDescription.Location = new System.Drawing.Point(39, 61);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(382, 27);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(446, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "توضیحات:";
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(283, 21);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(138, 27);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(469, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "شرح:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(456, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "کد الگو:";
            // 
            // frmPrice_Pattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(559, 409);
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
            this.Name = "frmPrice_Pattern";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPrice_Pattern_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        public System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox picClose;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Timer timer1;
        public DevComponents.DotNetBar.Controls.GroupPanel grp1;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbState;
        public System.Windows.Forms.TextBox txtNotice;
        public System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtExpiration_Date;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtStart_Date;
    }
}