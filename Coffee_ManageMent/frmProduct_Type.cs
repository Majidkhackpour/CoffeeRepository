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
    public partial class frmProduct_Type : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Type_Name;
        int s_Type_Code, Counter_Name;
        public void Form_Load()
        {
            txtDescription.Text = "";
            string query = "SELECT MAX (Type_Code) FROM tbl_Product_Type";
            clsFunction.Numeric_Up_Down_NewCode(dataconnection, query, txtCode, "1");
        }
        private bool Check_Type_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Type_Code FROM tbl_Product_Type WHERE Type_Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Type_Code = (int)dr["Type_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Type_Code == Convert.ToInt32(txtCode.Text))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Type_Name()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Description FROM tbl_Product_Type WHERE Description LIKE N'" + txtDescription.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Type_Name = (string)dr["Description"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Type_Name == txtDescription.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Type_Name_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Description) FROM tbl_Product_Type WHERE Description LIKE N'" + txtDescription.Text.Trim() + "'", dataconnection);
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
        public void FillData(string Name)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Type_Code FROM tbl_Product_Type WHERE Description LIKE N'" + Name + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDescription.Text = Name;
            txtCode.Value = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            txtCode.Enabled = false;
        }
        public frmProduct_Type()
        {
            InitializeComponent();
        }

        private void frmProduct_Type_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Description FROM tbl_Product_Type", dataconnection, txtDescription);
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

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDescription.Focus();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtDescription, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    if (Check_Type_Code() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "طبقه بندی شماره ی " + txtCode.Text + " " + "از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else if (Check_Type_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "طبقه بندی با نام  " + txtDescription.Text + " " + "از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Product_Type (Type_Code, Description) VALUES ('" + Convert.ToInt32(txtCode.Value) + "',N'" + txtDescription.Text.Trim() + "')";
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
                        f.lblMessage.Text = "طبقه بندی با نام  " + txtDescription.Text + " " + "از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "UPDATE tbl_Product_Type SET Description = N'" + txtDescription.Text.Trim() + "' WHERE Type_Code = '" + Convert.ToInt32(txtCode.Value) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            this.Close();
                    }
                }
            }
        }
    }
}
