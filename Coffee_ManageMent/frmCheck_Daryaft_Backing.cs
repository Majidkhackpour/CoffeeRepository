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
    public partial class frmCheck_Daryaft_Backing : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Check_Number;
        int Doc_Number, state;
        public void Fill_Data(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Acc_Code, Price, Safe_Reciver, Moeen_Code FROM tbl_Check_Daryaft WHERE ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblID.Text = ID.ToString();
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txttafzili_Bed.Text = txtCode.Text;
            txtCash.Text = dt.Rows[0].ItemArray[1].ToString();
            txtTafsili_Name_Bes.Text = dt.Rows[0].ItemArray[2].ToString();
            txtmoeen_Code_Bed.Text = dt.Rows[0].ItemArray[3].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Parent FROM tbl_Account WHERE Description LIKE N'" + dt.Rows[0].ItemArray[2].ToString() + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows[0].ItemArray[0].ToString() == "10")
                txtMoeen_Code_Bes.Text = "10101";
            else
                txtMoeen_Code_Bes.Text = "10102";
            if (op == "Kharj")
            {
                txtmoeen_Code_Bed.Text = txtMoen_Name_Bed.Text = "";
                txttafzili_Bed.Text = txttafzili_Name_Bed.Text = "";
            }
        }
        private void Insertasion()
        {
            try
            {
                string Mooen_Bes = "", Tafzili_Bes = "";
                string Moeen_Bed = "", Tafzili_Bed = "";
                string Notice = "";
                SqlDataAdapter da = new SqlDataAdapter("SELECT Parent FROM tbl_Account WHERE Code LIKE N'" + txtTafsili_Bes.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string Ass_Code = dt.Rows[0].ItemArray[0].ToString();
                if (dt.Rows[0].ItemArray[0].ToString() == "10")
                    Mooen_Bes = "10101";
                else
                    Mooen_Bes = "10102";
                Tafzili_Bes = txtTafsili_Bes.Text;
                Tafzili_Bed = txttafzili_Bed.Text;
                if (op == "Bargasht")
                {
                    Moeen_Bed = txtmoeen_Code_Bed.Text;
                    Notice = "برگشت چک به شماره " + Check_Number + " " + "به مبلغ " + txtCash.Text;
                    state = 2;
                }
                else if (op == "Esterdad")
                {
                    Moeen_Bed = txtmoeen_Code_Bed.Text;
                    Notice = "استرداد چک به شماره " + Check_Number + " " + "به مبلغ " + txtCash.Text;
                    state = 5;
                }
                else if (op == "Kharj")
                {
                    Moeen_Bed = "30101";
                    Notice = "خرج چک به شماره " + Check_Number + " " + "به مبلغ " + txtCash.Text;
                    state = 6;
                    Get_Max_Doc_Number();
                    string query11 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Tafzili_Bes + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "پرداخت چک به شماره "+Check_Number+" "+"به مبلغ "+txtCash.Text+" "+"به "+txttafzili_Name_Bed.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + Moeen_Bed + "',19,'" + lblID.Text + "')";
                    if (clsFunction.Execute(dataconnection, query11) == true)
                    {
                    }
                }
                Get_Max_Doc_Number();
                string query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Tafzili_Bed + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + Notice + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + Moeen_Bed + "',18,'" + lblID.Text + "')";
                string query2 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Tafzili_Bes + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + Notice + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + Mooen_Bes + "',18,'" + lblID.Text + "')";
                string query3 = "UPDATE tbl_Check_Daryaft SET State ='" + state + "' WHERE ID='" + Convert.ToInt64(lblID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                {
                    if (clsFunction.Execute(dataconnection, query3) == true)
                    {
                        this.Close();
                    }
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
        public frmCheck_Daryaft_Backing()
        {
            InitializeComponent();
        }

        private void frmCheck_Daryaft_Backing_Load(object sender, EventArgs e)
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtCash, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtMoeen_Name_Bes, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtTafsili_Name_Bes, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtMoen_Name_Bed, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txttafzili_Name_Bed, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
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
                    if (txtCode.Text != txttafzili_Bed.Text)
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
                            txttafzili_Bed.Text = txtCode.Text;
                        }
                    }
                    else
                    {
                        Insertasion();
                    }
                }
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
                txttafzili_Bed.Text = txtCode.Text;
                txttafzili_Name_Bed.Text = txtName.Text;
            }
            catch
            {
                txtName.Text = "";
                txttafzili_Bed.Text = txttafzili_Name_Bed.Text = "";
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

        private void txtmoeen_Code_Bed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_DefinitiveAccount WHERE AccCode='" + txtmoeen_Code_Bed.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtMoen_Name_Bed.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtMoen_Name_Bed.Text = "";
            }
        }

        private void btnSearch_Moeen_Bed_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                f.ShowDialog();
                txtmoeen_Code_Bed.Text = f.Moeen_Code;
            }
            catch
            {
                txtmoeen_Code_Bed.Text = "";
            }
        }

        private void txttafzili_Bed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txttafzili_Bed.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txttafzili_Name_Bed.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txttafzili_Name_Bed.Text = "";
            }
        }

        private void btnsearch_Tafzili_Bed_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "All";
                f.Fill_All_Account();
                f.ShowDialog();
                txttafzili_Bed.Text = f.Acc_Code;
            }
            catch
            {
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

        private void txtMoeen_Code_Bes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_DefinitiveAccount WHERE AccCode='" + txtMoeen_Code_Bes.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtMoeen_Name_Bes.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtMoeen_Name_Bes.Text = "";
            }
        }

        private void btnSearch_Moeen_Bes_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                f.ShowDialog();
                txtMoeen_Code_Bes.Text = f.Moeen_Code;
            }
            catch
            {
                txtMoeen_Code_Bes.Text = "";
            }
        }

        private void txtTafsili_Name_Bes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description= '" + txtTafsili_Name_Bes.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtTafsili_Bes.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
            }
        }

        private void txtTafsili_Bes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txtTafsili_Bes.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtTafsili_Name_Bes.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtTafsili_Name_Bes.Text = "";
            }
        }

        private void btnSearch_Tafsili_Bes_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "All";
                f.Fill_All_Account();
                f.ShowDialog();
                txtTafsili_Bes.Text = f.Acc_Code;
            }
            catch
            {
            }
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCash.Focus();
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMoeen_Code_Bes.Focus();
        }

        private void txtMoeen_Code_Bes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtMoeen_Name_Bes.Text != "")
                {
                    txtTafsili_Bes.Focus();
                }
                else
                {
                    frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                    f.txtSearch.Text = txtMoeen_Code_Bes.Text;
                    f.ShowDialog();
                    txtMoeen_Code_Bes.Text = f.Moeen_Code;
                }
            }
        }

        private void txtTafsili_Bes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtTafsili_Name_Bes.Text != "")
                {
                    txtmoeen_Code_Bed.Focus();
                }
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "All";
                    f.Fill_All_Account();
                    f.txtSearch.Text = txtTafsili_Bes.Text;
                    f.ShowDialog();
                    txtTafsili_Bes.Text = f.Acc_Code;
                }
            }
        }

        private void txtmoeen_Code_Bed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtMoen_Name_Bed.Text != "")
                {
                    txttafzili_Bed.Focus();
                }
                else
                {
                    frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                    f.txtSearch.Text = txtmoeen_Code_Bed.Text;
                    f.ShowDialog();
                    txtmoeen_Code_Bed.Text = f.Moeen_Code;
                }
            }
        }

        private void txttafzili_Bed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txttafzili_Name_Bed.Text != "")
                {
                    btnFinish.Focus();
                }
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "All";
                    f.Fill_All_Account();
                    f.txtSearch.Text = txttafzili_Bed.Text;
                    f.ShowDialog();
                    txttafzili_Bed.Text = f.Acc_Code;
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
    }
}
