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
using JntNum2Text;

namespace Coffee_ManageMent
{
    public partial class frmSafe : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op,s_Safe_Code;
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
            txtBedehkar.Text = "0";
            txtLetter_Cash.Text = "صفر ریال";
        }
        private bool Check_Safe_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Safe WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Safe_Code = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Safe_Code == txtCode.Text)
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT Description, Bedehkar FROM tbl_Account WHERE Code LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code;
            txtBedehkar.Text = dt.Rows[0].ItemArray[1].ToString();
            txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            txtCode.Enabled = false;
            btnSearchAcc.Enabled = false;
        }
        public frmSafe()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSafe_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description, Bedehkar FROM tbl_Account WHERE Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
                txtBedehkar.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                txtName.Text = txtBedehkar.Text = "";
            }
        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "Safe";
                f.Fill_Safe();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
                txtCode.Text = "";
                txtBedehkar.Text = "0";
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
                if (SubString != "20")
                {
                    clsFunction.Show_OtherError(txtCode, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    if (op == "Add")
                    {
                        if (Check_Safe_Code() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = txtName.Text + " " + "از پیش تعریف شده است";
                            f.ShowDialog();
                        }
                        else
                        {
                            query1 = "UPDATE tbl_Account SET Bedehkar = '" + Convert.ToInt64(txtBedehkar.Text) + "' WHERE Code = '" + txtCode.Text + "'";
                            query2 = "UPDATE tbl_Transaction SET Bedehkar = '" + Convert.ToInt64(txtBedehkar.Text) + "', Moeen='" + "10102" + "' WHERE Code = '" + txtCode.Text + "' AND Notice = '" + "ثبت سند افتتاحیه" + "'";
                            query3 = "INSERT INTO tbl_Safe (Code) VALUES ('" + txtCode.Text + "')";
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
                        query1 = "UPDATE tbl_Account SET Bedehkar = '" + Convert.ToInt64(txtBedehkar.Text) + "' WHERE Code = '" + txtCode.Text + "'";
                        query2 = "UPDATE tbl_Transaction SET Bedehkar = '" + Convert.ToInt64(txtBedehkar.Text) + "', Moeen='" + "10102" + "' WHERE Code = '" + txtCode.Text + "' AND Notice = '" + "ثبت سند افتتاحیه" + "'";
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            Document();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void txtBedehkar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtBedehkar);
                txtLetter_Cash.Text = Num2Text.ToFarsi(Convert.ToInt64(txtBedehkar.Text)) + " " + "ریال";
            }
            catch
            {
                txtLetter_Cash.Text = "صفر ریال";
            }
        }

        private void txtBedehkar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBedehkar.Focus();
        }

        private void txtBedehkar_KeyDown(object sender, KeyEventArgs e)
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
    }
}
