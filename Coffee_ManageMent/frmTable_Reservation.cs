using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent
{
    public partial class frmTable_Reservation : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public int State, op, Chair, int_ID;
        public string s_op;
        public void SplashCircleStart()
        {
            Application.Run(new frmTable_Reservation());
        }
        private void FillcmbTable()
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Table_Name FROM tbl_Tables", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmbTable.Items.Add(dr["Table_Name"]);
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }
        public void Form_Load()
        {
            cmbTable.Items.Clear();
            FillcmbTable();
            lblState.Text = lblTableCode.Text = "";
            rbtnDischarge.Checked = true;
            rbtnReserve.Checked = false;
            rbtnReserve.Enabled = true;
            rbtnDischarge.Enabled = true;
            cmbTable.SelectedIndex = 0;
            txtCode.Enabled = false;
            btnSearch_Acc.Enabled = false;
            txtDate.Enabled = false;
            txtTime.Enabled = false;
            txtTime.Text = txtDate.Text = txtCode.Text = txtName.Text = txtGuest_Number.Text = "";
            txtGuest_Number.Enabled = false;
        }
        public void Fill_Data(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Table_Code, Code, Date, Time, Guest_Number FROM tbl_Table_Reserve WHERE ID='" + ID + "'", dataconnection);
            DataTable dt=new DataTable();
            da.Fill(dt);
            lblTableCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtCode.Text = dt.Rows[0].ItemArray[1].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[2].ToString();
            txtTime.Text = dt.Rows[0].ItemArray[3].ToString();
            txtGuest_Number.Text = dt.Rows[0].ItemArray[4].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Table_Name FROM tbl_Tables WHERE Table_Code='" + Convert.ToInt32(lblTableCode.Text) + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cmbTable.Text = dt2.Rows[0].ItemArray[0].ToString();
            rbtnDischarge.Enabled = false;
            rbtnReserve.Enabled = false;
            op = 1;
            txtCode.Enabled = true;
            btnSearch_Acc.Enabled = true;
            txtDate.Enabled = true;
            txtTime.Enabled = true;
            txtGuest_Number.Enabled = true;
            txtGuest_Number.Text = Chair.ToString();
            btnShow_Reservation.Enabled = false;
        }
        public frmTable_Reservation()
        {
            InitializeComponent();
        }

        private void frmTable_Reservation_Load(object sender, EventArgs e)
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

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Table_State, Table_Code, Table_Chair FROM tbl_Tables WHERE Table_Name LIKE N'" + cmbTable.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblTableCode.Text = ((int)(dr["Table_Code"])).ToString();
                    State = (int)(dr["Table_State"]);
                    Chair = (int)(dr["Table_Chair"]);
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
            lblState.Text = State.ToString();
            if (State == 0)
            {
                lblState.Text = "تخلیه";
                lblState.ForeColor = Color.Red;
            }
            else if (State == 2)
            {
                lblState.Text = "درحال پذیرایی";
                lblState.ForeColor = Color.CadetBlue;
            }
            else if (State == 1)
            {
                lblState.Text = "رزرو";
                lblState.ForeColor = Color.ForestGreen;
            }
        }

        private void rbtnReserve_CheckedChanged(object sender, EventArgs e)
        {
            op = 1;
            txtCode.Enabled = true;
            btnSearch_Acc.Enabled = true;
            txtDate.Enabled = true;
            txtTime.Enabled = true;
            txtGuest_Number.Enabled = true;
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string Hour = System.DateTime.Now.Hour.ToString();
            if (Convert.ToInt32(Hour.Length) < 2)
                Hour = "0" + Hour;
            string Min = System.DateTime.Now.Minute.ToString();
            txtTime.Text = Hour + Min;
            txtGuest_Number.Text = Chair.ToString();
        }

        private void rbtnDischarge_CheckedChanged(object sender, EventArgs e)
        {
            op = 0;
            txtCode.Enabled = false;
            btnSearch_Acc.Enabled = false;
            txtDate.Enabled = false;
            txtTime.Enabled = false;
            txtGuest_Number.Enabled = false;
            txtDate.Text = "";
            txtTime.Text = "";
            txtGuest_Number.Text = "";
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (op == 3)
            {
                errorProvider1.Clear();
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(rbtnReserve, "لطفا نوع عملیات را انتخاب نمایید");
            }
            else
            {
                errorProvider1.Clear();
                if (op == 0 && lblState.Text == "تخلیه")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "وضعیت میز از پیش تخلیه می باشد";
                    f.ShowDialog();
                }
                else if (op == 1 && lblState.Text == "رزرو")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "این میز از پیش رزرو شده است";
                    f.ShowDialog();
                }
                else
                {
                    frmMessage f = new frmMessage();
                    if (op == 0)
                    {
                        f.lblMessage.Text = "آیا از تخلیه " + cmbTable.Text + " " + "اطمینان دارید؟";
                    }
                    else if (op == 1)
                    {
                        f.lblMessage.Text = "آیا از رزرواسیون " + cmbTable.Text + " " + "اطمینان دارید؟";
                    }
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        string query = "UPDATE tbl_Tables SET Table_State='" + op + "' WHERE Table_Code='" + Convert.ToInt32(lblTableCode.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            if (s_op == "Add")
                            {
                                if (op == 1)
                                {
                                    if (Chair < Convert.ToInt32(txtGuest_Number.Text))
                                    {
                                        frmMessage f1 = new frmMessage();
                                        f1.lblMessage.Text = "ظرفیت این میز از تعداد میهمانان کمتر است. آیا ادامه می دهید؟";
                                        f1.flag = 1;
                                        f1.ShowDialog();
                                        if (f1.Resault == 0)
                                        {
                                            string query1 = "INSERT INTO tbl_Table_Reserve (Table_Code, Code, Date, Time, Guest_Number) VALUES ('" + Convert.ToInt32(lblTableCode.Text) + "','" + txtCode.Text + "','" + txtDate.Text + "','" + txtTime.Text + "','" + Convert.ToInt32(txtGuest_Number.Text) + "')";
                                            if (clsFunction.Execute(dataconnection, query1) == true)
                                            {
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string query1 = "INSERT INTO tbl_Table_Reserve (Table_Code, Code, Date, Time, Guest_Number) VALUES ('" + Convert.ToInt32(lblTableCode.Text) + "','" + txtCode.Text + "','" + txtDate.Text + "','" + txtTime.Text + "','" + Convert.ToInt32(txtGuest_Number.Text) + "')";
                                        if (clsFunction.Execute(dataconnection, query1) == true)
                                        {
                                        }
                                    }
                                }
                            }
                            else if (s_op == "Edit")
                            {
                                if (Chair < Convert.ToInt32(txtGuest_Number.Text))
                                {
                                    frmMessage f1 = new frmMessage();
                                    f1.lblMessage.Text = "ظرفیت این میز از تعداد میهمانان کمتر است. آیا ادامه می دهید؟";
                                    f1.flag = 1;
                                    f1.ShowDialog();
                                    if (f1.Resault == 0)
                                    {
                                        string query1 = "UPDATE tbl_Table_Reserve SET Table_Code = '" + Convert.ToInt32(lblTableCode.Text) + "', Code = '" + txtCode.Text + "', Date = '" + txtDate.Text + "', Time = '" + txtTime.Text + "', Guest_Number = '" + Convert.ToInt32(txtGuest_Number.Text) + "' WHERE ID='" + Convert.ToInt64(int_ID) + "'";
                                        if (clsFunction.Execute(dataconnection, query1) == true)
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    string query1 = "UPDATE tbl_Table_Reserve SET Table_Code = '" + Convert.ToInt32(lblTableCode.Text) + "', Code = '" + txtCode.Text + "', Date = '" + txtDate.Text + "', Time = '" + txtTime.Text + "', Guest_Number = '" + Convert.ToInt32(txtGuest_Number.Text) + "' WHERE ID='" + Convert.ToInt64(int_ID) + "'";
                                    if (clsFunction.Execute(dataconnection, query1) == true)
                                    {
                                    }
                                }
                            }
                            new frmCircle_Progress().ShowDialog();
                            Thread t = new Thread(new ThreadStart(SplashCircleStart));
                            t.Start();
                            t.Abort();
                            Form_Load();
                        }
                    }
                }
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName.Text = "";
            }
        }

        private void btnSearch_Acc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.op = "Rael_And_Right_Acc";
                f.Fill_Real_And_Right_Account();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtName.Text != "")
                {
                    txtDate.Focus();
                }
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "Rael_And_Right_Acc";
                    f.Fill_Real_And_Right_Account();
                    f.txtSearch.Text = txtCode.Text;
                    f.ShowDialog();
                    txtCode.Text = f.Acc_Code;
                }
            }
        }

        private void cmbTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                rbtnReserve.Focus();
        }

        private void rbtnReserve_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                rbtnDischarge.Focus();
        }

        private void rbtnDischarge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode.Focus();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTime.Focus();
        }

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtGuest_Number.Focus();
        }

        private void txtGuest_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtGuest_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void btnShow_Reservation_Click(object sender, EventArgs e)
        {
            new frmShow_Tables_Reservation().ShowDialog();
        }
    }
}
