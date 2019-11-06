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
    public partial class frmTables_Unique : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Table_Name, s_Table_Code;
        public void Form_Load()
        {
            txtCode.Text = txtName.Text = txtChair.Text = "";
            string query2 = "SELECT MAX (Table_Code) FROM tbl_Tables";
            clsFunction.txt_NewCode(dataconnection, query2, txtCode, "1");
        }
        private bool Check_Table_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Table_Code FROM tbl_Tables WHERE Table_Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Table_Code = (string)dr["Table_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Table_Code == txtCode.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void Set_Table_Name()
        {
            try
            {
                Table_Name = Num2Text.ToFarsi(Convert.ToInt64(txtChair.Text));
                txtName.Text = "میز شماره ی " + txtCode.Text + " " + Table_Name + " " + "نفره";
            }
            catch
            {
                txtName.Text = "";
            }
        }
        public void FillData(string Code)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Table_Name, Table_Chair FROM tbl_Tables WHERE Table_Code LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code;
            txtChair.Text = dt.Rows[0].ItemArray[1].ToString();
            txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            txtCode.Enabled = false;
        }
        public frmTables_Unique()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTables_Unique_Load(object sender, EventArgs e)
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
            Set_Table_Name();
        }

        private void txtChair_TextChanged(object sender, EventArgs e)
        {
            Set_Table_Name();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtCode, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtChair, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    if (Check_Table_Code() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "میز شماره ی " + txtCode.Text + " " + "از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Tables (Table_Code, Table_Name, Table_Chair, Table_State) VALUES ('" + Convert.ToInt32(txtCode.Text) + "',N'" + txtName.Text + "','" + Convert.ToInt32(txtChair.Text) + "',0)";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            this.Close();
                    }
                }
                else if (op == "Edit")
                {
                    string query = "UPDATE tbl_Tables SET Table_Name = N'" + txtName.Text + "', Table_Chair = '" + Convert.ToInt32(txtChair.Text) + "' WHERE Table_Code ='" + Convert.ToInt32(txtCode.Text) + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtChair.Focus();
        }

        private void txtChair_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtChair_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
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
