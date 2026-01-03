using AntdUI;
using EOM.TSHotelManagement.Common;
using EOM.TSHotelManagement.Contract;
using EOM.TSHotelManagement.Shared;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmAccountSecurity : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountSecurity));
        public FrmAccountSecurity()
        {
            InitializeComponent();

            ucWindowHeader1.ApplySettingsWithoutMinimize("账号安全", string.Empty, (Image)resources.GetObject("FrmAccountSecurity.Icon")!);
        }

        private void FrmAccountSecurity_Load(object sender, EventArgs e)
        {
            lblEmployeeId.Text = LoginInfo.WorkerNo;
            txtOldPassword.PlaceholderText = LocalizationHelper.GetLocalizedString("Please input old password", "请输入旧密码");
            txtNewPassword.PlaceholderText = LocalizationHelper.GetLocalizedString("Please input new password", "请输入新密码");
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text) || string.IsNullOrEmpty(txtNewPassword.Text))
            {
                NotificationService.ShowWarning(LocalizationHelper.GetLocalizedString("Please input new password or old password", "请输入旧密码或新密码"));
                return;
            }

            var employee = new UpdateEmployeeInputDto
            {
                EmployeeId = LoginInfo.WorkerNo,
                OldPassword = txtOldPassword.Text.Trim(),
                Password = txtNewPassword.Text.Trim(),
                DataChgDate = DateTime.Now,
                DataChgUsr = LoginInfo.WorkerNo
            };
            var request = HttpHelper.Request(ApiConstants.Employee_UpdateEmployeeAccountPassword, employee.ModelToJson());
            var response = HttpHelper.JsonToModel<BaseResponse>(request.message);
            if (response.Success == false)
            {
                NotificationService.ShowError(LocalizationHelper.GetLocalizedString($"{ApiConstants.Employee_UpdateEmployeeAccountPassword}+Interface service exception, please submit an issue or try updating the version!", $"{ApiConstants.Employee_UpdateEmployeeAccountPassword}+接口服务异常，请提交Issue或尝试更新版本！"));
                return;
            }
            NotificationService.ShowSuccess(LocalizationHelper.GetLocalizedString("Update password success", "更新密码成功"));
            return;
        }
    }
}
