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
    public partial class frmShow_Customer : Form
    {
        SqlConnection dataconnection = new SqlConnection(clsFunction.Connection_string);
        string s_Acc_Code;
        private bool Check_Account_On_Customer_Club()
        {
            try
            {
                SqlCommand cmd;
                dataconnection.Open();
                cmd = new SqlCommand("SELECT Code FROM tbl_Customer_Club WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'", dataconnection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s_Acc_Code = (string)dr["Code"];
                    }
                }
                dr.Close();
                cmd.ExecuteNonQuery();
                dataconnection.Close();
                if (s_Acc_Code == dgvStore.CurrentRow.Cells["Code"].Value.ToString())
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public frmShow_Customer()
        {
            InitializeComponent();
        }

        private void frmShow_Customer_Load(object sender, EventArgs e)
        {
            clsFunction.Display_Header(lblDay, lblNewDate);
            timer1_Tick(null, null);
            string Query = "SELECT tbl_Customer.Code, tbl_Account.Description, tbl_PhoneBook.Mobile, tbl_Customer_Group.Name FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code INNER JOIN tbl_PhoneBook ON tbl_Account.Code = tbl_PhoneBook.Code INNER JOIN tbl_Customer_Group ON tbl_Customer.Cus_Group = tbl_Customer_Group.ID ORDER BY tbl_Customer.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsFunction.Timer_Dispaly(lblHour, lblMin, lblSec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer f = new frmCustomer();
                f.op = "Add";
                f.Form_Load();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void frmShow_Customer_Activated(object sender, EventArgs e)
        {
            string Query = "SELECT tbl_Customer.Code, tbl_Account.Description, tbl_PhoneBook.Mobile, tbl_Customer_Group.Name FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code INNER JOIN tbl_PhoneBook ON tbl_Account.Code = tbl_PhoneBook.Code INNER JOIN tbl_Customer_Group ON tbl_Customer.Cus_Group = tbl_Customer_Group.ID ORDER BY tbl_Customer.Code ASC";
            clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer f = new frmCustomer();
                f.op = "Edit";
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مشتری انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "DELETE FROM tbl_Customer WHERE Code='" + dgvStore.CurrentRow.Cells["Code"].Value.ToString() + "'";
                frmMessage f = new frmMessage();
                f.lblMessage.Text = "آیا از حذف " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "اطمینان دارید؟";
                f.flag = 1;
                f.ShowDialog();
                if (f.Resault == 0)
                {
                    if (clsFunction.Execute(dataconnection, query1) == true)
                        frmShow_Customer_Activated(null, null);
                }
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "شما قادر به حذف این مشتری نمی باشید";
                f.ShowDialog();
            }
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer f = new frmCustomer();
                f.FillData(dgvStore.CurrentRow.Cells["Code"].Value.ToString());
                f.groupPanel1.Enabled = false;
                f.btnFinish.Enabled = false;
                f.ShowDialog();
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "مشتری انتخابی معتبر نمی باشد";
                f.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT tbl_Customer.Code, tbl_Account.Description, tbl_PhoneBook.Mobile, tbl_Customer_Group.Name FROM tbl_Customer INNER JOIN tbl_Account ON tbl_Customer.Code = tbl_Account.Code INNER JOIN tbl_PhoneBook ON tbl_Account.Code = tbl_PhoneBook.Code INNER JOIN tbl_Customer_Group ON tbl_Customer.Cus_Group = tbl_Customer_Group.ID WHERE tbl_Customer.Code LIKE N'%" + txtSearch.Text + "%' OR tbl_Account.Description LIKE N'%" + txtSearch.Text + "%' OR tbl_PhoneBook.Mobile LIKE N'%" + txtSearch.Text + "%' OR tbl_Customer_Group.Name LIKE N'%" + txtSearch.Text + "%' ORDER BY tbl_Customer.Code ASC";
                clsFunction.Display(Query, dataconnection, dgvStore, lblCounter);
            }
            catch
            {
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSub_Code_Click(object sender, EventArgs e)
        {
            try
            {
                frmSubscription_Code f = new frmSubscription_Code();
                f.txtCode.Text = dgvStore.CurrentRow.Cells["Code"].Value.ToString();
                f.txtName.Text = dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString();
                f.Find_Sub_Code();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void mnuExport_To_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                clsFunction.Export_Data_To_Excel(dgvStore);
            }
            catch
            {
                frmMessage f = new frmMessage();
                f.flag = 0;
                f.lblMessage.Text = "سیستم شما قادر به ایجاد فایل اکسل نمی باشد. لطفا تنظیمات ویندوز را بررسی و مجددا تلاش نمایید";
                f.ShowDialog();
            }
        }

        private void mnuCus_Club_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check_Account_On_Customer_Club() == true)
                {
                    frmMessage f = new frmMessage();
                    f.flag = 0;
                    f.lblMessage.Text = dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "از پیش تعریف شده است";
                    f.ShowDialog();
                }
                else
                {
                    string query = "INSERT INTO tbl_Customer_Club (Code, Point) VALUES ('" + dgvStore.CurrentRow.Cells["Code"].Value.ToString().Trim() + "',0)";
                    frmMessage f = new frmMessage();
                    f.lblMessage.Text = "آیا از افزودن " + dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString() + " " + "به باشگاه مشتریان اطمینان دارید؟";
                    string Cus_Name = dgvStore.CurrentRow.Cells["Perssonel_Name"].Value.ToString();
                    f.flag = 1;
                    f.ShowDialog();
                    if (f.Resault == 0)
                    {
                        if (clsFunction.Execute(dataconnection, query) == true)
                        {
                            frmMessage f0 = new frmMessage();
                            f0.flag = 0;
                            f0.lblMessage.Text = "افزودن " + Cus_Name + " " + "به باشگاه مشتریان، با موفقیت انجام شد";
                            f0.ShowDialog();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void mnuGroup_Click(object sender, EventArgs e)
        {
            new frmShow_Cus_Group().ShowDialog();
        }
    }
}
