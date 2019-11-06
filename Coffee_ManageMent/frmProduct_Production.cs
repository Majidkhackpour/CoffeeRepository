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
    public partial class frmProduct_Production : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, First_Store;
        int Product_Type, P_Code, Formule_ID;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                try
                {
                    if (dgvStore.CurrentCell.ColumnIndex == 1)
                    {
                        Get_Product();
                        Calculate_TotalRow();
                    }
                    if (dgvStore.CurrentCell.ColumnIndex == 3 || dgvStore.CurrentCell.ColumnIndex == 4)
                        Calculate_TotalRow();
                    SendKeys.Send("{tab}");
                    return true;
                }
                catch
                {
                }
            }
            if (keyData == Keys.Delete)
                mnuDelete_Click(null, null);
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
                    f.lblMessage.Text = "از این کالا در فرمول تولید استفاده شده است. برای تغییر مقدار به ستون مورد نظر مراجعه نمایید";
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
                    f.op = "First_Only";
                    f.Fill_First_Only_Product();
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
                txtPrd_Cost.Text = T.ToString();
            }
            catch
            {
                txtPrd_Cost.Text = "0";
            }
        }
        public void Form_Load()
        {
            string query2 = "SELECT MAX (ID) FROM tbl_Header_Product_Production";
            clsFunction.txt_NewCode(dataconnection, query2, txtCode, "1");
            TabControl.SelectedTab = superTabItem1;
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            txtBuy_Price_Formule.Text = txtBuy_Price_Prd.Text = "0";
            txtEntity_Formule.Text = txtEntity_Prd.Text = "1";
            txtFix_Cost.Text = txtP_Cost.Text = txtPrd_Cost.Text = txtVar_Cost.Text = txtWage.Text = "0";
            txtNotice.Text = "";
            Fill_Store();
            Fill_Product_Type();
            Fill_Product();
            Fill_Product_Production();
            Fill_Formule();
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Product.P_Show_Name, tbl_Header_Product_Production.Entity, tbl_Header_Product_Production.Ins_Date, tbl_Header_Product_Production.Wage_Price, tbl_Header_Product_Production.Fixed_Price,  tbl_Header_Product_Production.Var_Price, tbl_Header_Product_Production.Total_Price, tbl_Header_Product_Production.Notice FROM tbl_Header_Product_Production INNER JOIN tbl_Product ON tbl_Header_Product_Production.P_Code = tbl_Product.P_Code WHERE tbl_Header_Product_Production.ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = ID.ToString();
            cmbProduct_Formule.Text = dt.Rows[0].ItemArray[0].ToString();
            txtEntity_Prd.Text = dt.Rows[0].ItemArray[1].ToString();
            txtDate.Text = dt.Rows[0].ItemArray[2].ToString();
            txtWage.Text = dt.Rows[0].ItemArray[3].ToString();
            txtFix_Cost.Text = dt.Rows[0].ItemArray[4].ToString();
            txtVar_Cost.Text = dt.Rows[0].ItemArray[5].ToString();
            txtP_Cost.Text = dt.Rows[0].ItemArray[6].ToString();
            txtNotice.Text = dt.Rows[0].ItemArray[7].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_Product_Production.P_Code, tbl_Product.P_Show_Name, tbl_Body_Product_Production.Entity, tbl_Body_Product_Production.Price, tbl_Body_Product_Production.Entity * tbl_Body_Product_Production.Price AS Expr1 FROM tbl_Body_Product_Production INNER JOIN tbl_Product ON tbl_Body_Product_Production.P_Code = tbl_Product.P_Code WHERE tbl_Body_Product_Production.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
            Calculate_All();
        }
        private void Get_Store_Code()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM tbl_Store WHERE Type=4", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                First_Store = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                First_Store = null;
            }
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Product_Production WHERE ID = '" + ID + "'";
                string query2 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=10 AND Parent_Code = '" + ID + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                {
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
        private void Fill_Product_Type()
        {
            try
            {
                cmbType.Items.Clear();
                string Query = "SELECT Description FROM tbl_Product_Type";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbType, s_obj);
                cmbType.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private void Fill_Product()
        {
            try
            {
                cmbProduct_Prd.Items.Clear();
                string Query = "SELECT P_Show_Name FROM tbl_Product WHERE Store LIKE N'" + Store_Code + "' AND Product_Group='" + Product_Type + "'";
                string s_obj = "P_Show_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbProduct_Prd, s_obj);
                cmbProduct_Prd.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private void Fill_Product_Production()
        {
            try
            {
                cmbProduct_Formule.Items.Clear();
                string Query = "SELECT tbl_Product.P_Show_Name FROM tbl_Header_Prd INNER JOIN tbl_Product ON tbl_Header_Prd.P_Code = tbl_Product.P_Code";
                string s_obj = "P_Show_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbProduct_Formule, s_obj);
            }
            catch
            {
            }
        }
        private void Fill_Formule()
        {
            try
            {
                cmbFormule.Items.Clear();
                string Query = "SELECT Prd_Name FROM tbl_Header_Prd WHERE P_Code='" + P_Code + "'";
                string s_obj = "Prd_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbFormule, s_obj);
            }
            catch
            {
            }
        }
        private void Calculate_Cost()
        {
            try
            {
                txtP_Cost.Text = (Convert.ToInt32(txtWage.Text) + Convert.ToInt32(txtFix_Cost.Text) + Convert.ToInt32(txtVar_Cost.Text) + Convert.ToInt32(txtPrd_Cost.Text)).ToString();
            }
            catch
            {
                txtP_Cost.Text = txtPrd_Cost.Text;
            }
        }
        public frmProduct_Production()
        {
            InitializeComponent();
        }

        private void frmProduct_Production_Load(object sender, EventArgs e)
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

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                Fill_Product();
            }
            catch
            {
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataconnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Type_Code FROM tbl_Product_Type WHERE Description LIKE N'" + cmbType.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Product_Type = (int)dr["Type_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                Fill_Product();
            }
            catch
            {
            }
        }

        private void cmbProduct_Prd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvStore.ReadOnly = false;
                dataconnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT P_Code FROM tbl_Product WHERE P_Show_Name LIKE N'" + cmbProduct_Prd.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        P_Code = (int)dr["P_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Buy_Price FROM tbl_Product WHERE P_Code='" + P_Code + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtBuy_Price_Prd.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
            }
        }

        private void cmbProduct_Formule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataconnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT P_Code FROM tbl_Product WHERE P_Show_Name LIKE N'" + cmbProduct_Formule.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        P_Code = (int)dr["P_Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                Fill_Formule();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Buy_Price, Product_Group FROM tbl_Product WHERE P_Code='" + P_Code + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtBuy_Price_Formule.Text = dt.Rows[0].ItemArray[0].ToString();
                cmbType.SelectedIndex = Convert.ToInt32(dt.Rows[0].ItemArray[1]) - 1;
                cmbProduct_Prd.SelectedItem = cmbProduct_Formule.SelectedItem;
            }
            catch
            {
            }
        }

        private void cmbFormule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataconnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID FROM tbl_Header_Prd WHERE Prd_Name LIKE N'" + cmbFormule.Text + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Formule_ID = (int)dr["ID"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Body_Prd.P_Code, tbl_Product.P_Show_Name, tbl_Body_Prd.Entity, tbl_Body_Prd.Price, tbl_Body_Prd.Entity * tbl_Body_Prd.Price AS Expr1 FROM tbl_Body_Prd INNER JOIN tbl_Product ON tbl_Body_Prd.P_Code = tbl_Product.P_Code WHERE tbl_Body_Prd.ID='" + Formule_ID + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore.DataSource = dt;
                Calculate_All();
                dgvStore.ReadOnly = true;
            }
            catch
            {
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.RemoveAt(dgvStore.CurrentRow.Index);
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
            }
            catch
            {
            }
        }

        private void txtWage_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtWage);
            Calculate_Cost();
        }

        private void txtFix_Cost_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtFix_Cost);
            Calculate_Cost();
        }

        private void txtVar_Cost_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtVar_Cost);
            Calculate_Cost();
        }

        private void txtP_Cost_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtP_Cost);
        }

        private void txtPrd_Cost_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.CMB_Error_Provider(cmbStore, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.CMB_Error_Provider(cmbType, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.CMB_Error_Provider(cmbProduct_Prd, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                string query1, query3, query2, query4;
                errorProvider1.Clear();
                if (op == "Add")
                {
                    Get_Store_Code();
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "شماره تولید: " + txtCode.Text + "\n" + "آیا تولید محصول " + cmbProduct_Prd.Text + " " + "به قیمت تمام شده هر عدد " + txtP_Cost.Text + " " + "ریال و به تعداد: " + txtEntity_Prd.Text + " " + "مورد تایید است؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        query1 = "INSERT INTO tbl_Header_Product_Production (ID, P_Code, Entity, Ins_Date, Wage_Price, Fixed_Price, Var_Price, Total_Price, Notice) VALUES ('" + Convert.ToInt64(txtCode.Text) + "','" + P_Code + "','" + float.Parse(txtEntity_Prd.Text) + "','" + txtDate.Text + "','" + Convert.ToInt64(txtWage.Text) + "','" + Convert.ToInt64(txtFix_Cost.Text) + "','" + Convert.ToInt64(txtVar_Cost.Text) + "','" + Convert.ToInt64(txtP_Cost.Text) + "',N'" + txtNotice.Text + "')";
                        query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + P_Code + "','" + txtDate.Text + "','" + float.Parse(txtEntity_Prd.Text) + "',N'" + "تولید شده" + "',10,'" + Convert.ToInt32(txtCode.Text) + "','" + Store_Code + "')";
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query3 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "',N'" + cmbStore.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "مصرف شده بایت تولید " + cmbProduct_Prd.Text + "',10,'" + Convert.ToInt32(txtCode.Text) + "','" + First_Store + "')";
                                    query4 = "INSERT INTO tbl_Body_Product_Production (ID, P_Code, Entity, Price, Total) VALUES ('" + Convert.ToInt64(txtCode.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
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
                else if (op == "Edit")
                {
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "شماره تولید: " + txtCode.Text + "\n" + "آیا تولید محصول " + cmbProduct_Prd.Text + " " + "به قیمت تمام شده هر عدد " + txtP_Cost.Text + " " + "ریال و به تعداد: " + txtEntity_Prd.Text + " " + "مورد تایید است؟";
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        Get_Store_Code();
                        Delete_Data(Convert.ToInt32(txtCode.Text));
                        query1 = "UPDATE tbl_Header_Product_Production SET P_Code = '" + P_Code + "', Entity = '" + float.Parse(txtEntity_Prd.Text) + "', Ins_Date = '" + txtDate.Text + "', Wage_Price = '" + Convert.ToInt64(txtWage.Text) + "', Fixed_Price = '" + Convert.ToInt64(txtFix_Cost.Text) + "', Var_Price = '" + Convert.ToInt64(txtVar_Cost.Text) + "', Total_Price = '" + Convert.ToInt64(txtP_Cost.Text) + "',  Notice = N'" + txtNotice.Text + "' WHERE ID = '" + Convert.ToInt64(txtCode.Text) + "'";
                        query2 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Incoming, Notice, Parent, Parent_Code, Store) VALUES ('" + P_Code + "','" + txtDate.Text + "','" + float.Parse(txtEntity_Prd.Text) + "',N'" + "تولید شده" + "',10,'" + Convert.ToInt32(txtCode.Text) + "','" + Store_Code + "')";
                        if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query3 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "',N'" + cmbStore.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "مصرف شده بایت تولید " + cmbProduct_Prd.Text + "',10,'" + Convert.ToInt32(txtCode.Text) + "','" + First_Store + "')";
                                    query4 = "INSERT INTO tbl_Body_Product_Production (ID, P_Code, Entity, Price, Total) VALUES ('" + Convert.ToInt64(txtCode.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
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

        private void txtEntity_Formule_TextChanged(object sender, EventArgs e)
        {
            txtEntity_Prd.Text = txtEntity_Formule.Text;
        }

        private void txtBuy_Price_Prd_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBuy_Price_Prd);
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbProduct_Prd.Focus();
            else if (e.KeyData == Keys.F12)
            {
                try
                {
                    frmProduct_Type f = new frmProduct_Type();
                    f.Form_Load();
                    f.op = "Add";
                    f.ShowDialog();
                    Fill_Product_Type();
                }
                catch
                {
                }
            }
        }

        private void cmbStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbType.Focus();
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

        private void cmbProduct_Prd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtEntity_Prd.Focus();
            else if (e.KeyData == Keys.F12)
            {
                try
                {
                    frmProduct f = new frmProduct();
                    f.op = "Add";
                    f.Flag = 0;
                    f.Form_Load();
                    f.ShowDialog();
                    Fill_Product();
                }
                catch
                {
                }
            }
        }

        private void txtEntity_Prd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBuy_Price_Prd.Focus();
        }

        private void txtBuy_Price_Prd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtWage.Focus();
        }

        private void txtWage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtFix_Cost.Focus();
        }

        private void txtFix_Cost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtVar_Cost.Focus();
        }

        private void txtVar_Cost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtP_Cost.Focus();
        }

        private void txtP_Cost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtBuy_Price_Prd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtWage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtFix_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtVar_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtP_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtEntity_Prd_TextChanged(object sender, EventArgs e)
        {
            txtEntity_Formule.Text = txtEntity_Prd.Text;
        }

        private void txtBuy_Price_Formule_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtBuy_Price_Formule);
        }

        private void txtBuy_Price_Formule_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }
    }
}
