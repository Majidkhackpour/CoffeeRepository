using System;
using System.Drawing;
using System.Windows.Forms;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using BussinesLayer.Perssonel;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmPerssonel_Contract : Form
    {
        public frmPerssonel_Contract()
        {
            InitializeComponent();
        }
        private class NestedCallInfo
        {
            internal static frmPerssonel_Contract perssonelContractInfo = new frmPerssonel_Contract();

            public NestedCallInfo()
            {
            }
        }
        public static frmPerssonel_Contract ContractInfo => NestedCallInfo.perssonelContractInfo;
        public PerssonelBussines SetData(PerssonelBussines _perssonel)
        {
            try
            {
                _perssonel.ContractCode = txtContractCode.Text;
                _perssonel.ConTerm = txtTheTerm.Text.ParseToInt();
                _perssonel.ConStartDate = txtStartDate.Value.FarsiSelectedDate;
                _perssonel.ConEndDate = txtEndDate.Value.FarsiSelectedDate;
                _perssonel.Education = txtEdu.Text;
                EnumMaritalStatus mari;
                if (rbtnMarrie.Checked)
                    mari = EnumMaritalStatus.Motahel;
                else
                    mari = EnumMaritalStatus.Mojarad;
                _perssonel.MaritalStatus = mari;
                _perssonel.ConStatus = true;
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
                txtContractCode.Text = _perssonel.ContractCode;
                txtTheTerm.Text = _perssonel.ConTerm.ToString();
                txtEdu.Text = _perssonel.Education;
                txtStartDate.Value.FarsiSelectedDate = _perssonel.ConStartDate;
                txtEndDate.Value.FarsiSelectedDate = _perssonel.ConEndDate;
                var mari = _perssonel.MaritalStatus;
                if (mari == null)
                    rbtnSingle.Checked = true;
                else
                {
                    if (mari == EnumMaritalStatus.Mojarad)
                        rbtnSingle.Checked = true;
                    if (mari == EnumMaritalStatus.Motahel)
                        rbtnMarrie.Checked = true;
                }
                if (_perssonel.Guid == Guid.Empty)
                {
                    NewContractCode(_perssonel);
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        private void NewContractCode(PerssonelBussines p)
        {
            try
            {
                if (p.ContractCode == null)
                    txtContractCode.Text = PerssonelBussines.NewContractCode();
            }
            catch (Exception exception)
            {
                txtContractCode.Text = "1";
            }
        }

        private void TxtContractCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtContractCode);
        }

        private void TxtTheTerm_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtTheTerm);
        }

        private void TxtEdu_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEdu);
        }

        private void TxtEdu_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEdu);
        }

        private void TxtTheTerm_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtTheTerm);
        }

        private void TxtContractCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtContractCode);
        }
    }
}
