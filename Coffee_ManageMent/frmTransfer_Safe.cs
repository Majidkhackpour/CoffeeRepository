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
    public partial class frmTransfer_Safe : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        string Safe_Code_Bed, Safe_Code_Bes;
        int Doc_Number;
        private void Fill_Safe_Bed()
        {
            try
            {
                cmbBank1.Items.Clear();
                string Query = "SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Safe ON tbl_Account.Code = tbl_Safe.Code";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbBank1, s_obj);
                cmbBank1.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Safe FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbBank1.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        private void Fill_Safe_Bes()
        {
            try
            {
                cmbBank2.Items.Clear();
                string Query = "SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Safe ON tbl_Account.Code = tbl_Safe.Code";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbBank2, s_obj);
                cmbBank2.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Safe FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbBank2.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        private void Get_Max_Doc_Number()
        {
            try
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Number FROM tbl_Transaction WHERE Date='" + txtDate.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
                catch
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Doc_Number) FROM tbl_Transaction", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;
                }
            }
            catch
            {
                Doc_Number = 1;
            }
        }
        public frmTransfer_Safe()
        {
            InitializeComponent();
        }

        private void frmTransfer_Safe_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string query2 = "SELECT MAX (ID) FROM tbl_Transaction";
            clsFunction.lbl_NewCode(dataconnection, query2, lblID, "1");
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            Fill_Safe_Bed();
            Fill_Safe_Bes();
            txtPrice.Text = "0";
            txtLetterCash.Text = "صفر ریال";
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

        private void cmbBank1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + cmbBank1.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Safe_Code_Bes= (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void cmbBank2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + cmbBank2.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Safe_Code_Bed = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtPrice);
                txtLetterCash.Text = Num2Text.ToFarsi(Convert.ToInt64(txtPrice.Text)) + " " + "ریال";
            }
            catch
            {
                txtLetterCash.Text = "صفر ریال";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Safe_Code_Bes == Safe_Code_Bed)
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "صندوق مبدا و مقصد نمی تواند یکسان باشد";
                f.flag = 0;
                f.ShowDialog();
                return;
            }

            if (Convert.ToInt32(txtPrice.Text) <= 0)
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "لطفا مبلغ را وارد نمایید";
                f.flag = 0;
                f.ShowDialog();
                return;
            }
            Get_Max_Doc_Number();
            string query1 =
                "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" +
                Safe_Code_Bes + "','" + Convert.ToInt64(txtPrice.Text) + "',N'" + "پرداخت وجه نقد به " + cmbBank2.Text +
                " " + "بابت " + txtNotice.Text + "','" + txtDate.Text + "','" +
                System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10102" + "',6,'" + lblID.Text +
                "')";
            string query2 =
                "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" +
                Safe_Code_Bed + "','" + Convert.ToInt64(txtPrice.Text) + "',N'" + "دریافت وجه نقد از " + cmbBank1.Text +
                " " + "بابت " + txtNotice.Text + "','" + txtDate.Text + "','" +
                System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10102" + "',6,'" + lblID.Text +
                "')";
            string query3 = "INSERT INTO tbl_Pay_Recive_Info (ID, Code1, Code2, Babat_Code) VALUES ('" + lblID.Text +
                            "','" + Safe_Code_Bes + "','" + Safe_Code_Bes + "','" + "10102" + "')";
            if (clsFunction.Execute(dataconnection, query1) == true &&
                clsFunction.Execute(dataconnection, query2) == true &&
                clsFunction.Execute(dataconnection, query3) == true)
                this.Close();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void cmbBank1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void cmbBank2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }
    }
}
