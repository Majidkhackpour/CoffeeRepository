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
    public partial class frmShow_Income_Group : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Income_Group()
        {
            InitializeComponent();
        }

        private void frmShow_Income_Group_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT ID, Description FROM tbl_Income_Group";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
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
                frmIncome_Group f = new frmIncome_Group();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Income_Group_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT ID, Description FROM tbl_Income_Group";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
        }

        private void dgvTables_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvTables.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmIncome_Group f = new frmIncome_Group();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvTables.CurrentRow.Cells["ID"].Value));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "طبقه بندی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Income_Group WHERE ID='" + Convert.ToInt32(dgvTables.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvTables.CurrentRow.Cells["Description"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Income_Group_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این گروه درآمدی نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmIncome_Group f = new frmIncome_Group();
                f.FillData(Convert.ToInt32(dgvTables.CurrentRow.Cells["ID"].Value));
                f.btnFinish.Enabled = false;
                f.groupPanel1.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "طبقه بندی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT ID, Description FROM tbl_Income_Group WHERE Description LIKE N'%" + txtSearch.Text + "%'";
                clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
            }
            catch
            {
            }
        }
    }
}
