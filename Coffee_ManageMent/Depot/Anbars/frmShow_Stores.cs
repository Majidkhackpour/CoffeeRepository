﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer;
using BussinesLayer.Anbar;
using Coffee_ManageMent.Depot.AnbarGroup;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using DataLayer.Models.Settings;

namespace Coffee_ManageMent.Depot.Anbars
{
    public partial class frmShow_Stores : Form
    {
        private bool _isSelected = false;//When is True its mean selected part is show
        private Guid _selectedGuid = Guid.Empty;

        public Guid SelectedGuid
        {
            get { return _selectedGuid; }
            set { _selectedGuid = value; }
        }
        public frmShow_Stores()
        {
            InitializeComponent();
            cmAnbar.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
            cmAnbarGroup.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }

        private Guid _groupGuid;
        public Guid GroupGuid
        {
            get => _groupGuid;
            set => _groupGuid = value;
        }

        public void LoadData(string search = "", Guid groupGuid = default)
        {
            try
            {
                List<AnbarBussines> list;
                if (groupGuid == Guid.Empty)
                    list = AnbarBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                else
                    list = AnbarBussines.Search(search, groupGuid).Where(q => q.Status).OrderBy(q => q.Name).ToList();
                AnbarBindingSource.DataSource = list;

                lblCounter.Text = AnbarBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void FrmShow_Stores_Load(object sender, EventArgs e)
        {
            LoadData();
            FillTreeView();
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var Acc = AnbarBussines.Get(accGuid);
                string message = "آیا از حذف انبار " + Acc.Name + " " + "اطمینان دارید؟";
                frmMessage frm = new frmMessage(EnumMessageFlag.DeleteFlag, Color.PapayaWhip, message);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Acc = AnbarBussines.Change_Status(accGuid, false);
                    if (Acc.Save())
                    {
                        frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green,
                            "عملیات با موفقیت انجام شد");
                        f.ShowDialog();
                        LoadData(txtSearch.Text);
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

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void MnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmStores frm = new frmStores();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text);
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
                if (DGrid.RowCount == 0) return;
                Guid accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmStores frm = new frmStores(accGuid, true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text);
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
                Guid accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                frmStores frm = new frmStores(accGuid, false);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text);
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void FrmShow_Stores_KeyDown(object sender, KeyEventArgs e)
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

        private void MnuSet_Default_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0) return;
                Guid accGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var settingGuid = AppSettingBussines.GetLast();
                AppSettingBussines Setting;
                if (settingGuid == null || settingGuid == Guid.Empty)
                {
                    Setting = new AppSettingBussines();
                    Setting.Guid = Guid.NewGuid();
                    Setting.DateSabt = DateConvertor.M2SH(DateTime.Now);
                }
                else
                {
                    Setting = AppSettingBussines.Get(settingGuid);
                }

                Setting.CurrentAnbar = accGuid;
                if (Setting.Save())
                {
                    frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Green, "عملیات با موفقیت انجام شد");
                    f.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }

        private void FillTreeView()
        {
            try
            {
                trvGroup.Nodes.Clear();
                var lst = AnbarGroupBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                var node = new TreeNode { Text = "همه گروه ها", Name = Guid.Empty.ToString() };
                trvGroup.Nodes.Add(node);
                foreach (var item in lst)
                {
                    node = new TreeNode { Text = item.Name, Name = item.Guid.ToString() };
                    trvGroup.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void trvGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var node = trvGroup.SelectedNode;
                var group = AnbarGroupBussines.Get(Guid.Parse(node.Name));
                GroupGuid = group?.Guid ?? Guid.Empty;
                LoadData(txtSearch.Text, GroupGuid);
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }

        private void mnuInsGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmAnbarGroup();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    FillTreeView();
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
