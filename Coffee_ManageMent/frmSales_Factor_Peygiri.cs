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
    public partial class frmSales_Factor_Peygiri : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        Int64 Reminder_ID;
        public void Form_Load()
        {
            txtCode.Enabled = false;
            txtDate.Enabled = false;
            txtFactor_Code.Enabled = false;
            txtSett_Date.Enabled = false;
            txtPey_Date.Text = clsFunction.M2SH(DateTime.Now);
            txtNext_Pey.Text = txtResp_Code.Text = txtResp_Name.Text = "";
            txtPey_Date.Enabled = false;
            Fill_Cmb_State();
        }
        public void Fill_Data(int ID)
        {
            try
            {
                Form_Load();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Date, C_Code, Sett_Date, Fin_State, Next_Pey_Date, Pey_Resp FROM tbl_Header_Sales_Factor WHERE ID='" + ID + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtFactor_Code.Text = ID.ToString();
                txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
                txtCode.Text = dt.Rows[0].ItemArray[1].ToString();
                txtSett_Date.Text = dt.Rows[0].ItemArray[2].ToString();
                cmbFin_State.SelectedIndex = Convert.ToInt32(dt.Rows[0].ItemArray[3]);
                txtNext_Pey.Text = dt.Rows[0].ItemArray[4].ToString();
                txtResp_Name.Text = dt.Rows[0].ItemArray[5].ToString();
            }
            catch
            {
            }
            try
            {
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + txtResp_Name.Text + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                txtResp_Code.Text = dt2.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
            }
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
        private void Fill_Cmb_State()
        {
            try
            {
                cmbFin_State.Items.Clear();
                string Query = "SELECT Pey_Name FROM tbl_Peygiri_State";
                string s_obj = "Pey_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbFin_State, s_obj);
                cmbFin_State.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        public frmSales_Factor_Peygiri()
        {
            InitializeComponent();
        }

        private void frmSales_Factor_Peygiri_Load(object sender, EventArgs e)
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code WHERE tbl_Customer.Code='" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName.Text = "";
            }
        }

        private void btnSearch_Resp_Code_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Perssonel f = new frmShow_Perssonel();
                f.ShowDialog();
                txtResp_Code.Text = f.Per_Code;
            }
            catch
            {
                txtResp_Code.Text = "";
            }
        }

        private void txtResp_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code WHERE tbl_Perssonel.Code='" + txtResp_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtResp_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtResp_Name.Text = "";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                Get_Max_Reminder_ID();
                string query = "UPDATE tbl_Header_Sales_Factor SET Fin_State = '" + cmbFin_State.SelectedIndex + "', Pey_Date = '" + txtPey_Date.Text + "', Next_Pey_Date = '" + txtNext_Pey.Text + "', Pey_Resp = N'" + txtResp_Name.Text + "' WHERE ID = '" + Convert.ToInt64(txtFactor_Code.Text) + "'";
                string query5 = "INSERT INTO tbl_Reminder (ID, Title, Body, Ins_Date, Remind_Date) VALUES ('" + Reminder_ID + "',N'" + "پیگیری مالی فاکتور فروش" + "',N'" + "تسویه با " + txtName.Text + " " + "بابت فاکتور فروش شماره " + " " + txtFactor_Code.Text + " " + "مورخ " + txtDate.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + txtPey_Date.Text + "')";
                if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query5) == true)
                {
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void txtResp_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void cmbFin_State_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNext_Pey.Focus();
        }

        private void txtNext_Pey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPey_Date.Focus();
        }

        private void txtPey_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtResp_Code.Focus();
        }

        private void txtResp_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }
    }
}
