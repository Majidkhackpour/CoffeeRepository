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
    public partial class frmShow_Sales_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Sales_Factor()
        {
            InitializeComponent();
        }

        private void frmShow_Sales_Factor_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Sales_Factor.ID, tbl_Header_Sales_Factor.C_Code, tbl_Header_Sales_Factor.Date, tbl_Header_Sales_Factor.Time, tbl_Header_Sales_Factor.Sum_Factor, tbl_Account.Description, tbl_Header_Sales_Factor.UserName, tbl_Store.Shown_Name FROM tbl_Header_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Sales_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Sales_Factor.ID DESC";
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
                frmSales_Factor f = new frmSales_Factor();
                f.op = "Add";
                f.Form_Load();
                f.Edit_Or_View_Temp = 0;
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Sales_Factor_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Sales_Factor.ID, tbl_Header_Sales_Factor.C_Code, tbl_Header_Sales_Factor.Date, tbl_Header_Sales_Factor.Time, tbl_Header_Sales_Factor.Sum_Factor, tbl_Account.Description, tbl_Header_Sales_Factor.UserName, tbl_Store.Shown_Name FROM tbl_Header_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Sales_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Sales_Factor.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Code FROM tbl_Header_Sales_Factor WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Validation FROM tbl_Header_WareTransfer WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'", dataconnection);
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
                    frmSales_Factor f = new frmSales_Factor();
                    f.op = "Edit";
                    f.Edit_Or_View_Temp = 0;
                    f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور فروش انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Code, C_Code, Point FROM tbl_Header_Sales_Factor WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Validation FROM tbl_Header_WareTransfer WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'", dataconnection);
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
                    string query1 = "DELETE FROM tbl_Body_Sales_Factor WHERE ID='" + Factor_ID + "'";
                    string query2 = "DELETE FROM tbl_Body_WareTransfer WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'";
                    string query3 = "DELETE FROM tbl_Header_Sales_Factor WHERE ID='" + Convert.ToInt64(Factor_ID) + "'";
                    string query4 = "DELETE FROM tbl_Header_WareTransfer WHERE ID='" + Convert.ToInt64(dt.Rows[0].ItemArray[0]) + "'";
                    string query5 = "DELETE FROM tbl_Serve_Info WHERE ID_Factor='" + Factor_ID + "'";
                    string query6 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=1 AND Parent_Code='" + Factor_ID + "'";
                    string query7 = "DELETE FROM tbl_Transaction WHERE Parent=1 AND Parent_Code='" + Factor_ID + "'";
                    string query8 = "DELETE FROM tbl_Tour_Of_Income WHERE ID_Factor='" + Factor_ID + "'";
                    string query9 = "DELETE FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Factor_ID + "'";
                    string query10 = "UPDATE tbl_Customer_Club SET Point=Point-'" + Convert.ToInt32(dt.Rows[0].ItemArray[2]) + "' WHERE Code='" + dt.Rows[0].ItemArray[1].ToString() + "'";
                    string query11 = "DELETE FROM tbl_Tour_Cus_Club_Point WHERE Code='" + dt.Rows[0].ItemArray[1].ToString() + "' AND P_Code='" + Convert.ToInt64(Factor_ID) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف فاکتور فروش به شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query9) == true)
                        {
                        }
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            if (clsFunction.Execute(dataconnection, query5) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query6) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query7) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query8) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query10) == true && clsFunction.Execute(dataconnection, query11) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query3) == true)
                            {
                            }
                            if (clsFunction.Execute(dataconnection, query4) == true)
                            {
                            }
                        }
                        frmShow_Sales_Factor_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور فروش انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmSales_Factor f = new frmSales_Factor();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.Edit_Or_View_Temp = 1;
                f.False_Enabling(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور فروش انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Sales_Factor.ID, tbl_Header_Sales_Factor.C_Code, tbl_Header_Sales_Factor.Date, tbl_Header_Sales_Factor.Time, tbl_Header_Sales_Factor.Sum_Factor, tbl_Account.Description, tbl_Header_Sales_Factor.UserName, tbl_Store.Shown_Name FROM tbl_Header_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Sales_Factor.Store = tbl_Store.Code WHERE tbl_Header_Sales_Factor.ID='" + txtSearch.Text + "' OR tbl_Header_Sales_Factor.Sum_Factor='" + txtSearch.Text + "' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Sales_Factor.UserName LIKE N'%" + txtSearch.Text + "%' OR tbl_Store.Shown_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Sales_Factor.ID DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuProfit_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Profit_In_Factor f = new frmShow_Profit_In_Factor();
                f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grp3.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuTour_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer_Little_Tour f = new frmCustomer_Little_Tour();
                f.Fill_Data(dgvStore.CurrentRow.Cells["c_Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
