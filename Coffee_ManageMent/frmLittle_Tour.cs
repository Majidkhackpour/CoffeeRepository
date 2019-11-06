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
    public partial class frmLittle_Tour : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public void Form_Load()
        {
            txtBuy_Price.Text = txtEntity.Text = txtIncomming.Text = "0";
            txtIssued.Text = txtSell_Price.Text = "0";
            txtCode.Text = "";
            lblUnit1.Text = lblUnit2.Text = lblUnit3.Text = "";
        }
        public void Fill_Data(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Product.Buy_Price, tbl_Product.Sell_Price, tbl_Unit.Unit_Name FROM tbl_Product INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code WHERE tbl_Product.P_Code='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = ID.ToString();
            txtBuy_Price.Text = dt.Rows[0].ItemArray[0].ToString();
            txtSell_Price.Text = dt.Rows[0].ItemArray[1].ToString();
            lblUnit1.Text = dt.Rows[0].ItemArray[2].ToString();
            lblUnit2.Text = dt.Rows[0].ItemArray[2].ToString();
            lblUnit3.Text = dt.Rows[0].ItemArray[2].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT SUM(Incoming), SUM(Issued) FROM tbl_Tour_Of_Product WHERE P_Code='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            txtIncomming.Text = dt2.Rows[0].ItemArray[0].ToString();
            txtIssued.Text = dt2.Rows[0].ItemArray[1].ToString();
            txtEntity.Text = (Convert.ToInt32(txtIncomming.Text) - Convert.ToInt32(txtIssued.Text)).ToString();
        }
        public frmLittle_Tour()
        {
            InitializeComponent();
        }

        private void frmLittle_Tour_Load(object sender, EventArgs e)
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
    }
}
