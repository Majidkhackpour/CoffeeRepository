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
    public partial class frmWifi : Form
    {
        public frmWifi()
        {
            InitializeComponent();
        }

        private void frmWifi_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            SimpleWifi.Wifi wifi = new SimpleWifi.Wifi();
            lblState.Text = wifi.ConnectionStatus.ToString();
            if (lblState.Text == "Connected")
            {
                lblState.ForeColor = Color.Green;
                btnFinish.Text = "قطع اتصال";
            }
            else if (lblState.Text == "Disconnected")
            {
                lblState.ForeColor = Color.Red;
                btnFinish.Text = "اتصال";
            }
            List<SimpleWifi.AccessPoint> ac = wifi.GetAccessPoints();
            wifi.GetAccessPoints();
            for (int i = 0; i < ac.Count; i++)
            {
                lbxAccess_Point.Items.Add(ac[i].Name + " " + ac[i].SignalStrength + "%");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

            SimpleWifi.Wifi wifi = new SimpleWifi.Wifi();
            if (btnFinish.Text == "اتصال")
            {
                List<SimpleWifi.AccessPoint> ac = wifi.GetAccessPoints();
                wifi.GetAccessPoints();
                SimpleWifi.AuthRequest req = new SimpleWifi.AuthRequest(ac[lbxAccess_Point.SelectedIndex]);
                req.Password = txtPass.Text;
                ac[lbxAccess_Point.SelectedIndex].Connect(req);
                txtPass.Text = "";
                lblState.Text = wifi.ConnectionStatus.ToString();
                if (lblState.Text == "Connected")
                {
                    lblState.ForeColor = Color.Green;
                    btnFinish.Text = "قطع اتصال";
                }
                else if (lblState.Text == "Disconnected")
                {
                    lblState.ForeColor = Color.Red;
                    btnFinish.Text = "اتصال";
                }
            }
            else if (btnFinish.Text == "قطع اتصال")
            {
                wifi.Disconnect();
                lblState.Text = wifi.ConnectionStatus.ToString();
                txtPass.Text = "";
                if (lblState.Text == "Connected")
                {
                    lblState.ForeColor = Color.Green;
                    btnFinish.Text = "قطع اتصال";
                }
                else if (lblState.Text == "Disconnected")
                {
                    lblState.ForeColor = Color.Red;
                    btnFinish.Text = "اتصال";
                }
            }
        }

        private void chbPoss_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPoss.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
