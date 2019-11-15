using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using DataLayer.Models.Account;

namespace Coffee_ManageMent.Hesab
{
    public partial class frmKol : Form
    {
        private KolHesab kol;
        public frmKol()
        {
            InitializeComponent();
            kol = new KolHesab();
        }

        public frmKol(Guid kolGuid,bool Is_Show)
        {
            InitializeComponent();
            kol = KolBussines.Get(kolGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }

        private void Set_Data()
        {
            var lst = HesabGroupBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Code).ToList();
            cmbGroup.DataSource = lst;
            txtDescription.Text = kol.Description;
            txtCode.Text = kol.Half_Code;
            txtName.Text = kol.Name;
            if (kol.GroupGuid!=Guid.Empty)
            {
                cmbGroup.SelectedValue = kol.GroupGuid;
            }
            else
            {
                cmbGroup.SelectedIndex = 0;
            }
            if (kol.HesabGroup != null)
                lblCode.Text = kol.HesabGroup.Code;
            if (kol.Guid==Guid.Empty)
            {
                NewCode((Guid)cmbGroup.SelectedValue);
            }
        }

        private void NewCode(Guid groupGuid)
        {
            try
            {
                txtCode.Text = KolBussines.NewCode(groupGuid);
            }
            catch (Exception exception)
            {
                txtCode.Text = "01";
            }
        }
        private void TxtCode_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txt2: txtCode);
        }

        private void TxtName_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txt2: txtName);
        }

        private void TxtDescription_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txt2: txtDescription);
        }

        private void TxtDescription_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txt2: txtDescription);
        }

        private void TxtName_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txt2: txtName);
        }

        private void TxtCode_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txt2: txtCode);
        }

        private void CmbGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                lblCode.Text = HesabGroupBussines.Get((Guid)cmbGroup.SelectedValue).Code.ToString();
                if (cmbGroup.Focused || kol.Guid == Guid.Empty)
                    NewCode((Guid) cmbGroup.SelectedValue);
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.Enabled = false;
                if (kol.Guid == Guid.Empty)
                {
                    kol.Guid = Guid.NewGuid();
                    kol.DateSabt = DateConvertor.M2SH(DateTime.Now);
                }

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب را وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (txtCode.Text.Length > 2 || txtCode.Text.Length < 2)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "حتما باید دو کاراکتر به عنوان کد حساب کل وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (!KolBussines.Check_Code(lblCode.Text + txtCode.Text.Trim(), kol.Guid))
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

                if (!KolBussines.Check_Name(txtName.Text.Trim(), kol.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                kol.Code = lblCode.Text + txtCode.Text;
                kol.GroupGuid = (Guid) cmbGroup.SelectedValue;
                kol.Half_Code = txtCode.Text;
                kol.Description = txtDescription.Text;
                kol.Name = txtName.Text;
                kol.Status = true;
                kol.System = false;

                if (KolBussines.Save(kol))
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

        private void FrmKol_Load(object sender, EventArgs e)
        {
            try
            {
                Set_Data();
                var kols = KolBussines.GetAll().ToList();
                AutoCompleteStringCollection _source = new AutoCompleteStringCollection();

                foreach (var item in kols)
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void TxtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSetter.KeyPress_Whitout_Dot(sender, e);
        }

        private void FrmKol_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }
    }
}
