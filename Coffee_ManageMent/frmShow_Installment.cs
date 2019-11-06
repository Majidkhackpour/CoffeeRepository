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
    public partial class frmShow_Installment : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Code;
        public frmShow_Installment()
        {
            InitializeComponent();
        }

        private void frmShow_Installment_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Body_Loan.Date, tbl_Body_Loan.Price, tbl_State.State_Name FROM tbl_Body_Loan INNER JOIN tbl_State ON tbl_Body_Loan.State = tbl_State.State WHERE tbl_Body_Loan.Code='" + Code + "' AND tbl_Body_Loan.State=2 ORDER BY tbl_Body_Loan.Date ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            mnuDisable.Visible = false;
            mnuEnable.Visible = true;
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

        private void mnuAll_Click(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Body_Loan.Date, tbl_Body_Loan.Price, tbl_State.State_Name FROM tbl_Body_Loan INNER JOIN tbl_State ON tbl_Body_Loan.State = tbl_State.State WHERE tbl_Body_Loan.Code='" + Code + "' ORDER BY tbl_Body_Loan.Date ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
        }

        private void mnuEnable_Click(object sender, EventArgs e)
        {
            mnuDisable.Visible = true;
            mnuEnable.Visible = false;
            string Query = "SELECT tbl_Body_Loan.Date, tbl_Body_Loan.Price, tbl_State.State_Name FROM tbl_Body_Loan INNER JOIN tbl_State ON tbl_Body_Loan.State = tbl_State.State WHERE tbl_Body_Loan.Code='" + Code + "' AND tbl_Body_Loan.State=3 ORDER BY tbl_Body_Loan.Date ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
        }

        private void mnuDisable_Click(object sender, EventArgs e)
        {
            mnuDisable.Visible = false;
            mnuEnable.Visible = true;
            string Query = "SELECT tbl_Body_Loan.Date, tbl_Body_Loan.Price, tbl_State.State_Name FROM tbl_Body_Loan INNER JOIN tbl_State ON tbl_Body_Loan.State = tbl_State.State WHERE tbl_Body_Loan.Code='" + Code + "' AND tbl_Body_Loan.State=2 ORDER BY tbl_Body_Loan.Date ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
        }

        private void mnuCash_Click(object sender, EventArgs e)
        {
            try
            {
                frmCash_Pardakht f = new frmCash_Pardakht();
                f.Form_Load();
                f.op = "Add";
                f.txtDate.Text = dgvTables.CurrentRow.Cells["Date"].Value.ToString();
                f.Loan_Date = dgvTables.CurrentRow.Cells["Date"].Value.ToString();
                f.txtCode.Text = Code;
                f.Loan_Code = Code;
                f.txtCash.Text = dgvTables.CurrentRow.Cells["Price"].Value.ToString();
                f.Loan_Price = Convert.ToInt64(dgvTables.CurrentRow.Cells["Price"].Value);
                f.txtBabat_Code.Text = "029925";
                f.Type = "Loan";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Installment_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Body_Loan.Date, tbl_Body_Loan.Price, tbl_State.State_Name FROM tbl_Body_Loan INNER JOIN tbl_State ON tbl_Body_Loan.State = tbl_State.State WHERE tbl_Body_Loan.Code='" + Code + "' AND tbl_Body_Loan.State=2 ORDER BY tbl_Body_Loan.Date ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
        }

        private void mnuBank_Click(object sender, EventArgs e)
        {
            try
            {
                frmBank_Pardakht f = new frmBank_Pardakht();
                f.Form_Load();
                f.op = "Add";
                f.txtDate.Text = dgvTables.CurrentRow.Cells["Date"].Value.ToString();
                f.Loan_Date = dgvTables.CurrentRow.Cells["Date"].Value.ToString();
                f.txtCode.Text = Code;
                f.Loan_Code = Code;
                f.txtCash.Text = dgvTables.CurrentRow.Cells["Price"].Value.ToString();
                f.Loan_Price = Convert.ToInt64(dgvTables.CurrentRow.Cells["Price"].Value);
                f.txtBabat_Code.Text = "029925";
                f.Type = "Loan";
                f.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
