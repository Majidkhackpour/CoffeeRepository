using System;
using System.Drawing;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using BussinesLayer.Banks;
using Coffee_ManageMent.Hesab;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;

namespace Coffee_ManageMent.BankHesab
{
    public partial class frmBank : Form
    {
        private MoeinBussines _moein;
        private BanksBussines bank;
        public frmBank()
        {
            InitializeComponent();
            bank = new BanksBussines();
        }

        public frmBank(Guid bankGuid, bool Is_Show)
        {
            InitializeComponent();
            bank = BanksBussines.Get(bankGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
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
        private void LoadType()
        {
            try
            {
                cmbType.Items.Clear();
                cmbType.Items.Add(EnumBankHesabType.Jari.GetDisplay());
                cmbType.Items.Add(EnumBankHesabType.QarzolHasane.GetDisplay());
                cmbType.Items.Add(EnumBankHesabType.PasAndaz.GetDisplay());
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        private void Set_Data()
        {
            LoadType();
            LoadMahiat();
            lblCode.Text = AccountGroupBussines.Get((int)HesabType.Bank).Aouth_Code;
            txtDescription.Text = bank.Description;
            txtName.Text = bank.Name;
            chbPoss.Checked = bank.Poss;
            txtCode.Text = bank.HalfCode;
            txtDateEftetah.Value.FarsiSelectedDate = bank.DateEftetah;
            cmbType.SelectedIndex = (int) bank.Type;
            txtCodeShobe.Text = bank.ShobeCode;
            txtNameShobe.Text = bank.ShobeName;
            txtSahebHesab.Text = bank.DarandeName;
            _moein = MoeinBussines.Get(bank.MoeinAmountAvalDore);
            txtMoeinName.Text = _moein?.Name ?? "";
            txtMoeinCode.Text = _moein?.Code ?? "";
            txtAmount.Text = (Math.Abs(bank.AmountAvalDore)).ToString();
            if (bank.AmountAvalDore < 0)
                cmbAmountMahiat.SelectedIndex = 1;
            if (bank.AmountAvalDore == 0)
                cmbAmountMahiat.SelectedIndex = 0;
            if (bank.AmountAvalDore > 0)
                cmbAmountMahiat.SelectedIndex = 2;
            if (bank.Guid == Guid.Empty)
            {
                NewCode();
            }
        }
        private void frmBank_Load(object sender, EventArgs e)
        {
            Set_Data();
        }

        private void NewCode()
        {
            try
            {
                var groupGuid = AccountGroupBussines.Get((int)HesabType.Bank).Guid;
                txtCode.Text = AccountBussines.NewCode(groupGuid);
            }
            catch (Exception exception)
            {
                txtCode.Text = "0001";
            }
        }
        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCode);
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtName);
        }

        private void txtCodeShobe_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCodeShobe);
        }

        private void txtNameShobe_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtNameShobe);
        }

        private void txtSahebHesab_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtSahebHesab);
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtAmount);
        }

        private void txtMoeinCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtMoeinCode);
        }

        private void txtMoeinName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtMoeinName);
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtDescription);
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtDescription);
        }

        private void txtMoeinName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtMoeinName);
        }

        private void txtMoeinCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtMoeinCode);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtAmount);
        }

        private void txtSahebHesab_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtSahebHesab);
        }

        private void txtCodeShobe_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCodeShobe);
        }

        private void txtNameShobe_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtNameShobe);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtName);
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCode);
        }

        private void txtMoeinCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var a = MoeinBussines.GetByCode(txtMoeinCode.Text.Trim());
                txtMoeinName.Text = a?.Name ?? "";
                _moein = a;
            }
            catch
            {
                txtMoeinName.Text = "";
                _moein.Guid = Guid.Empty;
            }
        }

        private void btnSearchMoein_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new frmShow_MoeinHesab(true);
                if (f.ShowDialog() != DialogResult.OK) return;
                _moein = MoeinBussines.Get(f.SelectedGuid);
                txtMoeinCode.Text = _moein?.Code ?? "";
                txtMoeinName.Text = _moein?.Name ?? "";
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtAmount);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.Enabled = false;
                if (bank.Guid == Guid.Empty)
                {
                    bank.DateSabt = DateConvertor.M2SH(DateTime.Now);
                    bank.Guid = Guid.NewGuid();
                }

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب را وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (txtCode.Text.Length > 4 || txtCode.Text.Length < 4)
                {
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "حتما باید چهار کاراکتر به عنوان کد حساب کل وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (!AccountBussines.Check_Code(lblCode.Text + txtCode.Text.Trim(), bank.Guid))
                {
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }


                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "عنوان حساب را وارد نمایید");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (!AccountBussines.Check_Name(txtName.Text.Trim(), bank.Guid))
                {
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (txtAmount.Text.ParseToInt() != 0 && bank.MoeinAmountAvalDore == Guid.Empty)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "معین حساب مانده اول دوره بانک مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }
                bank.Code = lblCode.Text + txtCode.Text;
                bank.HalfCode = txtCode.Text;
                bank.Description = txtDescription.Text;
                bank.Name = txtName.Text;
                bank.Status = true;
                bank.MoeinAmountAvalDore = _moein?.Guid??Guid.Empty;
                bank.DarandeName = txtSahebHesab.Text;
                bank.DateEftetah = txtDateEftetah.Value.FarsiSelectedDate;
                bank.HesabNumber = txtHesabNumber.Text;
                bank.Poss = chbPoss.Checked;
                bank.ShobeCode = txtCodeShobe.Text;
                bank.ShobeName = txtNameShobe.Text;
                bank.Type = (EnumBankHesabType) cmbType.SelectedIndex;
                bank.AmountAvalDore= txtAmount.Text.Replace(",", "").ParseToDecimal();

                if (bank.Save())
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                    f.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                var frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
            finally
            {
                btnFinish.Enabled = true;
            }
        }

        private void txtHesabNumber_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtHesabNumber);
        }

        private void txtHesabNumber_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtHesabNumber);
        }
    }
}
