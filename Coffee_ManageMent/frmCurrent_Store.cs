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
using System.Threading;

namespace Coffee_ManageMent
{
    public partial class frmCurrent_Store : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        public void SplashCircleStart()
        {
            Application.Run(new frmShow_Stores());
        }
        public frmCurrent_Store()
        {
            InitializeComponent();
        }

        private void frmCurrent_Store_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            try
            {
                string Query = "SELECT Shown_Name FROM tbl_Store";
                string s_obj = "Shown_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbStore, s_obj);
                cmbStore.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Store FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStore.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
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
            string query;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
            {
                query = "INSERT INTO tbl_Setting (Current_Store) VALUES (N'" + cmbStore.Text + "')";
                clsFunction.Execute(dataconnection, query);
            }
            else
            {
                query = "UPDATE tbl_Setting SET Current_Store=N'" + cmbStore.Text + "' WHERE ID=1";
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
