using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Perssonel;
using Coffee_ManageMent.Perssonel;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent
{
    public partial class frmShow_Perssonel : Form
    {
        public frmShow_Perssonel()
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
                    var lst = PerssonelBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    PerssonelBindingSource.DataSource = lst.ToList();
                }
                else
                {
                    var list = PerssonelBussines.Search(search).Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    PerssonelBindingSource.DataSource = list;
                }

                lblCounter.Text = PerssonelBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
        private void frmShow_Perssonel_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FrmShow_Perssonel_KeyDown(object sender, KeyEventArgs e)
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
                    //case Keys.Enter:
                    //    if (_isSelected)
                    //    {
                    //        SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                    //        this.DialogResult = DialogResult.OK;
                    //        this.Close();
                    //    }

                    //    break;
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
                frmPerssonelMain frm = new frmPerssonelMain();
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
                var frm = new frmPerssonelMain(_guid, true);
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
                var frm = new frmPerssonelMain(_guid, false);
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
                var accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var Acc = PerssonelBussines.Get(accGuid);
                string message = "آیا از حذف " + Acc.Name + " " + "اطمینان دارید؟";
                frmMessage frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Acc = PerssonelBussines.Change_Status(accGuid, false);
                    if (Acc.Save())
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
    }
}
