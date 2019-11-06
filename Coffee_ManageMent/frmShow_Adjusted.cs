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
    public partial class frmShow_Adjusted : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Adjusted()
        {
            InitializeComponent();
        }

        private void frmShow_Adjusted_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Adjusted.ID, tbl_Header_Adjusted.Date, tbl_Header_Adjusted.Notice, tbl_Adjusted_Type.Type_Name FROM tbl_Header_Adjusted INNER JOIN tbl_Adjusted_Type ON tbl_Header_Adjusted.Ad_Type = tbl_Adjusted_Type.Type ORDER BY tbl_Header_Adjusted.Date DESC";
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
                frmAdjusted f = new frmAdjusted();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Adjusted_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Adjusted.ID, tbl_Header_Adjusted.Date, tbl_Header_Adjusted.Notice, tbl_Adjusted_Type.Type_Name FROM tbl_Header_Adjusted INNER JOIN tbl_Adjusted_Type ON tbl_Header_Adjusted.Ad_Type = tbl_Adjusted_Type.Type ORDER BY tbl_Header_Adjusted.Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdjusted f = new frmAdjusted();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تعدیل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdjusted f = new frmAdjusted();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grp1.Enabled = false;
                f.grp2.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تعدیل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=16 AND Parent_Code = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                string query2 = "DELETE FROM tbl_Body_Adjusted WHERE ID = '" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                string query3 = "DELETE FROM tbl_Header_Adjusted WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف تعدیل به شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                    {
                        frmShow_Adjusted_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تعدیل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Adjusted.ID, tbl_Header_Adjusted.Date, tbl_Header_Adjusted.Notice, tbl_Adjusted_Type.Type_Name FROM tbl_Header_Adjusted INNER JOIN tbl_Adjusted_Type ON tbl_Header_Adjusted.Ad_Type = tbl_Adjusted_Type.Type WHERE tbl_Header_Adjusted.Notice LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Adjusted.Date DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
