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
    public partial class frmAllSeller : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Acc_Code, Query;
        public frmAllSeller()
        {
            InitializeComponent();
        }

        private void frmAllSeller_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Seller.Code, tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Seller ON tbl_Account.Code = tbl_Seller.Code WHERE tbl_Seller.State=0 ORDER BY tbl_Seller.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccount.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void dgvAccount_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Acc_Code = dgvAccount.CurrentRow.Cells["Code"].Value.ToString();
            }
            catch
            {
                Acc_Code = null;
            }
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
                frmAccount f = new frmAccount();
                f.op = "Add";
                f.flag = 0;
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    Acc_Code = dgvAccount.CurrentRow.Cells["Code"].Value.ToString();
                }
                catch
                {
                    Acc_Code = null;
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Seller.Code, tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Seller ON tbl_Account.Code = tbl_Seller.Code WHERE tbl_Seller.State=0 AND (tbl_Seller.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%') ORDER BY tbl_Seller.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
            }
            catch
            {
            }
        }
    }
}
