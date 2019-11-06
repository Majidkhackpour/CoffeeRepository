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
    public partial class frmShow_Product_Type : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        string ID;
        public void Show_Data()
        {
            try
            {
                trvP_Type.Nodes.Clear();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Product_Type", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    trvP_Type.Nodes.Add(dt.Rows[i].ItemArray[0].ToString());
                }
                try
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT P_Show_Name,Product_Group FROM tbl_Product", dataconnection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        ID = dt2.Rows[i].ItemArray[1].ToString();
                        trvP_Type.Nodes[Convert.ToInt32(ID) - 1].Nodes.Add(dt2.Rows[i].ItemArray[0].ToString());
                    }
                }
                catch
                {
                }
                lblCounter.Text = trvP_Type.Nodes.Count.ToString();
            }
            catch
            {
            }
        }
        public frmShow_Product_Type()
        {
            InitializeComponent();
        }

        private void frmShow_Product_Type_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            Show_Data();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduct_Type f = new frmProduct_Type();
                f.Form_Load();
                f.op = "Add";
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduct_Type f = new frmProduct_Type();
                f.op = "Edit";
                f.FillData(trvP_Type.SelectedNode.Text);
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "طبقه بندی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Product_Type WHERE Description='" + trvP_Type.SelectedNode.Text + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + trvP_Type.SelectedNode.Text + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Product_Type_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این طبقه بندی نمی باشید";
                f.ShowDialog();
            }
        }

        private void frmShow_Product_Type_Activated(object sender, EventArgs e)
        {
            Show_Data();
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduct_Type f = new frmProduct_Type();
                f.FillData(trvP_Type.SelectedNode.Text);
                f.groupPanel1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "طبقه بندی انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }
    }
}
