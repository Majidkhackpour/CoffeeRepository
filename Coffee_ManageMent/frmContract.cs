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
    public partial class frmContract : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        int EDU, Con_Type, Con_State;
        public void Form_Load()
        {
            string Query = "SELECT Edu_Name FROM tbl_Education";
            string s_obj = "Edu_Name";
            clsFunction.FillComboBox(dataconnection, Query, cmbEdu, s_obj);
            cmbEdu.SelectedIndex = 0;
            string Query2 = "SELECT Type_Name FROM tbl_Contract_Type";
            string s_obj2 = "Type_Name";
            clsFunction.FillComboBox(dataconnection, Query2, cmbCon_Type, s_obj2);
            cmbCon_Type.SelectedIndex = 0;
            string Query3 = "SELECT State_Name FROM tbl_State";
            string s_obj3 = "State_Name";
            clsFunction.FillComboBox(dataconnection, Query3, cmbState, s_obj3);
            cmbState.SelectedIndex = 0;
            rbtnSingle.Checked = true;
            if (op == "View")
            {
                grp2.Enabled = false;
                txtDate.Enabled = false;
                txtExpiration_Date.Enabled = false;
                txtTheTerm.Enabled = false;
                cmbCon_Type.Enabled = false;
                cmbState.Enabled = false;
                txtNotice.Enabled = false;
                btnFinish.Enabled = false;
            }
        }
        public void Fill_Data(string Code)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Contract.Con_Code, tbl_Contract.Field_Edu, tbl_Contract.Date, tbl_Contract.Expiration_Date, tbl_Contract.TheTerm, tbl_Contract.Notice, tbl_Contract.Mrital_Status, tbl_Account.Description,  tbl_Education.Edu_Name, tbl_Contract_Type.Type_Name, tbl_Contract.State FROM tbl_Contract INNER JOIN tbl_Account ON tbl_Contract.Code = tbl_Account.Code INNER JOIN tbl_Education ON tbl_Contract.Education = tbl_Education.Education INNER JOIN tbl_Contract_Type ON tbl_Contract.Con_Type = tbl_Contract_Type.Con_Type WHERE tbl_Contract.Code= '" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = Code;
            txtCon_Code.Text = dt.Rows[0].ItemArray[0].ToString();
            txtField_Edu.Text = dt.Rows[0].ItemArray[1].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[2].ToString();
            txtExpiration_Date.Text = dt.Rows[0].ItemArray[3].ToString();
            txtTheTerm.Text = dt.Rows[0].ItemArray[4].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[5].ToString();
            if (dt.Rows[0].ItemArray[6].ToString() == "0")
                rbtnSingle.Checked = true;
            else
                rbtnMaried.Checked = true;
            txtName.Text = dt.Rows[0].ItemArray[7].ToString();
            cmbEdu.Text = dt.Rows[0].ItemArray[8].ToString();
            cmbCon_Type.Text = dt.Rows[0].ItemArray[9].ToString();
            if (dt.Rows[0].ItemArray[10].ToString() == "0")
                cmbState.SelectedIndex = 0;
            else
                cmbState.SelectedIndex = 1;
            if (txtTheTerm.Text == "")
                txtTheTerm.Text = "12";
        }
        public frmContract()
        {
            InitializeComponent();
        }

        private void frmContract_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Field_Edu FROM tbl_Contract", dataconnection, txtField_Edu);
            clsFunction.AutoComplete("SELECT TheTerm FROM tbl_Contract", dataconnection, txtTheTerm);
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

        }

        private void btnSallary_Click(object sender, EventArgs e)
        {
            try
            {
                frmSallary f = new frmSallary();
                if (op == "View")
                {
                    f.grp2.Enabled = false;
                    f.btnFinish.Enabled = false;
                }
                f.FillData(txtCon_Code.Text);
                f.The_Term = Convert.ToInt32(txtTheTerm.Text);
                f.Date = txtDate.Text;
                f.txtCode.Text = txtCode.Text;
                f.txtName.Text = txtName.Text;
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void cmbEdu_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Education FROM tbl_Education WHERE Edu_Name LIKE N'" + cmbEdu.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EDU = (int)dr["Education"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void cmbCon_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Con_Type FROM tbl_Contract_Type WHERE Type_Name LIKE N'" + cmbCon_Type.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Con_Type = (int)dr["Con_Type"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT State FROM tbl_State WHERE State_Name LIKE N'" + cmbState.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Con_State = (int)dr["State"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int Marital;
            if (rbtnSingle.Checked)
                Marital = 0;
            else
                Marital = 1;
            if (clsFunction.Error_Provider(txtTheTerm, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                string query = "UPDATE tbl_Contract SET Education = '" + EDU + "', Field_Edu = N'" + txtField_Edu.Text + "', Con_Type = '" + Con_Type + "', Date = '" + txtDate.Text + "', Expiration_Date = '" + txtExpiration_Date.Text + "', TheTerm = '" + Convert.ToInt32(txtTheTerm.Text) + "', State = '" + Con_State + "',  Notice = N'" + txtNotice.Text + "', Mrital_Status = '" + Marital + "' WHERE Con_Code = '" + txtCon_Code.Text + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                    this.Close();
            }
        }

        private void cmbEdu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtField_Edu.Focus();
        }

        private void txtField_Edu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDate.Focus();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtExpiration_Date.Focus();
        }

        private void txtExpiration_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTheTerm.Focus();
        }

        private void txtTheTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbCon_Type.Focus();
        }

        private void cmbCon_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbState.Focus();
        }

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtExpiration_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtTheTerm_KeyPress(object sender, KeyPressEventArgs e)
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
