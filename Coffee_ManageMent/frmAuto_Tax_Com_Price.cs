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
    public partial class frmAuto_Tax_Com_Price : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public void Form_Load()
        {
            rbtnAll.Checked = true;
            txtTax.Text = txtComplication.Text = "0";
        }
        public frmAuto_Tax_Com_Price()
        {
            InitializeComponent();
        }

        private void frmAuto_Tax_Com_Price_Load(object sender, EventArgs e)
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

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
                grpProduct2.Enabled = false;
            else if (rbtnSelect.Checked)
                grpProduct2.Enabled = true;
        }

        private void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
                grpProduct2.Enabled = false;
            else if (rbtnSelect.Checked)
                grpProduct2.Enabled = true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
            {
                if (clsFunction.Error_Provider(txtTax, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtComplication, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
                {
                }
                else
                {
                    errorProvider1.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Product", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int Tax = Convert.ToInt32(txtTax.Text);
                    int Complication = Convert.ToInt32(txtComplication.Text);
                    string query;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            Int32 TAX = (Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Tax) / 100;
                            Int32 COM = (Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Complication) / 100;
                            query = "UPDATE tbl_Product SET Tax_Price = '" + TAX + "', Complication_Price = '" + COM + "'  WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                            }
                        }
                        catch
                        {
                        }
                    }
                    this.Close();
                }
            }
            else if (rbtnSelect.Checked)
            {
                if (clsFunction.Error_Provider(txtName1, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtName1, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtTax, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtComplication, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
                {
                }
                else
                {
                    errorProvider1.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code, Buy_Price FROM tbl_Product WHERE P_Code>='" + Convert.ToInt32(txtCode1.Text) + "' AND P_Code<='" + Convert.ToInt32(txtCode2.Text) + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int Tax = Convert.ToInt32(txtTax.Text);
                    int Complication = Convert.ToInt32(txtComplication.Text);
                    string query;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            Int32 TAX = (Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Tax) / 100;
                            Int32 COM = (Convert.ToInt32(dt.Rows[i].ItemArray[1]) * Complication) / 100;
                            query = "UPDATE tbl_Product SET Tax_Price = '" + TAX + "', Complication_Price = '" + COM + "'  WHERE P_Code = '" + Convert.ToInt32(dt.Rows[i].ItemArray[0]) + "'";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                            }
                        }
                        catch
                        {
                        }
                    }
                    this.Close();
                }
            }
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtTax.Text) > 100)
                    txtTax.Text = "100";
            }
            catch
            {
            }
        }

        private void txtComplication_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtComplication.Text) > 100)
                    txtComplication.Text = "100";
            }
            catch
            {
            }
        }

        private void txtCode1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Show_Name FROM tbl_Product WHERE P_Code='" + Convert.ToInt32(txtCode1.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName1.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName1.Text = "";
            }
        }

        private void txtCode2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Show_Name FROM tbl_Product WHERE P_Code='" + Convert.ToInt32(txtCode2.Text) + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName2.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName2.Text = "";
            }
        }

        private void btnSearchProduct1_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllProduct f = new frmAllProduct();
                f.op = "All";
                f.Fill_All_Product();
                f.ShowDialog();
                txtCode1.Text = f.Product_Code;
            }
            catch
            {
                txtCode1.Text = "";
            }
        }

        private void btnSearchProduct2_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllProduct f = new frmAllProduct();
                f.op = "All";
                f.Fill_All_Product();
                f.ShowDialog();
                txtCode2.Text = f.Product_Code;
            }
            catch
            {
                txtCode2.Text = "";
            }
        }

        private void rbtnAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode1.Focus();
        }

        private void txtCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode2.Focus();
        }

        private void txtCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTax.Focus();
        }

        private void txtTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtComplication.Focus();
        }

        private void txtComplication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtCode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtComplication_KeyPress(object sender, KeyPressEventArgs e)
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
