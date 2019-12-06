using System;
using System.Drawing;
using System.Windows.Forms;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmPerssonel_Sallary : Form
    {
        public frmPerssonel_Sallary()
        {
            InitializeComponent();
        }
        private class NestedCallInfo
        {
            internal static frmPerssonel_Sallary perssonelSallaryInfo = new frmPerssonel_Sallary();

            public NestedCallInfo()
            {
            }
        }
        private void Calculate_Sallry()
        {
            try
            {
                var min = 0;
                if (txtMinInDay.Text != "0" || txtMinInDay.Text != "")
                {
                    float a = float.Parse(txtSallaryPerHour.Text) / 60;
                    var b = txtMinInDay.Text.ParseToInt();
                    min = (int)(a * b);
                }

                var rightHousing = txtRightHouse.Text.Replace(",", "").ParseToDecimal();
                var rightChild = txtRightChild.Text.Replace(",", "").ParseToDecimal();
                var baseSallary = (txtHourInDay.Text.Replace(",", "").ParseToLong() * 30 *
                                   txtSallaryPerHour.Text.Replace(",", "").ParseToLong()) + min;
                var benLaborer = txtBenLaborer.Text.Replace(",", "").ParseToDecimal();
                var otherSallary = txtOtherSallary.Text.Replace(",", "").ParseToDecimal();
                var inssurance = txtInsurance.Text.Replace(",", "").ParseToDecimal();
                var sallary = baseSallary + rightChild + rightHousing + benLaborer +
                               otherSallary;
                txtBaseSallary.Text = baseSallary.ToString();
                txtFullSallary.Text = (sallary - inssurance).ThreeSeparator();
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        public static frmPerssonel_Sallary SallaryInfo => NestedCallInfo.perssonelSallaryInfo;
        public PerssonelBussines SetData(PerssonelBussines _perssonel)
        {
            try
            {
                _perssonel.HourPrice = txtSallaryPerHour.Text.ParseToDecimal();
                _perssonel.HouseRight = txtRightHouse.Text.ParseToDecimal();
                _perssonel.ChildRight = txtRightChild.Text.ParseToDecimal();
                _perssonel.BenLaborer = txtBenLaborer.Text.ParseToDecimal();
                _perssonel.Bime = txtInsurance.Text.ParseToDecimal();
                _perssonel.Eydi = txtEydi.Text.ParseToDecimal();
                _perssonel.OtherSallary = txtOtherSallary.Text.ParseToDecimal();
                _perssonel.BaseSallary = txtBaseSallary.Text.ParseToDecimal();
                _perssonel.FullSallary = txtFullSallary.Text.ParseToDecimal();
                _perssonel.YearLeaving = txtLeaveInYear.Text.ParseToInt();
                _perssonel.KasrPrice = txtKasePrice.Text.ParseToDecimal();
                _perssonel.EzafePrice = txtEzafePrice.Text.ParseToDecimal();
                _perssonel.HourInDay = txtHourInDay.Text.ParseToInt();
                _perssonel.MinInDay = txtMinInDay.Text.ParseToInt();
                _perssonel.StartHour = txtStartHour.Text.ParseToInt();
                _perssonel.StartMin = txtStartMin.Text.ParseToInt();
                _perssonel.EndHour = txtEndHour.Text.ParseToInt();
                _perssonel.EndMin = txtEndMin.Text.ParseToInt();
                return _perssonel;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
        public void FillData(PerssonelBussines _perssonel)
        {
            try
            {
                txtSallaryPerHour.Text = _perssonel.HourPrice.ToString();
                txtRightHouse.Text = _perssonel.HouseRight.ToString();
                txtRightChild.Text = _perssonel.ChildRight.ToString();
                txtBenLaborer.Text = _perssonel.BenLaborer.ToString();
                txtInsurance.Text = _perssonel.Bime.ToString();
                txtEydi.Text = _perssonel.Eydi.ToString();
                txtOtherSallary.Text = _perssonel.OtherSallary.ToString();
                txtBaseSallary.Text = _perssonel.BaseSallary.ToString();
                txtFullSallary.Text = _perssonel.FullSallary.ToString();
                txtLeaveInYear.Text = _perssonel.YearLeaving.ToString();
                txtKasePrice.Text = _perssonel.KasrPrice.ToString();
                txtEzafePrice.Text = _perssonel.EzafePrice.ToString();
                txtHourInDay.Text = _perssonel.HourInDay.ToString();
                txtMinInDay.Text = _perssonel.MinInDay.ToString();
                txtStartHour.Text = _perssonel.StartHour.ToString();
                txtStartMin.Text = _perssonel.StartMin.ToString();
                txtEndHour.Text = _perssonel.EndHour.ToString();
                txtEndMin.Text = _perssonel.EndMin.ToString();
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void TxtSallaryPerHour_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtSallaryPerHour);
        }

        private void TxtRightChild_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtRightChild);
        }

        private void TxtInsurance_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtInsurance);
        }

        private void TxtOtherSallary_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtOtherSallary);
        }

        private void TxtMinInDay_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtMinInDay);
        }

        private void TxtHourInDay_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtHourInDay);
        }

        private void TxtStartMin_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtStartMin);
        }

        private void TxtStartHour_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtStartHour);
        }

        private void TxtEndMin_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEndMin);
        }

        private void TxtEndHour_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEndHour);
        }

        private void TxtLeaveInYear_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtLeaveInYear);
        }

        private void TxtKasePrice_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtKasePrice);
        }

        private void TxtEzafePrice_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEzafePrice);
        }

        private void TxtFullSallary_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtFullSallary);
        }

        private void TxtBaseSallary_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtBaseSallary);
        }

        private void TxtEydi_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEydi);
        }

        private void TxtBenLaborer_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtBenLaborer);
        }

        private void TxtRightHouse_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtRightHouse);
        }

        private void TxtRightHouse_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtRightHouse);
        }

        private void TxtBenLaborer_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtBenLaborer);
        }

        private void TxtEydi_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEydi);
        }

        private void TxtBaseSallary_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtBaseSallary);
        }

        private void TxtFullSallary_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtFullSallary);
        }

        private void TxtKasePrice_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtKasePrice);
        }

        private void TxtEzafePrice_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEzafePrice);
        }

        private void TxtLeaveInYear_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtLeaveInYear);
        }

        private void TxtEndHour_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEndHour);
        }

        private void TxtEndMin_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEndMin);
        }

        private void TxtStartHour_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtStartHour);
        }

        private void TxtStartMin_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtStartMin);
        }

        private void TxtHourInDay_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtHourInDay);
        }

        private void TxtMinInDay_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtMinInDay);
        }

        private void TxtOtherSallary_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtOtherSallary);
        }

        private void TxtInsurance_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtInsurance);
        }

        private void TxtRightChild_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtRightChild);
        }

        private void TxtSallaryPerHour_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtSallaryPerHour);
        }

        private void TxtSallaryPerHour_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtSallaryPerHour);
            Calculate_Sallry();
        }

        private void TxtRightHouse_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtRightHouse);
            Calculate_Sallry();
        }

        private void TxtBenLaborer_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtBenLaborer);
            Calculate_Sallry();
        }

        private void TxtRightChild_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtRightChild);
            Calculate_Sallry();
        }

        private void TxtInsurance_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtInsurance);
            Calculate_Sallry();
        }

        private void TxtEydi_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtEydi);
        }

        private void TxtBaseSallary_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtBaseSallary);
        }

        private void TxtOtherSallary_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtOtherSallary);
            Calculate_Sallry();
        }

        private void TxtKasePrice_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtKasePrice);
        }

        private void TxtEzafePrice_TextChanged(object sender, EventArgs e)
        {
            txtSetter.Three_Ziro(txtEzafePrice);
        }

        private void TxtHourInDay_TextChanged(object sender, EventArgs e)
        {
            if (txtHourInDay.Text.ParseToInt() >= 24)
                txtHourInDay.Text = "24";
            Calculate_Sallry();
        }

        private void TxtMinInDay_TextChanged(object sender, EventArgs e)
        {
            if (txtMinInDay.Text.ParseToInt() >= 60)
            {
                txtHourInDay.Text = (txtHourInDay.Text.ParseToInt() + 1).ToString();
                txtMinInDay.Text = (txtMinInDay.Text.ParseToInt() - 60).ToString();
            }
            Calculate_Sallry();
        }

        private void TxtStartMin_TextChanged(object sender, EventArgs e)
        {
            if (txtStartMin.Text.ParseToInt() >= 60)
            {
                txtStartHour.Text = (txtStartHour.Text.ParseToInt() + 1).ToString();
                txtStartMin.Text = (txtStartMin.Text.ParseToInt() - 60).ToString();
            }
        }

        private void TxtEndMin_TextChanged(object sender, EventArgs e)
        {
            if (txtEndMin.Text.ParseToInt() >= 60)
            {
                txtEndHour.Text = (txtEndHour.Text.ParseToInt() + 1).ToString();
                txtEndMin.Text = (txtEndMin.Text.ParseToInt() - 60).ToString();
            }
        }

        private void TxtStartHour_TextChanged(object sender, EventArgs e)
        {
            if (txtStartHour.Text.ParseToInt() >= 24)
                txtStartHour.Text = "24";
        }

        private void TxtEndHour_TextChanged(object sender, EventArgs e)
        {
            if (txtEndHour.Text.ParseToInt() >= 24)
                txtEndHour.Text = "24";
        }
    }
}
