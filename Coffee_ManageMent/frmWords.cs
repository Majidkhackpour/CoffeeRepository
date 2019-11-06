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
    public partial class frmWords : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public frmWords()
        {
            InitializeComponent();
        }

        private void frmWords_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
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

        private void txtFarsi_Enter(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_Persian();
        }

        private void txtEnglish_Enter(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_English();
        }

        private void txtEnglish_Leave(object sender, EventArgs e)
        {
            clsFunction.Switch_Language_To_Persian();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtFarsi, errorProvider1, "این فیلد نمی تواند خالی باشد") == true || clsFunction.Error_Provider(txtEnglish, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                string query = "INSERT INTO tbl_Dictionary (English, Farsi) VALUES ('" + txtEnglish.Text.Trim() + "',N'" + txtFarsi.Text.Trim() + "')";
                if (clsFunction.Execute(dataconnection, query) == true)
                    this.Close();
            }
        }
    }
}
