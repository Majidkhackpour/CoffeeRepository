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
    public partial class frmCheck : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Check_Book;
        public void Form_Load()
        {
            txtCode.Text = txtEnd_Page.Text = txtID.Text = txtName.Text = "";
            txtPage_Count.Text = txtSeries.Text = txtStart_Page.Text = "";
            string query2 = "SELECT MAX (ID) FROM tbl_Check_Book";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "200");
        }
        public void Calculate()
        {
            try
            {
                txtEnd_Page.Text = (Convert.ToInt32(txtPage_Count.Text) + Convert.ToInt32(txtStart_Page.Text) - 1).ToString();
            }
            catch
            {
                txtEnd_Page.Text = "0";
            }
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Code, Page_Count, End_Page, Series, Start_Page FROM tbl_Check_Book WHERE ID ='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtPage_Count.Text = dt.Rows[0].ItemArray[1].ToString();
            txtEnd_Page.Text = dt.Rows[0].ItemArray[2].ToString();
            txtSeries.Text = dt.Rows[0].ItemArray[3].ToString();
            txtStart_Page.Text = dt.Rows[0].ItemArray[4].ToString();
            grp1.Enabled = false;
            groupPanel1.Enabled = false;
            btnFinish1.Enabled = false;
        }
        private bool Check_CheckBook()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Check_Book WHERE Code='" + txtCode.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Check_Book = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Check_Book == txtCode.Text.Trim())
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmCheck()
        {
            InitializeComponent();
        }

        private void frmCheck_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Page_Count FROM tbl_Check_Book", dataconnection, txtPage_Count);
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
                f.op = "Check";
                f.Fill_Check();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
                txtCode.Text = "";
            }
        }

        private void txtPage_Count_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtStart_Page_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtPage_Count, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtStart_Page, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.Error_Provider(txtEnd_Page, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.Error_Provider(txtSeries, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
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
                else if (txtPage_Count.Text == "0" || txtStart_Page.Text == "0")
                {
                    clsFunction.Show_OtherError(txtEnd_Page, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else if (Convert.ToInt32(txtEnd_Page.Text) <= 0)
                {
                    clsFunction.Show_OtherError(txtEnd_Page, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    if (op == "Add")
                    {
                        if (Check_CheckBook() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = "از این حساب دسته چک تعریف شده است";
                            f.ShowDialog();
                        }
                        else
                        {
                            string Name = "دسته چک " + txtPage_Count.Text + " " + "برگی سری " + txtSeries.Text;
                            dataconnection.Close();
                            string query = "INSERT INTO tbl_Check_Book (ID, Code, Page_Count, Start_Page, End_Page, Series, Empty, State, Check_Book_Desc) VALUES ('" + Convert.ToInt32(txtID.Text) + "','" + txtCode.Text.Trim() + "','" + Convert.ToInt32(txtPage_Count.Text) + "','" + Convert.ToInt32(txtStart_Page.Text) + "','" + Convert.ToInt32(txtEnd_Page.Text) + "','" + txtSeries.Text + "','" + Convert.ToInt32(txtPage_Count.Text) + "',0,N'" + Name + "')";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                                dataconnection.Open();
                                for (int i = Convert.ToInt32(txtStart_Page.Text); i <= Convert.ToInt32(txtEnd_Page.Text); i++)
                                {
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Check_Page (ID, Check_Number, State) VALUES (@ID,@Check_Number,@State)", dataconnection);
                                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                                    cmd.Parameters.AddWithValue("@Check_Number", i);
                                    cmd.Parameters.AddWithValue("@State", 3);
                                    cmd.ExecuteNonQuery();
                                }
                                dataconnection.Close();
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPage_Count.Focus();
        }

        private void txtPage_Count_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtStart_Page.Focus();
        }

        private void txtStart_Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtSeries.Focus();
        }

        private void txtSeries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish1.Focus();
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

        private void txtPage_Count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtStart_Page_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtSeries_KeyPress(object sender, KeyPressEventArgs e)
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
