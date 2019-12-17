using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Sellers;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Sellers
{
    public partial class frmSellerMain : Form
    {
        private static SellerBussines _seller;

        private Form[] listForms =
        {
            frmSeller_PublicInfo.PublicInfo, frmSeller_CallInfo.CallInfo
        };

        private int Count = 0;
        private int top = -1;
        public frmSellerMain()
        {
            InitializeComponent();
            Count = listForms.Count();
            _seller = new SellerBussines();
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
                        frmSeller_PublicInfo.PublicInfo.FillData(_seller);
                        break;
                    case 1:
                        frmSeller_CallInfo.CallInfo.FillData(_seller);
                        break;
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        public frmSellerMain(Guid guid, bool Is_Show)
        {
            InitializeComponent();
            Count = listForms.Count();
            _seller = SellerBussines.Get(guid);
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

        private void FrmSellerMain_Load(object sender, EventArgs e)
        {
            Next();
            btnBack.Text = "خروج";
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            _seller = GetSeller(_seller);
            if (btnNext.Text == "ثبت اطلاعات")
            {
                btnFinish.PerformClick();
                return;
            }
            Next();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _seller = GetSeller(_seller);
            if (btnBack.Text == "خروج")
            {
                btnCancel.PerformClick();
                return;
            }
            Back();
        }
        private SellerBussines GetSeller(SellerBussines _p)
        {
            try
            {
                switch (top)
                {
                    case 0:
                        _p = frmSeller_PublicInfo.PublicInfo.SetData(_seller);
                        break;
                    case 1:
                        _p = frmSeller_CallInfo.CallInfo.SetData(_seller);
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

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                _seller = GetSeller(_seller);
                _seller.Status = true;
                if (_seller.Guid == Guid.Empty)
                {
                    _seller.Guid = Guid.NewGuid();
                    _seller.DateSabt = DateConvertor.M2SH(DateTime.Now);
                }

                if (string.IsNullOrEmpty(_seller.Code) || !SellerBussines.Check_Code(_seller.Code, _seller.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "کد شناسایی فروشنده مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }
                if (string.IsNullOrEmpty(_seller.Name) || !SellerBussines.Check_Name(_seller.Name, _seller.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "نام فروشنده مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }


                if (_seller.Amount_AvalDore != 0 && _seller.MeinAvalDore == Guid.Empty)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "معین حساب مانده اول دوره فروشنده مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }
                if (!CheckPerssonValidation.Check_Mobile(_seller.Mobile1) || !CheckPerssonValidation.Check_Mobile(_seller.Mobile2))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "تلفن همراه فروشنده مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }

                if (!CheckPerssonValidation.Check_Email(_seller.Email))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "پست الکترونیک فروشنده مورد نظر، معتبر نمی باشد");
                    f.ShowDialog();
                    return;
                }



                if (_seller.Save())
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
