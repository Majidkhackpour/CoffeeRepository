using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent
{
    public partial class frmSallary : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public int The_Term;
        public string Date;
        public void FillData(string Con_Code)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Sallary.Per_Code, tbl_Sallary.Hour_In_Day, tbl_Sallary.Hour_Price, tbl_Sallary.Right_Housing, tbl_Sallary.Right_Child, tbl_Sallary.Base_Sallary, tbl_Sallary.Ben_Laborer, tbl_Sallary.Other_Sallary,  tbl_Sallary.Full_Sallary, tbl_Account.Description, tbl_Sallary.Max_Dep_Leave, tbl_Sallary.Dep_Leave_Price, tbl_Sallary.Inssurance, tbl_Sallary.Night_Sallary FROM tbl_Sallary INNER JOIN tbl_Account ON tbl_Sallary.Per_Code = tbl_Account.Code WHERE tbl_Sallary.Con_Code LIKE N'" + Con_Code + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtCon_Code.Text = Con_Code;
                txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
                txtHour_Day.Text = dt.Rows[0].ItemArray[1].ToString();
                txtHour_Price.Text = dt.Rows[0].ItemArray[2].ToString();
                txtRight_Housing.Text = dt.Rows[0].ItemArray[3].ToString();
                txtRight_Child.Text = dt.Rows[0].ItemArray[4].ToString();
                txtBase_Sallary.Text = dt.Rows[0].ItemArray[5].ToString();
                txtBen_Laborer.Text = dt.Rows[0].ItemArray[6].ToString();
                txtOther_Sallary.Text = dt.Rows[0].ItemArray[7].ToString();
                txtSallary.Text = dt.Rows[0].ItemArray[8].ToString();
                txtName.Text = dt.Rows[0].ItemArray[9].ToString();
                txtMax_Dep_Leave.Text = dt.Rows[0].ItemArray[10].ToString();
                txtDep_Leave_Price.Text = dt.Rows[0].ItemArray[11].ToString();
                txtIns.Text = dt.Rows[0].ItemArray[12].ToString();
                txtNight.Text = dt.Rows[0].ItemArray[13].ToString();
                if (txtHour_Day.Text == "")
                    txtHour_Day.Text = "0";
                if (txtHour_Price.Text == "")
                    txtHour_Price.Text = "0";
                if (txtRight_Housing.Text == "")
                    txtRight_Housing.Text = "0";
                if (txtRight_Child.Text == "")
                    txtRight_Child.Text = "0";
                if (txtBase_Sallary.Text == "")
                    txtBase_Sallary.Text = "0";
                if (txtBen_Laborer.Text == "")
                    txtBen_Laborer.Text = "0";
                if (txtOther_Sallary.Text == "")
                    txtOther_Sallary.Text = "0";
                if (txtSallary.Text == "")
                    txtSallary.Text = "0";
                if (txtMax_Dep_Leave.Text == "")
                    txtMax_Dep_Leave.Text = "0";
                if (txtDep_Leave_Price.Text == "")
                    txtDep_Leave_Price.Text = "0";
                if (txtIns.Text == "")
                    txtIns.Text = "0";
                if (txtNight.Text == "")
                    txtNight.Text = "0";
                if (txtHour_Price.Text != "" && txtDep_Leave_Price.Text == "")
                    txtHour_Price_TextChanged_1(null, null);
            }
            catch
            {
                txtBase_Sallary.Text = txtBen_Laborer.Text = txtDep_Leave_Price.Text = txtHour_Day.Text = txtHour_Price.Text = "0";
                txtIns.Text = txtMax_Dep_Leave.Text = txtNight.Text = txtOther_Sallary.Text = txtRight_Child.Text = txtRight_Housing.Text = "0";
                txtSallary.Text = "0";
            }
        }
        private void Calculate_Sallry()
        {
            try
            {
                int Right_Housing = Convert.ToInt32(txtRight_Housing.Text);
                int Right_Child = Convert.ToInt32(txtRight_Child.Text);
                int Base_Sallary = Convert.ToInt32(txtHour_Day.Text) * 30 * Convert.ToInt32(txtHour_Price.Text);
                int Ben_Laborer = Convert.ToInt32(txtBen_Laborer.Text);
                int Other_Sallary = Convert.ToInt32(txtOther_Sallary.Text);
                int Inssurance = Convert.ToInt32(txtIns.Text);
                int Night = Convert.ToInt32(txtNight.Text);
                long Sallary = Convert.ToInt32(txtBase_Sallary.Text) + Right_Child + Right_Housing + Ben_Laborer + Other_Sallary + Night;
                txtSallary.Text = (Sallary - Inssurance).ToString();
            }
            catch
            {
            }
        }
        private void Delete_Data()
        {
            try
            {
                string query = "DELETE FROM tbl_Sallary WHERE Con_Code='" + txtCon_Code.Text + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                }
            }
            catch
            {
            }
        }
        public void SplashCircleStart()
        {
            Application.Run(new frmShow_Stores());
        }
        public frmSallary()
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

        private void frmSallary_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT Hour_In_Day FROM tbl_Contract", dataconnection, txtHour_Day);
            clsFunction.AutoComplete("SELECT Hour_Price FROM tbl_Contract", dataconnection, txtHour_Price);
            clsFunction.AutoComplete("SELECT Right_Housing FROM tbl_Contract", dataconnection, txtRight_Housing);
            clsFunction.AutoComplete("SELECT Right_Child FROM tbl_Contract", dataconnection, txtRight_Child);
            clsFunction.AutoComplete("SELECT Base_Sallary FROM tbl_Contract", dataconnection, txtBase_Sallary);
            clsFunction.AutoComplete("SELECT Ben_Laborer FROM tbl_Contract", dataconnection, txtBen_Laborer);
            clsFunction.AutoComplete("SELECT Other_Sallary FROM tbl_Contract", dataconnection, txtOther_Sallary);
            clsFunction.AutoComplete("SELECT Full_Sallary FROM tbl_Contract", dataconnection, txtSallary);
            clsFunction.AutoComplete("SELECT Max_Dep_Leave FROM tbl_Contract", dataconnection, txtMax_Dep_Leave);
            clsFunction.AutoComplete("SELECT Dep_Leave_Price FROM tbl_Contract", dataconnection, txtDep_Leave_Price);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void txtHour_Day_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtHour_Day);
            try
            {
                int Hour_In_Day = Convert.ToInt32(txtHour_Day.Text);
                int Hour_Price = Convert.ToInt32(txtHour_Price.Text);
                txtBase_Sallary.Text = (Hour_In_Day * 30 * Hour_Price).ToString();
            }
            catch
            {
            }
        }

        private void txtRight_Child_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtRight_Child);
            Calculate_Sallry();
        }

        private void txtBen_Laborer_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBen_Laborer);
            Calculate_Sallry();
        }

        private void txtRight_Housing_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtRight_Housing);
            Calculate_Sallry();
        }

        private void txtOther_Sallary_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtOther_Sallary);
            Calculate_Sallry();
        }

        private void txtBase_Sallary_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBase_Sallary);
            Calculate_Sallry();
        }

        private void txtSallary_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtSallary);
            Calculate_Sallry();
        }

        private void txtHour_Price_TextChanged_1(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtHour_Price);
            try
            {
                int Hour_In_Day = Convert.ToInt32(txtHour_Day.Text);
                int Hour_Price = Convert.ToInt32(txtHour_Price.Text);
                txtBase_Sallary.Text = (Hour_In_Day * 30 * Hour_Price).ToString();
                txtDep_Leave_Price.Text = ((Convert.ToInt32(txtHour_Price.Text) / 4) * 3).ToString();
            }
            catch
            {
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

            if (clsFunction.Error_Provider(txtHour_Day, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtHour_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtRight_Child, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBen_Laborer, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (clsFunction.Error_Provider(txtRight_Housing, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtOther_Sallary, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBase_Sallary, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtSallary, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (clsFunction.Error_Provider(txtMax_Dep_Leave, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtDep_Leave_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (clsFunction.Error_Provider(txtIns, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtNight, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                Delete_Data();
                errorProvider1.Clear();
                for (int i = 0; i < The_Term + 1; i++)
                {
                    string Year = Date.Substring(0, 4);
                    int Y = Convert.ToInt32(Year);
                    string Mounth = Date.Substring(5, 2);
                    string M = (Convert.ToInt32(Mounth) + i).ToString();
                    if (Convert.ToInt32(M) > 12)
                    {
                        Y++;
                        M=(Convert.ToInt32(M)-12).ToString();
                    }
                    if (Convert.ToInt32(M) > 0 && Convert.ToInt32(M) <= 9)
                    {
                        M = "0" + M.ToString();
                    }
                    string query = "INSERT INTO tbl_Sallary (Con_Code, Per_Code, Hour_In_Day, Hour_Price, Right_Housing, Right_Child, Base_Sallary, Ben_Laborer, Other_Sallary, Full_Sallary, Max_Dep_Leave, Dep_Leave_Price, Year, Mounth, Eydi, Per_Daryafti, Inssurance, Night_Sallary) VALUES ('" + txtCon_Code.Text + "','" + txtCode.Text + "','" + Convert.ToInt32(txtHour_Day.Text) + "','" + Convert.ToInt32(txtHour_Price.Text) + "','" + Convert.ToInt32(txtRight_Housing.Text) + "','" + Convert.ToInt32(txtRight_Child.Text) + "','" + Convert.ToInt32(txtBase_Sallary.Text) + "','" + Convert.ToInt32(txtBen_Laborer.Text) + "','" + Convert.ToInt32(txtOther_Sallary.Text) + "','" + Convert.ToInt64(txtSallary.Text) + "','" + float.Parse(txtMax_Dep_Leave.Text) + "','" + Convert.ToInt32(txtDep_Leave_Price.Text) + "','" + Y + "','" + M.ToString() + "',0,'" + Convert.ToInt64(txtSallary.Text) + "','" + Convert.ToInt32(txtIns.Text) + "','" + Convert.ToInt32(txtNight.Text) + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                        string query2 = "UPDATE tbl_Contract SET Max_Leave='" + Convert.ToInt32(txtMax_Dep_Leave.Text) + "', H_Day='" + Convert.ToInt32(txtHour_Day.Text) + "' WHERE Con_Code='" + txtCon_Code.Text + "'";
                        if (clsFunction.Execute(dataconnection, query2) == true)
                        {
                        }
                    }
                }
                new frmCircle_Progress().ShowDialog();
                Thread t = new Thread(new ThreadStart(SplashCircleStart));
                t.Start();
                t.Abort();
                this.Close();
            }
        }

        private void txtHour_Day_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtHour_Price.Focus();
        }

        private void txtHour_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtRight_Child.Focus();
        }

        private void txtRight_Child_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBen_Laborer.Focus();
        }

        private void txtBen_Laborer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtRight_Housing.Focus();
        }

        private void txtRight_Housing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtOther_Sallary.Focus();
        }

        private void txtOther_Sallary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBase_Sallary.Focus();
        }

        private void txtBase_Sallary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtIns.Focus();
        }

        private void txtSallary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtHour_Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtHour_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtRight_Child_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtBen_Laborer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtRight_Housing_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtOther_Sallary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtBase_Sallary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtSallary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtMax_Dep_Leave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDep_Leave_Price.Focus();
        }

        private void txtDep_Leave_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNight.Focus();
        }

        private void txtMax_Dep_Leave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDep_Leave_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDep_Leave_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtDep_Leave_Price);
        }

        private void txtIns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMax_Dep_Leave.Focus();
        }

        private void txtNight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtSallary.Focus();
        }

        private void txtNight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtIns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtIns_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtIns);
            Calculate_Sallry();
        }

        private void txtNight_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtNight);
            Calculate_Sallry();
        }
    }
}
