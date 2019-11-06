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
    public partial class frmShow_Personnel_Log : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op;
        public int Per_Id;
        public void Show_All()
        {
            string query = "SELECT tbl_Account.Description, tbl_LogPerssonel.Per_ID, tbl_LogPerssonel.Guid, tbl_LogPerssonel.Year, tbl_LogPerssonel.Mounth, tbl_LogPerssonel.Day, tbl_Log_Per_Type.Type_Name, tbl_LogPerssonel.Hour, tbl_LogPerssonel.Min, tbl_LogPerssonel.Ez_Hour, tbl_LogPerssonel.Ez_Min, tbl_LogPerssonel.Kasr_Hour, tbl_LogPerssonel.Kasr_Min, tbl_LogPerssonel.Hoz_Hour, tbl_LogPerssonel.Hoz_Min FROM tbl_LogPerssonel INNER JOIN tbl_Perssonel ON tbl_LogPerssonel.Per_ID = tbl_Perssonel.ID INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Log_Per_Type ON tbl_LogPerssonel.Type = tbl_Log_Per_Type.Type ORDER BY tbl_LogPerssonel.Day DESC";
            clsFunction.Display(query, dataconnection, dgvStore, lblCounter);
        }
        public void Show_One(int ID)
        {
            string query = "SELECT tbl_Account.Description, tbl_LogPerssonel.Per_ID, tbl_LogPerssonel.Guid, tbl_LogPerssonel.Year, tbl_LogPerssonel.Mounth, tbl_LogPerssonel.Day, tbl_Log_Per_Type.Type_Name, tbl_LogPerssonel.Hour, tbl_LogPerssonel.Min, tbl_LogPerssonel.Ez_Hour, tbl_LogPerssonel.Ez_Min, tbl_LogPerssonel.Kasr_Hour, tbl_LogPerssonel.Kasr_Min, tbl_LogPerssonel.Hoz_Hour, tbl_LogPerssonel.Hoz_Min FROM tbl_LogPerssonel INNER JOIN tbl_Perssonel ON tbl_LogPerssonel.Per_ID = tbl_Perssonel.ID INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Log_Per_Type ON tbl_LogPerssonel.Type = tbl_Log_Per_Type.Type WHERE tbl_LogPerssonel.Per_ID='" + ID + "' ORDER BY tbl_LogPerssonel.Day DESC";
            clsFunction.Display(query, dataconnection, dgvStore, lblCounter);
        }
        public frmShow_Personnel_Log()
        {
            InitializeComponent();
        }

        private void frmShow_Personnel_Log_Load(object sender, EventArgs e)
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

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (op == "All")
                {
                    string query = "SELECT tbl_Account.Description, tbl_LogPerssonel.Per_ID, tbl_LogPerssonel.Guid, tbl_LogPerssonel.Year, tbl_LogPerssonel.Mounth, tbl_LogPerssonel.Day, tbl_Log_Per_Type.Type_Name, tbl_LogPerssonel.Hour, tbl_LogPerssonel.Min, tbl_LogPerssonel.Ez_Hour, tbl_LogPerssonel.Ez_Min, tbl_LogPerssonel.Kasr_Hour, tbl_LogPerssonel.Kasr_Min, tbl_LogPerssonel.Hoz_Hour, tbl_LogPerssonel.Hoz_Min FROM tbl_LogPerssonel INNER JOIN tbl_Perssonel ON tbl_LogPerssonel.Per_ID = tbl_Perssonel.ID INNER JOIN tbl_Account ON tbl_Perssonel.Code = tbl_Account.Code INNER JOIN tbl_Log_Per_Type ON tbl_LogPerssonel.Type = tbl_Log_Per_Type.Type WHERE tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_LogPerssonel.Day DESC";
                    clsFunction.Display(query, dataconnection, dgvStore, lblCounter);
                }
            }
            catch
            {
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query2 = "DELETE FROM tbl_LogPerssonel WHERE Guid = '" + dgvStore.CurrentRow.Cells["Guid"].Value + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف تردد اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query2) == true)
                    {
                        if (op == "All")
                            Show_All();
                        else if (op == "One")
                            Show_One(Per_Id);
                    }
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تردد انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmPer_Log_Aouth f = new frmPer_Log_Aouth();
                f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["Per_ID"].Value));
                f.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
