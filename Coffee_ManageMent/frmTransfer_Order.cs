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
    public partial class frmTransfer_Order : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, Store_Code1;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                try
                {
                    if (dgvStore.CurrentCell.ColumnIndex == 0)
                    {
                        Get_Product();
                        Calculate_TotalRow();
                        Calculate_All_Entity();
                    }
                    if (dgvStore.CurrentCell.ColumnIndex == 2 || dgvStore.CurrentCell.ColumnIndex == 4 || dgvStore.CurrentCell.ColumnIndex == 5)
                    {
                        Calculate_TotalRow();
                        Calculate_All_Entity();
                    }
                    SendKeys.Send("{tab}");
                    return true;
                }
                catch
                {
                }
            }
            if (keyData == Keys.Delete)
            {
                mnuDelete_Click(null, null);
                Calculate_All();
                Calculate_All_Entity();
            }
            if (this.ActiveControl.GetType() != typeof(DevComponents.DotNetBar.Controls.ComboBoxEx))
            {
                if (keyData == Keys.F12)
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
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Get_Product()
        {
            dgvStore.EndEdit();
            try
            {
                int P_ID = Convert.ToInt32(dgvStore.CurrentCell.Value);
                SqlDataAdapter da = new SqlDataAdapter("SELECT Buy_Price, P_Show_Name FROM tbl_Product WHERE P_Code='" + P_ID + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore["P_Name", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[1].ToString();
                dgvStore["Buy_Price", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[0].ToString();
                dgvStore["Entity", dgvStore.CurrentRow.Index].Value = "1";
                int Counter = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) == P_ID)
                    {
                        Counter++;
                    }
                }
                if (Counter > 1)
                {
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "از این کالا در استفاده شده است. برای تغییر مقدار به ستون مورد نظر مراجعه نمایید";
                    f.flag = 0;
                    f.ShowDialog();
                    mnuDelete_Click(null, null);
                }
                return;
            }
            catch
            {
                try
                {
                    frmAllProduct f = new frmAllProduct();
                    f.op = "All";
                    f.Fill_All_Product();
                    f.txtSearch.Text = dgvStore["Code", dgvStore.CurrentRow.Index].Value.ToString();
                    f.ShowDialog();
                    dgvStore["Code", dgvStore.CurrentRow.Index].Value = null;
                    dgvStore["Code", dgvStore.CurrentRow.Index].Value = f.Product_Code;
                    Get_Product();
                }
                catch
                {
                }
            }
        }
        public void Calculate_TotalRow()
        {
            try
            {
                dgvStore.EndEdit();
                float Count = float.Parse(dgvStore["Entity", dgvStore.CurrentRow.Index].Value.ToString());
                int Price = Convert.ToInt32(dgvStore["Buy_Price", dgvStore.CurrentRow.Index].Value);
                int Total = Convert.ToInt32(Count * Price);
                dgvStore["Cost", dgvStore.CurrentRow.Index].Value = Total;
                Calculate_All();
            }
            catch
            {
                dgvStore["Cost", dgvStore.CurrentRow.Index].Value = "0";
            }
        }
        public void Calculate_All()
        {
            try
            {
                int T = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    object v = dgvStore["Cost", i].Value;
                    if (v != null)
                    {
                        T += Convert.ToInt32(v);
                    }
                }
                txtSum.Text = T.ToString();

            }
            catch
            {
                txtSum.Text = "0";
            }
        }
        public void Calculate_All_Entity()
        {
            try
            {
                float T = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    object v = dgvStore["Entity", i].Value;
                    if (v != null)
                    {
                        T += Convert.ToInt32(v);
                    }
                }
                txtEntity.Text = T.ToString();
            }
            catch
            {
                txtEntity.Text = "0";
            }
        }
        private void Fill_Store()
        {
            try
            {
                cmbW_Destination.Items.Clear();
                cmbW_Origin.Items.Clear();
                string Query = "SELECT Shown_Name FROM tbl_Store";
                string s_obj = "Shown_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbW_Origin, s_obj);
                clsFunction.FillComboBox(dataconnection, Query, cmbW_Destination, s_obj);
                cmbW_Origin.SelectedIndex = 0;
                cmbW_Destination.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Store FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbW_Origin.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public void Form_Load()
        {
            Fill_Store();
            txtTransferee.Text = txtNotice.Text = "";
            txtEntity.Text = txtSum.Text = "0";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string query2 = "SELECT MAX (ID) FROM tbl_Header_TransferOrder";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "1");
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT W_Origin, W_Destination, Date, Tranferee, Notice, SUM FROM tbl_Header_TransferOrder WHERE ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            cmbW_Origin.Text = dt.Rows[0].ItemArray[0].ToString();
            cmbW_Destination.Text = dt.Rows[0].ItemArray[1].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[2].ToString();
            txtTransferee.Text = dt.Rows[0].ItemArray[3].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[4].ToString();
            txtSum.Text = dt.Rows[0].ItemArray[5].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_TransferOrder.P_Code, tbl_Product.P_Show_Name, tbl_Body_TransferOrder.Entity, tbl_Body_TransferOrder.P_Entity, tbl_Body_TransferOrder.Cost FROM tbl_Body_TransferOrder INNER JOIN tbl_Product ON tbl_Body_TransferOrder.P_Code = tbl_Product.P_Code WHERE tbl_Body_TransferOrder.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
            Calculate_All_Entity();
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_TransferOrder WHERE ID = '" + ID + "'";
                string query2 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=15 AND Parent_Code = '" + Convert.ToInt32(txtID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                {
                }
            }
            catch
            {
            }
        }
        public frmTransfer_Order()
        {
            InitializeComponent();
        }

        private void frmTransfer_Order_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.RemoveAt(dgvStore.CurrentRow.Index);
                Calculate_All();
                Calculate_All_Entity();
            }
            catch
            {
            }
        }

        private void mnuDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.Clear();
                Calculate_All();
                Calculate_All_Entity();
            }
            catch
            {
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string query1, query2, query3, query4;
            if (cmbW_Origin.Text == cmbW_Destination.Text)
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "انبار مبدا و انبار مقصد نباید یکسان باشند";
                f.ShowDialog();
            }
            else
            {
                DateTime d1 = Convert.ToDateTime(txtDate.Text);
                DateTime d2 = Convert.ToDateTime(clsFunction.M2SH(DateTime.Now));
                if (d1 > d2)
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = "تاریخ حواله انتقالی نمی تواند از تاریخ روز بزرگتر باشد";
                    f.ShowDialog();
                }
                else
                {
                    if (op == "Add")
                    {
                        query1 = "INSERT INTO tbl_Header_TransferOrder (ID, W_Origin, W_Destination, Date, Tranferee, Notice, SUM, Type) VALUES ('" + Convert.ToInt64(txtID.Text) + "',N'" + cmbW_Origin.Text + "',N'" + cmbW_Destination.Text + "','" + txtDate.Text + "',N'" + txtTransferee.Text + "',N'" + txtNotice.Text + "','" + Convert.ToInt64(txtSum.Text) + "',15)";
                        if (clsFunction.Execute(dataconnection, query1) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query4 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbW_Destination.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + txtNotice.Text + "',15,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code1 + "')";
                                    query3 = "INSERT INTO tbl_Body_TransferOrder (ID, P_Code, Entity, P_Entity, Cost) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                            for (int j = 0; j < dgvStore.Rows.Count; j++)
                            {
                                try
                                {
                                    query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[j].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbW_Origin.Text + "','" + float.Parse(dgvStore.Rows[j].Cells["Entity"].Value.ToString()) + "',N'" + txtNotice.Text + "',15,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                            this.Close();
                        }
                    }
                    else if (op == "Edit")
                    {
                        Delete_Data(Convert.ToInt32(txtID.Text));
                        query1 = "UPDATE tbl_Header_TransferOrder SET W_Origin = '" + cmbW_Origin.Text + "', W_Destination = '" + cmbW_Destination.Text + "', Date = '" + txtDate.Text + "', Tranferee = N'" + txtTransferee.Text + "', Notice = N'" + txtNotice.Text + "', SUM = '" + Convert.ToInt64(txtSum.Text) + "' WHERE ID = '" + Convert.ToInt32(txtID.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query1) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query4 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbW_Destination.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + txtNotice.Text + "',15,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code1 + "')";
                                    query3 = "INSERT INTO tbl_Body_TransferOrder (ID, P_Code, Entity, P_Entity, Cost) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                            for (int j = 0; j < dgvStore.Rows.Count; j++)
                            {
                                try
                                {
                                    query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[j].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbW_Origin.Text + "','" + float.Parse(dgvStore.Rows[j].Cells["Entity"].Value.ToString()) + "',N'" + txtNotice.Text + "',15,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                    if (clsFunction.Execute(dataconnection, query2) == true)
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                            this.Close();
                        }
                    }
                }
            }
        }

        private void cmbW_Origin_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Store WHERE Shown_Name LIKE N'" + cmbW_Origin.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Store_Code1 = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void cmbW_Destination_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Store WHERE Shown_Name LIKE N'" + cmbW_Destination.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Store_Code = (string)dr["Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
        }

        private void dgvStore_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvStore_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvStore.CurrentRow.Cells["Code"].Value != null)
            {
                if (dgvStore.CurrentRow.Cells["Entity"].Value == null)
                {
                    Get_Product();
                }
            }
        }

        private void cmbW_Origin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbW_Destination.Focus();
            else if (e.KeyData == Keys.F12)
            {
                try
                {
                    frmStores f = new frmStores();
                    f.Form_Load();
                    f.op = "Add";
                    f.ShowDialog();
                    Fill_Store();
                }
                catch
                {
                }
            }
        }

        private void cmbW_Destination_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTransferee.Focus();
            else if (e.KeyData == Keys.F12)
            {
                try
                {
                    frmStores f = new frmStores();
                    f.Form_Load();
                    f.op = "Add";
                    f.ShowDialog();
                    Fill_Store();
                }
                catch
                {
                }
            }
        }

        private void txtTransferee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDate.Focus();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void mnuTour_Click(object sender, EventArgs e)
        {
            try
            {
                frmLittle_Tour f = new frmLittle_Tour();
                f.Form_Load();
                f.Fill_Data(Convert.ToInt32(dgvStore.CurrentRow.Cells["Code"].Value.ToString()));
                f.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
