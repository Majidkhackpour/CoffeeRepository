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
    public partial class frmProduct : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, s_PName;
        public int Product_Type, Unit_Code, Flag, P_Code, p_Service, Counter_Name;
        Image img;
        Boolean Chekc_Pic = false;
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
        private void Fill_Product_Unit()
        {
            try
            {
                cmbUnit.Items.Clear();
                string Query = "SELECT Unit_Name FROM tbl_Unit";
                string s_obj = "Unit_Name";
                clsFunction.FillComboBox(dataconnection, Query, cmbUnit, s_obj);
                cmbUnit.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Unit FROM tbl_Product_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbUnit.Text = dt.Rows[0].ItemArray[0].ToString();
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
            superTabControl1.SelectedTab = superTabItem1;
            rbtnProduct.Checked = true;
            txtCode.Text = txtName.Text = "";
            lblCode.Text = "00";
            txtBarcode.Text = txtPacking.Text = "";
            txtNum_In_Pack.Text = "0";
            txtShelf_Code.Text = txtTec_Code.Text = "";
            txtOrder_Point.Text = txtMin_Inventory.Text = txtMax_Inventory.Text = "0";
            txtFirst_Inventory.Text = txtSell_Price.Text = txtBuy_Price.Text = "0";
            lblTax_Price.Text = lblCom_Price.Text = "0";
            chbState.Checked = true;
            txtTax.Text = txtComplication.Text = txtCost.Text = "0";
            Fill_Store();
            Fill_Product_Type();
            Fill_Product_Unit();
            string query2 = "SELECT MAX (P_Code) FROM tbl_Product WHERE Product_Group ='" + Product_Type + "'";
            clsFunction.txt_NewCode(dataconnection, query2, txtCode, "0001");
            if (txtCode.Text.Length > 4)
                txtCode.Text = txtCode.Text.Remove(0, 1);
            rbtnProduct.Focus();
        }
        private void Set_Product_Type()
        {
            if (rbtnService.Checked)
            {
                cmbStore.Enabled = false;
                cmbType.Enabled = false;
                txtCode.Enabled = false;
                grpFull_Info.Enabled = false;
                grpInventory_Info.Enabled = false;
                chbState.Checked = true;
                chbState.Enabled = false;
                cmbType.SelectedIndex = 0;
            }
            else if (rbtnProduct.Checked)
            {
                cmbStore.Enabled = true;
                cmbType.Enabled = true;
                txtCode.Enabled = true;
                grpFull_Info.Enabled = true;
                grpInventory_Info.Enabled = true;
                chbState.Enabled = true;
            }
        }
        private void Calculate_Cost()
        {
            try
            {
                float Tax = float.Parse(txtTax.Text);
                float Complication = float.Parse(txtComplication.Text);
                int Cost = Convert.ToInt32(txtBuy_Price.Text);
                Tax = (Cost * Tax) / 100;
                Complication = (Cost * Complication) / 100;
                Cost = Convert.ToInt32(Cost + Tax + Complication);
                txtCost.Text = Cost.ToString();
                lblTax_Price.Text = Tax.ToString();
                lblCom_Price.Text = Complication.ToString();
            }
            catch
            {
                txtCost.Text = "0";
                lblCom_Price.Text = lblTax_Price.Text = "0";
            }
        }
        private bool Check_Product_Code()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                string Code = lblCode.Text + txtCode.Text;
                cmd = new SqlCommand("SELECT P_Code FROM tbl_Product WHERE P_Code='" + Convert.ToInt32(Code) + "'", dataconnection);
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
                if (P_Code == Convert.ToInt32(Code))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Product_Name()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT P_Name FROM tbl_Product WHERE P_Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_PName = (string)dr["P_Name"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_PName == txtName.Text.Trim())
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Product_Name_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(P_Name) FROM tbl_Product WHERE P_Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
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
        public void FillData(string Name)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Product.P_Code, tbl_Product.Product_Type, tbl_Product_Type.Description, tbl_Unit.Unit_Name, tbl_Store.Shown_Name, tbl_Product.Barcode, tbl_Product.Pic, tbl_Product.Packing,  tbl_Product.Number_In_Pack, tbl_Product.Shelf_Code, tbl_Product.Tec_Code, tbl_Product.Order_Point, tbl_Product.Max_Inventory, tbl_Product.Min_Inventory, tbl_Product.First_Inventory, tbl_Product.Sell_Price,  tbl_Product.Buy_Price, tbl_Product.Tax_Percent, tbl_Product.Complication_Percent, tbl_Product.Cost, tbl_Product.P_Name FROM tbl_Product INNER JOIN tbl_Product_Type ON tbl_Product.Product_Group = tbl_Product_Type.Type_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Store ON tbl_Product.Store = tbl_Store.Code WHERE tbl_Product.P_Show_Name LIKE N'" + Name + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Flag = 1;
            txtName.Text = Name;
            txtCode.Text = dt.Rows[0].ItemArray[0].ToString();
            txtCode.Text = txtCode.Text.Remove(0, 1);
            cmbType.Text = dt.Rows[0].ItemArray[2].ToString();
            cmbUnit.Text = dt.Rows[0].ItemArray[3].ToString();
            cmbStore.Text = dt.Rows[0].ItemArray[4].ToString();
            txtBarcode.Text = dt.Rows[0].ItemArray[5].ToString();
            txtPacking.Text = dt.Rows[0].ItemArray[7].ToString();
            txtNum_In_Pack.Text = dt.Rows[0].ItemArray[8].ToString();
            txtShelf_Code.Text = dt.Rows[0].ItemArray[9].ToString();
            txtTec_Code.Text = dt.Rows[0].ItemArray[10].ToString();
            txtOrder_Point.Text = dt.Rows[0].ItemArray[11].ToString();
            txtMax_Inventory.Text = dt.Rows[0].ItemArray[12].ToString();
            txtMin_Inventory.Text = dt.Rows[0].ItemArray[13].ToString();
            txtFirst_Inventory.Text = dt.Rows[0].ItemArray[14].ToString();
            txtSell_Price.Text = dt.Rows[0].ItemArray[15].ToString();
            txtBuy_Price.Text = dt.Rows[0].ItemArray[16].ToString();
            txtTax.Text = dt.Rows[0].ItemArray[17].ToString();
            txtComplication.Text = dt.Rows[0].ItemArray[18].ToString();
            txtCost.Text = dt.Rows[0].ItemArray[19].ToString();
            txtName.Text = dt.Rows[0].ItemArray[20].ToString();
            rbtnService.Enabled = false;
            rbtnProduct.Enabled = false;
            cmbType.Enabled = false;
            txtCode.Enabled = false;
            if (dt.Rows[0].ItemArray[1].ToString() == "0")
                rbtnProduct.Checked = true;
            else
                rbtnService.Checked = true;
            try
            {
                byte[] myarray = null;
                myarray = (byte[])dt.Rows[0].ItemArray[6];
                System.IO.MemoryStream mymemory = new System.IO.MemoryStream(myarray);
                picProduct.Image = Image.FromStream(mymemory);
            }
            catch
            {
            }
        }
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnNewBarcode, "ایجاد بارکد");
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.AutoComplete("SELECT P_Name FROM tbl_Product", dataconnection, txtName);
            clsFunction.AutoComplete("SELECT Packing FROM tbl_Product", dataconnection, txtPacking);
            clsFunction.AutoComplete("SELECT Number_In_Pack FROM tbl_Product", dataconnection, txtNum_In_Pack);
            clsFunction.AutoComplete("SELECT Sell_Price FROM tbl_Product", dataconnection, txtSell_Price);
            clsFunction.AutoComplete("SELECT Buy_Price FROM tbl_Product", dataconnection, txtBuy_Price);
            clsFunction.AutoComplete("SELECT Tax_Percent FROM tbl_Product", dataconnection, txtTax);
            clsFunction.AutoComplete("SELECT Complication_Percent FROM tbl_Product", dataconnection, txtComplication);
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

        private void chbState_CheckedChanged(object sender, EventArgs e)
        {
            if (chbState.Checked)
            {
                txtTax.Enabled = false;
                txtComplication.Enabled = false;
            }
            else if (chbState.Checked == false)
            {
                txtTax.Enabled = true;
                txtComplication.Enabled = true;
            }
        }

        private void rbtnProduct_CheckedChanged(object sender, EventArgs e)
        {
            Set_Product_Type();
        }

        private void rbtnService_CheckedChanged(object sender, EventArgs e)
        {
            Set_Product_Type();
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type_Code FROM tbl_Product_Type WHERE Description LIKE N'" + cmbType.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product_Type = (int)dr["Type_Code"];
                    lblCode.Text = Product_Type.ToString();
                    if (lblCode.Text.Length <= 1)
                        lblCode.Text = "0" + lblCode.Text;
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
            if (Flag == 0)
            {
                string query2 = "SELECT MAX (P_Code) FROM tbl_Product WHERE Product_Group ='" + Product_Type + "'";
                clsFunction.txt_NewCode(dataconnection, query2, txtCode, "0001");
                if (txtCode.Text.Length > 4)
                    txtCode.Text = txtCode.Text.Remove(0, 1);
                txtBarcode.Text = lblCode.Text + txtCode.Text;
            }
            Flag = 0;
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Unit_Code FROM tbl_Unit WHERE Unit_Name LIKE N'" + cmbUnit.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Unit_Code = (int)dr["Unit_Code"];
                }
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            dataconnection.Close();
            lblOrder_Point.Text = lblMin_Inventory.Text = lblMax_Inventory.Text = lblFirst_Inventory.Text = cmbUnit.Text;
        }

        private void btnSearch_Pic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                picProduct.Load(op.FileName);
                img = Image.FromFile(op.FileName);
                Chekc_Pic = true;
            }
            catch
            {
                Chekc_Pic = false;
            }
        }

        private void btnNewBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                frmBarcode f = new frmBarcode();
                f.txtName.Text = txtName.Text;
                f.txtCode.Text = txtBarcode.Text;
                f.txtBarcode.Text = txtBarcode.Text;
                f.ShowDialog();
                txtBarcode.Text = f.txtBarcode.Text;
            }
            catch
            {
            }
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
        }

        private void txtComplication_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
        }

        private void txtSell_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtSell_Price);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (cmbStore.Text == "" || cmbType.Text == "" || cmbUnit.Text == "")
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "اطلاعات پیش فرض سیستم را پر نمایید";
                f.ShowDialog();
            }
            else if (clsFunction.Error_Provider(txtCode, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else if (clsFunction.Error_Provider(txtNum_In_Pack, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtOrder_Point, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtMin_Inventory, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtMax_Inventory, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else if (clsFunction.Error_Provider(txtFirst_Inventory, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtSell_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtBuy_Price, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtTax, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtComplication, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtCost, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else if (Convert.ToInt32(txtTax.Text) > 100)
            {
                txtTax.Text = "100";
            }
            else if (Convert.ToInt32(txtComplication.Text) > 100)
            {
                txtComplication.Text = "100";
            }
            else
            {
                errorProvider1.Clear();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Pic_Patch, Type_Name FROM tbl_Product_Setting WHERE ID=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string Code = lblCode.Text + txtCode.Text;
                if (rbtnProduct.Checked)
                    p_Service = 0;
                else
                    p_Service = 1;
                byte[] myarray;
                try
                {
                    System.IO.MemoryStream mymemory = new System.IO.MemoryStream();
                    img.Save(mymemory, picProduct.Image.RawFormat);
                    myarray = mymemory.GetBuffer();
                }
                catch
                {
                    myarray = null;
                }
                string Name;
                if (Convert.ToBoolean(dt.Rows[0].ItemArray[1].ToString()) == true)
                    Name = txtName.Text.Trim() + " " + "(" + " " + cmbType.Text + " " + ")";
                else
                    Name = txtName.Text.Trim();
                if (op == "Add")
                {
                    if (Check_Product_Code() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "کد کالا تکراری است";
                        f.ShowDialog();
                    }
                    else if (Check_Product_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "کالا با شرح " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        if (Chekc_Pic == true)
                        {
                            if (dt.Rows[0].ItemArray[0] != null)
                            {
                                picProduct.Image.Save(dt.Rows[0].ItemArray[0].ToString() + lblCode.Text + txtCode.Text + ".jpg");
                            }
                            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Product (P_Code, Product_Type, Product_Group, P_Name, Unit, Store, Barcode, Pic, Packing, Number_In_Pack, Shelf_Code, Tec_Code, Order_Point, Max_Inventory, Min_Inventory, First_Inventory, Sell_Price, Buy_Price,  Tax_Percent, Complication_Percent, Cost, P_Show_Name, Tax_Price, Complication_Price) VALUES (@P_Code,@Product_Type,@Product_Group,@P_Name,@Unit,@Store,@Barcode,@Pic,@Packing,@Number_In_Pack,@Shelf_Code,@Tec_Code,@Order_Point,@Max_Inventory,@Min_Inventory,@First_Inventory,@Sell_Price,@Buy_Price,@Tax_Percent,@Complication_Percent,@Cost,@P_Show_Name,@Tax_Price,@Complication_Price)", dataconnection);
                            cmd.Parameters.AddWithValue("@P_Code", Convert.ToInt32(Code));
                            cmd.Parameters.AddWithValue("@Product_Type", p_Service);
                            cmd.Parameters.AddWithValue("@Product_Group", Product_Type);
                            cmd.Parameters.AddWithValue("@P_Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Unit", Unit_Code);
                            cmd.Parameters.AddWithValue("@Store", Store_Code);
                            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                            cmd.Parameters.AddWithValue("@Pic", myarray);
                            cmd.Parameters.AddWithValue("@Packing", txtPacking.Text);
                            cmd.Parameters.AddWithValue("@Number_In_Pack", float.Parse(txtNum_In_Pack.Text));
                            cmd.Parameters.AddWithValue("@Shelf_Code", txtShelf_Code.Text);
                            cmd.Parameters.AddWithValue("@Tec_Code", txtTec_Code.Text);
                            cmd.Parameters.AddWithValue("@Order_Point", float.Parse(txtOrder_Point.Text));
                            cmd.Parameters.AddWithValue("@Max_Inventory", float.Parse(txtMax_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Min_Inventory", float.Parse(txtMin_Inventory.Text));
                            cmd.Parameters.AddWithValue("@First_Inventory", float.Parse(txtFirst_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Sell_Price", Convert.ToInt64(txtSell_Price.Text));
                            cmd.Parameters.AddWithValue("@Buy_Price", Convert.ToInt64(txtBuy_Price.Text));
                            cmd.Parameters.AddWithValue("@Tax_Percent", float.Parse(txtTax.Text));
                            cmd.Parameters.AddWithValue("@Complication_Percent", float.Parse(txtComplication.Text));
                            cmd.Parameters.AddWithValue("@Cost", Convert.ToInt64(txtCost.Text));
                            cmd.Parameters.AddWithValue("@P_Show_Name", Name);
                            cmd.Parameters.AddWithValue("@Tax_Price", Convert.ToInt32(lblTax_Price.Text));
                            cmd.Parameters.AddWithValue("@Complication_Price", Convert.ToInt32(lblCom_Price.Text));
                            dataconnection.Open();
                            cmd.ExecuteNonQuery();
                            dataconnection.Close();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Product (P_Code, Product_Type, Product_Group, P_Name, Unit, Store, Barcode, Packing, Number_In_Pack, Shelf_Code, Tec_Code, Order_Point, Max_Inventory, Min_Inventory, First_Inventory, Sell_Price, Buy_Price,  Tax_Percent, Complication_Percent, Cost, P_Show_Name, Tax_Price, Complication_Price) VALUES (@P_Code,@Product_Type,@Product_Group,@P_Name,@Unit,@Store,@Barcode,@Packing,@Number_In_Pack,@Shelf_Code,@Tec_Code,@Order_Point,@Max_Inventory,@Min_Inventory,@First_Inventory,@Sell_Price,@Buy_Price,@Tax_Percent,@Complication_Percent,@Cost,@P_Show_Name,@Tax_Price,@Complication_Price)", dataconnection);
                            cmd.Parameters.AddWithValue("@P_Code", Convert.ToInt32(Code));
                            cmd.Parameters.AddWithValue("@Product_Type", p_Service);
                            cmd.Parameters.AddWithValue("@Product_Group", Product_Type);
                            cmd.Parameters.AddWithValue("@P_Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Unit", Unit_Code);
                            cmd.Parameters.AddWithValue("@Store", Store_Code);
                            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                            cmd.Parameters.AddWithValue("@Packing", txtPacking.Text);
                            cmd.Parameters.AddWithValue("@Number_In_Pack", float.Parse(txtNum_In_Pack.Text));
                            cmd.Parameters.AddWithValue("@Shelf_Code", txtShelf_Code.Text);
                            cmd.Parameters.AddWithValue("@Tec_Code", txtTec_Code.Text);
                            cmd.Parameters.AddWithValue("@Order_Point", float.Parse(txtOrder_Point.Text));
                            cmd.Parameters.AddWithValue("@Max_Inventory", float.Parse(txtMax_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Min_Inventory", float.Parse(txtMin_Inventory.Text));
                            cmd.Parameters.AddWithValue("@First_Inventory", float.Parse(txtFirst_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Sell_Price", Convert.ToInt64(txtSell_Price.Text));
                            cmd.Parameters.AddWithValue("@Buy_Price", Convert.ToInt64(txtBuy_Price.Text));
                            cmd.Parameters.AddWithValue("@Tax_Percent", float.Parse(txtTax.Text));
                            cmd.Parameters.AddWithValue("@Complication_Percent", float.Parse(txtComplication.Text));
                            cmd.Parameters.AddWithValue("@Cost", Convert.ToInt64(txtCost.Text));
                            cmd.Parameters.AddWithValue("@P_Show_Name", Name);
                            cmd.Parameters.AddWithValue("@Tax_Price", Convert.ToInt32(lblTax_Price.Text));
                            cmd.Parameters.AddWithValue("@Complication_Price", Convert.ToInt32(lblCom_Price.Text));
                            dataconnection.Open();
                            cmd.ExecuteNonQuery();
                            dataconnection.Close();
                        }
                        string query = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Incoming, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(Code) + "','" + clsFunction.M2SH(DateTime.Now) + "','" + float.Parse(txtFirst_Inventory.Text) + "',0,N'" + "اول دوره" + "','" + 9 + "','" + 1 + "','" + Store_Code + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                        }
                        SqlDataAdapter da2 = new SqlDataAdapter("SELECT Code FROM tbl_Price_Pattern", dataconnection);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        for (int i = 0; i < dt2.Rows.Count+1; i++)
                        {
                            try
                            {
                                string query2 = "INSERT INTO tbl_Price_List (P_Code, Pattern_Code) VALUES ('" + Convert.ToInt32(Code) + "','" + i.ToString() + "')";
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
                    if (Check_Product_Name_ForEdit() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "کالا با شرح " + txtName.Text + " " + "از پیش در سیستم تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        if (Chekc_Pic == true)
                        {
                            System.IO.File.Delete(dt.Rows[0].ItemArray[0].ToString() + lblCode.Text + txtCode.Text + ".jpg");
                            if (dt.Rows[0].ItemArray[0] != null)
                            {
                                picProduct.Image.Save(dt.Rows[0].ItemArray[0].ToString() + lblCode.Text + txtCode.Text + ".jpg");
                            }
                            SqlCommand cmd = new SqlCommand("UPDATE tbl_Product SET Product_Type = @Product_Type, Product_Group = @Product_Group, P_Name = @P_Name, Unit = @Unit, Store = @Store, Barcode = @Barcode, Pic = @Pic, Packing = @Packing,  Number_In_Pack = @Number_In_Pack, Shelf_Code = @Shelf_Code, Tec_Code = @Tec_Code, Order_Point = @Order_Point, Max_Inventory = @Max_Inventory, Min_Inventory = @Min_Inventory,  First_Inventory = @First_Inventory, Sell_Price = @Sell_Price, Buy_Price = @Buy_Price, Tax_Percent = @Tax_Percent, Complication_Percent = @Complication_Percent, Cost = @Cost, Tax_Price=@Tax_Price, Complication_Price=@Complication_Price WHERE P_Code = @P_Code", dataconnection);
                            cmd.Parameters.AddWithValue("@P_Code", Convert.ToInt32(Code));
                            cmd.Parameters.AddWithValue("@Product_Type", p_Service);
                            cmd.Parameters.AddWithValue("@Product_Group", Product_Type);
                            cmd.Parameters.AddWithValue("@P_Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Unit", Unit_Code);
                            cmd.Parameters.AddWithValue("@Store", Store_Code);
                            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                            cmd.Parameters.AddWithValue("@Pic", myarray);
                            cmd.Parameters.AddWithValue("@Packing", txtPacking.Text);
                            cmd.Parameters.AddWithValue("@Number_In_Pack", float.Parse(txtNum_In_Pack.Text));
                            cmd.Parameters.AddWithValue("@Shelf_Code", txtShelf_Code.Text);
                            cmd.Parameters.AddWithValue("@Tec_Code", txtTec_Code.Text);
                            cmd.Parameters.AddWithValue("@Order_Point", float.Parse(txtOrder_Point.Text));
                            cmd.Parameters.AddWithValue("@Max_Inventory", float.Parse(txtMax_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Min_Inventory", float.Parse(txtMin_Inventory.Text));
                            cmd.Parameters.AddWithValue("@First_Inventory", float.Parse(txtFirst_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Sell_Price", Convert.ToInt64(txtSell_Price.Text));
                            cmd.Parameters.AddWithValue("@Buy_Price", Convert.ToInt64(txtBuy_Price.Text));
                            cmd.Parameters.AddWithValue("@Tax_Percent", float.Parse(txtTax.Text));
                            cmd.Parameters.AddWithValue("@Complication_Percent", float.Parse(txtComplication.Text));
                            cmd.Parameters.AddWithValue("@Cost", Convert.ToInt64(txtCost.Text));
                            cmd.Parameters.AddWithValue("@P_Show_Name", Name);
                            cmd.Parameters.AddWithValue("@Tax_Price", Convert.ToInt32(lblTax_Price.Text));
                            cmd.Parameters.AddWithValue("@Complication_Price", Convert.ToInt32(lblCom_Price.Text));
                            dataconnection.Open();
                            cmd.ExecuteNonQuery();
                            dataconnection.Close();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE tbl_Product SET Product_Type = @Product_Type, Product_Group = @Product_Group, P_Name = @P_Name, Unit = @Unit, Store = @Store, Barcode = @Barcode, Packing = @Packing,  Number_In_Pack = @Number_In_Pack, Shelf_Code = @Shelf_Code, Tec_Code = @Tec_Code, Order_Point = @Order_Point, Max_Inventory = @Max_Inventory, Min_Inventory = @Min_Inventory,  First_Inventory = @First_Inventory, Sell_Price = @Sell_Price, Buy_Price = @Buy_Price, Tax_Percent = @Tax_Percent, Complication_Percent = @Complication_Percent, Cost = @Cost, Tax_Price=@Tax_Price, Complication_Price=@Complication_Price WHERE P_Code = @P_Code", dataconnection);
                            cmd.Parameters.AddWithValue("@P_Code", Convert.ToInt32(Code));
                            cmd.Parameters.AddWithValue("@Product_Type", p_Service);
                            cmd.Parameters.AddWithValue("@Product_Group", Product_Type);
                            cmd.Parameters.AddWithValue("@P_Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Unit", Unit_Code);
                            cmd.Parameters.AddWithValue("@Store", Store_Code);
                            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                            cmd.Parameters.AddWithValue("@Packing", txtPacking.Text);
                            cmd.Parameters.AddWithValue("@Number_In_Pack", float.Parse(txtNum_In_Pack.Text));
                            cmd.Parameters.AddWithValue("@Shelf_Code", txtShelf_Code.Text);
                            cmd.Parameters.AddWithValue("@Tec_Code", txtTec_Code.Text);
                            cmd.Parameters.AddWithValue("@Order_Point", float.Parse(txtOrder_Point.Text));
                            cmd.Parameters.AddWithValue("@Max_Inventory", float.Parse(txtMax_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Min_Inventory", float.Parse(txtMin_Inventory.Text));
                            cmd.Parameters.AddWithValue("@First_Inventory", float.Parse(txtFirst_Inventory.Text));
                            cmd.Parameters.AddWithValue("@Sell_Price", Convert.ToInt64(txtSell_Price.Text));
                            cmd.Parameters.AddWithValue("@Buy_Price", Convert.ToInt64(txtBuy_Price.Text));
                            cmd.Parameters.AddWithValue("@Tax_Percent", float.Parse(txtTax.Text));
                            cmd.Parameters.AddWithValue("@Complication_Percent", float.Parse(txtComplication.Text));
                            cmd.Parameters.AddWithValue("@Cost", Convert.ToInt64(txtCost.Text));
                            cmd.Parameters.AddWithValue("@P_Show_Name", Name);
                            cmd.Parameters.AddWithValue("@Tax_Price", Convert.ToInt32(lblTax_Price.Text));
                            cmd.Parameters.AddWithValue("@Complication_Price", Convert.ToInt32(lblCom_Price.Text));
                            dataconnection.Open();
                            cmd.ExecuteNonQuery();
                            dataconnection.Close();
                        }
                        string query = "UPDATE tbl_Tour_Of_Product SET Incoming = '" + float.Parse(txtFirst_Inventory.Text) + "', Store='" + Store_Code + "' WHERE P_Code = '" + Convert.ToInt32(Code) + "' AND Notice = N'" + "اول دوره" + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                            this.Close();
                    }
                }
            }
        }

        private void txtBuy_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCost.Text = txtBuy_Price.Text;
                clsFunction.Three_Ziro(txtBuy_Price);
            }
            catch
            {
                txtCost.Text = "";
            }
        }

        private void txtSell_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtBuy_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtNum_In_Pack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtOrder_Point_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtMin_Inventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtMax_Inventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtFirst_Inventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtComplication_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
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

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode.Focus();
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

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtName.Focus();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbUnit.Focus();
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                superTabControl1.SelectedTab = superTabItem2;
                txtBarcode.Focus();
            }
            else if (e.KeyData == Keys.F12)
            {
                try
                {
                    new frmUnit().ShowDialog();
                    Fill_Product_Unit();
                }
                catch
                {
                }
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPacking.Focus();
        }

        private void txtPacking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNum_In_Pack.Focus();
        }

        private void txtNum_In_Pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtShelf_Code.Focus();
        }

        private void txtShelf_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTec_Code.Focus();
        }

        private void txtTec_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                superTabControl1.SelectedTab = superTabItem3;
                txtOrder_Point.Focus();
            }
        }

        private void txtOrder_Point_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMin_Inventory.Focus();
        }

        private void txtMin_Inventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtMax_Inventory.Focus();
        }

        private void txtMax_Inventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtFirst_Inventory.Focus();
        }

        private void txtFirst_Inventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtSell_Price.Focus();
        }

        private void txtSell_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBuy_Price.Focus();
        }

        private void txtBuy_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                superTabControl1.SelectedTab = superTabItem4;
                chbState.Focus();
            }
        }

        private void chbState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtTax.Focus();
        }

        private void txtTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtComplication.Focus();
        }

        private void txtComplication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCost.Focus();
        }

        private void txtCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtCost);
        }

        private void rbtnProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbStore.Focus();
        }
    }
}
