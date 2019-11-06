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
    public partial class frmProduction : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, s_PName, s_Prd_Name;
        public int Product_Type, Unit_Code, Flag, P_Code, p_Service, Counter_Name;
        int Parent_Code;
        TextBox txt;
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
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Product.P_Show_Name, tbl_Store.Shown_Name, tbl_Product_Type.Description, tbl_Header_Prd.Wage, tbl_Header_Prd.Fix_Cost, tbl_Header_Prd.Var_Cost, tbl_Header_Prd.P_Cost,  tbl_Header_Prd.Prd_Name FROM tbl_Header_Prd INNER JOIN tbl_Product ON tbl_Header_Prd.P_Code = tbl_Product.P_Code INNER JOIN tbl_Product_Type ON tbl_Header_Prd.Type_Code = tbl_Product_Type.Type_Code AND tbl_Product.Product_Group = tbl_Product_Type.Type_Code INNER JOIN tbl_Store ON tbl_Header_Prd.Store = tbl_Store.Code AND tbl_Product.Store = tbl_Store.Code WHERE tbl_Header_Prd.ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCode.Text = ID.ToString();
            cmbProduct.Text = dt.Rows[0].ItemArray[0].ToString();
            cmbStore.Text = dt.Rows[0].ItemArray[1].ToString();
            cmbType.Text = dt.Rows[0].ItemArray[2].ToString();
            txtWage.Text = dt.Rows[0].ItemArray[3].ToString();
            txtFix_Cost.Text = dt.Rows[0].ItemArray[4].ToString();
            txtVar_Cost.Text = dt.Rows[0].ItemArray[5].ToString();
            txtP_Cost.Text = dt.Rows[0].ItemArray[6].ToString();
            txtName.Text = dt.Rows[0].ItemArray[7].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_Prd.P_Code, tbl_Product.P_Show_Name, tbl_Body_Prd.Entity, tbl_Body_Prd.Price, tbl_Body_Prd.Entity * tbl_Body_Prd.Price AS Expr1 FROM tbl_Body_Prd INNER JOIN tbl_Product ON tbl_Body_Prd.P_Code = tbl_Product.P_Code WHERE tbl_Body_Prd.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
            Calculate_All();
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query = "DELETE FROM tbl_Body_Prd WHERE ID = '" + ID + "'";
                if (clsFunction.Execute(dataconnection, query) == true)
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
                cmbProduct.Items.Clear();
                string Query = "SELECT P_Show_Name FROM tbl_Product WHERE Store LIKE N'" + Store_Code + "' AND Product_Group='" + Product_Type + "'";
                string s_obj = "P_Show_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbProduct, s_obj);
                cmbProduct.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        public void Form_Load()
        {
            txtCode.Text = txtName.Text = "";
            txtWage.Text = txtFix_Cost.Text = txtP_Cost.Text = txtVar_Cost.Text = "0";
            txtPrd_Cost.Text = "0";
            Fill_Store();
            Fill_Product_Type();
            Fill_Product();
            string query2 = "SELECT MAX (ID) FROM tbl_Header_Prd";
            clsFunction.txt_NewCode(dataconnection, query2, txtCode, "1");
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
        private bool Check_Production_Name()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Prd_Name FROM tbl_Header_Prd WHERE Prd_Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Prd_Name = (string)dr["Prd_Name"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Prd_Name == txtName.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Production_Name_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Prd_Name) FROM tbl_Header_Prd WHERE Prd_Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Counter_Name = (int)dr[0];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (Counter_Name == 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmProduction()
        {
            InitializeComponent();
        }

        private void frmProduction_Load(object sender, EventArgs e)
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

        private void txtWage_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
            clsFunction.Three_Ziro(txtWage);
        }

        private void txtFix_Cost_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
            clsFunction.Three_Ziro(txtFix_Cost);
        }

        private void txtVar_Cost_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
            clsFunction.Three_Ziro(txtVar_Cost);
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
            if (clsFunction.CMB_Error_Provider(cmbStore, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.CMB_Error_Provider(cmbType, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.CMB_Error_Provider(cmbProduct, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                string query1, query3;
                errorProvider1.Clear();
                if (op == "Add")
                {
                    if (Check_Production_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "فرمول " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        query1 = "INSERT INTO tbl_Header_Prd (ID, P_Code, Store, Type_Code, Wage, Fix_Cost, Var_Cost, P_Cost, Prd_Name) VALUES ('" + Convert.ToInt32(txtCode.Text) + "','" + P_Code + "','" + Store_Code + "','" + Product_Type + "','" + Convert.ToInt32(txtWage.Text) + "','" + Convert.ToInt32(txtFix_Cost.Text) + "','" + Convert.ToInt32(txtVar_Cost.Text) + "','" + Convert.ToInt64(txtP_Cost.Text) + "',N'" + txtName.Text.Trim() + "')";
                        if (clsFunction.Execute(dataconnection, query1) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query3 = "INSERT INTO tbl_Body_Prd (ID, P_Code, Entity, Price) VALUES ('" + Convert.ToInt32(txtCode.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query3) == true)
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
                    if (Check_Production_Name_ForEdit() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "فرمول " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        Delete_Data(Convert.ToInt32(txtCode.Text));
                        query1 = "UPDATE tbl_Header_Prd SET P_Code = '" + P_Code + "', Store = '" + Store_Code + "', Type_Code = '" + Product_Type + "', Wage = '" + Convert.ToInt32(txtWage.Text) + "', Fix_Cost = '" + Convert.ToInt32(txtFix_Cost.Text) + "', Var_Cost = '" + Convert.ToInt32(txtVar_Cost.Text) + "', P_Cost = '" + Convert.ToInt64(txtP_Cost.Text) + "', Prd_Name = N'" + txtName.Text.Trim() + "' WHERE ID = '" + Convert.ToInt32(txtCode.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query1) == true)
                        {
                            for (int i = 0; i < dgvStore.Rows.Count; i++)
                            {
                                try
                                {
                                    query3 = "INSERT INTO tbl_Body_Prd (ID, P_Code, Entity, Price) VALUES ('" + Convert.ToInt32(txtCode.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "')";
                                    if (clsFunction.Execute(dataconnection, query3) == true)
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

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataconnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT P_Code FROM tbl_Product WHERE P_Show_Name LIKE N'" + cmbProduct.Text + "'", dataconnection);
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
                txtName.Text = "تولید یک واحد " + cmbProduct.Text;
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

        private void txtPrd_Cost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbStore.Focus();
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

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbProduct.Focus();
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

        private void cmbProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                dgvStore.Focus();
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
                btnFinish.Focus();
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

        private void dgvStore_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
