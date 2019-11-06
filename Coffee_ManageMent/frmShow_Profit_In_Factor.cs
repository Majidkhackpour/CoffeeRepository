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
    public partial class frmShow_Profit_In_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public void Fill_Data(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description, tbl_Header_Sales_Factor.Date, tbl_Header_Sales_Factor.Sum_Factor FROM tbl_Header_Sales_Factor INNER JOIN tbl_Account ON tbl_Header_Sales_Factor.C_Code = tbl_Account.Code WHERE tbl_Header_Sales_Factor.ID='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            txtCustomer_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[1].ToString();
            txtSum_Factor.Text = dt.Rows[0].ItemArray[2].ToString();
            Display_Data();
        }
        private void Display_Data()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Body_Sales_Factor.P_Code, tbl_Product.P_Show_Name, tbl_Product.Buy_Price, tbl_Body_Sales_Factor.Price FROM tbl_Product INNER JOIN tbl_Body_Sales_Factor ON tbl_Product.P_Code = tbl_Body_Sales_Factor.P_Code WHERE tbl_Body_Sales_Factor.ID='" + Convert.ToInt64(txtID.Text) + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStore.DataSource = dt;
            Sum_Sell();
            int P = 0;
            for (int i = 0; i < dgvStore.Rows.Count; i++)
            {
                P += Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value);
            }
            lblBuy.Text = P.ToString();
            Calculate();
        }
        private void Sum_Sell()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM (Price) FROM tbl_Body_Sales_Factor WHERE ID='" + Convert.ToInt64(txtID.Text) + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblSell.Text = dt.Rows[0].ItemArray[0].ToString();
        }
        private void Calculate()
        {
            try
            {
                lblState.Text = (Convert.ToInt64(lblSell.Text) - Convert.ToInt64(lblBuy.Text)).ToString();
                if (Convert.ToInt32(lblState.Text) > 0)
                {
                    lblState_Name.Text = "سود";
                    lblState_Name.ForeColor = Color.ForestGreen;
                }
                else if (Convert.ToInt32(lblState.Text) == 0)
                {
                    lblState_Name.Text = "بی حساب";
                    lblState_Name.ForeColor = Color.Black;
                }
                else if (Convert.ToInt32(lblState.Text) < 0)
                {
                    int SUM = Convert.ToInt32(lblState.Text);
                    lblState_Name.Text = "زیان";
                    lblState_Name.ForeColor = Color.Red;
                    lblState.Text = (Math.Abs(SUM)).ToString();
                }
                lblState.Text = Convert.ToInt32(lblState.Text).ToString("n0");
                lblSell.Text = Convert.ToInt32(lblSell.Text).ToString("n0");
                lblBuy.Text = Convert.ToInt32(lblBuy.Text).ToString("n0");
            }
            catch
            {
            }
        }
        public frmShow_Profit_In_Factor()
        {
            InitializeComponent();
        }

        private void frmShow_Profit_In_Factor_Load(object sender, EventArgs e)
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

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }
    }
}
