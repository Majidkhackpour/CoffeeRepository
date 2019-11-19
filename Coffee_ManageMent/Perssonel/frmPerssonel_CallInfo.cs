using System;
using System.Drawing;
using System.Windows.Forms;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmPerssonel_CallInfo : Form
    {
        public frmPerssonel_CallInfo()
        {
            InitializeComponent();
        }

        private class NestedCallInfo
        {
            internal static frmPerssonel_CallInfo perssonelCallInfo = new frmPerssonel_CallInfo();

            public NestedCallInfo()
            {
            }
        }

        public static frmPerssonel_CallInfo CallInfo => NestedCallInfo.perssonelCallInfo;

        public DataLayer.Models.Perssonel.Perssonel SetData(DataLayer.Models.Perssonel.Perssonel _perssonel)
        {
            try
            {
                _perssonel.Phone1 = txtTell1.Text;
                return _perssonel;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
    }
}
