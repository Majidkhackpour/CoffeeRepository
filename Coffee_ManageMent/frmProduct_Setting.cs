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
    public partial class frmProduct_Setting : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        int Identification;
        public frmProduct_Setting()
        {
            InitializeComponent();
        }

        private void frmProduct_Setting_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            try
            {
                cmbUnit.Items.Clear();
                string Query = "SELECT Unit_Name FROM tbl_Unit";
                string s_obj = "Unit_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbUnit, s_obj);
                cmbUnit.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Pic_Patch, Current_Unit, Identification, Type_Name FROM tbl_Product_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    txtPatch.Text = dt.Rows[0].ItemArray[0].ToString();
                    cmbUnit.Text = dt.Rows[0].ItemArray[1].ToString();
                    if (dt.Rows[0].ItemArray[2].ToString() == "0")
                        rbtnBarcode.Checked = true;
                    else if (dt.Rows[0].ItemArray[2].ToString() == "1")
                        rbtnCode.Checked = true;
                    else if (dt.Rows[0].ItemArray[2].ToString() == "2")
                        rbtnTec_Code.Checked = true;
                    else
                    {
                        rbtnBarcode.Checked = false;
                        rbtnCode.Checked = false;
                        rbtnTec_Code.Checked = false;
                    }
                    if (Convert.ToBoolean(dt.Rows[0].ItemArray[3].ToString()) == true)
                        chbType_Name.Checked = true;
                    else
                        chbType_Name.Checked = false;
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

        private void btnPatch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "لطفا محل ذخیره سازی تصاویر کالا را انتخاب نمایید";
            fbd.ShowDialog();
            txtPatch.Text = fbd.SelectedPath;
        }

        private void btnFinish1_Click(object sender, EventArgs e)
        {
            string query;
            if (rbtnBarcode.Checked)
                Identification = 0;
            else if (rbtnCode.Checked)
                Identification = 1;
            else if (rbtnTec_Code.Checked)
                Identification = 2;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Product_Setting", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            frmMessage f = new frmMessage();
            f.lblMessage.Text = "تنظیمات کالا ست شده است." + "\n" + "ادامه می دهید؟";
            f.flag = 1;
            f.ShowDialog();
            if (f.Resault == 0)
            {
                if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
                {
                    query = "INSERT INTO tbl_Product_Setting (ID, Pic_Patch, Current_Unit, Identification, Type_Name) VALUES (1,'" + txtPatch.Text + "',N'" + cmbUnit.Text + "','" + Identification + "','" + chbType_Name.Checked + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
                else
                {
                    query = "UPDATE tbl_Product_Setting SET Pic_Patch = '" + txtPatch.Text + "', Current_Unit = N'" + cmbUnit.Text + "', Identification = '" + Identification + "', Type_Name = '" + chbType_Name.Checked + "' WHERE ID=1";
                    if (clsFunction.Execute(dataconnection, query) == true)
                        this.Close();
                }
            }
        }
    }
}
