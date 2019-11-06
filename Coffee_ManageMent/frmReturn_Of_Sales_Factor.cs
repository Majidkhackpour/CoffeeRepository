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
    public partial class frmReturn_Of_Sales_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, Pattern_Code, Product_op, Safe_Code;
        int Product_Code, Product_Price, Product_Tax, chk_Product_Code, Doc_Number;
        Boolean Check_Factor = false;
        int Sum_P_Total = 0;
        Int64 Ware_Rec_ID;
        public void Form_Load()
        {
            txtProduct_Code.Text = txtProduct_Name.Text = txtProduct_Notice.Text = "";
            txtProduct_Cost.Text = txtProduct_Discount.Text = txtProduct_Price.Text = txtProduct_Total.Text = "0";
            txtProduct_Entity.Text = "1";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string query2 = "SELECT MAX (ID) FROM tbl_Header_Return_Of_Sales_Factor";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "1");
            Fill_Store();
            Fill_Price_Pattern();
            Fill_Safe();
            timer2_Tick(null, null);
            txtCode.Text = txtName.Text = "";
            ToolTip tt = new ToolTip();
            Get_Other_Customer_From_Setting();
            txtCash.Text = "0";
            txtAdded_Percent.Text = txtDescount_Percent.Text = "";
            txtAdded_Price.Text = txtDiscount_Price.Text = "0";
            txtEntity.Text = txtCost.Text = txtTotal.Text = "0";
            Product_op = "Add";
            Fill_Product_In_dgv();
        }
        private bool Check_Product_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT P_Code FROM tbl_Body_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "' AND P_Code='" + Product_Code + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        chk_Product_Code = (int)dr["P_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (chk_Product_Code == Product_Code)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void Calculate_Factor_Cost()
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
        private void Get_Max_WareHouse_Reciept_ID()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (ID) FROM tbl_Header_TurnReceipt", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Ware_Rec_ID = Convert.ToInt64(dt.Rows[0].ItemArray[0]) + 1;
            }
            catch
            {
                Ware_Rec_ID = 1;
            }
        }
        private void Fill_Product_In_dgv()
        {
            try
            {
                Product_op = "Add";
                string Query = "SELECT tbl_Body_Return_Of_Sales_Factor.P_Code, tbl_Product.P_Show_Name, tbl_Body_Return_Of_Sales_Factor.Entity, tbl_Unit.Unit_Name, tbl_Body_Return_Of_Sales_Factor.P_Price, tbl_Body_Return_Of_Sales_Factor.Total, tbl_Body_Return_Of_Sales_Factor.Discount, tbl_Body_Return_Of_Sales_Factor.Notice FROM tbl_Body_Return_Of_Sales_Factor INNER JOIN tbl_Product ON tbl_Body_Return_Of_Sales_Factor.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code WHERE tbl_Body_Return_Of_Sales_Factor.ID='" + Convert.ToInt64(txtID.Text) + "'";
                SqlDataAdapter da = new SqlDataAdapter(Query, dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore.DataSource = dt;
                Calculate_Sum_And_Discount();
                txtProduct_Code.Text = txtProduct_Name.Text = txtProduct_Notice.Text = "";
                txtProduct_Cost.Text = txtProduct_Discount.Text = txtProduct_Price.Text = txtProduct_Total.Text = "0";
                txtProduct_Entity.Text = "1";
            }
            catch
            {
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
        private void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_TurnReceipt WHERE ID='" + Ware_Rec_ID + "'";
                string query3 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=3 AND Parent_Code='" + ID + "'";
                string query4 = "DELETE FROM tbl_Transaction WHERE Parent=3 AND Parent_Code='" + ID.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                {
                }
            }
            catch
            {
            }
        }
        private void Calculate_Sum_And_Discount()
        {
            try
            {
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT SUM(Cost) FROM tbl_Body_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "'", dataconnection);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                Sum_P_Total = Convert.ToInt32(dt3.Rows[0].ItemArray[0]);
            }
            catch
            {
                Sum_P_Total = 0;
            }
            txtCost.Text = (Sum_P_Total).ToString();
        }
        private void Get_Max_Doc_Number()
        {
            try
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Number FROM tbl_Transaction WHERE Date='" + txtDate.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
                catch
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Doc_Number) FROM tbl_Transaction", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;
                }
            }
            catch
            {
                Doc_Number = 1;
            }
        }
        public void FillData(int ID)
        {
            timer2.Stop();
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Time, C_Code, Cost, Discount, Added_Value, Total, Cash, Doc_Code, Notice FROM tbl_Header_Return_Of_Sales_Factor WHERE ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            lblTime.Text = dt.Rows[0].ItemArray[1].ToString();
            txtCode.Text = dt.Rows[0].ItemArray[2].ToString();
            txtCost.Text = dt.Rows[0].ItemArray[3].ToString();
            txtDiscount_Price.Text = dt.Rows[0].ItemArray[4].ToString();
            txtAdded_Price.Text = dt.Rows[0].ItemArray[5].ToString();
            txtTotal.Text = dt.Rows[0].ItemArray[6].ToString();
            txtCash.Text = dt.Rows[0].ItemArray[7].ToString();
            Ware_Rec_ID = Convert.ToInt32(dt.Rows[0].ItemArray[8]);
            txtNotice.Text = dt.Rows[0].ItemArray[9].ToString();
            Fill_Product_In_dgv();
        }
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
        private void Ins_Product_In_Body()
        {
            if (clsFunction.Error_Provider(txtProduct_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Entity, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Discount, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Total, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (Product_op == "Add")
                {
                    if (Check_Product_Code() == true)
                    {
                        string query3 = "UPDATE tbl_Body_Return_Of_Sales_Factor SET Entity = Entity+'" + float.Parse(txtProduct_Entity.Text) + "', Cost = Cost+'" + Convert.ToInt64(txtProduct_Price.Text) + "', Total = Total+'" + Convert.ToInt64(txtProduct_Total.Text) + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "' AND P_Code = '" + Product_Code + "'";
                        if (clsFunction.Execute(dataconnection, query3) == true)
                        {
                            Fill_Product_In_dgv();
                        }
                    }
                    else
                    {
                        if (Check_Factor == false)
                        {
                            string query = "INSERT INTO tbl_Header_Return_Of_Sales_Factor (ID) VALUES ('" + Convert.ToInt64(txtID.Text) + "')";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                            }
                        }
                        string query2 = "INSERT INTO tbl_Body_Return_Of_Sales_Factor (ID, P_Code, Entity, P_Price, Cost, Discount, Total, Notice) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Product_Code + "','" + float.Parse(txtProduct_Entity.Text) + "','" + Convert.ToInt32(txtProduct_Price.Text) + "','" + Convert.ToInt64(txtProduct_Cost.Text) + "','" + Convert.ToInt32(txtProduct_Discount.Text) + "','" + Convert.ToInt64(txtProduct_Total.Text) + "',N'" + txtProduct_Notice.Text + "')";
                        if (clsFunction.Execute(dataconnection, query2) == true)
                        {
                        }
                        Check_Factor = true;
                        Fill_Product_In_dgv();
                    }
                }
                else if (Product_op == "Edit")
                {
                    string query3 = "UPDATE tbl_Body_Return_Of_Sales_Factor SET Entity = '" + float.Parse(txtProduct_Entity.Text) + "', P_Price='" + Convert.ToInt32(txtProduct_Price.Text) + "', Cost = '" + Convert.ToInt64(txtProduct_Price.Text) + "', Discount='" + Convert.ToInt32(txtProduct_Discount.Text) + "', Total = '" + Convert.ToInt64(txtProduct_Total.Text) + "', Notice=N'" + txtProduct_Notice.Text + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "' AND P_Code = '" + Product_Code + "'";
                    if (clsFunction.Execute(dataconnection, query3) == true)
                    {
                        Fill_Product_In_dgv();
                    }
                }
                txtProduct_Code.Focus();
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
        private void Get_Other_Customer_From_Setting()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Other_Customer_Default FROM tbl_Setting_Sales_Factor WHERE ID=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (Convert.ToBoolean(dt.Rows[0].ItemArray[0]) == true)
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description='" + "متفرقه" + "'", dataconnection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    txtCode.Text = dt2.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    txtCode.Text = "";
                }
            }
            catch
            {
                txtCode.Text = "";
            }
        }
        private void Calculate_Product_Cost()
        {
            try
            {
                txtProduct_Cost.Text = (Convert.ToInt32(txtProduct_Entity.Text) * Convert.ToInt32(txtProduct_Price.Text)).ToString();
                txtProduct_Total.Text = (Convert.ToInt32(txtProduct_Cost.Text) - Convert.ToInt32(txtProduct_Discount.Text)).ToString();
            }
            catch
            {
                txtProduct_Discount.Text = "0";
                txtProduct_Cost.Text = "0";
                txtProduct_Total.Text = "0";
            }
        }
        public frmReturn_Of_Sales_Factor()
        {
            InitializeComponent();
        }

        private void frmReturn_Of_Sales_Factor_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description, tbl_Customer.Address FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code WHERE tbl_Customer.Code='" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
                lblAddress.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                txtName.Text = lblAddress.Text = "";
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

        private void txtProduct_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Show_Name FROM tbl_Product WHERE P_Code='" + txtProduct_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtProduct_Name.Text = dt.Rows[0].ItemArray[0].ToString();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT P_Code FROM tbl_Product WHERE P_Show_Name LIKE N'" + txtProduct_Name.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                Product_Code = Convert.ToInt32(dt2.Rows[0].ItemArray[0]);
                try
                {
                    SqlDataAdapter da20 = new SqlDataAdapter("SELECT tbl_Price_List.Sell_Price FROM tbl_Product INNER JOIN tbl_Price_List ON tbl_Product.P_Code = tbl_Price_List.P_Code WHERE tbl_Price_List.P_Code='" + Product_Code + "' AND tbl_Price_List.Pattern_Code='" + Pattern_Code + "'", dataconnection);
                    DataTable dt20 = new DataTable();
                    da20.Fill(dt20);
                    Product_Price = Convert.ToInt32(dt20.Rows[0].ItemArray[0]);
                }
                catch
                {
                    Product_Price = 0;
                }
                try
                {
                    SqlDataAdapter da3 = new SqlDataAdapter("SELECT Tax_Price FROM tbl_Product WHERE P_Code='" + Product_Code + "'", dataconnection);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    Product_Tax = Convert.ToInt32(dt3.Rows[0].ItemArray[0]);
                }
                catch
                {
                    Product_Tax = 0;
                }
                try
                {
                    SqlDataAdapter da4 = new SqlDataAdapter("SELECT Complication_Price FROM tbl_Product WHERE P_Code='" + Product_Code + "'", dataconnection);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    Product_Tax += Convert.ToInt32(dt4.Rows[0].ItemArray[0]);
                }
                catch
                {
                    Product_Tax += 0;
                }
                txtProduct_Price.Text = (Convert.ToInt32(Product_Price + Product_Tax)).ToString();
                Calculate_Product_Cost();
            }
            catch
            {
                txtProduct_Name.Text = "";
                txtProduct_Price.Text = "0";
            }
        }

        private void btnSearch_Product_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllProduct f = new frmAllProduct();
                f.Fill_All_Product();
                f.op = "All";
                f.ShowDialog();
                txtProduct_Code.Text = f.Product_Code;
                Product_Code = Convert.ToInt32(txtProduct_Code.Text);
                txtProduct_Entity.Focus();
            }
            catch
            {
                txtProduct_Code.Text = "";
            }
        }

        private void txtProduct_Entity_TextChanged(object sender, EventArgs e)
        {
            Calculate_Product_Cost();
        }

        private void txtProduct_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtProduct_Price);
                Calculate_Product_Cost();
            }
            catch
            {
                txtProduct_Price.Text = "0";
            }
        }

        private void txtProduct_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtProduct_Discount);
                Calculate_Product_Cost();
            }
            catch
            {
                txtProduct_Discount.Text = "0";
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

        private void txtProduct_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtProduct_Name.Text != "")
                {
                    Ins_Product_In_Body();
                }
                else
                {
                    frmAllProduct f = new frmAllProduct();
                    f.op = "All";
                    f.Fill_All_Product();
                    f.txtSearch.Text = txtProduct_Code.Text;
                    f.ShowDialog();
                    txtProduct_Code.Text = null;
                    txtProduct_Code.Text = f.Product_Code;
                }
            }
        }

        private void txtProduct_Entity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                Ins_Product_In_Body();
        }

        private void txtProduct_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                Ins_Product_In_Body();
        }

        private void txtProduct_Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                Ins_Product_In_Body();
        }

        private void txtProduct_Notice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                Ins_Product_In_Body();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Product_op = "Edit";
                txtProduct_Code.Text = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Entity, P_Price, Cost, Discount, Total, Notice FROM tbl_Body_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "' AND P_Code='" + Convert.ToInt32(txtProduct_Code.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtProduct_Entity.Text = dt.Rows[0].ItemArray[0].ToString();
                txtProduct_Price.Text = dt.Rows[0].ItemArray[1].ToString();
                txtProduct_Cost.Text = dt.Rows[0].ItemArray[2].ToString();
                txtProduct_Discount.Text = dt.Rows[0].ItemArray[3].ToString();
                txtProduct_Total.Text = dt.Rows[0].ItemArray[4].ToString();
                txtProduct_Notice.Text = dt.Rows[0].ItemArray[5].ToString();
            }
            catch
            {
                txtProduct_Code.Text = txtProduct_Name.Text = txtProduct_Notice.Text = "";
                txtProduct_Cost.Text = txtProduct_Discount.Text = txtProduct_Price.Text = txtProduct_Total.Text = "0";
                txtProduct_Entity.Text = "1";
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "' AND P_Code='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Code"].Value) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["P_Name"].Value.ToString() + " " + "از فاکتور، اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        Fill_Product_In_dgv();
                }
            }
            catch
            {
            }
        }

        private void frmReturn_Of_Sales_Factor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvStore.Rows.Count == 0)
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "تغییرات ذخیره نخواهد شد";
                f.flag = 0;
                f.ShowDialog();
                string query1 = "DELETE FROM tbl_Header_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query1) == true)
                {
                }
            }
        }

        private void mnuDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف کلیه کالاها از فاکتور، اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        Fill_Product_In_dgv();
                }
            }
            catch
            {
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (dgvStore.Rows.Count == 0)
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "تغییرات ذخیره نخواهد شد";
                f.flag = 0;
                f.ShowDialog();
                string query = "DELETE FROM tbl_Header_Return_Of_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                }
            }
            else
            {
                string query1, query2, query3, query4, query5, query6, query7, query8, query9, query10, query11;
                if (op == "Add")
                {
                    Get_Max_WareHouse_Reciept_ID();
                    query1 = "UPDATE tbl_Header_Return_Of_Sales_Factor SET Date = '" + txtDate.Text + "', Time = '" + lblTime.Text + "', Store = '" + Store_Code + "', C_Code = '" + txtCode.Text + "', Cost = '" + Convert.ToInt64(txtCost.Text) + "', Discount = '" + Convert.ToInt32(txtDiscount_Price.Text) + "', Added_Value = '" + Convert.ToInt32(txtAdded_Price.Text) + "', Total = '" + Convert.ToInt64(txtTotal.Text) + "', Doc_Code = '" + Ware_Rec_ID + "', Notice = N'" + txtNotice.Text + "',  UserName =N'" + clsFunction.User_Real_Name + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "'";
                    query2 = "INSERT INTO tbl_Header_TurnReceipt (ID, Code, Date, Sum, Notice, Type, Store, Validation) VALUES ('" + Ware_Rec_ID + "','" + txtCode.Text + "','" + txtDate.Text + "','" + Convert.ToInt64(txtTotal.Text) + "','" + "فاکتور برگشت از فروش به شماره " + txtID.Text + "',3,'" + Store_Code + "','" + "خیر" + "')";
                    if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true)
                    {
                        for (int i = 0; i < dgvStore.Rows.Count; i++)
                        {
                            try
                            {
                                query3 = "INSERT INTO tbl_Body_TurnReceipt (ID, P_Code, Entity, Notice, E_Price, Total) VALUES ('" + Ware_Rec_ID + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + dgvStore.Rows[i].Cells["Notice"].Value.ToString() + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                query4 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtName.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "فاکتور برگشت از فروش به شماره " + txtID.Text + "',3,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                        Get_Max_Doc_Number();
                        query5 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtCost.Text) + "',N'" + "فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60201" + "','" + 3 + "','" + txtID.Text + "')";
                        query6 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + Convert.ToInt64(txtTotal.Text) + "',N'" + "فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "','" + 3 + "','" + txtID.Text + "')";
                        if (clsFunction.Execute(dataconnection, query5) == true && clsFunction.Execute(dataconnection, query6) == true)
                        {
                        }
                        if (Convert.ToInt32(txtAdded_Price.Text) != 0)
                        {
                            query7 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtAdded_Price.Text) + "',N'" + "هزینه فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60301" + "','" + 3 + "','" + txtID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query7) == true)
                            {
                            }
                        }
                        if (Convert.ToInt32(txtDiscount_Price.Text) != 0)
                        {
                            query8 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtDiscount_Price.Text) + "',N'" + "تخفیف فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60202" + "','" + 3 + "','" + txtID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query8) == true)
                            {
                            }
                        }
                        if (Convert.ToInt32(txtCash.Text) != 0)
                        {
                            query9 = "UPDATE tbl_Header_Return_Of_Sales_Factor SET Cash = '" + Convert.ToInt64(txtCash.Text) + "', Safe_Code = '" + Safe_Code + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "'";
                            query10 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + Convert.ToInt64(txtCash.Text) + "','" + "دریافت وجه نقد بابت فاکتور برگشت از فروش شماره " + txtID.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "',3,'" + txtID.Text + "')";
                            query11 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Safe_Code + "','" + Convert.ToInt64(txtCash.Text) + "','" + "پرداخت وجه نقد بابت فاکتور برگشت از فروش شماره " + txtID.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10102" + "',3,'" + txtID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query9) == true && clsFunction.Execute(dataconnection, query10) == true && clsFunction.Execute(dataconnection, query11) == true)
                            {
                            }
                        }
                        this.Close();
                    }
                }
                else if (op == "Edit")
                {
                    Delete_Data(Convert.ToInt32(txtID.Text));
                    query1 = "UPDATE tbl_Header_Return_Of_Sales_Factor SET Date = '" + txtDate.Text + "', Time = '" + lblTime.Text + "', Store = '" + Store_Code + "', C_Code = '" + txtCode.Text + "', Cost = '" + Convert.ToInt64(txtCost.Text) + "', Discount = '" + Convert.ToInt32(txtDiscount_Price.Text) + "', Added_Value = '" + Convert.ToInt32(txtAdded_Price.Text) + "', Total = '" + Convert.ToInt64(txtTotal.Text) + "', Doc_Code = '" + Ware_Rec_ID + "', Notice = N'" + txtNotice.Text + "',  UserName =N'" + clsFunction.User_Real_Name + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "'";
                    query2 = "UPDATE tbl_Header_TurnReceipt SET Code = '" + txtCode.Text + "', Date = '" + txtDate.Text + "', Sum = '" + Convert.ToInt64(txtTotal.Text) + "', Notice = N'" + "فاکتور برگشت از فروش به شماره " + txtID.Text + "', Store='" + Store_Code + "' WHERE ID = '" + Ware_Rec_ID + "'";
                    if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true)
                    {
                        for (int i = 0; i < dgvStore.Rows.Count; i++)
                        {
                            try
                            {
                                query3 = "INSERT INTO tbl_Body_TurnReceipt (ID, P_Code, Entity, Notice, E_Price, Total) VALUES ('" + Ware_Rec_ID + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + dgvStore.Rows[i].Cells["Notice"].Value.ToString() + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                query4 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtName.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "فاکتور برگشت از فروش به شماره " + txtID.Text + "',3,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                        Get_Max_Doc_Number();
                        query5 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtCost.Text) + "',N'" + "فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60201" + "','" + 3 + "','" + txtID.Text + "')";
                        query6 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + Convert.ToInt64(txtTotal.Text) + "',N'" + "فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "','" + 3 + "','" + txtID.Text + "')";
                        if (clsFunction.Execute(dataconnection, query5) == true && clsFunction.Execute(dataconnection, query6) == true)
                        {
                        }
                        if (Convert.ToInt32(txtAdded_Price.Text) != 0)
                        {
                            query7 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtAdded_Price.Text) + "',N'" + "هزینه فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60301" + "','" + 3 + "','" + txtID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query7) == true)
                            {
                            }
                        }
                        if (Convert.ToInt32(txtDiscount_Price.Text) != 0)
                        {
                            query8 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtDiscount_Price.Text) + "',N'" + "تخفیف فاکتور برگشت از فروش به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60202" + "','" + 3 + "','" + txtID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query8) == true)
                            {
                            }
                        }
                        if (Convert.ToInt32(txtCash.Text) != 0)
                        {
                            query9 = "UPDATE tbl_Header_Return_Of_Sales_Factor SET Cash = '" + Convert.ToInt64(txtCash.Text) + "', Safe_Code = '" + Safe_Code + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "'";
                            query10 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + Convert.ToInt64(txtCash.Text) + "','" + "دریافت وجه نقد بابت فاکتور برگشت از فروش شماره " + txtID.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "',3,'" + txtID.Text + "')";
                            query11 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Safe_Code + "','" + Convert.ToInt64(txtCash.Text) + "','" + "پرداخت وجه نقد بابت فاکتور برگشت از فروش شماره " + txtID.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10102" + "',3,'" + txtID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query9) == true && clsFunction.Execute(dataconnection, query10) == true && clsFunction.Execute(dataconnection, query11) == true)
                            {
                            }
                        }
                        this.Close();
                    }
                }
            }
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
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            Calculate_Factor_Cost();
        }

        private void txtDiscount_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtDiscount_Price);
                Calculate_Factor_Cost();
            }
            catch
            {
                txtDiscount_Price.Text = "0";
            }
        }

        private void txtAdded_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtAdded_Price);
                Calculate_Factor_Cost();
            }
            catch
            {
                txtAdded_Price.Text = "0";
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtCash);
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
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

        private void txtDescount_Percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDiscount_Price.Focus();
        }

        private void txtDiscount_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtAdded_Percent.Focus();
        }

        private void txtAdded_Percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtAdded_Price.Focus();
        }

        private void txtAdded_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCash.Focus();
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbSafe.Focus();
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

        private void txtProduct_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
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

        private void txtProduct_Entity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtProduct_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
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

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }
    }
}
