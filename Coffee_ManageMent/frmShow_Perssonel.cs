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
    public partial class frmShow_Perssonel : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Per_Code;
        public frmShow_Perssonel()
        {
            InitializeComponent();
        }

        private void frmShow_Perssonel_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel_Group.Group_Name, tbl_State.State_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_State ON tbl_Perssonel.State = tbl_State.State ORDER BY tbl_Perssonel.Code ASC";
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
                frmPerssonel f = new frmPerssonel();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Perssonel_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel_Group.Group_Name, tbl_State.State_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_State ON tbl_Perssonel.State = tbl_State.State ORDER BY tbl_Perssonel.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmPerssonel f = new frmPerssonel();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پرسنل انتخابی معتبر نمی باشد";
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
                string query = "UPDATE tbl_Perssonel SET State = 0 WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value) + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Perssonel_Activated(null, null);
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
                string query = "UPDATE tbl_Perssonel SET State = 1 WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value) + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Perssonel_Activated(null, null);
                }
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmPerssonel f = new frmPerssonel();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                f.grpPerssonel.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پرسنل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuContract_Click(object sender, EventArgs e)
        {
            try
            {
                frmContract f = new frmContract();
                f.Fill_Data(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.op = "Edit";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel_Group.Group_Name, tbl_State.State_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_State ON tbl_Perssonel.State = tbl_State.State WHERE tbl_Perssonel.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Perssonel_Group.Group_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Perssonel.Code ASC";
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

        private void mnuPic_Click(object sender, EventArgs e)
        {
            try
            {
                frmPerssonel_Pic f = new frmPerssonel_Pic();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پرسنل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void dgvStore_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStore_Click(object sender, EventArgs e)
        {
            try
            {
                Per_Code = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
            }
            catch
            {
                Per_Code = null;
            }
        }

        private void dgvStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    Per_Code = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                }
                catch
                {
                    Per_Code = null;
                }
                finally
                {
                    this.Close();
                }
            }
        }
    }
}
