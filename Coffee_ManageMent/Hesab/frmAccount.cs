using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using DataLayer.Models.Account;

namespace Coffee_ManageMent
{
    public partial class frmAccount : Form
    {
        private Account account;
        public frmAccount()
        {
            InitializeComponent();
            account = new Account();
        }

        public frmAccount(Guid accountGuid, bool Is_Show)
        {
            InitializeComponent();
            account = AccountBussines.Get(accountGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }
        private void Set_Data()
        {
            var lst = AccountGroupBussines.GetAll().OrderBy(q => q.Aouth_Code).ToList();
            cmbGroup.DataSource = lst;
            txtDescription.Text = account.Description;
            txtCode.Text = account.Half_Code;
            txtName.Text = account.Name;
            if (account.GroupGuid != Guid.Empty)
            {
                cmbGroup.SelectedValue = account.GroupGuid;
            }
            else
            {
                cmbGroup.SelectedIndex = 0;
            }
            if (account.AccountGroup != null)
                lblCode.Text = account.AccountGroup.Aouth_Code;
            if (account.Guid == Guid.Empty)
            {
                NewCode((Guid)cmbGroup.SelectedValue);
            }
        }
        private void NewCode(Guid groupGuid)
        {
            try
            {
                txtCode.Text = AccountBussines.NewCode(groupGuid);
            }
            catch (Exception exception)
            {
                txtCode.Text = "0001";
            }
        }
        private void frmAccount_Load(object sender, EventArgs e)
        {
            try
            {
                Set_Data();
                var accounts = AccountBussines.GetAll().ToList();
                AutoCompleteStringCollection _source = new AutoCompleteStringCollection();

                foreach (var item in accounts)
                {
                    _source.Add(item.Name);
                }

                txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtName.AutoCompleteCustomSource = _source;
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }
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

        private void CmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblCode.Text = AccountGroupBussines.Get((Guid) cmbGroup.SelectedValue).Aouth_Code.ToString();
                if (cmbGroup.Focused || account.Guid == Guid.Empty)
                    NewCode((Guid)cmbGroup.SelectedValue);
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
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
                if (account.Guid == Guid.Empty)
                {
                    account.DateSabt = DateConvertor.M2SH(DateTime.Now);
                    account.Guid = Guid.NewGuid();
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

                if (!AccountBussines.Check_Code(lblCode.Text + txtCode.Text.Trim(), account.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (cmbGroup.SelectedValue == null)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "گروه حساب را وارد نمایید");
                    f.ShowDialog();
                    cmbGroup.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "عنوان حساب را وارد نمایید");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (!AccountBussines.Check_Name(txtName.Text.Trim(), account.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                account.Code = lblCode.Text + txtCode.Text;
                account.GroupGuid = (Guid)cmbGroup.SelectedValue;
                account.Half_Code = txtCode.Text;
                account.Description = txtDescription.Text;
                account.Name = txtName.Text;
                account.State = true;
                account.AccountGroup = AccountGroupBussines.Get((Guid) cmbGroup.SelectedValue);
                account.Amounth = 0;
                account.HesabType = HesabType.Hazine;

                if (AccountBussines.Save(account))
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

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }

        private void CmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }

        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }

        private void TxtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSetter.KeyPress_Whitout_Dot(sender, e);
        }
    }
}
