namespace Coffee_ManageMent
{
    partial class frmWeb_Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeb_Browser));
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnBack = new DevComponents.DotNetBar.ButtonX();
            this.btnForward = new DevComponents.DotNetBar.ButtonX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnGo = new DevComponents.DotNetBar.ButtonX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.picShow_Fav = new System.Windows.Forms.PictureBox();
            this.picHistory = new System.Windows.Forms.PictureBox();
            this.picBing = new System.Windows.Forms.PictureBox();
            this.picYahoo = new System.Windows.Forms.PictureBox();
            this.picGoogle = new System.Windows.Forms.PictureBox();
            this.picFavorite = new System.Windows.Forms.PictureBox();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow_Fav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYahoo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoogle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavorite)).BeginInit();
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
            this.panelEx1.Location = new System.Drawing.Point(0, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1211, 43);
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
            this.panelEx1.TabIndex = 35;
            this.panelEx1.Click += new System.EventHandler(this.panelEx1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(869, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "مرورگر";
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
            this.panelEx2.Location = new System.Drawing.Point(501, 20);
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
            this.panelEx2.TabIndex = 36;
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
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(0, 666);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1211, 43);
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
            this.panelEx3.TabIndex = 40;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnBack
            // 
            this.btnBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Location = new System.Drawing.Point(8, 82);
            this.btnBack.Name = "btnBack";
            this.btnBack.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnBack.Size = new System.Drawing.Size(27, 27);
            this.btnBack.TabIndex = 41;
            this.btnBack.Text = ">";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnForward.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForward.Location = new System.Drawing.Point(41, 82);
            this.btnForward.Name = "btnForward";
            this.btnForward.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnForward.Size = new System.Drawing.Size(27, 27);
            this.btnForward.TabIndex = 41;
            this.btnForward.Text = "<";
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(75, 82);
            this.txtSearch.MaxLength = 25;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(872, 27);
            this.txtSearch.TabIndex = 42;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearch.WatermarkText = "... Type URL";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnGo
            // 
            this.btnGo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Location = new System.Drawing.Point(953, 82);
            this.btnGo.Name = "btnGo";
            this.btnGo.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnGo.Size = new System.Drawing.Size(55, 27);
            this.btnGo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnGo.TabIndex = 41;
            this.btnGo.Text = "GO";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(8, 193);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1190, 467);
            this.webBrowser1.TabIndex = 44;
            // 
            // picShow_Fav
            // 
            this.picShow_Fav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShow_Fav.Image = global::Coffee_ManageMent.Properties.Resources.star;
            this.picShow_Fav.Location = new System.Drawing.Point(1109, 82);
            this.picShow_Fav.Name = "picShow_Fav";
            this.picShow_Fav.Size = new System.Drawing.Size(89, 86);
            this.picShow_Fav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShow_Fav.TabIndex = 43;
            this.picShow_Fav.TabStop = false;
            this.picShow_Fav.Click += new System.EventHandler(this.picShow_Fav_Click);
            // 
            // picHistory
            // 
            this.picHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHistory.Image = global::Coffee_ManageMent.Properties.Resources.history_clock_button;
            this.picHistory.Location = new System.Drawing.Point(1014, 82);
            this.picHistory.Name = "picHistory";
            this.picHistory.Size = new System.Drawing.Size(89, 86);
            this.picHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHistory.TabIndex = 43;
            this.picHistory.TabStop = false;
            this.picHistory.Click += new System.EventHandler(this.picHistory_Click);
            // 
            // picBing
            // 
            this.picBing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBing.Image = global::Coffee_ManageMent.Properties.Resources.bing;
            this.picBing.Location = new System.Drawing.Point(140, 115);
            this.picBing.Name = "picBing";
            this.picBing.Size = new System.Drawing.Size(60, 72);
            this.picBing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBing.TabIndex = 43;
            this.picBing.TabStop = false;
            this.picBing.Click += new System.EventHandler(this.picBing_Click);
            // 
            // picYahoo
            // 
            this.picYahoo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picYahoo.Image = global::Coffee_ManageMent.Properties.Resources.yahoo_logo;
            this.picYahoo.Location = new System.Drawing.Point(74, 115);
            this.picYahoo.Name = "picYahoo";
            this.picYahoo.Size = new System.Drawing.Size(60, 72);
            this.picYahoo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picYahoo.TabIndex = 43;
            this.picYahoo.TabStop = false;
            this.picYahoo.Click += new System.EventHandler(this.picYahoo_Click);
            // 
            // picGoogle
            // 
            this.picGoogle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGoogle.Image = global::Coffee_ManageMent.Properties.Resources.google_plus_logo;
            this.picGoogle.Location = new System.Drawing.Point(8, 115);
            this.picGoogle.Name = "picGoogle";
            this.picGoogle.Size = new System.Drawing.Size(60, 72);
            this.picGoogle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGoogle.TabIndex = 43;
            this.picGoogle.TabStop = false;
            this.picGoogle.Click += new System.EventHandler(this.picGoogle_Click);
            // 
            // picFavorite
            // 
            this.picFavorite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFavorite.Image = global::Coffee_ManageMent.Properties.Resources.star;
            this.picFavorite.Location = new System.Drawing.Point(921, 82);
            this.picFavorite.Name = "picFavorite";
            this.picFavorite.Size = new System.Drawing.Size(26, 27);
            this.picFavorite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFavorite.TabIndex = 43;
            this.picFavorite.TabStop = false;
            this.picFavorite.Click += new System.EventHandler(this.picFavorite_Click);
            // 
            // frmWeb_Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.panelEx1;
            this.ClientSize = new System.Drawing.Size(1210, 709);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.picShow_Fav);
            this.Controls.Add(this.picHistory);
            this.Controls.Add(this.picBing);
            this.Controls.Add(this.picYahoo);
            this.Controls.Add(this.picGoogle);
            this.Controls.Add(this.picFavorite);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWeb_Browser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmWeb_Browser_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow_Fav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYahoo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoogle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavorite)).EndInit();
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
        private System.Windows.Forms.Timer timer1;
        public DevComponents.DotNetBar.ButtonX btnBack;
        public DevComponents.DotNetBar.ButtonX btnForward;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        public DevComponents.DotNetBar.ButtonX btnGo;
        private System.Windows.Forms.PictureBox picFavorite;
        private System.Windows.Forms.PictureBox picGoogle;
        private System.Windows.Forms.PictureBox picYahoo;
        private System.Windows.Forms.PictureBox picBing;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox picHistory;
        private System.Windows.Forms.PictureBox picShow_Fav;
    }
}