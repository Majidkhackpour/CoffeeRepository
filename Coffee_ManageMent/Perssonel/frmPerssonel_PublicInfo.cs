using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;

namespace Coffee_ManageMent
{
    public partial class frmPerssonel_PublicInfo : Form
    {
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

        public DataLayer.Models.Perssonel.Perssonel SetData(DataLayer.Models.Perssonel.Perssonel _perssonel)
        {
            try
            {
                _perssonel.Code = txtCode.Text;
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
                cmbGroup.DataSource = lst;
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
        }
    }
}
