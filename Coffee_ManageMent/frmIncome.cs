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
    public partial class frmIncome : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Acc_Number;
        int Group_Code, Counter_Name;
        public void Form_Load()
        {
            string query2 = "SELECT MAX (ID) FROM tbl_Income";
            clsFunction.txt_NewCode(dataconnection, query2, txtAccCode, "6003001");
            txtBedehkar.Text = "0";
            txtDescription.Text = "";
            Fill_Group();
        }
        private void Fill_Group()
        {
            try
            {
                cmbAccount.Items.Clear();
                string Query = "SELECT Description FROM tbl_Income_Group";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbAccount, s_obj);
                cmbAccount.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private bool Check_Account_Number()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Inc_Name FROM tbl_Income WHERE Inc_Name='" + txtDescription.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Number = (string)dr["Inc_Name"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Acc_Number == txtDescription.Text)
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT Inc_Name, Price, Group_ID FROM tbl_Income WHERE ID ='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtAccCode.Text = ID.ToString();
            txtDescription.Text = dt.Rows[0].ItemArray[0].ToString();
            txtBedehkar.Text = dt.Rows[0].ItemArray[1].ToString();
            cmbAccount.SelectedIndex = Convert.ToInt32(dt.Rows[0].ItemArray[2]) - 1;
        }
        private bool Check_Type_Name_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Description) FROM tbl_Income WHERE Description LIKE N'" + txtDescription.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Counter_Name = (int)dr[0];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (Counter_Name > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmIncome()
        {
            InitializeComponent();
        }

        private void frmIncome_Load(object sender, EventArgs e)
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

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID FROM tbl_Income_Group WHERE Description LIKE N'" + cmbAccount.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Group_Code = (int)dr["ID"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtDescription, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBedehkar, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.CMB_Error_Provider(cmbAccount, errorProvider1, "ابتدا نسبت به درج گروه های درآمدی اقدام نمایید") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    if (Check_Account_Number() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = txtDescription.Text + " " + " از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Income (ID, Inc_Name, Group_ID, Price) VALUES ('" + Convert.ToInt32(txtAccCode.Text) + "',N'" + txtDescription.Text + "','" + Group_Code + "','" + Convert.ToInt64(txtBedehkar.Text) + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            this.Close();
                    }
                }
                else if (op == "Edit")
                {
                    if (Check_Type_Name_ForEdit() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "درآمد با نام  " + txtDescription.Text + " " + "از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        dataconnection.Close();
                        string query = "UPDATE tbl_Income SET Inc_Name = N'" + txtDescription.Text.Trim() + "', Group_ID = '" + Group_Code + "', Price = '" + Convert.ToInt64(txtBedehkar.Text) + "' WHERE ID = '" + Convert.ToInt32(txtAccCode.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            this.Close();
                    }
                }
            }
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDescription.Focus();
            else if (e.KeyData == Keys.F12)
            {
                try
                {
                    frmIncome_Group f = new frmIncome_Group();
                    f.Form_Load();
                    f.op = "Add";
                    f.ShowDialog();
                    Fill_Group();
                }
                catch
                {
                }
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBedehkar.Focus();
        }

        private void txtBedehkar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
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

        private void txtBedehkar_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBedehkar);
        }
    }
}
