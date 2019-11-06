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
    public partial class frmShow_Check : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        int flag;
        string Query;
        public frmShow_Check()
        {
            InitializeComponent();
        }

        private void frmShow_Check_Load(object sender, EventArgs e)
        {
            flag = 1;
            string Query = "SELECT tbl_Check_Book.ID, tbl_Check_Book.Code, tbl_Account.Description, tbl_Check_Book.Page_Count, tbl_Check_Book.Empty, tbl_Check_Book.Series, tbl_Check_Book.State FROM tbl_Check_Book INNER JOIN tbl_Account ON tbl_Check_Book.Code = tbl_Account.Code ORDER BY tbl_Check_Book.ID ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            mnuAll_Check.Visible = true;
            mnuEnable_Check.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuAll_Check_Click(object sender, EventArgs e)
        {
            flag = 0;
            mnuAll_Check.Visible = false;
            mnuEnable_Check.Visible = true;
            frmShow_Check_Activated(null, null);
        }

        private void mnuEnable_Check_Click(object sender, EventArgs e)
        {
            flag = 1;
            mnuAll_Check.Visible = true;
            mnuEnable_Check.Visible = false;
            frmShow_Check_Activated(null, null);
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheck f = new frmCheck();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Check_Page WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                string query2 = "DELETE FROM tbl_Check_Book WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        frmShow_Check_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این دسته چک نمی باشید";
                f.ShowDialog();
            }
        }

        private void frmShow_Check_Activated(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                Query = "SELECT tbl_Check_Book.ID, tbl_Check_Book.Code, tbl_Account.Description, tbl_Check_Book.Page_Count, tbl_Check_Book.Empty, tbl_Check_Book.Series, tbl_Check_Book.State FROM tbl_Check_Book INNER JOIN tbl_Account ON tbl_Check_Book.Code = tbl_Account.Code WHERE tbl_Check_Book.State=0 ORDER BY tbl_Check_Book.ID ASC";
            }
            else if (flag == 0)
            {
                Query = "SELECT tbl_Check_Book.ID, tbl_Check_Book.Code, tbl_Account.Description, tbl_Check_Book.Page_Count, tbl_Check_Book.Empty, tbl_Check_Book.Series, tbl_Check_Book.State FROM tbl_Check_Book INNER JOIN tbl_Account ON tbl_Check_Book.Code = tbl_Account.Code ORDER BY tbl_Check_Book.ID ASC";
            }
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheck f = new frmCheck();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "دسته چک انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                Query = "SELECT tbl_Check_Book.ID, tbl_Check_Book.Code, tbl_Account.Description, tbl_Check_Book.Page_Count, tbl_Check_Book.Empty, tbl_Check_Book.Series, tbl_Check_Book.State FROM tbl_Check_Book INNER JOIN tbl_Account ON tbl_Check_Book.Code = tbl_Account.Code WHERE tbl_Check_Book.State=0 AND (tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Book.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Book.ID LIKE N'%" + txtSearch.Text + "%') ORDER BY tbl_Check_Book.ID ASC";
            }
            else if (flag == 0)
            {
                Query = "SELECT tbl_Check_Book.ID, tbl_Check_Book.Code, tbl_Account.Description, tbl_Check_Book.Page_Count, tbl_Check_Book.Empty, tbl_Check_Book.Series, tbl_Check_Book.State FROM tbl_Check_Book INNER JOIN tbl_Account ON tbl_Check_Book.Code = tbl_Account.Code WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Book.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Book.ID LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Check_Book.ID ASC";
            }
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuCheck_Page_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheck_Page f = new frmCheck_Page();
                f.Check_ID = Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "دسته چک انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }
    }
}
