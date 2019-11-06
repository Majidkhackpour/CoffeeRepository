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
    public partial class frmSallary_Aouth : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public int Per_Id, Kasr_Price, Ezafe_Price;
        public string Per_Code, Year, Mounth_Dig, Mounth;
        public void Fill_Data(int ID)
        {
            Cleanner();
            lblYear.Text = Year;
            lblMounth_Dig.Text = Mounth_Dig;
            lblMounth.Text = Mounth;
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description, tbl_Perssonel.Perssonel_Code, tbl_Perssonel.National_Code, tbl_Perssonel.Code, tbl_Perssonel.Father_Name, tbl_Perssonel.Date_Birth, tbl_Perssonel.Place_Birth, tbl_Perssonel.Pic,  tbl_Contract.Con_Code, tbl_Contract.H_Day, tbl_Sallary.Hour_Price, tbl_Sallary.Right_Housing, tbl_Sallary.Right_Child, tbl_Sallary.Ben_Laborer, tbl_Sallary.Other_Sallary, tbl_Sallary.Night_Sallary,  tbl_Sallary.Eydi, tbl_Sallary.Inssurance, tbl_Sallary.Dep_Leave_Price, tbl_Sallary.Base_Sallary, tbl_Sallary.Full_Sallary FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Contract ON tbl_Account.Code = tbl_Contract.Code INNER JOIN tbl_Sallary ON tbl_Account.Code = tbl_Sallary.Per_Code AND tbl_Contract.Con_Code = tbl_Sallary.Con_Code WHERE tbl_Perssonel.ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblID.Text = ID.ToString();
            lblName.Text = dt.Rows[0].ItemArray[0].ToString();
            lblPer_Code.Text = dt.Rows[0].ItemArray[1].ToString();
            lblNat_Code.Text = dt.Rows[0].ItemArray[2].ToString();
            lblCode.Text = dt.Rows[0].ItemArray[3].ToString();
            lblFather_Name.Text = dt.Rows[0].ItemArray[4].ToString();
            lblDate_Birth.Text = dt.Rows[0].ItemArray[5].ToString();
            lblPlace_Birth.Text = dt.Rows[0].ItemArray[6].ToString();
            lblCon_Code.Text = dt.Rows[0].ItemArray[8].ToString();
            txtHour_Day.Text = dt.Rows[0].ItemArray[9].ToString();
            txtHour_Price.Text = dt.Rows[0].ItemArray[10].ToString();
            txtRight_Housing.Text = dt.Rows[0].ItemArray[11].ToString();
            txtRight_Child.Text = dt.Rows[0].ItemArray[12].ToString();
            txtBen_Laborer.Text = dt.Rows[0].ItemArray[13].ToString();
            txtOther_Sallary.Text = dt.Rows[0].ItemArray[14].ToString();
            txtNight.Text = dt.Rows[0].ItemArray[15].ToString();
            txtEydi.Text = dt.Rows[0].ItemArray[16].ToString();
            txtIns.Text = dt.Rows[0].ItemArray[17].ToString();
            txtLeave_Price.Text = dt.Rows[0].ItemArray[18].ToString();
            txtBase_Sallary.Text = dt.Rows[0].ItemArray[19].ToString();
            txtSallary.Text = dt.Rows[0].ItemArray[20].ToString();
            try
            {
                byte[] myarray = null;
                myarray = (byte[])dt.Rows[0].ItemArray[7];
                System.IO.MemoryStream mymemory = new System.IO.MemoryStream(myarray);
                PictureBox.Image = Image.FromStream(mymemory);
            }
            catch
            {
            }
            Set_Hozor(ID);
            Set_Kasr(ID);
            Set_Ezafe(ID);
            Calculate();
        }
        private void Cleanner()
        {
            lblCode.Text = lblCon_Code.Text = lblDate_Birth.Text = "";
            lblFather_Name.Text = lblID.Text = lblMounth.Text = "";
            lblMounth_Dig.Text = lblName.Text = lblNat_Code.Text = "";
            lblPer_Code.Text = lblPlace_Birth.Text = lblYear.Text = "";
            txtBase_Sallary.Text = txtBen_Laborer.Text = txtEydi.Text = "0";
            txtHour_Day.Text = txtHour_Price.Text = lblTotal.Text = "0";
            txtIns.Text = txtEzafe_Price.Text = txtKasr_Price.Text = "0";
            txtLeave_Price.Text = txtNight.Text = txtOther_Sallary.Text = "0";
            txtRight_Child.Text = txtRight_Housing.Text = txtSallary.Text = "0";
            txtHozor.Text = txtKasr.Text = txtEzafe.Text = "00:00";
        }
        private void Set_Hozor(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM (Hoz_Hour), SUM (Hoz_Min) FROM tbl_LogPerssonel WHERE Per_ID='" + ID + "' AND Year='" + Year + "' AND Mounth='" + Mounth_Dig + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int Hour = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            int Min = Convert.ToInt32(dt.Rows[0].ItemArray[1]);
            if (Min >= 60)
            {
                Min -= 60;
                Hour++;
            }
            txtHozor.Text = Hour.ToString() + ":" + Min.ToString();
        }
        private void Set_Ezafe(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM (Ez_Hour), SUM (Ez_Min) FROM tbl_LogPerssonel WHERE Per_ID='" + ID + "' AND Year='" + Year + "' AND Mounth='" + Mounth_Dig + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int Hour = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            int Min = Convert.ToInt32(dt.Rows[0].ItemArray[1]);
            if (Min >= 60)
            {
                Min -= 60;
                Hour++;
            }
            txtEzafe.Text = Hour.ToString() + ":" + Min.ToString();
            try
            {
                Ezafe_Price = Convert.ToInt32(txtLeave_Price.Text) * Hour;
                txtEzafe_Price.Text = Ezafe_Price.ToString();
            }
            catch
            {
                txtEzafe_Price.Text = "0";
            }
        }
        private void Set_Kasr(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM (Kasr_Hour), SUM (Kasr_Min) FROM tbl_LogPerssonel WHERE Per_ID='" + ID + "' AND Year='" + Year + "' AND Mounth='" + Mounth_Dig + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int Hour = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            int Min = Convert.ToInt32(dt.Rows[0].ItemArray[1]);
            if (Min >= 60)
            {
                Min -= 60;
                Hour++;
            }
            txtKasr.Text = Hour.ToString() + ":" + Min.ToString();
            try
            {
                Ezafe_Price = Convert.ToInt32(txtLeave_Price.Text) * Hour;
                txtKasr_Price.Text = Ezafe_Price.ToString();
            }
            catch
            {
                txtKasr_Price.Text = "0";
            }
        }
        private void Calculate()
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
                int Eydi = Convert.ToInt32(txtEydi.Text);
                int Ezafe = Convert.ToInt32(txtEzafe_Price.Text);
                int Kasr = Convert.ToInt32(txtKasr_Price.Text);
                long Hoqoq = Convert.ToInt32(txtBase_Sallary.Text) + Right_Child + Right_Housing + Ben_Laborer + Other_Sallary + Night;
                txtSallary.Text = (Hoqoq - Inssurance).ToString();
                long Ezafat = Hoqoq + Eydi + Ezafe;
                long Kosorat = Inssurance + Kasr;
                lblTotal.Text = (Ezafat - Kosorat).ToString();
            }
            catch
            {
                lblTotal.Text = "0";
            }
        }
        public frmSallary_Aouth()
        {
            InitializeComponent();
        }

        private void frmSallary_Aouth_Load(object sender, EventArgs e)
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

        private void txtHour_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtHour_Price);
            try
            {
                int Hour_In_Day = Convert.ToInt32(txtHour_Day.Text);
                int Hour_Price = Convert.ToInt32(txtHour_Price.Text);
                txtBase_Sallary.Text = (Hour_In_Day * 30 * Hour_Price).ToString();
                txtLeave_Price.Text = ((Convert.ToInt32(txtHour_Price.Text) / 4) * 3).ToString();
            }
            catch
            {
            }
        }

        private void txtRight_Housing_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtRight_Housing);
            Calculate();
        }

        private void txtRight_Child_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtRight_Child);
            Calculate();
        }

        private void txtBen_Laborer_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBen_Laborer);
            Calculate();
        }

        private void txtOther_Sallary_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtOther_Sallary);
            Calculate();
        }

        private void txtNight_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtNight);
            Calculate();
        }

        private void txtEydi_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtEydi);
            Calculate();
        }

        private void txtIns_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtIns);
            Calculate();
        }

        private void txtLeave_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtLeave_Price);
            Set_Ezafe(Per_Id);
            Set_Kasr(Per_Id);
        }

        private void txtBase_Sallary_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBase_Sallary);
            Calculate();
        }

        private void txtSallary_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtSallary);
            Calculate();
        }

        private void txtEzafe_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtEzafe_Price);
            Calculate();
        }

        private void txtKasr_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtKasr_Price);
            Calculate();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtHour_Day, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtHour_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtRight_Child, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBen_Laborer, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (clsFunction.Error_Provider(txtRight_Housing, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtOther_Sallary, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBase_Sallary, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtSallary, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (clsFunction.Error_Provider(txtEzafe, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtLeave_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (clsFunction.Error_Provider(txtIns, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtNight, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (clsFunction.Error_Provider(txtEydi, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtKasr, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                string query = "UPDATE tbl_Sallary SET Hour_In_Day = '" + Convert.ToInt32(txtHour_Day.Text) + "', Hour_Price = '" + Convert.ToInt32(txtHour_Price.Text) + "', Right_Housing = '" + Convert.ToInt32(txtRight_Housing.Text) + "', Right_Child = '" + Convert.ToInt32(txtRight_Child.Text) + "',  Base_Sallary = '" + Convert.ToInt64(txtBase_Sallary.Text) + "', Ben_Laborer = '" + Convert.ToInt32(txtBen_Laborer.Text) + "', Other_Sallary = '" + Convert.ToInt32(txtOther_Sallary.Text) + "', Full_Sallary = '" + Convert.ToInt64(txtSallary.Text) + "', Dep_Leave_Price = '" + Convert.ToInt32(txtLeave_Price.Text) + "',  Inssurance = '" + Convert.ToInt32(txtIns.Text) + "', Night_Sallary = '" + Convert.ToInt32(txtNight.Text) + "', Eydi = '" + Convert.ToInt32(txtEydi.Text) + "', Per_Daryafti = '" + Convert.ToInt64(lblTotal.Text) + "', Ezafe = '" + txtEzafe.Text + "', Kasr = '" + txtKasr.Text + "', Hozor = '" + txtHozor.Text + "', Ezafe_Price = '" + Convert.ToInt32(txtEzafe_Price.Text) + "', Kasr_Price = '" + Convert.ToInt32(txtKasr_Price.Text) + "' WHERE Con_Code = '" + lblCon_Code.Text + "' AND Per_Code = '" + lblCode.Text + "' AND Year = '" + Convert.ToInt32(lblYear.Text) + "' AND Mounth = '" + lblMounth_Dig.Text + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                {
                    this.Close();
                }
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

        private void txtEydi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLeave_Price_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHour_Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtHour_Day_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtHour_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtRight_Housing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtRight_Child_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtBen_Laborer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtOther_Sallary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtEydi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtIns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtLeave_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtBase_Sallary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtSallary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtEzafe_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtKasr_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtKasr_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtEzafe_Price_KeyPress(object sender, KeyPressEventArgs e)
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
