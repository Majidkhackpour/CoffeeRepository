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
    public partial class frmCus_Group : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Store_Name;
        int Counter_Name;
        public void Form_Load()
        {
            txtName.Text = "";
            string query = "SELECT MAX (ID) FROM tbl_Customer_Group";
            clsFunction.txt_NewCode(dataconnection, query, txtCode, "1");
        }
        private bool Check_Group_Name()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Name FROM tbl_Customer_Group WHERE Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
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
        private bool Check_Group_Name_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Name) FROM tbl_Customer_Group WHERE Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
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
        public void FillData(int Code)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Name FROM tbl_Customer_Group WHERE ID LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code.ToString();
            txtName.Text = dt.Rows[0].ItemArray[0].ToString();
        }
        public frmCus_Group()
        {
            InitializeComponent();
        }

        private void frmCus_Group_Load(object sender, EventArgs e)
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if ((clsFunction.Error_Provider(txtCode, errorProvider1, "این فیلد نمی تواند خالی باشد") == true) || (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true))
            {
                txtName.Focus();
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    if (Check_Group_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "گروه " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Customer_Group (ID, Name) VALUES ('" + txtCode.Text.Trim() + "',N'" + txtName.Text.Trim() + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            this.Close();
                        }
                    }
                }
                else if (op == "Edit")
                {
                    if (Check_Group_Name_ForEdit() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "گروه " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "UPDATE tbl_Customer_Group SET Name = N'" + txtName.Text.Trim() + "' WHERE ID = '" + txtCode.Text + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }
    }
}
