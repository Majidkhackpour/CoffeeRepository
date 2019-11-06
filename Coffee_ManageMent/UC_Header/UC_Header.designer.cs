namespace UC_Header
{
    partial class UC_Header
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Panel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Panel1.Controls.Add(this.lblTitle);
            this.Panel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.Panel1.Location = new System.Drawing.Point(0, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(365, 55);
            this.Panel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.Panel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.Panel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.Panel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.Panel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.Panel1.Style.BorderWidth = 2;
            this.Panel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.Panel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Panel1.Style.GradientAngle = 90;
            this.Panel1.TabIndex = 0;
            // 
            // panelEx1
            // 
            this.panelEx1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lblSec);
            this.panelEx1.Controls.Add(this.lblMin);
            this.panelEx1.Controls.Add(this.lblHour);
            this.panelEx1.Controls.Add(this.lblNewDate);
            this.panelEx1.Controls.Add(this.lblDay);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(61, 35);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(240, 55);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("B Titr", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(3, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(352, 39);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "عنوان";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDay.ForeColor = System.Drawing.Color.Silver;
            this.lblDay.Location = new System.Drawing.Point(182, 27);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(45, 20);
            this.lblDay.TabIndex = 7;
            this.lblDay.Text = "چهارشنبه";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewDate
            // 
            this.lblNewDate.AutoSize = true;
            this.lblNewDate.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNewDate.ForeColor = System.Drawing.Color.Silver;
            this.lblNewDate.Location = new System.Drawing.Point(104, 27);
            this.lblNewDate.Name = "lblNewDate";
            this.lblNewDate.Size = new System.Drawing.Size(80, 20);
            this.lblNewDate.TabIndex = 7;
            this.lblNewDate.Text = "هفت مهرماه 1398";
            this.lblNewDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHour.ForeColor = System.Drawing.Color.Silver;
            this.lblHour.Location = new System.Drawing.Point(9, 27);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(22, 20);
            this.lblHour.TabIndex = 7;
            this.lblHour.Text = "23";
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSec.ForeColor = System.Drawing.Color.Silver;
            this.lblSec.Location = new System.Drawing.Point(33, 27);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(12, 20);
            this.lblSec.TabIndex = 7;
            this.lblSec.Text = ":";
            this.lblSec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMin.ForeColor = System.Drawing.Color.Silver;
            this.lblMin.Location = new System.Drawing.Point(49, 27);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(22, 20);
            this.lblMin.TabIndex = 7;
            this.lblMin.Text = "23";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UC_Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.panelEx1);
            this.Name = "UC_Header";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(367, 94);
            this.Load += new System.EventHandler(this.UC_Header_Load);
            this.Panel1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx Panel1;
        private System.Windows.Forms.Label lblTitle;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Timer timer1;
    }
}
