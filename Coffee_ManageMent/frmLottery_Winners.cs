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
    public partial class frmLottery_Winners : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public void Display_Winners(int Number)
        {
            lblID.Text = Number.ToString();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Award FROM tbl_Header_Lottery WHERE Number='" + Number + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblDate.Text = dt.Rows[0].ItemArray[0].ToString();
            lblAward.Text = dt.Rows[0].ItemArray[1].ToString();
            string query = "SELECT tbl_Body_Lottery.Code, tbl_Account.Description, tbl_PhoneBook.Phone, tbl_PhoneBook.Mobile FROM tbl_Body_Lottery INNER JOIN tbl_Account ON tbl_Body_Lottery.Code = tbl_Account.Code INNER JOIN tbl_PhoneBook ON tbl_Body_Lottery.Code = tbl_PhoneBook.Code WHERE tbl_Body_Lottery.Number='" + Number + "'";
            clsFunction.Display(query, dataconnection, dgvAccount, lblCounter);
        }
        public frmLottery_Winners()
        {
            InitializeComponent();
        }

        private void frmLottery_Winners_Load(object sender, EventArgs e)
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

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccount.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }
    }
}
