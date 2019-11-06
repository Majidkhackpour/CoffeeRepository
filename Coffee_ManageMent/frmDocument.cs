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
    public partial class frmDocument : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        string op;
        int ID_Edit, btn_flag;
        private void Fill_Doc()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Moeen, Code, Notice, Bedehkar, Bestankar FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "' ORDER BY Bestankar", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProduct.DataSource = dt;
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Date FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "'", dataconnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                txtDate.Text = dt2.Rows[0].ItemArray[0].ToString();
                Calculating();
            }
            catch
            {
            }
        }
        private void Calculating()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Bedehkar) FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblSumBed.Text = dt.Rows[0].ItemArray[0].ToString();
                if (lblSumBed.Text == "")
                    lblSumBed.Text = "0";
            }
            catch
            {
                lblSumBed.Text = "0";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(Bestankar) FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblSumBes.Text = dt.Rows[0].ItemArray[0].ToString();
                if (lblSumBes.Text == "")
                    lblSumBes.Text = "0";
            }
            catch
            {
                lblSumBes.Text = "0";
            }
            try
            {
                lblRemain.Text = "0";
                lblGues.Text = "";
                lblRemain.Text = (Convert.ToInt64(lblSumBed.Text) - Convert.ToInt64(lblSumBes.Text)).ToString();
                if (Convert.ToInt32(lblRemain.Text) > 0)
                {
                    lblGues.Text = "بدهکار";
                    lblGues.ForeColor = Color.Red;
                }
                else if (Convert.ToInt32(lblRemain.Text) == 0)
                {
                    lblGues.Text = "موازنه";
                    lblGues.ForeColor = Color.Black;
                }
                else if (Convert.ToInt32(lblRemain.Text) < 0)
                {
                    int SUM = Convert.ToInt32(lblRemain.Text);
                    lblGues.Text = "بستانکار";
                    lblGues.ForeColor = Color.ForestGreen;
                    lblRemain.Text = (Math.Abs(SUM)).ToString();
                }
                lblRemain.Text = Convert.ToInt32(lblRemain.Text).ToString("n0");
                lblSumBed.Text = Convert.ToInt32(lblSumBed.Text).ToString("n0");
                lblSumBes.Text = Convert.ToInt32(lblSumBes.Text).ToString("n0");
            }
            catch
            {
            }
        }
        public frmDocument()
        {
            InitializeComponent();
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            btn_flag = 1;
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            lblMoeen.Text = lblTafsili.Text = "";
            txtAcc_Code.Text = txtAcc_Name.Text = txtCode.Text = "";
            txtDate.Text = txtDescription.Text = txtMoeen_Code.Text = txtMoeen_Name.Text = "";
            txtBedehkar.Text = txtBestankar.Text = "0";
            lblSumBed.Text = lblSumBes.Text = lblRemain.Text = "0";
            lblGues.Text = "";
            txtDescription.Enabled = false;
            txtMoeen_Code.Enabled = false;
            btnSearch_Moeen.Enabled = false;
            txtAcc_Code.Enabled = false;
            btnSearch_Acc.Enabled = false;
            txtDate.Enabled = false;
            txtBedehkar.Enabled = false;
            txtBestankar.Enabled = false;
            btnInsert_P_Factor.Enabled = false;
            SqlDataAdapter da = new SqlDataAdapter("SELECT MAX(Doc_Number) FROM tbl_Transaction", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            Fill_Doc();
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

        private void dgvProduct_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_DefinitiveAccount WHERE AccCode='" + dgvProduct.CurrentRow.Cells["Moeen"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblMoeen.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                lblMoeen.Text = "";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code='" + dgvProduct.CurrentRow.Cells["Code"].Value.ToString() + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblTafsili.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                lblTafsili.Text = "";
            }
            try
            {
                if (op == "Edit")
                {
                    txtMoeen_Code.Text = dgvProduct.CurrentRow.Cells["Moeen"].Value.ToString();
                    txtAcc_Code.Text = dgvProduct.CurrentRow.Cells["Code"].Value.ToString();
                    txtDescription.Text = dgvProduct.CurrentRow.Cells["Notice"].Value.ToString();
                    txtBedehkar.Text = dgvProduct.CurrentRow.Cells["Bedehkar"].Value.ToString();
                    txtBestankar.Text = dgvProduct.CurrentRow.Cells["Bestankar"].Value.ToString();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Code='" + txtAcc_Code.Text + "' AND Bedehkar='" + Convert.ToInt64(txtBedehkar.Text) + "' AND Bestankar='" + Convert.ToInt64(txtBestankar.Text) + "' AND Notice=N'" + txtDescription.Text + "' AND Moeen='" + txtMoeen_Code.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ID_Edit = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
            }
            catch
            {
                txtMoeen_Code.Text = txtAcc_Code.Text = txtDescription.Text = "";
                txtBestankar.Text = txtBedehkar.Text = "0";
            }
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                op = "Add";
                txtDescription.Enabled = true;
                txtMoeen_Code.Enabled = true;
                btnSearch_Moeen.Enabled = true;
                txtAcc_Code.Enabled = true;
                btnSearch_Acc.Enabled = true;
                txtDate.Enabled = true;
                txtBedehkar.Enabled = true;
                txtBestankar.Enabled = true;
                btnInsert_P_Factor.Enabled = true;
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX(Doc_Number) FROM tbl_Transaction", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtCode.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();
                txtDate.Text = clsFunction.M2SH(DateTime.Now);
                txtMoeen_Code.Focus();
            }
            catch
            {
            }
        }

        private void txtCode_ValueChanged(object sender, EventArgs e)
        {
            Fill_Doc();
            lblMoeen.Text = lblTafsili.Text = "";
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

        private void txtMoeen_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_DefinitiveAccount WHERE AccCode='" + txtMoeen_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtMoeen_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtMoeen_Name.Text = "";
            }
        }

        private void btnSearch_Acc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllAccount f = new frmAllAccount();
                f.Fill_All_Account();
                f.op = "All";
                f.ShowDialog();
                txtAcc_Code.Text = f.Acc_Code;
            }
            catch
            {
                txtAcc_Code.Text = "";
            }
        }

        private void txtAcc_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Account WHERE Code='" + txtAcc_Code.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtAcc_Name.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtAcc_Name.Text = "";
            }
        }

        private void txtBedehkar_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBedehkar);
        }

        private void txtBestankar_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBestankar);
        }

        private void btnInsert_P_Factor_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtDescription, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtMoeen_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtAcc_Name, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBedehkar, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBestankar, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (Convert.ToInt32(txtMoeen_Code.Text.Length) <= 3)
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "حساب معین انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
                else if (txtBedehkar.Text != "0" && txtBestankar.Text != "0" || txtBedehkar.Text == "0" && txtBestankar.Text == "0")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "مبالغ وارد شده صحیح نمی باشد";
                    f.ShowDialog();
                    txtBedehkar.BackColor = Color.Red;
                    txtBestankar.BackColor = Color.Red;
                }
                else
                {
                    txtBedehkar.BackColor = Color.White;
                    txtBestankar.BackColor = Color.White;
                    if (op == "Add")
                    {
                        string query = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtAcc_Code.Text + "','" + Convert.ToInt64(txtBedehkar.Text) + "','" + Convert.ToInt64(txtBestankar.Text) + "',N'" + txtDescription.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Convert.ToInt32(txtCode.Text) + "','" + txtMoeen_Code.Text + "',17,'" + txtCode.Text + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            lblMoeen.Text = lblTafsili.Text = "";
                            txtAcc_Code.Text = txtAcc_Name.Text = "";
                            txtDate.Text = txtDescription.Text = txtMoeen_Code.Text = txtMoeen_Name.Text = "";
                            txtBedehkar.Text = txtBestankar.Text = "0";
                            lblSumBed.Text = lblSumBes.Text = lblRemain.Text = "0";
                            lblGues.Text = "";
                            Fill_Doc();
                        }
                    }
                    else if (op == "Edit")
                    {
                        string query = "UPDATE tbl_Transaction SET Code = '" + txtAcc_Code.Text + "', Bedehkar = '" + Convert.ToInt64(txtBedehkar.Text) + "', Bestankar = '" + Convert.ToInt64(txtBestankar.Text) + "', Notice = N'" + txtDescription.Text + "', Moeen = '" + txtMoeen_Code.Text + "' WHERE ID = '" + ID_Edit + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            lblMoeen.Text = lblTafsili.Text = "";
                            txtAcc_Code.Text = txtAcc_Name.Text = "";
                            txtDate.Text = txtDescription.Text = txtMoeen_Code.Text = txtMoeen_Name.Text = "";
                            txtBedehkar.Text = txtBestankar.Text = "0";
                            lblSumBed.Text = lblSumBes.Text = lblRemain.Text = "0";
                            lblGues.Text = "";
                            Fill_Doc();
                        }
                    }
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (lblRemain.Text != "0")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "سند موازنه نیست و سیستم قادر به ذخیره آن نمی باشد";
                f.ShowDialog();
            }
            else
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "سند به عطف " + txtCode.Text + " " + "ذخیره شود؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    frmDocument_Load(null, null);
                }
                else
                {
                    if (op == "Add")
                    {
                        string query = "DELETE FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            frmDocument_Load(null, null);
                        }
                    }
                    else
                    {
                        frmDocument_Load(null, null);
                    }
                }
            }
            btn_flag = 0;
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Parent FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() != "17")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما مجاز به ویرایش سندهای اتوماتیک نمی باشید";
                    f.ShowDialog();
                }
                else
                {
                    op = "Edit";
                    txtDescription.Enabled = true;
                    txtMoeen_Code.Enabled = true;
                    btnSearch_Moeen.Enabled = true;
                    txtAcc_Code.Enabled = true;
                    btnSearch_Acc.Enabled = true;
                    txtDate.Enabled = true;
                    txtBedehkar.Enabled = true;
                    txtBestankar.Enabled = true;
                    btnInsert_P_Factor.Enabled = true;
                }
            }
            catch
            {
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Parent FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString() != "17")
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "شما مجاز به حذف سندهای اتوماتیک نمی باشید";
                    f.ShowDialog();
                }
                else
                {
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف سند به عطف " + txtCode.Text + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        string query = "DELETE FROM tbl_Transaction WHERE Doc_Number='" + Convert.ToInt32(txtCode.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            frmDocument_Load(null, null);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void txtMoeen_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtMoeen_Name.Text != "")
                {
                    txtAcc_Code.Focus();
                }
                else
                {
                    frmShow_Dif_Acc f = new frmShow_Dif_Acc();
                    f.txtSearch.Text = txtMoeen_Code.Text;
                    f.ShowDialog();
                    txtMoeen_Code.Text = f.Moeen_Code;
                }
            }
        }

        private void txtAcc_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtAcc_Name.Text != "")
                {
                    txtDescription.Focus();
                }
                else
                {
                    frmAllAccount f = new frmAllAccount();
                    f.Fill_All_Account();
                    f.op = "All";
                    f.txtSearch.Text = txtAcc_Code.Text;
                    f.ShowDialog();
                    txtAcc_Code.Text = f.Acc_Code;
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDate.Focus();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMoeen_Code.Focus();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBedehkar.Focus();
        }

        private void txtBedehkar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBestankar.Focus();
        }

        private void txtBestankar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnInsert_P_Factor.Focus();
        }

        private void txtBedehkar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtBestankar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void frmDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_flag != 0)
                btnFinish_Click(null, null);
        }
    }
}
