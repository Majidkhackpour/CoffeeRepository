using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.Context;
using PersitenceLayer.Persistance;

namespace Coffee_ManageMent.Hazine
{
    public partial class frmShow_Hazine : Form
    {
        void Load_Data(string search)
        {
            UnitOfWork db = new UnitOfWork();
            if (search == null)
            {
                HazineBindingSource.DataSource = db.HazineRepository.GetAll();
            }
        }
        public frmShow_Hazine()
        {
            InitializeComponent();
        }

        private void frmShow_Hazine_Load(object sender, EventArgs e)
        {
            Load_Data(null);
        }
    }
}
