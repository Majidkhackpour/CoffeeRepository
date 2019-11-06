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
    public partial class frmShow_Stores : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Stores()
        {
            InitializeComponent();
        }

        private void frmShow_Stores_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Store.Code, tbl_Store.Name, tbl_Store.Shown_Name, tbl_Store_Type.Type_Name FROM tbl_Store INNER JOIN tbl_Store_Type ON tbl_Store.Type = tbl_Store_Type.Type ORDER BY tbl_Store.Code ASC";
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

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmStores f = new frmStores();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmStores f = new frmStores();
                f.op = "Edit";
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "انبار انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void frmShow_Stores_Activated(object sender, EventArgs e)
        {
            frmShow_Stores_Load(null, null);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM tbl_Store WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف انبار " + dgvStore.CurrentRow.Cells["Shown_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query) == true)
                        frmShow_Stores_Load(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما مجاز به حذف این انبار نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmStores f = new frmStores();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.grpStores.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "انبار انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT tbl_Store.Code, tbl_Store.Name, tbl_Store.Shown_Name, tbl_Store_Type.Type_Name FROM tbl_Store INNER JOIN tbl_Store_Type ON tbl_Store.Type = tbl_Store_Type.Type WHERE tbl_Store.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Store.Shown_Name LIKE N'%" + txtSearch.Text + "%'";
                clsFunction.Display(query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuCurrentHotel_Click(object sender, EventArgs e)
        {
            try
            {
                new frmCurrent_Store().ShowDialog();
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
