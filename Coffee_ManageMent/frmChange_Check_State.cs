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
    public partial class frmChange_Check_State : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        string query1, query2, query3, Moeen;
        int Doc_Number, ch_State, ID_CHeck;
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
        private void form_Load()
        {
            lblBankCode.Text = lblBankName.Text = lblCheck_Type.Text = "";
            lblCode.Text = lblDateArrivall.Text = lblMablaq.Text = "";
            lblReciver.Text = lblReciverCode.Text = lblSerial.Text = lblStateNow.Text = "";
            cmbNewState.Items.Clear();
            string Query = "SELECT State_Name FROM tbl_Check_State";
            string s_obj = "State_Name";
            clsFunction.FillComboBox(dataconnection, Query, cmbNewState, s_obj);
            cmbNewState.SelectedIndex = 0;
        }
        public void Fill_Data(int ID)
        {
            form_Load();
            string query="";
            if (op == "Daryaft")
            {
                query = "SELECT tbl_Check_Daryaft.Acc_Code, tbl_Account.Description, tbl_Check_Daryaft.Safe_Reciver, tbl_Check_Daryaft.Sett_Date, tbl_Check_Daryaft.Check_Number, tbl_Check_Daryaft.Price,  tbl_Check_State.State_Name, tbl_Check_Daryaft.Moeen_Code FROM tbl_Check_Daryaft INNER JOIN tbl_Account ON tbl_Check_Daryaft.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_State ON tbl_Check_Daryaft.State = tbl_Check_State.State WHERE tbl_Check_Daryaft.ID='" + ID + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblCode.Text = ID.ToString();
                lblCheck_Type.Text = "دریافتنی";
                lblReciverCode.Text=dt.Rows[0].ItemArray[0].ToString();
                lblReciver.Text=dt.Rows[0].ItemArray[1].ToString();
                lblBankName.Text=dt.Rows[0].ItemArray[2].ToString();
                lblDateArrivall.Text=dt.Rows[0].ItemArray[3].ToString();
                lblSerial.Text=dt.Rows[0].ItemArray[4].ToString();
                lblMablaq.Text=dt.Rows[0].ItemArray[5].ToString();
                lblStateNow.Text=dt.Rows[0].ItemArray[6].ToString();
                Moeen = dt.Rows[0].ItemArray[7].ToString();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + dt.Rows[0].ItemArray[2].ToString() + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                lblBankCode.Text = dt2.Rows[0].ItemArray[0].ToString();
            }
            else if (op == "Pardakht")
            {
                query = "SELECT tbl_Check_Pardakht.Acc_Code, tbl_Account.Description, tbl_Check_Pardakht.Payer, tbl_Check_Pardakht.Date_Of_Arrivall, tbl_Check_Pardakht.Check_Number,  tbl_Check_Pardakht.Price, tbl_Check_State.State_Name, tbl_Check_Pardakht.ID_Bank, tbl_Check_Pardakht.Moeen_Code, tbl_Check_Pardakht.ID_Check  FROM tbl_Check_Pardakht INNER JOIN tbl_Account ON tbl_Check_Pardakht.Acc_Code = tbl_Account.Code INNER JOIN tbl_Check_State ON tbl_Check_Pardakht.State = tbl_Check_State.State WHERE tbl_Check_Pardakht.ID='" + ID + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblCode.Text = ID.ToString();
                lblCheck_Type.Text = "پرداختنی";
                lblReciverCode.Text = dt.Rows[0].ItemArray[0].ToString();
                lblReciver.Text = dt.Rows[0].ItemArray[1].ToString();
                lblBankName.Text = dt.Rows[0].ItemArray[2].ToString();
                lblDateArrivall.Text = dt.Rows[0].ItemArray[3].ToString();
                lblSerial.Text = dt.Rows[0].ItemArray[4].ToString();
                lblMablaq.Text = dt.Rows[0].ItemArray[5].ToString();
                lblStateNow.Text = dt.Rows[0].ItemArray[6].ToString();
                Moeen = dt.Rows[0].ItemArray[8].ToString();
                ID_CHeck = Convert.ToInt32(dt.Rows[0].ItemArray[9]);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Code FROM tbl_Bank WHERE ID='" + Convert.ToInt32(dt.Rows[0].ItemArray[7]) + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                lblBankCode.Text = dt2.Rows[0].ItemArray[0].ToString();
            }
            if (lblStateNow.Text == "پاس شده")
                lblStateNow.ForeColor = Color.Green;
            else if (lblStateNow.Text == "برگشتی")
                lblStateNow.ForeColor = Color.Red;
            else
                lblStateNow.ForeColor = Color.Black;
        }
        public frmChange_Check_State()
        {
            InitializeComponent();
        }

        private void frmChange_Check_State_Load(object sender, EventArgs e)
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (lblStateNow.Text != "پاس شده" && lblStateNow.Text != "برگشتی")
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "فقط چک های پاس شده و برگشتی قابل تغییر وضعیت هستند";
                f.flag = 0;
                f.ShowDialog();
            }
            else
            {
                if (cmbNewState.Text != "پاس شده" && cmbNewState.Text != "برگشتی")
                {
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "با انتخاب " + cmbNewState.Text + " " + "به عنوان وضعیت جدید، وضعیت بدهکاری و بستانکاری فرد نامتوازن می شود.";
                    f.flag = 0;
                    f.ShowDialog();
                }
                Get_Max_Doc_Number();
                if (op == "Daryaft")
                {
                    if (cmbNewState.Text == "پاس شده")
                    {
                        ch_State = 0;
                        query1 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblBankCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "وصول چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10201" + "',18,'" + lblCode.Text + "')";
                        query2 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblBankCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "وصول چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10101" + "',18,'" + lblCode.Text + "')";
                    }
                    else if (cmbNewState.Text == "برگشتی")
                    {
                        ch_State = 2;
                        query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblReciverCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "برگشت چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + Moeen + "',18,'" + lblCode.Text + "')";
                        query2 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblBankCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "برگشت چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10101" + "',18,'" + lblCode.Text + "')";
                    }
                    query3 = "UPDATE tbl_Check_Daryaft SET State='" + ch_State + "' WHERE ID='" + Convert.ToInt64(lblCode.Text) + "'";
                }
                else if (op == "Pardakht")
                {
                    if (cmbNewState.Text == "پاس شده")
                    {
                        ch_State = 0;
                        query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblBankCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "وصول چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30101" + "',19,'" + lblCode.Text + "')";
                        query2 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblBankCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "وصول چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10101" + "',19,'" + lblCode.Text + "')";
                    }
                    else if (cmbNewState.Text == "برگشتی")
                    {
                        ch_State = 2;
                        query1 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblBankCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "برگشت چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30101" + "',19,'" + lblCode.Text + "')";
                        query2 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lblReciverCode.Text + "','" + Convert.ToInt64(lblMablaq.Text) + "',N'" + "برگشت چک شماره " + lblSerial.Text + " " + "به مبلغ " + lblMablaq.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + Moeen + "',19,'" + lblCode.Text + "')";
                        string query4 = "UPDATE tbl_Check_Page SET State='" + ch_State + "' WHERE ID='" + ID_CHeck + "' AND Check_Number='" + Convert.ToInt32(lblSerial.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query4) == true)
                        {
                        }
                    }
                    query3 = "UPDATE tbl_Check_Pardakht SET State='" + ch_State + "' WHERE ID='" + Convert.ToInt64(lblCode.Text) + "'";
                }
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                    this.Close();
            }
        }
    }
}
