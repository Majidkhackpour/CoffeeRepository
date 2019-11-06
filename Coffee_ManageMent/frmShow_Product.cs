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
    public partial class frmShow_Product : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        int Flag;
        string ID;
        private void Display_Data()
        {
            string Query = "SELECT tbl_Product.P_Code, tbl_Product_Type.Description, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Store.Shown_Name FROM tbl_Product INNER JOIN tbl_Product_Type ON tbl_Product.Product_Group = tbl_Product_Type.Type_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Product.Store = tbl_Store.Code ORDER BY tbl_Product.P_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
            try
            {
                trvProduct.Nodes.Clear();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Description FROM tbl_Product_Type", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    trvProduct.Nodes.Add(dt.Rows[i].ItemArray[0].ToString());
                }
                try
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT P_Show_Name,Product_Group FROM tbl_Product", dataconnection);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        ID = dt2.Rows[i].ItemArray[1].ToString();
                        trvProduct.Nodes[Convert.ToInt32(ID) - 1].Nodes.Add(dt2.Rows[i].ItemArray[0].ToString());
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public frmShow_Product()
        {
            InitializeComponent();
        }

        private void frmShow_Product_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            Display_Data();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Last_Product_Operation FROM tbl_Setting", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Flag = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                if (Flag == 1)
                {
                    mnuTree.Visible = false;
                    mnuGrid.Visible = true;
                    trvProduct.Visible = true;
                    dgvProduct.Visible = false;
                }
                else
                {
                    mnuTree.Visible = true;
                    mnuGrid.Visible = false;
                    trvProduct.Visible = false;
                    dgvProduct.Visible = true;
                }
            }
            catch
            {

            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuTree_Click(object sender, EventArgs e)
        {
            mnuTree.Visible = false;
            mnuGrid.Visible = true;
            trvProduct.Visible = true;
            dgvProduct.Visible = false;
            txtSearch.Visible = false;
            Flag = 1;
        }

        private void mnuGrid_Click(object sender, EventArgs e)
        {
            mnuTree.Visible = true;
            mnuGrid.Visible = false;
            trvProduct.Visible = false;
            dgvProduct.Visible = true;
            txtSearch.Visible = true;
            Flag = 0;
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {

            if (Flag == 1)
            {
                frmProduct f = new frmProduct();
                f.op = "Add";
                f.Flag = 0;
                f.Form_Load();
                try
                {
                    f.cmbType.Text = trvProduct.SelectedNode.Text;
                }
                catch
                {
                }
                f.ShowDialog();
            }
            else
            {
                frmProduct f = new frmProduct();
                f.op = "Add";
                f.Flag = 0;
                f.Form_Load();
                f.ShowDialog();
            }
        }

        private void frmShow_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            string query;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
            {
                query = "INSERT INTO tbl_Setting (Last_Product_Operation) VALUES ('" + Flag + "')";
                clsFunction.Execute(dataconnection, query);
            }
            else
            {
                query = "UPDATE tbl_Setting SET Last_Product_Operation='" + Flag + "' WHERE ID=1";
                clsFunction.Execute(dataconnection, query);
            }
        }

        private void frmShow_Product_Activated(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            if (Flag == 0)
            {
                try
                {
                    frmProduct f = new frmProduct();
                    f.op = "Edit";
                    f.FillData(dgvProduct.CurrentRow.Cells["P_Name"].Value.ToString());
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "کالای انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
            else if (Flag == 1)
            {
                try
                {
                    frmProduct f = new frmProduct();
                    f.op = "Edit";
                    f.FillData(trvProduct.SelectedNode.Text);
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "کالای انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Flag == 0)
                {
                    string P_Code = dgvProduct.CurrentRow.Cells["P_Code"].Value.ToString();
                    string query1 = "DELETE FROM tbl_Tour_Of_Product WHERE P_Code='" + Convert.ToInt32(P_Code) + "'AND Notice='" + "اول دوره" + "'";
                    string query2 = "DELETE FROM tbl_Product WHERE P_Code='" + Convert.ToInt32(P_Code) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف کالای " + dgvProduct.CurrentRow.Cells["P_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT Pic_Patch FROM tbl_Product_Setting WHERE ID=1", dataconnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            frmMessage f1 = new frmMessage();
                            f1.lblMessage.Text = "آیا تصویر کالا در مسیر " + dt.Rows[0].ItemArray[0].ToString() + " " + "نیز حذف شود؟";
                            f1.flag = 1;
                            f1.ShowDialog();
                            if (f1.Resault == 0)
                            {
                                try
                                {
                                    System.IO.File.Delete(dt.Rows[0].ItemArray[0].ToString() + "0" + P_Code + ".jpg");
                                }
                                catch
                                {
                                    System.IO.File.Delete(dt.Rows[0].ItemArray[0].ToString() + P_Code + ".jpg");
                                }
                            }
                            Display_Data();
                        }
                    }
                }
                else if (Flag == 1)
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT P_Code FROM tbl_Product WHERE P_Show_Name LIKE N'" + trvProduct.SelectedNode.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string P_Code = dt.Rows[0].ItemArray[0].ToString();
                    string query1 = "DELETE FROM tbl_Tour_Of_Product WHERE P_Code='" + Convert.ToInt32(P_Code) + "'AND Notice='" + "اول دوره" + "'";
                    string query2 = "DELETE FROM tbl_Product WHERE P_Code='" + Convert.ToInt32(P_Code) + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف کالای " + trvProduct.SelectedNode.Text + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Pic_Patch FROM tbl_Product_Setting WHERE ID=1", dataconnection);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            frmMessage f12 = new frmMessage();
                            f12.lblMessage.Text = "آیا تصویر کالا در مسیر " + dt2.Rows[0].ItemArray[0].ToString() + " " + "نیز حذف شود؟";
                            f12.flag = 1;
                            f12.ShowDialog();
                            if (f12.Resault == 0)
                            {
                                try
                                {
                                    System.IO.File.Delete(dt2.Rows[0].ItemArray[0].ToString() + "0" + P_Code + ".jpg");
                                }
                                catch
                                {
                                    System.IO.File.Delete(dt2.Rows[0].ItemArray[0].ToString() + P_Code + ".jpg");
                                }
                            }
                            Display_Data();
                        }
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما مجاز به حذف این کالا نمی باشید";
                f.ShowDialog();
            }
        }

        private void dgvProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvProduct.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuProduct_Type_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShow_Product_Type().ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            if (Flag == 0)
            {
                try
                {
                    frmProduct f = new frmProduct();
                    f.FillData(dgvProduct.CurrentRow.Cells["P_Name"].Value.ToString());
                    f.grpBaseInfo.Enabled = false;
                    f.grpFull_Info.Enabled = false;
                    f.grpInventory_Info.Enabled = false;
                    f.grpTax_Info.Enabled = false;
                    f.btnFinish.Enabled = false;
                    f.rbtnProduct.Enabled = false;
                    f.rbtnService.Enabled = false;
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "کالای انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
            else if (Flag == 1)
            {
                try
                {
                    frmProduct f = new frmProduct();
                    f.FillData(trvProduct.SelectedNode.Text);
                    f.grpBaseInfo.Enabled = false;
                    f.grpFull_Info.Enabled = false;
                    f.grpInventory_Info.Enabled = false;
                    f.grpTax_Info.Enabled = false;
                    f.btnFinish.Enabled = false;
                    f.rbtnProduct.Enabled = false;
                    f.rbtnService.Enabled = false;
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "کالای انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT tbl_Product.P_Code, tbl_Product_Type.Description, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Store.Shown_Name FROM tbl_Product INNER JOIN tbl_Product_Type ON tbl_Product.Product_Group = tbl_Product_Type.Type_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Product.Store = tbl_Store.Code WHERE tbl_Product.P_Show_Name LIKE N'%" + txtSearch.Text + "%' OR tbl_Product_Type.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Store.Shown_Name LIKE N'%" + txtSearch.Text + "%'";
                clsFunction.Display(query, dataconnection, dgvProduct, lblCounter);
            }
            catch
            {
            }
        }

        private void mnuExport_To_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Export_Data_To_Excel(dgvProduct);
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "سیستم شما قادر به ایجاد فایل اکسل نمی باشد. لطفا تنظیمات ویندوز را بررسی و مجددا تلاش نمایید";
                f.ShowDialog();
            }
        }
    }
}
