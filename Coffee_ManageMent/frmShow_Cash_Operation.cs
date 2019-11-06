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
    public partial class frmShow_Cash_Operation : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        string Safe_Code, query1;
        private void Fill_Safe()
        {
            try
            {
                cmbSafe.Items.Clear();
                string Query = "SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Safe ON tbl_Account.Code = tbl_Safe.Code";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbSafe, s_obj);
                cmbSafe.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Safe FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbSafe.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void Fill_Data()
        {
            try
            {
                string Query = "SELECT tbl_Transaction.Date, tbl_Transaction.Parent_Code, tbl_Transaction.Bedehkar, tbl_Transaction.Bestankar, tbl_Transaction.Notice FROM tbl_Transaction INNER JOIN tbl_Account ON tbl_Transaction.Code = tbl_Account.Code WHERE tbl_Transaction.Code='" + Safe_Code + "' AND tbl_Transaction.Date='" + clsFunction.M2SH(DateTime.Now) + "' ORDER BY tbl_Transaction.Date DESC";
                clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
            }
            catch
            {
            }
        }
        public frmShow_Cash_Operation()
        {
            InitializeComponent();
        }

        private void frmShow_Cash_Operation_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            Fill_Safe();
            Fill_Data();
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

        private void cmbSafe_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + cmbSafe.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Safe_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
            Fill_Data();
        }

        private void mnuShow_All_Click(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Transaction.Date, tbl_Transaction.Parent_Code, tbl_Transaction.Bedehkar, tbl_Transaction.Bestankar, tbl_Transaction.Notice FROM tbl_Transaction INNER JOIN tbl_Account ON tbl_Transaction.Code = tbl_Account.Code WHERE tbl_Transaction.Code='" + Safe_Code + "' ORDER BY tbl_Transaction.Date DESC";
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
        }

        private void mnuDaryaft_Click(object sender, EventArgs e)
        {
            try
            {
                frmCash_Daryaft f = new frmCash_Daryaft();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuPardakht_Click(object sender, EventArgs e)
        {
            try
            {
                frmCash_Pardakht f = new frmCash_Pardakht();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Cash_Operation_Activated(object sender, EventArgs e)
        {
            Fill_Data();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Parent FROM tbl_Transaction WHERE Parent_Code='" + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() != "5" && dt.Rows[0].ItemArray[0].ToString() != "6")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این عملیات مختص فاکتور بوده و باید از همان طریق نسبت به ویرایش آن اقدام نمایید";
                    f.ShowDialog();
                }
                else
                {
                    if (dgvProduct.CurrentRow.Cells["Bedehkar"].Value.ToString() != "")
                    {
                        frmCash_Daryaft f = new frmCash_Daryaft();
                        f.Fill_Data(Convert.ToInt32(dgvProduct.CurrentRow.Cells["ID"].Value));
                        f.op = "Edit";
                        f.ShowDialog();
                    }
                    else if (dgvProduct.CurrentRow.Cells["Bestankar"].Value.ToString() != "")
                    {
                        frmCash_Pardakht f = new frmCash_Pardakht();
                        f.Fill_Data(Convert.ToInt32(dgvProduct.CurrentRow.Cells["ID"].Value));
                        f.op = "Edit";
                        f.ShowDialog();
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "عملیات انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Parent FROM tbl_Transaction WHERE Parent_Code='" + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() != "5" && dt.Rows[0].ItemArray[0].ToString() != "6")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این عملیات مختص فاکتور بوده و باید از همان طریق نسبت به حذف آن اقدام نمایید";
                    f.ShowDialog();
                }
                else
                {
                    string query2 = "DELETE FROM tbl_Pay_Recive_Info WHERE ID='" + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + "'";
                    frmMessage f = new frmMessage();
                    if (dgvProduct.CurrentRow.Cells["Bedehkar"].Value.ToString() != "")
                    {
                        query1 = "DELETE FROM tbl_Transaction WHERE Parent=5 AND Parent_Code='" + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + "'";
                        f.lblMessage.Text = "آیا از حذف دریافت نقدی به مبلغ " + dgvProduct.CurrentRow.Cells["Bedehkar"].Value.ToString() + " " + "ریال، اطمینان دارید؟";
                    }
                    else if (dgvProduct.CurrentRow.Cells["Bestankar"].Value.ToString() != "")
                    {
                        query1 = "DELETE FROM tbl_Transaction WHERE Parent=6 AND Parent_Code='" + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + "'";
                        f.lblMessage.Text = "آیا از حذف پرداخت نقدی به مبلغ " + dgvProduct.CurrentRow.Cells["Bestankar"].Value.ToString() + " " + "ریال، اطمینان دارید؟";
                    }
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            Fill_Data();
                        }
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "عملیات انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Parent FROM tbl_Transaction WHERE Parent_Code='" + dgvProduct.CurrentRow.Cells["ID"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() != "5" && dt.Rows[0].ItemArray[0].ToString() != "6")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این عملیات مختص فاکتور بوده و باید از همان طریق نسبت به مشاهده آن اقدام نمایید";
                    f.ShowDialog();
                }
                else
                {
                    if (dgvProduct.CurrentRow.Cells["Bedehkar"].Value.ToString() != "")
                    {
                        frmCash_Daryaft f = new frmCash_Daryaft();
                        f.Fill_Data(Convert.ToInt32(dgvProduct.CurrentRow.Cells["ID"].Value));
                        f.grpAccount.Enabled = false;
                        f.btnFinish.Enabled = false;
                        f.ShowDialog();
                    }
                    else if (dgvProduct.CurrentRow.Cells["Bestankar"].Value.ToString() != "")
                    {
                        frmCash_Pardakht f = new frmCash_Pardakht();
                        f.Fill_Data(Convert.ToInt32(dgvProduct.CurrentRow.Cells["ID"].Value));
                        f.grpAccount.Enabled = false;
                        f.btnFinish.Enabled = false;
                        f.ShowDialog();
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "عملیات انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Transaction.Date, tbl_Transaction.Parent_Code, tbl_Transaction.Bedehkar, tbl_Transaction.Bestankar, tbl_Transaction.Notice FROM tbl_Transaction INNER JOIN tbl_Account ON tbl_Transaction.Code = tbl_Account.Code WHERE tbl_Transaction.Code='" + Safe_Code + "' AND tbl_Transaction.Notice LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Transaction.Date DESC";
                clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
            }
            catch
            {
                Fill_Data();
            }
        }
    }
}
