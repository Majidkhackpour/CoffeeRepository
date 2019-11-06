using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.AccountBussines;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent
{
    public partial class frmShow_Account : Form
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
        public frmShow_Account()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }
        public frmShow_Account(bool isSelected)
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
                    var lst = AccountBussines.GetAll().Where(q => q.State).OrderBy(q => q.Code).ToList();
                    AccountBindingSource.DataSource = lst.ToList();
                }
                else
                {
                    var list = AccountBussines.Search(search).Where(q => q.State).OrderBy(q => q.Code).ToList();
                    AccountBindingSource.DataSource = list;
                }

                lblCounter.Text = AccountBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
        private void frmShow_Account_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void MnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmAccount frm = new frmAccount();
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

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmAccount frm = new frmAccount(_guid, true);
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
                Guid accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var Acc = AccountBussines.Get(accGuid);
                string message = "آیا از حذف حساب " + Acc.Name + " " + "اطمینان دارید؟";
                frmMessage frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Acc = AccountBussines.Change_Status(accGuid, false);
                    AccountBussines.Save(Acc);
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

        private void MnuView_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmAccount frm = new frmAccount(_guid, false);
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

        private void DGrid_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DGrid_KeyDown(sender, e);
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
    }
}
