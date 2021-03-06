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
    public partial class frmTurn_Receipt : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                try
                {
                    if (dgvStore.CurrentCell.ColumnIndex == 0)
                    {
                        Get_Product();
                        Calculate_TotalRow();
                        Calculate_All_Entity();
                    }
                    if (dgvStore.CurrentCell.ColumnIndex == 2 || dgvStore.CurrentCell.ColumnIndex == 4 || dgvStore.CurrentCell.ColumnIndex == 5)
                    {
                        Calculate_TotalRow();
                        Calculate_All_Entity();
                    }
                    SendKeys.Send("{tab}");
                    return true;
                }
                catch
                {
                }
            }
            if (keyData == Keys.Delete)
            {
                mnuDelete_Click(null, null);
                Calculate_All();
                Calculate_All_Entity();
            }
            if (this.ActiveControl.GetType() != typeof(DevComponents.DotNetBar.Controls.ComboBoxEx))
            {
                if (keyData == Keys.F12)
                {
                    try
                    {
                        frmProduct f = new frmProduct();
                        f.op = "Add";
                        f.Flag = 0;
                        f.Form_Load();
                        f.ShowDialog();
                    }
                    catch
                    {
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Get_Product()
        {
            dgvStore.EndEdit();
            try
            {
                int P_ID = Convert.ToInt32(dgvStore.CurrentCell.Value);
                SqlDataAdapter da = new SqlDataAdapter("SELECT Sell_Price, P_Show_Name FROM tbl_Product WHERE P_Code='" + P_ID + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore["P_Name", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[1].ToString();
                dgvStore["Sell_Price", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[0].ToString();
                dgvStore["Entity", dgvStore.CurrentRow.Index].Value = "1";
                int Counter = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) == P_ID)
                    {
                        Counter++;
                    }
                }
                if (Counter > 1)
                {
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "از این کالا در رسید برگشت استفاده شده است. برای تغییر مقدار به ستون مورد نظر مراجعه نمایید";
                    f.flag = 0;
                    f.ShowDialog();
                    mnuDelete_Click(null, null);
                }
                return;
            }
            catch
            {
                try
                {
                    frmAllProduct f = new frmAllProduct();
                    f.op = "All";
                    f.Fill_All_Product();
                    f.txtSearch.Text = dgvStore["Code", dgvStore.CurrentRow.Index].Value.ToString();
                    f.ShowDialog();
                    dgvStore["Code", dgvStore.CurrentRow.Index].Value = null;
                    dgvStore["Code", dgvStore.CurrentRow.Index].Value = f.Product_Code;
                    Get_Product();
                }
                catch
                {
                }
            }
        }
        public void Calculate_TotalRow()
        {
            try
            {
                dgvStore.EndEdit();
                float Count = float.Parse(dgvStore["Entity", dgvStore.CurrentRow.Index].Value.ToString());
                int Price = Convert.ToInt32(dgvStore["Sell_Price", dgvStore.CurrentRow.Index].Value);
                int Total = Convert.ToInt32(Count * Price);
                dgvStore["Cost", dgvStore.CurrentRow.Index].Value = Total;
                Calculate_All();
            }
            catch
            {
                dgvStore["Cost", dgvStore.CurrentRow.Index].Value = "0";
            }
        }
        public void Calculate_All()
        {
            try
            {
                int T = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    object v = dgvStore["Cost", i].Value;
                    if (v != null)
                    {
                        T += Convert.ToInt32(v);
                    }
                }
                txtSum.Text = T.ToString();
            }
            catch
            {
                txtSum.Text = "0";
            }
        }
        public void Calculate_All_Entity()
        {
            try
            {
                float T = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    object v = dgvStore["Entity", i].Value;
                    if (v != null)
                    {
                        T += Convert.ToInt32(v);
                    }
                }
                txtEntity.Text = T.ToString();
            }
            catch
            {
                txtEntity.Text = "0";
            }
        }
        private void Fill_Store()
        {
            try
            {
                cmbStore.Items.Clear();
                string Query = "SELECT Shown_Name FROM tbl_Store";
                string s_obj = "Shown_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbStore, s_obj);
                cmbStore.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Store FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStore.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public void Form_Load()
        {
            Fill_Store();
            txtBill.Text = txtCode.Text = txtDelivery.Text = "";
            txtName.Text = txtNotice.Text = txtTranfer_Number.Text = "";
            txtEntity.Text = txtSum.Text = "0";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string query2 = "SELECT MAX (ID) FROM tbl_Header_TurnReceipt";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "1");
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Code, Date, Bill_Lad, Delivery, Notice, Transfer_No, Sum FROM tbl_Header_TurnReceipt WHERE ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[1].ToString();
            txtBill.Text = dt.Rows[0].ItemArray[2].ToString();
            txtDelivery.Text = dt.Rows[0].ItemArray[3].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[4].ToString();
            txtTranfer_Number.Text = dt.Rows[0].ItemArray[5].ToString();
            txtSum.Text = dt.Rows[0].ItemArray[6].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_TurnReceipt.P_Code, tbl_Product.P_Show_Name, tbl_Body_TurnReceipt.Entity, tbl_Body_TurnReceipt.Notice, tbl_Body_TurnReceipt.E_Price, tbl_Body_TurnReceipt.Total FROM tbl_Body_TurnReceipt INNER JOIN tbl_Product ON tbl_Body_TurnReceipt.P_Code = tbl_Product.P_Code WHERE tbl_Body_TurnReceipt.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
            Calculate_All_Entity();
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_TurnReceipt WHERE ID = '" + ID + "'";
                string query2 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=12 AND Parent_Code = '" + Convert.ToInt32(txtID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                {
                }
            }
            catch
            {
            }
        }
        public frmTurn_Receipt()
        {
            InitializeComponent();
        }

        private void frmTurn_Receipt_Load(object sender, EventArgs e)
        {
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.RemoveAt(dgvStore.CurrentRow.Index);
                Calculate_All();
                Calculate_All_Entity();
            }
            catch
            {
            }
        }

        private void mnuDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.Clear();
                Calculate_All();
                Calculate_All_Entity();
            }
            catch
            {
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string query1, query2, query3;
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                string SubString = txtCode.Text.Substring(0, 2);
                if (SubString != "30" && SubString != "40")
                {
                    clsFunction.Show_OtherError(txtName, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    errorProvider1.Clear();
                    DateTime d1 = Convert.ToDateTime(txtDate.Text);
                    DateTime d2 = Convert.ToDateTime(clsFunction.M2SH(DateTime.Now));
                    if (d1 > d2)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "تاریخ رسید برگشت نمی تواند از تاریخ روز بزرگتر باشد";
                        f.ShowDialog();
                    }
                    else
                    {
                        if (op == "Add")
                        {
                            query1 = "INSERT INTO tbl_Header_TurnReceipt (ID, Transfer_No, Code, Date, Bill_Lad, Delivery, Sum, Notice, Type, Store, Validation) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + txtTranfer_Number.Text + "','" + txtCode.Text + "','" + txtDate.Text + "','" + txtBill.Text + "',N'" + txtDelivery.Text + "','" + Convert.ToInt64(txtSum.Text) + "','" + txtNotice.Text + "',12,'" + Store_Code + "','" + "خیر" + "')";
                            if (clsFunction.Execute(dataconnection, query1) == true)
                            {
                                for (int i = 0; i < dgvStore.Rows.Count; i++)
                                {
                                    try
                                    {
                                        query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtName.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + txtNotice.Text + "',12,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                        query3 = "INSERT INTO tbl_Body_TurnReceipt (ID, P_Code, Entity, Notice, E_Price, Total) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + dgvStore.Rows[i].Cells["Notice"].Value.ToString() + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Sell_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                        if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query2) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                this.Close();
                            }
                        }
                        else if (op == "Edit")
                        {
                            Delete_Data(Convert.ToInt32(txtID.Text));
                            query1 = "UPDATE tbl_Header_TurnReceipt SET Transfer_No = '" + txtTranfer_Number.Text + "', Code = '" + txtCode.Text + "', Date = '" + txtDate.Text + "', Bill_Lad = '" + txtBill.Text + "', Delivery = N'" + txtDelivery.Text + "', Sum = '" + Convert.ToInt64(txtSum.Text) + "', Notice = N'" + txtNotice.Text + "', Store='" + Store_Code + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "'";
                            if (clsFunction.Execute(dataconnection, query1) == true)
                            {
                                for (int i = 0; i < dgvStore.Rows.Count; i++)
                                {
                                    try
                                    {
                                        query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtName.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + txtNotice.Text + "',12,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                        query3 = "INSERT INTO tbl_Body_TurnReceipt (ID, P_Code, Entity, Notice, E_Price, Total) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + dgvStore.Rows[i].Cells["Notice"].Value.ToString() + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Sell_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                        if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query2) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "Rael_And_Right_Acc";
                f.Fill_Real_And_Right_Account();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
                txtCode.Text = "";
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName.Text = "";
            }
        }

        private void dgvStore_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvStore_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["Code"].Value != null)
            {
                if (dgvStore.CurrentRow.Cells["Entity"].Value == null)
                {
                    Get_Product();
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDate.Focus();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDelivery.Focus();
        }

        private void txtDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBill.Focus();
        }

        private void txtBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTranfer_Number.Focus();
        }

        private void txtTranfer_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbStore.Focus();
        }

        private void cmbStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
            else if (e.KeyData == Keys.F12)
            {
                try
                {
                    frmStores f = new frmStores();
                    f.Form_Load();
                    f.op = "Add";
                    f.ShowDialog();
                    Fill_Store();
                }
                catch
                {
                }
            }
        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Store WHERE Shown_Name LIKE N'" + cmbStore.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Store_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void mnuTour_Click(object sender, EventArgs e)
        {
            try
            {
                frmLittle_Tour f = new frmLittle_Tour();
                f.Form_Load();
                f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["Code"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
