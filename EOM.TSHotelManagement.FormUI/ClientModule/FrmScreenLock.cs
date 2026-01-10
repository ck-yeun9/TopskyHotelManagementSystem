using AntdUI;
using EOM.TSHotelManagement.Shared;
using jvncorelib.EncryptorLib;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmScreenLock : Window
    {
        public FrmScreenLock()
        {
            InitializeComponent();
        }

        private void FrmScreenLock_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {

        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == string.Empty)
            {
                NotificationService.ShowError("密码不能为空，请重新输入！");
                txtPassword.Focus();
                return;
            }
            var password = new EncryptLib().Decryption(LoginInfo.Password);
            if (password != null && password == txtPassword.Text.Trim())
            {
                this.Close();
            }
            else
            {
                NotificationService.ShowError("密码错误，请重新输入！");
                txtPassword.Focus();
                txtPassword.Clear();
            }
        }
    }
}
