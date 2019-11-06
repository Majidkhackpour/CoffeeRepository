namespace Coffee_ManageMent
{
    partial class frmLogPerssonel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogPerssonel));
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
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.rbtnExit = new System.Windows.Forms.RadioButton();
            this.rbtnEnter = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSemat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.cmbPerssonel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mnuPrint_One = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint_All = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.grp1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.panelEx1.Location = new System.Drawing.Point(2, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(339, 43);
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
            this.panelEx1.TabIndex = 21;
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
            this.label4.Location = new System.Drawing.Point(157, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "تردد پرسنل";
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
            this.panelEx2.Location = new System.Drawing.Point(64, 21);
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
            this.panelEx2.TabIndex = 22;
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
            this.panelEx3.Location = new System.Drawing.Point(1, 297);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(339, 43);
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
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "انصراف";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Location = new System.Drawing.Point(168, 8);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish.Size = new System.Drawing.Size(156, 25);
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
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.ContextMenuStrip = this.contextMenuStrip1;
            this.grp1.Controls.Add(this.rbtnExit);
            this.grp1.Controls.Add(this.rbtnEnter);
            this.grp1.Controls.Add(this.label6);
            this.grp1.Controls.Add(this.txtTime);
            this.grp1.Controls.Add(this.label5);
            this.grp1.Controls.Add(this.label3);
            this.grp1.Controls.Add(this.lblSemat);
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.lblCode);
            this.grp1.Controls.Add(this.cmbPerssonel);
            this.grp1.Controls.Add(this.label7);
            this.grp1.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp1.Location = new System.Drawing.Point(1, 83);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(339, 212);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrint});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 50);
            // 
            // mnuPrint
            // 
            this.mnuPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrint_One,
            this.mnuPrint_All});
            this.mnuPrint.Image = global::Coffee_ManageMent.Properties.Resources.Imprimante;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(152, 24);
            this.mnuPrint.Text = "گزارش تردد";
            // 
            // rbtnExit
            // 
            this.rbtnExit.AutoSize = true;
            this.rbtnExit.BackColor = System.Drawing.Color.Transparent;
            this.rbtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnExit.Location = new System.Drawing.Point(65, 173);
            this.rbtnExit.Name = "rbtnExit";
            this.rbtnExit.Size = new System.Drawing.Size(53, 24);
            this.rbtnExit.TabIndex = 3;
            this.rbtnExit.TabStop = true;
            this.rbtnExit.Text = "خروج";
            this.rbtnExit.UseVisualStyleBackColor = false;
            // 
            // rbtnEnter
            // 
            this.rbtnEnter.AutoSize = true;
            this.rbtnEnter.BackColor = System.Drawing.Color.Transparent;
            this.rbtnEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnEnter.Location = new System.Drawing.Point(165, 173);
            this.rbtnEnter.Name = "rbtnEnter";
            this.rbtnEnter.Size = new System.Drawing.Size(51, 24);
            this.rbtnEnter.TabIndex = 2;
            this.rbtnEnter.TabStop = true;
            this.rbtnEnter.Text = "ورود";
            this.rbtnEnter.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(269, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 55603;
            this.label6.Text = "نوع تردد:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(51, 124);
            this.txtTime.Mask = "00:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(192, 27);
            this.txtTime.TabIndex = 1;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(282, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 55600;
            this.label5.Text = "ساعت:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(285, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 55601;
            this.label3.Text = "سمت:";
            // 
            // lblSemat
            // 
            this.lblSemat.AutoSize = true;
            this.lblSemat.BackColor = System.Drawing.Color.Transparent;
            this.lblSemat.Location = new System.Drawing.Point(123, 87);
            this.lblSemat.Name = "lblSemat";
            this.lblSemat.Size = new System.Drawing.Size(25, 20);
            this.lblSemat.TabIndex = 55599;
            this.lblSemat.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(260, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 55601;
            this.label2.Text = "کد تفصیلی:";
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(51, 51);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(175, 20);
            this.lblCode.TabIndex = 55599;
            this.lblCode.Text = "00";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPerssonel
            // 
            this.cmbPerssonel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPerssonel.DisplayMember = "Text";
            this.cmbPerssonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerssonel.ForeColor = System.Drawing.Color.Black;
            this.cmbPerssonel.ItemHeight = 20;
            this.cmbPerssonel.Location = new System.Drawing.Point(51, 9);
            this.cmbPerssonel.Name = "cmbPerssonel";
            this.cmbPerssonel.Size = new System.Drawing.Size(192, 28);
            this.cmbPerssonel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPerssonel.TabIndex = 0;
            this.cmbPerssonel.SelectedIndexChanged += new System.EventHandler(this.cmbPerssonel_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(271, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "شناسایی:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mnuPrint_One
            // 
            this.mnuPrint_One.Name = "mnuPrint_One";
            this.mnuPrint_One.Size = new System.Drawing.Size(200, 24);
            this.mnuPrint_One.Text = "گزارش تردد پرسنل جاری";
            this.mnuPrint_One.Click += new System.EventHandler(this.mnuPrint_One_Click_1);
            // 
            // mnuPrint_All
            // 
            this.mnuPrint_All.Name = "mnuPrint_All";
            this.mnuPrint_All.Size = new System.Drawing.Size(200, 24);
            this.mnuPrint_All.Text = "گزارش تردد همه پرسنل";
            this.mnuPrint_All.Click += new System.EventHandler(this.mnuPrint_All_Click);
            // 
            // frmLogPerssonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(341, 340);
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
            this.Name = "frmLogPerssonel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogPerssonel_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.Timer timer1;
        public DevComponents.DotNetBar.Controls.GroupPanel grp1;
        public System.Windows.Forms.Label label7;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbPerssonel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtTime;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.RadioButton rbtnExit;
        private System.Windows.Forms.RadioButton rbtnEnter;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblSemat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint_One;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint_All;
    }
}