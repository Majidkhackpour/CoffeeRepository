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
    public partial class frmCheck_Page : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public int Check_ID;
        string Description;
        public frmCheck_Page()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCheck_Page_Load(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Check_Page.ID, tbl_Check_Page.Check_Number, tbl_Check_Page.Date_Arrival, tbl_Check_Page.Price, tbl_Check_Page.Bestankar_Name, tbl_Check_Page.Reciver_Name, tbl_Check_Page.Date_Tomorrow, tbl_Check_Page.Bestankar_Code,  tbl_Check_State.State_Name FROM tbl_Check_Page INNER JOIN tbl_Check_State ON tbl_Check_Page.State = tbl_Check_State.State WHERE tbl_Check_Page.ID='" + Check_ID + "' ORDER BY tbl_Check_Page.Check_Number ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            for (int i = 0; i < dgvStore.Rows.Count; i++)
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code='" + dgvStore.Rows[i].Cells["Bestankar_Code"].Value.ToString() + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Description = dt.Rows[0].ItemArray[0].ToString();
                    string query = "UPDATE tbl_Check_Page SET Bestankar_Name = N'" + Description + "' WHERE ID = '" + Convert.ToInt32(dgvStore.Rows[i].Cells["ID"].Value.ToString()) + "' AND Check_Number ='" + Convert.ToInt32(dgvStore.Rows[i].Cells["Check_Number"].Value.ToString()) + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                        string Query1 = "SELECT tbl_Check_Page.ID, tbl_Check_Page.Check_Number, tbl_Check_Page.Date_Arrival, tbl_Check_Page.Price, tbl_Check_Page.Bestankar_Name, tbl_Check_Page.Reciver_Name, tbl_Check_Page.Date_Tomorrow, tbl_Check_Page.Bestankar_Code,  tbl_Check_State.State_Name FROM tbl_Check_Page INNER JOIN tbl_Check_State ON tbl_Check_Page.State = tbl_Check_State.State WHERE tbl_Check_Page.ID='" + Check_ID + "' ORDER BY tbl_Check_Page.Check_Number ASC";
                        clsFunction.Display(Query1, dataconnection, dgvStore, lblCounter);
                    }
                }
                catch
                {
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void mnuDisable_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE tbl_Check_Page SET State = 4 WHERE ID = '" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Check_Number ='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از تغییر وضعیت چک به شماره " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "استفاده نشده")
                    {
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            frmCheck_Page_Load(null, null);
                        }
                    }
                    else if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() == "باطل")
                    {
                        frmMessage f1 = new frmMessage();
                        f1.flag = 0;
                        f1.lblMessage.Text = "این برگ چک از پیش باطل شده است";
                        f1.ShowDialog();
                    }
                    else
                    {
                        frmMessage f1 = new frmMessage();
                        f1.flag = 0;
                        f1.lblMessage.Text = "از این چک در اسناد حسابداری استفاده شده و امکان باطل کردن وجود ندارد";
                        f1.ShowDialog();
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به تغییر وضعیت این برگ چک نمی باشید";
                f.ShowDialog();
            }
        }
    }
}
