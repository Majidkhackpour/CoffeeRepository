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
    public partial class frmCus_Installment : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        private Int64 Reminder_ID;
        private Guid guid_edit;
        public void Form_Load()
        {
            txtCode.Text = txtName.Text = "";
            txtPrice.Text = "0";
            txtDigit.Text = "صفر ریال";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            txtNotice.Text = "";
        }

        public void Fill_Data(Guid ggGuid)
        {
            Form_Load();
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT Code, Price, Sett_Date, Notice FROM tbl_Customer_Installment WHERE Guid='" + ggGuid + "'",
                    dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guid_edit = ggGuid;
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtPrice.Text = dt.Rows[0].ItemArray[1].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[2].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[3].ToString();
        }

        private void Get_Max_Reminder_ID()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (ID) FROM tbl_Reminder", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Reminder_ID = Convert.ToInt64(dt.Rows[0].ItemArray[0]) + 1;
            }
            catch
            {
                Reminder_ID = 1;
            }
        }
        public frmCus_Installment()
        {
            InitializeComponent();
        }

        private void frmCus_Installment_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer2_Tick(null, null);
        }

        private void timer2_Tick(object sender, EventArgs e)
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Customer ON tbl_Account.Code = tbl_Customer.Code WHERE tbl_Customer.Code= '" + txtCode.Text + "'", dataconnection);
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
                frmAllCustomer f = new frmAllCustomer();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
                txtCode.Text = "";
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtPrice);
                txtDigit.Text = Num2Text.ToFarsi(Convert.ToInt64(txtPrice.Text)) + " " + "ریال";
            }
            catch
            {
                txtDigit.Text = "صفر ریال";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (txtPrice.Text == "" || txtPrice.Text == "0")
                {
                    errorProvider1.RightToLeft = true;
                    errorProvider1.SetError(txtDigit, "مبلغ وارد شده صحیح نمی باشد");
                }
                else
                {
                    errorProvider1.Clear();
                    if (op == "Add")
                    {
                        Get_Max_Reminder_ID();
                        string query1 =
                            "INSERT INTO tbl_Customer_Installment (Guid, Code, Price, Date, Sett_Date, Notice, State) VALUES ('" +
                            Guid.NewGuid() + "','" + txtCode.Text + "','" + txtPrice.Text + "','" +
                            clsFunction.M2SH(DateTime.Now) + "','" + txtDate.Text + "',N'" + txtNotice.Text + "',2)";
                        if (clsFunction.Execute(dataconnection, query1) == true)
                        {
                            string query2 =
                                "INSERT INTO tbl_Reminder (ID, Title, Body, Ins_Date, Remind_Date) VALUES ('" +
                                Reminder_ID + "',N'" + "تسویه اقساط مشتریان" + "',N'" + "تسویه قسط  " + txtName.Text +
                                "','" + clsFunction.M2SH(DateTime.Now) + "','" + txtDate.Text + "')";
                            if (clsFunction.Execute(dataconnection, query2) == true)
                                this.Close();
                        }
                    }
                    else if (op == "Edit")
                    {
                        string query = "UPDATE tbl_Customer_Installment SET Code = '" + txtCode.Text + "', Price = '" +
                                       txtPrice.Text + "', Sett_Date = '" + txtDate.Text + "', Notice = N'" +
                                       txtNotice.Text + "' WHERE Guid = '" + guid_edit + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            this.Close();
                    }
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtName.Text != "")
                {
                    SendKeys.Send("{tab}");
                }
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "All";
                    f.Fill_All_Account();
                    f.txtSearch.Text = txtCode.Text;
                    f.ShowDialog();
                    txtCode.Text = f.Acc_Code;
                }
            }
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

        private void btnSearchAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }
    }
}
