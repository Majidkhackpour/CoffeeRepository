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
using System.Data.OleDb;

namespace Coffee_ManageMent
{
    public partial class frmImport_Account_From_Excel : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        DataTable dt;
        public frmImport_Account_From_Excel()
        {
            InitializeComponent();
        }

        private void frmImport_Account_From_Excel_Load(object sender, EventArgs e)
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

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Excel File";
            ofd.InitialDirectory = @"c:\";
            ofd.FileName = txtAddress.Text;
            ofd.Filter = "Excel Sheet (*.xls)|*.xls|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
                txtAddress.Text = ofd.FileName;
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string str = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + txtAddress.Text + "; Extended Properties=\"Excel 8.0; HDR=Yes;\";";
            //    OleDbConnection con = new OleDbConnection(str);
            //    OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM [" + txtSheet.Text + "$]", con);
            //    DataTable dt = new DataTable();
            //    adp.Fill(dt);
            //    dgvStore.DataSource = dt;
            //}
            //catch
            //{
            //}
            await Find_Excel();
            dgvStore.DataSource = dt;
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dgvStore.Rows.Count; i++)
            //{
            //    try
            //    {
            //        string query = "INSERT INTO tbl_Account (Code, Description, Parent, Bedehkar, Bestankar) VALUES ('" + dgvStore.Rows[i].Cells[0].Value.ToString() + "',N'" + dgvStore.Rows[i].Cells[1].Value.ToString() + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells[2].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[3].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[4].Value.ToString()) + "')";
            //        if (clsFunction.Execute(dataconnection, query) == true)
            //        {
            //            if (Convert.ToInt64(dgvStore.Rows[i].Cells[3].Value.ToString()) != 0 || Convert.ToInt64(dgvStore.Rows[i].Cells[4].Value.ToString()) != 0)
            //            {
            //                string query2 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Parent, Parent_Code) VALUES ('" + dgvStore.Rows[i].Cells[0].Value.ToString() + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[3].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[4].Value.ToString()) + "','" + "ثبت سند افتتاحیه" + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "',1,0,1)";
            //                if (clsFunction.Execute(dataconnection, query2) == true)
            //                {
            //                }
            //            }
            //        }
            //    }
            //    catch
            //    {
            //    }
            //}
            //this.Close();
            await Save_Data();
        }

        private void txtSheet_Enter(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_English();
        }

        private void txtSheet_Leave(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_Persian();
        }
        private async Task Find_Excel()
        {
            await Task.Run(() =>
                {
                    try
                    {
                        string str = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + txtAddress.Text + "; Extended Properties=\"Excel 8.0; HDR=Yes;\";";
                        OleDbConnection con = new OleDbConnection(str);
                        OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM [" + txtSheet.Text + "$]", con);
                        dt = new DataTable();
                        adp.Fill(dt);
                    }
                    catch
                    {
                    }
                });
        }
        private async Task Save_Data()
        {
            await Task.Run(() =>
                {
                    for (int i = 0; i < dgvStore.Rows.Count; i++)
                    {
                        try
                        {
                            string query = "INSERT INTO tbl_Account (Code, Description, Parent, Bedehkar, Bestankar) VALUES ('" + dgvStore.Rows[i].Cells[0].Value.ToString() + "',N'" + dgvStore.Rows[i].Cells[1].Value.ToString() + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells[2].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[3].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[4].Value.ToString()) + "')";
                            if (clsFunction.Execute(dataconnection, query) == true)
                            {
                                if (Convert.ToInt64(dgvStore.Rows[i].Cells[3].Value.ToString()) != 0 || Convert.ToInt64(dgvStore.Rows[i].Cells[4].Value.ToString()) != 0)
                                {
                                    string query2 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Parent, Parent_Code) VALUES ('" + dgvStore.Rows[i].Cells[0].Value.ToString() + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[3].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells[4].Value.ToString()) + "','" + "ثبت سند افتتاحیه" + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "',1,0,1)";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    this.Close();
                });
        }
    }
}
