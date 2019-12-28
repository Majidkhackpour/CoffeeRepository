using System;
using System.Drawing;
using System.Windows.Forms;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using System.IO;
using BussinesLayer.Customer;
using BussinesLayer.Perssonel;
using DataLayer.BussinesLayer;

namespace Coffee_ManageMent.Customers
{
    public partial class frmCustomer_AouthInfo : Form
    {
        public frmCustomer_AouthInfo()
        {
            InitializeComponent();
        }

        private class NestedCallInfo
        {
            internal static frmCustomer_AouthInfo cusCallInfo = new frmCustomer_AouthInfo();

            public NestedCallInfo()
            {
            }
        }

        public static frmCustomer_AouthInfo AouthInfo => NestedCallInfo.cusCallInfo;

        public CustomersBussines SetData(CustomersBussines _cus)
        {
            try
            {
                _cus.HadeEtebar = txtHadeEtebar.Text.ParseToDecimal();
                _cus.Job = txtJob.Text;
                _cus.CompanyName = txtCompanyName.Text;
                _cus.ShomareSabt = txtShomareSabt.Text;
                _cus.EconomyNumber = txtEconomyCode.Text;
                _cus.ClubPoint = txtCusClubPoint.Text.ParseToInt();
                _cus.NahveAshnaei = txtNahveAshnaei.Text;
                _cus.HesabNumber1 = txtHesabNumber1.Text;
                _cus.HesabNumber2 = txtHesabNumber2.Text;
                _cus.CardNumber1 = txtCardNumber1.Text;
                _cus.CardNumber2 = txtCardNumber2.Text;
                _cus.PayType = rbtnNaqdi.Checked ? PayType.Naqdi : PayType.Etebari;
                _cus.SubCode = txtSubCode.Text;
                return _cus;
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
        public void FillData(CustomersBussines _cus)
        {
            try
            {
                txtHadeEtebar.Text = _cus.HadeEtebar.ToString();
                txtJob.Text = _cus.Job;
                txtCompanyName.Text = _cus.CompanyName;
                txtShomareSabt.Text = _cus.ShomareSabt;
                txtEconomyCode.Text = _cus.EconomyNumber;
                txtCusClubPoint.Text = _cus.ClubPoint.ToString();
                txtNahveAshnaei.Text = _cus.NahveAshnaei;
                txtHesabNumber1.Text = _cus.HesabNumber1;
                txtHesabNumber2.Text = _cus.HesabNumber2;
                txtCardNumber1.Text = _cus.CardNumber1;
                txtCardNumber2.Text = _cus.CardNumber2;
                txtSubCode.Text = _cus.SubCode;
                if (_cus.PayType == PayType.Naqdi)
                    rbtnNaqdi.Checked = true;
                else
                    rbtnEtebari.Checked = true;
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
      
        private void txtHadeEtebar_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtHadeEtebar);
        }

        private void txtJob_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtJob);
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCompanyName);
        }

        private void txtCompanyName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCompanyName);
        }

        private void txtEconomyCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEconomyCode);
        }

        private void txtShomareSabt_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtShomareSabt);
        }

        private void txtCusClubPoint_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCusClubPoint);
        }

        private void txtNahveAshnaei_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtNahveAshnaei);
        }

        private void txtHesabNumber1_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtHesabNumber1);
        }

        private void txtHesabNumber2_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtHesabNumber2);
        }

        private void txtCardNumber1_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCardNumber1);
        }

        private void txtCardNumber2_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCardNumber2);
        }

        private void txtCardNumber2_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCardNumber2);
        }

        private void txtCardNumber1_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCardNumber1);
        }

        private void txtHesabNumber1_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtHesabNumber1);
        }

        private void txtHesabNumber2_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtHesabNumber2);
        }

        private void txtNahveAshnaei_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtNahveAshnaei);
        }

        private void txtCusClubPoint_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCusClubPoint);
        }

        private void txtShomareSabt_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtShomareSabt);
        }

        private void txtEconomyCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEconomyCode);
        }

        private void txtJob_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtJob);
        }

        private void txtHadeEtebar_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtHadeEtebar);
        }

        private void txtSubCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtSubCode);
        }

        private void txtSubCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtSubCode);
        }

        private void txtHadeEtebar_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtHadeEtebar);
        }
    }
}
