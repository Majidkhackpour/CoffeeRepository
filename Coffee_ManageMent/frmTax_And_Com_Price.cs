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
    public partial class frmTax_And_Com_Price : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        TextBox txt;
        private void txt1_TextChanged(object sender, EventArgs e)
        {
            txt.Text = txt.Text.Replace(".", "000");
            txt.SelectionStart = txt.Text.Length;
        }
        private void txt1_Enter(object sender, EventArgs e)
        {
            txt.ReadOnly = true;
        }
        public frmTax_And_Com_Price()
        {
            InitializeComponent();
        }

        private void frmTax_And_Com_Price_Load(object sender, EventArgs e)
        {
            string Query = "SELECT P_Code, P_Show_Name, Tax_Price, Complication_Price FROM tbl_Product ORDER BY P_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            btnFinish.Enabled = false;
            mnuEdit.Enabled = true;
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

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = true;
            mnuEdit.Enabled = false;
            dgvProduct.AllowUserToAddRows = true;
            dgvProduct.ReadOnly = false;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvProduct.Rows.Count; i++)
            {
                try
                {
                    string Tax = dgvProduct.Rows[i].Cells["Tax_Price"].Value.ToString();
                    string Complication = dgvProduct.Rows[i].Cells["Complication_Price"].Value.ToString();
                    if (Tax == null)
                        Tax = "0";
                    if (Complication == null)
                        Complication = "0";
                    string query = "UPDATE tbl_Product SET Tax_Price = '" + Convert.ToInt32(Tax) + "', Complication_Price='" + Convert.ToInt32(Complication) + "' WHERE P_Code = '" + Convert.ToInt32(dgvProduct.Rows[i].Cells["P_Code"].Value) + "'";
                    if (clsFunction.Execute(dataconnection, query) == true)
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
            mnuRefresh_Click(null, null);
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

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            string Query = "SELECT P_Code, P_Show_Name, Tax_Price, Complication_Price FROM tbl_Product ORDER BY P_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
        }

        private void mnuAutomatic_Click(object sender, EventArgs e)
        {
            try
            {
                frmAuto_Tax_Com_Price f = new frmAuto_Tax_Com_Price();
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT P_Code, P_Show_Name, Tax_Price, Complication_Price FROM tbl_Product WHERE P_Show_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY P_Code ASC";
                clsFunction.Display(Query, dataconnection, dgvProduct, lblCounter);
            }
            catch
            {
            }
        }
    }
}
