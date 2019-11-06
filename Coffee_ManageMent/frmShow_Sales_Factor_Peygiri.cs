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
    public partial class frmShow_Sales_Factor_Peygiri : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Sales_Factor_Peygiri()
        {
            InitializeComponent();
        }

        private void frmShow_Sales_Factor_Peygiri_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Sales_Factor.ID, tbl_Header_Sales_Factor.Date, tbl_Header_Sales_Factor.Sum_Factor, tbl_Account.Description, tbl_Header_Sales_Factor.Pey_Date, tbl_Peygiri_State.Pey_Name FROM tbl_Header_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Peygiri_State ON tbl_Header_Sales_Factor.Fin_State = tbl_Peygiri_State.Pey_ID ORDER BY tbl_Header_Sales_Factor.ID DESC";
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
                if (dgvStore.CurrentRow.Cells["Pey_Name"].Value.ToString() == "تسویه شده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "وضعیت مالی این فاکتور تسویه شده است و قابل پیگیری نمی باشد";
                    f.ShowDialog();
                }
                else
                {
                    frmSales_Factor_Peygiri f = new frmSales_Factor_Peygiri();
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void frmShow_Sales_Factor_Peygiri_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Sales_Factor.ID, tbl_Header_Sales_Factor.Date, tbl_Header_Sales_Factor.Sum_Factor, tbl_Account.Description, tbl_Header_Sales_Factor.Pey_Date, tbl_Peygiri_State.Pey_Name FROM tbl_Header_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Peygiri_State ON tbl_Header_Sales_Factor.Fin_State = tbl_Peygiri_State.Pey_ID ORDER BY tbl_Header_Sales_Factor.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["Pey_Name"].Value.ToString() == "تسویه شده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "وضعیت مالی این فاکتور تسویه شده است و قابل پیگیری نمی باشد";
                    f.ShowDialog();
                }
                else
                {
                    frmSales_Factor_Peygiri f = new frmSales_Factor_Peygiri();
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                    f.groupPanel1.Enabled = false;
                    f.grp1.Enabled = false;
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void mnuRecive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["Pey_Name"].Value.ToString() == "تسویه شده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "وضعیت مالی این فاکتور تسویه شده است و قابل دریافت نمی باشد";
                    f.ShowDialog();
                }
                else
                {
                    frmSales_Factor_Peygiri_Daryaft f = new frmSales_Factor_Peygiri_Daryaft();
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Sales_Factor.ID, tbl_Header_Sales_Factor.Date, tbl_Header_Sales_Factor.Sum_Factor, tbl_Account.Description, tbl_Header_Sales_Factor.Pey_Date, tbl_Peygiri_State.Pey_Name FROM tbl_Header_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Sales_Factor.C_Code = tbl_Account.Code INNER JOIN tbl_Peygiri_State ON tbl_Header_Sales_Factor.Fin_State = tbl_Peygiri_State.Pey_ID WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Peygiri_State.Pey_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Sales_Factor.ID DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
