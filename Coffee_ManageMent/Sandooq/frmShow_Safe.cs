using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Sandooq;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Sandooq
{
    public partial class frmShow_Safe : Form
    {
        public void LoadData(string search = "")
        {
            try
            {
                if (search == "")
                {
                    var lst = SafeBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    SandooqBindingSource.DataSource = lst.ToList();
                }
                else
                {
                    var list = SafeBussines.Search(search).Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    SandooqBindingSource.DataSource = list;
                }

                lblCounter.Text = SandooqBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
        public frmShow_Safe()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }


        private void frmShow_Safe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmShow_Safe_KeyDown(object sender, KeyEventArgs e)
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
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSafe();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                frm.ShowDialog();
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid _safeGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmSafe(_safeGuid, true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text);
                }
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var Acc = SafeBussines.Get(accGuid);
                string message = "آیا از حذف حساب " + Acc.Name + " " + "اطمینان دارید؟";
                frmMessage frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Acc = SafeBussines.Change_Status(accGuid, false);
                    var a = Acc.Save();
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

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid _safeGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmSafe(_safeGuid, false);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text);
                }
            }
            catch (Exception exception)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
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
