using System;
using System.Drawing;
using System.Windows.Forms;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using System.IO;
using BussinesLayer.Perssonel;
using BussinesLayer.Sellers;

namespace Coffee_ManageMent.Sellers
{
    public partial class frmSeller_CallInfo : Form
    {
        private string pic = null;
        private readonly WebCam wb = new WebCam();
        public frmSeller_CallInfo()
        {
            InitializeComponent();
        }

        private class NestedCallInfo
        {
            internal static frmSeller_CallInfo sellerCallInfo = new frmSeller_CallInfo();

            public NestedCallInfo()
            {
            }
        }

        public static frmSeller_CallInfo CallInfo => NestedCallInfo.sellerCallInfo;

        public SellerBussines SetData(SellerBussines _seller)
        {
            try
            {
                _seller.Phone1 = txtPhone1.Text;
                _seller.Phone2 = txtPhone2.Text;
                _seller.Mobile1 = txtMobile1.Text;
                _seller.Mobile2 = txtMobile2.Text;
                _seller.Email = txtEmail.Text;
                _seller.PostalCode = txtPostalCode.Text;
                _seller.Fax = txtFax.Text;
                _seller.Address = txtAddress.Text;
                _seller.Pic = pic;
                picPerssonel.Image = null;
                return _seller;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
        public void FillData(SellerBussines _seller)
        {
            try
            {
                txtPhone1.Text = _seller.Phone1;
                txtPhone2.Text = _seller.Phone2;
                txtMobile1.Text = _seller.Mobile1;
                txtMobile2.Text = _seller.Mobile2;
                txtEmail.Text = _seller.Email;
                txtPostalCode.Text = _seller.PostalCode;
                txtFax.Text = _seller.Fax;
                txtAddress.Text = _seller.Address;
                if (_seller.Pic != null)
                {
                    var path = Path.Combine(Application.StartupPath + "\\pictures\\Seller", _seller.Pic);
                    if (path != null)
                        picPerssonel.ImageLocation = path;
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        private void TxtPhone1_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtPhone1);
        }

        private void TxtMobile1_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtMobile1);
        }

        private void TxtFax_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtFax);
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtEmail);
            txtSetter.Switch_Language_To_English();
        }

        private void TxtAddress_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtAddress);
        }

        private void TxtPostalCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtPostalCode);
        }

        private void TxtMobile2_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtMobile2);
        }

        private void TxtPhone2_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txt2: txtPhone2);
        }

        private void TxtPhone2_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtPhone2);
        }

        private void TxtMobile2_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtMobile2);
        }

        private void TxtPostalCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtPostalCode);
        }

        private void TxtAddress_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtAddress);
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtEmail);
            txtSetter.Switch_Language_To_Persian();
        }

        private void TxtFax_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtFax);
        }

        private void TxtMobile1_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtMobile1);
        }

        private void TxtPhone1_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txt2: txtPhone1);
        }

        private void LblAddPic_Click(object sender, EventArgs e)
        {
            try
            {
                string pic = LoadFromFile();
                var picPath = Path.Combine(Application.StartupPath + "\\pictures\\Seller", pic);
                picPerssonel.ImageLocation = picPath;
                this.pic = pic;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }
        }
        private string LoadFromFile()
        {
            try
            {
                OpenFileDialog FD = new OpenFileDialog();
                FD.Multiselect = false;

                FD.InitialDirectory = Application.StartupPath + "\\pictures\\Seller";
                if (!System.IO.Directory.Exists(FD.InitialDirectory))
                {
                    System.IO.Directory.CreateDirectory(FD.InitialDirectory);
                }
                FD.Filter = "*.JPG;*.GIF;*.PNG|*.JPG;*.GIF;*.PNG";
                if (!(FD.ShowDialog() == DialogResult.OK))
                {
                    return null;
                }
                System.IO.FileInfo aa = new System.IO.FileInfo(FD.FileName);
                int attache = 1;
                if (Application.StartupPath + "\\Pictures\\Seller\\" + aa.Name != aa.FullName)
                {
                    string newName = "";
                    newName = aa.Name;
                    while (System.IO.File.Exists(Application.StartupPath + "\\Pictures\\Seller\\" + newName))
                    {
                        string nameLen = aa.Name.Length.ToString();
                        var extentionLength = aa.Extension.Length;
                        newName = aa.Name.Substring(0, Convert.ToInt32(double.Parse(nameLen) - extentionLength));
                        newName = newName + attache.ToString() + aa.Extension;
                        attache++;
                    }
                    System.IO.File.Copy(aa.FullName, Application.StartupPath + "\\Pictures\\Seller\\" + newName);
                    return newName;
                }
                else
                {
                    return aa.Name;
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }

        private void LblAddPic_MouseEnter(object sender, EventArgs e)
        {
            lblSetter.GotFocose(lblAddPic);
        }

        private void LblWebCam_MouseEnter(object sender, EventArgs e)
        {
            lblSetter.GotFocose(lblWebCam);
        }

        private void LblDelPic_MouseEnter(object sender, EventArgs e)
        {
            lblSetter.GotFocose(lblDelPic);
        }

        private void LblDelPic_MouseLeave(object sender, EventArgs e)
        {
            lblSetter.LostFocose(lblDelPic);
        }

        private void LblWebCam_MouseLeave(object sender, EventArgs e)
        {
            lblSetter.LostFocose(lblWebCam);
        }

        private void LblAddPic_MouseLeave(object sender, EventArgs e)
        {
            lblSetter.LostFocose(lblAddPic);
        }

        private void LblDelPic_Click(object sender, EventArgs e)
        {
            picPerssonel.Image = null;
        }

        private void LblWebCam_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblWebCam.Text == "استفاده از WebCam")
                {
                    wb.InitializeWebCam(ref picPerssonel);
                    try
                    {
                        wb.Start();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        wb.Continue();
                        lblWebCam.Text = "عکس گرفتن";
                    }
                }
                else if (lblWebCam.Text == "عکس گرفتن")
                {
                    wb.Stop();
                    lblWebCam.Text = "استفاده از WebCam";
                    Image image = picPerssonel.Image;
                    string Name = Guid.NewGuid().ToString() + ".jpg";
                    var path = Path.Combine(Application.StartupPath + "\\pictures\\Seller", Name);
                    image.Save(path);
                    pic = Name;
                }
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
            }

        }
    }
}
