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
    public partial class frmPay_Sales_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        string Safe_Code, Bank_Code;
        int Doc_Number_For_Cash_Payement, Doc_Number_For_Bank_Payement;
        Int64 ID_Cash_Trans, ID_Bank_Trans, ID_Cash_Pay, ID_Bank_Pay, ID_Cash_Trans_Customer, ID_Bank_Trans_Customer;
        public void Form_Load()
        {
            TabControl.SelectedTab = superTabItem1;
            txtCash_Date.Text = txtBank_Date.Text = clsFunction.M2SH(DateTime.Now);
            txtCash_Price.Text = lblSum_Cash.Text = lblSum_Bank.Text = txtBank_Price.Text = "0";
            txtFish_Number.Text = "";
            Fill_Safe();
            Fill_Bank();
            Fill_Cash_Payement();
            Fill_Bank_Payement();
            Find_Cash_Price();
            Find_Bank_Price();
        }
        private void Find_Cash_Price()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Price) FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Pay_Type=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblSum_Cash.Text = dt.Rows[0].ItemArray[0].ToString();
                if (lblSum_Cash.Text == "")
                    lblSum_Cash.Text = "0";
            }
            catch
            {
                lblSum_Cash.Text = "0";
            }
        }
        private void Find_Bank_Price()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Price) FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Pay_Type=2", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblSum_Bank.Text = dt.Rows[0].ItemArray[0].ToString();
                if (lblSum_Bank.Text == "")
                    lblSum_Bank.Text = "0";
            }
            catch
            {
                lblSum_Bank.Text = "0";
            }
        }
        private void Fill_Cash_Payement()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Price, Date, Destination FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Pay_Type=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCash.DataSource = dt;
            }
            catch
            {
            }
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
        private void Fill_Bank()
        {
            try
            {
                cmbBank.Items.Clear();
                string Query = "SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Bank ON tbl_Account.Code = tbl_Bank.Code WHERE Poss=0";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbBank, s_obj);
                cmbBank.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Bank FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbBank.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void Get_Max_Doc_Number_For_Cash_Payement()
        {
            try
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Number FROM tbl_Transaction WHERE Date='" + txtCash_Date.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number_For_Cash_Payement = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
                catch
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Doc_Number) FROM tbl_Transaction", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number_For_Cash_Payement = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;
                }
            }
            catch
            {
                Doc_Number_For_Cash_Payement = 1;
            }
        }
        private void Get_Max_Doc_Number_For_Bank_Payement()
        {
            try
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Number FROM tbl_Transaction WHERE Date='" + txtBank_Date.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number_For_Bank_Payement = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
                catch
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Doc_Number) FROM tbl_Transaction", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number_For_Bank_Payement = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;
                }
            }
            catch
            {
                Doc_Number_For_Bank_Payement = 1;
            }
        }
        private void Fill_Bank_Payement()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Price, Date, Fish_Number, Destination FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + Convert.ToInt64(lblFactor_Code.Text) + "' AND Pay_Type=2", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBank.DataSource = dt;
            }
            catch
            {
            }
        }
        public frmPay_Sales_Factor()
        {
            InitializeComponent();
        }

        private void frmPay_Sales_Factor_Load(object sender, EventArgs e)
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

        private void btnIns_Cash_OP_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtCash_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else if (txtCash_Price.Text == "0")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مبلغ را وارد نمایید";
                f.ShowDialog();
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    Get_Max_Doc_Number_For_Cash_Payement();
                    string query = "INSERT INTO tbl_Pay_Of_Sales_Factor (ID_Factor, Time, Pay_Type, Price, Date, Destination, Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + System.DateTime.Now.ToLongTimeString() + "',1,'" + Convert.ToInt64(txtCash_Price.Text) + "','" + txtCash_Date.Text + "',N'" + cmbSafe.Text + "','" + Safe_Code + "')";
                    string query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Safe_Code + "','" + Convert.ToInt64(txtCash_Price.Text) + "','" + "دریافت وجه نقد بابت فاکتور فروش شماره " + lblFactor_Code.Text + "','" + txtCash_Date.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number_For_Cash_Payement + "','" + "10102" + "',1,'" + lblFactor_Code.Text + "')";
                    string query21 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblCustomer_Code.Text + "','" + Convert.ToInt64(txtCash_Price.Text) + "','" + "پرداخت وجه نقد بابت فاکتور فروش شماره " + lblFactor_Code.Text + "','" + txtCash_Date.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number_For_Cash_Payement + "','" + "10301" + "',1,'" + lblFactor_Code.Text + "')";
                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query21) == true)
                    {
                        Form_Load();
                    }
                }
                else if (op == "Edit")
                {
                    string query = "UPDATE tbl_Pay_Of_Sales_Factor SET Price = '" + Convert.ToInt64(txtCash_Price.Text) + "', Date = '" + txtCash_Date.Text + "', Destination = N'" + cmbSafe.Text + "', Code='" + Safe_Code + "' WHERE ID='" + ID_Cash_Pay + "'";
                    string query1 = "UPDATE tbl_Transaction SET Code = '" + Safe_Code + "', Bedehkar = '" + Convert.ToInt64(txtCash_Price.Text) + "', Date = '" + txtCash_Date.Text + "' WHERE ID='" + ID_Cash_Trans + "'";
                    string query21 = "UPDATE tbl_Transaction SET Code = '" + lblCustomer_Code.Text + "', Bestankar = '" + Convert.ToInt64(txtCash_Price.Text) + "', Date = '" + txtCash_Date.Text + "' WHERE ID='" + ID_Cash_Trans_Customer + "'";
                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query21) == true)
                    {
                        Form_Load();
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

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + cmbBank.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Bank_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnIns_Bank_OP_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtBank_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else if (txtBank_Price.Text == "0")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مبلغ را وارد نمایید";
                f.ShowDialog();
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    Get_Max_Doc_Number_For_Bank_Payement();
                    string query = "INSERT INTO tbl_Pay_Of_Sales_Factor (ID_Factor, Time, Pay_Type, Price, Date, Destination, Fish_Number, Code) VALUES ('" + Convert.ToInt64(lblFactor_Code.Text) + "','" + System.DateTime.Now.ToLongTimeString() + "',2,'" + Convert.ToInt64(txtBank_Price.Text) + "','" + txtBank_Date.Text + "',N'" + cmbBank.Text + "','" + txtFish_Number.Text + "','" + Bank_Code + "')";
                    string query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Bank_Code + "','" + Convert.ToInt64(txtBank_Price.Text) + "','" + "دریافت وجه طی فیش " + txtFish_Number.Text + " " + "بابت فاکتور شماره " + lblFactor_Code.Text + "','" + txtBank_Date.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number_For_Bank_Payement + "','" + "10101" + "',1,'" + lblFactor_Code.Text + "')";
                    string query21 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblCustomer_Code.Text + "','" + Convert.ToInt64(txtBank_Price.Text) + "','" + "پرداخت وجه طی فیش " + txtFish_Number.Text + " " + "بابت فاکتور شماره " + lblFactor_Code.Text + "','" + txtBank_Date.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number_For_Bank_Payement + "','" + "30101" + "',1,'" + lblFactor_Code.Text + "')";
                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query21) == true)
                    {
                        Form_Load();
                        TabControl.SelectedTab = superTabItem2;
                    }
                }
                else if (op == "Edit")
                {
                    string query = "UPDATE tbl_Pay_Of_Sales_Factor SET Price = '" + Convert.ToInt64(txtBank_Price.Text) + "', Date = '" + txtBank_Date.Text + "', Destination = N'" + cmbBank.Text + "', Fish_Number='" + txtFish_Number.Text + "', Code='" + Bank_Code + "' WHERE ID='" + ID_Bank_Pay + "'";
                    string query1 = "UPDATE tbl_Transaction SET Code = '" + Bank_Code + "', Bedehkar = '" + Convert.ToInt64(txtBank_Price.Text) + "', Date = '" + txtBank_Date.Text + "' WHERE ID='" + ID_Bank_Trans + "'";
                    string query21 = "UPDATE tbl_Transaction SET Code = '" + Bank_Code + "', Bedehkar = '" + Convert.ToInt64(txtBank_Price.Text) + "', Date = '" + txtBank_Date.Text + "' WHERE ID='" + ID_Bank_Trans_Customer + "'";
                    if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query1) == true)
                    {
                        Form_Load();
                        TabControl.SelectedTab = superTabItem2;
                    }
                }
            }
        }

        private void txtCash_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtCash_Price);
        }

        private void txtBank_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBank_Price);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int SUM = Convert.ToInt32(lblSum_Bank.Text) + Convert.ToInt32(lblSum_Cash.Text);
            frmMessage f = new frmMessage();
            f.flag = 1;
            f.lblMessage.Text = "مجموع مبالغ دریافتی " + SUM.ToString() + " " + "ریال" + " " + "می باشد. آیا ادامه می دهید؟";
            f.ShowDialog();
            if (f.Resault == 0)
            {
                this.Close();
            }
        }

        private void dgvCash_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvCash.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void dgvBank_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvBank.Rows[e.RowIndex].Cells["Bank_Radif"].Value = e.RowIndex + 1;
        }

        private void txtBank_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnIns_Bank_OP_Click(null, null);
        }

        private void txtCash_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnIns_Cash_OP_Click(null, null);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                op = "Edit";
                cmbSafe.SelectedItem = dgvCash.CurrentRow.Cells["Destination"].Value.ToString();
                txtCash_Date.Text = dgvCash.CurrentRow.Cells["Date"].Value.ToString();
                txtCash_Price.Text = dgvCash.CurrentRow.Cells["Price"].Value.ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description='" + dgvCash.CurrentRow.Cells["Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + dt.Rows[0].ItemArray[0].ToString() + "' AND Bedehkar='" + Convert.ToInt64(dgvCash.CurrentRow.Cells["Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ID_Cash_Trans = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT ID FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + lblFactor_Code.Text + "' AND Pay_Type=1 AND Price='" + Convert.ToInt64(dgvCash.CurrentRow.Cells["Price"].Value) + "' AND Destination=N'" + dgvCash.CurrentRow.Cells["Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                ID_Cash_Pay = Convert.ToInt64(dt3.Rows[0].ItemArray[0]);
                SqlDataAdapter da12 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + lblCustomer_Code.Text + "' AND Bestankar='" + Convert.ToInt64(dgvCash.CurrentRow.Cells["Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                ID_Cash_Trans_Customer = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
            }
            catch
            {
            }
        }

        private void mnuBank_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                op = "Edit";
                cmbBank.SelectedItem = dgvBank.CurrentRow.Cells["Bank_Destination"].Value.ToString();
                txtBank_Date.Text = dgvBank.CurrentRow.Cells["Bank_Date"].Value.ToString();
                txtBank_Price.Text = dgvBank.CurrentRow.Cells["Bank_Price"].Value.ToString();
                txtFish_Number.Text = dgvBank.CurrentRow.Cells["Fish_Number"].Value.ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description='" + dgvBank.CurrentRow.Cells["Bank_Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + dt.Rows[0].ItemArray[0].ToString() + "' AND Bedehkar='" + Convert.ToInt64(dgvBank.CurrentRow.Cells["Bank_Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ID_Bank_Trans = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT ID FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + lblFactor_Code.Text + "' AND Pay_Type=2 AND Price='" + Convert.ToInt64(dgvBank.CurrentRow.Cells["Bank_Price"].Value) + "' AND Destination=N'" + dgvBank.CurrentRow.Cells["Bank_Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                ID_Bank_Pay = Convert.ToInt64(dt3.Rows[0].ItemArray[0]);
                SqlDataAdapter da21 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + lblCustomer_Code.Text + "' AND Bestankar='" + Convert.ToInt64(dgvBank.CurrentRow.Cells["Bank_Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt21 = new DataTable();
                da21.Fill(dt21);
                ID_Bank_Trans_Customer = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
            }
            catch
            {
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description='" + dgvCash.CurrentRow.Cells["Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + dt.Rows[0].ItemArray[0].ToString() + "' AND Bedehkar='" + Convert.ToInt64(dgvCash.CurrentRow.Cells["Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ID_Cash_Trans = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT ID FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + lblFactor_Code.Text + "' AND Pay_Type=1 AND Price='" + Convert.ToInt64(dgvCash.CurrentRow.Cells["Price"].Value) + "' AND Destination=N'" + dgvCash.CurrentRow.Cells["Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                ID_Cash_Pay = Convert.ToInt64(dt3.Rows[0].ItemArray[0]);
                SqlDataAdapter da12 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + lblCustomer_Code.Text + "' AND Bestankar='" + Convert.ToInt64(dgvCash.CurrentRow.Cells["Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                ID_Cash_Trans_Customer = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
                string query = "DELETE FROM tbl_Pay_Of_Sales_Factor WHERE ID='" + ID_Cash_Pay + "'";
                string query1 = "DELETE FROM tbl_Transaction WHERE ID='" + ID_Cash_Trans + "'";
                string query21 = "DELETE FROM tbl_Transaction WHERE ID='" + ID_Cash_Trans_Customer + "'";
                try
                {
                    frmMessage f = new frmMessage();
                    f.flag = 1;
                    f.lblMessage.Text = "آیا از حذف دریافت نقدی به مبلغ " + dgvCash.CurrentRow.Cells["Price"].Value.ToString() + " " + "و به مقصد " + dgvCash.CurrentRow.Cells["Destination"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query21) == true)
                            Form_Load();
                    }
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما مجاز به حذف ردیف نمی باشید";
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void mnuBank_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description='" + dgvBank.CurrentRow.Cells["Bank_Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + dt.Rows[0].ItemArray[0].ToString() + "' AND Bedehkar='" + Convert.ToInt64(dgvBank.CurrentRow.Cells["Bank_Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ID_Bank_Trans = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT ID FROM tbl_Pay_Of_Sales_Factor WHERE ID_Factor='" + lblFactor_Code.Text + "' AND Pay_Type=2 AND Price='" + Convert.ToInt64(dgvBank.CurrentRow.Cells["Bank_Price"].Value) + "' AND Destination=N'" + dgvBank.CurrentRow.Cells["Bank_Destination"].Value.ToString() + "'", dataconnection);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                ID_Bank_Pay = Convert.ToInt64(dt3.Rows[0].ItemArray[0]);
                SqlDataAdapter da21 = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + lblCustomer_Code.Text + "' AND Bestankar='" + Convert.ToInt64(dgvBank.CurrentRow.Cells["Bank_Price"].Value) + "' AND Parent=1 AND Parent_Code='" + lblFactor_Code.Text + "'", dataconnection);
                DataTable dt21 = new DataTable();
                da21.Fill(dt21);
                ID_Bank_Trans_Customer = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
                string query = "DELETE FROM tbl_Pay_Of_Sales_Factor WHERE ID='" + ID_Bank_Pay + "'";
                string query1 = "DELETE FROM tbl_Transaction WHERE ID='" + ID_Bank_Trans + "'";
                string query12 = "DELETE FROM tbl_Transaction WHERE ID='" + ID_Bank_Trans_Customer + "'";
                try
                {
                    frmMessage f = new frmMessage();
                    f.flag = 1;
                    f.lblMessage.Text = "آیا از حذف فیش به مبلغ " + dgvBank.CurrentRow.Cells["Bank_Price"].Value.ToString() + " " + "و به مقصد " + dgvBank.CurrentRow.Cells["Bank_Destination"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query12) == true)
                        {
                            Form_Load();
                            TabControl.SelectedTab = superTabItem2;
                        }
                    }
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما مجاز به حذف ردیف نمی باشید";
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void dgvCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                mnuDelete_Click(null, null);
            }
        }

        private void dgvBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                mnuBank_Delete_Click(null, null);
            }
        }

        private void txtCash_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtBank_Price_KeyPress(object sender, KeyPressEventArgs e)
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
