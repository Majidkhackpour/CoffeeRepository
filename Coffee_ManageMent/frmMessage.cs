using System;
using System.Drawing;
using System.Windows.Forms;
using DataLayer.Enums;

namespace Coffee_ManageMent.Utility
{
    public partial class frmMessage : Form
    {
        public EnumMessageFlag flag;
        public EnumMessageResualt Resault;

        public frmMessage(EnumMessageFlag ff, Color bColor, string message)
        {
            InitializeComponent();
            this.BackColor = bColor;
            pictureBox1.BackColor = bColor;
            lblCancel.BackColor = bColor;
            lblClose.BackColor = bColor;
            lblMessage.BackColor = bColor;
            lblOK.BackColor = bColor;
            lblMessage.Text = message;
            flag = ff;
            if (flag == EnumMessageFlag.ShowFlag)
            {
                lblClose.Visible = true;
                lblCancel.Visible = false;
                lblOK.Visible = false;
            }
            else if (flag == EnumMessageFlag.DeleteFlag)
            {
                lblClose.Visible = false;
                lblCancel.Visible = true;
                lblOK.Visible = true;
            }
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {
        }
        private void lblOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblOK_MouseEnter(object sender, EventArgs e)
        {
           // clsFunction.Red(lblOK);
        }

        private void lblOK_MouseLeave(object sender, EventArgs e)
        {
           // clsFunction.Black(lblOK);
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
           // clsFunction.Red(lblClose);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            //clsFunction.Black(lblClose);
        }

        private void lblCancel_MouseEnter(object sender, EventArgs e)
        {
            //clsFunction.Red(lblCancel);
        }

        private void lblCancel_MouseLeave(object sender, EventArgs e)
        {
          //  clsFunction.Black(lblCancel);
        }

        private void FrmMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (flag==EnumMessageFlag.ShowFlag)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        lblClose_Click(sender, e);
                        break;
                }
            }
            else if (flag==EnumMessageFlag.DeleteFlag)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        lblOK_Click(sender, e);
                        break;
                }
            }
        }
    }
}
