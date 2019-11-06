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
    public partial class frmPay_Recive_Identity : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Iden_Code, op, Query, Moeen_Code;
        public void Fill_Daryaft()
        {
            string Query = "SELECT Code, Name, Moeen FROM tbl_Pay_Recive_Identity WHERE Type=0 ORDER BY Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_Pardakht()
        {
            string Query = "SELECT Code, Name, Moeen FROM tbl_Pay_Recive_Identity WHERE Type=1 ORDER BY Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public frmPay_Recive_Identity()
        {
            InitializeComponent();
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccount.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (op == "Daryaft")
            {
                Query = "SELECT Code, Name, Moeen FROM tbl_Pay_Recive_Identity WHERE Type=0 AND (Code LIKE N'%" + txtSearch.Text + "%' OR Name LIKE N'%" + txtSearch.Text + "%') ORDER BY Code ASC";
            }
            else if (op == "Pardakht")
            {
                Query = "SELECT Code, Name, Moeen FROM tbl_Pay_Recive_Identity WHERE Type=1 AND (Code LIKE N'%" + txtSearch.Text + "%' OR Name LIKE N'%" + txtSearch.Text + "%') ORDER BY Code ASC";
            }
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }

        private void dgvAccount_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Iden_Code = dgvAccount.CurrentRow.Cells["Code"].Value.ToString();
            }
            catch
            {
                Iden_Code = null;
            }
            try
            {
                Moeen_Code = dgvAccount.CurrentRow.Cells["Moeen"].Value.ToString();
            }
            catch
            {
                Moeen_Code = null;
            }
        }

        private void frmPay_Recive_Identity_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    Iden_Code = dgvAccount.CurrentRow.Cells["Code"].Value.ToString();
                }
                catch
                {
                    Iden_Code = null;
                }
                try
                {
                    Moeen_Code = dgvAccount.CurrentRow.Cells["Moeen"].Value.ToString();
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

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
