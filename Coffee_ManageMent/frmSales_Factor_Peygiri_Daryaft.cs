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
    public partial class frmSales_Factor_Peygiri_Daryaft : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public void Form_Load()
        {
            txtDate.Enabled = false;
            txtCode.Enabled = false;
            txtCash.Enabled = false;
            txtRecive_Date.Text = clsFunction.M2SH(DateTime.Now);
            txtCash_Rec.Text = txtNon_Cash_Rec.Text = "0";
            Fill_Cmb_State();
            Calculate();
        }
        public void Fill_Data(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, C_Code, Sum_Factor FROM tbl_Header_Sales_Factor WHERE ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblID.Text = ID.ToString();
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            txtCode.Text = dt.Rows[0].ItemArray[1].ToString();
            txtCash.Text = dt.Rows[0].ItemArray[2].ToString();
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
        private void Calculate()
        {
            try
            {
                int Cash = Convert.ToInt32(txtCash_Rec.Text);
                int Non_Cash = Convert.ToInt32(txtNon_Cash_Rec.Text);
                int Sum_Cash_AND_Non_Cash = Cash + Non_Cash;
                if (Sum_Cash_AND_Non_Cash == Convert.ToInt32(txtCash.Text))
                    cmbFin_State.SelectedIndex = 0;
                else
                    cmbFin_State.SelectedIndex = 1;
            }
            catch
            {
            }
        }
        public frmSales_Factor_Peygiri_Daryaft()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void frmSales_Factor_Peygiri_Daryaft_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
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

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtLetterCash.Text = Num2Text.ToFarsi(Convert.ToInt64(txtCash.Text)) + " " + "ریال";
            }
            catch
            {
                txtLetterCash.Text = "صفر ریال";
            }
        }

        private void btnSearch_Cash_Click(object sender, EventArgs e)
        {
            try
            {
                frmPay_Sales_Factor f = new frmPay_Sales_Factor();
                f.Form_Load();
                f.op = "Add";
                f.lblFactor_Code.Text = lblID.Text;
                f.lblCustomer_Code.Text = txtCode.Text;
                f.lblCustomer_Name.Text = txtName.Text;
                f.ShowDialog();
                txtCash_Rec.Text = f.lblSum_Cash.Text;
                txtNon_Cash_Rec.Text = f.lblSum_Bank.Text;
            }
            catch
            {
                txtCash_Rec.Text = txtNon_Cash_Rec.Text = "0";
            }
        }

        private void txtCash_Rec_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtNon_Cash_Rec_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (txtCash_Rec.Text == "0" && txtNon_Cash_Rec.Text == "0")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "لطفا مبالغ را وارد نمایید";
                f.ShowDialog();
            }
            else
            {
                string query = "UPDATE tbl_Header_Sales_Factor SET Fin_State='" + cmbFin_State.SelectedIndex + "' WHERE ID='" + Convert.ToInt64(lblID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    this.Close();
                }
            }
        }

        private void txtRecive_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbFin_State.Focus();
        }

        private void cmbFin_State_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }
    }
}
