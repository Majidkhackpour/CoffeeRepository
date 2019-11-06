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
    public partial class frmTables_Group : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Table_Name;
        public void Form_Load()
        {
            txtCode.Text = txtChair.Text = txtCode1.Text = "";
            string query2 = "SELECT MAX (Table_Code) FROM tbl_Tables";
            clsFunction.Numeric_Up_Down_NewCode(dataconnection, query2, txtCode, "1");
            txtCode1.Value = txtCode.Value + 1;
        }
        public void Form_Load_For_Edit()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Table_Code) FROM tbl_Tables", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode1.Value = Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
            txtCode.Value = 1;
        }
        public frmTables_Group()
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

        private void frmTables_Group_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtChair, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || txtCode.Value.ToString() == "" || txtCode1.Value.ToString() == "")
            {
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    for (int i = Convert.ToInt32(txtCode.Value); i <= Convert.ToInt32(txtCode1.Value); i++)
                    {
                        try
                        {
                            Table_Name = "میز شماره ی " + i + " " + Num2Text.ToFarsi(Convert.ToInt64(txtChair.Text)) + " " + "نفره";
                            string query = "INSERT INTO tbl_Tables (Table_Code, Table_Name, Table_Chair, Table_State) VALUES ('" + i + "',N'" + Table_Name + "','" + Convert.ToInt32(txtChair.Text) + "',0)";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                            }
                        }
                        catch
                        {
                        }
                    }
                    this.Close();
                }
                else if (op == "Edit")
                {
                    for (int i = Convert.ToInt32(txtCode.Value); i <= Convert.ToInt32(txtCode1.Value); i++)
                    {
                        try
                        {
                            Table_Name = "میز شماره ی " + i + " " + Num2Text.ToFarsi(Convert.ToInt64(txtChair.Text)) + " " + "نفره";
                            string query = "UPDATE tbl_Tables SET Table_Name = N'" + Table_Name + "', Table_Chair = '" + Convert.ToInt32(txtChair.Text) + "' WHERE Table_Code ='" + i + "'";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                            }
                        }
                        catch
                        {
                        }
                    }
                    this.Close();
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode1.Focus();
        }

        private void txtCode1_KeyDown(object sender, KeyEventArgs e)
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
    }
}
