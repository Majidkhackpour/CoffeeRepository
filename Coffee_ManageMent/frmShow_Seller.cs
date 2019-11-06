using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent
{
    public partial class frmShow_Seller : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Seller()
        {
            InitializeComponent();
        }

        private void frmShow_Seller_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Seller.Code, tbl_Account.Description, tbl_State.State_Name FROM tbl_Seller INNER JOIN tbl_Account ON tbl_Seller.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Seller.State = tbl_State.State ORDER BY tbl_Seller.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeller f = new frmSeller();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Seller_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Seller.Code, tbl_Account.Description, tbl_State.State_Name FROM tbl_Seller INNER JOIN tbl_Account ON tbl_Seller.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Seller.State = tbl_State.State ORDER BY tbl_Seller.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeller f = new frmSeller();
                f.op = "Edit";
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فروشنده انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Seller WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Seller_Activated(null, null); 
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این فروشنده نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuEnable_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "فعال")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وضعیت همکاری با " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "فعال است";
                f.ShowDialog();
            }
            else
            {
                string query = "UPDATE tbl_Seller SET State = 0 WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Seller_Activated(null, null);
                }
            }
        }

        private void mnuDisable_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "غیرفعال")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وضعیت همکاری با " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "غیرفعال است";
                f.ShowDialog();
            }
            else
            {
                string query = "UPDATE tbl_Seller SET State = 1 WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Seller_Activated(null, null);
                }
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeller f = new frmSeller();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.groupPanel1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فروشنده انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Seller.Code, tbl_Account.Description, tbl_State.State_Name FROM tbl_Seller INNER JOIN tbl_Account ON tbl_Seller.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Seller.State = tbl_State.State WHERE tbl_Seller.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_State.State_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Seller.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuExport_To_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Export_Data_To_Excel(dgvStore);
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "سیستم شما قادر به ایجاد فایل اکسل نمی باشد. لطفا تنظیمات ویندوز را بررسی و مجددا تلاش نمایید";
                f.ShowDialog();
            }
        }
    }
}
