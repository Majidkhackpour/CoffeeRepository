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
    public partial class frmCustomer_Little_Tour : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public void Fill_Data(string Code)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description, tbl_Customer.Modified, tbl_Customer.Last_Factor_Price, tbl_Customer.Last_Factor_Date FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code AND tbl_Customer.Code = tbl_Account.Code WHERE tbl_Customer.Code='" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblCode.Text = Code;
            lblName.Text = dt.Rows[0].ItemArray[0].ToString();
            lblDate.Text = dt.Rows[0].ItemArray[1].ToString();
            lblLast_Price.Text = dt.Rows[0].ItemArray[2].ToString();
            lblLast_Date.Text = dt.Rows[0].ItemArray[3].ToString();
            Sum_Factor(Code);
            lblLast_Price.Text = (Convert.ToInt32(lblLast_Price.Text)).ToString("N0");
            lblSum.Text = (Convert.ToInt32(lblSum.Text)).ToString("N0");
        }

        private void Sum_Factor(string Code)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM (Sum_Factor) FROM tbl_Header_Sales_Factor WHERE C_Code='" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblSum.Text = dt.Rows[0].ItemArray[0].ToString();
        }

        public frmCustomer_Little_Tour()
        {
            InitializeComponent();
        }

        private void frmCustomer_Little_Tour_Load(object sender, EventArgs e)
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
