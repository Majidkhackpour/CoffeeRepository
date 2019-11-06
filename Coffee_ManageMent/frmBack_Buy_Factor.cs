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
    public partial class frmBack_Buy_Factor : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, Store_Code, Pattern_Code;
        Int64 Ware_Rec_ID, Reminder_ID, Ware_Rec_ID_Edit;
        int Doc_Number, Total_Price;
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
                        Calculate_All_Entity();
                    }
                    if (dgvStore.CurrentCell.ColumnIndex == 3 || dgvStore.CurrentCell.ColumnIndex == 6 || dgvStore.CurrentCell.ColumnIndex == 5)
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
                int P_ID = Convert.ToInt32(dgvStore.CurrentRow.Cells["Code"].Value);
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Product.P_Show_Name, tbl_Unit.Unit_Name, tbl_Price_List.Buy_Price FROM tbl_Product INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code INNER JOIN tbl_Price_List ON tbl_Product.P_Code = tbl_Price_List.P_Code WHERE tbl_Product.P_Code='" + P_ID + "' AND tbl_Price_List.Pattern_Code='" + Pattern_Code + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStore["P_Name", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[0].ToString();
                dgvStore["Unit_Name", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[1].ToString();
                dgvStore["Buy_Price", dgvStore.CurrentRow.Index].Value = dt.Rows[0].ItemArray[2].ToString();
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
                txtCost.Text = T.ToString();
            }
            catch
            {
                txtCost.Text = "0";
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
        public void Form_Load()
        {
            txtDate.Text = clsFunction.M2SH(DateTime.Now);
            string query2 = "SELECT MAX (ID) FROM tbl_Header_Back_Buy_Factor";
            clsFunction.txt_NewCode(dataconnection, query2, txtID, "1");
            txtAdded_Percent.Text = txtBill.Text = txtCode.Text = "";
            txtDelivery.Text = txtDescount_Percent.Text = txtName.Text = "";
            txtNotice.Text = txtSett_Date.Text = "";
            txtTotal.Text = txtEntity.Text = txtDiscount_Price.Text = "0";
            txtCost.Text = txtAdded_Price.Text = "0";
            Fill_Store();
            Fill_Price_Pattern();
        }
        private void Get_Max_Reminder_ID()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (ID) FROM tbl_Reminder", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Reminder_ID = Convert.ToInt64(dt.Rows[0].ItemArray[0]) + 1;
            }
            catch
            {
                Reminder_ID = 1;
            }
        }
        private void Get_Max_WareHouse_Reciept_ID()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (ID) FROM tbl_Header_TurnTransfer", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Ware_Rec_ID = Convert.ToInt64(dt.Rows[0].ItemArray[0]) + 1;
            }
            catch
            {
                Ware_Rec_ID = 1;
            }
        }
        private void Document()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Moeen=302 AND Parent_Code=1", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {
                    string q = "UPDATE tbl_Transaction SET Bedehkar=Bedehkar-'" + Convert.ToInt64(txtTotal.Text) + "' WHERE ID='" + Convert.ToInt32(dt.Rows[0].ItemArray[0]) + "'";
                    if (clsFunction.Execute(dataconnection, q) == true)
                    {
                    }
                }
                catch
                {
                    string q = "INSERT INTO tbl_Transaction (Bestankar, Notice, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtTotal.Text) + "',N'" + "حساب های پرداختنی" + "','" + 1 + "','" + 302 + "','" + 0 + "','" + 1 + "')";
                    if (clsFunction.Execute(dataconnection, q) == true)
                    {
                    }
                }
            }
            catch
            {
            }
        }
        private void Document_Edit()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM tbl_Transaction WHERE Moeen=302 AND Parent_Code=1", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
                int Distance = Convert.ToInt32(txtTotal.Text) - Total_Price;
                string q = "UPDATE tbl_Transaction SET Bedehkar=Bedehkar+'" + Convert.ToInt64(Distance) + "' WHERE ID='" + Convert.ToInt32(dt.Rows[0].ItemArray[0]) + "'";
                if (clsFunction.Execute(dataconnection, q) == true)
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
        private void Get_Max_Doc_Number()
        {
            try
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Doc_Number FROM tbl_Transaction WHERE Date='" + txtDate.Text + "'", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
                catch
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MAX (Doc_Number) FROM tbl_Transaction", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Doc_Number = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;
                }
            }
            catch
            {
                Doc_Number = 1;
            }
        }
        private void Fill_Price_Pattern()
        {
            try
            {
                cmbPrice_Pattern.Items.Clear();
                string Query = "SELECT Description FROM tbl_Price_Pattern WHERE Type=0 AND State=0";
                string s_obj = "Description";
                clsFunction.FillComboBox(dataconnection, Query, cmbPrice_Pattern, s_obj);
                cmbPrice_Pattern.SelectedIndex = 0;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Current_Buy_Pattern FROM tbl_Setting", dataconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbPrice_Pattern.Text = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void Calculate_Cost()
        {
            try
            {
                txtTotal.Text = ((Convert.ToInt32(txtCost.Text) + Convert.ToInt32(txtAdded_Price.Text)) - Convert.ToInt32(txtDiscount_Price.Text)).ToString();
            }
            catch
            {
                txtTotal.Text = "0";
            }
        }
        public void Delete_Data(int ID)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Body_Back_Buy_Factor WHERE ID = '" + ID + "'";
                string query2 = "DELETE FROM tbl_Body_TurnTransfer WHERE ID = '" + Ware_Rec_ID_Edit + "'";
                string query3 = "DELETE FROM tbl_Tour_Of_Product WHERE Parent=4 AND Parent_Code = '" + Ware_Rec_ID_Edit + "'";
                string query4 = "DELETE FROM tbl_Transaction WHERE Parent=4 AND Parent_Code = '" + ID + "'";
                if (clsFunction.Execute(dataconnection, query1) == true && clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query4) == true)
                {
                }
            }
            catch
            {
            }
        }
        public void FillData(int ID)
        {
            Form_Load();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date, Reciver, Sett_Date, Bill, Seller_Code, Price, Discount, Added_Value, Total, Doc_Code, Notice FROM tbl_Header_Back_Buy_Factor WHERE ID= '" + ID + "'", dataconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtID.Text = ID.ToString();
            txtDate.Text = dt.Rows[0].ItemArray[0].ToString();
            txtDelivery.Text = dt.Rows[0].ItemArray[1].ToString();
            txtSett_Date.Text = dt.Rows[0].ItemArray[2].ToString();
            txtBill.Text = dt.Rows[0].ItemArray[3].ToString();
            txtCode.Text = dt.Rows[0].ItemArray[4].ToString();
            txtCost.Text = dt.Rows[0].ItemArray[5].ToString();
            txtDiscount_Price.Text = dt.Rows[0].ItemArray[6].ToString();
            txtAdded_Price.Text = dt.Rows[0].ItemArray[7].ToString();
            txtTotal.Text = dt.Rows[0].ItemArray[8].ToString();
            Total_Price = Convert.ToInt32(dt.Rows[0].ItemArray[8]);
            Ware_Rec_ID_Edit = Convert.ToInt64(dt.Rows[0].ItemArray[9]);
            txtNotice.Text = dt.Rows[0].ItemArray[10].ToString();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT tbl_Body_Back_Buy_Factor.P_Code, tbl_Product.P_Show_Name, tbl_Body_Back_Buy_Factor.Entity, tbl_Unit.Unit_Name, tbl_Body_Back_Buy_Factor.P_Cost, tbl_Body_Back_Buy_Factor.Total FROM tbl_Body_Back_Buy_Factor INNER JOIN tbl_Product ON tbl_Body_Back_Buy_Factor.P_Code = tbl_Product.P_Code INNER JOIN tbl_Unit ON tbl_Product.Unit = tbl_Unit.Unit_Code WHERE tbl_Body_Back_Buy_Factor.ID='" + ID + "'", dataconnection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvStore.DataSource = dt2;
            Calculate_All();
            Calculate_All_Entity();
        }
        public frmBack_Buy_Factor()
        {
            InitializeComponent();
        }

        private void frmBack_Buy_Factor_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            ToolTip tt = new ToolTip();
            tt.SetToolTip(picShow_Reminder, "نمایش همه یادآوری ها");
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Account.Description FROM tbl_Account INNER JOIN tbl_Seller ON tbl_Account.Code = tbl_Seller.Code WHERE tbl_Seller.Code= '" + txtCode.Text + "'", dataconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtName.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                txtName.Text = "";
            }
        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            try
            {
                frmAllSeller f = new frmAllSeller();
                f.ShowDialog();
                txtCode.Text = f.Acc_Code;
            }
            catch
            {
                txtCode.Text = "";
            }
        }

        private void txtDescount_Percent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDescount_Percent.Text) > 100)
                    txtDescount_Percent.Text = "100";
                txtDiscount_Price.Text = ((Convert.ToInt32(txtCost.Text) * Convert.ToInt32(txtDescount_Percent.Text)) / 100).ToString();
            }
            catch
            {
                txtDiscount_Price.Text = "0";
            }
        }

        private void txtAdded_Percent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtAdded_Percent.Text) > 100)
                    txtAdded_Percent.Text = "100";
                txtAdded_Price.Text = ((Convert.ToInt32(txtCost.Text) * Convert.ToInt32(txtAdded_Percent.Text)) / 100).ToString();
            }
            catch
            {
                txtAdded_Price.Text = "0";
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            Calculate_Cost();
        }

        private void txtDiscount_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtDiscount_Price);
            Calculate_Cost();
        }

        private void txtAdded_Price_TextChanged(object sender, EventArgs e)
        {
            clsFunction.Three_Ziro(txtAdded_Price);
            Calculate_Cost();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStore.Rows.RemoveAt(dgvStore.CurrentRow.Index);
                Calculate_All();
                Calculate_All_Entity();
                Calculate_TotalRow();
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
                Calculate_TotalRow();
            }
            catch
            {
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string query1, query2, query3, query4, query5, query6, query7, query8, query9, query10;
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                string SubString = txtCode.Text.Substring(0, 2);
                if (SubString != "30" && SubString != "40")
                {
                    clsFunction.Show_OtherError(txtName, errorProvider1, "در وارد کردن اطلاعات دقت نمایید");
                }
                else
                {
                    errorProvider1.Clear();
                    DateTime d1 = Convert.ToDateTime(txtDate.Text);
                    DateTime d2 = Convert.ToDateTime(clsFunction.M2SH(DateTime.Now));
                    if (d1 > d2)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "تاریخ فاکتور برگشت از خرید نمی تواند از تاریخ روز بزرگتر باشد";
                        f.ShowDialog();
                    }
                    else
                    {
                        if (op == "Add")
                        {
                            Get_Max_WareHouse_Reciept_ID();
                            query1 = "INSERT INTO tbl_Header_Back_Buy_Factor (ID, Date, Reciver, Store, Sett_Date, Bill, Seller_Code, Price, Discount, Added_Value, Total, UserName, Doc_Code, Notice) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + txtDate.Text + "',N'" + txtDelivery.Text + "','" + Store_Code + "','" + txtSett_Date.Text + "',N'" + txtBill.Text + "','" + txtCode.Text + "','" + Convert.ToInt64(txtCost.Text) + "','" + Convert.ToInt64(txtDiscount_Price.Text) + "','" + Convert.ToInt64(txtAdded_Price.Text) + "','" + Convert.ToInt64(txtTotal.Text) + "',N'" + clsFunction.User_Real_Name + "','" + Ware_Rec_ID + "',N'" + txtNotice.Text + "')";
                            query2 = "INSERT INTO tbl_Header_TurnTransfer (ID, Code, Date, Transferee, Notice, Store, Type, Validation) VALUES ('" + Ware_Rec_ID + "','" + txtCode.Text + "','" + txtDate.Text + "',N'" + txtDelivery.Text + "',N'" + "فاکتور برگشت از خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "','" + Store_Code + "',4,'" + "خیر" + "')";
                            if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true)
                            {
                                for (int i = 0; i < dgvStore.Rows.Count; i++)
                                {
                                    try
                                    {
                                        query5 = "INSERT INTO tbl_Body_Back_Buy_Factor (ID, P_Code, Entity, P_Cost, Total) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                        query3 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtName.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "فاکتور برگشت خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "',4,'" + Convert.ToInt32(Ware_Rec_ID) + "','" + Store_Code + "')";
                                        query4 = "INSERT INTO tbl_Body_TurnTransfer (ID, P_Code, Entity) VALUES ('" + Ware_Rec_ID + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "')";
                                        query6 = "UPDATE tbl_Product SET Store = '" + Store_Code + "', Buy_Price = '" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "' WHERE P_Code = '" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "'";
                                        if (clsFunction.Execute(dataconnection, query5) == true && clsFunction.Execute(dataconnection, query4) == true)
                                        {
                                            if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query6) == true)
                                            {
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                if (txtSett_Date.Text != "    /  /")
                                {
                                    Get_Max_Reminder_ID();
                                    query7 = "INSERT INTO tbl_Reminder (ID, Title, Body, Ins_Date, Remind_Date) VALUES ('" + Reminder_ID + "',N'" + "تسویه با بستانکاران تجاری" + "',N'" + "تسویه با " + txtName.Text + " " + "بابت فاکتور برگشت از خرید شماره " + " " + txtID.Text + " " + "مورخ " + txtDate.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + txtSett_Date.Text + "')";
                                    if (clsFunction.Execute(dataconnection, query7) == true)
                                    {
                                    }
                                }
                                int Cost_Discount = Convert.ToInt32(txtCost.Text) - Convert.ToInt32(txtDiscount_Price.Text);
                                Get_Max_Doc_Number();
                                query8 = "INSERT INTO tbl_Transaction (Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtCost.Text) + "',N'" + "فاکتور برگشت از خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "70103" + "','" + 4 + "','" + txtID.Text + "')";
                                query9 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + Convert.ToInt64(Cost_Discount) + "','" + 0 + "',N'" + "فاکتور برگشت از خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30201" + "','" + 4 + "','" + txtID.Text + "')";
                                if (clsFunction.Execute(dataconnection, query8) == true && clsFunction.Execute(dataconnection, query9) == true)
                                {
                                    if (Convert.ToInt32(txtAdded_Price.Text) != 0)
                                    {
                                        query10 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + Convert.ToInt64(txtAdded_Price.Text) + "','" + 0 + "',N'" + "هزینه فاکتور برگشت از خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30201" + "','" + 4 + "','" + txtID.Text + "')";
                                        if (clsFunction.Execute(dataconnection, query10) == true)
                                        {
                                        }
                                    }
                                }
                                Document();
                                this.Close();
                            }
                        }
                        else if (op == "Edit")
                        {
                            Delete_Data(Convert.ToInt32(txtID.Text));
                            query1 = "UPDATE tbl_Header_Back_Buy_Factor SET Date = '" + txtDate.Text + "', Reciver = N'" + txtDelivery.Text + "', Store = '" + Store_Code + "', Sett_Date = '" + txtSett_Date.Text + "', Bill = N'" + txtBill.Text + "', Seller_Code = '" + txtCode.Text + "', Price = '" + Convert.ToInt64(txtCost.Text) + "', Discount = '" + Convert.ToInt64(txtDiscount_Price.Text) + "', Added_Value = '" + Convert.ToInt64(txtAdded_Price.Text) + "', Total = '" + Convert.ToInt64(txtTotal.Text) + "',  Notice = N'" + txtNotice.Text + "' WHERE ID = '" + Convert.ToInt64(txtID.Text) + "'";
                            query2 = "UPDATE tbl_Header_TurnTransfer SET Code = '" + txtCode.Text + "', Date = '" + txtDate.Text + "', Transferee = N'" + txtDelivery.Text + "', Notice = N'" + "فاکتور برگشت خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "', Store = '" + Store_Code + "' WHERE ID = '" + Ware_Rec_ID_Edit + "'";
                            if (clsFunction.Execute(dataconnection, query2) == true && clsFunction.Execute(dataconnection, query1) == true)
                            {
                                for (int i = 0; i < dgvStore.Rows.Count; i++)
                                {
                                    try
                                    {
                                        query5 = "INSERT INTO tbl_Body_Back_Buy_Factor (ID, P_Code, Entity, P_Cost, Total) VALUES ('" + Convert.ToInt64(txtID.Text) + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "','" + Convert.ToInt64(dgvStore.Rows[i].Cells["Cost"].Value) + "')";
                                        query3 = "INSERT INTO tbl_Tour_Of_Product (P_Code, Date, Destination, Issued, Notice, Parent, Parent_Code, Store) VALUES ('" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + txtDate.Text + "','" + txtName.Text + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "',N'" + "فاکتور برگشت خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "',4,'" + Convert.ToInt32(Ware_Rec_ID_Edit) + "','" + Store_Code + "')";
                                        query4 = "INSERT INTO tbl_Body_TurnTransfer (ID, P_Code, Entity) VALUES ('" + Ware_Rec_ID_Edit + "','" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "','" + float.Parse(dgvStore.Rows[i].Cells["Entity"].Value.ToString()) + "')";
                                        query6 = "UPDATE tbl_Product SET Store = '" + Store_Code + "', Buy_Price = '" + Convert.ToInt64(dgvStore.Rows[i].Cells["Buy_Price"].Value) + "' WHERE P_Code = '" + Convert.ToInt32(dgvStore.Rows[i].Cells["Code"].Value) + "'";
                                        if (clsFunction.Execute(dataconnection, query5) == true && clsFunction.Execute(dataconnection, query4) == true)
                                        {
                                            if (clsFunction.Execute(dataconnection, query3) == true && clsFunction.Execute(dataconnection, query6) == true)
                                            {
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                int Cost_Discount = Convert.ToInt32(txtCost.Text) - Convert.ToInt32(txtDiscount_Price.Text);
                                Get_Max_Doc_Number();
                                query8 = "INSERT INTO tbl_Transaction (Bedehkar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + Convert.ToInt64(txtCost.Text) + "',N'" + "فاکتور برگشت از خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "70103" + "','" + 4 + "','" + txtID.Text + "')";
                                query9 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + 0 + "','" + Convert.ToInt64(Cost_Discount) + "',N'" + "فاکتور برگشت از خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30201" + "','" + 4 + "','" + txtID.Text + "')";
                                if (clsFunction.Execute(dataconnection, query8) == true && clsFunction.Execute(dataconnection, query9) == true)
                                {
                                    if (Convert.ToInt32(txtAdded_Price.Text) != 0)
                                    {
                                        query10 = "INSERT INTO tbl_Transaction (Code, Bedehkar, Bestankar, Notice, Date, Time, Doc_Number, Moeen, Parent, Parent_Code) VALUES ('" + txtCode.Text + "','" + 0 + "','" + Convert.ToInt64(txtAdded_Price.Text) + "',N'" + "هزینه فاکتور برگشت از خرید به شماره " + txtID.Text + " " + "مورخ " + txtDate.Text + " " + "توضیحات: " + txtNotice.Text + "','" + txtDate.Text + "','" + System.DateTime.Now.ToLongTimeString() + "','" + Doc_Number + "','" + "30201" + "','" + 4 + "','" + txtID.Text + "')";
                                        if (clsFunction.Execute(dataconnection, query10) == true)
                                        {
                                        }
                                    }
                                }
                                Document_Edit();
                                this.Close();
                            }
                        }
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

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStore.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void cmbPrice_Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataconnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Code FROM tbl_Price_Pattern WHERE Description LIKE N'" + cmbPrice_Pattern.Text + "'", dataconnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Pattern_Code = (string)dr["Code"];
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

        private void cmbStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtSett_Date.Focus();
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

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtCode.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDelivery.Focus();
        }

        private void txtDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbStore.Focus();
        }

        private void txtSett_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtBill.Focus();
        }

        private void txtBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbPrice_Pattern.Focus();
        }

        private void cmbPrice_Pattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDescount_Percent.Focus();
        }

        private void txtDescount_Percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtDiscount_Price.Focus();
        }

        private void txtDiscount_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtAdded_Percent.Focus();
        }

        private void txtAdded_Percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtAdded_Price.Focus();
        }

        private void txtAdded_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtNotice.Focus();
        }

        private void txtNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void txtDescount_Percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtAdded_Percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
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

        private void txtDiscount_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtAdded_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
            {
                e.KeyChar = Convert.ToChar(Keys.None);
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

        private void picShow_Reminder_Click(object sender, EventArgs e)
        {
            new frmShow_Remind().ShowDialog();
        }
    }
}
