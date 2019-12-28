using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Customer;
using BussinesLayer.Sellers;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Customers
{
    public partial class frmCustomer : Form
    {
        private static CustomersBussines _cus;

        private Form[] listForms =
        {
            frmCustomer_PublicInfo.PublicInfo, frmCustomer_CallInfo.CallInfo, frmCustomer_AouthInfo.AouthInfo
        };

        private int Count = 0;
        private int top = -1;
        public frmCustomer()
        {
            InitializeComponent();
            Count = listForms.Count();
            _cus = new CustomersBussines();
        }
        private void LoadNewForm(Form frm)
        {
            try
            {
                lblTitle.Text = frm.Text;
                frm.TopLevel = false;
                frm.AutoScroll = true;
                frm.Dock = DockStyle.Fill;
                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(frm);
                pnlContent.AutoScroll = true;
                SetButtons();
                frm.Show();
                switch (top)
                {
                    case 0:
                        frmCustomer_PublicInfo.PublicInfo.FillData(_cus);
                        break;
                    case 1:
                        frmCustomer_CallInfo.CallInfo.FillData(_cus);
                        break;
                    case 2:
                        frmCustomer_AouthInfo.AouthInfo.FillData(_cus);
                        break;
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        public frmCustomer(Guid guid, bool Is_Show)
        {
            InitializeComponent();
            Count = listForms.Count();
            _cus = CustomersBussines.Get(guid);
            pnlContent.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }

        private void SetButtons()
        {
            try
            {
                btnNext.Text = top + 1 >= Count ? "ثبت اطلاعات" : listForms[top + 1].Text;
                btnBack.Text = top - 1 < 0 ? "خروج" : listForms[top - 1].Text;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        public void Next()
        {
            try
            {
                top++;
                if (top >= Count - 1)
                    btnNext.Text = "ثبت اطلاعات";
                btnBack.Text = "مرحله قبل";
                LoadNewForm(listForms[top]);
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        public void Back()
        {
            try
            {
                top--;
                if (top <= 0)
                    btnBack.Text = "خروج";
                btnNext.Text = "مرحله بعد";
                LoadNewForm(listForms[top]);
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }


        private void frmCustomer_Load(object sender, EventArgs e)
        {
            Next();
            btnBack.Text = "خروج";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _cus = GetCustomer(_cus);
            if (btnNext.Text == "ثبت اطلاعات")
            {
                btnFinish.PerformClick();
                return;
            }
            Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _cus = GetCustomer(_cus);
            if (btnBack.Text == "خروج")
            {
                btnCancel.PerformClick();
                return;
            }
            Back();
        }
        private CustomersBussines GetCustomer(CustomersBussines _p)
        {
            try
            {
                switch (top)
                {
                    case 0:
                        _p = frmCustomer_PublicInfo.PublicInfo.SetData(_cus);
                        break;
                    case 1:
                        _p = frmCustomer_CallInfo.CallInfo.SetData(_cus);
                        break;
                    case 2:
                        _p = frmCustomer_AouthInfo.AouthInfo.SetData(_cus);
                        break;
                }

                return _p;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                _cus = GetCustomer(_cus);
                _cus.Status = true;
                if (_cus.Guid == Guid.Empty)
                {
                    _cus.Guid = Guid.NewGuid();
                    _cus.DateSabt = DateConvertor.M2SH(DateTime.Now);
                }

                if (string.IsNullOrEmpty(_cus.Code) || !CustomersBussines.Check_Code(_cus.Code, _cus.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "کد شناسایی مشتری مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }
                if (string.IsNullOrEmpty(_cus.Name) || !CustomersBussines.Check_Name(_cus.Name, _cus.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "نام مشتری مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }

                if (_cus.GroupGuid == Guid.Empty)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "گروه مشتری مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }

                if (_cus.Amount_AvalDore != 0 && _cus.MoeinAmountAvalDore == Guid.Empty)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "معین حساب مانده اول دوره مشتری مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }
                if (!CheckPerssonValidation.Check_Mobile(_cus.Mobile1) || !CheckPerssonValidation.Check_Mobile(_cus.Mobile2))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "تلفن همراه مشتری مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }

                if (!CheckPerssonValidation.Check_Email(_cus.Email))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "پست الکترونیک مشتری مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }

                if (_cus.Save())
                {
                    var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                    f.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
    }
}
