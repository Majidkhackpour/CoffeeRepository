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
    public partial class frmShow_Contract : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Contract()
        {
            InitializeComponent();
        }

        private void frmShow_Contract_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Contract.Con_Code, tbl_Contract.Code, tbl_Contract.Expiration_Date, tbl_Account.Description, tbl_State.State_Name FROM tbl_Contract INNER JOIN tbl_Account ON tbl_Contract.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Contract.State = tbl_State.State ORDER BY tbl_Contract.Con_Code ASC";
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

        private void mnuEdit_Click(object sender, EventArgs e)
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

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmContract f = new frmContract();
                f.op = "View";
                f.Fill_Data(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuEnable_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "فعال")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وضعیت  قرارداد " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "فعال است";
                f.ShowDialog();
            }
            else
            {
                string query = "UPDATE tbl_Contract SET State = 0 WHERE Con_Code='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Con_Code"].Value) + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Contract_Activated(null, null);
                }
            }
        }

        private void frmShow_Contract_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Contract.Con_Code, tbl_Contract.Code, tbl_Contract.Expiration_Date, tbl_Account.Description, tbl_State.State_Name FROM tbl_Contract INNER JOIN tbl_Account ON tbl_Contract.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Contract.State = tbl_State.State ORDER BY tbl_Contract.Con_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuDisable_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "غیرفعال")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وضعیت قرارداد " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "غیرفعال است";
                f.ShowDialog();
            }
            else
            {
                string query = "UPDATE tbl_Contract SET State = 1 WHERE Con_Code='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Con_Code"].Value) + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Contract_Activated(null, null);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Contract.Con_Code, tbl_Contract.Code, tbl_Contract.Expiration_Date, tbl_Account.Description, tbl_State.State_Name FROM tbl_Contract INNER JOIN tbl_Account ON tbl_Contract.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Contract.State = tbl_State.State WHERE tbl_Contract.Con_Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_State.State_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Contract.Con_Code ASC";
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
