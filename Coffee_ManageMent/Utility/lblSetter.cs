using System.Drawing;
using System.Windows.Forms;

namespace Coffee_ManageMent.Utility
{
    public static class lblSetter
    {
        public static void LostFocose(Label lbl)
        {
            lbl.ForeColor = Color.Gainsboro;
        }
        public static void GotFocose(Label lbl)
        {
            lbl.ForeColor = Color.Red;
        }
    }
}
