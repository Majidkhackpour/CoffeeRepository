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
using System.IO;
namespace Coffee_ManageMent
{
    public partial class frmLogPerssonel : Form
    {
        string Res;
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        int Per_ID, Max_Leave, H_Day, Log, Calc;
        string Ent_Hour, Ent_Min;
        private void Fill_Perssonel()
        {
            try
            {
                cmbPerssonel.Items.Clear();
                string Query = "SELECT DISTINCT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Perssonel ON tbl_Account.Code = tbl_Perssonel.Code";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbPerssonel, s_obj);
                cmbPerssonel.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        public frmLogPerssonel()
        {
            InitializeComponent();
        }

        private void frmLogPerssonel_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            lblCode.Text = lblSemat.Text = "";
            rbtnEnter.Checked = true;
            string Hour, Min;
            Hour = System.DateTime.Now.Hour.ToString();
            Min = System.DateTime.Now.Minute.ToString();
            if (Convert.ToInt32(Min) > 0 && Convert.ToInt32(Min) <= 9)
            {
                Min = "0" + Min;
            }
            else if (Convert.ToInt32(Min) > 9)
            {
                Min = Min;
            }
            txtTime.Text = Hour + Min;
            Fill_Perssonel();
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

        private void cmbPerssonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT tbl_Perssonel.ID, tbl_Perssonel.Code, tbl_Perssonel_Group.Group_Name FROM tbl_Perssonel INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Perssonel_Group ON tbl_Perssonel.Group_ID = tbl_Perssonel_Group.Group_ID WHERE tbl_Account.Description LIKE N'" + cmbPerssonel.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblCode.Text = (string)dr["Code"];
                    lblSemat.Text = (string)dr["Group_Name"];
                    Per_ID = (int)dr["ID"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (txtTime.Text == "  :")
            {
                errorProvider1.Clear();
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(txtTime, "این فیلد نمی تواند خالی باشد");
            }
            else
            {
                if (rbtnEnter.Checked)
                    Log = 0;
                else
                    Log = 1;
                SqlDataAdapter da = new SqlDataAdapter("SELECT Max_Leave, H_Day FROM tbl_Contract WHERE Code='" + lblCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Max_Leave = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                H_Day = Convert.ToInt32(dt.Rows[0].ItemArray[1]);
                string Year, Mount, Day;
                Year = clsFunction.M2SH(DateTime.Now).Substring(0, 4);
                Mount = clsFunction.M2SH(DateTime.Now).Substring(5, 2);
                Day = clsFunction.M2SH(DateTime.Now).Substring(8, 2);
                if (rbtnEnter.Checked)
                {
                    string query = "INSERT INTO tbl_LogPerssonel (Guid, Per_ID, Year, Mounth, Day, Type, Hour, Min) VALUES ('" + Guid.NewGuid() + "','" + Per_ID + "','" + Year + "','" + Mount + "','" + Day + "','" + Log + "','" + txtTime.Text.Substring(0, 2) + "','" + txtTime.Text.Substring(3, 2) + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                        if (lblSemat.Text == "پیک ها")
                        {
                            string query3 = "INSERT INTO tbl_Perssonel_Trafic (Per_ID, Date, Time, Traf_Type) VALUES ('"+Per_ID+"','"+clsFunction.M2SH(DateTime.Now)+"','"+txtTime.Text+"',0)";
                            if (clsFunction.Execute(dataconnection, query3) == true)
                            {
                            }
                        }
                        this.Close();
                    }
                }

                else if (rbtnExit.Checked)
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT Hour, Min FROM tbl_LogPerssonel WHERE Year='" + Year + "' AND Mounth='" + Mount + "' AND Day='" + Day + "' AND Type=0 AND Per_ID='" + Per_ID + "'", dataconnection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    Ent_Hour = dt2.Rows[0].ItemArray[0].ToString();
                    Ent_Min = dt2.Rows[0].ItemArray[1].ToString();
                    string New_Hour, New_Min;
                    New_Hour = (Convert.ToInt32(txtTime.Text.Substring(0, 2)) - Convert.ToInt32(Ent_Hour)).ToString();
                    New_Min = (Convert.ToInt32(txtTime.Text.Substring(3, 2)) - Convert.ToInt32(Ent_Min)).ToString();
                    Calc = H_Day - Convert.ToInt32(New_Hour);
                    if (Calc > 0)
                    {
                        Res = "INSERT INTO tbl_LogPerssonel (Guid, Per_ID, Year, Mounth, Day, Type, Hour, Min, Kasr_Hour, Kasr_Min, Hoz_Hour, Hoz_Min) VALUES ('" + Guid.NewGuid() + "','" + Per_ID + "','" + Year + "','" + Mount + "','" + Day + "','" + Log + "','" + txtTime.Text.Substring(0, 2) + "','" + txtTime.Text.Substring(3, 2) + "','" + Convert.ToInt32(Calc - 1) + "','" + Convert.ToInt32(60 - Convert.ToInt32(New_Min)) + "','" + Convert.ToInt32(New_Hour) + "','" + Convert.ToInt32(New_Min) + "')";
                    }
                    else if (Calc <= 0)
                    {
                        Calc = System.Math.Abs(Calc);
                        Res = "INSERT INTO tbl_LogPerssonel (Guid, Per_ID, Year, Mounth, Day, Type, Hour, Min, Ez_Hour, Ez_Min, Hoz_Hour, Hoz_Min) VALUES ('" + Guid.NewGuid() + "','" + Per_ID + "','" + Year + "','" + Mount + "','" + Day + "','" + Log + "','" + txtTime.Text.Substring(0, 2) + "','" + txtTime.Text.Substring(3, 2) + "','" + Calc + "','" + Convert.ToInt32(New_Min) + "','" + Convert.ToInt32(New_Hour) + "','" + Convert.ToInt32(New_Min) + "')";
                    }
                    if (clsFunction.Execute(dataconnection, Res) == true)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void mnuPrint_One_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmShow_Personnel_Log f = new frmShow_Personnel_Log();
                f.Show_One(Per_ID);
                f.op = "One";
                f.Per_Id = Per_ID;
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuPrint_All_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Personnel_Log f = new frmShow_Personnel_Log();
                f.Show_All();
                f.op = "All";
                f.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
