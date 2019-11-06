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
    public partial class frmShow_Tables_Reservation : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Tables_Reservation()
        {
            InitializeComponent();
        }

        private void frmShow_Tables_Reservation_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Table_Reserve.ID, tbl_Tables.Table_Name, tbl_Account.Description, tbl_Table_Reserve.Date, tbl_Table_Reserve.Time, tbl_Table_Reserve.Guest_Number FROM tbl_Table_Reserve INNER JOIN tbl_Tables ON tbl_Table_Reserve.Table_Code = tbl_Tables.Table_Code INNER JOIN tbl_Account ON tbl_Table_Reserve.Code = tbl_Account.Code ORDER BY tbl_Table_Reserve.Date DESC";
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

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmTable_Reservation f = new frmTable_Reservation();
                f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                f.int_ID = Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value);
                f.s_op = "Edit";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Tables_Reservation_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Table_Reserve.ID, tbl_Tables.Table_Name, tbl_Account.Description, tbl_Table_Reserve.Date, tbl_Table_Reserve.Time, tbl_Table_Reserve.Guest_Number FROM tbl_Table_Reserve INNER JOIN tbl_Tables ON tbl_Table_Reserve.Table_Code = tbl_Tables.Table_Code INNER JOIN tbl_Account ON tbl_Table_Reserve.Code = tbl_Account.Code ORDER BY tbl_Table_Reserve.Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Table_Reserve.ID, tbl_Tables.Table_Name, tbl_Account.Description, tbl_Table_Reserve.Date, tbl_Table_Reserve.Time, tbl_Table_Reserve.Guest_Number FROM tbl_Table_Reserve INNER JOIN tbl_Tables ON tbl_Table_Reserve.Table_Code = tbl_Tables.Table_Code INNER JOIN tbl_Account ON tbl_Table_Reserve.Code = tbl_Account.Code WHERE tbl_Tables.Table_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Table_Reserve.Date DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
