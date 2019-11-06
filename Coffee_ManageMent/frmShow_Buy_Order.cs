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
    public partial class frmShow_Buy_Order : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Buy_Order()
        {
            InitializeComponent();
        }

        private void frmShow_Buy_Order_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Buy_Order.ID, tbl_Header_Buy_Order.Date, tbl_Account.Description, tbl_Header_Buy_Order.PrePayement, tbl_Header_Buy_Order.Notice FROM tbl_Header_Buy_Order INNER JOIN tbl_Account ON tbl_Header_Buy_Order.Seller_Code = tbl_Account.Code ORDER BY tbl_Header_Buy_Order.Date DESC";
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
                frmBuy_Order f = new frmBuy_Order();
                f.Form_Load();
                f.op = "Add";
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
                frmBuy_Order f = new frmBuy_Order();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "سفارش خرید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Buy_Order WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                string query = "DELETE FROM tbl_Header_Buy_Order WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف سفارش خرید به شماره  " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query) == true)
                        frmShow_Buy_Order_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما مجاز به حذف این سفارش خرید نمی باشید";
                f.ShowDialog();
            }
        }

        private void frmShow_Buy_Order_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Buy_Order.ID, tbl_Header_Buy_Order.Date, tbl_Account.Description, tbl_Header_Buy_Order.PrePayement, tbl_Header_Buy_Order.Notice FROM tbl_Header_Buy_Order INNER JOIN tbl_Account ON tbl_Header_Buy_Order.Seller_Code = tbl_Account.Code ORDER BY tbl_Header_Buy_Order.Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuy_Order f = new frmBuy_Order();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grp1.Enabled = false;
                f.grp2.Enabled = false;
                f.grp3.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "سفارش خرید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Buy_Order.ID, tbl_Header_Buy_Order.Date, tbl_Account.Description, tbl_Header_Buy_Order.PrePayement, tbl_Header_Buy_Order.Notice FROM tbl_Header_Buy_Order INNER JOIN tbl_Account ON tbl_Header_Buy_Order.Seller_Code = tbl_Account.Code WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Buy_Order.Notice LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Buy_Order.Date DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuTurn_To_Factor_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    frmBuy_Factor f = new frmBuy_Factor();
                    f.op = "Add";
                    f.FillData_Order(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "سفارش خرید انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }
    }
}
