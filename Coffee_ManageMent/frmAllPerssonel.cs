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
    public partial class frmAllPerssonel : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Query, Acc_Code;
        public void Fill_All_Perssonel()
        {
            string Query = "SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel_Group.Group_Name, tbl_State.State_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_State ON tbl_Perssonel.State = tbl_State.State ORDER BY tbl_Perssonel.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }
        public void Fill_Peyk()
        {
            try
            {
                string Query = "SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel_Group.Group_Name, tbl_State.State_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_State ON tbl_Perssonel.State = tbl_State.State WHERE tbl_Perssonel.Group_ID=5 AND tbl_Perssonel.State=0 ORDER BY tbl_Perssonel.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
        public frmAllPerssonel()
        {
            InitializeComponent();
        }

        private void frmAllPerssonel_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (op == "All")
                {
                    Query = "SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel_Group.Group_Name, tbl_State.State_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_State ON tbl_Perssonel.State = tbl_State.State WHERE tbl_Perssonel.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Perssonel_Group.Group_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Perssonel.Code ASC";
                }
                else if (op == "Peyk")
                {
                    Query = "SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel_Group.Group_Name, tbl_State.State_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_State ON tbl_Perssonel.State = tbl_State.State WHERE Group_ID=5 AND State=0 AND (tbl_Perssonel.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Perssonel_Group.Group_Name LIKE N'%" + txtSearch.Text + "%') ORDER BY tbl_Perssonel.Code ASC";
                }
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void dgvStore_Click(object sender, EventArgs e)
        {
            try
            {
                Acc_Code = dgvStore.CurrentRow.Cells["ID"].Value.ToString();
            }
            catch
            {
                Acc_Code = null;
            }
        }

        private void dgvStore_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
