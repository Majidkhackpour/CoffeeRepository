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
    public partial class frmShow_Lottery : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Lottery()
        {
            InitializeComponent();
        }

        private void frmShow_Festival_Load(object sender, EventArgs e)
        {
            string Query = "SELECT Number, Date, Winner_Count, Award, Notice FROM tbl_Header_Lottery ORDER BY Number DESC";
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
                frmLottery f = new frmLottery();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Festival_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT Number, Date, Winner_Count, Award, Notice FROM tbl_Header_Lottery ORDER BY Number DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmLottery f = new frmLottery();
                f.op = "Edit";
                f.Fill_Data((Convert.ToInt32(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString())));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "جشنواره انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Lottery WHERE Number='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString()) + "'";
                string query2 = "DELETE FROM tbl_Header_Lottery WHERE Number='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString()) + "'";
                string query3 = "DELETE FROM tbl_Transaction WHERE Parent=20 AND Parent_Code = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف قرعه کشی اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                    {
                        frmMessage f1 = new frmMessage();
                        f1.lblMessage.Text = "قرعه کشی با موفقیت حذف شد. آیا مایلید سند حسابداری هم حذف شود؟";
                        f1.flag = 1;
                        f1.ShowDialog();
                        if (f.Resault == 0)
                        {
                            if (clsFunction.Execute(dataconnection, query3) == true)
                            {
                            }
                        }
                        frmShow_Festival_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این جشنواره نمی باشید";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT Number, Date, Winner_Count, Award, Notice FROM tbl_Header_Lottery ORDER BY Number DESC";
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

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmLottery f = new frmLottery();
                f.Fill_Data((Convert.ToInt32(dgvStore.CurrentRow.Cells["Guid1"].Value.ToString())));
                f.grp1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "جشنواره انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuShow_Winners_Click(object sender, EventArgs e)
        {
            try
            {
                frmLottery_Winners f = new frmLottery_Winners();
                f.Display_Winners(Convert.ToInt32(dgvStore.CurrentRow.Cells["Guid1"].Value));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "جشنواره انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }
    }
}
