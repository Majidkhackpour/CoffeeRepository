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
    public partial class frmCheck_Daryaft : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Safe_Code;
        int Check_Type, Doc_Number;
        Int64 Reminder_ID;
        public void Form_Load()
        {
            string query2 = "SELECT MAX (ID) FROM tbl_Transaction";
            clsFunction.lbl_NewCode(dataconnection, query2, lblID, "1");
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            Fill_Safe();
            txtCode.Text = txtName.Text = "";
            txtCheck_Number.Text = txtBank.Text = txtBabat_Code.Text = txtBabat_Name.Text = "";
            txtNotice.Text = txtMoeen_Code.Text = txtMoeen_Name.Text = "";
            txtTafsili.Text = txtTafsili_Name.Text = "";
            txtSett_Date.Text = clsFunction.M2SH(DateTime.Now);
            txtCash.Text = "0";
            txtLetterCash.Text = "صفر ریال";
            Fill_Check_Type();
        }
        public void Fill_Data(int ID)
        {
            timer2.Stop();
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Time, Acc_Code, Safe_Reciver, Check_Number, Sett_Date, Price, Bank, Type, Babat_Code, Notice, Moeen_Code, Acc_Code2 FROM tbl_Check_Daryaft WHERE ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblID.Text = ID.ToString();
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            lblTime.Text = dt.Rows[0].ItemArray[1].ToString();
            txtCode.Text = dt.Rows[0].ItemArray[2].ToString();
            cmbSafe.Text = dt.Rows[0].ItemArray[3].ToString();
            txtCheck_Number.Text = dt.Rows[0].ItemArray[4].ToString();
            txtSett_Date.Text = dt.Rows[0].ItemArray[5].ToString();
            txtCash.Text = dt.Rows[0].ItemArray[6].ToString();
            txtBank.Text = dt.Rows[0].ItemArray[7].ToString();
            cmbCheck_Type.SelectedIndex = Convert.ToInt32(dt.Rows[0].ItemArray[8]);
            txtBabat_Code.Text = dt.Rows[0].ItemArray[9].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[10].ToString();
            txtMoeen_Code.Text = dt.Rows[0].ItemArray[11].ToString();
            txtTafsili.Text = dt.Rows[0].ItemArray[12].ToString();
        }
        private void Delete_Data()
        {
            try
            {
                string query = "DELETE FROM tbl_Transaction WHERE Parent=18 AND Parent_Code='" + lblID.Text + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
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
        private void Fill_Check_Type()
        {
            try
            {
                cmbCheck_Type.Items.Clear();
                string Query = "SELECT Type_Name FROM tbl_Check_Type";
                string s_obj = "Type_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbCheck_Type, s_obj);
                cmbCheck_Type.SelectedIndex = 0;
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
                string query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Safe_Code + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "دریافت چک از " + txtName.Text + " " + "به شماره " + txtCheck_Number.Text + " " + "به سررسید " + txtSett_Date.Text + " " + "بابت " + txtBabat_Name.Text + "','" + txtDate.Text + "','" + lblTime.Text + "','" + Doc_Number + "','" + "10201" + "',18,'" + lblID.Text + "')";
                string query2 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtTafsili.Text + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "پرداخت چک به شماره " + txtCheck_Number.Text + " " + "به سررسید " + txtSett_Date.Text + " " + "بابت " + txtBabat_Name.Text + "','" + txtDate.Text + "','" + lblTime.Text + "','" + Doc_Number + "','" + txtMoeen_Code.Text + "',18,'" + lblID.Text + "')";
                string query3 = "INSERT INTO tbl_Check_Daryaft (ID, Date, Time, State, Acc_Code, Safe_Reciver, Check_Number, Sett_Date, Price, Bank, Type, Babat_Code, Notice, Moeen_Code, Acc_Code2) VALUES ('" + Convert.ToInt64(lblID.Text) + "','" + txtDate.Text + "','" + lblTime.Text + "',1,'" + txtCode.Text + "',N'" + cmbSafe.Text + "','" + txtCheck_Number.Text + "','" + txtSett_Date.Text + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + txtBank.Text + "','" + Check_Type + "','" + txtBabat_Code.Text + "',N'" + txtNotice.Text + "','" + txtMoeen_Code.Text + "','" + txtTafsili.Text + "')";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                {
                    if (clsFunction.Execute(dataconnection, query3) == true)
                    {
                        Get_Max_Reminder_ID();
                        string query5 = "INSERT INTO tbl_Reminder (ID, Title, Body, Ins_Date, Remind_Date) VALUES ('" + Reminder_ID + "',N'" + "سررسید چک دریافتنی" + "',N'" + "سررسید چک دریافتنی " + txtName.Text + " " + "به شماره " + txtCheck_Number.Text + " " + "بابت " + " " + txtBabat_Name.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + txtSett_Date.Text + "')";
                        if (clsFunction.Execute(dataconnection, query5) == true)
                        {
                        }
                    }
                    this.Close();
                }
            }
            catch
            {
            }
        }
        private void Updation()
        {
            try
            {
                string query = "UPDATE tbl_Check_Daryaft SET Date = '" + txtDate.Text + "', Time = '" + lblTime.Text + "', Acc_Code = '" + txtCode.Text + "', Safe_Reciver = N'" + cmbSafe.Text + "', Check_Number = '" + txtCheck_Number.Text + "', Sett_Date = '" + txtSett_Date.Text + "', Price = '" + Convert.ToInt64(txtCash.Text) + "', Bank = N'" + txtBank.Text + "', Type = '" + Check_Type + "',  Babat_Code = '" + txtBabat_Code.Text + "', Notice = N'" + txtNotice.Text + "', Moeen_Code = '" + txtMoeen_Code.Text + "', Acc_Code2 = '" + txtTafsili.Text + "' WHERE ID = '" + Convert.ToInt64(lblID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                }
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
        public frmCheck_Daryaft()
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

        private void frmCheck_Daryaft_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            timer2_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
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

        private void txtBabat_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Name, Moeen FROM tbl_Pay_Recive_Identity WHERE Type=0 AND Code='" + txtBabat_Code.Text + "'", dataconnection);
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

        private void btnSearch_Babat_Click(object sender, EventArgs e)
        {
            try
            {
                frmPay_Recive_Identity f = new frmPay_Recive_Identity();
                f.Fill_Daryaft();
                f.op = "Daryaft";
                f.ShowDialog();
                txtBabat_Code.Text = f.Iden_Code;
                txtMoeen_Code.Text = f.Moeen_Code;
            }
            catch
            {
                txtBabat_Code.Text = txtMoeen_Code.Text = "";
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

        private void cmbCheck_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Check_Type FROM tbl_Check_Type WHERE Type_Name LIKE N'" + cmbCheck_Type.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Check_Type = (int)dr["Check_Type"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtCheck_Number, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBabat_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtMoeen_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
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
                    }
                    else if (op == "Edit")
                    {
                        Delete_Data();
                        if (txtCode.Text != txtTafsili.Text)
                        {
                            frmMessage f = new frmMessage();
                            f.lblMessage.Text = "حساب تفصیلی اولیه و ثانویه با هم تفاوت دارند. آیا ادامه می دهید؟";
                            f.flag = 1;
                            f.ShowDialog();
                            if (f.Resault == 0)
                            {
                                Insertasion();
                                Updation();
                            }
                            if (f.Resault == 1)
                            {
                                txtTafsili.Text = txtCode.Text;
                            }
                        }
                        else
                        {
                            Insertasion();
                            Updation();
                        }
                    }
                }
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
                    txtCheck_Number.Focus();
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

        private void txtCheck_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtSett_Date.Focus();
        }

        private void txtSett_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCash.Focus();
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBank.Focus();
        }

        private void txtBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbCheck_Type.Focus();
        }

        private void cmbCheck_Type_KeyDown(object sender, KeyEventArgs e)
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
                    txtNotice.Focus();
                }
                else
                {
                    frmPay_Recive_Identity f = new frmPay_Recive_Identity();
                    f.Fill_Daryaft();
                    f.op = "Daryaft";
                    f.txtSearch.Text = txtBabat_Code.Text;
                    f.ShowDialog();
                    txtBabat_Code.Text = f.Iden_Code;
                    txtMoeen_Code.Text = f.Moeen_Code;
                }
            }
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMoeen_Code.Focus();
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

        private void txtCheck_Number_KeyPress(object sender, KeyPressEventArgs e)
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
