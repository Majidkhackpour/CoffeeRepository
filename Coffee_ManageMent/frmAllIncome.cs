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
    public partial class frmAllIncome : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Income_Code;
        public frmAllIncome()
        {
            InitializeComponent();
        }

        private void frmAllIncome_Load(object sender, EventArgs e)
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

        private void dgvStore_Click(object sender, EventArgs e)
        {
            try
            {
                Income_Code = dgvStore.CurrentRow.Cells["ID"].Value.ToString();
            }
            catch
            {
                Income_Code = null;
            }
        }

        private void dgvStore_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
