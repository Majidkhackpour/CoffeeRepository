using System;
using System.Drawing;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using BussinesLayer.Sandooq;
using Coffee_ManageMent.Hesab;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;

namespace Coffee_ManageMent.Sandooq
{
    public partial class frmSafe : Form
    {
        private MoeinBussines _moein;
        private SafeBussines safe;
        public frmSafe()
        {
            InitializeComponent();
            safe = new SafeBussines();
        }
        public frmSafe(Guid safeGuid, bool Is_Show)
        {
            InitializeComponent();
            safe = SafeBussines.Get(safeGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }
        private void frmSafe_Load(object sender, EventArgs e)
        {
            Set_Data();
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
        private void Set_Data()
        {
            LoadMahiat();
            lblCode.Text = AccountGroupBussines.Get((int)HesabType.Sandouq).Aouth_Code;
            txtDescription.Text = safe.Description;
            txtName.Text = safe.Name;
            txtCode.Text = safe.HalfCode;
            _moein = MoeinBussines.Get(safe.MoeinAmountAvalDore);
            txtMoeinName.Text = _moein?.Name ?? "";
            txtMoeinCode.Text = _moein?.Code ?? "";
            txtAmount.Text = (Math.Abs(safe.AmountAvalDore)).ToString();
            if (safe.AmountAvalDore < 0)
                cmbAmountMahiat.SelectedIndex = 1;
            if (safe.AmountAvalDore == 0)
                cmbAmountMahiat.SelectedIndex = 0;
            if (safe.AmountAvalDore > 0)
                cmbAmountMahiat.SelectedIndex = 2;
            if (safe.Guid == Guid.Empty)
            {
                NewCode();
            }
        }
        private void NewCode()
        {
            try
            {
                var groupGuid = AccountGroupBussines.Get((int)HesabType.Sandouq).Guid;
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
                if (safe.Guid == Guid.Empty)
                {
                    safe.DateSabt = DateConvertor.M2SH(DateTime.Now);
                    safe.Guid = Guid.NewGuid();
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

                if (!AccountBussines.Check_Code(lblCode.Text + txtCode.Text.Trim(), safe.Guid))
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

                if (!AccountBussines.Check_Name(txtName.Text.Trim(), safe.Guid))
                {
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (txtAmount.Text.ParseToInt() != 0 && safe.MoeinAmountAvalDore == Guid.Empty)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "معین حساب مانده اول دوره صندوق مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }
                safe.Code = lblCode.Text + txtCode.Text;
                safe.HalfCode = txtCode.Text;
                safe.Description = txtDescription.Text;
                safe.Name = txtName.Text;
                safe.Status = true;
                safe.MoeinAmountAvalDore = _moein?.Guid ?? Guid.Empty;
                safe.AmountAvalDore = txtAmount.Text.Replace(",", "").ParseToDecimal();

                if (safe.Save())
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
    }
}
