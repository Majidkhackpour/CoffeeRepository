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
    public partial class frmLoan : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        string Date, s_Acc_Number;
        private void Calculate_Date()
        {
            try
            {
                string Year = txtDate.Text.Substring(0, 4);
                int Y = Convert.ToInt32(Year);
                string Mounth = txtDate.Text.Substring(5, 2);
                int M = Convert.ToInt32(Mounth) + (Convert.ToInt32(txtInstall_Count.Text) - 1);
                if (M > 12)
                {
                    Y++;
                    M -= 12;
                }
                string Day = txtDate.Text.Substring(8, 2);
                if (M > 0 && M <= 9)
                {
                    Date = Y.ToString() + "/" + "0" + M.ToString() + "/" + Day;
                }
                else if (M > 9 && M <= 12)
                {
                    Date = Y.ToString() + "/" + M.ToString() + "/" + Day;
                }
                txtExpiration_Date.Text = Date;
            }
            catch
            {
                txtExpiration_Date.Text = "";
            }
        }
        public void Form_Load()
        {
            txtCode.Text = txtExpiration_Date.Text = txtName.Text = "";
            txtNumber.Text = txtType.Text = "";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            txtFirst_Install.Text = txtFirst_Price.Text = txtOther_Install.Text = txtProfit_Price.Text = "0";
            txtTotal_Price.Text = "0";
            txtProfit_Percent.Text = "4";
            txtInstall_Count.Text = "12";
        }
        public void FillData(string Code)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Number, Type, Expiration_Date, Profit_Percent, Profit_Price, First_Price, Install_Count, First_Install, Other_Install, Total_Price, First_Date FROM tbl_Header_Loan WHERE Code LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code;
            txtNumber.Text = dt.Rows[0].ItemArray[0].ToString();
            txtType.Text = dt.Rows[0].ItemArray[1].ToString();
            txtExpiration_Date.Text = dt.Rows[0].ItemArray[2].ToString();
            txtProfit_Percent.Text = dt.Rows[0].ItemArray[3].ToString();
            txtProfit_Price.Text = dt.Rows[0].ItemArray[4].ToString();
            txtFirst_Price.Text = dt.Rows[0].ItemArray[5].ToString();
            txtInstall_Count.Text = dt.Rows[0].ItemArray[6].ToString();
            txtFirst_Install.Text = dt.Rows[0].ItemArray[7].ToString();
            txtOther_Install.Text = dt.Rows[0].ItemArray[8].ToString();
            txtTotal_Price.Text = dt.Rows[0].ItemArray[9].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[10].ToString();
            grp1.Enabled = false;
        }
        private void Installment_Calculate()
        {
            try
            {
                int Sum = (Convert.ToInt32(txtTotal_Price.Text) - (((Convert.ToInt32(txtInstall_Count.Text)-1) * Convert.ToInt32(txtOther_Install.Text) + Convert.ToInt32(txtFirst_Install.Text))));
                txtProfit_Price.Text = Sum.ToString();
            }
            catch
            {
                txtProfit_Price.Text = "0";
            }
        }
        private bool Check_Account_Number()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Header_Loan WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Number = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Acc_Number == txtCode.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void Delete_Body()
        {
            try
            {
                string query = "DELETE FROM tbl_Body_Loan WHERE Code='" + txtCode.Text + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                }
            }
            catch
            {
            }
        }
        public frmLoan()
        {
            InitializeComponent();
        }

        private void frmLoan_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Type FROM tbl_Header_Loan", dataconnection, txtType);
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

        private void txtTotal_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtTotal_Price);
            Installment_Calculate();
        }

        private void txtInstall_Count_TextChanged(object sender, EventArgs e)
        {
            Installment_Calculate();
            Calculate_Date();
        }

        private void txtOther_Install_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtOther_Install);
            Installment_Calculate();
        }

        private void txtFirst_Install_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtFirst_Install);
            Installment_Calculate();
        }

        private void txtFirst_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtFirst_Price);
        }

        private void txtProfit_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtProfit_Price);
        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "Loan";
                f.Fill_Loan();
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtNumber, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.Error_Provider(txtType, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtFirst_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else if (clsFunction.Error_Provider(txtTotal_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtInstall_Count, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.Error_Provider(txtFirst_Install, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtOther_Install, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                string SubString = txtCode.Text.Substring(0, 2);
                if (SubString != "40")
                {
                    clsFunction.Show_OtherError(txtName, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    if (op == "Add")
                    {
                        if (Check_Account_Number() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = "این وام دریافتنی از پیش در سیستم ثبت شده است";
                            f.ShowDialog();
                        }
                        else
                        {
                            string query = "INSERT INTO tbl_Header_Loan (Code, Number, Type, Expiration_Date, Profit_Percent, Profit_Price, First_Price, Install_Count, First_Install, Other_Install, Total_Price, First_Date) VALUES ('" + txtCode.Text + "','" + txtNumber.Text + "',N'" + txtType.Text + "','" + txtDate.Text + "','" + float.Parse(txtProfit_Percent.Text) + "','" + Convert.ToInt64(txtProfit_Price.Text) + "','" + txtFirst_Price.Text + "','" + Convert.ToInt32(txtInstall_Count.Text) + "','" + Convert.ToInt64(txtFirst_Install.Text) + "','" + Convert.ToInt64(txtOther_Install.Text) + "','" + txtTotal_Price.Text + "','" + txtDate.Text + "')";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                                string query3 = "INSERT INTO tbl_Body_Loan (Code, Date, Price, State) VALUES ('" + txtCode.Text + "','" + txtDate.Text + "','" + Convert.ToInt64(txtFirst_Install.Text) + "',2)";
                                if (clsFunction.Execute(dataconnection, query3) == true)
                                {
                                    for (int i = 1; i < Convert.ToInt32(txtInstall_Count.Text); i++)
                                    {
                                        string Year = txtDate.Text.Substring(0, 4);
                                        int Y = Convert.ToInt32(Year);
                                        string Mounth = txtDate.Text.Substring(5, 2);
                                        int M = Convert.ToInt32(Mounth) + i;
                                        if (M > 12)
                                        {
                                            Y++;
                                            M -= 12;
                                        }
                                        string Day = txtDate.Text.Substring(8, 2);
                                        if (M > 0 && M <= 9)
                                        {
                                            Date = Y.ToString() + "/" + "0" + M.ToString() + "/" + Day;
                                        }
                                        else if (M > 9 && M <= 12)
                                        {
                                            Date = Y.ToString() + "/" + M.ToString() + "/" + Day;
                                        }
                                        string query2 = "INSERT INTO tbl_Body_Loan (Code, Date, Price, State) VALUES ('" + txtCode.Text + "','" + Date + "','" + Convert.ToInt64(txtOther_Install.Text) + "',2)";
                                        if (clsFunction.Execute(dataconnection, query2) == true)
                                        {
                                        }
                                    }
                                }
                                this.Close();
                            }
                        }
                    }
                    else if (op == "Edit")
                    {
                        string query = "UPDATE tbl_Header_Loan SET Number = '" + txtNumber.Text + "', Type = N'" + txtType.Text + "', Expiration_Date = '" + txtDate.Text + "', Profit_Percent = '" + float.Parse(txtProfit_Percent.Text) + "', Profit_Price = '" + Convert.ToInt64(txtProfit_Price.Text) + "', First_Price = '" + txtFirst_Price.Text + "',  Install_Count = '" + Convert.ToInt32(txtInstall_Count.Text) + "', First_Install = '" + Convert.ToInt64(txtFirst_Install.Text) + "', Other_Install = '" + Convert.ToInt64(txtOther_Install.Text) + "', Total_Price = '" + txtTotal_Price.Text + "', First_Date = '" + txtDate.Text + "' WHERE Code = '" + txtCode.Text + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            Delete_Body();
                            string query3 = "INSERT INTO tbl_Body_Loan (Code, Date, Price, State) VALUES ('" + txtCode.Text + "','" + txtDate.Text + "','" + Convert.ToInt64(txtFirst_Install.Text) + "',2)";
                            if (clsFunction.Execute(dataconnection, query3) == true)
                            {
                                for (int i = 1; i < Convert.ToInt32(txtInstall_Count.Text); i++)
                                {
                                    string Year = txtDate.Text.Substring(0, 4);
                                    int Y = Convert.ToInt32(Year);
                                    string Mounth = txtDate.Text.Substring(5, 2);
                                    int M = Convert.ToInt32(Mounth) + i;
                                    if (M > 12)
                                    {
                                        Y++;
                                        M -= 12;
                                    }
                                    string Day = txtDate.Text.Substring(8, 2);
                                    if (M > 0 && M <= 9)
                                    {
                                        Date = Y.ToString() + "/" + "0" + M.ToString() + "/" + Day;
                                    }
                                    else if (M > 9 && M <= 12)
                                    {
                                        Date = Y.ToString() + "/" + M.ToString() + "/" + Day;
                                    }
                                    string query2 = "INSERT INTO tbl_Body_Loan (Code, Date, Price, State) VALUES ('" + txtCode.Text + "','" + Date + "','" + Convert.ToInt64(txtOther_Install.Text) + "',2)";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                            }
                            this.Close();
                        }
                    }
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNumber.Focus();
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtType.Focus();
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDate.Focus();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtExpiration_Date.Focus();
        }

        private void txtExpiration_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtFirst_Price.Focus();
        }

        private void txtFirst_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTotal_Price.Focus();
        }

        private void txtTotal_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtProfit_Percent.Focus();
        }

        private void txtProfit_Percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtInstall_Count.Focus();
        }

        private void txtInstall_Count_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtFirst_Install.Focus();
        }

        private void txtFirst_Install_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtOther_Install.Focus();
        }

        private void txtOther_Install_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtProfit_Price.Focus();
        }

        private void txtProfit_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
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

        private void txtFirst_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtTotal_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtFirst_Install_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtOther_Install_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtProfit_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtProfit_Percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtInstall_Count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            Calculate_Date();
        }
    }
}
