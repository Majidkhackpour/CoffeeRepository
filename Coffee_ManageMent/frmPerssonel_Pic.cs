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
    public partial class frmPerssonel_Pic : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        Image img;
        WebCam wb = new WebCam();
        public void FillData(string Code)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Perssonel.Pic, tbl_Account.Description FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code WHERE tbl_Perssonel.Code LIKE N'" + Code + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtName.Text = dt.Rows[0].ItemArray[1].ToString();
            txtCode.Text = Code;
            try
            {
                byte[] myarray = null;
                myarray = (byte[])dt.Rows[0].ItemArray[0];
                System.IO.MemoryStream mymemory = new System.IO.MemoryStream(myarray);
                PictureBox.Image = Image.FromStream(mymemory);
            }
            catch
            {
            }
        }
        public frmPerssonel_Pic()
        {
            InitializeComponent();
        }

        private void frmPerssonel_Pic_Load(object sender, EventArgs e)
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                PictureBox.Load(op.FileName);
                img = Image.FromFile(op.FileName);
            }
            catch
            {
            }
        }

        private void btnWebCam_Click(object sender, EventArgs e)
        {
            if (btnWebCam.Text == "WebCam")
            {
                wb.InitializeWebCam(ref PictureBox);
                try
                {
                    wb.Start();
                }
                catch
                {
                }
                finally
                {
                    wb.Continue();
                    btnWebCam.Text = "Capture";
                }
            }
            else if (btnWebCam.Text == "Capture")
            {
                wb.Stop();
                btnWebCam.Text = "WebCam";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] myarray;
                System.IO.MemoryStream mymemory = new System.IO.MemoryStream();
                img.Save(mymemory, PictureBox.Image.RawFormat);
                myarray = mymemory.GetBuffer();
                string query = "UPDATE tbl_Perssonel SET Pic = @Pic WHERE Code = @Code";
                SqlCommand cmd = new SqlCommand(query, dataconnection);
                cmd.Parameters.AddWithValue("@Pic", myarray);
                cmd.Parameters.AddWithValue("@Code", txtCode.Text);
                dataconnection.Open();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
            }
            catch
            {
            }
            this.Close();
        }
    }
}
