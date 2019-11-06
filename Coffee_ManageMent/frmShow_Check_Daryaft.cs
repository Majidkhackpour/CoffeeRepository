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
    public partial class frmShow_Check_Daryaft : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        int Doc_Number;
        private void Get_Max_Doc_Number()
        {
            try
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Number FROM tbl_Transaction WHERE Date='" + clsFunction.M2SH(DateTime.Now) + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
                catch
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Doc_Number) FROM tbl_Transaction", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;
                }
            }
            catch
            {
                Doc_Number = 1;
            }
        }
        public frmShow_Check_Daryaft()
        {
            InitializeComponent();
        }

        private void frmShow_Check_Daryaft_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Check_Daryaft.ID, tbl_Check_Daryaft.Check_Number, tbl_Check_Daryaft.Sett_Date, tbl_Check_Daryaft.Price, tbl_Check_Daryaft.Acc_Code, tbl_Account.Description, tbl_Check_Daryaft.Safe_Reciver, tbl_Check_Daryaft.Bank,  tbl_Check_State.State_Name, tbl_Check_Type.Type_Name FROM tbl_Check_Daryaft INNER JOIN tbl_Account ON tbl_Check_Daryaft.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_State ON tbl_Check_Daryaft.State = tbl_Check_State.State INNER JOIN tbl_Check_Type ON tbl_Check_Daryaft.Type = tbl_Check_Type.Check_Type WHERE tbl_Check_Daryaft.State=1 ORDER BY tbl_Check_Daryaft.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
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

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheck_Daryaft f = new frmCheck_Daryaft();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuShow_All_Click(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Check_Daryaft.ID, tbl_Check_Daryaft.Check_Number, tbl_Check_Daryaft.Sett_Date, tbl_Check_Daryaft.Price, tbl_Check_Daryaft.Acc_Code, tbl_Account.Description, tbl_Check_Daryaft.Safe_Reciver, tbl_Check_Daryaft.Bank,  tbl_Check_State.State_Name, tbl_Check_Type.Type_Name FROM tbl_Check_Daryaft INNER JOIN tbl_Account ON tbl_Check_Daryaft.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_State ON tbl_Check_Daryaft.State = tbl_Check_State.State INNER JOIN tbl_Check_Type ON tbl_Check_Daryaft.Type = tbl_Check_Type.Check_Type ORDER BY tbl_Check_Daryaft.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuRecive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "فقط چک های پاس نشده قابل ویرایش می باشند";
                    f.ShowDialog();
                }
                else
                {
                    frmCheck_Daryaft f = new frmCheck_Daryaft();
                    f.op = "Edit";
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "چک دریافتنی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "فقط چک های پاس نشده قابل حذف می باشند";
                    f.ShowDialog();
                }
                else
                {
                    string query1 = "DELETE FROM tbl_Check_Daryaft WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'";
                    string query2 = "DELETE FROM tbl_Transaction WHERE Parent=18 AND Parent_Code='" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف چک دریافتنی از " + dgvStore.CurrentRow.Cells["Description"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                            frmShow_Check_Daryaft_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این چک دریافتنی نمی باشید";
                f.ShowDialog();
            }
        }

        private void frmShow_Check_Daryaft_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Check_Daryaft.ID, tbl_Check_Daryaft.Check_Number, tbl_Check_Daryaft.Sett_Date, tbl_Check_Daryaft.Price, tbl_Check_Daryaft.Acc_Code, tbl_Account.Description, tbl_Check_Daryaft.Safe_Reciver, tbl_Check_Daryaft.Bank,  tbl_Check_State.State_Name, tbl_Check_Type.Type_Name FROM tbl_Check_Daryaft INNER JOIN tbl_Account ON tbl_Check_Daryaft.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_State ON tbl_Check_Daryaft.State = tbl_Check_State.State INNER JOIN tbl_Check_Type ON tbl_Check_Daryaft.Type = tbl_Check_Type.Check_Type WHERE tbl_Check_Daryaft.State=1 ORDER BY tbl_Check_Daryaft.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheck_Daryaft f = new frmCheck_Daryaft();
                f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grpAccount.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "چک دریافتنی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuSend_Bank_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما فقط مجاز به واگذاری اسناد پاس نشده می باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmCheck_Asignment f = new frmCheck_Asignment();
                    f.Fill_Bank();
                    f.cmbAssignor.Enabled = false;
                    f.Fill_cmbAssignor();
                    f.cmbAssignor.Text = dgvStore.CurrentRow.Cells["Safe_Reciver"].Value.ToString();
                    f.Check_ID = Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value);
                    f.Check_Number = dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString();
                    f.Check_Price = Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value);
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void mnuSend_Safe_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما فقط مجاز به واگذاری اسناد پاس نشده می باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmCheck_Asignment f = new frmCheck_Asignment();
                    f.Fill_Safe();
                    f.cmbAssignor.Enabled = false;
                    f.Fill_cmbAssignor();
                    f.cmbAssignor.Text = dgvStore.CurrentRow.Cells["Safe_Reciver"].Value.ToString();
                    f.Check_ID = Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value);
                    f.Check_Number = dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString();
                    f.Check_Price = Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value);
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void mnuDaryaft_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما فقط مجاز به دریافت اسناد پاس نشده می باشید";
                f.ShowDialog();
            }
            else
            {
                string Mooen = "";
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code, Parent FROM tbl_Account WHERE Description LIKE N'" + dgvStore.CurrentRow.Cells["Safe_Reciver"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string Ass_Code = dt.Rows[0].ItemArray[0].ToString();
                if (dt.Rows[0].ItemArray[1].ToString() == "10")
                    Mooen = "10101";
                else
                    Mooen = "10102";
                DateTime Check_Date = Convert.ToDateTime(dgvStore.CurrentRow.Cells["Sett_Date"].Value.ToString());
                DateTime Today = Convert.ToDateTime(clsFunction.M2SH(DateTime.Now));
                if (Check_Date > Today)
                {
                    string Distance = (Check_Date - Today).TotalDays.ToString();
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "هنوز " + Distance + " " + "روز به تاریخ سررسید چک زمان باقی مانده است.";
                    f.flag = 0;
                    f.ShowDialog();
                }
                else
                {
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از وصول چک به شماره ی " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        Get_Max_Doc_Number();
                        string query1 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Ass_Code + "','" + Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value) + "',N'" + "وصول چک شماره " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10201" + "',18,'" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "')";
                        string query2 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Ass_Code + "','" + Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value) + "',N'" + "وصول چک شماره " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + Mooen + "',18,'" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "')";
                        string query3 = "UPDATE tbl_Check_Daryaft SET State=0 WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'";
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                            frmShow_Check_Daryaft_Activated(null, null);
                    }
                }
            }
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما فقط مجاز به برگشت زدن اسناد پاس نشده می باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmCheck_Daryaft_Backing f = new frmCheck_Daryaft_Backing();
                    f.op = "Bargasht";
                    f.lblTitle.Text = "برگشت چک";
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                    f.Check_Number = dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString();
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void mnuReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما فقط مجاز به استرداد اسناد پاس نشده می باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmCheck_Daryaft_Backing f = new frmCheck_Daryaft_Backing();
                    f.op = "Esterdad";
                    f.lblTitle.Text = "استرداد چک";
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                    f.Check_Number = dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString();
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void mnuPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما فقط مجاز به خرج اسناد پاس نشده می باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmCheck_Daryaft_Backing f = new frmCheck_Daryaft_Backing();
                    f.op = "Kharj";
                    f.lblTitle.Text = "خرج چک";
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                    f.Check_Number = dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString();
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Check_Daryaft.ID, tbl_Check_Daryaft.Check_Number, tbl_Check_Daryaft.Sett_Date, tbl_Check_Daryaft.Price, tbl_Check_Daryaft.Acc_Code, tbl_Account.Description, tbl_Check_Daryaft.Safe_Reciver, tbl_Check_Daryaft.Bank,  tbl_Check_State.State_Name, tbl_Check_Type.Type_Name FROM tbl_Check_Daryaft INNER JOIN tbl_Account ON tbl_Check_Daryaft.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_State ON tbl_Check_Daryaft.State = tbl_Check_State.State INNER JOIN tbl_Check_Type ON tbl_Check_Daryaft.Type = tbl_Check_Type.Check_Type WHERE tbl_Check_Daryaft.Check_Number LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Daryaft.Bank LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_State.State_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Type.Type_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Check_Daryaft.ID DESC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuChange_State_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Parent FROM tbl_Account WHERE Description LIKE N'" + dgvStore.CurrentRow.Cells["Safe_Reciver"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() == "20")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما مجاز به تغییر وضعیت چک های واگذار نشده، نمی باشید.";
                    f.ShowDialog();
                }
                if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده" && dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "برگشتی")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما فقط مجاز به دریافت اسناد پاس نشده می باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmChange_Check_State f = new frmChange_Check_State();
                    f.op = "Daryaft";
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value));
                    f.ShowDialog();
                }
            }
            catch
            {
            }
        }
    }
}
