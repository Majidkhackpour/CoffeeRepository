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
    public partial class frmShow_Account : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        int Flag;
        string ID;
        private void Display_Data()
        {
            string Query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code ORDER BY tbl_Account.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
            trvAccount.Nodes.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Parent_Name FROM tbl_MoeenAccount", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trvAccount.Nodes.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Description,Parent FROM tbl_Account", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                ID = dt2.Rows[i].ItemArray[1].ToString();
                ID = ID.Remove(1, 1);
                trvAccount.Nodes[Convert.ToInt32(ID) - 1].Nodes.Add(dt2.Rows[i].ItemArray[0].ToString());
            }
        }
        public frmShow_Account()
        {
            InitializeComponent();
        }

        private void frmShow_Account_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            Display_Data();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Last_Account_Operation FROM tbl_Setting", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Flag = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                if (Flag == 1)
                {
                    mnuTree.Visible = false;
                    mnuGrid.Visible = true;
                    trvAccount.Visible = true;
                    dgvAccount.Visible = false;
                }
                else
                {
                    mnuTree.Visible = true;
                    mnuGrid.Visible = false;
                    trvAccount.Visible = false;
                    dgvAccount.Visible = true;
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

        private void mnuTree_Click(object sender, EventArgs e)
        {
            mnuTree.Visible = false;
            mnuGrid.Visible = true;
            trvAccount.Visible = true;
            dgvAccount.Visible = false;
            Flag = 1;
        }

        private void mnuGrid_Click(object sender, EventArgs e)
        {
            mnuTree.Visible = true;
            mnuGrid.Visible = false;
            trvAccount.Visible = false;
            dgvAccount.Visible = true;
            Flag = 0;
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            if (Flag == 1)
            {
                frmAccount f = new frmAccount();
                f.op = "Add";
                f.flag = 0;
                f.Form_Load();
                try
                {
                    f.cmbAccount.Text = trvAccount.SelectedNode.Text;
                }
                catch
                {
                }
                f.ShowDialog();
            }
            else
            {
                frmAccount f = new frmAccount();
                f.op = "Add";
                f.flag = 0;
                f.Form_Load();
                f.ShowDialog();
            }
        }

        private void frmShow_Account_Activated(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            if (Flag == 0)
            {
                try
                {
                    frmAccount f = new frmAccount();
                    f.op = "Edit";
                    f.FillData(dgvAccount.CurrentRow.Cells["Description"].Value.ToString());
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "حساب انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
            else if (Flag == 1)
            {
                try
                {
                    frmAccount f = new frmAccount();
                    f.op = "Edit";
                    f.FillData(trvAccount.SelectedNode.Text);
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "حساب انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccount.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Flag == 0)
                {
                    string query1 = "DELETE FROM tbl_Transaction WHERE Code='" + dgvAccount.CurrentRow.Cells["Code"].Value.ToString() + "'AND Notice='" + "ثبت سند افتتاحیه" + "'";
                    string query2 = "DELETE FROM tbl_Account WHERE Code='" + dgvAccount.CurrentRow.Cells["Code"].Value.ToString() + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف حساب " + dgvAccount.CurrentRow.Cells["Description"].Value.ToString() + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                            Display_Data();
                    }
                }
                else if (Flag == 1)
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Account WHERE Description LIKE N'" + trvAccount.SelectedNode.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string query1 = "DELETE FROM tbl_Transaction WHERE Code='" + dt.Rows[0].ItemArray[0].ToString() + "'AND Notice='" + "ثبت سند افتتاحیه" + "'";
                    string query2 = "DELETE FROM tbl_Account WHERE Code='" + dt.Rows[0].ItemArray[0].ToString() + "'";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از حذف حساب " + trvAccount.SelectedNode.Text + " " + "اطمینان دارید؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                            Display_Data();
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما مجاز به حذف این حساب نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            if (Flag == 0)
            {
                try
                {
                    frmAccount f = new frmAccount();
                    f.FillData(dgvAccount.CurrentRow.Cells["Description"].Value.ToString());
                    f.grpAccount.Enabled = false;
                    f.btnFinish.Enabled = false;
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "حساب انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
            else if (Flag == 1)
            {
                try
                {
                    frmAccount f = new frmAccount();
                    f.FillData(trvAccount.SelectedNode.Text);
                    f.grpAccount.Enabled = false;
                    f.btnFinish.Enabled = false;
                    f.ShowDialog();
                }
                catch
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "حساب انتخابی معتبر نمی باشد";
                    f.ShowDialog();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT tbl_Account.Code, tbl_Account.Description, tbl_MoeenAccount.Parent_Name FROM tbl_Account INNER JOIN tbl_MoeenAccount ON tbl_Account.Parent = tbl_MoeenAccount.Parent_Code WHERE tbl_Account.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%'";
                clsFunction.Display(query, dataconnection, dgvAccount, lblCounter);
            }
            catch
            {
            }
        }

        private void frmShow_Account_FormClosing(object sender, FormClosingEventArgs e)
        {
            string query;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Count (ID) FROM tbl_Setting", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) <= 0)
            {
                query = "INSERT INTO tbl_Setting (Last_Account_Operation) VALUES ('" + Flag + "')";
                clsFunction.Execute(dataconnection, query);
            }
            else
            {
                query = "UPDATE tbl_Setting SET Last_Account_Operation='" + Flag + "' WHERE ID=1";
                clsFunction.Execute(dataconnection, query);
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuExport_To_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Export_Data_To_Excel(dgvAccount);
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "سیستم شما قادر به ایجاد فایل اکسل نمی باشد. لطفا تنظیمات ویندوز را بررسی و مجددا تلاش نمایید";
                f.ShowDialog();
            }
        }

        private void mnuImport_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                new frmImport_Account_From_Excel().ShowDialog();
            }
            catch
            {
            }
        }

        private void وردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.doc)|*.doc";
            sfd.FileName = "Export.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                clsFunction.ToCsv(dgvAccount, sfd.FileName);
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "فایل متنی در مسیر " + sfd.FileName + " " + "ذخیره شد";
                f.ShowDialog();
            }
        }
    }
}
