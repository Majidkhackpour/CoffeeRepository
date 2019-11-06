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
    public partial class frmPanels : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        private Guid g_Edit;
        public void Form_Load()
        {
            txtAPI.Text = txtName.Text = "";
            txtNumber.Text = "";
        }

        public void Fill_Data(Guid qqGuid)
        {
            Form_Load();
            SqlDataAdapter da =
                new SqlDataAdapter("SELECT Name, API_Code, Line_Number FROM tbl_Panels WHERE Guid='" + qqGuid + "'",
                    dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            g_Edit = qqGuid;
            txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            txtAPI.Text = dt.Rows[0].ItemArray[1].ToString();
            txtNumber.Text = dt.Rows[0].ItemArray[2].ToString();
        }
        public frmPanels()
        {
            InitializeComponent();
        }

        private void frmPanels_Load(object sender, EventArgs e)
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
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true ||
                clsFunction.Error_Provider(txtNumber, errorProvider1, "این فیلد نمی تواند خالی باشد") == true ||
                clsFunction.Error_Provider(txtAPI, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    string query = "INSERT INTO tbl_Panels (Guid,Name,API_Code,Line_Number) VALUES ('" +
                                   Guid.NewGuid() + "',N'" + txtName.Text + "','" + txtAPI.Text.Trim() + "','" +
                                   txtNumber.Text.Trim() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
                else if (op == "Edit")
                {
                    string query = "UPDATE tbl_Panels SET Name=N'" + txtName.Text + "', API_Code='" +
                                   txtAPI.Text.Trim() + "', Line_Number='" + txtNumber.Text.Trim() + "' WHERE Guid='" +
                                   g_Edit + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtAPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{tab}");
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }
    }
}
