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
    public partial class frmLottery : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        int Doc_Number;
        public void Form_Load()
        {
            string query2 = "SELECT MAX (Number) FROM tbl_Header_Lottery";
            clsFunction.lbl_NewCode(dataconnection, query2, lblID, "1");
            txtNotice.Text = "";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            txtWinner.Text = "1";
            txtAward.Text = "0";
            lbxWinners.Items.Clear();
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Lottery WHERE Number = '" + ID + "'";
                string query2 = "DELETE FROM tbl_Transaction WHERE Parent=20 AND Parent_Code = '" + ID + "'";
                if (clsFunction.Execute(dataconnection, query1) == true)
                {
                }
                if (clsFunction.Execute(dataconnection, query2) == true)
                {
                }
            }
            catch
            {
            }
        }
        private void Get_Max_Doc_Number()
        {
            try
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Number FROM tbl_Transaction WHERE Date='" + txtDate.Text + "'", dataconnection);
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
        public void Fill_Data(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Winner_Count, Notice, Award FROM tbl_Header_Lottery WHERE Number='" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblID.Text = ID.ToString();
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            txtWinner.Text = dt.Rows[0].ItemArray[1].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[2].ToString();
            txtAward.Text = dt.Rows[0].ItemArray[3].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Code FROM tbl_Body_Lottery WHERE Number='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                try
                {
                    lbxWinners.Items.Add(dt2.Rows[i].ItemArray[0].ToString());
                }
                catch
                {
                }
            }
        }
        public frmLottery()
        {
            InitializeComponent();
        }

        private void frmFestival_Load(object sender, EventArgs e)
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
            if (clsFunction.Error_Provider(txtWinner, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            if (txtWinner.Text == "0" || txtAward.Text == "0")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "در وارد کردن اطلاعات دقت فرمایید";
                f.ShowDialog();
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    string query1 = "INSERT INTO tbl_Header_Lottery (Number, Date, Winner_Count, Notice, Award) VALUES ('" + Convert.ToInt32(lblID.Text) + "','" + txtDate.Text + "','" + Convert.ToInt32(txtWinner.Text) + "',N'" + txtNotice.Text + "','" + txtAward.Text + "')";
                    if (clsFunction.Execute(dataconnection, query1) == true)
                    {
                        for (int i = 0; i < lbxWinners.Items.Count; i++)
                        {
                            try
                            {
                                string query2 = "INSERT INTO tbl_Body_Lottery (Number, Code) VALUES ('" + Convert.ToInt32(lblID.Text) + "','" + lbxWinners.Items[i].ToString() + "')";
                                if (clsFunction.Execute(dataconnection, query2) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                        frmMessage f = new frmMessage();
                        f.lblMessage.Text = "برندگان قرعه کشی با موفقیت ثبت شدند. آیا مایلید سند حسابداری هم ثبت شود؟";
                        f.flag = 1;
                        f.ShowDialog();
                        if (f.Resault == 0)
                        {
                            Get_Max_Doc_Number();
                            int Price = Convert.ToInt32(txtWinner.Text) * Convert.ToInt32(txtAward.Text);
                            string query3 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(Price) + "',N'" + "قرعه کشی مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60202" + "','" + 20 + "','" + lblID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query3) == true)
                            {
                                for (int i = 0; i < lbxWinners.Items.Count; i++)
                                {
                                    try
                                    {
                                        string query4 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lbxWinners.Items[i].ToString() + "','" + 0 + "','" + Convert.ToInt64(txtAward.Text) + "',N'" + "قرعه کشی مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "','" + 20 + "','" + lblID.Text + "')";
                                        if (clsFunction.Execute(dataconnection, query4) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                    this.Close();
                }
                else if (op == "Edit")
                {
                    string query1 = "UPDATE tbl_Header_Lottery SET Date='" + txtDate.Text + "', Winner_Count='" + Convert.ToInt32(txtWinner.Text) + "', Notice=N'" + txtNotice.Text + "', Award='" + txtAward.Text + "' WHERE Number='" + Convert.ToInt32(lblID.Text) + "'";
                    if (clsFunction.Execute(dataconnection, query1) == true)
                    {
                        Delete_Data(Convert.ToInt32(lblID.Text));
                        for (int i = 0; i < lbxWinners.Items.Count; i++)
                        {
                            try
                            {
                                string query2 = "INSERT INTO tbl_Body_Lottery (Number, Code) VALUES ('" + Convert.ToInt32(lblID.Text) + "','" + lbxWinners.Items[i].ToString() + "')";
                                if (clsFunction.Execute(dataconnection, query2) == true)
                                {
                                }
                            }
                            catch
                            {
                            }
                        }
                        frmMessage f = new frmMessage();
                        f.lblMessage.Text = "برندگان قرعه کشی با موفقیت ثبت شدند. آیا مایلید سند حسابداری هم ثبت شود؟";
                        f.flag = 1;
                        f.ShowDialog();
                        if (f.Resault == 0)
                        {
                            Get_Max_Doc_Number();
                            int Price = Convert.ToInt32(txtWinner.Text) * Convert.ToInt32(txtAward.Text);
                            string query3 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(Price) + "',N'" + "قرعه کشی مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "60202" + "','" + 20 + "','" + lblID.Text + "')";
                            if (clsFunction.Execute(dataconnection, query3) == true)
                            {
                                for (int i = 0; i < lbxWinners.Items.Count; i++)
                                {
                                    try
                                    {
                                        string query4 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + lbxWinners.Items[i].ToString() + "','" + 0 + "','" + Convert.ToInt64(txtAward.Text) + "',N'" + "قرعه کشی مورخ " + txtDate.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10301" + "','" + 20 + "','" + lblID.Text + "')";
                                        if (clsFunction.Execute(dataconnection, query4) == true)
                                        {
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                    this.Close();
                }
            }
        }

        private void btnDo_IT_Click(object sender, EventArgs e)
        {
            lbxWinners.Items.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT MIN (Code) FROM tbl_Account WHERE Parent=30 AND Code>300001", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int Min_Val = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT MAX (Code) FROM tbl_Account WHERE Parent=30 AND Code>300001", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int Max_Val = Convert.ToInt32(dt2.Rows[0].ItemArray[0]);
            while (lbxWinners.Items.Count < Convert.ToInt32(txtWinner.Text))
            {
                Random r = new Random();
                int Random_Number = r.Next(Min_Val, Max_Val);
                if (lbxWinners.Items.Count == 0)
                    lbxWinners.Items.Add(Random_Number);
                else
                {
                    for (int i = 0; i < lbxWinners.Items.Count; i++)
                    {
                        if (Random_Number == Convert.ToInt32(lbxWinners.Items[i]))
                            i = lbxWinners.Items.Count;
                        else
                        {
                            if (i == lbxWinners.Items.Count - 1)
                                lbxWinners.Items.Add(Random_Number);
                        }
                    }
                }
            }
        }

        private void txtAward_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtAward);
        }

        private void txtAward_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtWinner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtAward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void btnDo_IT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void lbxWinners_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtWinner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void btnShow_Winners_Click(object sender, EventArgs e)
        {
            try
            {
                frmLottery_Winners f = new frmLottery_Winners();
                f.Display_Winners(Convert.ToInt32(lblID.Text));
                f.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
