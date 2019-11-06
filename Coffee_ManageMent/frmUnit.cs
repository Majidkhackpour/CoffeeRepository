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
    public partial class frmUnit : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        public string op, s_Unit_Name;
        int Counter_Name, Flag;
        public void Display()
        {
            string Query = "SELECT * FROM tbl_Unit ORDER BY Unit_Code ASC";
            clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
        }
        public void Clear()
        {
            txtCode.Text = txtName.Text = "";
        }
        private bool Check_Unit_Name()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Unit_Name FROM tbl_Unit WHERE Unit_Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Unit_Name = (string)dr["Unit_Name"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Unit_Name == txtName.Text)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private bool Check_Unit_Name_ForEdit()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT COUNT(Unit_Name) FROM tbl_Unit WHERE Unit_Name LIKE N'" + txtName.Text.Trim() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Counter_Name = (int)dr[0];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (Counter_Name > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmUnit()
        {
            InitializeComponent();
        }

        private void frmUnit_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            ExPanel.Expanded = false;
            Display();
            Clear();
            Flag = 0;
            clsFunction.AutoComplete("SELECT Unit_Name FROM tbl_Unit", dataconnection, txtName);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExPanel.Expanded = false;
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            op = "Add";
            Clear();
            Flag = 1;
            string query2 = "SELECT MAX (Unit_Code) FROM tbl_Unit";
            clsFunction.txt_NewCode(dataconnection, query2, txtCode, "1");
            ExPanel.Expanded = true;
            txtName.Focus();
            frmUnit_Activated(null, null);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (clsFunction.Error_Provider(txtName, errorProvider1, "این فیلد نمی تواند خالی باشد") == true)
            {
            }
            else
            {
                errorProvider1.Clear();
                if (op == "Add")
                {
                    if (Check_Unit_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "واحد شمارش با نام  " + txtName.Text + " " + "از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "INSERT INTO tbl_Unit (Unit_Code, Unit_Name) VALUES ('" + Convert.ToInt32(txtCode.Text) + "',N'" + txtName.Text.Trim() + "')";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            ExPanel.Expanded = false;
                            Display();
                            Clear();
                            Flag = 0;
                            frmUnit_Activated(null, null);
                        }
                    }
                }
                else if (op == "Edit")
                {
                    if (Check_Unit_Name() == true)
                    {
                        frmMessage f = new frmMessage();
                        f.flag = 0;
                        f.lblMessage.Text = "واحد شمارش با نام  " + txtName.Text + " " + "از پیش تعریف شده است";
                        f.ShowDialog();
                    }
                    else
                    {
                        string query = "UPDATE tbl_Unit SET Unit_Name = N'" + txtName.Text.Trim() + "' WHERE Unit_Code = '" + Convert.ToInt32(txtCode.Text) + "'";
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            ExPanel.Expanded = false;
                            Display();
                            Clear();
                            Flag = 0;
                            frmUnit_Activated(null, null);
                        }
                    }
                }
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnFinish.Focus();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                op = "Edit";
                Clear();
                Flag = 1;
                txtCode.Text = dgvTables.CurrentRow.Cells["Unit_Code"].Value.ToString();
                txtName.Text = dgvTables.CurrentRow.Cells["Unit_Name"].Value.ToString();
                ExPanel.Expanded = true;
                txtName.Focus();
                frmUnit_Activated(null, null);
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "واحد انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void frmUnit_Activated(object sender, EventArgs e)
        {
            if (Flag == 0)
                btnFinish.Enabled = false;
            else
                btnFinish.Enabled = true;
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Unit WHERE Unit_Code='" + Convert.ToInt32(dgvTables.CurrentRow.Cells["Unit_Code"].Value.ToString()) + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف واحد شمارش " + dgvTables.CurrentRow.Cells["Unit_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                    {
                        ExPanel.Expanded = false;
                        Display();
                        Clear();
                        Flag = 0;
                        frmUnit_Activated(null, null);
                    }
                        
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این واحد شمارش نمی باشید";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT * FROM tbl_Unit WHERE Unit_Name LIKE N'%" + txtSearch.Text + "%' ORDER BY Unit_Code ASC";
                clsFunction.Display(Query, dataconnection, dgvTables, lblCounter);
            }
            catch
            {
            }
        }
    }
}
