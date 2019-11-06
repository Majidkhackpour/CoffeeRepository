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
    public partial class frmShow_Loan : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Loan()
        {
            InitializeComponent();
        }

        private void frmShow_Loan_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Loan.Code, tbl_Account.Description, tbl_Header_Loan.Number, tbl_Header_Loan.Type, tbl_Header_Loan.Expiration_Date FROM tbl_Header_Loan INNER JOIN tbl_Account ON tbl_Header_Loan.Code = tbl_Account.Code ORDER BY tbl_Header_Loan.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoan f = new frmLoan();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Loan_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Loan.Code, tbl_Account.Description, tbl_Header_Loan.Number, tbl_Header_Loan.Type, tbl_Header_Loan.Expiration_Date FROM tbl_Header_Loan INNER JOIN tbl_Account ON tbl_Header_Loan.Code = tbl_Account.Code ORDER BY tbl_Header_Loan.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoan f = new frmLoan();
                f.op = "Edit";
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وام پرداختنی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Loan WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                string query2 = "DELETE FROM tbl_Header_Loan WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        frmShow_Loan_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این وام پرداختنی نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoan f = new frmLoan();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.grp2.Enabled = false;
                f.grp3.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وام پرداختنی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Loan.Code, tbl_Account.Description, tbl_Header_Loan.Number, tbl_Header_Loan.Type, tbl_Header_Loan.Expiration_Date FROM tbl_Header_Loan INNER JOIN tbl_Account ON tbl_Header_Loan.Code = tbl_Account.Code WHERE tbl_Header_Loan.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Loan.Number LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Loan.Type LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Loan.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuShow_Install_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Installment f = new frmShow_Installment();
                f.lblName.Text = dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString();
                f.Code = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
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
    }
}
