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
    public partial class frmPer_Leave : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        int Per_ID, le_Type;
        Guid G_Edit;
        public string op, s_Acc_Code;
        public void Form_Load()
        {
            txtCode.Text = txtName.Text = "";
            txtDate.Text = txtF_Date.Text = txtT_Date.Text = clsFunction.M2SH(DateTime.Now);
            txtF_Hour.Text = System.DateTime.Now.Hour.ToString();
            txtF_Min.Text = txtT_Min.Text = System.DateTime.Now.Minute.ToString();
            txtT_Hour.Text = (Convert.ToInt32(System.DateTime.Now.Hour) + 1).ToString();
            txtNotice.Text = "";
            Fill_Type();
        }
        private void Fill_Type()
        {
            try
            {
                cmbType.Items.Clear();
                string Query = "SELECT Type_Name FROM tbl_Leave_Per_Type";
                string s_obj = "Type_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbType, s_obj);
                cmbType.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        public void Fill_Data(Guid gg)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Perssonel.Code, tbl_Leave_Perssonel.Date, tbl_Leave_Perssonel.F_Hour, tbl_Leave_Perssonel.F_Min, tbl_Leave_Perssonel.F_Date, tbl_Leave_Perssonel.T_Hour, tbl_Leave_Perssonel.T_Min,  tbl_Leave_Perssonel.T_Date, tbl_Leave_Perssonel.Type, tbl_Leave_Perssonel.Description, tbl_Leave_Perssonel.Per_ID FROM tbl_Leave_Perssonel INNER JOIN tbl_Perssonel ON tbl_Leave_Perssonel.Per_ID = tbl_Perssonel.ID WHERE tbl_Leave_Perssonel.Guid='" + gg + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            G_Edit = gg;
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[1].ToString();
            txtF_Hour.Text = dt.Rows[0].ItemArray[2].ToString();
            txtF_Min.Text = dt.Rows[0].ItemArray[3].ToString();
            txtF_Date.Text = dt.Rows[0].ItemArray[4].ToString();
            txtT_Hour.Text = dt.Rows[0].ItemArray[5].ToString();
            txtT_Min.Text = dt.Rows[0].ItemArray[6].ToString();
            txtT_Date.Text = dt.Rows[0].ItemArray[7].ToString();
            cmbType.SelectedIndex = Convert.ToInt32(dt.Rows[0].ItemArray[8]);
            txtNotice.Text = dt.Rows[0].ItemArray[9].ToString();
            Per_ID = Convert.ToInt32(dt.Rows[0].ItemArray[10]);
        }
        private void CRUD()
        {
            if (op == "Add")
            {
                if (Check_Account_On_Perssonel() == false)
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "متقاضی مرخصی در لیست پرسنل وجود ندارد";
                    f.ShowDialog();
                }
                else
                {
                    string query = "INSERT INTO tbl_Leave_Perssonel (Guid, Per_ID, Date, F_Hour, F_Min, F_Date, T_Hour, T_Min, T_Date, Type, Description) VALUES ('" + Guid.NewGuid() + "','" + Per_ID + "','" + txtDate.Text + "','" + txtF_Hour.Text + "','" + txtF_Min.Text + "','" + txtF_Date.Text + "','" + txtT_Hour.Text + "','" + txtT_Min.Text + "','" + txtT_Date.Text + "','" + le_Type + "',N'" + txtNotice.Text + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
            }
            else if (op == "Edit")
            {
                string query = "UPDATE tbl_Leave_Perssonel SET Per_ID = '" + Per_ID + "', Date = '" + txtDate.Text + "', F_Hour = '" + txtF_Hour.Text + "', F_Min = '" + txtF_Min.Text + "', F_Date = '" + txtF_Date.Text + "', T_Hour = '" + txtT_Hour.Text + "', T_Min = '" + txtT_Min.Text + "', T_Date = '" + txtT_Date.Text + "', Type = '" + le_Type + "', Description = N'" + txtNotice.Text + "' WHERE Guid = '" + G_Edit + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
                    this.Close();
            }
        }
        private bool Check_Account_On_Perssonel()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Perssonel WHERE Code='" + txtCode.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Code = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Acc_Code == txtCode.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmPer_Leave()
        {
            InitializeComponent();
        }

        private void frmPer_Leave_Load(object sender, EventArgs e)
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

        private void btnSearch_Acc_Click(object sender, EventArgs e)
        {
            frmAllPerssonel f = new frmAllPerssonel();
            f.Fill_All_Perssonel();
            f.op = "All";
            f.ShowDialog();
            Per_ID = Convert.ToInt32(f.Acc_Code);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Perssonel WHERE ID='" + Per_ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtF_Hour, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtF_Min, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtT_Hour, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtT_Min, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (txtF_Date.Text == "    /  /" || txtT_Date.Text == "    /  /")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "تاریخ وارد شده صحیح نمی باشد";
                    f.ShowDialog();
                }
                else
                {
                    DateTime d1 = Convert.ToDateTime(txtF_Date.Text);
                    DateTime d2 = Convert.ToDateTime(txtT_Date.Text);
                    if (d2 < d1)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "تاریخ آغاز نمی تواند از تاریخ پایان مرخصی بزرگتر باشد";
                        f.ShowDialog();
                    }
                    else
                    {
                        if (txtT_Date.Text == txtF_Date.Text)
                        {
                            if (txtF_Hour.Text == txtT_Hour.Text)
                            {
                                if (Convert.ToInt32(txtT_Min.Text) < Convert.ToInt32(txtF_Min.Text))
                                {
                                    frmMessage f = new frmMessage();
                                    f.flag = 0;
                                    f.lblMessage.Text = "زمان آغاز نمی تواند از زمان پایان مرخصی بزرگتر باشد";
                                    f.ShowDialog();
                                }
                            }
                            if (Convert.ToInt32(txtT_Hour.Text) < Convert.ToInt32(txtF_Hour.Text))
                            {
                                frmMessage f = new frmMessage();
                                f.flag = 0;
                                f.lblMessage.Text = "زمان آغاز نمی تواند از زمان پایان مرخصی بزرگتر باشد";
                                f.ShowDialog();
                            }
                            else
                            {
                                CRUD();
                            }
                        }
                        else
                        {
                            CRUD();
                        }
                    }
                }
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type FROM tbl_Leave_Per_Type WHERE Type_Name LIKE N'" + cmbType.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    le_Type = (int)dr["Type"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void txtF_Hour_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtF_Hour.Text) >= 24)
                txtF_Hour.Text = "00";
        }

        private void txtT_Hour_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtT_Hour.Text) >= 24)
                txtT_Hour.Text = "00";
        }

        private void txtF_Min_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtF_Min.Text) >= 60)
                txtF_Min.Text = "00";
        }

        private void txtT_Min_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtT_Min.Text) >= 60)
                txtT_Min.Text = "00";
        }

        private void txtF_Min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtF_Hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtT_Min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtT_Hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void btnSearch_Acc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtF_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtF_Hour_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtF_Min_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtT_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtT_Min_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtT_Hour_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtName.Text != "")
                {
                    SendKeys.Send("{tab}");
                }
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.op = "All";
                    f.Fill_All_Account();
                    f.txtSearch.Text = txtCode.Text;
                    f.ShowDialog();
                    txtCode.Text = f.Acc_Code;
                }
            }
        }
    }
}
