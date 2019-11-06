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
    public partial class frmShow_Warehouse_Receipt : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Warehouse_Receipt()
        {
            InitializeComponent();
        }

        private void frmShow_Warehouse_Receipt_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_WareReceipt.Date, tbl_Account.Description, tbl_Header_WareReceipt.Bill, tbl_Header_WareReceipt.Notice, tbl_Header_WareReceipt.ID FROM tbl_Header_WareReceipt INNER JOIN tbl_Account ON tbl_Header_WareReceipt.Code = tbl_Account.Code ORDER BY tbl_Header_WareReceipt.Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
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
                frmWarehouse_Receipt f = new frmWarehouse_Receipt();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Type, Validation FROM tbl_Header_WareReceipt WHERE ID= '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() == "2")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "بر روی این رسید انبار، فاکتور خرید و سند حسابداری تنظیم شده و از طریق فاکتورهای خرید قابل ویرایش است";
                    f.ShowDialog();
                }
                else if (dt.Rows[0].ItemArray[1].ToString() == "بله")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این سند تایید شده و شما مجاز به ویرایش اسناد تایید شده نمی باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmWarehouse_Receipt f = new frmWarehouse_Receipt();
                    f.op = "Edit";
                    f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "رسید انبار انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Type, Validation FROM tbl_Header_WareReceipt WHERE ID= '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() == "2")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "بر روی این رسید انبار، فاکتور خرید و سند حسابداری تنظیم شده و از طریق فاکتورهای خرید قابل ویرایش است";
                    f.ShowDialog();
                }
                else if (dt.Rows[0].ItemArray[1].ToString() == "بله")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این سند تایید شده و شما مجاز به حذف اسناد تایید شده نمی باشید";
                    f.ShowDialog();
                }
                else
                {
                    string query1 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=11 AND Parent_Code = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    string query2 = "DELETE FROM tbl_Body_WareReceipt WHERE ID = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    string query3 = "DELETE FROM tbl_Header_WareReceipt WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف رسید انبار به شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                        {
                            frmShow_Warehouse_Receipt_Activated(null, null);
                        }
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "رسید انبار انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void frmShow_Warehouse_Receipt_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_WareReceipt.Date, tbl_Account.Description, tbl_Header_WareReceipt.Bill, tbl_Header_WareReceipt.Notice, tbl_Header_WareReceipt.ID FROM tbl_Header_WareReceipt INNER JOIN tbl_Account ON tbl_Header_WareReceipt.Code = tbl_Account.Code ORDER BY tbl_Header_WareReceipt.Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmWarehouse_Receipt f = new frmWarehouse_Receipt();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grp1.Enabled = false;
                f.grp2.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "رسید انبار انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_WareReceipt.Date, tbl_Account.Description, tbl_Header_WareReceipt.Bill, tbl_Header_WareReceipt.Notice, tbl_Header_WareReceipt.ID FROM tbl_Header_WareReceipt INNER JOIN tbl_Account ON tbl_Header_WareReceipt.Code = tbl_Account.Code WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_WareReceipt.Bill LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_WareReceipt.Date DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
