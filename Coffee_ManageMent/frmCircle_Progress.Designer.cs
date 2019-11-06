namespace Coffee_ManageMent
{
    partial class frmCircle_Progress
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
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPass2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // circularProgress1
            // 
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(12, 3);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut;
            this.circularProgress1.ProgressColor = System.Drawing.Color.DarkRed;
            this.circularProgress1.ProgressTextVisible = true;
            this.circularProgress1.Size = new System.Drawing.Size(218, 212);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 32;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPass2
            // 
            this.lblPass2.AutoSize = true;
            this.lblPass2.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPass2.Location = new System.Drawing.Point(75, 224);
            this.lblPass2.Name = "lblPass2";
            this.lblPass2.Size = new System.Drawing.Size(99, 20);
            this.lblPass2.TabIndex = 7;
            this.lblPass2.Text = "لطفا منتظر بمانید...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCounter);
            this.panel1.Controls.Add(this.circularProgress1);
            this.panel1.Controls.Add(this.lblPass2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 279);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(84, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "%";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCounter.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCounter.Location = new System.Drawing.Point(112, 244);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(35, 29);
            this.lblCounter.TabIndex = 8;
            this.lblCounter.Text = "00";
            // 
            // frmCircle_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(237, 279);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCircle_Progress";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCounter;
    }
}