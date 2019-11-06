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
    public partial class frmShow_Transfer_BedBes : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        private void Fill_Data()
        {
            try
            {
                string Query =
                    "SELECT tbl_Transfer_BedBes.Guid, tbl_Transfer_BedBes.Date, tbl_Transfer_BedBes.Parent_Code, tbl_Transfer_BedBes.Mabda_Code, tbl_Transfer_BedBes.Mabda_Name, tbl_Transfer_BedBes.Maqsad_Code, tbl_Transfer_BedBes.Maqsad_Name, tbl_Transfer_BedBes.Price, tbl_Transfer_Type.Type_Name FROM tbl_Transfer_BedBes INNER JOIN tbl_Transfer_Type ON tbl_Transfer_BedBes.Type = tbl_Transfer_Type.Type ORDER BY tbl_Transfer_BedBes.Date DESC";
                clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
            }
            catch
            {
            }
        }
        public frmShow_Transfer_BedBes()
        {
            InitializeComponent();
        }

        private void frmShow_Transfer_BedBes_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            Fill_Data();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void frmShow_Transfer_BedBes_Activated(object sender, EventArgs e)
        {
            Fill_Data();
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
                frmTransfer_BedBes f = new frmTransfer_BedBes();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch 
            {
            }
        }

        private void dgvProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvProduct.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmTransfer_BedBes f = new frmTransfer_BedBes();
                f.op = "Edit";
                f.Fill_Data(Guid.Parse(dgvProduct.CurrentRow.Cells["Guid1"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = " انتقال انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Transaction WHERE Parent=21 AND Parent_Code='" + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + "'";
                string query2 = "DELETE FROM tbl_Transfer_BedBes WHERE Guid='" +
                                Guid.Parse(dgvProduct.CurrentRow.Cells["Guid1"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف  انتقال به عطف سند " + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query2) == true &&
                        clsFunction.Execute(dataconnection, query1) == true)
                    {
                        Fill_Data();
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = " انتقال انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmTransfer_BedBes f = new frmTransfer_BedBes();
                f.Fill_Data(Guid.Parse(dgvProduct.CurrentRow.Cells["Guid1"].Value.ToString()));
                f.grpAccount.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = " انتقال انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Query =
                "SELECT tbl_Transfer_BedBes.Guid, tbl_Transfer_BedBes.Date, tbl_Transfer_BedBes.Parent_Code, tbl_Transfer_BedBes.Mabda_Code, tbl_Transfer_BedBes.Mabda_Name, tbl_Transfer_BedBes.Maqsad_Code, tbl_Transfer_BedBes.Maqsad_Name, tbl_Transfer_BedBes.Price, tbl_Transfer_Type.Type_Name FROM tbl_Transfer_BedBes INNER JOIN tbl_Transfer_Type ON tbl_Transfer_BedBes.Type = tbl_Transfer_Type.Type WHERE tbl_Transfer_BedBes.Date LIKE N'%" +
                txtSearch.Text + "%' OR tbl_Transfer_BedBes.Mabda_Name LIKE N'%" + txtSearch.Text +
                "%' OR tbl_Transfer_BedBes.Maqsad_Name LIKE N'%" + txtSearch.Text +
                "%' OR tbl_Transfer_BedBes.Price LIKE N'%" + txtSearch.Text +
                "%' OR tbl_Transfer_Type.Type_Name LIKE N'%" + txtSearch.Text +
                "%' ORDER BY tbl_Transfer_BedBes.Date DESC";
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
        }
    }
}
