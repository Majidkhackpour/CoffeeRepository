using System;
using System.Drawing;
using System.Windows.Forms;
using Coffee_ManageMent.Utility;
using DataLayer.Enums;
using System.IO;
using BussinesLayer.Perssonel;

namespace Coffee_ManageMent.Perssonel
{
    public partial class frmPerssonel_CallInfo : Form
    {
        string Pic = null;
        WebCam wb = new WebCam();
        public frmPerssonel_CallInfo()
        {
            InitializeComponent();
        }

        private class NestedCallInfo
        {
            internal static frmPerssonel_CallInfo perssonelCallInfo = new frmPerssonel_CallInfo();

            public NestedCallInfo()
            {
            }
        }

        public static frmPerssonel_CallInfo CallInfo => NestedCallInfo.perssonelCallInfo;

        public PerssonelBussines SetData(PerssonelBussines _perssonel)
        {
            try
            {
                _perssonel.Phone1 = txtPhone1.Text;
                _perssonel.Phone2 = txtPhone2.Text;
                _perssonel.Mobile1 = txtMobile1.Text;
                _perssonel.Mobile2 = txtMobile2.Text;
                _perssonel.Email = txtEmail.Text;
                _perssonel.PostalCode = txtPostalCode.Text;
                _perssonel.Fax = txtFax.Text;
                _perssonel.Address = txtAddress.Text;
                _perssonel.Pic = Pic;
                picPerssonel.Image = null;
                return _perssonel;
            }
            catch (Exception ex)
            {
                frmMessage f = new frmMessage(EnumMessageFlag.ShowFlag, Color.Red, ex.Message);
                f.ShowDialog();
                return null;
            }
        }
        public void FillData(PerssonelBussines _perssonel)
        {
            try
            {
                txtPhone1.Text = _perssonel.Phone1;
                txtPhone2.Text = _perssonel.Phone2;
                txtMobile1.Text = _perssonel.Mobile1;
                txtMobile2.Text = _perssonel.Mobile2;
                txtEmail.Text = _perssonel.Email;
                txtPostalCode.Text = _perssonel.PostalCode;
                txtFax.Text = _perssonel.Fax;
                txtAddress.Text = _perssonel.Address;
                if (_perssonel.Pic != null)
                {
                    var path = Path.Combine(Application.StartupPath + "\\pictures\\Perssonel", _perssonel.Pic);
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
                var picPath = Path.Combine(Application.StartupPath + "\\pictures\\Perssonel", pic);
                picPerssonel.ImageLocation = picPath;
                Pic = pic;
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

                FD.InitialDirectory = Application.StartupPath + "\\pictures\\Perssonel";
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
                if (Application.StartupPath + "\\Pictures\\Perssonel\\" + aa.Name != aa.FullName)
                {
                    string newName = "";
                    newName = aa.Name;
                    while (System.IO.File.Exists(Application.StartupPath + "\\Pictures\\Perssonel\\" + newName))
                    {
                        string nameLen = aa.Name.Length.ToString();
                        var extentionLength = aa.Extension.Length;
                        newName = aa.Name.Substring(0, Convert.ToInt32(double.Parse(nameLen) - extentionLength));
                        newName = newName + attache.ToString() + aa.Extension;
                        attache++;
                    }
                    System.IO.File.Copy(aa.FullName, Application.StartupPath + "\\Pictures\\Perssonel\\" + newName);
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
                    var path = Path.Combine(Application.StartupPath + "\\pictures\\Perssonel", Name);
                    image.Save(path);
                    Pic = Name;
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
