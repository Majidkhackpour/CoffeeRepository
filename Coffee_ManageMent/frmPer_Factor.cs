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
    public partial class frmPer_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, Pattern_Code;
        int Product_Tax = 0;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                try
                {
                    if (dgvStore.CurrentCell.ColumnIndex == 1)
                    {
                        Get_Product();
                        Calculate_TotalRow();
                        Calculate_All_Entity();
                    }
                    if (dgvStore.CurrentCell.ColumnIndex == 3 || dgvStore.CurrentCell.ColumnIndex == 6 || dgvStore.CurrentCell.ColumnIndex == 5)
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
                int P_ID = Convert.ToInt32(dgvStore.CurrentRow.Cells["Code"].Value);
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Price_List.Sell_Price, tbl_Product.Tax_Price, tbl_Product.Complication_Price FROM tbl_Product INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Price_List ON tbl_Product.P_Code = tbl_Price_List.P_Code WHERE tbl_Product.P_Code='" + P_ID + "' AND tbl_Price_List.Pattern_Code='" + Pattern_Code + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore["P_Name", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[0].ToString();
                dgvStore["Unit_Name", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[1].ToString();
                Product_Tax = Convert.ToInt32(dt.Rows[0].ItemArray[3]) + Convert.ToInt32(dt.Rows[0].ItemArray[4]);
                dgvStore["Buy_Price", dgvStore.CurrentRow.Index].Value = (Convert.ToInt32(dt.Rows[0].ItemArray[2]) + Product_Tax).ToString();
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
                    f.lblMessage.Text = "از این کالا استفاده شده است. برای تغییر مقدار به ستون مورد نظر مراجعه نمایید";
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
                txtCost.Text = T.ToString();
            }
            catch
            {
                txtCost.Text = "0";
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
        public void Calculate_TotalRow()
        {
            try
            {
                dgvStore.EndEdit();
                float Count = float.Parse(dgvStore["Entity", dgvStore.CurrentRow.Index].Value.ToString());
                int Price = Convert.ToInt32(dgvStore["Buy_Price", dgvStore.CurrentRow.Index].Value);
                int Total = Convert.ToInt32(Count * Price);
                dgvStore["Cost", dgvStore.CurrentRow.Index].Value = Total;
                Calculate_All();
            }
            catch
            {
                dgvStore["Cost", dgvStore.CurrentRow.Index].Value = "0";
            }
        }
        public void Form_Load()
        {
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string query2 = "SELECT MAX (ID) FROM tbl_Header_Per_Factor";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "1");
            txtAdded_Percent.Text = txtCode.Text = "";
            txtDescount_Percent.Text = txtName.Text = "";
            txtNotice.Text = "";
            txtTotal.Text = txtEntity.Text = txtDiscount_Price.Text = "0";
            txtCost.Text = txtAdded_Price.Text = "0";
            Fill_Store();
            Fill_Price_Pattern();
        }
        private void Calculate_Cost()
        {
            try
            {
                txtTotal.Text = ((Convert.ToInt32(txtCost.Text) + Convert.ToInt32(txtAdded_Price.Text)) - Convert.ToInt32(txtDiscount_Price.Text)).ToString();
            }
            catch
            {
                txtTotal.Text = "0";
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
        private void Fill_Price_Pattern()
        {
            try
            {
                cmbPrice_Pattern.Items.Clear();
                string Query = "SELECT Description FROM tbl_Price_Pattern WHERE Type=1 AND State=0";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbPrice_Pattern, s_obj);
                cmbPrice_Pattern.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Sell_Pattern FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbPrice_Pattern.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Code, Sum, Discount, Added, Total, Notice FROM tbl_Header_Per_Factor WHERE ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            txtCode.Text = dt.Rows[0].ItemArray[1].ToString();
            txtCost.Text = dt.Rows[0].ItemArray[2].ToString();
            txtDiscount_Price.Text = dt.Rows[0].ItemArray[3].ToString();
            txtAdded_Price.Text = dt.Rows[0].ItemArray[4].ToString();
            txtTotal.Text = dt.Rows[0].ItemArray[5].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[6].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_Per_Factor.P_Code, tbl_Product.P_Show_Name, tbl_Body_Per_Factor.Entity, tbl_Unit.Unit_Name, tbl_Body_Per_Factor.Price, tbl_Body_Per_Factor.Total FROM tbl_Body_Per_Factor INNER JOIN tbl_Product ON tbl_Body_Per_Factor.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code WHERE tbl_Body_Per_Factor.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
            Calculate_All();
            Calculate_All_Entity();
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Per_Factor WHERE ID = '" + ID + "'";
                if (clsFunction.Execute(dataconnection, query1) == true)
                {
                }
            }
            catch
            {
            }
        }
        public frmPer_Factor()
        {
            InitializeComponent();
        }

        private void frmPer_Factor_Load(object sender, EventArgs e)
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Customer ON tbl_Account.Code = tbl_Customer.Code WHERE tbl_Customer.Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName.Text = "";
            }
        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllCustomer f = new frmAllCustomer();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
                txtCode.Text = "";
            }
        }

        private void cmbPrice_Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Price_Pattern WHERE Description LIKE N'" + cmbPrice_Pattern.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Pattern_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.RemoveAt(dgvStore.CurrentRow.Index);
                Calculate_All();
                Calculate_All_Entity();
                Calculate_TotalRow();
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
                Calculate_TotalRow();
            }
            catch
            {
            }
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

        private void txtDescount_Percent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDescount_Percent.Text) > 100)
                    txtDescount_Percent.Text = "100";
                txtDiscount_Price.Text = ((Convert.ToInt32(txtCost.Text) * Convert.ToInt32(txtDescount_Percent.Text)) / 100).ToString();
            }
            catch
            {
                txtDiscount_Price.Text = "0";
            }
        }

        private void txtAdded_Percent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtAdded_Percent.Text) > 100)
                    txtAdded_Percent.Text = "100";
                txtAdded_Price.Text = ((Convert.ToInt32(txtCost.Text) * Convert.ToInt32(txtAdded_Percent.Text)) / 100).ToString();
            }
            catch
            {
                txtAdded_Price.Text = "0";
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
        }

        private void txtDiscount_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtDiscount_Price);
            Calculate_Cost();
        }

        private void txtAdded_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtAdded_Price);
            Calculate_Cost();
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string query1, query2;
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
                    if (op == "Add")
                    {
                        query1 = "INSERT INTO tbl_Header_Per_Factor (ID, Date, Code, Store, Sum, Discount, Added, Total, Notice, UserName) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + txtDate.Text + "','" + txtCode.Text + "','" + Store_Code + "','" + Convert.ToInt64(txtCost.Text) + "','" + Convert.ToInt32(txtDiscount_Price.Text) + "','" + Convert.ToInt32(txtAdded_Price.Text) + "','" + Convert.ToInt64(txtTotal.Text) + "',N'" + txtNotice.Text + "','" + clsFunction.User_Real_Name + "')";
                        if (clsFunction.Execute(dataconnection, query1) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query2 = "INSERT INTO tbl_Body_Per_Factor (ID, P_Code, Entity, Price, Total) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
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
                        Delete_Data(Convert.ToInt32(txtCode.Text));
                        query1 = "UPDATE tbl_Header_Per_Factor SET Date = '" + txtDate.Text + "', Code = '" + txtCode.Text + "', Store = '" + Store_Code + "', Sum = '" + Convert.ToInt64(txtCost.Text) + "', Discount = '" + Convert.ToInt32(txtDiscount_Price.Text) + "', Added = '" + Convert.ToInt32(txtAdded_Price.Text) + "', Total = '" + Convert.ToInt64(txtTotal.Text) + "', Notice = N'" + txtNotice.Text + "' WHERE ID = '" + Convert.ToInt32(txtID.Text) + "'"; ;
                        if (clsFunction.Execute(dataconnection, query1) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query2 = "INSERT INTO tbl_Body_Per_Factor (ID, P_Code, Entity, Price, Total) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
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

        private void txtDescount_Percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtAdded_Percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
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

        private void txtDiscount_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtAdded_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void cmbStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void btnSearchAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void cmbPrice_Pattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtDescount_Percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtDiscount_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtAdded_Percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtAdded_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }
    }
}
