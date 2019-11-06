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
    public partial class frmWeb_History : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string URL;
        public frmWeb_History()
        {
            InitializeComponent();
        }

        private void frmWeb_History_Load(object sender, EventArgs e)
        {
            string Query = "SELECT ID, Link, Date, Time FROM tbl_Web_History ORDER BY Date DESC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
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

        private void dgvStore_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStore_Click(object sender, EventArgs e)
        {
            try
            {
                URL = dgvStore.CurrentRow.Cells["Link"].Value.ToString();
            }
            catch
            {
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Web_History WHERE ID='" + Convert.ToInt32(dgvStore.CurrentRow.Cells["ID"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف این صفحه اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmWeb_History_Load(null, null);
                }
            }
            catch
            {
            }
        }

        private void mnuDel_All_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Web_History";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف تمام صفحه اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmWeb_History_Load(null, null);
                }
            }
            catch
            {
            }
        }
    }
}
