namespace Coffee_ManageMent.Perssonel
{
    partial class frmPerssonel_Contract
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
            AmirCalendar.FarsiDate farsiDate2 = new AmirCalendar.FarsiDate();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerssonel_Contract));
            this.txtEdu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContractCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTheTerm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpAccount = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnMarrie = new System.Windows.Forms.RadioButton();
            this.rbtnSingle = new System.Windows.Forms.RadioButton();
            this.txtEndDate = new AmirCalendar.FarsiCalendar();
            this.txtStartDate = new AmirCalendar.FarsiCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEdu
            // 
            this.txtEdu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtEdu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdu.ForeColor = System.Drawing.Color.Silver;
            this.txtEdu.Location = new System.Drawing.Point(18, 144);
            this.txtEdu.MaxLength = 32270;
            this.txtEdu.Name = "txtEdu";
            this.txtEdu.Size = new System.Drawing.Size(366, 27);
            this.txtEdu.TabIndex = 17;
            this.txtEdu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEdu.Enter += new System.EventHandler(this.TxtEdu_Enter);
            this.txtEdu.Leave += new System.EventHandler(this.TxtEdu_Leave);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(133, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(243, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "مدت قرارداد";
            // 
            // txtContractCode
            // 
            this.txtContractCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtContractCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractCode.ForeColor = System.Drawing.Color.Silver;
            this.txtContractCode.Location = new System.Drawing.Point(446, 35);
            this.txtContractCode.MaxLength = 4;
            this.txtContractCode.Name = "txtContractCode";
            this.txtContractCode.Size = new System.Drawing.Size(366, 27);
            this.txtContractCode.TabIndex = 17;
            this.txtContractCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractCode.Enter += new System.EventHandler(this.TxtContractCode_Enter);
            this.txtContractCode.Leave += new System.EventHandler(this.TxtContractCode_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(545, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "تاریخ آغاز قرارداد";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(32, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "تحصیلات (مدرک و رشته تحصیلی)";
            // 
            // txtTheTerm
            // 
            this.txtTheTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.txtTheTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTheTerm.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTheTerm.ForeColor = System.Drawing.Color.Silver;
            this.txtTheTerm.HideSelection = false;
            this.txtTheTerm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTheTerm.Location = new System.Drawing.Point(46, 35);
            this.txtTheTerm.MaxLength = 3;
            this.txtTheTerm.Name = "txtTheTerm";
            this.txtTheTerm.Size = new System.Drawing.Size(338, 27);
            this.txtTheTerm.TabIndex = 2;
            this.txtTheTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTheTerm.Enter += new System.EventHandler(this.TxtTheTerm_Enter);
            this.txtTheTerm.Leave += new System.EventHandler(this.TxtTheTerm_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(562, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "شماره قرارداد";
            // 
            // grpAccount
            // 
            this.grpAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAccount.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpAccount.Controls.Add(this.rbtnMarrie);
            this.grpAccount.Controls.Add(this.rbtnSingle);
            this.grpAccount.Controls.Add(this.txtEndDate);
            this.grpAccount.Controls.Add(this.txtStartDate);
            this.grpAccount.Controls.Add(this.txtEdu);
            this.grpAccount.Controls.Add(this.label4);
            this.grpAccount.Controls.Add(this.label10);
            this.grpAccount.Controls.Add(this.txtContractCode);
            this.grpAccount.Controls.Add(this.label7);
            this.grpAccount.Controls.Add(this.label5);
            this.grpAccount.Controls.Add(this.label3);
            this.grpAccount.Controls.Add(this.txtTheTerm);
            this.grpAccount.Controls.Add(this.label2);
            this.grpAccount.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpAccount.Location = new System.Drawing.Point(12, 9);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(846, 188);
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
            this.grpAccount.TabIndex = 55670;
            // 
            // rbtnMarrie
            // 
            this.rbtnMarrie.AutoSize = true;
            this.rbtnMarrie.BackColor = System.Drawing.Color.Transparent;
            this.rbtnMarrie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnMarrie.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbtnMarrie.Location = new System.Drawing.Point(652, 144);
            this.rbtnMarrie.Name = "rbtnMarrie";
            this.rbtnMarrie.Size = new System.Drawing.Size(56, 24);
            this.rbtnMarrie.TabIndex = 25;
            this.rbtnMarrie.TabStop = true;
            this.rbtnMarrie.Text = "متاهل";
            this.rbtnMarrie.UseVisualStyleBackColor = false;
            // 
            // rbtnSingle
            // 
            this.rbtnSingle.AutoSize = true;
            this.rbtnSingle.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSingle.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbtnSingle.Location = new System.Drawing.Point(761, 144);
            this.rbtnSingle.Name = "rbtnSingle";
            this.rbtnSingle.Size = new System.Drawing.Size(51, 24);
            this.rbtnSingle.TabIndex = 24;
            this.rbtnSingle.TabStop = true;
            this.rbtnSingle.Text = "مجرد";
            this.rbtnSingle.UseVisualStyleBackColor = false;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtEndDate.Location = new System.Drawing.Point(18, 87);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEndDate.Size = new System.Drawing.Size(366, 21);
            this.txtEndDate.TabIndex = 22;
            farsiDate1.FarsiSelectedDate = "1398/08/27";
            this.txtEndDate.Value = farsiDate1;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtStartDate.Location = new System.Drawing.Point(446, 87);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStartDate.Size = new System.Drawing.Size(366, 21);
            this.txtStartDate.TabIndex = 22;
            farsiDate2.FarsiSelectedDate = "1398/08/27";
            this.txtStartDate.Value = farsiDate2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(18, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "ماه";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(106, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "تاریخ پایان قرارداد";
            // 
            // frmPerssonel_Contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(870, 208);
            this.Controls.Add(this.grpAccount);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPerssonel_Contract";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات قرارداد";
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txtEdu;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtContractCode;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTheTerm;
        public System.Windows.Forms.Label label2;
        public DevComponents.DotNetBar.Controls.GroupPanel grpAccount;
        public System.Windows.Forms.Label label4;
        private AmirCalendar.FarsiCalendar txtEndDate;
        private AmirCalendar.FarsiCalendar txtStartDate;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.RadioButton rbtnMarrie;
        public System.Windows.Forms.RadioButton rbtnSingle;
    }
}