using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using BussinesLayer.Customer;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Hesab;
using Coffee_ManageMent.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;

namespace Coffee_ManageMent.Customers
{
    public partial class frmCustomer_PublicInfo : Form
    {
        private MoeinBussines moein = new MoeinBussines();
        public frmCustomer_PublicInfo()
        {
            InitializeComponent();
        }
        private class NestedPublicInfo
        {
            internal static frmCustomer_PublicInfo perssonelPublicInfo = new frmCustomer_PublicInfo();

            public NestedPublicInfo()
            {
            }
        }

        public static frmCustomer_PublicInfo PublicInfo => NestedPublicInfo.perssonelPublicInfo;

        public CustomersBussines SetData(CustomersBussines _cus)
        {
            try
            {
                _cus.Code = lblCode.Text + txtCode.Text;
                _cus.Half_Code = txtCode.Text;
                _cus.GroupGuid = (Guid)cmbGroup.SelectedValue;
                _cus.DateBirth = txtDateBirth.Value.FarsiSelectedDate;
                _cus.Name = txtName.Text.Trim();
                _cus.Description = txtDescription.Text;
                _cus.MoeinAmountAvalDore = moein?.Guid ?? Guid.Empty;
                _cus.Type = cmbType.SelectedIndex == 0 ? SellerType.A_Haqiqi : SellerType.A_Hoqouqi;
                var amount = txtAmount.Text.Replace(",", "").ParseToDecimal();
                switch (cmbAmountMahiat.SelectedIndex)
                {
                    case 0:
                        _cus.Amount_AvalDore = 0;
                        break;
                    case 1:
                        _cus.Amount_AvalDore = -amount;
                        break;
                    case 2:
                        _cus.Amount_AvalDore = +amount;
                        break;
                }
                return _cus;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
        public void FillData(CustomersBussines _cus)
        {
            try
            {
                cmbType.Items.Clear();
                cmbType.Items.Add(SellerType.A_Haqiqi.GetDisplay());
                cmbType.Items.Add(SellerType.A_Hoqouqi.GetDisplay());
                cmbType.SelectedIndex = 0;
                lblCode.Text = AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Aouth_Code;
                LoadGroups();
                LoadMahiat();
                txtCode.Text = _cus.Half_Code;
                txtName.Text = _cus.Name;
                txtAmount.Text = (Math.Abs(_cus.Amount_AvalDore)).ToString();
                txtDateBirth.Value.FarsiSelectedDate = _cus.DateBirth;
                txtDescription.Text = _cus.Description;
                moein = MoeinBussines.Get(_cus.MoeinAmountAvalDore);
                txtMoeinName.Text = moein?.Name ?? "";
                txtMoeinCode.Text = moein?.Code ?? "";
                cmbType.SelectedIndex = _cus.Type == SellerType.A_Haqiqi ? 0 : 1;
                if (_cus.GroupGuid != Guid.Empty)
                    cmbGroup.SelectedValue = _cus.GroupGuid;
                else
                {
                    if (cusGroupBindingSource.Count > 0)
                        cmbGroup.SelectedIndex = 0;
                }

                if (_cus.Guid == Guid.Empty)
                {
                    NewCode();
                }

                if (_cus.Amount_AvalDore < 0)
                    cmbAmountMahiat.SelectedIndex = 1;
                if (_cus.Amount_AvalDore == 0)
                    cmbAmountMahiat.SelectedIndex = 0;
                if (_cus.Amount_AvalDore > 0)
                    cmbAmountMahiat.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        private void LoadGroups()
        {
            try
            {
                var lst = CustomerGroupBusiness.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                cusGroupBindingSource.DataSource = lst;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        private void LoadMahiat()
        {
            try
            {
                cmbAmountMahiat.Items.Clear();
                cmbAmountMahiat.Items.Add(EnumMahiatAshkhas.BiHesab.GetDisplay());
                cmbAmountMahiat.Items.Add(EnumMahiatAshkhas.Bedehkar.GetDisplay());
                cmbAmountMahiat.Items.Add(EnumMahiatAshkhas.Bestankar.GetDisplay());
                cmbAmountMahiat.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        private void NewCode()
        {
            try
            {
                Guid guid;
                if (cmbType.SelectedIndex == 0)
                {
                    guid = AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Guid;
                    lblCode.Text = AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Aouth_Code;
                }
                else
                {
                    guid = AccountGroupBussines.Get((int)HesabType.A_Hoqouqi).Guid;
                    lblCode.Text = AccountGroupBussines.Get((int)HesabType.A_Hoqouqi).Aouth_Code;
                }
                txtCode.Text = AccountBussines.NewCode(guid);
            }
            catch (Exception exception)
            {
                txtCode.Text = "0001";
            }
        }

        private void TxtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCode);
        }


        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtAmount);
        }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtDescription);
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtName);
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtName);
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtDescription);
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtAmount);
        }


        private void TxtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCode);
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtAmount);
        }

        public void FrmPerssonel_PublicInfo_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, frmPerssonelMain.MainInfo.btnFinish);
        }

        private void BtnSearchMoein_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new frmShow_MoeinHesab(true);
                if (f.ShowDialog() != DialogResult.OK) return;
                moein = MoeinBussines.Get(f.SelectedGuid);
                txtMoeinCode.Text = moein?.Code ?? "";
                txtMoeinName.Text = moein?.Name ?? "";
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void TxtMoeinCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var a = MoeinBussines.GetByCode(txtMoeinCode.Text.Trim());
                txtMoeinName.Text = a?.Name ?? "";
                moein = a;
            }
            catch
            {
                txtMoeinName.Text = "";
                moein.Guid = Guid.Empty;
            }
        }

        private void BtnSearchGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new frmShow_Cus_Group(true);
                if (f.ShowDialog() != DialogResult.OK) return;
                LoadGroups();
                cmbGroup.SelectedValue = f.SelectedGuid;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void FrmPerssonel_PublicInfo_Load(object sender, EventArgs e)
        {
            //ToolTip tt = new ToolTip();
            //tt.SetToolTip(btnSearchGroup,"جستجوی گروه پرسنل");
            //tt.SetToolTip(btnSearchMoein, "جستجوی حساب معین مانده اول دوره");
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewCode();
        }
    }
}
