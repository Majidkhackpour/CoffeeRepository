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
    public partial class frmShow_Cus_Installment : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Cus_Installment()
        {
            InitializeComponent();
        }

        private void frmShow_Cus_Installment_Load(object sender, EventArgs e)
        {
            string Query =
                "SELECT tbl_Customer_Installment.Guid, tbl_Customer_Installment.Code, tbl_Customer_Installment.Sett_Date, tbl_Customer_Installment.Price, tbl_Account.Description, tbl_Customer_Installment.Notice, tbl_State.State_Name FROM tbl_Customer_Installment INNER JOIN tbl_Account ON tbl_Customer_Installment.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Customer_Installment.State = tbl_State.State ORDER BY tbl_Customer_Installment.Sett_Date DESC";
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
                frmCus_Installment f = new frmCus_Installment();
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

        private void frmShow_Cus_Installment_Activated(object sender, EventArgs e)
        {
            string Query =
                "SELECT tbl_Customer_Installment.Guid, tbl_Customer_Installment.Code, tbl_Customer_Installment.Sett_Date, tbl_Customer_Installment.Price, tbl_Account.Description, tbl_Customer_Installment.Notice, tbl_State.State_Name FROM tbl_Customer_Installment INNER JOIN tbl_Account ON tbl_Customer_Installment.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Customer_Installment.State = tbl_State.State ORDER BY tbl_Customer_Installment.Sett_Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پرداخت نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "فقط اقساط پرداخت نشده قابل ویرایش می باشند";
                    f.ShowDialog();
                }
                else
                {
                    frmCus_Installment f = new frmCus_Installment();
                    f.op = "Edit";
                    f.Fill_Data(System.Guid.Parse(dgvStore.CurrentRow.Cells["GuidCell"].Value.ToString()));
                    f.ShowDialog();
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "قسط انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پرداخت نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "فقط اقساط پرداخت نشده قابل حذف می باشند";
                    f.ShowDialog();
                }
                else
                {
                    string query = "DELETE FROM tbl_Customer_Installment WHERE Guid='" +
                                   System.Guid.Parse(dgvStore.CurrentRow.Cells["GuidCell"].Value.ToString()) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = " آیا از حذف قسط " +
                                        dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " +
                                        "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + " " +
                                        "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query) == true)
                            frmShow_Cus_Installment_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "قسط انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmCus_Installment f = new frmCus_Installment();
                f.Fill_Data(System.Guid.Parse(dgvStore.CurrentRow.Cells["GuidCell"].Value.ToString()));
                f.grp1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "قسط انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuNaqd_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پرداخت نشده")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فقط اقساط پرداخت نشده قابل دریافت می باشند";
                f.ShowDialog();
            }
            else
            {
                Guid g_cell = System.Guid.Parse(dgvStore.CurrentRow.Cells["GuidCell"].Value.ToString());
                frmCash_Daryaft f = new frmCash_Daryaft();
                f.op = "Add";
                f.Form_Load();
                f.txtCode.Text = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                f.txtCash.Text = dgvStore.CurrentRow.Cells["Price"].Value.ToString();
                f.txtBabat_Code.Text = "019912";
                f.txtMoeen_Code.Text = "10301";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string query = "UPDATE tbl_Customer_Installment SET State=3 WHERE Guid='" + g_cell + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        frmShow_Cus_Installment_Activated(null, null);
                }
            }
        }

        private void mnuBank_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پرداخت نشده")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فقط اقساط پرداخت نشده قابل دریافت می باشند";
                f.ShowDialog();
            }
            else
            {
                Guid g_cell = System.Guid.Parse(dgvStore.CurrentRow.Cells["GuidCell"].Value.ToString());
                frmBank_Daryaft f = new frmBank_Daryaft();
                f.op = "Add";
                f.Form_Load();
                f.txtCode.Text = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                f.txtCash.Text = dgvStore.CurrentRow.Cells["Price"].Value.ToString();
                f.txtBabat_Code.Text = "019912";
                f.txtMoeen_Code.Text = "10301";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string query = "UPDATE tbl_Customer_Installment SET State=3 WHERE Guid='" + g_cell + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        frmShow_Cus_Installment_Activated(null, null);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query =
                    "SELECT tbl_Customer_Installment.Guid, tbl_Customer_Installment.Code, tbl_Customer_Installment.Sett_Date, tbl_Customer_Installment.Price, tbl_Account.Description, tbl_Customer_Installment.Notice, tbl_State.State_Name FROM tbl_Customer_Installment INNER JOIN tbl_Account ON tbl_Customer_Installment.Code = tbl_Account.Code INNER JOIN tbl_State ON tbl_Customer_Installment.State = tbl_State.State WHERE tbl_Customer_Installment.Sett_Date LIKE N'%" +
                    txtSearch.Text + "%' OR tbl_Customer_Installment.Price LIKE N'%" + txtSearch.Text +
                    "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text +
                    "%' OR tbl_Customer_Installment.Notice LIKE N'%" + txtSearch.Text +
                    "%' ORDER BY tbl_Customer_Installment.Sett_Date DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch 
            {
            }
        }
    }
}
