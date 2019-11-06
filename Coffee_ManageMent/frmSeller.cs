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
    public partial class frmSeller : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Acc_Code, s_PhoneBook;
        private void Document()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Moeen=302 AND Parent_Code=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Bedehkar FROM tbl_Transaction WHERE Parent_Code=1 AND Code='" + txtCode.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                try
                {
                    string q = "UPDATE tbl_Transaction SET Bedehkar=Bedehkar+'" + Convert.ToInt64(dt2.Rows[0].ItemArray[0]) + "' WHERE ID='" + Convert.ToInt32(dt.Rows[0].ItemArray[0]) + "'";
                    if (clsFunction.Execute(dataconnection, q) == true)
                    {
                    }
                }
                catch
                {
                    string q = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(dt2.Rows[0].ItemArray[0]) + "',N'" + "حساب های پرداختنی" + "','" + 1 + "','" + 302 + "','" + 0 + "','" + 1 + "')";
                    if (clsFunction.Execute(dataconnection, q) == true)
                    {
                    }
                }
            }
            catch
            {
            }
        }
        private bool Check_Account_On_Seller()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Seller WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Code = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Acc_Code == txtCode.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Account_On_PhoneBook()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_PhoneBook WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_PhoneBook = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_PhoneBook == txtCode.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public void FillData(string Code)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Seller.Code, tbl_Seller.Address, tbl_Seller.Notice, tbl_Account.Description, tbl_PhoneBook.Phone, tbl_PhoneBook.Mobile, tbl_PhoneBook.Email FROM tbl_Seller INNER JOIN tbl_Account ON tbl_Seller.Code = tbl_Account.Code INNER JOIN tbl_PhoneBook ON tbl_Account.Code = tbl_PhoneBook.Code WHERE tbl_Seller.Code LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code;
            txtAddress.Text = dt.Rows[0].ItemArray[1].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[2].ToString();
            txtName.Text = dt.Rows[0].ItemArray[3].ToString();
            txtPhone.Text = dt.Rows[0].ItemArray[4].ToString();
            txtMobile.Text = dt.Rows[0].ItemArray[5].ToString();
            txtEmail.Text = dt.Rows[0].ItemArray[6].ToString();
            grpAccount.Enabled = false;
        }
        public frmSeller()
        {
            InitializeComponent();
        }

        private void frmSeller_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Mobile FROM tbl_PhoneBook", dataconnection, txtMobile);
            clsFunction.AutoComplete("SELECT Email FROM tbl_PhoneBook", dataconnection, txtEmail);
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
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                string SubString = txtCode.Text.Substring(0, 2);
                if (SubString != "30" && SubString != "40")
                {
                    clsFunction.Show_OtherError(txtCode, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else if ((txtMobile.Text.Length < 11 && txtMobile.Text.Length > 0) || clsFunction.Check_Mobile(txtMobile) == false)
                {
                    clsFunction.Show_OtherError(txtMobile, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else if (clsFunction.Check_Email(txtEmail) == false)
                {
                    clsFunction.Show_OtherError(txtEmail, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    string query1, query2, query3;
                    if (op == "Add")
                    {
                        errorProvider1.Clear();
                        if (Check_Account_On_PhoneBook() == false)
                        {
                            query1 = "INSERT INTO tbl_PhoneBook (Code, Phone, Mobile, Email, Group_ID, Name) VALUES ('" + txtCode.Text + "','" + txtPhone.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "',6,N'" + txtName.Text + "')";
                            if (clsFunction.Execute(dataconnection, query1) == true)
                            {
                            }
                        }
                        if (Check_Account_On_Seller() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = txtName.Text + " " + "از پیش تعریف شده است";
                            f.ShowDialog();
                        }
                        else if (Check_Account_On_Seller() == false)
                        {
                            query2 = "INSERT INTO tbl_Seller (Code, Address, Notice, State) VALUES ('" + txtCode.Text + "',N'" + txtAddress.Text + "',N'" + txtNotice.Text + "',0)";
                            query3 = "UPDATE tbl_Transaction SET Moeen='" + "30201" + "' WHERE Code = '" + txtCode.Text + "' AND Notice = '" + "ثبت سند افتتاحیه" + "'";
                            if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                            {
                                Document();
                                this.Close();
                            }
                        }
                    }
                    else if (op == "Edit")
                    {
                        query1 = "UPDATE tbl_Seller SET Address = N'" + txtAddress.Text + "', Notice = N'" + txtNotice.Text + "' WHERE Code = '" + txtCode.Text + "'";
                        query2 = "UPDATE tbl_PhoneBook SET Phone = '" + txtPhone.Text + "', Mobile = '" + txtMobile.Text + "', Email = '" + txtEmail.Text + "', Name=N'" + txtName.Text + "' WHERE Code = '" + txtCode.Text + "'";
                        query3 = "UPDATE tbl_Transaction SET Moeen='" + "30201" + "' WHERE Code = '" + txtCode.Text + "' AND Notice = '" + "ثبت سند افتتاحیه" + "'";
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_English();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_Persian();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPhone.Focus();
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMobile.Focus();
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtEmail.Focus();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtAddress.Focus();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Phone, Mobile, Email FROM tbl_PhoneBook WHERE Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtPhone.Text = dt.Rows[0].ItemArray[0].ToString();
                txtMobile.Text = dt.Rows[0].ItemArray[1].ToString();
                txtEmail.Text = dt.Rows[0].ItemArray[2].ToString();
            }
            catch
            {
                txtPhone.Text = txtMobile.Text = txtEmail.Text = "";
            }
        }
    }
}
