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
    public partial class frmShow_Safe : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Safe()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShow_Safe_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Safe.Code, tbl_Account.Description FROM tbl_Safe INNER JOIN tbl_Account ON tbl_Safe.Code = tbl_Account.Code ORDER BY tbl_Safe.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmSafe f = new frmSafe();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Safe_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Safe.Code, tbl_Account.Description FROM tbl_Safe INNER JOIN tbl_Account ON tbl_Safe.Code = tbl_Account.Code ORDER BY tbl_Safe.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmSafe f = new frmSafe();
                f.op = "Edit";
                f.Form_Load();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "صندوق انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Safe WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Description"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Safe_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این صندوق نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmSafe f = new frmSafe();
                f.Form_Load();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.grpAccount.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "صندوق انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Safe.Code, tbl_Account.Description FROM tbl_Safe INNER JOIN tbl_Account ON tbl_Safe.Code = tbl_Account.Code WHERE tbl_Safe.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Safe.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuCurrentHotel_Click(object sender, EventArgs e)
        {
            try
            {
                new frmCurrent_Safe().ShowDialog();
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
