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
    public partial class frmShow_Bank : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Bank()
        {
            InitializeComponent();
        }

        private void frmShow_Bank_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Bank.ID, tbl_Bank.Code, tbl_Account.Description, tbl_Bank.Bank_Branch, tbl_Bank_Acc_Type.Type_Name, tbl_Bank.Branch_Code, tbl_Poss.Poss_Name FROM tbl_Bank INNER JOIN tbl_Account ON tbl_Bank.Code = tbl_Account.Code INNER JOIN tbl_Bank_Acc_Type ON tbl_Bank.Account_Type = tbl_Bank_Acc_Type.Account_Type INNER JOIN tbl_Poss ON tbl_Bank.Poss = tbl_Poss.Poss ORDER BY tbl_Bank.Code ASC";
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

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmBank f = new frmBank();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Bank_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Bank.ID, tbl_Bank.Code, tbl_Account.Description, tbl_Bank.Bank_Branch, tbl_Bank_Acc_Type.Type_Name, tbl_Bank.Branch_Code, tbl_Poss.Poss_Name FROM tbl_Bank INNER JOIN tbl_Account ON tbl_Bank.Code = tbl_Account.Code INNER JOIN tbl_Bank_Acc_Type ON tbl_Bank.Account_Type = tbl_Bank_Acc_Type.Account_Type INNER JOIN tbl_Poss ON tbl_Bank.Poss = tbl_Poss.Poss ORDER BY tbl_Bank.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmBank f = new frmBank();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "بانک انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Bank WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Bank_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این حساب بانکی نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmBank f = new frmBank();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.groupPanel1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "بانک انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuCurrent_Bank_Click(object sender, EventArgs e)
        {
            try
            {
                new frmCurrent_Bank().ShowDialog();
            }
            catch
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Bank.ID, tbl_Bank.Code, tbl_Account.Description, tbl_Bank.Bank_Branch, tbl_Bank_Acc_Type.Type_Name, tbl_Bank.Branch_Code, tbl_Poss.Poss_Name FROM tbl_Bank INNER JOIN tbl_Account ON tbl_Bank.Code = tbl_Account.Code INNER JOIN tbl_Bank_Acc_Type ON tbl_Bank.Account_Type = tbl_Bank_Acc_Type.Account_Type INNER JOIN tbl_Poss ON tbl_Bank.Poss = tbl_Poss.Poss WHERE tbl_Bank.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Bank_Acc_Type.Type_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Bank.Code ASC";
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
    }
}
