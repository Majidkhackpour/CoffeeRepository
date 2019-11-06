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
    public partial class frmBank : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Code, s_Acc_Number;
        int Bank_Type, s_Bank_Type, Branh_counter, Poss;
        private void Document()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Moeen=101 AND Parent_Code=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Bedehkar FROM tbl_Transaction WHERE Parent_Code=1 AND Code='" + txtCode.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                try
                {
                    string q = "UPDATE tbl_Transaction SET Bestankar=Bestankar+'" + Convert.ToInt64(dt2.Rows[0].ItemArray[0]) + "' WHERE ID='" + Convert.ToInt32(dt.Rows[0].ItemArray[0]) + "'";
                    if (clsFunction.Execute(dataconnection, q) == true)
                    {
                    }
                }
                catch
                {
                    string q = "INSERT INTO tbl_Transaction (Bestankar, Notice, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(dt2.Rows[0].ItemArray[0]) + "',N'" + "موجودی نقدی" + "','" + 1 + "','" + 101 + "','" + 0 + "','" + 1 + "')";
                    if (clsFunction.Execute(dataconnection, q) == true)
                    {
                    }
                }
            }
            catch
            {
            }
        }
        private void Delete_Document()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Moeen=101 AND Parent_Code=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Bedehkar FROM tbl_Transaction WHERE Parent_Code=1 AND Code='" + txtCode.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                try
                {
                    string q = "UPDATE tbl_Transaction SET Bestankar=Bestankar-'" + Convert.ToInt64(dt2.Rows[0].ItemArray[0]) + "' WHERE ID='" + Convert.ToInt32(dt.Rows[0].ItemArray[0]) + "'";
                    if (clsFunction.Execute(dataconnection, q) == true)
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
        public void Form_Load()
        {
            cmbAcc_Type.Items.Clear();
            txtAcc_Number.Text = txtBank_Branch.Text = txtBranch_Code.Text = "";
            txtCode.Text = txtName.Text = "";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            txtEntity.Text = "0";
            txtLetter_Cash.Text = "صفر ریال";
            chbPoss.Checked = false;
            string Query = "SELECT Type_Name FROM tbl_Bank_Acc_Type";
            string s_obj = "Type_Name";
            clsFunction.FillComboBox(dataconnection, Query, cmbAcc_Type, s_obj);
            cmbAcc_Type.SelectedIndex = 0;
            string query2 = "SELECT MAX (ID) FROM tbl_Bank";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "100");
        }
        private bool Check_Account_On_Bank()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code, Account_Type FROM tbl_Bank WHERE Code='" + txtCode.Text + "' AND Account_Type='" + Bank_Type + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Code = (string)dr["Code"];
                        s_Bank_Type = (int)dr["Account_Type"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Code == txtCode.Text && s_Bank_Type == Bank_Type)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Branch_Count()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Branch_Code) FROM tbl_Bank WHERE Branch_Code='" + Convert.ToInt32(txtBranch_Code.Text) + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Branh_counter = (int)dr[0];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (Branh_counter > 2)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Account_Number()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Account_Number FROM tbl_Bank WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Number = (string)dr["Account_Number"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Acc_Number == txtAcc_Number.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Code, Date, Bank_Branch, Account_Number, Branch_Code, Account_Type, Poss FROM tbl_Bank WHERE ID ='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[1].ToString();
            txtBank_Branch.Text = dt.Rows[0].ItemArray[2].ToString();
            txtAcc_Number.Text = dt.Rows[0].ItemArray[3].ToString();
            txtBranch_Code.Text = dt.Rows[0].ItemArray[4].ToString();
            cmbAcc_Type.SelectedIndex = Convert.ToInt32(dt.Rows[0].ItemArray[5].ToString());
            if (dt.Rows[0].ItemArray[6].ToString() == "0")
                chbPoss.Checked = true;
            else
                chbPoss.Checked = false;
            grp1.Enabled = false;
            cmbAcc_Type.Enabled = false;
            txtAcc_Number.Enabled = false;
        }
        public frmBank()
        {
            InitializeComponent();
        }

        private void frmBank_Load(object sender, EventArgs e)
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

        private void cmbAcc_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Account_Type FROM tbl_Bank_Acc_Type WHERE Type_Name LIKE N'" + cmbAcc_Type.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Bank_Type = (int)dr["Account_Type"];
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description, Bedehkar FROM tbl_Account WHERE Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
                txtBank_Branch.Text = dt.Rows[0].ItemArray[0].ToString();
                txtEntity.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                txtName.Text = txtEntity.Text = txtBank_Branch.Text = "";
            }
        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "Bank";
                f.Fill_Bank();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
                txtCode.Text = "";
                txtEntity.Text = "0";
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
                txtBank_Branch.Focus();
        }

        private void txtBank_Branch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBranch_Code.Focus();
        }

        private void txtBranch_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtAcc_Number.Focus();
        }

        private void txtAcc_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbAcc_Type.Focus();
        }

        private void cmbAcc_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtEntity.Focus();
        }

        private void txtEntity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                chbPoss.Focus();
        }

        private void chbPoss_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtBranch_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtAcc_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtEntity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtEntity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtEntity);
                txtLetter_Cash.Text = Num2Text.ToFarsi(Convert.ToInt64(txtEntity.Text)) + " " + "ریال";
            }
            catch
            {
                txtLetter_Cash.Text = "صفر ریال";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string query1, query2, query3;
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBranch_Code, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.Error_Provider(txtAcc_Number, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtEntity, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                string SubString = txtCode.Text.Substring(0, 2);
                if (SubString != "10")
                {
                    clsFunction.Show_OtherError(txtName, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    if (chbPoss.Checked)
                        Poss = 0;
                    else
                        Poss = 1;
                    if (op == "Add")
                    {
                        if (Check_Account_On_Bank() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = txtName.Text + " " + "با نوع حساب " + " " + cmbAcc_Type.Text + " " + "از پیش تعریف شده است";
                            f.ShowDialog();
                        }
                        else if (Check_Branch_Count() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = "تعداد حساب های مجاز برای حساب بانکی " + txtName.Text + " " + "در یک شعبه، به اتمام رسیده است";
                            f.ShowDialog();
                        }
                        else if (Check_Account_Number() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = "شماره حساب " + txtAcc_Number.Text + " " + " از پیش تعریف شده است";
                            f.ShowDialog();
                        }
                        else
                        {
                            query1 = "INSERT INTO tbl_Bank (Code, Date, Bank_Branch, Account_Number, Branch_Code, Account_Type, Poss, ID) VALUES ('" + txtCode.Text + "','" + txtDate.Text + "',N'" + txtBank_Branch.Text + "','" + txtAcc_Number.Text + "','" + txtBranch_Code.Text + "','" + Bank_Type + "','" + Poss + "','" + Convert.ToInt32(txtID.Text) + "')";
                            query2 = "UPDATE tbl_Account SET Bedehkar = '" + Convert.ToInt64(txtEntity.Text) + "' WHERE Code = '" + txtCode.Text + "'";
                            query3 = "UPDATE tbl_Transaction SET Bedehkar = '" + Convert.ToInt64(txtEntity.Text) + "', Moeen='"+"10101"+"' WHERE Code = '" + txtCode.Text + "' AND Notice = '" + "ثبت سند افتتاحیه" + "'";
                            if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                            {
                                Document();
                                this.Close();
                            }
                        }
                    }
                    else if (op == "Edit")
                    {
                        Delete_Document();
                        query1 = "UPDATE tbl_Account SET Bedehkar = '" + Convert.ToInt64(txtEntity.Text) + "' WHERE Code = '" + txtCode.Text + "'";
                        query2 = "UPDATE tbl_Transaction SET Bedehkar = '" + Convert.ToInt64(txtEntity.Text) + "', Moeen='" + "10101" + "' WHERE Code = '" + txtCode.Text + "' AND Notice = '" + "ثبت سند افتتاحیه" + "'";
                        query3 = "UPDATE tbl_Bank SET Date = '" + txtDate.Text + "', Bank_Branch = N'" + txtBank_Branch.Text + "', Account_Number = '" + txtAcc_Number.Text + "', Branch_Code = '" + txtBranch_Code.Text + "', Account_Type = '" + Bank_Type + "', Poss = '" + Poss + "' WHERE ID = '" + Convert.ToInt32(txtID.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                        {
                            Document();
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
