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
    public partial class frmShow_Back_Buy_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Back_Buy_Factor()
        {
            InitializeComponent();
        }

        private void frmShow_Back_Buy_Factor_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Back_Buy_Factor.ID, tbl_Header_Back_Buy_Factor.Date, tbl_Header_Back_Buy_Factor.Price, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Back_Buy_Factor.UserName, tbl_Header_Back_Buy_Factor.Notice FROM tbl_Header_Back_Buy_Factor INNER JOIN tbl_Account ON tbl_Header_Back_Buy_Factor.Seller_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Back_Buy_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Back_Buy_Factor.ID DESC";
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
                frmBack_Buy_Factor f = new frmBack_Buy_Factor();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Back_Buy_Factor_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Back_Buy_Factor.ID, tbl_Header_Back_Buy_Factor.Date, tbl_Header_Back_Buy_Factor.Price, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Back_Buy_Factor.UserName, tbl_Header_Back_Buy_Factor.Notice FROM tbl_Header_Back_Buy_Factor INNER JOIN tbl_Account ON tbl_Header_Back_Buy_Factor.Seller_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Back_Buy_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Back_Buy_Factor.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Code FROM tbl_Header_Back_Buy_Factor WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Validation FROM tbl_Header_TurnTransfer WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows[0].ItemArray[0].ToString() == "بله")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این سند تایید شده و شما مجاز به ویرایش اسناد تایید شده نمی باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmBack_Buy_Factor f = new frmBack_Buy_Factor();
                    f.op = "Edit";
                    f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور برگشت از خرید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Code FROM tbl_Header_Back_Buy_Factor WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Validation, ID FROM tbl_Header_TurnTransfer WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows[0].ItemArray[0].ToString() == "بله")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این سند تایید شده و شما مجاز به حذف اسناد تایید شده نمی باشید";
                    f.ShowDialog();
                }
                else
                {
                    string query1 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=4 AND Parent_Code = '" + Convert.ToInt32(dt2.Rows[0].ItemArray[1]) + "'";
                    string query2 = "DELETE FROM tbl_Body_TurnTransfer WHERE ID = '" + Convert.ToInt32(dt.Rows[0].ItemArray[0]) + "'";
                    string query3 = "DELETE FROM tbl_Header_TurnTransfer WHERE ID='" + Convert.ToInt32(dt.Rows[0].ItemArray[0]) + "'";
                    string query4 = "DELETE FROM tbl_Header_Back_Buy_Factor WHERE ID = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    string query5 = "DELETE FROM tbl_Body_Back_Buy_Factor WHERE ID = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    string query6 = "DELETE FROM tbl_Transaction WHERE Parent=4 AND Parent_Code = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف حواله برگشت به شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query6) == true)
                        {
                        }
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query5) == true && clsFunction.Execute(dataconnection, query4) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                        {
                            frmShow_Back_Buy_Factor_Activated(null, null);
                        }
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور برگشت از خرید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmBack_Buy_Factor f = new frmBack_Buy_Factor();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grp1.Enabled = false;
                f.grp2.Enabled = false;
                f.grp3.Enabled = false;
                f.grp4.Enabled = false;
                f.grp5.Enabled = false;
                f.txtNotice.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور برگشت خرید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Back_Buy_Factor.ID, tbl_Header_Back_Buy_Factor.Date, tbl_Header_Back_Buy_Factor.Price, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Back_Buy_Factor.UserName, tbl_Header_Back_Buy_Factor.Notice FROM tbl_Header_Back_Buy_Factor INNER JOIN tbl_Account ON tbl_Header_Back_Buy_Factor.Seller_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Back_Buy_Factor.Store = tbl_Store.Code WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Store.Shown_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Back_Buy_Factor.UserName LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Back_Buy_Factor.Notice LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Back_Buy_Factor.ID DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
