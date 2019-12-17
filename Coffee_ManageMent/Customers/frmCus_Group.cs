using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Customer;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent
{
    public partial class frmCus_Group : Form
    {
        private CustomerGroupBusiness _group;
        public frmCus_Group()
        {
            InitializeComponent();
            _group = new CustomerGroupBusiness();
        }

        public frmCus_Group(Guid groupGuid, bool Is_Show)
        {
            InitializeComponent();
            _group = CustomerGroupBusiness.Get(groupGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }
        private void Set_Data()
        {
            try
            {
                txtDescription.Text = _group.Notice;
                txtName.Text = _group.Name;
            }
            catch (Exception e)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, e.Message);
                f.ShowDialog();
            }
        }

        private void frmCus_Group_Load(object sender, EventArgs e)
        {
            Set_Data();
            var grp = CustomerGroupBusiness.GetAll().ToList();
            var _source = new AutoCompleteStringCollection();

            foreach (var item in grp)
            {
                _source.Add(item.Name);
            }

            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteCustomSource = _source;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSetter.Focus(txt2: txtName);
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSetter.Focus(txt2: txtDescription);
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSetter.Follow(txt2: txtDescription);
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSetter.Follow(txt2: txtName);
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void FrmCus_Group_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                txtSetter.KeyDown(sender, e, btnFinish);
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
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
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "عنوان حساب را وارد نمایید");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (!CustomerGroupBusiness.Check_Name(txtName.Text.Trim(), _group.Guid))
                {
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }
                _group.Notice = txtDescription.Text;
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
