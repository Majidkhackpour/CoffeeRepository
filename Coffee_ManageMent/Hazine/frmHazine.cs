using System;
using System.Drawing;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Hazine
{
    public partial class frmHazine : Form
    {
        private DataLayer.Models.Account.Hazine hazine;
        public frmHazine()
        {
            InitializeComponent();
            hazine = new DataLayer.Models.Account.Hazine();
        }
        public frmHazine(Guid hazineGuid, bool Is_Show)
        {
            InitializeComponent();
            hazine = HazineBussines.Get(hazineGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }
        private void Set_Data()
        {
            try
            {
                lblCode.Text = AccountGroupBussines.Get((int) HesabType.Hazine).Aouth_Code;
                txtDescription.Text = hazine.Description;
                txtCode.Text = hazine.Half_Code;
                txtName.Text = hazine.Name;
                if (hazine.Guid == Guid.Empty)
                {
                    NewCode();
                }
            }
            catch (Exception e)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, e.Message);
                f.ShowDialog();
            }
        }
        private void NewCode()
        {
            try
            {
                var groupGuid = AccountGroupBussines.Get((int) HesabType.Hazine).Guid;
                txtCode.Text = AccountBussines.NewCode(groupGuid);
            }
            catch (Exception exception)
            {
                txtCode.Text = "0001";
            }
        }

        private void FrmHazine_Load(object sender, EventArgs e)
        {
            Set_Data();
        }

        private void TxtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtCode);
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtName);
        }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtDescription);
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtDescription);
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtName);
        }

        private void TxtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCode);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.Enabled = false;
                if (hazine.Guid == Guid.Empty)
                {
                    hazine.DateSabt = DateConvertor.M2SH(DateTime.Now);
                    hazine.Guid = Guid.NewGuid();
                }

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب را وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (txtCode.Text.Length > 4 || txtCode.Text.Length < 4)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "حتما باید چهار کاراکتر به عنوان کد حساب کل وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (!AccountBussines.Check_Code(lblCode.Text + txtCode.Text.Trim(), hazine.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب وارد شده تکراری است");
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

                if (!AccountBussines.Check_Name(txtName.Text.Trim(), hazine.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                hazine.Code = lblCode.Text + txtCode.Text;
                hazine.Half_Code = txtCode.Text;
                hazine.Description = txtDescription.Text;
                hazine.Name = txtName.Text;
                hazine.State = true;

                if (HazineBussines.Save(hazine))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                    f.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
            finally
            {
                btnFinish.Enabled = true;
            }
        }

        private void TxtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSetter.KeyPress_Whitout_Dot(sender, e);
        }

        private void FrmHazine_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }
    }
}
