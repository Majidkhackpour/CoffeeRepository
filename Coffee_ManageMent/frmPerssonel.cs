using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent
{
    public partial class frmPerssonel : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Acc_Code, s_PhoneBook, s_Contract, strCon_Code;
        int Group, grp, gender, State, ID_Per, Perssonel_Counter;
        public void Form_Load()
        {
            string Query = "SELECT Group_Name FROM tbl_Perssonel_Group";
            string s_obj = "Group_Name";
            clsFunction.FillComboBox(dataconnection, Query, cmbGroup, s_obj);
            cmbGroup.SelectedIndex = 0;
            rbtnMale.Checked = true;
            chbState.Checked = true;
        }
        private bool Check_Account_On_Perssonel()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code,Group_ID FROM tbl_Perssonel WHERE Code='" + txtCode.Text + "'AND Group_ID='" + Group + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Code = (string)dr["Code"];
                        grp = (int)dr["Group_ID"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if ((s_Acc_Code == txtCode.Text) && (grp == Group))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void Get_Max_Contract_Code()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Con_Code) FROM tbl_Contract", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                strCon_Code = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();
            }
            catch
            {
                strCon_Code = "700001";
            }
        }
        private bool Check_Account_On_PhoneBook()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_PhoneBook WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_PhoneBook = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_PhoneBook == txtCode.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Account_On_Contract()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Contract WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Contract = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Contract == txtCode.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Perssonel.Code, tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel.National_Code, tbl_Perssonel.Father_Name, tbl_Perssonel.Date_Birth, tbl_Perssonel.Place_Birth,  tbl_Perssonel.Address, tbl_Perssonel.Notice, tbl_Perssonel_Group.Group_Name, tbl_Perssonel.State, tbl_Perssonel.Gender, tbl_PhoneBook.Phone, tbl_PhoneBook.Mobile, tbl_PhoneBook.Email FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID INNER JOIN tbl_PhoneBook ON tbl_Account.Code = tbl_PhoneBook.Code WHERE tbl_Perssonel.ID LIKE N'" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ID_Per = ID;
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtName.Text = dt.Rows[0].ItemArray[1].ToString();
            txtPersonnelCode.Text = dt.Rows[0].ItemArray[2].ToString();
            txtNat_Code.Text = dt.Rows[0].ItemArray[3].ToString();
            txtFather_Name.Text = dt.Rows[0].ItemArray[4].ToString();
            txtDate_Birth.Text = dt.Rows[0].ItemArray[5].ToString();
            txtPlace_Birth.Text = dt.Rows[0].ItemArray[6].ToString();
            txtAddress.Text = dt.Rows[0].ItemArray[7].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[8].ToString();
            cmbGroup.Text = dt.Rows[0].ItemArray[9].ToString();
            if (dt.Rows[0].ItemArray[10].ToString() == "0")
                chbState.Checked = true;
            else
                chbState.Checked = false;
            if (dt.Rows[0].ItemArray[11].ToString() == "0")
                rbtnFemale.Checked = true;
            else
                rbtnMale.Checked = true;
            txtPhone.Text = dt.Rows[0].ItemArray[12].ToString();
            txtMobile.Text = dt.Rows[0].ItemArray[13].ToString();
            txtEmail.Text = dt.Rows[0].ItemArray[14].ToString();
            txtCode.Enabled = false;
            btnSearchAcc.Enabled = false;
        }
        private bool Check_Account_On_Perssonel_For_Edit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT (Code) FROM tbl_Perssonel WHERE Code='" + txtCode.Text + "'AND Group_ID='" + Group + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Perssonel_Counter = (int)dr[0];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (Perssonel_Counter > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmPerssonel()
        {
            InitializeComponent();
        }

        private void frmPerssonel_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Mobile FROM tbl_PhoneBook", dataconnection, txtMobile);
            clsFunction.AutoComplete("SELECT Email FROM tbl_PhoneBook", dataconnection, txtEmail);
            clsFunction.AutoComplete("SELECT National_Code FROM tbl_Perssonel", dataconnection, txtNat_Code);
            clsFunction.AutoComplete("SELECT Father_Name FROM tbl_Perssonel", dataconnection, txtFather_Name);
            clsFunction.AutoComplete("SELECT Place_Birth FROM tbl_Perssonel", dataconnection, txtPlace_Birth);
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

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Group_ID FROM tbl_Perssonel_Group WHERE Group_Name LIKE N'" + cmbGroup.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Group = (int)dr["Group_ID"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtNat_Code, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.Error_Provider(txtMobile, errorProvider1, "این فیلد نمی تواند خالی باشد") || clsFunction.Error_Provider(txtPersonnelCode, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                Get_Max_Contract_Code();
                string SubString = txtCode.Text.Substring(0, 2);
                if (SubString != "30")
                {
                    clsFunction.Show_OtherError(txtCode, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else if (clsFunction.Check_NationalCode(txtNat_Code) == false || txtNat_Code.Text.Length < 8)
                {
                    clsFunction.Show_OtherError(txtNat_Code, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else if ((txtMobile.Text.Length < 11 && txtMobile.Text.Length > 0) || clsFunction.Check_Mobile(txtMobile) == false)
                {
                    clsFunction.Show_OtherError(txtMobile, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else if (clsFunction.Check_Email(txtEmail) == false)
                {
                    clsFunction.Show_OtherError(txtEmail, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    string query1, query2, query3;
                    if (rbtnMale.Checked)
                        gender = 1;
                    else
                        gender = 0;
                    if (chbState.Checked)
                        State = 0;
                    else State = 1;
                    if (op == "Add")
                    {
                        errorProvider1.Clear();
                        if (Check_Account_On_PhoneBook() == false)
                        {
                            query1 = "INSERT INTO tbl_PhoneBook (Code, Phone, Mobile, Email, Group_ID, Name) VALUES ('" + txtCode.Text + "','" + txtPhone.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "',2,N'" + txtName.Text + "')";
                            if (clsFunction.Execute(dataconnection, query1) == true)
                            {
                            }
                        }
                        if (Check_Account_On_Contract() == false)
                        {
                            query2 = "INSERT INTO tbl_Contract (Con_Code, Code, Date, State, Education, Con_Type, Mrital_Status) VALUES ('" + strCon_Code + "','" + txtCode.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + State + "',1,1,0)";
                            if (clsFunction.Execute(dataconnection, query2) == true)
                            {
                            }
                        }
                        if (Check_Account_On_Perssonel() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = txtName.Text + " " + "در سمت " + cmbGroup.Text + " " + "از پیش تعریف شده است";
                            f.ShowDialog();
                        }
                        else if (Check_Account_On_Perssonel() == false)
                        {
                            query3 = "INSERT INTO tbl_Perssonel (Code, Perssonel_Code, National_Code, Father_Name, Date_Birth, Place_Birth, Address, Notice, Group_ID, State, Gender) VALUES ('" + txtCode.Text + "','" + txtPersonnelCode.Text + "','" + txtNat_Code.Text + "',N'" + txtFather_Name.Text + "','" + txtDate_Birth.Text + "',N'" + txtPlace_Birth.Text + "',N'" + txtAddress.Text + "',N'" + txtNotice.Text + "','" + Group + "','" + State + "','" + gender + "')";
                            if (clsFunction.Execute(dataconnection, query3) == true)
                            {
                                this.Close();
                            }
                        }
                    }
                    else if (op == "Edit")
                    {
                        if (Check_Account_On_Perssonel_For_Edit() == true)
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = txtName.Text + " " + "در سمت " + cmbGroup.Text + " " + "از پیش تعریف شده است";
                            f.ShowDialog();
                        }
                        else
                        {
                            query1 = "UPDATE tbl_Perssonel SET Perssonel_Code = '" + txtPersonnelCode.Text + "', National_Code = '" + txtNat_Code.Text + "', Father_Name = N'" + txtFather_Name.Text + "', Date_Birth = '" + txtDate_Birth.Text + "', Place_Birth = '" + txtPlace_Birth.Text + "', Address = N'" + txtAddress.Text + "',  Notice = N'" + txtNotice.Text + "', Group_ID = '" + Group + "', State = '" + State + "', Gender = '" + gender + "' WHERE ID='" + ID_Per + "'";
                            query2 = "UPDATE tbl_PhoneBook SET Phone = '" + txtPhone.Text + "', Mobile = '" + txtMobile.Text + "', Email = '" + txtEmail.Text + "', Name=N'" + txtName.Text + "' WHERE Code = '" + txtCode.Text + "'";
                            if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                            {
                                this.Close();
                            }
                        }
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
                f.op = "Rael_Acc";
                f.Fill_Real_Account();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
                txtPersonnelCode.Text = txtCode.Text;
            }
            catch
            {
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtPersonnelCode.Text = txtCode.Text;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Phone, Mobile, Email FROM tbl_PhoneBook WHERE Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtPhone.Text = dt.Rows[0].ItemArray[0].ToString();
                txtMobile.Text = dt.Rows[0].ItemArray[1].ToString();
                txtEmail.Text = dt.Rows[0].ItemArray[2].ToString();
            }
            catch
            {
                txtPhone.Text = txtMobile.Text = txtEmail.Text = "";
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_English();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_Persian();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNat_Code.Focus();
        }

        private void txtNat_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtFather_Name.Focus();
        }

        private void txtFather_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                rbtnMale.Focus();
        }

        private void rbtnMale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDate_Birth.Focus();
        }

        private void txtDate_Birth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPlace_Birth.Focus();
        }

        private void txtPlace_Birth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPhone.Focus();
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMobile.Focus();
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtEmail.Focus();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPersonnelCode.Focus();
        }

        private void txtPersonnelCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbGroup.Focus();
        }

        private void cmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtAddress.Focus();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                chbState.Focus();
        }

        private void chbState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
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

        private void txtNat_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDate_Birth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtPersonnelCode_KeyPress(object sender, KeyPressEventArgs e)
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
