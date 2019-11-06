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
    public partial class frmShow_Income : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Income()
        {
            InitializeComponent();
        }

        private void frmShow_Income_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Income.ID, tbl_Income_Group.Description, tbl_Income.Inc_Name, tbl_Income.Price FROM tbl_Income INNER JOIN tbl_Income_Group ON tbl_Income.Group_ID = tbl_Income_Group.ID ORDER BY tbl_Income.ID ASC";
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
                frmIncome f = new frmIncome();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Income_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Income.ID, tbl_Income_Group.Description, tbl_Income.Inc_Name, tbl_Income.Price FROM tbl_Income INNER JOIN tbl_Income_Group ON tbl_Income.Group_ID = tbl_Income_Group.ID ORDER BY tbl_Income.ID ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmIncome f = new frmIncome();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "درآمد انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Income WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Inc_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Income_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "درآمد انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Income.ID, tbl_Income_Group.Description, tbl_Income.Inc_Name, tbl_Income.Price FROM tbl_Income INNER JOIN tbl_Income_Group ON tbl_Income.Group_ID = tbl_Income_Group.ID WHERE tbl_Income_Group.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Income.Inc_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Income.ID ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
