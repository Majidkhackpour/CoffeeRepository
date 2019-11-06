using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent
{
    public partial class frmCircle_Progress : Form
    {
        public frmCircle_Progress()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgress1.Value += 1;
            lblCounter.Text = circularProgress1.Value.ToString();
            if (circularProgress1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
            }
        }
    }
}
