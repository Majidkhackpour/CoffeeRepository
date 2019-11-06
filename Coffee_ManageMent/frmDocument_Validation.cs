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
    public partial class frmDocument_Validation : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        string query;
        private void Fill_Data()
        {
            SqlDataAdapter da = new SqlDataAdapter("(SELECT tbl_Header_WareTransfer.ID, tbl_Account.Description, tbl_Header_WareTransfer.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_WareTransfer.Validation, tbl_Header_WareTransfer.Type FROM tbl_Header_WareTransfer INNER JOIN tbl_Account ON tbl_Header_WareTransfer.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_WareTransfer.Type = tbl_Trans_Parent.Parent) UNION (SELECT tbl_Header_WareReceipt.ID, tbl_Account.Description, tbl_Header_WareReceipt.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_WareReceipt.Validation, tbl_Header_WareReceipt.Type FROM tbl_Header_WareReceipt INNER JOIN tbl_Account ON tbl_Header_WareReceipt.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_WareReceipt.Type = tbl_Trans_Parent.Parent) UNION (SELECT tbl_Header_TurnTransfer.ID, tbl_Account.Description, tbl_Header_TurnTransfer.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_TurnTransfer.Validation, tbl_Header_TurnTransfer.Type FROM tbl_Header_TurnTransfer INNER JOIN tbl_Account ON tbl_Header_TurnTransfer.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_TurnTransfer.Type = tbl_Trans_Parent.Parent) UNION (SELECT tbl_Header_TurnReceipt.ID, tbl_Account.Description, tbl_Header_TurnReceipt.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_TurnReceipt.Validation, tbl_Header_TurnReceipt.Type FROM tbl_Header_TurnReceipt INNER JOIN tbl_Account ON tbl_Header_TurnReceipt.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_TurnReceipt.Type = tbl_Trans_Parent.Parent)", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStore.DataSource = dt;
            lblCounter.Text = dgvStore.Rows.Count.ToString();
        }
        public frmDocument_Validation()
        {
            InitializeComponent();
        }

        private void frmDocument_Validation_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            Fill_Data();
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

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void frmDocument_Validation_Activated(object sender, EventArgs e)
        {
            Fill_Data();
        }

        private void mnuValidate_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["Validation"].Value.ToString() == "بله")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "این " + dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() + " " + "با شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "تایید شده می باشد";
                f.ShowDialog();
            }
            else
            {
                if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "حواله انبار")
                {
                    query = "UPDATE tbl_Header_WareTransfer SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور فروش")
                {
                    query = "UPDATE tbl_Header_WareTransfer SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "حواله برگشت")
                {
                    query = "UPDATE tbl_Header_TurnTransfer SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "رسید برگشت")
                {
                    query = "UPDATE tbl_Header_TurnReceipt SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور برگشت از فروش")
                {
                    query = "UPDATE tbl_Header_TurnReceipt SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "رسید انبار")
                {
                    query = "UPDATE tbl_Header_WareReceipt SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور خرید")
                {
                    query = "UPDATE tbl_Header_WareReceipt SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور برگشت از خرید")
                {
                    query = "UPDATE tbl_Header_TurnTransfer SET Validation='" + "بله" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از تایید " + dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() + " " + "با شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query) == true)
                        Fill_Data();
                }
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["Validation"].Value.ToString() == "خیر")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "این " + dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() + " " + "با شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "تایید شده نمی باشد";
                f.ShowDialog();
            }
            else
            {
                if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "حواله انبار")
                {
                    query = "UPDATE tbl_Header_WareTransfer SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور فروش")
                {
                    query = "UPDATE tbl_Header_WareTransfer SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "حواله برگشت")
                {
                    query = "UPDATE tbl_Header_TurnTransfer SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "رسید برگشت")
                {
                    query = "UPDATE tbl_Header_TurnReceipt SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور برگشت از فروش")
                {
                    query = "UPDATE tbl_Header_TurnReceipt SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "رسید انبار")
                {
                    query = "UPDATE tbl_Header_WareReceipt SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور خرید")
                {
                    query = "UPDATE tbl_Header_WareReceipt SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                else if (dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() == "فاکتور برگشت از خرید")
                {
                    query = "UPDATE tbl_Header_TurnTransfer SET Validation='" + "خیر" + "' WHERE ID='" + Convert.ToInt64(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "' AND Type='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["Type"].Value.ToString()) + "'";
                }
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف تایید " + dgvStore.CurrentRow.Cells["Parent_Name"].Value.ToString() + " " + "با شماره " + dgvStore.CurrentRow.Cells["ID"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query) == true)
                        Fill_Data();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Header_WareTransfer.ID, tbl_Account.Description, tbl_Header_WareTransfer.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_WareTransfer.Validation, tbl_Header_WareTransfer.Type FROM tbl_Header_WareTransfer INNER JOIN tbl_Account ON tbl_Header_WareTransfer.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_WareTransfer.Type = tbl_Trans_Parent.Parent WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Trans_Parent.Parent_Name LIKE N'%" + txtSearch.Text + "%' UNION SELECT tbl_Header_WareReceipt.ID, tbl_Account.Description, tbl_Header_WareReceipt.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_WareReceipt.Validation, tbl_Header_WareReceipt.Type FROM tbl_Header_WareReceipt INNER JOIN tbl_Account ON tbl_Header_WareReceipt.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_WareReceipt.Type = tbl_Trans_Parent.Parent WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Trans_Parent.Parent_Name LIKE N'%" + txtSearch.Text + "%' UNION SELECT tbl_Header_TurnTransfer.ID, tbl_Account.Description, tbl_Header_TurnTransfer.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_TurnTransfer.Validation, tbl_Header_TurnTransfer.Type FROM tbl_Header_TurnTransfer INNER JOIN tbl_Account ON tbl_Header_TurnTransfer.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_TurnTransfer.Type = tbl_Trans_Parent.Parent WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Trans_Parent.Parent_Name LIKE N'%" + txtSearch.Text + "%' UNION SELECT tbl_Header_TurnReceipt.ID, tbl_Account.Description, tbl_Header_TurnReceipt.Date, tbl_Trans_Parent.Parent_Name, tbl_Header_TurnReceipt.Validation, tbl_Header_TurnReceipt.Type FROM tbl_Header_TurnReceipt INNER JOIN tbl_Account ON tbl_Header_TurnReceipt.Code = tbl_Account.Code INNER JOIN tbl_Trans_Parent ON tbl_Header_TurnReceipt.Type = tbl_Trans_Parent.Parent WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_Trans_Parent.Parent_Name LIKE N'%" + txtSearch.Text + "%'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore.DataSource = dt;
                lblCounter.Text = dgvStore.Rows.Count.ToString();
            }
            catch
            {
            }
        }
    }
}
