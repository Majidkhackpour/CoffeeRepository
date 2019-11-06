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
    public partial class frmShow_Production : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Production()
        {
            InitializeComponent();
        }

        private void frmShow_Production_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Prd.ID, tbl_Header_Prd.Prd_Name, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Store.Shown_Name FROM tbl_Header_Prd INNER JOIN tbl_Product ON tbl_Header_Prd.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Header_Prd.Store = tbl_Store.Code AND tbl_Product.Store = tbl_Store.Code ORDER BY tbl_Header_Prd.ID ASC";
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
                frmProduction f = new frmProduction();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Production_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Prd.ID, tbl_Header_Prd.Prd_Name, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Store.Shown_Name FROM tbl_Header_Prd INNER JOIN tbl_Product ON tbl_Header_Prd.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Header_Prd.Store = tbl_Store.Code AND tbl_Product.Store = tbl_Store.Code ORDER BY tbl_Header_Prd.ID ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduction f = new frmProduction();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فرمول انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            string query1 = "DELETE FROM tbl_Body_Prd WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
            string query2 = "DELETE FROM tbl_Header_Prd WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
            frmMessage f = new frmMessage();
            f.lblMessage.Text = "آیا از حذف فرمول " + dgvStore.CurrentRow.Cells["Prd_Name"].Value.ToString() + " " + "اطمینان دارید؟";
            f.flag = 1;
            f.ShowDialog();
            if (f.Resault == 0)
            {
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                    frmShow_Production_Activated(null, null);
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduction f = new frmProduction();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.btnFinish.Enabled = false;
                f.dgvStore.Enabled = false;
                f.groupPanel1.Enabled = false;
                f.groupPanel2.Enabled = false;
                f.grp1.Enabled = false;
                f.txtP_Cost.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فرمول انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Prd.ID, tbl_Header_Prd.Prd_Name, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Store.Shown_Name FROM tbl_Header_Prd INNER JOIN tbl_Product ON tbl_Header_Prd.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Header_Prd.Store = tbl_Store.Code AND tbl_Product.Store = tbl_Store.Code WHERE tbl_Header_Prd.Prd_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Product.P_Show_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Store.Shown_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Header_Prd.ID ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
