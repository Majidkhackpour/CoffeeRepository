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
    public partial class frmPrice_Pattern : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Pattern_Name;
        int Counetr_Name;
        public void Form_Load()
        {
            txtCode.Text = txtDescription.Text = txtNotice.Text = "";
            txtStart_Date.Text = clsFunction.M2SH(DateTime.Now);
            chbState.Checked = true;
            string query2 = "SELECT MAX (Code) FROM tbl_Price_Pattern";
            clsFunction.txt_NewCode(dataconnection, query2, txtCode, "1");
        }
        private bool Check_Pattern_Name()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Description FROM tbl_Price_Pattern WHERE Description='" + txtDescription.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Pattern_Name = (string)dr["Description"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Pattern_Name == txtDescription.Text)
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT Description, Start_Date, Expiration_Date, Notice, State FROM tbl_Price_Pattern WHERE Code LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code;
            txtDescription.Text = dt.Rows[0].ItemArray[0].ToString();
            txtStart_Date.Text = dt.Rows[0].ItemArray[1].ToString();
            txtExpiration_Date.Text = dt.Rows[0].ItemArray[2].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[3].ToString();
            if (dt.Rows[0].ItemArray[4].ToString() == "0")
                chbState.Checked = true;
            else
                chbState.Checked = false;
            txtCode.Enabled = false;
        }
        private bool Check_Pattern_Name_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Description) FROM tbl_Price_Pattern WHERE Description LIKE N'" + txtDescription.Text.Trim() + "'", dataconnection);
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
        public frmPrice_Pattern()
        {
            InitializeComponent();
        }

        private void frmPrice_Pattern_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Description FROM tbl_Price_Pattern", dataconnection, txtDescription);
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
            if (clsFunction.Error_Provider(txtDescription, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                int State;
                if (chbState.Checked)
                    State = 0;
                else
                    State = 1;
                if (op == "Buy_Add")
                {
                    if (Check_Pattern_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "الگوی قیمت " + txtDescription.Text + " " + " از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Price_Pattern (Code, Description, Start_Date, Expiration_Date, Notice, State, Type) VALUES ('" + txtCode.Text + "',N'" + txtDescription.Text + "','" + txtStart_Date.Text + "','" + txtExpiration_Date.Text + "',N'" + txtNotice.Text + "','" + State + "',0)";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Product", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    string query2 = "INSERT INTO tbl_Price_List (P_Code, Buy_Price, Pattern_Code) VALUES ('" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "','" + Convert.ToInt64(dt.Rows[i].ItemArray[1]) + "','" + txtCode.Text + "')";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
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
                else if (op == "Sell_Add")
                {
                    if (Check_Pattern_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "الگوی قیمت " + txtDescription.Text + " " + " از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Price_Pattern (Code, Description, Start_Date, Expiration_Date, Notice, State, Type) VALUES ('" + txtCode.Text + "',N'" + txtDescription.Text + "','" + txtStart_Date.Text + "','" + txtExpiration_Date.Text + "',N'" + txtNotice.Text + "','" + State + "',1)";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Sell_Price FROM tbl_Product", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    string query2 = "INSERT INTO tbl_Price_List (P_Code, Sell_Price, Pattern_Code) VALUES ('" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "','" + Convert.ToInt64(dt.Rows[i].ItemArray[1]) + "','" + txtCode.Text + "')";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
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
                else if (op == "Edit")
                {
                    if (Check_Pattern_Name_ForEdit() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "الگوی قیمت " + txtDescription.Text + " " + " از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "UPDATE tbl_Price_Pattern SET Description = N'" + txtDescription.Text + "', Start_Date = '" + txtStart_Date.Text + "', Expiration_Date = '" + txtExpiration_Date.Text + "', Notice = N'" + txtNotice.Text + "', State = '" + State + "' WHERE Code = '" + txtCode.Text + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            this.Close();
                    }
                }
            }
        }

        private void chbState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDescription.Focus();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtStart_Date.Focus();
        }

        private void txtStart_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtExpiration_Date.Focus();
        }

        private void txtExpiration_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }
    }
}
