using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Hesab
{
    public partial class frmShow_Kol : Form
    {
        private bool _isSelected = false;//When is True its mean selected part is show
        private Guid _selectedGuid = Guid.Empty;

        public Guid SelectedGuid
        {
            get { return _selectedGuid; }
            set { _selectedGuid = value; }
        }

        public string SearchText
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public frmShow_Kol()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }

        public frmShow_Kol(bool isSelected)
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
            _isSelected = isSelected;
        }
        public void LoadData(string search = "")
        {
            try
            {
                if (search == "")
                {
                    var lst = KolBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Code).ToList();
                    KolBindingSource.DataSource = lst.ToList();
                }
                else
                {
                    var list = KolBussines.Search(search).Where(q => q.Status).OrderBy(q => q.Code).ToList();
                    KolBindingSource.DataSource = list;
                }

                lblCounter.Text = KolBindingSource.Count.ToString();
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
                frmKol frmKol = new frmKol();
                if (frmKol.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void FrmShow_Kol_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid kol_Guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmKol frmKol = new frmKol(kol_Guid, true);
                if (frmKol.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid kol_Guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var kol = KolBussines.Get(kol_Guid);
                string message = "آیا از حذف حساب " + kol.Name + " " + "اطمینان دارید؟";
                frmMessage frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    kol = KolBussines.Change_Status(kol_Guid, false);
                    if (kol.Save())
                    {
                        frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                        f.ShowDialog();
                        LoadData();
                    }

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

        private void MnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid kol_Guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmKol frmKol = new frmKol(kol_Guid, false);
                frmKol.ShowDialog();
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
                if (DGrid.RowCount == 0) return;
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

        private void FrmShow_Kol_KeyDown(object sender, KeyEventArgs e)
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
