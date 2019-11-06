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
    public partial class frmShow_Price_Pattern : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Query;
        public frmShow_Price_Pattern()
        {
            InitializeComponent();
        }

        private void frmShow_Price_Pattern_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            if (op == "Buy")
            {
                lblPattern.Text = "( " + "قیمت خرید " + ")";
                Query = "SELECT tbl_Price_Pattern.Code, tbl_Price_Pattern.Description, tbl_Price_Pattern.Start_Date, tbl_Price_Pattern.Expiration_Date, tbl_State.State_Name FROM tbl_Price_Pattern INNER JOIN tbl_State ON tbl_Price_Pattern.State = tbl_State.State WHERE tbl_Price_Pattern.Type=0 ORDER BY tbl_Price_Pattern.Code ASC";
            }
            else if (op == "Sell")
            {
                lblPattern.Text = "( " + "قیمت فروش " + ")";
                Query = "SELECT tbl_Price_Pattern.Code, tbl_Price_Pattern.Description, tbl_Price_Pattern.Start_Date, tbl_Price_Pattern.Expiration_Date, tbl_State.State_Name FROM tbl_Price_Pattern INNER JOIN tbl_State ON tbl_Price_Pattern.State = tbl_State.State WHERE tbl_Price_Pattern.Type=1 ORDER BY tbl_Price_Pattern.Code ASC";
            }
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
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
                frmPrice_Pattern f = new frmPrice_Pattern();
                if (op == "Buy")
                    f.op = "Buy_Add";
                else if (op == "Sell")
                    f.op = "Sell_Add";
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
                frmPrice_Pattern f = new frmPrice_Pattern();
                f.op = "Edit";
                f.Form_Load();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "الگوی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void frmShow_Price_Pattern_Activated(object sender, EventArgs e)
        {
            if (op == "Buy")
                Query = "SELECT tbl_Price_Pattern.Code, tbl_Price_Pattern.Description, tbl_Price_Pattern.Start_Date, tbl_Price_Pattern.Expiration_Date, tbl_State.State_Name FROM tbl_Price_Pattern INNER JOIN tbl_State ON tbl_Price_Pattern.State = tbl_State.State WHERE tbl_Price_Pattern.Type=0 ORDER BY tbl_Price_Pattern.Code ASC";
            else if (op == "Sell")
                Query = "SELECT tbl_Price_Pattern.Code, tbl_Price_Pattern.Description, tbl_Price_Pattern.Start_Date, tbl_Price_Pattern.Expiration_Date, tbl_State.State_Name FROM tbl_Price_Pattern INNER JOIN tbl_State ON tbl_Price_Pattern.State = tbl_State.State WHERE tbl_Price_Pattern.Type=1 ORDER BY tbl_Price_Pattern.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Price_Pattern WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                string query2 = "DELETE FROM tbl_Price_List WHERE Pattern_Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Price_Pattern_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این الگوی قیمت نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuEnable_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "فعال")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وضعیت الگوی قیمت  " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "فعال است";
                f.ShowDialog();
            }
            else
            {
                string query = "UPDATE tbl_Price_Pattern SET State = 0 WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Price_Pattern_Activated(null, null);
                }
            }
        }

        private void mnuDisable_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "غیرفعال")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "وضعیت الگوی قیمت " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "غیرفعال است";
                f.ShowDialog();
            }
            else
            {
                string query = "UPDATE tbl_Price_Pattern SET State = 1 WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    frmShow_Price_Pattern_Activated(null, null);
                }
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmPrice_Pattern f = new frmPrice_Pattern();
                f.Form_Load();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.btnFinish.Enabled = false;
                f.grp1.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "الگوی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuCost_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduct_Price f = new frmProduct_Price();
                f.lblPattern_Code.Text = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                f.lblPattern_Name.Text = dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString();
                if (op == "Buy")
                {
                    f.dgvProduct.Columns["Sell_Price"].Visible = false;
                    f.Fill_Buy_Price();
                }
                else if (op == "Sell")
                {
                    f.dgvProduct.Columns["Buy_Price"].Visible = false;
                    f.Fill_Sell_Price();
                }
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuCurrent_Pattern_Click(object sender, EventArgs e)
        {
            try
            {
                frmCurrent_Pattern_Price f = new frmCurrent_Pattern_Price();
                if (op == "Buy")
                {
                    f.lblType.Text = "خرید";
                    f.Pattern_Type = "Buy";
                }
                else if (op == "Sell")
                {
                    f.lblType.Text = "فروش";
                    f.Pattern_Type = "Sell";
                }
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
                if (op == "Buy")
                    Query = "SELECT tbl_Price_Pattern.Code, tbl_Price_Pattern.Description, tbl_Price_Pattern.Start_Date, tbl_Price_Pattern.Expiration_Date, tbl_State.State_Name FROM tbl_Price_Pattern INNER JOIN tbl_State ON tbl_Price_Pattern.State = tbl_State.State WHERE tbl_Price_Pattern.Type=0 AND (tbl_Price_Pattern.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Price_Pattern.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_State.State_Name LIKE N'%" + txtSearch.Text + "%') ORDER BY tbl_Price_Pattern.Code ASC";
                else if (op == "Sell")
                    Query = "SELECT tbl_Price_Pattern.Code, tbl_Price_Pattern.Description, tbl_Price_Pattern.Start_Date, tbl_Price_Pattern.Expiration_Date, tbl_State.State_Name FROM tbl_Price_Pattern INNER JOIN tbl_State ON tbl_Price_Pattern.State = tbl_State.State WHERE tbl_Price_Pattern.Type=1 AND (tbl_Price_Pattern.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Price_Pattern.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_State.State_Name LIKE N'%" + txtSearch.Text + "%') ORDER BY tbl_Price_Pattern.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
