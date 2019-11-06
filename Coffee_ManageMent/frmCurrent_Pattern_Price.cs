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
    public partial class frmCurrent_Pattern_Price : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Pattern_Type;
        public void SplashCircleStart()
        {
            Application.Run(new frmShow_Price_Pattern());
        }
        public frmCurrent_Pattern_Price()
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void frmCurrent_Pattern_Price_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            if (Pattern_Type == "Buy")
            {
                string Query = "SELECT Description FROM tbl_Price_Pattern WHERE Type=0";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbStore, s_obj);
                cmbStore.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Buy_Pattern FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStore.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {

                }
            }
            else if (Pattern_Type == "Sell")
            {
                string Query = "SELECT Description FROM tbl_Price_Pattern WHERE Type=1";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbStore, s_obj);
                cmbStore.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Sell_Pattern FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStore.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {

                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (Pattern_Type == "Buy")
            {
                string query;
                SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
                {
                    query = "INSERT INTO tbl_Setting (Current_Buy_Pattern) VALUES (N'" + cmbStore.Text + "')";
                    clsFunction.Execute(dataconnection, query);
                }
                else
                {
                    query = "UPDATE tbl_Setting SET Current_Buy_Pattern=N'" + cmbStore.Text + "' WHERE ID=1";
                    clsFunction.Execute(dataconnection, query);
                }
            }
            else if (Pattern_Type == "Sell")
            {
                string query;
                SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
                {
                    query = "INSERT INTO tbl_Setting (Current_Sell_Pattern) VALUES (N'" + cmbStore.Text + "')";
                    clsFunction.Execute(dataconnection, query);
                }
                else
                {
                    query = "UPDATE tbl_Setting SET Current_Sell_Pattern=N'" + cmbStore.Text + "' WHERE ID=1";
                    clsFunction.Execute(dataconnection, query);
                }
            }
            new frmCircle_Progress().ShowDialog();
            Thread t = new Thread(new ThreadStart(SplashCircleStart));
            t.Start();
            t.Abort();
            this.Close();
        }
    }
}
