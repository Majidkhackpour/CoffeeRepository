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
    public partial class frmAllProduct : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string Product_Code, op, Query;
        public void Fill_All_Product()
        {
            string Query = "SELECT tbl_Product.P_Code, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Product.Store, tbl_Store.Type FROM tbl_Product INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Product.Store = tbl_Store.Code ORDER BY tbl_Product.P_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public void Fill_First_Only_Product()
        {
            string Query = "SELECT tbl_Product.P_Code, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Product.Store, tbl_Store.Type FROM tbl_Product INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Product.Store = tbl_Store.Code WHERE tbl_Store.Type=4 ORDER BY tbl_Product.P_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
        }
        public frmAllProduct()
        {
            InitializeComponent();
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccount.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void dgvAccount_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Product_Code = dgvAccount.CurrentRow.Cells["P_Code"].Value.ToString();
            }
            catch
            {
                Product_Code = null;
            }
        }

        private void frmAllProduct_Load(object sender, EventArgs e)
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

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmProduct f = new frmProduct();
                f.op = "Add";
                f.Flag = 0;
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
                if (op == "All")
                {
                    Query = "SELECT tbl_Product.P_Code, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Product.Store, tbl_Store.Type FROM tbl_Product INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Product.Store = tbl_Store.Code WHERE tbl_Product.P_Show_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Product.P_Code ASC";
                }
                else if (op == "First_Only")
                {
                    Query = "SELECT tbl_Product.P_Code, tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Product.Store, tbl_Store.Type FROM tbl_Product INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Product.Store = tbl_Store.Code WHERE tbl_Store.Type=4 AND tbl_Product.P_Show_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Product.P_Code ASC";
                }
                clsFunction.Display(Query, dataconnection, dgvAccount, lblCounter);
            }
            catch
            {
            }
        }

        private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    Product_Code = dgvAccount.CurrentRow.Cells["P_Code"].Value.ToString();
                }
                catch
                {
                    Product_Code = null;
                }
                finally
                {
                    this.Close();
                }
            }
        }
    }
}
