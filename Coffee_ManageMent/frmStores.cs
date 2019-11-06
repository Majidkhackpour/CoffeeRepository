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
    public partial class frmStores : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Store_Name, s_Store_Code;
        public int Type, Counter_Name;
        public void Form_Load()
        {
            cmbType.Items.Clear();
            txtName.Text = "";
            string query = "SELECT MAX (Code) FROM tbl_Store";
            clsFunction.txt_NewCode(dataconnection, query, txtCode, "600001");
            string Query = "SELECT Type_Name FROM tbl_Store_Type";
            string s_obj = "Type_Name";
            clsFunction.FillComboBox(dataconnection, Query, cmbType, s_obj);
            cmbType.SelectedIndex = 0;
        }
        private bool Check_StoreName()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Name FROM tbl_Store WHERE Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Store_Name = (string)dr["Name"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Store_Name == txtName.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_StoreCode()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Store WHERE Code='" + txtCode.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Store_Code = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Store_Code == txtCode.Text.Trim())
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_StoreName_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Name) FROM tbl_Store WHERE Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
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
        public void FillData(string Code)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Name, Type FROM tbl_Store WHERE Code LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code;
            txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            if (dt.Rows[0].ItemArray[1].ToString() == "1")
                cmbType.SelectedIndex = 0;
            else if (dt.Rows[0].ItemArray[1].ToString() == "2")
                cmbType.SelectedIndex = 1;
            else if (dt.Rows[0].ItemArray[1].ToString() == "3")
                cmbType.SelectedIndex = 2;
            else if (dt.Rows[0].ItemArray[1].ToString() == "4")
                cmbType.SelectedIndex = 3;
            else if (dt.Rows[0].ItemArray[1].ToString() == "5")
                cmbType.SelectedIndex = 4;
            else if (dt.Rows[0].ItemArray[1].ToString() == "6")
                cmbType.SelectedIndex = 5;
            txtCode.Enabled = false;
        }
        public frmStores()
        {
            InitializeComponent();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type FROM tbl_Store_Type WHERE Type_Name LIKE N'" + cmbType.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Type = (int)dr["Type"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void frmStores_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Name FROM tbl_Store", dataconnection, txtName);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if ((clsFunction.Error_Provider(txtCode, errorProvider1, "این فیلد نمی تواند خالی باشد") == true) || (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true))
            {
                txtName.Focus();
            }
            else
            {
                errorProvider1.Clear();
                string Show_Name = txtName.Text + " " + "( " + cmbType.Text + " )";
                if (op == "Add")
                {
                    if (Check_StoreCode() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "کد انبار تکراری است";
                        f.ShowDialog();
                    }
                    else if (Check_StoreName() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "انبار " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Store (Code, Name, Shown_Name, Type) VALUES ('" + txtCode.Text.Trim() + "',N'" + txtName.Text.Trim() + "',N'" + Show_Name + "','" + Type + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            this.Close();
                        }
                    }
                }
                else if (op == "Edit")
                {
                    if (Check_StoreName_ForEdit() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "انبار " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "UPDATE tbl_Store SET Name = N'"+txtName.Text.Trim()+"', Shown_Name = N'"+Show_Name+"', Type = '"+Type+"' WHERE Code = '"+txtCode.Text+"'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
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
                txtName.Focus();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbType.Focus();
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
