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
    public partial class frmShow_Per_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Per_Factor()
        {
            InitializeComponent();
        }

        private void frmShow_Per_Factor_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Per_Factor.ID, tbl_Header_Per_Factor.Date, tbl_Header_Per_Factor.Total, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Per_Factor.UserName, tbl_Header_Per_Factor.Notice FROM tbl_Header_Per_Factor INNER JOIN tbl_Account ON tbl_Header_Per_Factor.Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Per_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Per_Factor.ID DESC";
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
                frmPer_Factor f = new frmPer_Factor();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Per_Factor_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Per_Factor.ID, tbl_Header_Per_Factor.Date, tbl_Header_Per_Factor.Total, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Per_Factor.UserName, tbl_Header_Per_Factor.Notice FROM tbl_Header_Per_Factor INNER JOIN tbl_Account ON tbl_Header_Per_Factor.Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Per_Factor.Store = tbl_Store.Code ORDER BY tbl_Header_Per_Factor.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmPer_Factor f = new frmPer_Factor();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پیش فاکتور انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                    string query4 = "DELETE FROM tbl_Header_Per_Factor WHERE ID = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    string query5 = "DELETE FROM tbl_Body_Per_Factor WHERE ID = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف پیش فاکتور به شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query5) == true && clsFunction.Execute(dataconnection, query4) == true)
                        {
                            frmShow_Per_Factor_Activated(null, null);
                        }
                    }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پیش فاکتور انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmPer_Factor f = new frmPer_Factor();
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
                f.lblMessage.Text = "پیش فاکتور انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Per_Factor.ID, tbl_Header_Per_Factor.Date, tbl_Header_Per_Factor.Total, tbl_Account.Description, tbl_Store.Shown_Name, tbl_Header_Per_Factor.UserName, tbl_Header_Per_Factor.Notice FROM tbl_Header_Per_Factor INNER JOIN tbl_Account ON tbl_Header_Per_Factor.Code = tbl_Account.Code INNER JOIN tbl_Store ON tbl_Header_Per_Factor.Store = tbl_Store.Code WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Store.Shown_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Per_Factor.UserName LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Per_Factor.Notice LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Per_Factor.ID DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuTurn_Factor_Click(object sender, EventArgs e)
        {
            try
            {
                frmSales_Factor f = new frmSales_Factor();
                f.op = "Add";
                f.Per_Factor = "Per";
                f.Per_Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.Edit_Or_View_Temp = 0;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پیش فاکتور انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }
    }
}
