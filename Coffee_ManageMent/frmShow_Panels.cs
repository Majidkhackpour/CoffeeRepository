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
    public partial class frmShow_Panels : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Panels()
        {
            InitializeComponent();
        }

        private void frmShow_Panels_Load(object sender, EventArgs e)
        {
            string Query = "SELECT Guid, Name FROM tbl_Panels ORDER BY Name";
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

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmPanels f = new frmPanels();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmPanels f = new frmPanels();
                f.op = "Edit";
                f.Fill_Data(Guid.Parse(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پنل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query4 = "DELETE FROM tbl_Panels WHERE Guid = '" +
                                Guid.Parse(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف پنل " + dgvStore.CurrentRow.Cells["Description"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query4) == true)
                        frmShow_Panels_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پنل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void frmShow_Panels_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT Guid, Name FROM tbl_Panels ORDER BY Name";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmPanels f = new frmPanels();
                f.Fill_Data(Guid.Parse(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString()));
                f.grp1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "پنل انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT Guid, Name FROM tbl_Panels WHERE Name LIKE N'%" + txtSearch.Text +
                               "%' ORDER BY Name";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch 
            {
            }
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuShow_Winners_Click(object sender, EventArgs e)
        {
            try
            {
                new frmCurrent_Panel().ShowDialog();
            }
            catch 
            {
            }
        }
    }
}
