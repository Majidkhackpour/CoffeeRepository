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
    public partial class frmAdjusted : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code;
        int Type_Code;
        string query1, query2, query3;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                try
                {
                    if (dgvStore.CurrentCell.ColumnIndex == 0)
                    {
                        Get_Product();
                        Calculate_INC();
                        Calculate_DEC();
                    }
                    if (dgvStore.CurrentCell.ColumnIndex == 2 || dgvStore.CurrentCell.ColumnIndex == 3)
                    {
                        Inc_OR_Dec();
                        Calculate_INC();
                        Calculate_DEC();
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
                Calculate_INC();
                Calculate_DEC();
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT P_Show_Name FROM tbl_Product WHERE P_Code='" + P_ID + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore["P_Name", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[0].ToString();
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
                    f.lblMessage.Text = "از این کالا استفاده شده است. برای تغییر مقدار به ستون مورد نظر مراجعه نمایید";
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
        public void Calculate_INC()
        {
            try
            {
                int T = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    object v = dgvStore["Inc", i].Value;
                    if (v != null)
                    {
                        T += Convert.ToInt32(v);
                    }
                }
                txtIncriment.Text = T.ToString();
            }
            catch
            {
                txtIncriment.Text = "0";
            }
        }
        public void Calculate_DEC()
        {
            try
            {
                float T = 0;
                for (int i = 0; i < dgvStore.Rows.Count; i++)
                {
                    object v = dgvStore["Dec", i].Value;
                    if (v != null)
                    {
                        T += Convert.ToInt32(v);
                    }
                }
                txtDecriment.Text = T.ToString();
            }
            catch
            {
                txtDecriment.Text = "0";
            }
        }
        private void Inc_OR_Dec()
        {
            try
            {
                if (dgvStore.CurrentRow.Cells["Dec"].Value != null)
                {
                    dgvStore.CurrentRow.Cells["Inc"].Value = null;
                }
                if (dgvStore.CurrentRow.Cells["Inc"].Value != null)
                {
                    dgvStore.CurrentRow.Cells["Dec"].Value = null;
                }
            }
            catch
            {
            }
        }
        private void Fill_Store()
        {
            try
            {
                cmbStore.Items.Clear();
                string Query = "SELECT Shown_Name FROM tbl_Store";
                string s_obj = "Shown_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbStore, s_obj);
                cmbStore.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Store FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStore.Text = dt.Rows[0].ItemArray[0].ToString();
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
            txtNotice.Text = "";
            txtIncriment.Text = txtDecriment.Text = "0";
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string query2 = "SELECT MAX (ID) FROM tbl_Header_Adjusted";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "1");
            cmbAd_Type.Items.Clear();
            string Query = "SELECT Type_Name FROM tbl_Adjusted_Type";
            string s_obj = "Type_Name";
            clsFunction.FillComboBox(dataconnection, Query, cmbAd_Type, s_obj);
            cmbAd_Type.SelectedIndex = 0;
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Ad_Type, Date, Notice FROM tbl_Header_Adjusted WHERE ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            cmbAd_Type.SelectedIndex = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            txtDate.Text = dt.Rows[0].ItemArray[1].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[2].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_Adjusted.P_Code, tbl_Product.P_Show_Name, tbl_Body_Adjusted.Dec, tbl_Body_Adjusted.Inc FROM tbl_Body_Adjusted INNER JOIN tbl_Product ON tbl_Body_Adjusted.P_Code = tbl_Product.P_Code WHERE tbl_Body_Adjusted.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
            Calculate_DEC();
            Calculate_INC();
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Adjusted WHERE ID = '" + ID + "'";
                string query2 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=16 AND Parent_Code = '" + Convert.ToInt32(txtID.Text) + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                {
                }
            }
            catch
            {
            }
        }
        public frmAdjusted()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdjusted_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.RemoveAt(dgvStore.CurrentRow.Index);
                Calculate_DEC();
                Calculate_INC();
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
                Calculate_DEC();
                Calculate_INC();
            }
            catch
            {
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(txtDate.Text);
            DateTime d2 = Convert.ToDateTime(clsFunction.M2SH(DateTime.Now));
            if (d1 > d2)
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "تاریخ تعدیل نمی تواند از تاریخ روز بزرگتر باشد";
                f.ShowDialog();
            }
            else
            {
                if (op == "Add")
                {
                    query1 = "INSERT INTO tbl_Header_Adjusted (ID, Ad_Type, Date, Notice, Store, Type) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Type_Code + "','" + txtDate.Text + "',N'" + txtNotice.Text + "','" + Store_Code + "',16)";
                    if (clsFunction.Execute(dataconnection, query1) == true)
                    {
                        for (int i = 0; i < dgvStore.Rows.Count; i++)
                        {
                            try
                            {
                                if (dgvStore.Rows[i].Cells["Dec"].Value == null)
                                {
                                    query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbAd_Type.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Inc"].Value.ToString()) + "',N'" + txtNotice.Text + "',16,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                    query3 = "INSERT INTO tbl_Body_Adjusted (ID, P_Code, Inc) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Inc"].Value.ToString()) + "')";
                                }
                                else if (dgvStore.Rows[i].Cells["Inc"].Value == null)
                                {
                                    query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbAd_Type.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Dec"].Value.ToString()) + "',N'" + txtNotice.Text + "',16,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                    query3 = "INSERT INTO tbl_Body_Adjusted (ID, P_Code, Dec) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Dec"].Value.ToString()) + "')";
                                }
                                if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query2) == true)
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
                    query1 = "UPDATE tbl_Header_Adjusted SET Ad_Type = '" + Type_Code + "', Date = '" + txtDate.Text + "', Notice = N'" + txtNotice.Text + "', Store = '" + Store_Code + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "'";
                    if (clsFunction.Execute(dataconnection, query1) == true)
                    {
                        for (int i = 0; i < dgvStore.Rows.Count; i++)
                        {
                            try
                            {
                                if (dgvStore.Rows[i].Cells["Dec"].Value.ToString()!="")
                                {
                                    query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbAd_Type.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Dec"].Value.ToString()) + "',N'" + txtNotice.Text + "',16,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                    query3 = "INSERT INTO tbl_Body_Adjusted (ID, P_Code, Dec) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Dec"].Value.ToString()) + "')";
                                }
                                else if (dgvStore.Rows[i].Cells["Inc"].Value.ToString()!="")
                                {
                                    query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Origin, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + cmbAd_Type.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Inc"].Value.ToString()) + "',N'" + txtNotice.Text + "',16,'" + Convert.ToInt32(txtID.Text) + "','" + Store_Code + "')";
                                    query3 = "INSERT INTO tbl_Body_Adjusted (ID, P_Code, Inc) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Inc"].Value.ToString()) + "')";
                                }
                                if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query2) == true)
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

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Store WHERE Shown_Name LIKE N'" + cmbStore.Text + "'", dataconnection);
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

        private void cmbAd_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type FROM tbl_Adjusted_Type WHERE Type_Name LIKE N'" + cmbAd_Type.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Type_Code = (int)dr["Type"];
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

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbAd_Type.Focus();
        }

        private void cmbAd_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbStore.Focus();
        }

        private void cmbStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
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
