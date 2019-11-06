using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_ManageMent
{
    public partial class frmWeb_Browser : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmWeb_Browser()
        {
            InitializeComponent();
        }

        private void frmWeb_Browser_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            clsFunction.Switch_Language_To_English();
            toolTip1.SetToolTip(btnBack, "Back");
            toolTip1.SetToolTip(btnForward, "Forward");
            toolTip1.SetToolTip(picBing, "Bing.com");
            toolTip1.SetToolTip(picFavorite, "Bookmark");
            toolTip1.SetToolTip(picGoogle, "Google.com");
            toolTip1.SetToolTip(picYahoo, "Yahoo.com");
            toolTip1.SetToolTip(picShow_Fav, "Show Favorites");
            toolTip1.SetToolTip(picHistory, "History");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picGoogle_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("www.google.com");
                txtSearch.Text = "www.google.com";
            }
            catch
            {
                txtSearch.Text = "";
            }
        }

        private void picYahoo_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("www.yahoo.com");
                txtSearch.Text = "www.yahoo.com";
            }
            catch
            {
                txtSearch.Text = "";
            }
        }

        private void picBing_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("www.bing.com");
                txtSearch.Text = "www.bing.com";
            }
            catch
            {
                txtSearch.Text = "";
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(txtSearch.Text);
                try
                {
                    string query = "INSERT INTO tbl_Web_History (Link, Date, Time) VALUES (N'" + webBrowser1.Url.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
                catch
                {
                    string query = "INSERT INTO tbl_Web_History (Link, Date, Time) VALUES (N'" + txtSearch.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.GoForward();
                try
                {
                    string query = "INSERT INTO tbl_Web_History (Link, Date, Time) VALUES (N'" + webBrowser1.Url.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
                catch
                {
                    string query = "INSERT INTO tbl_Web_History (Link, Date, Time) VALUES (N'" + txtSearch.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.GoBack();
                try
                {
                    string query = "INSERT INTO tbl_Web_History (Link, Date, Time) VALUES (N'" + webBrowser1.Url.ToString() + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
                catch
                {
                    string query = "INSERT INTO tbl_Web_History (Link, Date, Time) VALUES (N'" + txtSearch.Text + "','" + clsFunction.M2SH(DateTime.Now) + "','" + System.DateTime.Now.ToLongTimeString() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void picFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    string query = "INSERT INTO tbl_Web_Favorites (Link) VALUES (N'" + webBrowser1.Url.ToString() + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
                catch
                {
                    string query = "INSERT INTO tbl_Web_Favorites (Link) VALUES (N'" + txtSearch.Text + "')";
                    if (clsFunction.Execute(dataconnection, query) == true)
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void picHistory_Click(object sender, EventArgs e)
        {
            try
            {
                frmWeb_History f = new frmWeb_History();
                f.ShowDialog();
                txtSearch.Text = f.URL;
            }
            catch
            {
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnGo_Click(null, null);
        }

        private void picShow_Fav_Click(object sender, EventArgs e)
        {
            try
            {
                frmWeb_Favoriets f = new frmWeb_Favoriets();
                f.ShowDialog();
                txtSearch.Text = f.URL;
            }
            catch
            {
            }
        }
    }
}
