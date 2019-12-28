using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using BussinesLayer.Sellers;
using Coffee_ManageMent.Hesab;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;

namespace Coffee_ManageMent.Sellers
{
    public partial class frmSeller_PublicInfo : Form
    {
        private MoeinBussines moein = new MoeinBussines();
        public frmSeller_PublicInfo()
        {
            InitializeComponent();
        }
        private class NestedPublicInfo
        {
            internal static frmSeller_PublicInfo sellerPublicInfo = new frmSeller_PublicInfo();

            public NestedPublicInfo()
            {
            }
        }

        public static frmSeller_PublicInfo PublicInfo => NestedPublicInfo.sellerPublicInfo;

        private void frmSeller_Load(object sender, EventArgs e)
        {

        }
        public SellerBussines SetData(SellerBussines _seller)
        {
            try
            {
                _seller.Code = lblCode.Text + txtCode.Text;
                _seller.Half_Code = txtCode.Text;
                _seller.Name = txtName.Text.Trim();
                _seller.Description = txtDescription.Text;
                _seller.RespName = txtResName.Text;
                _seller.EconomyCode = txtEcoCode.Text;
                _seller.MoeinAmountAvalDore = moein?.Guid ?? Guid.Empty;
                var amount = txtAmount.Text.Replace(",", "").ParseToDecimal();
                switch (cmbAmountMahiat.SelectedIndex)
                {
                    case 0:
                        _seller.Amount_AvalDore = 0;
                        break;
                    case 1:
                        _seller.Amount_AvalDore = -amount;
                        break;
                    case 2:
                        _seller.Amount_AvalDore = +amount;
                        break;
                }

                _seller.Type = cmbType.SelectedIndex == 0 ? SellerType.A_Haqiqi : SellerType.A_Hoqouqi;
                return _seller;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
        public void FillData(SellerBussines _seller)
        {
            try
            {
                cmbType.Items.Clear();
                cmbType.Items.Add(SellerType.A_Haqiqi.GetDisplay());
                cmbType.Items.Add(SellerType.A_Hoqouqi.GetDisplay());
                cmbType.SelectedIndex = 0;
                LoadMahiat();
                txtCode.Text = _seller.Half_Code;
                txtName.Text = _seller.Name;
                txtDescription.Text = _seller.Description;
                txtResName.Text = _seller.RespName;
                txtEcoCode.Text = _seller.EconomyCode;
                txtAmount.Text = (Math.Abs(_seller.Amount_AvalDore)).ToString();
                moein = MoeinBussines.Get(_seller.MoeinAmountAvalDore);
                txtMoeinName.Text = moein?.Name ?? "";
                txtMoeinCode.Text = moein?.Code ?? "";
                if (_seller.Guid == Guid.Empty)
                    NewCode();

                if (_seller.Amount_AvalDore < 0)
                    cmbAmountMahiat.SelectedIndex = 1;
                if (_seller.Amount_AvalDore == 0)
                    cmbAmountMahiat.SelectedIndex = 0;
                if (_seller.Amount_AvalDore > 0)
                    cmbAmountMahiat.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
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
                    guid = AccountGroupBussines.Get((int) HesabType.A_Haqiqi).Guid;
                    lblCode.Text = AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Aouth_Code;
                }
                else
                {
                    guid = AccountGroupBussines.Get((int) HesabType.A_Hoqouqi).Guid;
                    lblCode.Text = AccountGroupBussines.Get((int)HesabType.A_Hoqouqi).Aouth_Code;
                }

                txtCode.Text = AccountBussines.NewCode(guid);
            }
            catch (Exception exception)
            {
                txtCode.Text = "0001";
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

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewCode();
        }

        private void TxtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCode);
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtName);
        }

        private void TxtResName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtResName);
        }

        private void TxtEcoCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEcoCode);
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtAmount);
        }

        private void TxtMoeinCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtMoeinCode);
        }

        private void TxtMoeinName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtMoeinName);
        }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtDescription);
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtDescription);
        }

        private void TxtMoeinName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtMoeinName);
        }

        private void TxtMoeinCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtMoeinCode);
        }

        private void TxtEcoCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEcoCode);
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtAmount);
        }

        private void TxtResName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtResName);
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtName);
        }

        private void TxtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCode);
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtAmount);
        }

        private void BtnSearchMoein_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_MoeinHesab f = new frmShow_MoeinHesab(true);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    moein = MoeinBussines.Get(f.SelectedGuid);
                    txtMoeinCode.Text = moein?.Code ?? "";
                    txtMoeinName.Text = moein?.Name ?? "";
                }
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
    }
}
