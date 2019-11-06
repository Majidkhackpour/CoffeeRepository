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
    public partial class frmProduct_Price : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        TextBox txt;
        string Query;
        public void Fill_Buy_Price()
        {
            string Query = "SELECT tbl_Price_List.P_Code, tbl_Product.P_Show_Name, tbl_Price_List.Buy_Price FROM tbl_Price_List INNER JOIN tbl_Product ON tbl_Price_List.P_Code = tbl_Product.P_Code WHERE tbl_Price_List.Pattern_Code LIKE N'" + lblPattern_Code.Text + "' ORDER BY tbl_Price_List.P_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
        }
        public void Fill_Sell_Price()
        {
            string Query = "SELECT tbl_Price_List.P_Code, tbl_Product.P_Show_Name, tbl_Price_List.Sell_Price FROM tbl_Price_List INNER JOIN tbl_Product ON tbl_Price_List.P_Code = tbl_Product.P_Code WHERE tbl_Price_List.Pattern_Code LIKE N'" + lblPattern_Code.Text + "' ORDER BY tbl_Price_List.P_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
        }
        private void txt1_TextChanged(object sender, EventArgs e)
        {
            txt.Text = txt.Text.Replace(".", "000");
            txt.SelectionStart = txt.Text.Length;
        }
        private void txt1_Enter(object sender, EventArgs e)
        {
            txt.ReadOnly = true;
        }
        public frmProduct_Price()
        {
            InitializeComponent();
        }

        private void frmProduct_Price_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            btnFinish.Enabled = false;
            mnuEdit.Enabled = true;
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

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = true;
            mnuEdit.Enabled = false;
            dgvProduct.AllowUserToAddRows = true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            mnuEdit.Enabled = true;
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.ReadOnly = true;
            if (dgvProduct.Columns["Sell_Price"].Visible == false)
            {
                //Buy
                for (int i = 0; i < dgvProduct.Rows.Count; i++)
                {
                    try
                    {
                        string query = "UPDATE tbl_Price_List SET Buy_Price = '" + Convert.ToInt64(dgvProduct.Rows[i].Cells["Buy_Price"].Value.ToString()) + "' WHERE P_Code = '" + Convert.ToInt32(dgvProduct.Rows[i].Cells["P_Code"].Value.ToString()) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                        string query2 = "UPDATE tbl_Product SET Buy_Price = '" + Convert.ToInt64(dgvProduct.Rows[i].Cells["Buy_Price"].Value.ToString()) + "' WHERE P_Code = '" + Convert.ToInt32(dgvProduct.Rows[i].Cells["P_Code"].Value.ToString()) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                        }
                    }
                    catch
                    {
                    }
                }
                btnFinish.Enabled = false;
                mnuEdit.Enabled = true;
                dgvProduct.AllowUserToAddRows = false;
                dgvProduct.ReadOnly = true;
                Fill_Buy_Price();
            }
            else if (dgvProduct.Columns["Buy_Price"].Visible == false)
            {
                //Sell
                for (int i = 0; i < dgvProduct.Rows.Count; i++)
                {
                    try
                    {
                        string query = "UPDATE tbl_Price_List SET Sell_Price = '" + Convert.ToInt64(dgvProduct.Rows[i].Cells["Sell_Price"].Value.ToString()) + "' WHERE P_Code = '" + Convert.ToInt32(dgvProduct.Rows[i].Cells["P_Code"].Value.ToString()) + "' AND Pattern_Code = '" + lblPattern_Code.Text + "'";
                        string query2 = "UPDATE tbl_Product SET Sell_Price = '" + Convert.ToInt64(dgvProduct.Rows[i].Cells["Sell_Price"].Value.ToString()) + "' WHERE P_Code = '" + Convert.ToInt32(dgvProduct.Rows[i].Cells["P_Code"].Value.ToString()) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                        }
                    }
                    catch
                    {
                    }
                }
                btnFinish.Enabled = false;
                mnuEdit.Enabled = true;
                dgvProduct.AllowUserToAddRows = false;
                dgvProduct.ReadOnly = true;
                Fill_Sell_Price();
            }
        }

        private void dgvProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvProduct.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void dgvProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != '\b')
                    e.Handled = true;
            }
        }

        private void dgvProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            txt = e.Control as TextBox;
            if (dgvProduct.CurrentCell.ColumnIndex == dgvProduct.Columns[0].Index || dgvProduct.CurrentCell.ColumnIndex == dgvProduct.Columns[1].Index || dgvProduct.CurrentCell.ColumnIndex == dgvProduct.Columns[2].Index)
            {
                txt.TextChanged += new EventHandler(txt1_Enter);
            }
            else if (dgvProduct.CurrentCell.ColumnIndex == dgvProduct.Columns[3].Index || dgvProduct.CurrentCell.ColumnIndex == dgvProduct.Columns[4].Index)
            {
                txt.TextChanged += new EventHandler(txt1_TextChanged);
            }
        }

        private void mnuAutomatic_Click(object sender, EventArgs e)
        {
            frmAuto_Price f = new frmAuto_Price();
            f.Form_Load();
            f.lblPattern_Code.Text = lblPattern_Code.Text;
            f.lblPattern_Name.Text = lblPattern_Name.Text;
            if (dgvProduct.Columns["Sell_Price"].Visible == false)
            {
                //Buy
                f.op = "Buy";
                f.groupPanel5.Enabled = false;
            }
            else if (dgvProduct.Columns["Buy_Price"].Visible == false)
            {
                //Sell
                f.op = "Sell";
            }
            f.ShowDialog();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Columns["Sell_Price"].Visible == false)
            {
                //Buy
                Fill_Buy_Price();
            }
            else if (dgvProduct.Columns["Buy_Price"].Visible == false)
            {
                //Sell
                Fill_Sell_Price();
            }
        }

        private void mnuRefresh_Click_1(object sender, EventArgs e)
        {
            if (dgvProduct.Columns["Sell_Price"].Visible == false)
            {
                //Buy
                Fill_Buy_Price();
            }
            else if (dgvProduct.Columns["Buy_Price"].Visible == false)
            {
                //Sell
                Fill_Sell_Price();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvProduct.Columns["Sell_Price"].Visible == false)
            {
                //Buy
                Query = "SELECT tbl_Price_List.P_Code, tbl_Product.P_Show_Name, tbl_Price_List.Buy_Price FROM tbl_Price_List INNER JOIN tbl_Product ON tbl_Price_List.P_Code = tbl_Product.P_Code WHERE tbl_Price_List.Pattern_Code LIKE N'" + lblPattern_Code.Text + "' AND tbl_Product.P_Show_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Price_List.P_Code ASC";
            }
            else if (dgvProduct.Columns["Buy_Price"].Visible == false)
            {
                //Sell
                Query = "SELECT tbl_Price_List.P_Code, tbl_Product.P_Show_Name, tbl_Price_List.Sell_Price FROM tbl_Price_List INNER JOIN tbl_Product ON tbl_Price_List.P_Code = tbl_Product.P_Code WHERE tbl_Price_List.Pattern_Code LIKE N'" + lblPattern_Code.Text + "' AND tbl_Product.P_Show_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Price_List.P_Code ASC";
            }
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
        }
    }
}
