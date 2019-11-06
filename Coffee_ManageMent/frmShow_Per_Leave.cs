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
    public partial class frmShow_Per_Leave : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Per_Leave()
        {
            InitializeComponent();
        }

        private void frmShow_Per_Leave_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Leave_Perssonel.Guid, tbl_Leave_Perssonel.Per_ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Leave_Perssonel.F_Date, tbl_Leave_Perssonel.T_Date, tbl_Leave_Per_Type.Type_Name FROM tbl_Leave_Perssonel INNER JOIN tbl_Perssonel ON tbl_Leave_Perssonel.Per_ID = tbl_Perssonel.ID INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Leave_Per_Type ON tbl_Leave_Perssonel.Type = tbl_Leave_Per_Type.Type ORDER BY tbl_Leave_Perssonel.F_Date DESC";
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
                frmPer_Leave f = new frmPer_Leave();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Per_Leave_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Leave_Perssonel.Guid, tbl_Leave_Perssonel.Per_ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Leave_Perssonel.F_Date, tbl_Leave_Perssonel.T_Date, tbl_Leave_Per_Type.Type_Name FROM tbl_Leave_Perssonel INNER JOIN tbl_Perssonel ON tbl_Leave_Perssonel.Per_ID = tbl_Perssonel.ID INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Leave_Per_Type ON tbl_Leave_Perssonel.Type = tbl_Leave_Per_Type.Type ORDER BY tbl_Leave_Perssonel.F_Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmPer_Leave f = new frmPer_Leave();
                f.op = "Edit";
                f.Fill_Data((Guid.Parse(dgvStore.CurrentRow.Cells["Guid_1"].Value.ToString())));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مرخصی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Leave_Perssonel WHERE Guid='" + Guid.Parse(dgvStore.CurrentRow.Cells["Guid_1"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف مرخصی برای " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Per_Leave_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مرخصی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Leave_Perssonel.Guid, tbl_Leave_Perssonel.Per_ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Leave_Perssonel.F_Date, tbl_Leave_Perssonel.T_Date, tbl_Leave_Per_Type.Type_Name FROM tbl_Leave_Perssonel INNER JOIN tbl_Perssonel ON tbl_Leave_Perssonel.Per_ID = tbl_Perssonel.ID INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Leave_Per_Type ON tbl_Leave_Perssonel.Type = tbl_Leave_Per_Type.Type WHERE tbl_Perssonel.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Leave_Perssonel.F_Date LIKE N'%" + txtSearch.Text + "%' OR tbl_Leave_Perssonel.T_Date LIKE N'%" + txtSearch.Text + "%' OR tbl_Leave_Per_Type.Type_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Leave_Perssonel.F_Date DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
