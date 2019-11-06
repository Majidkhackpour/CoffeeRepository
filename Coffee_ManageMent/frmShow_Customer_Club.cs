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
    public partial class frmShow_Customer_Club : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Customer_Club()
        {
            InitializeComponent();
        }

        private void frmShow_Customer_Club_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Customer_Club.Code, tbl_Account.Description, tbl_Customer_Club.Point FROM tbl_Customer_Club INNER JOIN tbl_Account ON tbl_Customer_Club.Code = tbl_Account.Code ORDER BY tbl_Customer_Club.Code ASC";
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

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer_Club f = new frmCustomer_Club();
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Customer_Club_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Customer_Club.Code, tbl_Account.Description, tbl_Customer_Club.Point FROM tbl_Customer_Club INNER JOIN tbl_Account ON tbl_Customer_Club.Code = tbl_Account.Code ORDER BY tbl_Customer_Club.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Customer_Club WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Customer_Club_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مشتری انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer_Club f = new frmCustomer_Club();
                f.txtCode.Enabled = false;
                f.btnFinish.Enabled = false;
                f.btnSearchAcc.Enabled = false;
                f.txtCode.Text = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مشتری انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Customer_Club.Code, tbl_Account.Description, tbl_Customer_Club.Point FROM tbl_Customer_Club INNER JOIN tbl_Account ON tbl_Customer_Club.Code = tbl_Account.Code WHERE tbl_Customer_Club.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Customer_Club.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuShow_Tour_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Cus_Club_Tour f = new frmShow_Cus_Club_Tour();
                f.Fill_Data(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.lblName.Text = dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString();
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مشتری انتخابی فاقد گردش امتیاز می باشد";
                f.ShowDialog();
            }
        }
    }
}
