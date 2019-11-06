using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace Coffee_ManageMent
{
    public partial class frmCurrent_Safe : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        public void SplashCircleStart()
        {
            Application.Run(new frmShow_Safe());
        }
        public frmCurrent_Safe()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCurrent_Safe_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Account.Description FROM tbl_Safe INNER JOIN tbl_Account ON tbl_Safe.Code = tbl_Account.Code";
            string s_obj = "Description";
            clsFunction.FillComboBox(dataconnection, Query, cmbStore, s_obj);
            cmbStore.SelectedIndex = 0;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Safe FROM tbl_Setting", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbStore.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string query;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
            {
                query = "INSERT INTO tbl_Setting (Current_Safe) VALUES (N'" + cmbStore.Text + "')";
                clsFunction.Execute(dataconnection, query);
            }
            else
            {
                query = "UPDATE tbl_Setting SET Current_Safe=N'" + cmbStore.Text + "' WHERE ID=1";
                clsFunction.Execute(dataconnection, query);
            }
            new frmCircle_Progress().ShowDialog();
            Thread t = new Thread(new ThreadStart(SplashCircleStart));
            t.Start();
            t.Abort();
            this.Close();
        }
    }
}
