using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BussinesLayer.Banks;
using BussinesLayer.Sellers;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.BankHesab
{
    public partial class frmShow_Bank : Form
    {
        public void LoadData(string search = "")
        {
            try
            {
                if (search == "")
                {
                    var lst = BanksBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                    BankBindingSource.DataSource = lst.ToList();
                }
                //else
                //{
                //    var list = SellerBussines.Search(search).Where(q => q.Status).OrderBy(q => q.Name).ToList();
                //    SellerBindingSource.DataSource = list;
                //}

                lblCounter.Text = BankBindingSource.Count.ToString();
            }
            catch (Exception exception)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, exception.Message);
                frm.ShowDialog();
            }
        }
        public frmShow_Bank()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new ContextMenuSetter());
        }

        private void frmShow_Bank_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmShow_Bank_KeyDown(object sender, KeyEventArgs e)
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
                var frm = new frmBank();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                frmMessage frm = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                frm.ShowDialog();
            }
        }
    }
}
