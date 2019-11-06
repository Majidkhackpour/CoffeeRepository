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
    public partial class frmShow_Return_Of_Sales_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Return_Of_Sales_Factor()
        {
            InitializeComponent();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShow_Return_Of_Sales_Factor_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Return_Of_Sales_Factor.ID, tbl_Header_Return_Of_Sales_Factor.Date, tbl_Header_Return_Of_Sales_Factor.Total, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Return_Of_Sales_Factor.UserName, tbl_Header_Return_Of_Sales_Factor.Notice FROM tbl_Header_Return_Of_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Return_Of_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Return_Of_Sales_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Return_Of_Sales_Factor.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmReturn_Of_Sales_Factor f = new frmReturn_Of_Sales_Factor();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Return_Of_Sales_Factor_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Return_Of_Sales_Factor.ID, tbl_Header_Return_Of_Sales_Factor.Date, tbl_Header_Return_Of_Sales_Factor.Total, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Return_Of_Sales_Factor.UserName, tbl_Header_Return_Of_Sales_Factor.Notice FROM tbl_Header_Return_Of_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Return_Of_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Return_Of_Sales_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Return_Of_Sales_Factor.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Code FROM tbl_Header_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Validation FROM tbl_Header_TurnReceipt WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'", dataconnection);
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
                    frmReturn_Of_Sales_Factor f = new frmReturn_Of_Sales_Factor();
                    f.op = "Edit";
                    f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور برگشت از فروش انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Code FROM tbl_Header_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Validation FROM tbl_Header_TurnReceipt WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'", dataconnection);
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
                    int Factor_ID = Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value);
                    string query1 = "DELETE FROM tbl_Body_Return_Of_Sales_Factor WHERE ID='" + Factor_ID + "'";
                    string query2 = "DELETE FROM tbl_Body_TurnReceipt WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'";
                    string query3 = "DELETE FROM tbl_Header_Return_Of_Sales_Factor WHERE ID='" + Factor_ID + "'";
                    string query4 = "DELETE FROM tbl_Header_TurnReceipt WHERE ID='" + Factor_ID + "'";
                    string query6 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=3 AND Parent_Code='" + Factor_ID + "'";
                    string query7 = "DELETE FROM tbl_Transaction WHERE Parent=3 AND Parent_Code='" + Factor_ID + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف فاکتور برگشت از فروش به شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query6) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query7) == true)
                            {
                            }
                        }
                        frmShow_Return_Of_Sales_Factor_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور برگشت از فروش انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Return_Of_Sales_Factor.ID, tbl_Header_Return_Of_Sales_Factor.Date, tbl_Header_Return_Of_Sales_Factor.Total, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Return_Of_Sales_Factor.UserName, tbl_Header_Return_Of_Sales_Factor.Notice FROM tbl_Header_Return_Of_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Return_Of_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Return_Of_Sales_Factor.Store = tbl_Store.Code WHERE tbl_Header_Return_Of_Sales_Factor.ID='" + txtSearch.Text + "' OR tbl_Header_Return_Of_Sales_Factor.Total='" + txtSearch.Text + "' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Store.Shown_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Return_Of_Sales_Factor.UserName LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Return_Of_Sales_Factor.Notice LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Return_Of_Sales_Factor.ID DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
