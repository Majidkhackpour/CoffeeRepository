using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using Coffee_ManageMent.Utility;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Models.Account;

namespace Coffee_ManageMent.Hesab
{
    public partial class frmMoein : Form
    {
        private MoeinBussines moein;
        private KolBussines kol = new KolBussines();
        public frmMoein()
        {
            InitializeComponent();
            moein = new MoeinBussines();
        }
        public frmMoein(Guid moeinGuid, bool Is_Show)
        {
            InitializeComponent();
            moein = MoeinBussines.Get(moeinGuid);
            grpAccount.Enabled = Is_Show;
            btnFinish.Enabled = Is_Show;
        }
        private void Set_Data()
        {
            cmbMahiat.Items.Add(EnumMahiat.Bedehkar.GetDisplay());
            cmbMahiat.Items.Add(EnumMahiat.Bestankar.GetDisplay());
            cmbMahiat.Items.Add(EnumMahiat.BedAndBes.GetDisplay());
            cmbMahiat.SelectedIndex = (int)moein.Mahiat;
            txtDescription.Text = moein.Description;
            txtCode.Text = moein.Half_Code;
            txtName.Text = moein.Name;
            if (moein.KolGuid != Guid.Empty)
            {
                txtKolCode.Text = KolBussines.Get(moein.KolGuid).Code;
                txtKolName.Text = KolBussines.Get(moein.KolGuid).Name;
            }
            if (moein.Guid == Guid.Empty)
            {
                NewCode(kol.Guid);
            }
        }
        private void NewCode(Guid kolGuid)
        {
            try
            {
                txtCode.Text = MoeinBussines.NewCode(kolGuid);
            }
            catch (Exception exception)
            {
                txtCode.Text = "001";
            }
        }

        private void TxtKolCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtKolCode);
        }

        private void TxtKolCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtKolCode);
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

        private void TxtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtCode);
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtName);
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtDescription);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void FrmMoein_Load(object sender, EventArgs e)
        {
            try
            {
                Set_Data();
                var moeins = MoeinBussines.GetAll().ToList();
                AutoCompleteStringCollection _source = new AutoCompleteStringCollection();

                foreach (var item in moeins)
                {
                    _source.Add(item.Name);
                }

                txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtName.AutoCompleteCustomSource = _source;
                ToolTip tt = new ToolTip();
                tt.SetToolTip(btnSearchKol, "انتخاب حساب کل");
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.Enabled = false;
                if (moein.Guid == Guid.Empty)
                {
                    moein.Guid = Guid.NewGuid();
                    moein.DateSabt = DateConvertor.M2SH(DateTime.Now);
                }

                if (kol.Guid == Guid.Empty)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "حساب کل را انتخاب نمایید");
                    f.ShowDialog();
                    txtKolCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب را وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (txtCode.Text.Length > 3 || txtCode.Text.Length < 3)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "حتما باید سه کاراکتر به عنوان کد حساب معین وارد نمایید");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (!MoeinBussines.Check_Code(txtKolCode.Text + txtCode.Text.Trim(), moein.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "کد حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtCode.Focus();
                    return;
                }

                if (cmbMahiat.SelectedIndex == -1)
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "ماهیت حساب را وارد نمایید");
                    f.ShowDialog();
                    cmbMahiat.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "عنوان حساب را وارد نمایید");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                if (!MoeinBussines.Check_Name(txtName.Text.Trim(), moein.Guid))
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, "عنوان حساب وارد شده تکراری است");
                    f.ShowDialog();
                    txtName.Focus();
                    return;
                }

                moein.Mahiat = (EnumMahiat)cmbMahiat.SelectedIndex;
                moein.Half_Code = txtCode.Text;
                moein.Code = txtKolCode.Text + txtCode.Text;
                moein.Description = txtDescription.Text;
                moein.Name = txtName.Text;
                moein.Status = true;
                moein.System = false;
                moein.KolGuid = kol.Guid;

                if (moein.Save())
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                    f.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }


            finally{ btnFinish.Enabled = true; }
        }

        private void TxtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSetter.KeyPress_Whitout_Dot(sender, e);
        }

        private void BtnSearchKol_Click(object sender, EventArgs e)
        {
            try
            {
                frmShow_Kol f=new frmShow_Kol(true);
                if (f.ShowDialog()==DialogResult.OK)
                {
                    kol = KolBussines.Get(f.SelectedGuid);
                    txtKolCode.Text = kol?.Code ?? "";
                    txtKolName.Text = kol?.Name ?? "";
                    if (moein.Guid == Guid.Empty)
                        NewCode(kol.Guid);
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void TxtKolCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtKolName.Text = KolBussines.GetByCode(txtKolCode.Text.Trim()).Name;
                kol.Guid = KolBussines.GetByCode(txtKolCode.Text.Trim()).Guid;
                if (moein.Guid==Guid.Empty)
                    NewCode(kol.Guid);
            }
            catch
            {
                txtKolName.Text = "";
                kol.Guid = Guid.Empty;
            }
        }

        private void TxtKolCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtKolName.Text != "")
                {
                    txtSetter.KeyDown(sender, e, btnFinish);
                    return;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    frmShow_Kol f = new frmShow_Kol(true);
                    f.SearchText = txtKolCode.Text.Trim();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        kol = KolBussines.Get(f.SelectedGuid);
                        txtKolCode.Text = kol?.Code ?? "";
                        txtKolName.Text = kol?.Name ?? "";
                        if (moein.Guid == Guid.Empty)
                            NewCode(kol.Guid);
                    }
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void FrmMoein_KeyDown(object sender, KeyEventArgs e)
        {
            txtSetter.KeyDown(sender, e, btnFinish);
        }
    }
}
