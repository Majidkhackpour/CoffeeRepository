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
    public partial class frmSetting_Sales_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        public frmSetting_Sales_Factor()
        {
            InitializeComponent();
        }

        private void frmSetting_Sales_Factor_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Entity_Control, Other_Customer_Default, Price_Control, Point, Price FROM tbl_Setting_Sales_Factor WHERE ID=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                chbEntity_Control.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[0]);
                chbOther_Customer_Default.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[1]);
                chbPrice_Control.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[2]);
                txtPoint.Text = dt.Rows[0].ItemArray[3].ToString();
                txtPrice.Text = dt.Rows[0].ItemArray[4].ToString();
            }
            catch
            {
                txtPrice.Text = txtPoint.Text = "0";
                chbEntity_Control.Checked = false;
                chbOther_Customer_Default.Checked = false;
                chbPrice_Control.Checked = false;
            }
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

        private void btnFinish1_Click(object sender, EventArgs e)
        {
            string query;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting_Sales_Factor", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            frmMessage f = new frmMessage();
            f.lblMessage.Text = "تنظیمات فاکتور فروش ست شده است." + "\n" + "ادامه می دهید؟";
            f.flag = 1;
            f.ShowDialog();
            if (f.Resault == 0)
            {
                if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
                {
                    query = "INSERT INTO tbl_Setting_Sales_Factor (ID, Entity_Control, Other_Customer_Default, Price_Control, Point, Price) VALUES (1,'" + Convert.ToBoolean(chbEntity_Control.Checked) + "','" + Convert.ToBoolean(chbOther_Customer_Default.Checked) + "','" + Convert.ToBoolean(chbPrice_Control.Checked) + "','" + Convert.ToInt32(txtPoint.Text) + "','" + Convert.ToInt32(txtPrice.Text) + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
                else
                {
                    query = "UPDATE tbl_Setting_Sales_Factor SET Entity_Control = '" + Convert.ToBoolean(chbEntity_Control.Checked) + "', Other_Customer_Default = '" + Convert.ToBoolean(chbOther_Customer_Default.Checked) + "', Price_Control = '" + Convert.ToBoolean(chbPrice_Control.Checked) + "', Point='" + Convert.ToInt32(txtPoint.Text) + "', Price='" + Convert.ToInt32(txtPrice.Text) + "' WHERE ID=1";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
            }
        }

        private void txtPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtPrice);
        }
    }
}
