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
    public partial class frmAccount : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public int flag, Counetr_Name;
        public string op, s_Acc_Name;
        public void Form_Load()
        {
            cmbAccount.Items.Clear();
            txtAccCode.Text = txtDescription.Text = lblAccCode.Text = "";
            txtBedehkar.Text = txtBestankar.Text = "0";
            string Query = "SELECT Parent_Name FROM tbl_MoeenAccount";
            string s_obj = "Parent_Name";
            clsFunction.FillComboBox(dataconnection, Query, cmbAccount, s_obj);
            cmbAccount.SelectedIndex = 0;
            string query2 = "SELECT MAX (Code) FROM tbl_Account WHERE Parent ='" + lblAccCode.Text + "'";
            clsFunction.txt_NewCode(dataconnection, query2, txtAccCode, "0001");
            if (txtAccCode.Text.Length > 4)
                txtAccCode.Text = txtAccCode.Text.Remove(0, 2);
        }
        private bool Check_AccountName()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Description FROM tbl_Account WHERE Description LIKE N'" + txtDescription.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Name = (string)dr["Description"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Acc_Name == txtDescription.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_AccountName_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Description) FROM tbl_Account WHERE Description LIKE N'" + txtDescription.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Counetr_Name = (int)dr[0];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (Counetr_Name > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public void FillData(string Name)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Code, Parent, Bedehkar, Bestankar FROM tbl_Account WHERE Description LIKE N'" + Name + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            flag = 1;
            txtDescription.Text = Name;
            txtAccCode.Text = dt.Rows[0].ItemArray[0].ToString();
            lblAccCode.Text = dt.Rows[0].ItemArray[1].ToString();
            txtBedehkar.Text = dt.Rows[0].ItemArray[2].ToString();
            txtBestankar.Text = dt.Rows[0].ItemArray[3].ToString();
            txtAccCode.Text = txtAccCode.Text.Remove(0, 2);
            if (lblAccCode.Text == "10")
                cmbAccount.SelectedIndex = 0;
            else if (lblAccCode.Text == "20")
                cmbAccount.SelectedIndex = 1;
            else if (lblAccCode.Text == "30")
                cmbAccount.SelectedIndex = 2;
            else if (lblAccCode.Text == "40")
                cmbAccount.SelectedIndex = 3;
            else if (lblAccCode.Text == "50")
                cmbAccount.SelectedIndex = 4;
            cmbAccount.Enabled = false;
        }
        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Parent_Code FROM tbl_MoeenAccount WHERE Parent_Name LIKE N'" + cmbAccount.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblAccCode.Text = ((int)dr["Parent_Code"]).ToString();
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
            if (flag == 0)
            {
                string query2 = "SELECT MAX (Code) FROM tbl_Account WHERE Parent ='" + lblAccCode.Text + "'";
                clsFunction.txt_NewCode(dataconnection, query2, txtAccCode, "0001");
                if (txtAccCode.Text.Length > 4)
                    txtAccCode.Text = txtAccCode.Text.Remove(0, 2);
            }
            flag = 0;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDescription.Focus();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBedehkar.Focus();
        }

        private void txtBedehkar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBestankar.Focus();
        }

        private void txtBestankar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtBedehkar_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBedehkar);
            try
            {
                if (Convert.ToInt32(txtBestankar.Text) == 0)
                {
                }
                else
                {
                    txtBestankar.Text = "0";
                    txtBedehkar.SelectAll();
                }
            }
            catch
            {
            }
        }

        private void txtBestankar_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBestankar);
            try
            {
                if (Convert.ToInt32(txtBedehkar.Text) == 0)
                {
                }
                else
                {
                    txtBedehkar.Text = "0";
                    txtBestankar.SelectAll();
                }
            }
            catch
            {
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

        private void txtBestankar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtDescription, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
                txtDescription.Focus();
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    if (Check_AccountName() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "حساب تفصیلی " + txtDescription.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Account (Code, Description, Parent, Bedehkar, Bestankar) VALUES ('" + lblAccCode.Text + txtAccCode.Text + "',N'" + txtDescription.Text.Trim() + "','" + Convert.ToInt32(lblAccCode.Text) + "','" + Convert.ToInt64(txtBedehkar.Text) + "','" + Convert.ToInt64(txtBestankar.Text) + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            if (txtBedehkar.Text != "0" || txtBestankar.Text != "0")
                            {
                                string query2 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Parent, Parent_Code) VALUES ('" + lblAccCode.Text + txtAccCode.Text + "','" + Convert.ToInt64(txtBedehkar.Text) + "','" + Convert.ToInt64(txtBestankar.Text) + "','" + "ثبت سند افتتاحیه" + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "',1,0,1)";
                                if (clsFunction.Execute(dataconnection, query2) == true)
                                    this.Close();
                            }
                            else
                                this.Close();
                        }
                    }
                }
                else if (op == "Edit")
                {
                    if (Check_AccountName_ForEdit() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "حساب تفصیلی " + txtDescription.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "UPDATE tbl_Account SET Description = N'" + txtDescription.Text.Trim() + "', Bedehkar = '" + Convert.ToInt64(txtBedehkar.Text) + "', Bestankar = '" + Convert.ToInt64(txtBestankar.Text) + "' WHERE Code = '" + lblAccCode.Text + txtAccCode.Text + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            if (txtBedehkar.Text != "0" || txtBestankar.Text != "0")
                            {
                                string query2 = "UPDATE tbl_Transaction SET Bedehkar = '" + Convert.ToInt64(txtBedehkar.Text) + "', Bestankar = '" + Convert.ToInt64(txtBestankar.Text) + "' WHERE Code = '" + lblAccCode.Text + txtAccCode.Text + "' AND Notice = '" + "ثبت سند افتتاحیه" + "'";
                                if (clsFunction.Execute(dataconnection, query2) == true)
                                    this.Close();
                            }
                            else
                                this.Close();
                        }
                    }
                }
            }
        }
    }
}
