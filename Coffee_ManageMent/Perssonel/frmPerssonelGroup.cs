using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Anbar;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using DataLayer.Models.Perssonel;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmPerssonelGroup : Form
    {
        private PerssonelGroupBussines _group;
        public frmPerssonelGroup()
        {
            InitializeComponent();
            _group = new PerssonelGroupBussines();
        }
        public frmPerssonelGroup(Guid groupGuid, bool Is_Show)
        {
            InitializeComponent();
            _group = PerssonelGroupBussines.Get(groupGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }
        private void Set_Data()
        {
            try
            {
                txtDescription.Text = _group.Description;
                txtName.Text = _group.Name;
            }
            catch (Exception e)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, e.Message);
                f.ShowDialog();
            }
        }

        private void FrmPerssonelGroup_Load(object sender, EventArgs e)
        {
            Set_Data();
            var accounts = PerssonelGroupBussines.GetAll().ToList();
            AutoCompleteStringCollection _source = new AutoCompleteStringCollection();

            foreach (var item in accounts)
            {
                _source.Add(item.Name);
            }

            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteCustomSource = _source;
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void FrmPerssonelGroup_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.Enabled = false;
                if (_group.Guid == Guid.Empty)
                {
                    _group.DateSabt = DateConvertor.M2SH(DateTime.Now);
                    _group.Guid = Guid.NewGuid();
                }


                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "عنوان حساب را وارد نمایید");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (!PerssonelGroupBussines.Check_Name(txtName.Text.Trim(), _group.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }
                _group.Description = txtDescription.Text;
                _group.Name = txtName.Text;
                _group.Status = true;

                if (_group.Save())
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
    }
}
