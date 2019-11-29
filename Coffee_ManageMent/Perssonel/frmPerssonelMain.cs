using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmPerssonelMain : Form
    {
        private static DataLayer.Models.Perssonel.Perssonel _perssonel;

        private Form[] listForms =
        {
            frmPerssonel_PublicInfo.PublicInfo, frmPerssonel_CallInfo.CallInfo, frmPerssonel_Contract.ContractInfo,
            frmPerssonel_Sallary.SallaryInfo
        };

        private int Count = 0;
        private int top = -1;
        public frmPerssonelMain()
        {
            InitializeComponent();
            Count = listForms.Count();
            _perssonel = new DataLayer.Models.Perssonel.Perssonel();
        }
        public frmPerssonelMain(Guid guid)
        {
            InitializeComponent();
            Count = listForms.Count();
            _perssonel = PerssonelBussines.Get(guid);
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            GetPerssonel(_perssonel);
            if (_perssonel.Guid == Guid.Empty)
            {
                _perssonel.Guid = Guid.Empty;
                _perssonel.DateSabt = DateConvertor.M2SH(DateTime.Now);
            }

            if (_perssonel.Code == null || _perssonel.Code == "" || !PerssonelBussines.Check_Code(_perssonel.Code, _perssonel.Guid))
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "کد شناسایی پرسنل مورد نظر، معتبر نمی باشد");
                f.ShowDialog();
                return;
            }
            if (_perssonel.Name == null || _perssonel.Name == "" || !PerssonelBussines.Check_Name(_perssonel.Name, _perssonel.Guid))
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "نام پرسنل مورد نظر، معتبر نمی باشد");
                f.ShowDialog();
                return;
            }

            if (_perssonel.PerssonelGroup == null || _perssonel.PerssonelGroup == Guid.Empty)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "گروه پرسنل مورد نظر، معتبر نمی باشد");
                f.ShowDialog();
                return;
            }
            if (!CheckPerssonValidation.Check_NationalCode(_perssonel.NationalCode))
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "کد ملی پرسنل مورد نظر، معتبر نمی باشد");
                f.ShowDialog();
                return;
            }

            if (_perssonel.Amount_AvalDore != 0 && _perssonel.MoeinAvalDore == Guid.Empty)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "معین حساب مانده اول دوره پرسنل مورد نظر، معتبر نمی باشد");
                f.ShowDialog();
                return;
            }
            if (!CheckPerssonValidation.Check_Mobile(_perssonel.Mobile1) || !CheckPerssonValidation.Check_Mobile(_perssonel.Mobile2))
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "تلفن همراه پرسنل مورد نظر، معتبر نمی باشد");
                f.ShowDialog();
                return;
            }

            if (!CheckPerssonValidation.Check_Email(_perssonel.Email))
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "پست الکترونیک پرسنل مورد نظر، معتبر نمی باشد");
                f.ShowDialog();
                return;
            }

            if (_perssonel.ConStartDate.ParseToDate() > _perssonel.ConEndDate.ParseToDate())
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                    "تاریخ شروع قرارداد نمی تواند از تاریخ اتمام آن بزرگتر باشد");
                f.ShowDialog();
                return;
            }
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
                        frmPerssonel_PublicInfo.PublicInfo.FillData(_perssonel);
                        break;
                    case 1:
                        frmPerssonel_CallInfo.CallInfo.FillData(_perssonel);
                        break;
                    case 2:
                        frmPerssonel_Contract.ContractInfo.FillData(_perssonel);
                        break;
                    case 3:
                        frmPerssonel_Sallary.SallaryInfo.FillData(_perssonel);
                        break;
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void SetButtons()
        {
            try
            {
                if (top + 1 >= Count)
                    btnNext.Text = "ثبت اطلاعات";
                else
                    btnNext.Text = listForms[top + 1].Text;
                if (top - 1 < 0)
                    btnBack.Text = "خروج";
                else
                    btnBack.Text = listForms[top - 1].Text;
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

        private void FrmPerssonelMain_Load(object sender, EventArgs e)
        {
            Next();
            btnBack.Text = "خروج";
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            _perssonel = GetPerssonel(_perssonel);
            if (btnNext.Text == "ثبت اطلاعات")
            {
                btnFinish.PerformClick();
                return;
            }
            Next();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _perssonel = GetPerssonel(_perssonel);
            if (btnBack.Text == "خروج")
            {
                btnCancel.PerformClick();
                return;
            }
            Back();
        }

        private DataLayer.Models.Perssonel.Perssonel GetPerssonel(DataLayer.Models.Perssonel.Perssonel _p)
        {
            try
            {
                switch (top)
                {
                    case 0:
                        _perssonel = frmPerssonel_PublicInfo.PublicInfo.SetData(_perssonel);
                        break;
                    case 1:
                        _perssonel = frmPerssonel_CallInfo.CallInfo.SetData(_perssonel);
                        break;
                    case 2:
                        _perssonel = frmPerssonel_Contract.ContractInfo.SetData(_perssonel);
                        break;
                    case 3:
                        _perssonel = frmPerssonel_Sallary.SallaryInfo.SetData(_perssonel);
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
        private class NestedMainInfo
        {
            internal static frmPerssonelMain perssonelMain = new frmPerssonelMain();

            public NestedMainInfo()
            {
            }
        }

        public static frmPerssonelMain MainInfo => NestedMainInfo.perssonelMain;

        private void FrmPerssonelMain_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
