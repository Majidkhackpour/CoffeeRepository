namespace Coffee_ManageMent
{
    partial class frmTransfer_Order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransfer_Order));
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grp2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvStore = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTour = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.grp3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtDate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbW_Destination = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbW_Origin = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTransferee = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.grp3.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.grp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(799, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "تحویل گیرنده:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStore.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.P_Name,
            this.Entity,
            this.Buy_Price,
            this.Cost});
            this.dgvStore.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStore.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStore.Location = new System.Drawing.Point(3, 3);
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStore.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvStore.RowsDefaultCellStyle = dataGridViewCellStyle7;
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
            // Buy_Price
            // 
            this.Buy_Price.DataPropertyName = "P_Entity";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Buy_Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Buy_Price.FillWeight = 69.33315F;
            this.Buy_Price.HeaderText = "فی واحد";
            this.Buy_Price.Name = "Buy_Price";
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle4;
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
            // txtNotice
            // 
            this.txtNotice.HideSelection = false;
            this.txtNotice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNotice.Location = new System.Drawing.Point(442, 9);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(346, 79);
            this.txtNotice.TabIndex = 0;
            this.txtNotice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotice_KeyDown);
            // 
            // grp3
            // 
            this.grp3.CanvasColor = System.Drawing.SystemColors.Control;
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
            // txtSum
            // 
            this.txtSum.Enabled = false;
            this.txtSum.HideSelection = false;
            this.txtSum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSum.Location = new System.Drawing.Point(34, 61);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(306, 27);
            this.txtSum.TabIndex = 2;
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.panelEx1.TabIndex = 55678;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F);
            this.label4.Location = new System.Drawing.Point(320, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(546, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "مدیریت حواله های انتقالی";
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
            this.panelEx2.TabIndex = 55679;
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
            // txtDate
            // 
            // 
            // 
            // 
            this.txtDate.BackgroundStyle.Class = "TextBoxBorder";
            this.txtDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.ButtonClear.Visible = true;
            this.txtDate.Location = new System.Drawing.Point(35, 61);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(221, 26);
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
            this.label10.Location = new System.Drawing.Point(308, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "تاریخ:";
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
            this.label1.Location = new System.Drawing.Point(604, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "انبار مبدا:";
            // 
            // grp1
            // 
            this.grp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp1.Controls.Add(this.cmbW_Destination);
            this.grp1.Controls.Add(this.cmbW_Origin);
            this.grp1.Controls.Add(this.txtDate);
            this.grp1.Controls.Add(this.txtID);
            this.grp1.Controls.Add(this.label10);
            this.grp1.Controls.Add(this.label12);
            this.grp1.Controls.Add(this.label3);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Controls.Add(this.txtTransferee);
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
            // cmbW_Destination
            // 
            this.cmbW_Destination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbW_Destination.DisplayMember = "Text";
            this.cmbW_Destination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbW_Destination.ForeColor = System.Drawing.Color.Black;
            this.cmbW_Destination.ItemHeight = 20;
            this.cmbW_Destination.Location = new System.Drawing.Point(35, 11);
            this.cmbW_Destination.Name = "cmbW_Destination";
            this.cmbW_Destination.Size = new System.Drawing.Size(221, 28);
            this.cmbW_Destination.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbW_Destination.TabIndex = 2;
            this.cmbW_Destination.SelectedIndexChanged += new System.EventHandler(this.cmbW_Destination_SelectedIndexChanged);
            this.cmbW_Destination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbW_Destination_KeyDown);
            // 
            // cmbW_Origin
            // 
            this.cmbW_Origin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbW_Origin.DisplayMember = "Text";
            this.cmbW_Origin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbW_Origin.ForeColor = System.Drawing.Color.Black;
            this.cmbW_Origin.ItemHeight = 20;
            this.cmbW_Origin.Location = new System.Drawing.Point(352, 12);
            this.cmbW_Origin.Name = "cmbW_Origin";
            this.cmbW_Origin.Size = new System.Drawing.Size(221, 28);
            this.cmbW_Origin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbW_Origin.TabIndex = 1;
            this.cmbW_Origin.SelectedIndexChanged += new System.EventHandler(this.cmbW_Origin_SelectedIndexChanged);
            this.cmbW_Origin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbW_Origin_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(281, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "انبار مقصد:";
            // 
            // txtTransferee
            // 
            this.txtTransferee.HideSelection = false;
            this.txtTransferee.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTransferee.Location = new System.Drawing.Point(352, 61);
            this.txtTransferee.Name = "txtTransferee";
            this.txtTransferee.Size = new System.Drawing.Size(437, 27);
            this.txtTransferee.TabIndex = 3;
            this.txtTransferee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTransferee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransferee_KeyDown);
            // 
            // frmTransfer_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(915, 663);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.grp3);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.grp1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransfer_Order";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTransfer_Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grp2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grp3.ResumeLayout(false);
            this.grp3.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public DevComponents.DotNetBar.Controls.GroupPanel grp2;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgvStore;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteAll;
        private System.Windows.Forms.ToolStripMenuItem mnuTour;
        public DevComponents.DotNetBar.Controls.GroupPanel grp3;
        public System.Windows.Forms.TextBox txtNotice;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSum;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtEntity;
        public System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnClose;
        public DevComponents.DotNetBar.ButtonX btnFinish;
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
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtTransferee;
        private System.Windows.Forms.Timer timer1;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbW_Destination;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbW_Origin;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buy_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
    }
}