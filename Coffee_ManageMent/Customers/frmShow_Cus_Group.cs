using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Customer;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Customers
{
    public partial class frmShow_Cus_Group : Form
    {
        private bool _isSelected = false;//When is True its mean selected part is show
        private Guid _selectedGuid = Guid.Empty;
        public Guid SelectedGuid
        {
            get => _selectedGuid;
            set => _selectedGuid = value;
        }
        public void LoadData(string search = "")
        {
            try
            {
                if (search == "")
                {
                    var lst = CustomerGroupBusiness.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    CustomerGroupBindingSource.DataSource = lst.ToList();
                }
                else
                {
                    var list = CustomerGroupBusiness.Search(search).Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    CustomerGroupBindingSource.DataSource = list;
                }

                lblCounter.Text = CustomerGroupBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
        public frmShow_Cus_Group()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }
        public frmShow_Cus_Group(bool sIsSelected)
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
            _isSelected = sIsSelected;
        }
        private void frmShow_Cus_Group_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FrmShow_Cus_Group_KeyDown(object sender, KeyEventArgs e)
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
                var frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void MnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmCus_Group();
                if (frm.ShowDialog() != DialogResult.OK) return;
                LoadData();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmCus_Group(guid, true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                LoadData();
                frm.Dispose();
            }
            catch (Exception exception)
            {
                var frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void MnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmCus_Group(guid, false);
                if (frm.ShowDialog() != DialogResult.OK) return;
                LoadData();
                frm.Dispose();
            }
            catch (Exception exception)
            {
                var frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                var accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var acc = CustomerGroupBusiness.Get(accGuid);
                var message = "آیا از حذف گروه " + acc.Name + " " + "اطمینان دارید؟";
                var frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() != DialogResult.OK) return;
                acc = CustomerGroupBusiness.Change_Status(accGuid, false);
                if (!acc.Save()) return;
                var f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                f.ShowDialog();
                LoadData();
            }
            catch (Exception exception)
            {
                var frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
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
                var frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!_isSelected) return;
                if (DGrid.RowCount == 0) return;
                SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
    }
}
