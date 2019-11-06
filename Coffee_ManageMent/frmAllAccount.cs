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
    public partial class frmAllAccount : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Acc_Code, op, Query;
        public void Fill_All_Account()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_Real_Account()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=30 ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_Real_And_Right_Account()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE (tbl_Account.Parent=30 OR tbl_Account.Parent=40) ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_Safe()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=20 ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_Bank()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=10 ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_Check()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=10 ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_Loan()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=40 ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public frmAllAccount()
        {
            InitializeComponent();
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccount.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (op == "All")
                {
                    Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Account.Code ASC";
                }
                else if (op == "Rael_Acc")
                {
                    Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=30 AND tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Account.Code ASC";
                }
                else if (op == "Rael_And_Right_Acc")
                {
                    Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE (tbl_Account.Parent=30 OR tbl_Account.Parent=40) AND tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Account.Code ASC";
                }
                else if (op == "Safe")
                {
                    Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=20 AND tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Account.Code ASC";
                }
                else if (op == "Bank")
                {
                    Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=10 AND tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Account.Code ASC";
                }
                else if (op == "Check")
                {
                    Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=10 AND tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Account.Code ASC";
                }
                else if (op == "Loan")
                {
                    Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name, tbl_Account.Parent FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Parent=40 AND tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Account.Code ASC";
                }
                clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
            }
            catch
            {
            }
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

        private void frmAllAccount_Load(object sender, EventArgs e)
        {
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

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
