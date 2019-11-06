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
    public partial class frmShow_Tables : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Tables()
        {
            InitializeComponent();
        }

        private void frmShow_Tables_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Tables.Table_Code, tbl_Tables.Table_Name, tbl_Tables.Table_Chair, tbl_Tables.Table_State, tbl_Table_State.State_Name FROM tbl_Tables INNER JOIN tbl_Table_State ON tbl_Tables.Table_State = tbl_Table_State.Table_State ORDER BY tbl_Tables.Table_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
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
                frmTables_Unique f = new frmTables_Unique();
                f.Form_Load();
                f.op = "Add";
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
                frmTables_Unique f = new frmTables_Unique();
                f.op = "Edit";
                f.Form_Load();
                f.FillData(dgvTables.CurrentRow.Cells["Table_Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "میز انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void frmShow_Tables_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Tables.Table_Code, tbl_Tables.Table_Name, tbl_Tables.Table_Chair, tbl_Tables.Table_State, tbl_Table_State.State_Name FROM tbl_Tables INNER JOIN tbl_Table_State ON tbl_Tables.Table_State = tbl_Table_State.Table_State ORDER BY tbl_Tables.Table_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTables.CurrentRow.Cells["Table_State"].Value.ToString() != "0")
                {
                    frmMessage f1 = new frmMessage();
                    f1.flag = 0;
                    f1.lblMessage.Text = "شما قادر به حذف این میز نمی باشید";
                    f1.ShowDialog();
                }
                else
                {
                    string query1 = "DELETE FROM tbl_Tables WHERE Table_Code='" + dgvTables.CurrentRow.Cells["Table_Code"].Value.ToString() + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف " + dgvTables.CurrentRow.Cells["Table_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true)
                            frmShow_Tables_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این میز نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmTables_Unique f = new frmTables_Unique();
                f.Form_Load();
                f.FillData(dgvTables.CurrentRow.Cells["Table_Code"].Value.ToString());
                f.groupPanel1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "میز انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuInsert_Group_Click(object sender, EventArgs e)
        {
            try
            {
                frmTables_Group f = new frmTables_Group();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuEdit_Group_Click(object sender, EventArgs e)
        {
            try
            {
                frmTables_Group f = new frmTables_Group();
                f.op = "Edit";
                f.Form_Load_For_Edit();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Tables.Table_Code, tbl_Tables.Table_Name, tbl_Tables.Table_Chair, tbl_Tables.Table_State, tbl_Table_State.State_Name FROM tbl_Tables INNER JOIN tbl_Table_State ON tbl_Tables.Table_State = tbl_Table_State.Table_State WHERE tbl_Tables.Table_Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Table_State.State_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Tables.Table_Code ASC";
                clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
            }
            catch
            {
            }
        }
    }
}
