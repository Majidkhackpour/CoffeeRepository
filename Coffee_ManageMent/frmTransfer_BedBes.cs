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
using JntNum2Text;
using DateTime = System.DateTime;

namespace Coffee_ManageMent
{
    public partial class frmTransfer_BedBes : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        private int Type, Doc_Number;
        private Guid Guid_Edit;
        public void Form_Load()
        {
            string query2 = "SELECT MAX (ID) FROM tbl_Transaction";
            clsFunction.lbl_NewCode(dataconnection, query2, lblID, "1");
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            rbtnBed.Checked = true;
            txtCash.Text = "0";
            txtLetterCash.Text = "صفر ریال";
            txtBabat_Code.Text = txtBabat_Name.Text = txtMabda_Code.Text = "";
            txtMabda_Name.Text = txtMaqsad_Code.Text = txtMaqsad_Name.Text = "";
            txtBabat_Name.Text = txtBabat_Code.Text = "";
            txtMoeen_Code.Text = txtMoeen_Name.Text = "";
        }

        public void Fill_Data(Guid ggGuid)
        {
            Form_Load();
            timer2.Stop();
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT Mabda_Code, Maqsad_Code, Price, Babat_Code, Moein_Code, Type, Date, Time, Parent_Code FROM tbl_Transfer_BedBes WHERE Guid='" +
                    ggGuid + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Guid_Edit = ggGuid;
            txtMabda_Code.Text = dt.Rows[0].ItemArray[0].ToString();
            txtMaqsad_Code.Text = dt.Rows[0].ItemArray[1].ToString();
            if (dt.Rows[0].ItemArray[5].ToString() == "0")
                rbtnBed.Checked = true;
            else
                rbtnBes.Checked = true;
            Type = Convert.ToInt32(dt.Rows[0].ItemArray[5]);
            txtCash.Text = dt.Rows[0].ItemArray[2].ToString();
            txtBabat_Code.Text = dt.Rows[0].ItemArray[3].ToString();
            txtMoeen_Code.Text = dt.Rows[0].ItemArray[4].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[6].ToString();
            lblTime.Text = dt.Rows[0].ItemArray[7].ToString();
            lblID.Text = dt.Rows[0].ItemArray[8].ToString();
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
        private void Insertasion()
        {
            try
            {
                Get_Max_Doc_Number();
                string query1, query2;
                if (rbtnBed.Checked)
                {
                    query1 =
                       "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" +
                       txtMabda_Code.Text + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "انتقال بدهکاری به " +
                       txtMaqsad_Name.Text + "','" + txtDate.Text + "','" +
                       lblTime.Text + "','" + Doc_Number + "','" + txtMoeen_Code.Text + "',21,'" + lblID.Text + "')";
                    query2 =
                       "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" +
                       txtMaqsad_Code.Text + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "انتقال بدهکاری از " +
                       txtMabda_Name.Text + "','" + txtDate.Text + "','" + lblTime.Text + "','" + Doc_Number + "','" +
                       txtMoeen_Code.Text + "',21,'" + lblID.Text + "')";
                }
                else
                {
                    query1 =
                       "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" +
                       txtMaqsad_Code.Text + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "انتقال بستانکاری به " +
                       txtMabda_Name.Text + "','" + txtDate.Text + "','" +
                       lblTime.Text + "','" + Doc_Number + "','" + txtMoeen_Code.Text + "',21,'" + lblID.Text + "')";
                    query2 =
                       "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" +
                       txtMabda_Code.Text + "','" + Convert.ToInt64(txtCash.Text) + "',N'" + "انتقال بستانکاری از " +
                       txtMaqsad_Name.Text + "','" + txtDate.Text + "','" + lblTime.Text + "','" + Doc_Number + "','" +
                       txtMoeen_Code.Text + "',21,'" + lblID.Text + "')";
                }

                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                    this.Close();
            }
            catch
            {
            }
        }
        private void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Transaction WHERE Parent=21 AND Parent_Code='" + ID.ToString() + "'";
                if (clsFunction.Execute(dataconnection, query1) == true)
                {
                }
            }
            catch
            {
            }
        }
        public frmTransfer_BedBes()
        {
            InitializeComponent();
        }

        private void frmTransfer_BedBes_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            timer2_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToLongTimeString();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Mabda_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "All";
                f.Fill_All_Account();
                f.ShowDialog();
                txtMabda_Code.Text = f.Acc_Code;
            }
            catch
            {
            }
        }

        private void btnSearch_Maqsad_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "All";
                f.Fill_All_Account();
                f.ShowDialog();
                txtMaqsad_Code.Text = f.Acc_Code;
            }
            catch
            {
            }
        }

        private void txtMabda_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txtMabda_Code.Text + "'",
                        dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtMabda_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtMabda_Name.Text = "";
            }
        }

        private void txtMaqsad_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txtMaqsad_Code.Text + "'",
                        dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtMaqsad_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtMaqsad_Name.Text = "";
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Three_Ziro(txtCash);
                txtLetterCash.Text = Num2Text.ToFarsi(Convert.ToInt64(txtCash.Text)) + " " + "ریال";
            }
            catch
            {
                txtLetterCash.Text = "صفر ریال";
            }
        }

        private void txtBabat_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnBed.Checked)
                    Type = 0;
                else
                    Type = 1;
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "SELECT Name, Moeen FROM tbl_Pay_Recive_Identity WHERE Type='" + Type + "' AND Code='" +
                        txtBabat_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtBabat_Name.Text = dt.Rows[0].ItemArray[0].ToString();
                txtMoeen_Code.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                txtBabat_Name.Text = txtMoeen_Code.Text = "";
            }
        }

        private void btnSearch_Babat_Click(object sender, EventArgs e)
        {
            try
            {
                frmPay_Recive_Identity f = new frmPay_Recive_Identity();
                if (rbtnBed.Checked)
                {
                    f.Fill_Daryaft();
                    f.op = "Daryaft";
                }
                else
                {
                    f.Fill_Pardakht();
                    f.op = "Pardakht";
                }

                f.ShowDialog();
                txtBabat_Code.Text = f.Iden_Code;
                txtMoeen_Code.Text = f.Moeen_Code;
            }
            catch
            {
                txtBabat_Code.Text = txtMoeen_Code.Text = "";
            }
        }

        private void txtMoeen_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "SELECT Description FROM tbl_DefinitiveAccount WHERE AccCode='" + txtMoeen_Code.Text + "'",
                        dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtMoeen_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtMoeen_Name.Text = "";
            }
        }

        private void btnSearch_Moeen_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                f.ShowDialog();
                txtMoeen_Code.Text = f.Moeen_Code;
            }
            catch
            {
                txtMoeen_Code.Text = "";
            }
        }

        private void rbtnBed_CheckedChanged(object sender, EventArgs e)
        {
            txtBabat_Name.Text = txtBabat_Code.Text = "";
            txtMoeen_Code.Text = txtMoeen_Name.Text = "";
        }

        private void rbtnBes_CheckedChanged(object sender, EventArgs e)
        {
            txtBabat_Name.Text = txtBabat_Code.Text = "";
            txtMoeen_Code.Text = txtMoeen_Name.Text = "";
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (rbtnBed.Checked)
                Type = 0;
            else
                Type = 1;
            if (clsFunction.Error_Provider(txtMabda_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true ||
                clsFunction.Error_Provider(txtMaqsad_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true ||
                clsFunction.Error_Provider(txtBabat_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true ||
                clsFunction.Error_Provider(txtMoeen_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (txtCash.Text == "" || txtCash.Text == "0")
                {
                    errorProvider1.RightToLeft = true;
                    errorProvider1.SetError(txtLetterCash, "مبلغ وارد شده صحیح نمی باشد");
                }
                else
                {
                    timer2.Stop();
                    errorProvider1.Clear();
                    if (op == "Add")
                    {
                        string query3 =
                            "INSERT INTO tbl_Transfer_BedBes (Guid, Mabda_Code, Mabda_Name, Maqsad_Code, Maqsad_Name, Price, Babat_Code, Moein_Code, Type, Date, Time, Parent_Code) VALUES ('" +
                            Guid.NewGuid() + "','" + txtMabda_Code.Text + "',N'" + txtMabda_Name.Text + "','" +
                            txtMaqsad_Code.Text + "',N'" + txtMaqsad_Name.Text + "','" + Convert.ToInt64(txtCash.Text) +
                            "','" + txtBabat_Code.Text + "','" + txtMoeen_Code.Text + "','" + Type + "','" +
                            txtDate.Text + "','" + lblTime.Text + "','" + Convert.ToInt64(lblID.Text) + "')";
                        if (clsFunction.Execute(dataconnection, query3) == true)
                            Insertasion();
                    }
                    else if (op == "Edit")
                    {
                        Delete_Data(Convert.ToInt32(lblID.Text));
                        string query = "UPDATE tbl_Transfer_BedBes SET Mabda_Code = '" + txtMabda_Code.Text +
                                       "', Mabda_Name = N'" + txtMabda_Name.Text + "', Maqsad_Code = '" +
                                       txtMaqsad_Code.Text + "', Maqsad_Name = N'" + txtMaqsad_Name.Text +
                                       "', Price = '" + Convert.ToInt64(txtCash.Text) + "', Babat_Code = '" +
                                       txtBabat_Code.Text + "',  Moein_Code = '" + txtMoeen_Code.Text + "', Type = '" +
                                       Type + "', Date = '" + txtDate.Text + "', Time = '" + lblTime.Text +
                                       "', Parent_Code = '" + Convert.ToInt64(lblID.Text) + "' WHERE Guid='" +
                                       Guid_Edit + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            Insertasion();
                    }
                }
            }
        }

        private void txtMabda_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtMabda_Name.Text != "")
                    SendKeys.Send("{tab}");
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "All";
                    f.Fill_All_Account();
                    f.txtSearch.Text = txtMabda_Code.Text;
                    f.ShowDialog();
                    txtMabda_Code.Text = f.Acc_Code;
                }
            }
        }

        private void txtMaqsad_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtMaqsad_Name.Text != "")
                    SendKeys.Send("{tab}");
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "All";
                    f.Fill_All_Account();
                    f.txtSearch.Text = txtMaqsad_Code.Text;
                    f.ShowDialog();
                    txtMaqsad_Code.Text = f.Acc_Code;
                }
            }
        }

        private void txtBabat_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtBabat_Name.Text != "")
                    SendKeys.Send("{tab}");
                else
                {
                    frmPay_Recive_Identity f = new frmPay_Recive_Identity();
                    if (rbtnBed.Checked)
                    {
                        f.Fill_Daryaft();
                        f.op = "Daryaft";
                    }
                    else
                    {
                        f.Fill_Pardakht();
                        f.op = "Pardakht";
                    }
                    f.txtSearch.Text = txtBabat_Code.Text;
                    f.ShowDialog();
                    txtBabat_Code.Text = f.Iden_Code;
                    txtMoeen_Code.Text = f.Moeen_Code;
                }
            }
        }

        private void txtMoeen_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtMoeen_Name.Text != "")
                    SendKeys.Send("{tab}");
                else
                {
                    frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                    f.txtSearch.Text = txtMoeen_Code.Text;
                    f.ShowDialog();
                    txtMoeen_Code.Text = f.Moeen_Code;
                }
            }
        }

        private void btnSearch_Mabda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void btnSearch_Maqsad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void btnSearch_Babat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void btnSearch_Moeen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }
    }
}
