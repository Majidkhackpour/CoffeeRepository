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
    public partial class frmShow_Check_Pardakht : Form
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
        public frmShow_Check_Pardakht()
        {
            InitializeComponent();
        }

        private void frmShow_Check_Pardakht_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Check_Pardakht.ID, tbl_Check_Pardakht.Check_Number, tbl_Check_Pardakht.ID_Check, tbl_Check_Pardakht.Date_Of_Arrivall, tbl_Check_Pardakht.Price, tbl_Check_Pardakht.ID_Bank, tbl_Check_Pardakht.Payer,tbl_Account.Description, tbl_Check_Pardakht.Acc_Code,  tbl_Check_Pardakht.Dar_Vajh, tbl_Check_Pardakht.Date, tbl_Check_Type.Type_Name, tbl_Check_State.State_Name FROM tbl_Check_Pardakht INNER JOIN tbl_Account ON tbl_Check_Pardakht.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_Type ON tbl_Check_Pardakht.Type = tbl_Check_Type.Check_Type INNER JOIN tbl_Check_State ON tbl_Check_Pardakht.State = tbl_Check_State.State WHERE tbl_Check_Pardakht.State=1 ORDER BY tbl_Check_Pardakht.ID DESC";
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
                frmCheck_Pardakht f = new frmCheck_Pardakht();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Check_Pardakht_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Check_Pardakht.ID, tbl_Check_Pardakht.Check_Number, tbl_Check_Pardakht.ID_Check, tbl_Check_Pardakht.Date_Of_Arrivall, tbl_Check_Pardakht.Price, tbl_Check_Pardakht.ID_Bank, tbl_Check_Pardakht.Payer,tbl_Account.Description, tbl_Check_Pardakht.Acc_Code,  tbl_Check_Pardakht.Dar_Vajh, tbl_Check_Pardakht.Date, tbl_Check_Type.Type_Name, tbl_Check_State.State_Name FROM tbl_Check_Pardakht INNER JOIN tbl_Account ON tbl_Check_Pardakht.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_Type ON tbl_Check_Pardakht.Type = tbl_Check_Type.Check_Type INNER JOIN tbl_Check_State ON tbl_Check_Pardakht.State = tbl_Check_State.State WHERE tbl_Check_Pardakht.State=1 ORDER BY tbl_Check_Pardakht.ID DESC";
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
                    frmCheck_Pardakht f = new frmCheck_Pardakht();
                    f.op = "Edit";
                    f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "چک پرداختنی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuShow_All_Click(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Check_Pardakht.ID, tbl_Check_Pardakht.Check_Number,tbl_Check_Pardakht.ID_Check, tbl_Check_Pardakht.Date_Of_Arrivall, tbl_Check_Pardakht.Price, tbl_Check_Pardakht.ID_Bank, tbl_Check_Pardakht.Payer,tbl_Account.Description, tbl_Check_Pardakht.Acc_Code,  tbl_Check_Pardakht.Dar_Vajh, tbl_Check_Pardakht.Date, tbl_Check_Type.Type_Name, tbl_Check_State.State_Name FROM tbl_Check_Pardakht INNER JOIN tbl_Account ON tbl_Check_Pardakht.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_Type ON tbl_Check_Pardakht.Type = tbl_Check_Type.Check_Type INNER JOIN tbl_Check_State ON tbl_Check_Pardakht.State = tbl_Check_State.State ORDER BY tbl_Check_Pardakht.ID DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
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
                    string query1 = "DELETE FROM tbl_Check_Pardakht WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'";
                    string query2 = "DELETE FROM tbl_Transaction WHERE Parent=19 AND Parent_Code='" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "'";
                    string query3 = "UPDATE tbl_Check_Page SET Date_Arrival='" + "" + "', Price='" + 0 + "', Bestankar_Name='" + "" + "', Reciver_Name='" + "" + "', Date_Tomorrow='" + "" + "', State=3, Bestankar_Code='" + "" + "' WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID_Check"].Value) + "' AND Check_Number='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Check_Number"].Value) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف چک پرداختنی از " + dgvStore.CurrentRow.Cells["Description"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                            frmShow_Check_Pardakht_Activated(null, null);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "چک پرداختنی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheck_Pardakht f = new frmCheck_Pardakht();
                f.op = "Edit";
                f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()));
                f.grpAccount.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "چک پرداختنی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDaryaft_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما فقط مجاز به پاس کردن اسناد پاس نشده می باشید";
                f.ShowDialog();
            }
            else
            {
                DateTime Check_Date = Convert.ToDateTime(dgvStore.CurrentRow.Cells["Date_Of_Arrivall"].Value.ToString());
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Bank WHERE ID ='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID_Bank"].Value.ToString()) + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string Ass_Code = dt.Rows[0].ItemArray[0].ToString();
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از وصول چک به شماره ی " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        Get_Max_Doc_Number();
                        string query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Ass_Code + "','" + Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value) + "',N'" + "وصول چک شماره " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30101" + "',19,'" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "')";
                        string query2 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Ass_Code + "','" + Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value) + "',N'" + "وصول چک شماره " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10101" + "',19,'" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "')";
                        string query4 = "UPDATE tbl_Check_Page SET State=0 WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID_Check"].Value) + "' AND Check_Number='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Check_Number"].Value) + "'";
                        string query3 = "UPDATE tbl_Check_Pardakht SET State=0 WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'";
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                        {
                            frmShow_Check_Pardakht_Activated(null, null);
                        }
                    }
                }
            }
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["State_Name"].Value.ToString() != "پاس نشده")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما فقط مجاز به پاس کردن اسناد پاس نشده می باشید";
                f.ShowDialog();
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Bank WHERE ID ='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID_Bank"].Value.ToString()) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string Ass_Code = dt.Rows[0].ItemArray[0].ToString();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Moeen_Code FROM tbl_Check_Pardakht WHERE ID ='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                string Moeen= dt2.Rows[0].ItemArray[0].ToString();
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از برگشت چک به شماره ی " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    Get_Max_Doc_Number();
                    string query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Ass_Code + "','" + Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value) + "',N'" + "برگشت چک شماره " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30101" + "',19,'" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "')";
                    string query2 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "','" + Convert.ToInt64(dgvStore.CurrentRow.Cells["Price"].Value) + "',N'" + "برگشت چک شماره " + dgvStore.CurrentRow.Cells["Check_Number"].Value.ToString() + " " + "به مبلغ " + dgvStore.CurrentRow.Cells["Price"].Value.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + Moeen + "',19,'" + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + "')";
                    string query4 = "UPDATE tbl_Check_Page SET State=2 WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID_Check"].Value) + "' AND Check_Number='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Check_Number"].Value) + "'";
                    string query3 = "UPDATE tbl_Check_Pardakht SET State=2 WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value) + "'";
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                    {
                        frmShow_Check_Pardakht_Activated(null, null);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Check_Pardakht.ID, tbl_Check_Pardakht.Check_Number,tbl_Check_Pardakht.ID_Check, tbl_Check_Pardakht.Date_Of_Arrivall, tbl_Check_Pardakht.Price, tbl_Check_Pardakht.ID_Bank, tbl_Check_Pardakht.Payer,tbl_Account.Description, tbl_Check_Pardakht.Acc_Code,  tbl_Check_Pardakht.Dar_Vajh, tbl_Check_Pardakht.Date, tbl_Check_Type.Type_Name, tbl_Check_State.State_Name FROM tbl_Check_Pardakht INNER JOIN tbl_Account ON tbl_Check_Pardakht.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_Type ON tbl_Check_Pardakht.Type = tbl_Check_Type.Check_Type INNER JOIN tbl_Check_State ON tbl_Check_Pardakht.State = tbl_Check_State.State WHERE tbl_Check_Pardakht.Payer LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Pardakht.Dar_Vajh LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_Type.Type_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Check_State.State_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Check_Pardakht.ID DESC";
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
                    f.op = "Pardakht";
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
