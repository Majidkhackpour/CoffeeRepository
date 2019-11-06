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
    public partial class frmPer_Log_Aouth : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public int Per_ID;
        string Mounth;
        string MM;
        public void Fill_Data(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Perssonel.Code, tbl_Account.Description FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code WHERE tbl_Perssonel.ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Per_ID = ID;
            txtAccCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtDescription.Text = dt.Rows[0].ItemArray[1].ToString();
            Fill_Year();
        }
        private void Fill_Year()
        {
            try
            {
                cmbAccount.Items.Clear();
                string Query = "SELECT DISTINCT Year FROM tbl_Sallary";
                string s_obj = "Year";
                clsFunction.FillComboBox(dataconnection, Query, cmbAccount, s_obj);
                cmbAccount.SelectedIndex = 0;
                try
                {
                    string Date=clsFunction.M2SH(DateTime.Now);
                    string Year = Date.Substring(0, 4);
                    cmbAccount.Text = Year;
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public frmPer_Log_Aouth()
        {
            InitializeComponent();
        }

        private void frmPer_Log_Aouth_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            lblMounth.Text = "";
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

        private void lblFarvardin_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblFarvardin);
        }

        private void lblFarvardin_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblFarvardin);
        }

        private void lblOrdibehesht_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblOrdibehesht);
        }

        private void lblOrdibehesht_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblOrdibehesht);
        }

        private void lblKhordad_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblKhordad);
        }

        private void lblKhordad_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblKhordad);
        }

        private void lblTir_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblTir);
        }

        private void lblTir_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblTir);
        }

        private void lblMordad_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblMordad);
        }

        private void lblMordad_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblMordad);
        }

        private void lblShahrivar_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblShahrivar);
        }

        private void lblShahrivar_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblShahrivar);
        }

        private void lblMehr_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblMehr);
        }

        private void lblMehr_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblMehr);
        }

        private void lblAban_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblAban);
        }

        private void lblAban_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblAban);
        }

        private void lblAzar_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblAzar);
        }

        private void lblAzar_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblAzar);
        }

        private void lblDey_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblDey);
        }

        private void lblDey_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblDey);
        }

        private void lblBahman_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblBahman);
        }

        private void lblBahman_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblBahman);
        }

        private void lblEsfand_MouseEnter(object sender, EventArgs e)
        {
            clsFunction.Red(lblEsfand);
        }

        private void lblEsfand_MouseLeave(object sender, EventArgs e)
        {
            clsFunction.Black(lblEsfand);
        }

        private void lblFarvardin_Click(object sender, EventArgs e)
        {
            Mounth = "فروردین";
            MM = "01";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Green;
        }

        private void lblOrdibehesht_Click(object sender, EventArgs e)
        {
            Mounth = "اردیبهشت";
            MM = "02";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Green;
        }

        private void lblKhordad_Click(object sender, EventArgs e)
        {
            Mounth = "خرداد";
            MM = "03";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Green;
        }

        private void lblTir_Click(object sender, EventArgs e)
        {
            Mounth = "تیر";
            MM = "04";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Red;
        }

        private void lblMordad_Click(object sender, EventArgs e)
        {
            Mounth = "مرداد";
            MM = "05";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Red;
        }

        private void lblShahrivar_Click(object sender, EventArgs e)
        {
            Mounth = "شهریور";
            MM = "06";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Red;
        }

        private void lblMehr_Click(object sender, EventArgs e)
        {
            Mounth = "مهر";
            MM = "07";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Orange;
        }

        private void lblAban_Click(object sender, EventArgs e)
        {
            Mounth = "آبان";
            MM = "08";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Orange;
        }

        private void lblAzar_Click(object sender, EventArgs e)
        {
            Mounth = "آذر";
            MM = "09";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.Orange;
        }

        private void lblDey_Click(object sender, EventArgs e)
        {
            Mounth = "دی";
            MM = "10";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.SkyBlue;
        }

        private void lblBahman_Click(object sender, EventArgs e)
        {
            Mounth = "بهمن";
            MM = "11";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.SkyBlue;
        }

        private void lblEsfand_Click(object sender, EventArgs e)
        {
            Mounth = "اسفند";
            MM = "12";
            lblMounth.Text = Mounth;
            lblMounth.ForeColor = Color.SkyBlue;
        }

        private void frmPer_Log_Aouth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
                lblFarvardin_Click(null, null);
            else if (e.KeyData == Keys.F2)
                lblOrdibehesht_Click(null, null);
            else if (e.KeyData == Keys.F3)
                lblKhordad_Click(null, null);
            else if (e.KeyData == Keys.F4)
                lblTir_Click(null, null);
            else if (e.KeyData == Keys.F5)
                lblMordad_Click(null, null);
            else if (e.KeyData == Keys.F6)
                lblShahrivar_Click(null, null);
            else if (e.KeyData == Keys.F7)
                lblMehr_Click(null, null);
            else if (e.KeyData == Keys.F8)
                lblAban_Click(null, null);
            else if (e.KeyData == Keys.F9)
                lblAzar_Click(null, null);
            else if (e.KeyData == Keys.F10)
                lblDey_Click(null, null);
            else if (e.KeyData == Keys.F11)
                lblBahman_Click(null, null);
            else if (e.KeyData == Keys.F12)
                lblEsfand_Click(null, null);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (lblMounth.Text == "")
            {
            }
            else
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Mounth FROM tbl_Sallary WHERE Year='" + Convert.ToInt32(cmbAccount.Text) + "' AND Mounth='" + MM + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows[0].ItemArray[0].ToString() == MM)
                        {
                            frmSallary_Aouth f = new frmSallary_Aouth();
                            f.Per_Id = Per_ID;
                            f.Per_Code = txtAccCode.Text;
                            f.Year = cmbAccount.Text;
                            f.Mounth_Dig = MM.ToString();
                            f.Mounth = lblMounth.Text;
                            f.Fill_Data(Per_ID);
                            f.ShowDialog();
                        }
                        else
                        {
                            frmMessage f = new frmMessage();
                            f.flag = 0;
                            f.lblMessage.Text = "اطلاعات حقوقی ماه انتخابی موجود نمی باشد";
                            f.ShowDialog();
                        }
                    }
                    catch
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "اطلاعات حقوقی ماه انتخابی موجود نمی باشد";
                        f.ShowDialog();
                    }
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "لطفا ماه فیش حقوقی را انتخاب نمایید";
                    f.ShowDialog();
                }
            }
        }
    }
}
