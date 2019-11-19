using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmPerssonelMain : Form
    {
        private static DataLayer.Models.Perssonel.Perssonel _perssonel;
        private Form[] listForms =
        {
            frmPerssonel_PublicInfo.PublicInfo, frmPerssonel_CallInfo.CallInfo
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
                frm.Show();
                switch (top)
                {
                    case 0:
                         frmPerssonel_PublicInfo.PublicInfo.FillData(_perssonel);
                        break;
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void Next()
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
        private void Back()
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
    }
}
