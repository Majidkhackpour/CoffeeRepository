namespace Coffee_ManageMent.Utility
{
    partial class frmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessage));
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessage.Location = new System.Drawing.Point(30, 27);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(322, 85);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "label1";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::Coffee_ManageMent.Properties.Resources.BlueSkin;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblOK
            // 
            this.lblOK.AutoSize = true;
            this.lblOK.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOK.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOK.Location = new System.Drawing.Point(217, 112);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(28, 24);
            this.lblOK.TabIndex = 3;
            this.lblOK.Text = "بله";
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            this.lblOK.MouseEnter += new System.EventHandler(this.lblOK_MouseEnter);
            this.lblOK.MouseLeave += new System.EventHandler(this.lblOK_MouseLeave);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblClose.Location = new System.Drawing.Point(161, 112);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(44, 24);
            this.lblClose.TabIndex = 3;
            this.lblClose.Text = "بستن";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancel.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCancel.Location = new System.Drawing.Point(118, 112);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(31, 24);
            this.lblCancel.TabIndex = 3;
            this.lblCancel.Text = "خیر";
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            this.lblCancel.MouseEnter += new System.EventHandler(this.lblCancel_MouseEnter);
            this.lblCancel.MouseLeave += new System.EventHandler(this.lblCancel_MouseLeave);
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 147);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMessage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMessage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblCancel;
    }
}