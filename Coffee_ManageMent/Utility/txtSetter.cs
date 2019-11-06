using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent.Utility
{
    public static class txtSetter
    {

        public static void Focus(DevComponents.DotNetBar.Controls.TextBoxX txt = null, TextBox txt2 = null)
        {
            if (txt == null)
            {
                txt2.BackColor = Color.White;
                txt2.ForeColor = Color.Black;
                return;
            }
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;
        }

        public static void Follow(DevComponents.DotNetBar.Controls.TextBoxX txt = null, TextBox txt2 = null)
        {
            Color colour = ColorTranslator.FromHtml("#17212b");
            if (txt == null)
            {
                txt2.BackColor = colour;
                txt2.ForeColor = Color.White;
                return;
            }
            txt.BackColor = colour;
            txt.ForeColor = Color.White;
        }

        public static void KeyPress_Whit_Dot(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 45 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
                e.KeyChar = Convert.ToChar(Keys.None);
        }
        public static void KeyPress_Whitout_Dot(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) <= 57 & Convert.ToInt32(e.KeyChar) >= 48 || Convert.ToInt32(e.KeyChar) <= 1785 & Convert.ToInt32(e.KeyChar) >= 1776 || Convert.ToInt32(e.KeyChar) == 8)
            {
            }
            else
                e.KeyChar = Convert.ToChar(Keys.None);
        }

        public static void KeyDown(object sender, KeyEventArgs e, DevComponents.DotNetBar.ButtonX btn)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
            if (e.KeyCode == Keys.F5)
                btn.PerformClick();
        }
    }
}
