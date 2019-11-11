using System;
using System.Drawing;
using System.Windows.Forms;
using Coffee_ManageMent.Depot.AnbarGroup;
using Coffee_ManageMent.Depot.Anbars;
using Coffee_ManageMent.Hazine;
using Coffee_ManageMent.Hesab;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuAccount_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Account frm = new frmShow_Account();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                frm.ShowDialog();
            }
        }

        private void mnuStore_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Stores frm = new frmShow_Stores();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                frm.ShowDialog();
            }
        }

        private void mnuPerssonel_Click(object sender, EventArgs e)
        {
            //  new frmShow_Perssonel().ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // clsFunction.Switch_Language_To_Persian();
        }

        private void mnuContract_Click(object sender, EventArgs e)
        {
            //  new frmShow_Contract().ShowDialog();
        }

        private void mnuSeller_Click(object sender, EventArgs e)
        {
            // new frmShow_Seller().ShowDialog();
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            //  new frmShow_Customer().ShowDialog();
        }

        private void mnuSafe_Click(object sender, EventArgs e)
        {
            // new frmShow_Safe().ShowDialog();
        }

        private void mnuCurrent_Safe_Click(object sender, EventArgs e)
        {
            //  new frmCurrent_Safe().ShowDialog();
        }

        private void mnuBank_Click(object sender, EventArgs e)
        {
            // new frmShow_Bank().ShowDialog();
        }

        private void mnuCurrent_Bank_Click(object sender, EventArgs e)
        {
            // new frmCurrent_Bank().ShowDialog();
        }

        private void mnuCheck_Mng_Click(object sender, EventArgs e)
        {
            //  new frmShow_Check().ShowDialog();
        }

        private void mnuDiff_Account_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Kol frm = new frmShow_Kol();
                frm.ShowDialog();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void mnuTables_Click(object sender, EventArgs e)
        {
            //  new frmShow_Tables().ShowDialog();
        }

        private void mnuProduct_Type_Click(object sender, EventArgs e)
        {
            // new frmShow_Product_Type().ShowDialog();
        }

        private void mnuUnit_Click(object sender, EventArgs e)
        {
            // new frmUnit().ShowDialog();
        }

        private void mnuProduct_Setting_Click(object sender, EventArgs e)
        {
            //  new frmProduct_Setting().ShowDialog();
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            // new frmShow_Product().ShowDialog();
        }

        private void mnuBuy_Price_Click(object sender, EventArgs e)
        {
            //frmShow_Price_Pattern f = new frmShow_Price_Pattern();
            //f.op = "Buy";
            //f.ShowDialog();
        }

        private void mnuSell_Price_Click(object sender, EventArgs e)
        {
            //frmShow_Price_Pattern f = new frmShow_Price_Pattern();
            //f.op = "Sell";
            //f.ShowDialog();
        }

        private void mnuCurrent_Buy_Pattern_Click(object sender, EventArgs e)
        {
            //frmCurrent_Pattern_Price f = new frmCurrent_Pattern_Price();
            //f.lblType.Text = "خرید";
            //f.Pattern_Type = "Buy";
            //f.ShowDialog();
        }

        private void mnuCurrent_Sell_Pattern_Click(object sender, EventArgs e)
        {
            //frmCurrent_Pattern_Price f = new frmCurrent_Pattern_Price();
            //f.lblType.Text = "فروش";
            //f.Pattern_Type = "Sell";
            //f.ShowDialog();
        }

        private void mnuTax_And_Com_Click(object sender, EventArgs e)
        {
            // new frmTax_And_Com_Price().ShowDialog();
        }

        private void mnuBrowser_Click(object sender, EventArgs e)
        {
            // new frmWeb_Browser().ShowDialog();
        }

        private void mnuProduction_Click(object sender, EventArgs e)
        {
            //  new frmShow_Production().ShowDialog();
        }

        private void mnuLoan_Click(object sender, EventArgs e)
        {
            // new frmShow_Loan().ShowDialog();
        }

        private void mnuDictionary_Click(object sender, EventArgs e)
        {
            //  new frmDictionary().ShowDialog();
        }

        private void mnuWifi_Click(object sender, EventArgs e)
        {
            //  new frmWifi().ShowDialog();
        }

        private void mnuWHR_Click(object sender, EventArgs e)
        {
            //  new frmShow_Warehouse_Receipt().ShowDialog();
        }

        private void mnuTurn_Receipt_Click(object sender, EventArgs e)
        {
            //  new frmShow_Turn_Receipt().ShowDialog();
        }

        private void mnuWareTransfer_Click(object sender, EventArgs e)
        {
            // new frmShow_Warehouse_Transfer().ShowDialog();
        }

        private void mnuTurn_Transfer_Click(object sender, EventArgs e)
        {
            //   new frmShow_Turn_Transfer().ShowDialog();
        }

        private void mnuTransfer_Order_Click(object sender, EventArgs e)
        {
            //  new frmShow_Transfer_Order().ShowDialog();
        }

        private void mnuAdjusted_Click(object sender, EventArgs e)
        {
            // new frmShow_Adjusted().ShowDialog();
        }

        private void mnuDoc_Valid_Click(object sender, EventArgs e)
        {
            //  new frmDocument_Validation().ShowDialog();
        }

        private void mnuBuy_Order_Click(object sender, EventArgs e)
        {
            //new frmShow_Buy_Order().ShowDialog();
        }

        private void mnuBuy_Factor_Click(object sender, EventArgs e)
        {
            //  new frmShow_Buy_Factor().ShowDialog();
        }

        private void mnuBack_Buy_Factor_Click(object sender, EventArgs e)
        {
            //  new frmShow_Back_Buy_Factor().ShowDialog();
        }

        private void mnuProduct_Production_Click(object sender, EventArgs e)
        {
            //  new frmShow_Product_Production().ShowDialog();
        }

        private void mnuSales_Factor_Setting_Click(object sender, EventArgs e)
        {
            //   new frmSetting_Sales_Factor().ShowDialog();
        }

        private void mnuIncome_Group_Click(object sender, EventArgs e)
        {
            //  new frmShow_Income_Group().ShowDialog();
        }

        private void mnuIncome_Click(object sender, EventArgs e)
        {
            //   new frmShow_Income().ShowDialog();
        }

        private void mnuSales_Factor_Click(object sender, EventArgs e)
        {
            //  new frmShow_Sales_Factor().ShowDialog();
        }

        private void mnuReturn_Of_Sales_Factor_Click(object sender, EventArgs e)
        {
            //  new frmShow_Return_Of_Sales_Factor().ShowDialog();
        }

        private void mnuDocument_Click(object sender, EventArgs e)
        {
            // new frmDocument().ShowDialog();
        }

        private void mnuCash_Op_Click(object sender, EventArgs e)
        {
            // new frmShow_Cash_Operation().ShowDialog();
        }

        private void mnuBank_OP_Click(object sender, EventArgs e)
        {
            //  new frmShow_Bank_Operation().ShowDialog();
        }

        private void mnuTable_Reservation_Click(object sender, EventArgs e)
        {
            //frmTable_Reservation f = new frmTable_Reservation();
            //f.Form_Load();
            //f.s_op = "Add";
            //f.ShowDialog();
        }

        private void mnuSales_Factor_Peygiri_Click(object sender, EventArgs e)
        {
            // new frmShow_Sales_Factor_Peygiri().ShowDialog();
        }

        private void mnuRecive_Check_Click(object sender, EventArgs e)
        {
            // new frmShow_Check_Daryaft().ShowDialog();
        }

        private void mnuPay_Check_Click(object sender, EventArgs e)
        {
            // new frmShow_Check_Pardakht().ShowDialog();
        }

        private void mnuPer_Log_Click(object sender, EventArgs e)
        {
            //  new frmLogPerssonel().ShowDialog();
        }

        private void mnuPer_Leave_Click(object sender, EventArgs e)
        {
            // new frmShow_Per_Leave().ShowDialog();
        }

        private void mnuCus_Club_Click(object sender, EventArgs e)
        {
            //  new frmShow_Customer_Club().ShowDialog();
        }

        private void mnuFestival_Click(object sender, EventArgs e)
        {
            //  new frmShow_Lottery().ShowDialog();
        }

        private void mnuPer_Factor_Click(object sender, EventArgs e)
        {
            // new frmShow_Per_Factor().ShowDialog();
        }

        private void mnuCus_Group_Click(object sender, EventArgs e)
        {
            //  new frmShow_Cus_Group().ShowDialog();
        }

        private void mnuCus_Install_Click(object sender, EventArgs e)
        {
            // new frmShow_Cus_Installment().ShowDialog();
        }

        private void mnuSMS_Click(object sender, EventArgs e)
        {
            // new frmShow_Panels().ShowDialog();
        }

        private void mnuTransfer_BedBes_Click(object sender, EventArgs e)
        {
            //  new frmShow_Transfer_BedBes().ShowDialog();
        }

        private void mnuTransfer_Bank_Click(object sender, EventArgs e)
        {
            // new frmTransfer_Bank().ShowDialog();
        }

        private void mnuTransfer_Safe_Click(object sender, EventArgs e)
        {
            // new frmTransfer_Safe().ShowDialog();
        }

        private void mnuHazine_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Hazine frm = new frmShow_Hazine();
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                frm.ShowDialog();
            }
        }

        private void MnuMoein_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_MoeinHesab frm = new frmShow_MoeinHesab();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                frm.ShowDialog();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new frmShow_AnbarGroup().ShowDialog();
        }
    }
}
