﻿using System;
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
    public partial class frmShow_Product_Production : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmShow_Product_Production()
        {
            InitializeComponent();
        }

        private void frmShow_Product_Production_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Header_Product_Production.ID, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Header_Product_Production.Ins_Date, tbl_Header_Product_Production.Notice FROM tbl_Header_Product_Production INNER JOIN tbl_Product ON tbl_Header_Product_Production.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code ORDER BY tbl_Header_Product_Production.Ins_Date DESC";
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
                frmProduct_Production f = new frmProduct_Production();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void frmShow_Product_Production_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Header_Product_Production.ID, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Header_Product_Production.Ins_Date, tbl_Header_Product_Production.Notice FROM tbl_Header_Product_Production INNER JOIN tbl_Product ON tbl_Header_Product_Production.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code ORDER BY tbl_Header_Product_Production.Ins_Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduct_Production f = new frmProduct_Production();
                f.op = "Edit";
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تولید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Product_Production WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                string query2 = "DELETE FROM tbl_Header_Product_Production WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                string query3 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=10 AND Parent_Code='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف تولید " + dgvStore.CurrentRow.Cells["P_Show_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                        frmShow_Product_Production_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تولید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduct_Production f = new frmProduct_Production();
                f.FillData(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grp1.Enabled = false;
                f.superTabControlPanel1.Enabled = false;
                f.dgvStore.Enabled = false;
                f.grp2.Enabled = false;
                f.txtP_Cost.Enabled = false;
                f.txtNotice.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تولید انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Header_Product_Production.ID, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Header_Product_Production.Ins_Date, tbl_Header_Product_Production.Notice FROM tbl_Header_Product_Production INNER JOIN tbl_Product ON tbl_Header_Product_Production.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code WHERE tbl_Product.P_Show_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Header_Product_Production.Notice LIKE N'%"+txtSearch.Text+"%' ORDER BY tbl_Header_Product_Production.Ins_Date DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }
    }
}
