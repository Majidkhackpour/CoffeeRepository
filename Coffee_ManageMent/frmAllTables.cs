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
    public partial class frmAllTables : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public int i_Table_Code;
        public frmAllTables()
        {
            InitializeComponent();
        }

        private void frmAllTables_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Tables.Table_Code, tbl_Tables.Table_Name, tbl_Tables.Table_Chair, tbl_Tables.Table_State, tbl_Table_State.State_Name FROM tbl_Tables INNER JOIN tbl_Table_State ON tbl_Tables.Table_State = tbl_Table_State.Table_State WHERE tbl_Table_State.Table_State=0 ORDER BY tbl_Tables.Table_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
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
                string Query = "SELECT tbl_Tables.Table_Code, tbl_Tables.Table_Name, tbl_Tables.Table_Chair, tbl_Tables.Table_State, tbl_Table_State.State_Name FROM tbl_Tables INNER JOIN tbl_Table_State ON tbl_Tables.Table_State = tbl_Table_State.Table_State WHERE tbl_Table_State.Table_State=0 AND tbl_Tables.Table_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Tables.Table_Code ASC";
                clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
            }
            catch
            {
            }
        }

        private void dgvTables_Click(object sender, EventArgs e)
        {
            try
            {
                i_Table_Code = Convert.ToInt32(dgvTables.CurrentRow.Cells["Table_Code"].Value);
            }
            catch
            {
                i_Table_Code = 0;
            }
        }

        private void dgvTables_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
