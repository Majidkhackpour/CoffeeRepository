namespace Coffee_ManageMent
{
    partial class frmTurn_Receipt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurn_Receipt));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTranfer_Number = new System.Windows.Forms.TextBox();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnSearchAcc = new DevComponents.DotNetBar.ButtonX();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grp2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvStore = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sell_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTour = new System.Windows.Forms.ToolStripMenuItem();
            this.grp3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbStore = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.grp1.SuspendLayout();
            this.grp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.grp3.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.panelEx1.TabIndex = 55667;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(455, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(412, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "مدیریت رسیدهای برگشت";
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
            this.panelEx2.Location = new System.Drawing.Point(360, 20);
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
            this.panelEx2.TabIndex = 55668;
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
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.Controls.Add(this.txtDate);
            this.grp1.Controls.Add(this.txtID);
            this.grp1.Controls.Add(this.label10);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.label5);
            this.grp1.Controls.Add(this.txtTranfer_Number);
            this.grp1.Controls.Add(this.txtBill);
            this.grp1.Controls.Add(this.label3);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Controls.Add(this.txtCode);
            this.grp1.Controls.Add(this.btnSearchAcc);
            this.grp1.Controls.Add(this.txtDelivery);
            this.grp1.Controls.Add(this.txtName);
            this.grp1.Controls.Add(this.label2);
            this.grp1.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp1.Location = new System.Drawing.Point(5, 82);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(903, 103);
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
            // txtDate
            // 
            // 
            // 
            // 
            this.txtDate.BackgroundStyle.Class = "TextBoxBorder";
            this.txtDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.ButtonClear.Visible = true;
            this.txtDate.Location = new System.Drawing.Point(35, 13);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(126, 26);
            this.txtDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtDate.TabIndex = 4;
            this.txtDate.Text = "";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(689, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 27);
            this.txtID.TabIndex = 0;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(168, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "تاریخ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(165, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "حواله:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(458, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "بارنامه:";
            // 
            // txtTranfer_Number
            // 
            this.txtTranfer_Number.HideSelection = false;
            this.txtTranfer_Number.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTranfer_Number.Location = new System.Drawing.Point(35, 61);
            this.txtTranfer_Number.Name = "txtTranfer_Number";
            this.txtTranfer_Number.Size = new System.Drawing.Size(126, 27);
            this.txtTranfer_Number.TabIndex = 7;
            this.txtTranfer_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTranfer_Number.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTranfer_Number_KeyDown);
            // 
            // txtBill
            // 
            this.txtBill.HideSelection = false;
            this.txtBill.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtBill.Location = new System.Drawing.Point(249, 61);
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(203, 27);
            this.txtBill.TabIndex = 6;
            this.txtBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBill_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(832, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "شماره:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(633, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "مبدا:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(528, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(99, 27);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // btnSearchAcc
            // 
            this.btnSearchAcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchAcc.Location = new System.Drawing.Point(487, 12);
            this.btnSearchAcc.Name = "btnSearchAcc";
            this.btnSearchAcc.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSearchAcc.Size = new System.Drawing.Size(35, 27);
            this.btnSearchAcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnSearchAcc.TabIndex = 2;
            this.btnSearchAcc.Text = "+";
            this.btnSearchAcc.Click += new System.EventHandler(this.btnSearchAcc_Click);
            // 
            // txtDelivery
            // 
            this.txtDelivery.HideSelection = false;
            this.txtDelivery.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDelivery.Location = new System.Drawing.Point(528, 61);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(261, 27);
            this.txtDelivery.TabIndex = 5;
            this.txtDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDelivery_KeyDown);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(249, 12);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(232, 27);
            this.txtName.TabIndex = 3;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(799, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "تحویل دهنده:";
            // 
            // txtNotice
            // 
            this.txtNotice.HideSelection = false;
            this.txtNotice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNotice.Location = new System.Drawing.Point(442, 9);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(346, 30);
            this.txtNotice.TabIndex = 0;
            this.txtNotice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotice_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(815, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "توضیحات:";
            // 
            // grp2
            // 
            this.grp2.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp2.Controls.Add(this.dgvStore);
            this.grp2.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp2.Location = new System.Drawing.Point(6, 190);
            this.grp2.Name = "grp2";
            this.grp2.Size = new System.Drawing.Size(903, 314);
            // 
            // 
            // 
            this.grp2.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grp2.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grp2.Style.BackColorGradientAngle = 90;
            this.grp2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderBottomWidth = 1;
            this.grp2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grp2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderLeftWidth = 1;
            this.grp2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderRightWidth = 1;
            this.grp2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp2.Style.BorderTopWidth = 1;
            this.grp2.Style.CornerDiameter = 4;
            this.grp2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp2.Style.TextColor = System.Drawing.Color.Black;
            this.grp2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp2.TabIndex = 1;
            // 
            // dgvStore
            // 
            this.dgvStore.AllowUserToResizeColumns = false;
            this.dgvStore.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStore.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.P_Name,
            this.Entity,
            this.Notice,
            this.Sell_Price,
            this.Cost});
            this.dgvStore.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStore.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvStore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStore.Location = new System.Drawing.Point(3, 3);
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvStore.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvStore.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStore.Size = new System.Drawing.Size(891, 302);
            this.dgvStore.TabIndex = 0;
            this.dgvStore.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStore_DataError);
            this.dgvStore.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvStore_EditingControlShowing);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "P_Code";
            this.Code.FillWeight = 96.7576F;
            this.Code.HeaderText = "کد کالا";
            this.Code.Name = "Code";
            // 
            // P_Name
            // 
            this.P_Name.DataPropertyName = "P_Show_Name";
            this.P_Name.FillWeight = 243.6548F;
            this.P_Name.HeaderText = "شرح";
            this.P_Name.Name = "P_Name";
            this.P_Name.ReadOnly = true;
            // 
            // Entity
            // 
            this.Entity.DataPropertyName = "Entity";
            this.Entity.FillWeight = 48.04599F;
            this.Entity.HeaderText = "تعداد";
            this.Entity.Name = "Entity";
            // 
            // Notice
            // 
            this.Notice.DataPropertyName = "Notice";
            this.Notice.HeaderText = "علت برگشت";
            this.Notice.Name = "Notice";
            // 
            // Sell_Price
            // 
            this.Sell_Price.DataPropertyName = "E_Price";
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.Sell_Price.DefaultCellStyle = dataGridViewCellStyle10;
            this.Sell_Price.FillWeight = 69.33315F;
            this.Sell_Price.HeaderText = "فی واحد";
            this.Sell_Price.Name = "Sell_Price";
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Total";
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle11;
            this.Cost.FillWeight = 109.269F;
            this.Cost.HeaderText = "فی کل";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete,
            this.toolStripMenuItem2,
            this.mnuDeleteAll,
            this.mnuTour});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(204, 82);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Coffee_ManageMent.Properties.Resources.delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(203, 24);
            this.mnuDelete.Text = "حذف کالا";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // mnuDeleteAll
            // 
            this.mnuDeleteAll.Image = global::Coffee_ManageMent.Properties.Resources.delete;
            this.mnuDeleteAll.Name = "mnuDeleteAll";
            this.mnuDeleteAll.Size = new System.Drawing.Size(203, 24);
            this.mnuDeleteAll.Text = "حذف همه کالاها";
            this.mnuDeleteAll.Click += new System.EventHandler(this.mnuDeleteAll_Click);
            // 
            // mnuTour
            // 
            this.mnuTour.Image = global::Coffee_ManageMent.Properties.Resources.list__3_;
            this.mnuTour.Name = "mnuTour";
            this.mnuTour.Size = new System.Drawing.Size(203, 24);
            this.mnuTour.Text = "مشاهده گردش مختصر کالا";
            this.mnuTour.Click += new System.EventHandler(this.mnuTour_Click);
            // 
            // grp3
            // 
            this.grp3.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp3.Controls.Add(this.cmbStore);
            this.grp3.Controls.Add(this.label11);
            this.grp3.Controls.Add(this.txtNotice);
            this.grp3.Controls.Add(this.label6);
            this.grp3.Controls.Add(this.txtSum);
            this.grp3.Controls.Add(this.label9);
            this.grp3.Controls.Add(this.txtEntity);
            this.grp3.Controls.Add(this.label8);
            this.grp3.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp3.Location = new System.Drawing.Point(6, 510);
            this.grp3.Name = "grp3";
            this.grp3.Size = new System.Drawing.Size(903, 103);
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
            this.grp3.TabIndex = 2;
            // 
            // cmbStore
            // 
            this.cmbStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStore.DisplayMember = "Text";
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.ForeColor = System.Drawing.Color.Black;
            this.cmbStore.ItemHeight = 20;
            this.cmbStore.Location = new System.Drawing.Point(442, 56);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(346, 28);
            this.cmbStore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbStore.TabIndex = 2;
            this.cmbStore.SelectedIndexChanged += new System.EventHandler(this.cmbStore_SelectedIndexChanged);
            this.cmbStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStore_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(839, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "انبار:";
            // 
            // txtSum
            // 
            this.txtSum.Enabled = false;
            this.txtSum.HideSelection = false;
            this.txtSum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSum.Location = new System.Drawing.Point(34, 61);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(306, 27);
            this.txtSum.TabIndex = 3;
            this.txtSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(349, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "جمع ریالی:";
            // 
            // txtEntity
            // 
            this.txtEntity.Enabled = false;
            this.txtEntity.HideSelection = false;
            this.txtEntity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtEntity.Location = new System.Drawing.Point(34, 12);
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.ReadOnly = true;
            this.txtEntity.Size = new System.Drawing.Size(306, 27);
            this.txtEntity.TabIndex = 1;
            this.txtEntity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(346, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "جمع مقدار:";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnClose);
            this.panelEx3.Controls.Add(this.btnFinish);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(0, 618);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(914, 43);
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
            this.panelEx3.TabIndex = 3;
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
            this.btnFinish.Location = new System.Drawing.Point(736, 8);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnFinish.Size = new System.Drawing.Size(142, 25);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "تایید";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            // frmTurn_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(915, 663);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.grp3);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTurn_Receipt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTurn_Receipt_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.grp2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grp3.ResumeLayout(false);
            this.grp3.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        public DevComponents.DotNetBar.Controls.GroupPanel grp1;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtDate;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtNotice;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtBill;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCode;
        public DevComponents.DotNetBar.ButtonX btnSearchAcc;
        public System.Windows.Forms.TextBox txtDelivery;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtTranfer_Number;
        public DevComponents.DotNetBar.Controls.GroupPanel grp2;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgvStore;
        public DevComponents.DotNetBar.Controls.GroupPanel grp3;
        public System.Windows.Forms.TextBox txtSum;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtEntity;
        public System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sell_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbStore;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem mnuTour;
    }
}