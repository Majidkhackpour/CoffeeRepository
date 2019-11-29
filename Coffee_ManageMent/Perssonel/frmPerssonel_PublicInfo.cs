using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Hesab;
using Coffee_ManageMent.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Models.Account;

namespace Coffee_ManageMent
{
    public partial class frmPerssonel_PublicInfo : Form
    {
        private MoeinHesab moein = new MoeinHesab();
        public frmPerssonel_PublicInfo()
        {
            InitializeComponent();
        }
        private class NestedPublicInfo
        {
            internal static frmPerssonel_PublicInfo perssonelPublicInfo =  new frmPerssonel_PublicInfo();

            public NestedPublicInfo()
            {
            }
        }

        public static frmPerssonel_PublicInfo PublicInfo => NestedPublicInfo.perssonelPublicInfo;

        private void SetPerssonelCode()
        {
            try
            {
                txtPerssonelCode.Text = lblCode.Text + txtCode.Text;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        public DataLayer.Models.Perssonel.Perssonel SetData(DataLayer.Models.Perssonel.Perssonel _perssonel)
        {
            try
            {
                EnumGender gender;
                if (rbtnMale.Checked)
                    gender = EnumGender.Male;
                else
                    gender = EnumGender.Female;
                _perssonel.Code = lblCode.Text + txtCode.Text;
                _perssonel.PerssonelGroup = (Guid) cmbGroup.SelectedValue;
                _perssonel.PerssonelCode = txtPerssonelCode.Text;
                _perssonel.DateBirth = txtDateBirth.Value.FarsiSelectedDate;
                _perssonel.Name = txtName.Text.Trim();
                _perssonel.Description = txtDescription.Text;
                _perssonel.NationalCode = txtNatCode.Text;
                _perssonel.FatherName = txtFatherName.Text;
                _perssonel.PlaceBirth = txtPlaceBirth.Text;
                _perssonel.Gender = gender;
                _perssonel.MoeinAvalDore = moein?.Guid??Guid.Empty;
                var amount = txtAmount.Text.Replace(",","").ParseToDecimal();
                switch (cmbAmountMahiat.SelectedIndex)
                {
                    case 0:
                        _perssonel.Amount_AvalDore = 0;
                        break;
                    case 1:
                        _perssonel.Amount_AvalDore = -amount;
                        break;
                    case 2:
                        _perssonel.Amount_AvalDore = +amount;
                        break;
                }
                return _perssonel;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
        public void FillData(DataLayer.Models.Perssonel.Perssonel _perssonel)
        {
            try
            {
                lblCode.Text = AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Aouth_Code;
                LoadGroups();
                LoadMahiat();
                txtCode.Text = _perssonel.Code;
                txtName.Text = _perssonel.Name;
                txtAmount.Text = _perssonel.Amount_AvalDore.ToString();
                txtDateBirth.Value.FarsiSelectedDate = _perssonel.DateBirth;
                txtDescription.Text = _perssonel.Description;
                txtNatCode.Text = _perssonel.NationalCode;
                txtPerssonelCode.Text = _perssonel.PerssonelCode;
                txtPlaceBirth.Text = _perssonel.PlaceBirth;
                moein = MoeinBussines.Get(_perssonel.MoeinAvalDore);
                txtMoeinName.Text = moein?.Name??"";
                txtMoeinCode.Text = moein?.Code??"";
                if (_perssonel.PerssonelGroup != Guid.Empty)
                    cmbGroup.SelectedValue = _perssonel.PerssonelGroup;
                else
                    cmbGroup.SelectedIndex = 0;
                var gender = _perssonel.Gender;
                if (gender == null)
                    rbtnMale.Checked = true;
                else
                {
                    if (gender == EnumGender.Male)
                        rbtnMale.Checked = true;
                    if (gender == EnumGender.Female)
                        rbtnFemale.Checked = true;
                }
                if (_perssonel.Guid == Guid.Empty)
                {
                    NewCode();
                    SetPerssonelCode();
                }
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
                var lst = PerssonelGroupBussines.GetAll().OrderBy(q => q.Name).ToList();
                PerssonelGroupBindingSource.DataSource = lst;
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
                var groupGuid = AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Guid;
                txtCode.Text = AccountBussines.NewCode(groupGuid);
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

        private void TxtPerssonelCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtPerssonelCode);
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtAmount);
        }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtDescription);
        }

        private void TxtPlaceBirth_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtPlaceBirth);
        }

        private void TxtFatherName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtFatherName);
        }

        private void TxtNatCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtNatCode);
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtName);
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtName);
        }

        private void TxtNatCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtNatCode);
        }

        private void TxtFatherName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtFatherName);
        }

        private void TxtPlaceBirth_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtPlaceBirth);
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtDescription);
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtAmount);
        }

        private void TxtPerssonelCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtPerssonelCode);
        }

        private void TxtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCode);
            SetPerssonelCode();
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtAmount);
        }

        public void FrmPerssonel_PublicInfo_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender,e,frmPerssonelMain.MainInfo.btnFinish);
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
                txtMoeinName.Text = a.Name;
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
                frmShow_PerssonelGroup f = new frmShow_PerssonelGroup(true);
                if (f.ShowDialog()==DialogResult.OK)
                {
                    cmbGroup.SelectedValue = f.SelectedGuid;
                }
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
    }
}
