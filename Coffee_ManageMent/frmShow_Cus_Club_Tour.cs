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
    public partial class frmShow_Cus_Club_Tour : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public void Fill_Data(string Code)
        {
            string query = "SELECT ID, Sum_Factor, Date, Point FROM tbl_Header_Sales_Factor WHERE C_Code='" + Code + "'";
            clsFunction.Display(query, dataconnection, dgvStore, lblCounter);
        }
        public frmShow_Cus_Club_Tour()
        {
            InitializeComponent();
        }

        private void frmShow_Cus_Club_Tour_Load(object sender, EventArgs e)
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

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmSales_Factor f = new frmSales_Factor();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["Factor_Code"].Value.ToString()));
                f.Edit_Or_View_Temp = 1;
                f.False_Enabling(Convert.ToInt32(dgvStore.CurrentRow.Cells["Factor_Code"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فاکتور فروش انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }
    }
}
