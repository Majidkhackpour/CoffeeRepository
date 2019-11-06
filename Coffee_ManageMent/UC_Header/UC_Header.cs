using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Class;
using System.ComponentModel.Design;

namespace UC_Header
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design",typeof(IDesigner))]
    public partial class UC_Header : UserControl
    {
        public UC_Header()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return lblTitle.Text;}
            set { lblTitle.Text = value; }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHour.Text = System.DateTime.Now.Hour.ToString();
            lblMin.Text = System.DateTime.Now.Minute.ToString();
            if (lblSec.Visible == true)
                lblSec.Visible = false;
            else if (lblSec.Visible == false)
                lblSec.Visible = true;
        }

        private void UC_Header_Load(object sender, EventArgs e)
        {
            lblDay.Text = lblNewDate.Text = "";
            MaftooxCalendar.MaftooxPersianCalendar.DateWork PRD = new MaftooxCalendar.MaftooxPersianCalendar.DateWork();
            lblDay.Text = PRD.GetNameDayInMonth();
            lblNewDate.Text = PRD.GetNumberDayInMonth() + " " + PRD.GetNameMonth() + " " + PRD.GetNumberYear();
            timer1_Tick(null, null);
        }
    }
}
