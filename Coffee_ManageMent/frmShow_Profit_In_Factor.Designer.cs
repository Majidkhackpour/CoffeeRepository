namespace Coffee_ManageMent
{
    partial class frmShow_Profit_In_Factor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow_Profit_In_Factor));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.dgvStore = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtCustomer_Name = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.grp3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSum_Factor = new System.Windows.Forms.TextBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBuy = new System.Windows.Forms.Label();
            this.lblSell = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblState_Name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Show_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.grp3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
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
            this.panelEx1.Location = new System.Drawing.Point(0, 2);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(914, 43);
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
            this.panelEx1.TabIndex = 55629;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(308, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(535, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "نمایش میزان سود در فاکتور فروش";
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
            this.panelEx2.Location = new System.Drawing.Point(360, 21);
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
            this.panelEx2.TabIndex = 55630;
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
            // dgvStore
            // 
            this.dgvStore.AllowUserToAddRows = false;
            this.dgvStore.AllowUserToDeleteRows = false;
            this.dgvStore.AllowUserToResizeColumns = false;
            this.dgvStore.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStore.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Radif,
            this.P_Code,
            this.P_Show_Name,
            this.Buy_Price,
            this.Price});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStore.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStore.Location = new System.Drawing.Point(1, 146);
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.ReadOnly = true;
            this.dgvStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStore.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStore.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStore.Size = new System.Drawing.Size(913, 355);
            this.dgvStore.TabIndex = 55631;
            this.dgvStore.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStore_CellFormatting);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnClose);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(1, 569);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(913, 43);
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
            this.panelEx3.TabIndex = 55635;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(11, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "انصراف";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtCustomer_Name
            // 
            this.txtCustomer_Name.Location = new System.Drawing.Point(450, 13);
            this.txtCustomer_Name.Name = "txtCustomer_Name";
            this.txtCustomer_Name.Size = new System.Drawing.Size(239, 27);
            this.txtCustomer_Name.TabIndex = 55647;
            this.txtCustomer_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(695, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 20);
            this.label21.TabIndex = 55648;
            this.label21.Text = "مشتری:";
            // 
            // grp3
            // 
            this.grp3.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp3.Controls.Add(this.label5);
            this.grp3.Controls.Add(this.txtID);
            this.grp3.Controls.Add(this.txtSum_Factor);
            this.grp3.Controls.Add(this.txtDate);
            this.grp3.Controls.Add(this.label10);
            this.grp3.Controls.Add(this.txtCustomer_Name);
            this.grp3.Controls.Add(this.label6);
            this.grp3.Controls.Add(this.label21);
            this.grp3.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp3.Location = new System.Drawing.Point(1, 80);
            this.grp3.Name = "grp3";
            this.grp3.Size = new System.Drawing.Size(913, 60);
            // 
            // 
            // 
            this.grp3.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grp3.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grp3.Style.BackColorGradientAngle = 90;
            this.grp3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderBottomWidth = 1;
            this.grp3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grp3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderLeftWidth = 1;
            this.grp3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderRightWidth = 1;
            this.grp3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp3.Style.BorderTopWidth = 1;
            this.grp3.Style.CornerDiameter = 4;
            this.grp3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp3.Style.TextColor = System.Drawing.Color.Black;
            this.grp3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp3.TabIndex = 55649;
            // 
            // txtDate
            // 
            // 
            // 
            // 
            this.txtDate.BackgroundStyle.Class = "TextBoxBorder";
            this.txtDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.ButtonClear.Visible = true;
            this.txtDate.Location = new System.Drawing.Point(269, 13);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(126, 26);
            this.txtDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtDate.TabIndex = 55649;
            this.txtDate.Text = "";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(407, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 55650;
            this.label10.Text = "تاریخ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(204, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 55652;
            this.label5.Text = "مبلغ:";
            // 
            // txtSum_Factor
            // 
            this.txtSum_Factor.HideSelection = false;
            this.txtSum_Factor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSum_Factor.Location = new System.Drawing.Point(13, 13);
            this.txtSum_Factor.Name = "txtSum_Factor";
            this.txtSum_Factor.Size = new System.Drawing.Size(185, 27);
            this.txtSum_Factor.TabIndex = 55651;
            this.txtSum_Factor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.Controls.Add(this.lblState_Name);
            this.groupPanel1.Controls.Add(this.lblState);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.lblSell);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.lblBuy);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(1, 505);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(913, 60);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupPanel1.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 55650;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(187, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 55652;
            this.label1.Text = "وضعیت:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(487, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 55650;
            this.label2.Text = "جمع فی فروش:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(811, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 55648;
            this.label3.Text = "جمع فی خرید:";
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.BackColor = System.Drawing.Color.Transparent;
            this.lblBuy.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBuy.Location = new System.Drawing.Point(682, 19);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(28, 24);
            this.lblBuy.TabIndex = 55648;
            this.lblBuy.Text = "00";
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.BackColor = System.Drawing.Color.Transparent;
            this.lblSell.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSell.Location = new System.Drawing.Point(338, 15);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(28, 24);
            this.lblSell.TabIndex = 55650;
            this.lblSell.Text = "00";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblState.Location = new System.Drawing.Point(108, 19);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(28, 24);
            this.lblState.TabIndex = 55652;
            this.lblState.Text = "00";
            // 
            // lblState_Name
            // 
            this.lblState_Name.AutoSize = true;
            this.lblState_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblState_Name.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblState_Name.Location = new System.Drawing.Point(47, 19);
            this.lblState_Name.Name = "lblState_Name";
            this.lblState_Name.Size = new System.Drawing.Size(28, 24);
            this.lblState_Name.TabIndex = 55652;
            this.lblState_Name.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(827, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 55648;
            this.label6.Text = "ش فاکتور:";
            // 
            // txtID
            // 
            this.txtID.HideSelection = false;
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtID.Location = new System.Drawing.Point(748, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(73, 27);
            this.txtID.TabIndex = 55651;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Radif
            // 
            this.Radif.FillWeight = 61.89809F;
            this.Radif.HeaderText = "ردیف";
            this.Radif.Name = "Radif";
            this.Radif.ReadOnly = true;
            // 
            // P_Code
            // 
            this.P_Code.DataPropertyName = "P_Code";
            this.P_Code.FillWeight = 68.08987F;
            this.P_Code.HeaderText = "کد کالا";
            this.P_Code.Name = "P_Code";
            this.P_Code.ReadOnly = true;
            this.P_Code.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // P_Show_Name
            // 
            this.P_Show_Name.DataPropertyName = "P_Show_Name";
            this.P_Show_Name.FillWeight = 148.1639F;
            this.P_Show_Name.HeaderText = "عنوان";
            this.P_Show_Name.Name = "P_Show_Name";
            this.P_Show_Name.ReadOnly = true;
            // 
            // Buy_Price
            // 
            this.Buy_Price.DataPropertyName = "Buy_Price";
            this.Buy_Price.FillWeight = 108.055F;
            this.Buy_Price.HeaderText = "فی آخرین خرید";
            this.Buy_Price.Name = "Buy_Price";
            this.Buy_Price.ReadOnly = true;
            this.Buy_Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.FillWeight = 150.3414F;
            this.Price.HeaderText = "فروش در فاکتور";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // frmShow_Profit_In_Factor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(915, 612);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.grp3);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.dgvStore);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShow_Profit_In_Factor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmShow_Profit_In_Factor_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.grp3.ResumeLayout(false);
            this.grp3.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
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
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvStore;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.Timer timer1;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public System.Windows.Forms.TextBox txtCustomer_Name;
        public System.Windows.Forms.Label label21;
        public DevComponents.DotNetBar.Controls.GroupPanel grp3;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtDate;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtSum_Factor;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public System.Windows.Forms.Label lblState_Name;
        public System.Windows.Forms.Label lblState;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblSell;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblBuy;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radif;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Show_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buy_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}