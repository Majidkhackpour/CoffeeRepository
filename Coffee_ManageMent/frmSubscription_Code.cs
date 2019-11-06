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
    public partial class frmSubscription_Code : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        int grp;
        public void Find_Sub_Code()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Sub_Code FROM tbl_Customer WHERE Code='" + txtCode.Text + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0].ItemArray[0].ToString() == "")
            {
                txtSub_Code.Text = "";
                picDelete.Enabled = false;
                chbAuto_Code.Enabled = true;
            }
            else
            {
                txtSub_Code.Text = dt.Rows[0].ItemArray[0].ToString();
                picDelete.Enabled = true;
                chbAuto_Code.Enabled = false;
            }
        }
        public void SplashCircleStart()
        {
            Application.Run(new frmShow_Customer());
        }
        private bool Check_Sub_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Sub_Code FROM tbl_Customer WHERE Sub_Code='" + Convert.ToInt32(txtSub_Code.Text) + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        grp = (int)dr["Sub_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (grp == Convert.ToInt32(txtSub_Code.Text))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmSubscription_Code()
        {
            InitializeComponent();
        }

        private void frmSubscription_Code_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            toolTip1.SetToolTip(picDelete, "حذف کد اشتراک");
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

        private void chbAuto_Code_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAuto_Code.Checked)
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MAX(Sub_Code) FROM tbl_Customer", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    txtSub_Code.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();
                    picDelete.Enabled = false;
                }
                catch
                {
                    txtSub_Code.Text = "1000";
                }
            }
            else if (chbAuto_Code.Checked == false)
            {
                txtSub_Code.Text = "";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtCode, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                if (Check_Sub_Code() == true)
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "اشتراک تکراری است";
                    f.ShowDialog();
                }
                else
                {
                    string query = "UPDATE tbl_Customer SET Sub_Code = '" + Convert.ToInt32(txtSub_Code.Text) + "' WHERE Code = '" + txtCode.Text + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                        new frmCircle_Progress().ShowDialog();
                        Thread t = new Thread(new ThreadStart(SplashCircleStart));
                        t.Start();
                        t.Abort();
                        this.Close();
                    }
                }
            }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            string query1 = "UPDATE tbl_Customer SET Sub_Code = NULL WHERE Code = '" + txtCode.Text + "'";
            frmMessage f = new frmMessage();
            f.lblMessage.Text = "آیا از حذف کد اشتراک برای " + txtName.Text + " " + "اطمینان دارید؟";
            f.flag = 1;
            f.ShowDialog();
            if (f.Resault == 0)
            {
                if (clsFunction.Execute(dataconnection, query1) == true)
                    this.Close();
            }
        }

        private void txtSub_Code_KeyPress(object sender, KeyPressEventArgs e)
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
