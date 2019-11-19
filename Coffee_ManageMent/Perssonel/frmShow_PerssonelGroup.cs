using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmShow_PerssonelGroup : Form
    {
        private bool _isSelected = false;//When is True its mean selected part is show
        private Guid _selectedGuid = Guid.Empty;
        public Guid SelectedGuid
        {
            get { return _selectedGuid; }
            set { _selectedGuid = value; }
        }
        public frmShow_PerssonelGroup()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }
        public void LoadData(string search = "")
        {
            try
            {
                if (search == "")
                {
                    var lst = PerssonelGroupBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    PerssonelGroupBindingSource.DataSource = lst.ToList();
                }
                else
                {
                    var list = PerssonelGroupBussines.Search(search).Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    PerssonelGroupBindingSource.DataSource = list;
                }

                lblCounter.Text = PerssonelGroupBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void FrmShow_PerssonelGroup_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FrmShow_PerssonelGroup_KeyDown(object sender, KeyEventArgs e)
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

        private void MnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmPerssonelGroup frm = new frmPerssonelGroup();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }

        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid _guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmPerssonelGroup frm = new frmPerssonelGroup(_guid, true);
                if (frm.ShowDialog() == DialogResult.OK)
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

        private void MnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid _guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmPerssonelGroup frm = new frmPerssonelGroup(_guid, false);
                if (frm.ShowDialog() == DialogResult.OK)
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
                Guid accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var Acc = PerssonelGroupBussines.Get(accGuid);
                string message = "آیا از حذف گروه پرسنل " + Acc.Name + " " + "اطمینان دارید؟";
                frmMessage frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Acc = PerssonelGroupBussines.Change_Status(accGuid, false);
                    PerssonelGroupBussines.Save(Acc);
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
                    if (DGrid.RowCount == 0) return;
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

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }
    }
}
