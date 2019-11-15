using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using PersitenceLayer.Persistance;

namespace Coffee_ManageMent.Hesab
{
    public partial class frmShow_MoeinHesab : Form
    {
        private bool _isSelected = false;//When is True its mean selected part is show
        private Guid _selectedGuid = Guid.Empty;

        public Guid SelectedGuid
        {
            get { return _selectedGuid; }
            set { _selectedGuid = value; }
        }
        public frmShow_MoeinHesab()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }

        public frmShow_MoeinHesab(bool isSelected)
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
            _isSelected = isSelected;
        }
        private void LoadData(string search = null)
        {
            try
            {
                if (search == null)
                {
                    var lst = MoeinBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Code).ToList();
                    MoeinBindingSource.DataSource = lst.ToList();
                }
                else
                {
                    var list = MoeinBussines.Search(search).Where(q => q.Status).ToList();
                    MoeinBindingSource.DataSource = list;
                }

                lblCounter.Text = MoeinBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void MnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmMoein f = new frmMoein();
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }
        }

        private void FrmShow_MoeinHesab_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmMoein f = new frmMoein(_guid, true);
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }
        }

        private void MnuView_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmMoein f = new frmMoein(_guid, false);
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Guid moeinGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var moein = MoeinBussines.Get(moeinGuid);
                string message = "آیا از حذف حساب " + moein.Name + " " + "اطمینان دارید؟";
                frmMessage frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    moein = MoeinBussines.Change_Status(moeinGuid, false);
                    MoeinBussines.Save(moein);
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                    f.ShowDialog();
                    LoadData();
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(txtSearch.Text);
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_isSelected)
                {
                    SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void FrmShow_MoeinHesab_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        mnuInsert.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Escape:
                        this.Close();
                        break;
                    case Keys.Enter:
                        if (_isSelected)
                        {
                            SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }

                        break;
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
    }
}
