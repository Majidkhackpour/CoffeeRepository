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
    public partial class frmCheck_Asignment : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Safe_Code, Ass_Code, Check_Number;
        public Int64 Check_ID, Check_Price;
        int Doc_Number;
        public void Fill_Safe()
        {
            try
            {
                cmbAsignment.Items.Clear();
                string Query = "SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Safe ON tbl_Account.Code = tbl_Safe.Code";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbAsignment, s_obj);
                cmbAsignment.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Safe FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbAsignment.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public void Fill_Bank()
        {
            try
            {
                cmbAsignment.Items.Clear();
                string Query = "SELECT Description FROM tbl_Account WHERE Parent=10";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbAsignment, s_obj);
                cmbAsignment.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Bank FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbAsignment.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public void Fill_cmbAssignor()
        {
            try
            {
                cmbAssignor.Items.Clear();
                string Query = "SELECT Description FROM tbl_Account WHERE Parent=10 OR Parent=20";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbAssignor, s_obj);
                cmbAssignor.SelectedIndex = 0;
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
        public frmCheck_Asignment()
        {
            InitializeComponent();
        }

        private void frmCheck_Asignment_Load(object sender, EventArgs e)
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

        private void cmbAssignor_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + cmbAssignor.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Safe_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void cmbAsignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + cmbAsignment.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Ass_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (cmbAsignment.Text == cmbAssignor.Text)
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "واگذار کننده و دریافت کننده نمی توانند یکسان باشند";
                f.flag = 0;
                f.ShowDialog();
            }
            else
            {
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از واگذاری چک از " + cmbAssignor.Text + " " + "به " + cmbAsignment.Text + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    Get_Max_Doc_Number();
                    string query1 = "INSERT INTO tbl_Transaction (Code, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Safe_Code + "','" + Check_Price + "',N'" + "واگذاری چک شماره " + Check_Number + " " + "به " + cmbAsignment.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10201" + "',18,'" + Check_ID.ToString() + "')";
                    string query2 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Ass_Code + "','" + Check_Price + "',N'" + "واگذاری چک شماره " + Check_Number + " " + "از " + cmbAssignor.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "10201" + "',18,'" + Check_ID.ToString() + "')";
                    string query3 = "UPDATE tbl_Check_Daryaft SET Safe_Reciver=N'" + cmbAsignment.Text + "' WHERE ID='" + Check_ID + "'";
                    if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true)
                        this.Close();
                }
            }
        }
    }
}
