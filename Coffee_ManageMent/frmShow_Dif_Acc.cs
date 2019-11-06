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
    public partial class frmShow_Dif_Acc : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Moeen_Code;
        public frmShow_Dif_Acc()
        {
            InitializeComponent();
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccount.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void frmShow_Dif_Acc_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT * FROM tbl_DefinitiveAccount";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmDifinitive_Account f = new frmDifinitive_Account();
                f.txtAccCode.Text = dgvAccount.CurrentRow.Cells["AccCode"].Value.ToString();
                f.txtDescription.Text = dgvAccount.CurrentRow.Cells["Description"].Value.ToString();
                if (Convert.ToInt32(dgvAccount.CurrentRow.Cells["AccType"].Value) == 0)
                    f.rbtn1.Checked = true;
                else if (Convert.ToInt32(dgvAccount.CurrentRow.Cells["AccType"].Value) == 1)
                    f.rbtn2.Checked = true;
                else if (Convert.ToInt32(dgvAccount.CurrentRow.Cells["AccType"].Value) == 2)
                    f.rbtn3.Checked = true;
                else if (Convert.ToInt32(dgvAccount.CurrentRow.Cells["AccType"].Value) == 3)
                    f.rbtn4.Checked = true;
                else if (Convert.ToInt32(dgvAccount.CurrentRow.Cells["AccType"].Value) == 4)
                    f.rbtn5.Checked = true;
                f.ShowDialog();
            }
            catch
            {

            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT * FROM tbl_DefinitiveAccount WHERE AccCode LIKE N'%" + txtSearch.Text + "%' OR Description LIKE N'%" + txtSearch.Text + "%'";
                clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
            }
            catch
            {
            }
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Moeen_Code = dgvAccount.CurrentRow.Cells["AccCode"].Value.ToString();
            }
            catch
            {
                Moeen_Code = null;
            }
        }

        private void dgvAccount_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    Moeen_Code = dgvAccount.CurrentRow.Cells["AccCode"].Value.ToString();
                }
                catch
                {
                    Moeen_Code = null;
                }
                finally
                {
                    this.Close();
                }
            }
        }
    }
}
