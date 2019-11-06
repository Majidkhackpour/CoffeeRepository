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
    public partial class frmCash_Pardakht : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Safe_Code, Type, Loan_Code, Loan_Date;
        int Doc_Number;
        public Int64 Loan_Price;
        public void Form_Load()
        {
            string query2 = "SELECT MAX (ID) FROM tbl_Transaction";
            clsFunction.lbl_NewCode(dataconnection, query2, lblID, "1");
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
            Fill_Safe();
            txtCode.Text = txtName.Text = "";
            txtCash.Text = "0";
            txtLetterCash.Text = "صفر ریال";
            txtBabat_Code.Text = txtBabat_Name.Text = "";
            txtMoeen_Code.Text = txtMoeen_Name.Text = "";
            txtTafsili.Text = txtTafsili_Name.Text = "";
        }
        public void Fill_Data(int ID)
        {
            try
            {
                timer2.Stop();
                Form_Load();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Bedehkar, Date, Time, Moeen FROM tbl_Transaction WHERE Parent_Code='" + ID.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblID.Text = ID.ToString();
                txtCash.Text = dt.Rows[0].ItemArray[0].ToString();
                txtDate.Text = dt.Rows[0].ItemArray[1].ToString();
                lblTime.Text = dt.Rows[0].ItemArray[2].ToString();
                txtMoeen_Code.Text = dt.Rows[0].ItemArray[3].ToString();
            }
            catch
            {
            }
            try
            {
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Code1, Code2, Babat_Code FROM tbl_Pay_Recive_Info WHERE ID='" + ID.ToString() + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                txtCode.Text = dt2.Rows[0].ItemArray[0].ToString();
                txtTafsili.Text = dt2.Rows[0].ItemArray[1].ToString();
                txtBabat_Code.Text = dt2.Rows[0].ItemArray[2].ToString();
            }
            catch
            {
            }
        }
        private void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Transaction WHERE Parent=6 AND Parent_Code='" + ID.ToString() + "'";
                string query2 = "DELETE FROM tbl_Pay_Recive_Info WHERE ID='" + ID.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                {
                }
            }
            catch
            {
            }
        }
        private void Fill_Safe()
        {
            try
            {
                cmbSafe.Items.Clear();
                string Query = "SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Safe ON tbl_Account.Code = tbl_Safe.Code";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbSafe, s_obj);
                cmbSafe.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Safe FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbSafe.Text = dt.Rows[0].ItemArray[0].ToString();
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
        private void Insertasion()
        {
            try
            {
                Get_Max_Doc_Number();
                string query1 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Safe_Code + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "پرداخت وجه نقد به " + txtName.Text + " " + "بابت " + txtBabat_Name.Text + "','" + txtDate.Text + "','" + lblTime.Text + "','" + Doc_Number + "','" + "10102" + "',6,'" + lblID.Text + "')";
                string query2 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtTafsili.Text + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "دریافت وجه نقد بابت " + txtBabat_Name.Text + "','" + txtDate.Text + "','" + lblTime.Text + "','" + Doc_Number + "','" + txtMoeen_Code.Text + "',6,'" + lblID.Text + "')";
                string query3 = "INSERT INTO tbl_Pay_Recive_Info (ID, Code1, Code2, Babat_Code) VALUES ('" + lblID.Text + "','" + txtCode.Text + "','" + txtTafsili.Text + "','" + txtBabat_Code.Text + "')";
                if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query3) == true)
                    this.Close();
            }
            catch
            {
            }
        }
        public frmCash_Pardakht()
        {
            InitializeComponent();
        }

        private void frmCash_Pardakht_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            timer2_Tick(null, null);
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
        }

        private void cmbSafe_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + cmbSafe.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Safe_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnSearch_Acc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "All";
                f.Fill_All_Account();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
                txtTafsili.Text = txtCode.Text;
                txtTafsili_Name.Text = txtName.Text;
            }
            catch
            {
                txtName.Text = "";
                txtTafsili.Text = txtTafsili_Name.Text = "";
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtCash);
                txtLetterCash.Text = Num2Text.ToFarsi(Convert.ToInt64(txtCash.Text)) + " " + "ریال";
            }
            catch
            {
                txtLetterCash.Text = "صفر ریال";
            }
        }

        private void btnSearch_Babat_Click(object sender, EventArgs e)
        {
            try
            {
                frmPay_Recive_Identity f = new frmPay_Recive_Identity();
                f.Fill_Pardakht();
                f.op = "Pardakht";
                f.ShowDialog();
                txtBabat_Code.Text = f.Iden_Code;
                txtMoeen_Code.Text = f.Moeen_Code;
            }
            catch
            {
                txtBabat_Code.Text = txtMoeen_Code.Text = "";
            }
        }

        private void txtBabat_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Name, Moeen FROM tbl_Pay_Recive_Identity WHERE Type=1 AND Code='" + txtBabat_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtBabat_Name.Text = dt.Rows[0].ItemArray[0].ToString();
                txtMoeen_Code.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                txtBabat_Name.Text = txtMoeen_Code.Text = "";
            }
        }

        private void txtMoeen_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_DefinitiveAccount WHERE AccCode='" + txtMoeen_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtMoeen_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtMoeen_Name.Text = "";
            }
        }

        private void btnSearch_Tafsili_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "All";
                f.Fill_All_Account();
                f.ShowDialog();
                txtTafsili.Text = f.Acc_Code;
            }
            catch
            {
            }
        }

        private void txtTafsili_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txtTafsili.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtTafsili_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtTafsili_Name.Text = "";
            }
        }

        private void btnSearch_Moeen_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                f.ShowDialog();
                txtMoeen_Code.Text = f.Moeen_Code;
            }
            catch
            {
                txtMoeen_Code.Text = "";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBabat_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtMoeen_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (txtCash.Text == "" || txtCash.Text == "0")
                {
                    errorProvider1.RightToLeft = true;
                    errorProvider1.SetError(txtLetterCash, "مبلغ وارد شده صحیح نمی باشد");
                }
                else
                {
                    errorProvider1.Clear();
                    if (op == "Add")
                    {
                        if (txtCode.Text != txtTafsili.Text)
                        {
                            frmMessage f = new frmMessage();
                            f.lblMessage.Text = "حساب تفصیلی اولیه و ثانویه با هم تفاوت دارند. آیا ادامه می دهید؟";
                            f.flag = 1;
                            f.ShowDialog();
                            if (f.Resault == 0)
                            {
                                Insertasion();
                            }
                            if (f.Resault == 1)
                            {
                                txtTafsili.Text = txtCode.Text;
                            }
                        }
                        else
                        {
                            Insertasion();
                        }
                        if (Type == "Loan")
                        {
                            string query = "UPDATE tbl_Body_Loan SET State=3 WHERE Code='" + Loan_Code + "' AND Date='" + Loan_Date + "' AND Price='" + Loan_Price + "'";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                            }
                        }
                    }
                    else if (op == "Edit")
                    {
                        Delete_Data(Convert.ToInt32(lblID.Text));
                        if (txtCode.Text != txtTafsili.Text)
                        {
                            frmMessage f = new frmMessage();
                            f.lblMessage.Text = "حساب تفصیلی اولیه و ثانویه با هم تفاوت دارند. آیا ادامه می دهید؟";
                            f.flag = 1;
                            f.ShowDialog();
                            if (f.Resault == 0)
                            {
                                Insertasion();
                            }
                            if (f.Resault == 1)
                            {
                                txtTafsili.Text = txtCode.Text;
                            }
                        }
                        else
                        {
                            Insertasion();
                        }
                    }
                }
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbSafe.Focus();
        }

        private void cmbSafe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtName.Text != "")
                {
                    txtCash.Focus();
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

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBabat_Code.Focus();
        }

        private void txtBabat_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtBabat_Name.Text != "")
                {
                    txtMoeen_Code.Focus();
                }
                else
                {
                    frmPay_Recive_Identity f = new frmPay_Recive_Identity();
                    f.Fill_Pardakht();
                    f.op = "Pardakht";
                    f.txtSearch.Text = txtBabat_Code.Text;
                    f.ShowDialog();
                    txtBabat_Code.Text = f.Iden_Code;
                    txtMoeen_Code.Text = f.Moeen_Code;
                }
            }
        }

        private void txtMoeen_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtMoeen_Name.Text != "")
                {
                    txtTafsili.Focus();
                }
                else
                {
                    frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                    f.txtSearch.Text = txtMoeen_Code.Text;
                    f.ShowDialog();
                    txtMoeen_Code.Text = f.Moeen_Code;
                }
            }
        }

        private void txtTafsili_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtTafsili_Name.Text != "")
                {
                    btnFinish.Focus();
                }
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "All";
                    f.Fill_All_Account();
                    f.txtSearch.Text = txtTafsili.Text;
                    f.ShowDialog();
                    txtCode.Text = f.Acc_Code;
                }
            }
        }
    }
}
