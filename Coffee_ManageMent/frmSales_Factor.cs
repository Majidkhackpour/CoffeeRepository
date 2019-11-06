using JntNum2Text;
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
    public partial class frmSales_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, Pattern_Code, Income_op, Product_op, Per_Factor;
        int Product_Type_Code, grp, Table_Peyk_Flag, Sett_Type, Table_Code, Peyk_Code, Discount, Sum_Factor, chk_Income_Code, Home;
        int Sum_Discount = 0, Sum_Total = 0, Sum_P_Total = 0, Sum_P_Discount = 0;
        int Total_Income_Edit = 0, Finantial_State, Old_Pnt, Exit_Temp = 0;
        int Product_Code, Product_Price, Product_Tax, chk_Product_Code, Serve_Type, Doc_Number;
        Int64 Ware_Rec_ID, Reminder_ID, Factor_Price_Edit;
        Boolean Check_Factor = false, per_Factor = false;
        string query1, query2, query3, query4, query5, query6, query8, query9, query10, query11, query12, query13, query14;
        ListBox lbx = new ListBox();
        ListBox lbx_Entity = new ListBox();
        ListBox lbx_Price = new ListBox();
        ListBox lbx_Total = new ListBox();
        public int Edit_Or_View_Temp;
        int Discount_Fest_Percent, Discount_Fest_Price;
        public void Form_Load()
        {
            TabControl.SelectedTab = superTabItem1;
            lblDigit.Text = "صفر ریال";
            lblShow_Factor_Cost.Text = "0";
            txtProduct_Code.Text = txtProduct_Name.Text = txtProduct_Notice.Text = "";
            txtProduct_Cost.Text = txtProduct_Discount.Text = txtProduct_Price.Text = txtProduct_Total.Text = "0";
            txtProduct_Entity.Text = "1";
            Fill_Product_Group();
            Fill_Product();
            expFactor_Info.Expanded = false;
            expCustomer.Expanded = false;
            ExpPay_Factor.Expanded = false;
            expServe.Expanded = false;
            expIncome.Expanded = false;
            expReport.Expanded = false;
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string query2 = "SELECT MAX (ID) FROM tbl_Header_Sales_Factor";
            clsFunction.lbl_NewCode(dataconnection, query2, lblFactor_Code, "1");
            Fill_Store();
            Fill_Price_Pattern();
            timer2_Tick(null, null);
            lblUserName.Text = "";
            txtCustomer_Code.Text = txtCustomer_Name.Text = txtSub_Code.Text = "";
            ToolTip tt = new ToolTip();
            tt.SetToolTip(picIns_Sub_Code, "درج کد اشتراک");
            tt.SetToolTip(picSub_Code, "اختصاص کد اشتراک");
            Get_Other_Customer_From_Setting();
            rbtnOut.Checked = true;
            txtName_Peyk_Table.Text = txtSett_Date.Text = "";
            btnSearchPeyk_Table.Enabled = false;
            Fill_Sett_Type();
            txtCash.Text = txtCredit_Card.Text = "0";
            txtAdded_Percent.Text = txtDiscoount_Percent.Text = "";
            txtAdded_Price.Text = txtDiscount_Price.Text = "0";
            txtInc_Code.Text = txtInc_Name.Text = "";
            txtInc_Discount.Text = txtInc_Price.Text = txtInc_Total.Text = "0";
            txtInc_Entity.Text = "1";
            lblSum_Discount.Text = lblSum_Factor_Price.Text = lblSum_Tax.Text = lblSum_Recive.Text = "0";
            lblTotal_Factor.Text = lblRemane.Text = "0";
            Fill_Income();
            Fill_Product_In_dgv();
        }
        public void FillData(int ID)
        {
            timer2.Stop();
            Form_Load();
            lblSum_Recive.Text = "0";
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Time, UserName, C_Code, Serve_Type, Sett_Date, Added_Price, Doc_Code, Factor_Discount, Point FROM tbl_Header_Sales_Factor WHERE ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblFactor_Code.Text = ID.ToString();
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            lblTime.Text = dt.Rows[0].ItemArray[1].ToString();
            lblUserName.Text = dt.Rows[0].ItemArray[2].ToString();
            txtCustomer_Code.Text = dt.Rows[0].ItemArray[3].ToString();
            if (Convert.ToInt32(dt.Rows[0].ItemArray[4]) == 1)
                rbtnOut.Checked = true;
            else if (Convert.ToInt32(dt.Rows[0].ItemArray[4]) == 2)
                rbtnPeyk.Checked = true;
            else if (Convert.ToInt32(dt.Rows[0].ItemArray[4]) == 3)
                rbtnSalon.Checked = true;
            txtSett_Date.Text = dt.Rows[0].ItemArray[5].ToString();
            txtAdded_Price.Text = dt.Rows[0].ItemArray[6].ToString();
            Ware_Rec_ID = Convert.ToInt32(dt.Rows[0].ItemArray[7]);
            txtDiscount_Price.Text = dt.Rows[0].ItemArray[8].ToString();
            Old_Pnt = Convert.ToInt32(dt.Rows[0].ItemArray[9]);
            Fill_Income();
            Fill_Product_In_dgv();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT SUM(Price) FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Pay_Type=1", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            txtCash.Text = dt2.Rows[0].ItemArray[0].ToString();
            if (txtCash.Text == "")
                txtCash.Text = "0";
            SqlDataAdapter da3 = new SqlDataAdapter("SELECT SUM(Price) FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Pay_Type=2", dataconnection);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            txtCredit_Card.Text = dt3.Rows[0].ItemArray[0].ToString();
            if (txtCredit_Card.Text == "")
                txtCredit_Card.Text = "0";
            SqlDataAdapter da30 = new SqlDataAdapter("SELECT SUM(Price) FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "'", dataconnection);
            DataTable dt30 = new DataTable();
            da30.Fill(dt30);
            lblSum_Recive.Text = dt30.Rows[0].ItemArray[0].ToString();
            if (lblSum_Recive.Text == "")
                lblSum_Recive.Text = "0";
            Factor_Price_Edit = Convert.ToInt64(lblShow_Factor_Cost.Text);
        }
        public void Per_Fill_Data(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Code, Sum, Discount, Added, Total FROM tbl_Header_Per_Factor WHERE ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            txtCustomer_Code.Text = dt.Rows[0].ItemArray[1].ToString();
            lblSum_Factor_Price.Text = dt.Rows[0].ItemArray[2].ToString();
            txtDiscount_Price.Text = dt.Rows[0].ItemArray[3].ToString();
            txtAdded_Price.Text = dt.Rows[0].ItemArray[4].ToString();
            lblShow_Factor_Cost.Text = dt.Rows[0].ItemArray[5].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_Per_Factor.P_Code, tbl_Product.P_Show_Name, tbl_Body_Per_Factor.Entity, tbl_Unit.Unit_Name, tbl_Body_Per_Factor.Price, tbl_Body_Per_Factor.Total FROM tbl_Body_Per_Factor INNER JOIN tbl_Product ON tbl_Body_Per_Factor.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code WHERE tbl_Body_Per_Factor.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
        }
        private void Insert_From_Per_Factor()
        {
            for (int i = 0; i < dgvStore.Rows.Count; i++)
            {
                try
                {
                    string query = "INSERT INTO tbl_Header_Sales_Factor (ID) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                    string query2 = "INSERT INTO tbl_Body_Sales_Factor (ID, P_Code, Entity, Price, Cost, Discount, Total, Notice) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "','" + 0 + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "',N'" + "" + "')";
                    if (clsFunction.Execute(dataconnection, query2) == true)
                    {
                    }
                }
                catch
                {
                }
            }
        }
        public void False_Enabling(int ID)
        {
            try
            {
                txtDate.Enabled = false;
                cmbStore.Enabled = false;
                cmbPrice_Pattern.Enabled = false;
                txtSub_Code.Enabled = false;
                picIns_Sub_Code.Enabled = false;
                picSub_Code.Enabled = false;
                txtCustomer_Code.Enabled = false;
                btnSearch_Customer_Code.Enabled = false;
                rbtnOut.Enabled = false;
                rbtnPeyk.Enabled = false;
                rbtnSalon.Enabled = false;
                btnSearchPeyk_Table.Enabled = false;
                txtSett_Date.Enabled = false;
                cmbSett_Type.Enabled = false;
                txtDiscoount_Percent.Enabled = false;
                txtDiscount_Price.Enabled = false;
                btnSearch_Cash.Enabled = false;
                txtAdded_Percent.Enabled = false;
                txtAdded_Price.Enabled = false;
                TabControl.Enabled = false;
                lbxProduct.Enabled = false;
                lbxProduct_Group.Enabled = false;
                dgvStore.Enabled = false;
                txtInc_Code.Enabled = false;
                btnSearch_Income.Enabled = false;
                txtInc_Discount.Enabled = false;
                txtInc_Entity.Enabled = false;
                txtInc_Price.Enabled = false;
                txtInc_Total.Enabled = false;
                btnIns_Income.Enabled = false;
                dgvIncome.Enabled = false;
                btnFinish.Enabled = false;
            }
            catch
            {
            }
        }
        private bool Check_Product_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT P_Code FROM tbl_Body_Sales_Factor WHERE ID='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND P_Code='" + Product_Code + "'", dataconnection);
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
        private void Get_Max_Reminder_ID()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (ID) FROM tbl_Reminder", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Reminder_ID = Convert.ToInt64(dt.Rows[0].ItemArray[0]) + 1;
            }
            catch
            {
                Reminder_ID = 1;
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
        private void Fill_Product_In_dgv()
        {
            try
            {
                Product_op = "Add";
                string Query = "SELECT tbl_Body_Sales_Factor.P_Code, tbl_Product.P_Show_Name, tbl_Body_Sales_Factor.Entity, tbl_Unit.Unit_Name, tbl_Body_Sales_Factor.Price, tbl_Body_Sales_Factor.Total, tbl_Body_Sales_Factor.Notice FROM tbl_Body_Sales_Factor INNER JOIN tbl_Product ON tbl_Body_Sales_Factor.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code WHERE tbl_Body_Sales_Factor.ID='" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                SqlDataAdapter da = new SqlDataAdapter(Query, dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore.DataSource = dt;
                Calculate_Sum_And_Discount();
            }
            catch
            {
            }
        }
        private void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_WareTransfer WHERE ID='" + Ware_Rec_ID + "'";
                string query2 = "DELETE FROM tbl_Serve_Info WHERE ID_Factor='" + ID + "'";
                string query3 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=1 AND Parent_Code='" + ID + "'";
                string query4 = "DELETE FROM tbl_Transaction WHERE Moeen=60202 AND Parent=1 AND Parent_Code='" + ID.ToString() + "'";
                string query5 = "DELETE FROM tbl_Transaction WHERE Moeen=60301 AND Parent=1 AND Parent_Code='" + ID.ToString() + "'";
                string query6 = "DELETE FROM tbl_Transaction WHERE Moeen=60101 AND Parent=1 AND Parent_Code='" + ID.ToString() + "'";
                string query7 = "DELETE FROM tbl_Transaction WHERE Moeen=10301 AND Bedehkar='" + Factor_Price_Edit + "' AND Parent=1 AND Parent_Code='" + ID.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query7) == true && clsFunction.Execute(dataconnection, query6) == true)
                {
                    try
                    {
                        if (clsFunction.Execute(dataconnection, query4) == true)
                        {
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (clsFunction.Execute(dataconnection, query5) == true)
                        {
                        }
                    }
                    catch
                    {
                    }
                }
                string query8 = "UPDATE tbl_Customer_Club SET Point=Point-'" + Old_Pnt + "' WHERE Code='" + txtCustomer_Code.Text + "'";
                string query9 = "DELETE FROM tbl_Tour_Cus_Club_Point WHERE Code='" + txtCustomer_Code.Text + "' AND P_Code='" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                try
                {
                    if (clsFunction.Execute(dataconnection, query8) == true && clsFunction.Execute(dataconnection, query9) == true)
                    {
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private bool Check_Income_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Income_ID FROM tbl_Tour_Of_Income WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Income_ID='" + Convert.ToInt32(txtInc_Code.Text) + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        chk_Income_Code = (int)dr["Income_ID"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (chk_Income_Code == Convert.ToInt32(txtInc_Code.Text))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void Fill_Income()
        {
            try
            {
                txtInc_Code.Text = txtInc_Name.Text = "";
                txtInc_Discount.Text = txtInc_Price.Text = txtInc_Total.Text = "0";
                txtInc_Entity.Text = "1";
                Income_op = "Add";
                string Query = "SELECT tbl_Tour_Of_Income.Income_ID, tbl_Income.Inc_Name, tbl_Tour_Of_Income.Entity, tbl_Tour_Of_Income.Price, tbl_Tour_Of_Income.Total FROM tbl_Tour_Of_Income INNER JOIN tbl_Income ON tbl_Tour_Of_Income.Income_ID = tbl_Income.ID WHERE tbl_Tour_Of_Income.ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                SqlDataAdapter da = new SqlDataAdapter(Query, dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvIncome.DataSource = dt;
                Calculate_Sum_And_Discount();
            }
            catch
            {
            }
        }
        private void Calculate_Sum_And_Discount()
        {
            try
            {
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT SUM(Discount), SUM(Price*Entity) FROM tbl_Tour_Of_Income WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                Sum_Discount = Convert.ToInt32(dt2.Rows[0].ItemArray[0]);
                Sum_Total = Convert.ToInt32(dt2.Rows[0].ItemArray[1]);
            }
            catch
            {
                Sum_Total = 0;
                Sum_Discount = 0;
            }
            try
            {
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT SUM(Cost), SUM(Discount) FROM tbl_Body_Sales_Factor WHERE ID='" + Convert.ToInt64(lblFactor_Code.Text) + "'", dataconnection);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                Sum_P_Total = Convert.ToInt32(dt3.Rows[0].ItemArray[0]);
                Sum_P_Discount = Convert.ToInt32(dt3.Rows[0].ItemArray[1]);
            }
            catch
            {
                Sum_P_Total = 0;
            }
            lblSum_Tax.Text = (Convert.ToInt32(lblSum_Tax.Text) + Product_Tax).ToString();
            lblSum_Discount.Text = (Convert.ToInt32(txtDiscount_Price.Text) + Sum_Discount + Sum_P_Discount).ToString();
            Discount = Convert.ToInt32(lblSum_Discount.Text);
            lblSum_Factor_Price.Text = (Sum_Total + Sum_P_Total).ToString();
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
        private void Fill_Product_Group()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Product_Type", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lbxProduct_Group.DataSource = dt;
                lbxProduct_Group.DisplayMember = "Description";
            }
            catch
            {
                lbxProduct_Group.Items.Clear();
            }
        }
        private void Fill_Product()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Show_Name FROM tbl_Product WHERE Product_Group='" + Product_Type_Code + "' AND Store='" + Store_Code + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lbxProduct.DataSource = dt;
                lbxProduct.DisplayMember = "P_Show_Name";
            }
            catch
            {
                lbxProduct.Items.Clear();
            }
        }
        private bool Check_Sub_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Sub_Code FROM tbl_Customer WHERE Sub_Code='" + Convert.ToInt32(txtSub_Code.Text) + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        grp = (int)dr["Sub_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (grp == Convert.ToInt32(txtSub_Code.Text))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
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
        private void Fill_Sett_Type()
        {
            try
            {
                cmbSett_Type.Items.Clear();
                string Query = "SELECT Type_Name FROM tbl_Pay_Factor_Type";
                string s_obj = "Type_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbSett_Type, s_obj);
                cmbSett_Type.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private void Calculate_Income()
        {
            try
            {
                txtInc_Total.Text = ((Convert.ToInt32(txtInc_Price.Text) * Convert.ToInt32(txtInc_Entity.Text)) - Convert.ToInt32(txtInc_Discount.Text)).ToString();
            }
            catch
            {
                txtInc_Total.Text = "0";
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
                    txtCustomer_Code.Text = dt2.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    txtCustomer_Code.Text = "";
                }
            }
            catch
            {
                txtCustomer_Code.Text = "";
            }
        }
        private void Get_Max_WareHouse_Reciept_ID()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (ID) FROM tbl_Header_WareTransfer", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Ware_Rec_ID = Convert.ToInt64(dt.Rows[0].ItemArray[0]) + 1;
            }
            catch
            {
                Ware_Rec_ID = 1;
            }
        }
        public frmSales_Factor()
        {
            InitializeComponent();
        }

        private void frmSales_Factor_Load(object sender, EventArgs e)
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
            if (Exit_Temp == 1 || Edit_Or_View_Temp == 1)
                this.Close();
            else
            {
                btnFinish_Click(null, null);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
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
            Fill_Product();
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

        private void lbxProduct_Group_Click(object sender, EventArgs e)
        {
            try
            {
                Product_Type_Code = lbxProduct_Group.SelectedIndex + 1;
                Fill_Product();
            }
            catch
            {
            }
        }

        private void btnSearch_Customer_Code_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllCustomer f = new frmAllCustomer();
                f.ShowDialog();
                txtCustomer_Code.Text = f.Acc_Code;
            }
            catch
            {
                txtCustomer_Code.Text = "";
            }
        }

        private void txtCustomer_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description, tbl_Customer.Sub_Code FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code WHERE tbl_Customer.Code='" + txtCustomer_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtCustomer_Name.Text = dt.Rows[0].ItemArray[0].ToString();
                txtSub_Code.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                txtCustomer_Name.Text = txtSub_Code.Text = "";
            }
        }

        private void txtSub_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description, tbl_Customer.Code FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code WHERE tbl_Customer.Sub_Code='" + Convert.ToInt32(txtSub_Code.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtCustomer_Name.Text = dt.Rows[0].ItemArray[0].ToString();
                txtCustomer_Code.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
            }
        }

        private void picSub_Code_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtCustomer_Code, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Sub_Code FROM tbl_Customer WHERE Code='" + txtCustomer_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() == "")
                {
                    try
                    {
                        SqlDataAdapter da2 = new SqlDataAdapter("SELECT MAX(Sub_Code) FROM tbl_Customer", dataconnection);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        txtSub_Code.Text = (Convert.ToInt32(dt2.Rows[0].ItemArray[0]) + 1).ToString();
                    }
                    catch
                    {
                        txtSub_Code.Text = "1000";
                    }
                }
                else
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "مشتری دارای اشتراک می باشد";
                    f.ShowDialog();
                }
            }
        }

        private void picIns_Sub_Code_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtCustomer_Code, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Sub_Code FROM tbl_Customer WHERE Code='" + txtCustomer_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() == "")
                {
                    if (Check_Sub_Code() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "اشتراک تکراری است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "UPDATE tbl_Customer SET Sub_Code = '" + Convert.ToInt32(txtSub_Code.Text) + "' WHERE Code = '" + txtCustomer_Code.Text + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = "کد اشتراک با موفقیت انتساب داده شد";
                            f.ShowDialog();
                        }
                    }
                }
                else
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "مشتری دارای اشتراک می باشد";
                    f.ShowDialog();
                }
            }
        }

        private void rbtnOut_CheckedChanged(object sender, EventArgs e)
        {
            Serve_Type = 1;
            txtName_Peyk_Table.Text = "";
            if (rbtnOut.Checked == true)
            {
                btnSearchPeyk_Table.Enabled = false;
                Table_Peyk_Flag = 3;
                Home = 0;
            }
            else
            {
                btnSearchPeyk_Table.Enabled = true;
                if (rbtnPeyk.Checked == true)
                    Table_Peyk_Flag = 1;
                else if (rbtnSalon.Checked == true)
                    Table_Peyk_Flag = 2;
                else
                    Table_Peyk_Flag = 3;
            }
        }

        private void rbtnPeyk_CheckedChanged(object sender, EventArgs e)
        {
            Serve_Type = 2;
            txtName_Peyk_Table.Text = "";
            if (rbtnOut.Checked == true)
            {
                btnSearchPeyk_Table.Enabled = false;
                Table_Peyk_Flag = 3;
                Home = 0;
            }
            else
            {
                btnSearchPeyk_Table.Enabled = true;
                if (rbtnPeyk.Checked == true)
                    Table_Peyk_Flag = 1;
                else if (rbtnSalon.Checked == true)
                    Table_Peyk_Flag = 2;
                else
                    Table_Peyk_Flag = 3;
            }
        }

        private void rbtnSalon_CheckedChanged(object sender, EventArgs e)
        {
            Serve_Type = 3;
            txtName_Peyk_Table.Text = "";
            if (rbtnOut.Checked == true)
            {
                btnSearchPeyk_Table.Enabled = false;
                Table_Peyk_Flag = 3;
                Home = 0;
            }
            else
            {
                btnSearchPeyk_Table.Enabled = true;
                if (rbtnPeyk.Checked == true)
                    Table_Peyk_Flag = 1;
                else if (rbtnSalon.Checked == true)
                    Table_Peyk_Flag = 2;
                else
                    Table_Peyk_Flag = 3;
            }
        }

        private void cmbSett_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Pay_Type FROM tbl_Pay_Factor_Type WHERE Type_Name LIKE N'" + cmbSett_Type.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Sett_Type = (int)dr["Pay_Type"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnSearchPeyk_Table_Click(object sender, EventArgs e)
        {
            try
            {
                if (Table_Peyk_Flag == 1)
                {
                    Table_Code = 0;
                    txtName_Peyk_Table.Text = "";
                    frmAllPerssonel f = new frmAllPerssonel();
                    f.Fill_Peyk();
                    f.op = "Peyk";
                    f.ShowDialog();
                    Peyk_Code = Convert.ToInt32(f.Acc_Code);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Perssonel ON tbl_Account.Code = tbl_Perssonel.Code WHERE tbl_Perssonel.ID='" + Peyk_Code.ToString() + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    txtName_Peyk_Table.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                else if (Table_Peyk_Flag == 2)
                {
                    Peyk_Code = 0;
                    txtName_Peyk_Table.Text = "";
                    frmAllTables f = new frmAllTables();
                    f.ShowDialog();
                    Table_Code = f.i_Table_Code;
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Table_Name FROM tbl_Tables WHERE Table_Code='" + Table_Code + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    txtName_Peyk_Table.Text = dt.Rows[0].ItemArray[0].ToString();
                }
            }
            catch
            {
            }
        }

        private void btnSearch_Cash_Click(object sender, EventArgs e)
        {
            try
            {
                frmPay_Sales_Factor f = new frmPay_Sales_Factor();
                f.Form_Load();
                f.op = "Add";
                f.lblFactor_Code.Text = lblFactor_Code.Text;
                f.lblCustomer_Code.Text = txtCustomer_Code.Text;
                f.lblCustomer_Name.Text = txtCustomer_Name.Text;
                f.ShowDialog();
                txtCash.Text = f.lblSum_Cash.Text;
                txtCredit_Card.Text = f.lblSum_Bank.Text;
                lblSum_Recive.Text = (Convert.ToInt32(lblSum_Recive.Text) + Convert.ToInt32(txtCash.Text) + Convert.ToInt32(txtCredit_Card.Text)).ToString();
            }
            catch
            {
                txtCash.Text = txtCredit_Card.Text = "0";
            }
        }

        private void btnSearch_Income_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllIncome f = new frmAllIncome();
                f.ShowDialog();
                txtInc_Code.Text = f.Income_Code;
            }
            catch
            {
            }
        }

        private void txtInc_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Inc_Name, Price FROM tbl_Income WHERE ID='" + Convert.ToInt32(txtInc_Code.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtInc_Name.Text = dt.Rows[0].ItemArray[0].ToString();
                txtInc_Price.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                txtInc_Price.Text = "0";
                txtInc_Name.Text = "";
            }
        }

        private void txtInc_Entity_TextChanged(object sender, EventArgs e)
        {
            Calculate_Income();
        }

        private void txtInc_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtInc_Price);
            Calculate_Income();
        }

        private void txtInc_Discount_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtInc_Discount);
            Calculate_Income();
        }

        private void txtInc_Total_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtInc_Total);
        }

        private void btnIns_Income_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtInc_Code, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtInc_Entity, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtInc_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtInc_Discount, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtInc_Total, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (Income_op == "Add")
                {
                    if (Check_Income_Code() == true)
                    {
                        string query = "UPDATE tbl_Tour_Of_Income SET Entity =Entity+ '" + float.Parse(txtInc_Entity.Text) + "', Price = '" + Convert.ToInt32(txtInc_Price.Text) + "', Discount =Discount+ '" + Convert.ToInt32(txtInc_Discount.Text) + "', Total =Total+ '" + Convert.ToInt64(txtInc_Total.Text) + "' WHERE ID_Factor = '" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Income_ID = '" + Convert.ToInt32(txtInc_Code.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            Fill_Income();
                        }
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Tour_Of_Income (ID_Factor, Income_ID, Entity, Price, Discount, Total) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Convert.ToInt32(txtInc_Code.Text) + "','" + float.Parse(txtInc_Entity.Text) + "','" + Convert.ToInt32(txtInc_Price.Text) + "','" + Convert.ToInt32(txtInc_Discount.Text) + "','" + Convert.ToInt64(txtInc_Total.Text) + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            Fill_Income();
                        }
                    }
                }
                else if (Income_op == "Edit")
                {
                    string query = "UPDATE tbl_Tour_Of_Income SET Entity = '" + float.Parse(txtInc_Entity.Text) + "', Price = '" + Convert.ToInt32(txtInc_Price.Text) + "', Discount = '" + Convert.ToInt32(txtInc_Discount.Text) + "', Total ='" + Convert.ToInt64(txtInc_Total.Text) + "' WHERE ID_Factor = '" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Income_ID = '" + Convert.ToInt32(txtInc_Code.Text) + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                        Fill_Income();
                    }
                }
            }
        }

        private void lblShow_Factor_Cost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDigit.Text = Num2Text.ToFarsi(Convert.ToInt64(lblShow_Factor_Cost.Text)) + " " + "ریال";
                lblTotal_Factor.Text = lblShow_Factor_Cost.Text;
            }
            catch
            {
                lblDigit.Text = "صفر ریال";
            }
        }

        private void txtDiscount_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtDiscount_Price);
                lblSum_Discount.Text = (Discount + Convert.ToInt32(txtDiscount_Price.Text)).ToString();
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
                lblShow_Factor_Cost.Text = ((Convert.ToInt32(lblSum_Factor_Price.Text) + Convert.ToInt32(txtAdded_Price.Text)) - Convert.ToInt32(lblSum_Discount.Text)).ToString();
            }
            catch
            {
                txtAdded_Price.Text = "0";
            }
        }

        private void lblSum_Factor_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblShow_Factor_Cost.Text = ((Convert.ToInt32(lblSum_Factor_Price.Text) + Convert.ToInt32(txtAdded_Price.Text)) - Convert.ToInt32(lblSum_Discount.Text)).ToString();
                Sum_Factor = Convert.ToInt32(lblSum_Factor_Price.Text);
            }
            catch
            {
                lblShow_Factor_Cost.Text = "0";
            }
        }

        private void txtDiscoount_Percent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDiscoount_Percent.Text) > 100)
                    txtDiscoount_Percent.Text = "100";
                else
                    txtDiscount_Price.Text = ((Convert.ToInt32(lblSum_Factor_Price.Text) * Convert.ToInt32(txtDiscoount_Percent.Text)) / 100).ToString();
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
                else
                    txtAdded_Price.Text = ((Convert.ToInt32(lblSum_Factor_Price.Text) * Convert.ToInt32(txtAdded_Percent.Text)) / 100).ToString();
            }
            catch
            {
                txtAdded_Price.Text = "0";
            }
        }

        private void lblSum_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblShow_Factor_Cost.Text = ((Convert.ToInt32(lblSum_Factor_Price.Text) + Convert.ToInt32(txtAdded_Price.Text)) - Convert.ToInt32(lblSum_Discount.Text)).ToString();
            }
            catch
            {
                lblShow_Factor_Cost.Text = "0";
            }
        }

        private void lblSum_Recive_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblRemane.Text = (Convert.ToInt32(lblTotal_Factor.Text) - Convert.ToInt32(lblSum_Recive.Text)).ToString();
            }
            catch
            {
                lblRemane.Text = "0";
            }
        }

        private void lblTotal_Factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblRemane.Text = (Convert.ToInt32(lblTotal_Factor.Text) - Convert.ToInt32(lblSum_Recive.Text)).ToString();
            }
            catch
            {
                lblRemane.Text = "0";
            }
        }

        private void dgvIncome_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvIncome.Rows[e.RowIndex].Cells["Inc_Radif"].Value = e.RowIndex + 1;
        }

        private void mnuEdit_Income_Click(object sender, EventArgs e)
        {
            try
            {
                Income_op = "Edit";
                int Inc_Id_Edit = Convert.ToInt32(dgvIncome.CurrentRow.Cells["Income_ID"].Value);
                SqlDataAdapter da = new SqlDataAdapter("SELECT Entity, Price, Discount, Total FROM tbl_Tour_Of_Income WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Income_ID='" + Inc_Id_Edit + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtInc_Code.Text = Inc_Id_Edit.ToString();
                txtInc_Entity.Text = dt.Rows[0].ItemArray[0].ToString();
                txtInc_Price.Text = dt.Rows[0].ItemArray[1].ToString();
                txtInc_Discount.Text = dt.Rows[0].ItemArray[2].ToString();
                txtInc_Total.Text = dt.Rows[0].ItemArray[3].ToString();
                Total_Income_Edit = Convert.ToInt32(dt.Rows[0].ItemArray[3]);
            }
            catch
            {
            }
        }

        private void mnuDelete_Income_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Tour_Of_Income WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Income_ID='" + Convert.ToInt32(dgvIncome.CurrentRow.Cells["Income_ID"].Value) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvIncome.CurrentRow.Cells["Inc_Name"].Value.ToString() + " " + "از فاکتور، اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        Fill_Income();
                }
            }
            catch
            {
            }
        }

        private void mnuDelete_All_Income_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Tour_Of_Income WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف کلیه درآمدها از فاکتور، اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        Fill_Income();
                }
            }
            catch
            {
            }
        }

        private void lbxProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Per_Factor == "Per" && per_Factor == false)
                {
                    Insert_From_Per_Factor();
                    per_Factor = true;
                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code FROM tbl_Product WHERE P_Show_Name LIKE N'" + lbxProduct.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Product_Code = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                try
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Price_List.Sell_Price FROM tbl_Product INNER JOIN tbl_Price_List ON tbl_Product.P_Code = tbl_Price_List.P_Code WHERE tbl_Price_List.P_Code='" + Product_Code + "' AND tbl_Price_List.Pattern_Code='" + Pattern_Code + "'", dataconnection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    Product_Price = Convert.ToInt32(dt2.Rows[0].ItemArray[0]);
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
            }
            catch
            {
            }
            try
            {
                float Product_Entity;
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT SUM(Incoming), SUM(Issued) FROM tbl_Tour_Of_Product WHERE P_Code='" + Product_Code + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                Product_Entity = float.Parse(dt2.Rows[0].ItemArray[0].ToString()) - float.Parse(dt2.Rows[0].ItemArray[1].ToString());
                if (Product_Entity <= 0)
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "موجودی کالا کافی نمی باشد";
                    f.ShowDialog();
                }
                try
                {
                    SqlDataAdapter da5 = new SqlDataAdapter("SELECT Total_Price FROM tbl_Header_Product_Production WHERE P_Code='" + Product_Code + "'", dataconnection);
                    DataTable dt5 = new DataTable();
                    da5.Fill(dt5);
                    if (Convert.ToInt32(dt5.Rows[0].ItemArray[0]) >= Product_Price)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "آخرین قیمت تمام شده کالا " + dt5.Rows[0].ItemArray[0].ToString() + " " + "می باشد";
                        f.ShowDialog();
                    }
                }
                catch
                {
                }
                if (Check_Product_Code() == true)
                {
                    string query3 = "UPDATE tbl_Body_Sales_Factor SET Entity = Entity+1, Cost = Cost+'" + Convert.ToInt64(Product_Price + Product_Tax) + "', Total = Total+'" + Convert.ToInt64(Product_Price + Product_Tax) + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "' AND P_Code = '" + Product_Code + "'";
                    if (clsFunction.Execute(dataconnection, query3) == true)
                    {
                        Fill_Product_In_dgv();
                    }
                }
                else
                {
                    if (Check_Factor == false)
                    {
                        string query = "INSERT INTO tbl_Header_Sales_Factor (ID) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                        }
                    }
                    string query2 = "INSERT INTO tbl_Body_Sales_Factor (ID, P_Code, Entity, Price, Cost, Discount, Total, Notice) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Product_Code + "',1,'" + Convert.ToInt32(Product_Price + Product_Tax) + "','" + Convert.ToInt64(Product_Price + Product_Tax) + "',0,'" + Convert.ToInt64(Product_Price + Product_Tax) + "','" + "" + "')";
                    if (clsFunction.Execute(dataconnection, query2) == true)
                    {
                    }
                    Check_Factor = true;
                    Fill_Product_In_dgv();
                }
                lbx.Items.Add(Product_Code.ToString());
            }
            catch
            {
            }
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
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

        private void btnInsert_P_Factor_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtProduct_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Entity, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Discount, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtProduct_Total, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (Product_op == "Add")
                {
                    float Product_Entity;
                    if (Per_Factor == "Per" && per_Factor == false)
                    {
                        Insert_From_Per_Factor();
                        per_Factor = true;
                    }
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT SUM(Incoming), SUM(Issued) FROM tbl_Tour_Of_Product WHERE P_Code='" + Product_Code + "'", dataconnection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    Product_Entity = float.Parse(dt2.Rows[0].ItemArray[0].ToString()) - float.Parse(dt2.Rows[0].ItemArray[1].ToString());
                    if (Product_Entity <= 0)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "موجودی کالا کافی نمی باشد";
                        f.ShowDialog();
                    }
                    try
                    {
                        SqlDataAdapter da5 = new SqlDataAdapter("SELECT Total_Price FROM tbl_Header_Product_Production WHERE P_Code='" + Product_Code + "'", dataconnection);
                        DataTable dt5 = new DataTable();
                        da5.Fill(dt5);
                        if (Convert.ToInt32(dt5.Rows[0].ItemArray[0]) >= Product_Price)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = "آخرین قیمت تمام شده کالا " + dt5.Rows[0].ItemArray[0].ToString() + " " + "می باشد";
                            f.ShowDialog();
                        }
                    }
                    catch
                    {
                    }
                    if (Check_Product_Code() == true)
                    {
                        string query3 = "UPDATE tbl_Body_Sales_Factor SET Entity = Entity+'" + float.Parse(txtProduct_Entity.Text) + "', Cost = Cost+'" + Convert.ToInt64(txtProduct_Price.Text) + "', Total = Total+'" + Convert.ToInt64(txtProduct_Total.Text) + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "' AND P_Code = '" + Product_Code + "'";
                        if (clsFunction.Execute(dataconnection, query3) == true)
                        {
                            Fill_Product_In_dgv();
                        }
                    }
                    else
                    {
                        if (Check_Factor == false)
                        {
                            string query = "INSERT INTO tbl_Header_Sales_Factor (ID) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "')";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                            }
                        }
                        string query2 = "INSERT INTO tbl_Body_Sales_Factor (ID, P_Code, Entity, Price, Cost, Discount, Total, Notice) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Product_Code + "','" + float.Parse(txtProduct_Entity.Text) + "','" + Convert.ToInt32(txtProduct_Price.Text) + "','" + Convert.ToInt64(txtProduct_Cost.Text) + "','" + Convert.ToInt32(txtProduct_Discount.Text) + "','" + Convert.ToInt64(txtProduct_Total.Text) + "',N'" + txtProduct_Notice.Text + "')";
                        if (clsFunction.Execute(dataconnection, query2) == true)
                        {
                        }
                        Check_Factor = true;
                        Fill_Product_In_dgv();
                    }
                }
                else if (Product_op == "Edit")
                {
                    string query3 = "UPDATE tbl_Body_Sales_Factor SET Entity = '" + float.Parse(txtProduct_Entity.Text) + "', Price='" + Convert.ToInt32(txtProduct_Price.Text) + "', Cost = '" + Convert.ToInt64(txtProduct_Price.Text) + "', Discount='" + Convert.ToInt32(txtProduct_Discount.Text) + "', Total = '" + Convert.ToInt64(txtProduct_Total.Text) + "', Notice=N'" + txtProduct_Notice.Text + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "' AND P_Code = '" + Product_Code + "'";
                    if (clsFunction.Execute(dataconnection, query3) == true)
                    {
                        Fill_Product_In_dgv();
                    }
                }
                lbx.Items.Add(float.Parse(txtProduct_Code.Text));
                txtProduct_Code.Text = txtProduct_Name.Text = txtProduct_Notice.Text = "";
                txtProduct_Cost.Text = txtProduct_Discount.Text = txtProduct_Price.Text = txtProduct_Total.Text = "0";
                txtProduct_Entity.Text = "1";
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Product_op = "Edit";
                TabControl.SelectedTab = superTabItem2;
                txtProduct_Code.Text = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Entity, Price, Cost, Discount, Total, Notice FROM tbl_Body_Sales_Factor WHERE ID='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND P_Code='" + Convert.ToInt32(txtProduct_Code.Text) + "'", dataconnection);
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
                string query1 = "DELETE FROM tbl_Body_Sales_Factor WHERE ID='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND P_Code='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Code"].Value) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["P_Name"].Value.ToString() + " " + "از فاکتور، اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    lbx.Items.Add(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                    lbx_Entity.Items.Add(dgvStore.CurrentRow.Cells["Entity"].Value.ToString());
                    lbx_Price.Items.Add(dgvStore.CurrentRow.Cells["Buy_Price"].Value.ToString());
                    lbx_Total.Items.Add(dgvStore.CurrentRow.Cells["Cost"].Value.ToString());
                    if (clsFunction.Execute(dataconnection, query1) == true)
                    {
                        Fill_Product_In_dgv();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Exit_Temp = 1;
            if (dgvStore.Rows.Count == 0 || Exit_Temp == 0)
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "تغییرات ذخیره نشده است. آیا مایلید تغییرات فاکتور را ذخیره نمایید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 1)
                {
                    if (lbx_Entity.Items.Count > 0)
                    {
                        for (int i = 0; i < lbx.Items.Count; i++)
                        {
                            string query2 = "INSERT INTO tbl_Body_Sales_Factor (ID, P_Code, Entity, Price, Cost, Discount, Total, Notice) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Convert.ToInt32(lbx.Items[i].ToString()) + "','" + float.Parse(lbx_Entity.Items[i].ToString()) + "','" + Convert.ToInt32(lbx_Price.Items[i].ToString()) + "','" + Convert.ToInt64(lbx_Total.Items[i].ToString()) + "','" + 0 + "','" + Convert.ToInt64(lbx_Total.Items[i].ToString()) + "',N'" + "" + "')";
                            if (clsFunction.Execute(dataconnection, query2) == true)
                            {
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < lbx.Items.Count; i++)
                        {
                            string query1 = "DELETE FROM tbl_Body_Sales_Factor WHERE ID='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND P_Code='" + Convert.ToInt32(lbx.Items[i].ToString()) + "'";
                            if (clsFunction.Execute(dataconnection, query1) == true)
                            {
                            }
                        }
                    }
                }
                else
                {
                    Delete_Data(Convert.ToInt32(lblFactor_Code.Text));
                    query1 = "UPDATE tbl_Header_Sales_Factor SET Date = '" + txtDate.Text + "', Time = '" + lblTime.Text + "', UserName = '" + lblUserName.Text + "', Store = '" + Store_Code + "', C_Code = '" + txtCustomer_Code.Text + "', Serve_Type = '" + Serve_Type + "', Sett_Date = '" + txtSett_Date.Text + "', Cost = '" + Convert.ToInt64(lblSum_Factor_Price.Text) + "', Discount = '" + Convert.ToInt32(txtDiscount_Price.Text) + "', Tax = '" + Convert.ToInt32(lblSum_Tax.Text) + "', Sum_Factor = '" + Convert.ToInt64(lblShow_Factor_Cost.Text) + "', Added_Price='" + Convert.ToInt32(txtAdded_Price.Text) + "', Factor_Discount='" + Convert.ToInt32(txtDiscount_Price.Text) + "', Fin_State='" + Finantial_State + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                    query2 = "UPDATE tbl_Header_WareTransfer SET Code = '" + txtCustomer_Code.Text + "', Date = '" + txtDate.Text + "', Store = '" + Store_Code + "', Notice = N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                    if (Serve_Type == 2)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type, Peyk_Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "','" + Peyk_Code + "')";
                    else if (Serve_Type == 3)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type, Table_Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "','" + Table_Code + "')";
                    else if (Serve_Type == 1)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "')";
                    if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query4) == true)
                    {
                        if (Serve_Type == 2)
                        {
                            string query71 = "INSERT INTO tbl_Perssonel_Trafic (Per_ID, Date, Time, Traf_Type, Notice) VALUES ('" + Peyk_Code + "','" + txtDate.Text + "','" + lblTime.Text + "',1,'" + "ارسال سفارش مشتری " + txtCustomer_Name.Text + " " + "مربوط به فاکتور فروش شماره " + lblFactor_Code.Text + "')";
                            if (clsFunction.Execute(dataconnection, query71) == true)
                            {
                            }
                        }
                        if (Serve_Type == 3)
                        {
                            string query7 = "UPDATE tbl_Tables SET Table_State=2 WHERE Table_Code='" + Table_Code + "'";
                            if (clsFunction.Execute(dataconnection, query7) == true)
                            {
                            }
                        }
                        for (int i = 0; i < dgvStore.Rows.Count; i++)
                        {
                            try
                            {
                                query3 = "INSERT INTO tbl_Body_WareTransfer (ID, P_Code, Entity) VALUES ('" + Ware_Rec_ID + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "')";
                                query6 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtCustomer_Name.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "',1,'" + Convert.ToInt32(Ware_Rec_ID) + "','" + Store_Code + "')";
                                query8 = "UPDATE tbl_Product SET Sell_Price = '" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "' WHERE P_Code = '" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "'";
                                if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query6) == true && clsFunction.Execute(dataconnection, query8) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                        Get_Max_Doc_Number();
                        query9 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(lblSum_Factor_Price.Text) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60101" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                        query10 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCustomer_Code.Text + "','" + Convert.ToInt64(lblShow_Factor_Cost.Text) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                        if (clsFunction.Execute(dataconnection, query9) == true && clsFunction.Execute(dataconnection, query10) == true)
                        {
                            if (Convert.ToInt32(lblSum_Discount.Text) != 0)
                            {
                                query11 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(lblSum_Discount.Text) + "',N'" + "تخفیف فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60202" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                                if (clsFunction.Execute(dataconnection, query11) == true)
                                {
                                }
                            }
                            if (Convert.ToInt32(txtAdded_Price.Text) != 0)
                            {
                                query12 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtAdded_Price.Text) + "',N'" + "اضافات فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60301" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                                if (clsFunction.Execute(dataconnection, query12) == true)
                                {
                                }
                            }
                        }
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Point, Price FROM tbl_Setting_Sales_Factor WHERE ID=1", dataconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) != 0)
                        {
                            int Point = Convert.ToInt32(lblShow_Factor_Cost.Text) / Convert.ToInt32(dt.Rows[0].ItemArray[1]);
                            int Points = 0;
                            if (Point > 0 && Convert.ToInt32(lblShow_Factor_Cost.Text) >= Convert.ToInt32(dt.Rows[0].ItemArray[0]))
                            {
                                Points = Point * Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                                string query13 = "UPDATE tbl_Customer_Club SET Point=Point+'" + Points + "' WHERE Code='" + txtCustomer_Code.Text + "'";
                                string query14 = "INSERT INTO tbl_Tour_Cus_Club_Point (Guid, Code, Point, P_Code) VALUES ('" + Guid.NewGuid() + "','" + txtCustomer_Code.Text + "','" + Points + "','" + Convert.ToInt64(lblFactor_Code.Text) + "')";
                                if (clsFunction.Execute(dataconnection, query13) == true && clsFunction.Execute(dataconnection, query14) == true)
                                {
                                    string query15 = "UPDATE tbl_Header_Sales_Factor SET Point='" + Points + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                                    if (clsFunction.Execute(dataconnection, query15) == true)
                                    {
                                    }
                                }
                            }
                        }
                        this.Close();
                    }
                }
            }
            else
            {
                if (lblRemane.Text == "0")
                    Finantial_State = 0;
                else
                    Finantial_State = 1;
                if (op == "Add")
                {
                    Get_Max_WareHouse_Reciept_ID();
                    if (Per_Factor == "Per" && per_Factor == false)
                        Insert_From_Per_Factor();
                    query1 = "UPDATE tbl_Header_Sales_Factor SET Date = '" + txtDate.Text + "', Time = '" + lblTime.Text + "', UserName = '" + lblUserName.Text + "', Store = '" + Store_Code + "', C_Code = '" + txtCustomer_Code.Text + "', Serve_Type = '" + Serve_Type + "', Sett_Date = '" + txtSett_Date.Text + "', Cost = '" + Convert.ToInt64(lblSum_Factor_Price.Text) + "', Discount = '" + Convert.ToInt32(txtDiscount_Price.Text) + "', Tax = '" + Convert.ToInt32(lblSum_Tax.Text) + "', Sum_Factor = '" + Convert.ToInt64(lblShow_Factor_Cost.Text) + "', Doc_Code = '" + Ware_Rec_ID + "', Added_Price='" + Convert.ToInt32(txtAdded_Price.Text) + "', Factor_Discount='" + Convert.ToInt32(txtDiscount_Price.Text) + "', Fin_State='" + Finantial_State + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                    query2 = "INSERT INTO tbl_Header_WareTransfer (ID, Code, Date, Store, Notice, Type, Validation) VALUES ('" + Ware_Rec_ID + "','" + txtCustomer_Code.Text + "','" + txtDate.Text + "','" + Store_Code + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + "',1,'" + "خیر" + "')";
                    if (Serve_Type == 2)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type, Peyk_Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "','" + Peyk_Code + "')";
                    else if (Serve_Type == 3)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type, Table_Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "','" + Table_Code + "')";
                    else if (Serve_Type == 1)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "')";
                    if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query4) == true)
                    {
                        if (Serve_Type == 2)
                        {
                            string query71 = "INSERT INTO tbl_Perssonel_Trafic (Per_ID, Date, Time, Traf_Type, Notice) VALUES ('" + Peyk_Code + "','" + txtDate.Text + "','" + lblTime.Text + "',1,'" + "ارسال سفارش مشتری " + txtCustomer_Name.Text + " " + "مربوط به فاکتور فروش شماره " + lblFactor_Code.Text + "')";
                            if (clsFunction.Execute(dataconnection, query71) == true)
                            {
                            }
                        }
                        if (Serve_Type == 3)
                        {
                            string query7 = "UPDATE tbl_Tables SET Table_State=2 WHERE Table_Code='" + Table_Code + "'";
                            if (clsFunction.Execute(dataconnection, query7) == true)
                            {
                            }
                        }
                        for (int i = 0; i < dgvStore.Rows.Count; i++)
                        {
                            try
                            {
                                query3 = "INSERT INTO tbl_Body_WareTransfer (ID, P_Code, Entity) VALUES ('" + Ware_Rec_ID + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "')";
                                query6 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtCustomer_Name.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "',1,'" + Convert.ToInt32(Ware_Rec_ID) + "','" + Store_Code + "')";
                                query8 = "UPDATE tbl_Product SET Sell_Price = '" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "' WHERE P_Code = '" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "'";
                                if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query6) == true && clsFunction.Execute(dataconnection, query8) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                        if (txtSett_Date.Text != "    /  /")
                        {
                            Get_Max_Reminder_ID();
                            query5 = "INSERT INTO tbl_Reminder (ID, Title, Body, Ins_Date, Remind_Date) VALUES ('" + Reminder_ID + "',N'" + "تسویه با بدهکاران تجاری" + "',N'" + "تسویه با " + txtCustomer_Name.Text + " " + "بابت فاکتور فروش شماره " + " " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + txtSett_Date.Text + "')";
                            if (clsFunction.Execute(dataconnection, query5) == true)
                            {
                            }
                        }
                        Get_Max_Doc_Number();
                        query9 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(lblSum_Factor_Price.Text) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60101" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                        query10 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCustomer_Code.Text + "','" + Convert.ToInt64(lblShow_Factor_Cost.Text) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                        if (clsFunction.Execute(dataconnection, query9) == true && clsFunction.Execute(dataconnection, query10) == true)
                        {
                            if (Convert.ToInt32(lblSum_Discount.Text) != 0)
                            {
                                query11 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(lblSum_Discount.Text) + "',N'" + "تخفیف فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60202" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                                if (clsFunction.Execute(dataconnection, query11) == true)
                                {
                                }
                            }
                            if (Convert.ToInt32(txtAdded_Price.Text) != 0)
                            {
                                query12 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtAdded_Price.Text) + "',N'" + "اضافات فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60301" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                                if (clsFunction.Execute(dataconnection, query12) == true)
                                {
                                }
                            }
                        }
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Point, Price FROM tbl_Setting_Sales_Factor WHERE ID=1", dataconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) != 0)
                        {
                            int Point = Convert.ToInt32(lblShow_Factor_Cost.Text) / Convert.ToInt32(dt.Rows[0].ItemArray[1]);
                            int Points = 0;
                            if (Point > 0 && Convert.ToInt32(lblShow_Factor_Cost.Text) >= Convert.ToInt32(dt.Rows[0].ItemArray[0]))
                            {
                                Points = Point * Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                                string query13 = "UPDATE tbl_Customer_Club SET Point=Point+'" + Points + "' WHERE Code='" + txtCustomer_Code.Text + "'";
                                string query14 = "INSERT INTO tbl_Tour_Cus_Club_Point (Guid, Code, Point, P_Code) VALUES ('" + Guid.NewGuid() + "','" + txtCustomer_Code.Text + "','" + Points + "','" + Convert.ToInt64(lblFactor_Code.Text) + "')";
                                if (clsFunction.Execute(dataconnection, query13) == true && clsFunction.Execute(dataconnection, query14) == true)
                                {
                                    string query15 = "UPDATE tbl_Header_Sales_Factor SET Point='" + Points + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                                    if (clsFunction.Execute(dataconnection, query15) == true)
                                    {
                                    }
                                }
                            }
                        }
                        this.Close();
                    }
                }
                else if (op == "Edit")
                {
                    Delete_Data(Convert.ToInt32(lblFactor_Code.Text));
                    query1 = "UPDATE tbl_Header_Sales_Factor SET Date = '" + txtDate.Text + "', Time = '" + lblTime.Text + "', UserName = '" + lblUserName.Text + "', Store = '" + Store_Code + "', C_Code = '" + txtCustomer_Code.Text + "', Serve_Type = '" + Serve_Type + "', Sett_Date = '" + txtSett_Date.Text + "', Cost = '" + Convert.ToInt64(lblSum_Factor_Price.Text) + "', Discount = '" + Convert.ToInt32(txtDiscount_Price.Text) + "', Tax = '" + Convert.ToInt32(lblSum_Tax.Text) + "', Sum_Factor = '" + Convert.ToInt64(lblShow_Factor_Cost.Text) + "', Added_Price='" + Convert.ToInt32(txtAdded_Price.Text) + "', Factor_Discount='" + Convert.ToInt32(txtDiscount_Price.Text) + "', Fin_State='" + Finantial_State + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                    query2 = "UPDATE tbl_Header_WareTransfer SET Code = '" + txtCustomer_Code.Text + "', Date = '" + txtDate.Text + "', Store = '" + Store_Code + "', Notice = N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                    if (Serve_Type == 2)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type, Peyk_Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "','" + Peyk_Code + "')";
                    else if (Serve_Type == 3)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type, Table_Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "','" + Table_Code + "')";
                    else if (Serve_Type == 1)
                        query4 = "INSERT INTO tbl_Serve_Info (ID_Factor, Serve_Type) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + Serve_Type + "')";
                    if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query4) == true)
                    {
                        if (Serve_Type == 2)
                        {
                            string query71 = "INSERT INTO tbl_Perssonel_Trafic (Per_ID, Date, Time, Traf_Type, Notice) VALUES ('" + Peyk_Code + "','" + txtDate.Text + "','" + lblTime.Text + "',1,'" + "ارسال سفارش مشتری " + txtCustomer_Name.Text + " " + "مربوط به فاکتور فروش شماره " + lblFactor_Code.Text + "')";
                            if (clsFunction.Execute(dataconnection, query71) == true)
                            {
                            }
                        }
                        if (Serve_Type == 3)
                        {
                            string query7 = "UPDATE tbl_Tables SET Table_State=2 WHERE Table_Code='" + Table_Code + "'";
                            if (clsFunction.Execute(dataconnection, query7) == true)
                            {
                            }
                        }
                        for (int i = 0; i < dgvStore.Rows.Count; i++)
                        {
                            try
                            {
                                query3 = "INSERT INTO tbl_Body_WareTransfer (ID, P_Code, Entity) VALUES ('" + Ware_Rec_ID + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "')";
                                query6 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtCustomer_Name.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "',1,'" + Convert.ToInt32(Ware_Rec_ID) + "','" + Store_Code + "')";
                                query8 = "UPDATE tbl_Product SET Sell_Price = '" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "' WHERE P_Code = '" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "'";
                                if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query6) == true && clsFunction.Execute(dataconnection, query8) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                        Get_Max_Doc_Number();
                        query9 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(lblSum_Factor_Price.Text) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60101" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                        query10 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCustomer_Code.Text + "','" + Convert.ToInt64(lblShow_Factor_Cost.Text) + "',N'" + "فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                        if (clsFunction.Execute(dataconnection, query9) == true && clsFunction.Execute(dataconnection, query10) == true)
                        {
                            if (Convert.ToInt32(lblSum_Discount.Text) != 0)
                            {
                                query11 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(lblSum_Discount.Text) + "',N'" + "تخفیف فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60202" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                                if (clsFunction.Execute(dataconnection, query11) == true)
                                {
                                }
                            }
                            if (Convert.ToInt32(txtAdded_Price.Text) != 0)
                            {
                                query12 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtAdded_Price.Text) + "',N'" + "اضافات فاکتور فروش به شماره " + lblFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60301" + "','" + 1 + "','" + lblFactor_Code.Text + "')";
                                if (clsFunction.Execute(dataconnection, query12) == true)
                                {
                                }
                            }
                        }
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Point, Price FROM tbl_Setting_Sales_Factor WHERE ID=1", dataconnection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) != 0)
                        {
                            int Point = Convert.ToInt32(lblShow_Factor_Cost.Text) / Convert.ToInt32(dt.Rows[0].ItemArray[1]);
                            int Points = 0;
                            if (Point > 0 && Convert.ToInt32(lblShow_Factor_Cost.Text) >= Convert.ToInt32(dt.Rows[0].ItemArray[0]))
                            {
                                Points = Point * Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                                string query13 = "UPDATE tbl_Customer_Club SET Point=Point+'" + Points + "' WHERE Code='" + txtCustomer_Code.Text + "'";
                                string query14 = "INSERT INTO tbl_Tour_Cus_Club_Point (Guid, Code, Point, P_Code) VALUES ('" + Guid.NewGuid() + "','" + txtCustomer_Code.Text + "','" + Points + "','" + Convert.ToInt64(lblFactor_Code.Text) + "')";
                                if (clsFunction.Execute(dataconnection, query13) == true && clsFunction.Execute(dataconnection, query14) == true)
                                {
                                    string query15 = "UPDATE tbl_Header_Sales_Factor SET Point='" + Points + "' WHERE ID = '" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                                    if (clsFunction.Execute(dataconnection, query15) == true)
                                    {
                                    }
                                }
                            }
                        }
                        this.Close();
                    }
                }
            }
        }

        private void mnuDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Sales_Factor WHERE ID='" + Convert.ToInt64(lblFactor_Code.Text) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف کلیه کالاها از فاکتور، اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    for (int i = 0; i < dgvStore.Rows.Count; i++)
                    {
                        lbx.Items.Add(dgvStore.Rows[i].Cells["Code"].Value.ToString());
                        lbx_Entity.Items.Add(dgvStore.Rows[i].Cells["Entity"].Value.ToString());
                        lbx_Price.Items.Add(dgvStore.Rows[i].Cells["Buy_Price"].Value.ToString());
                        lbx_Total.Items.Add(dgvStore.Rows[i].Cells["Cost"].Value.ToString());
                    }
                    if (clsFunction.Execute(dataconnection, query1) == true)
                    {
                        Fill_Product_In_dgv();
                    }
                }
            }
            catch
            {
            }
        }

        private void txtSub_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCustomer_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDiscoount_Percent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAdded_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtInc_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtInc_Entity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtInc_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtInc_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtInc_Total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
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

        private void txtProduct_Entity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnInsert_P_Factor_Click(null, null);
            }
        }

        private void txtProduct_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                if (txtProduct_Name.Text != "")
                {
                    btnInsert_P_Factor_Click(null, null);
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

        private void txtProduct_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnInsert_P_Factor_Click(null, null);
        }

        private void txtProduct_Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnInsert_P_Factor_Click(null, null);
        }

        private void txtProduct_Notice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnInsert_P_Factor_Click(null, null);
        }

        private void txtInc_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnIns_Income_Click(null, null);
        }

        private void txtInc_Entity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnIns_Income_Click(null, null);
        }

        private void txtInc_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnIns_Income_Click(null, null);
        }

        private void txtInc_Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnIns_Income_Click(null, null);
        }

        private void txtInc_Total_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnIns_Income_Click(null, null);
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

        private void picTour_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer_Little_Tour f = new frmCustomer_Little_Tour();
                f.Fill_Data(txtCustomer_Code.Text);
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmSales_Factor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Convert.ToInt32(lblShow_Factor_Cost.Text) != 0)
            {
                string query = "UPDATE tbl_Customer SET Last_Factor_Price='" + lblShow_Factor_Cost.Text +
                               "', Last_Factor_Date='" + txtDate.Text + "' WHERE Code='" + txtCustomer_Code.Text + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                }
            }
        }
    }
}
