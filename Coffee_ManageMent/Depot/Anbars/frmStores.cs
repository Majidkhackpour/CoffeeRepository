using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Anbar;
using Coffee_ManageMent.Depot.AnbarGroup;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using DataLayer.Models.Anbar;

namespace Coffee_ManageMent.Depot.Anbars
{
    public partial class frmStores : Form
    {
        private DataLayer.Models.Anbar.AnbarGroup _group;
        private Anbar anbar;
        public frmStores()
        {
            InitializeComponent();
            anbar = new Anbar();
        }
        public frmStores(Guid anbarGuid, bool Is_Show)
        {
            InitializeComponent();
            anbar = AnbarBussines.Get(anbarGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }

        private void LoadGroups()
        {
            var lst = AnbarGroupBussines.GetAll().OrderBy(q => q.Name).ToList();
            cmbGroup.DataSource = lst;
        }
        private void Set_Data()
        {
            LoadGroups();
            txtDescription.Text = anbar.Description;
            txtName.Text = anbar.Name;
            chbManfi.Checked = anbar.Manfi;
            if (anbar.AnbarGroup != Guid.Empty)
                cmbGroup.SelectedValue = anbar.AnbarGroup;
            else
                cmbGroup.SelectedIndex = 0;
        }

        private void FrmStores_Load(object sender, EventArgs e)
        {
            Set_Data();
            var accounts = AnbarBussines.GetAll().ToList();
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

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.Enabled = false;
                if (anbar.Guid == Guid.Empty)
                {
                    anbar.DateSabt = DateConvertor.M2SH(DateTime.Now);
                    anbar.Guid = Guid.NewGuid();
                }

                if (cmbGroup.SelectedValue == null)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "گروه انبار را وارد نمایید");
                    f.ShowDialog();
                    cmbGroup.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "عنوان انبار را وارد نمایید");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (!AnbarBussines.Check_Name(txtName.Text.Trim(), anbar.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red,
                        "عنوان انبار وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                anbar.AnbarGroup = (Guid)cmbGroup.SelectedValue;
                anbar.Description = txtDescription.Text;
                anbar.Name = txtName.Text;
                anbar.Status = true;
                anbar.Manfi = chbManfi.Checked;
                if (AnbarBussines.Save(anbar))
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

        private void FrmStores_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }

        private void CmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F12)
            {
                frmShow_AnbarGroup frm=new frmShow_AnbarGroup();
                frm.ShowDialog();
                LoadGroups();
            }
        }
    }
}
