/*
 * MIT License
 *Copyright (c) 2021 易开元(EOM)

 *Permission is hereby granted, free of charge, to any person obtaining a copy
 *of this software and associated documentation files (the "Software"), to deal
 *in the Software without restriction, including without limitation the rights
 *to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *copies of the Software, and to permit persons to whom the Software is
 *furnished to do so, subject to the following conditions:

 *The above copyright notice and this permission notice shall be included in all
 *copies or substantial portions of the Software.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *SOFTWARE.
 *
 */

using AntdUI;
using EOM.TSHotelManagement.Common;
using EOM.TSHotelManagement.Contract;
using EOM.TSHotelManagement.Shared;
using jvncorelib.EncryptorLib;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmLogin : Window
    {
        private LoadingProgress _loadingProgress;
        public FrmLogin()
        {
            InitializeComponent();
            _loadingProgress = new LoadingProgress();
            #region 防止背景闪屏方法
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲 
            #endregion
        }

        ResponseMsg result = new ResponseMsg();

        #region 记录鼠标和窗体坐标的方法
        private Point mouseOld;//鼠标旧坐标
        private Point formOld;//窗体旧坐标 
        #endregion

        #region 记录移动的窗体坐标
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            formOld = this.Location;
            mouseOld = MousePosition;
        }
        #endregion

        #region 记录窗体移动的坐标
        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouseNew = MousePosition;
                int moveX = mouseNew.X - mouseOld.X;
                int moveY = mouseNew.Y - mouseOld.Y;
                this.Location = new Point(formOld.X + moveX, formOld.Y + moveY);
            }
        }
        #endregion

        #region 最小化窗体事件方法
        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        #endregion

        #region 关闭窗体事件方法
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();
            btnMinimize.IconSvg = UIControlIconConstant.Minimize;
            btnClose.IconSvg = UIControlIconConstant.Close;
            txtAccount.PlaceholderText = LocalizationHelper.GetLocalizedString("Please input employee number or email", "请输入员工编号或邮箱");
            txtWorkerPwd.PlaceholderText = LocalizationHelper.GetLocalizedString("Please input employee password", "请输入员工密码");
        }

        #region 检验输入完整性
        /// <summary>
        /// 检验输入完整性
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (txtAccount.Text == "")
            {
                NotificationService.ShowError(LocalizationHelper.GetLocalizedString("Please input employee number or email", "请输入员工编号或邮箱地址"));
                txtAccount.Focus();
                return false;
            }
            if (txtWorkerPwd.Text == "")
            {
                NotificationService.ShowError(LocalizationHelper.GetLocalizedString("Please input password", "请输入员工密码"));
                txtWorkerPwd.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 登录图片点击事件
        private void picLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    var worker = new EmployeeLoginDto() { EmployeeId = txtAccount.Text.Trim(), EmailAddress = txtAccount.Text.Trim(), Password = new EncryptLib().Encryption(txtWorkerPwd.Text.Trim(), EncryptionLevel.Enhanced) };

                    var json = worker.ModelToJson();

                    result = HttpHelper.Request(ApiConstants.Employee_EmployeeLogin, worker.ModelToJson());

                    var response = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeeOutputDto>>(result.message);

                    if (response.Success == false)
                    {
                        NotificationService.ShowError(LocalizationHelper.GetLocalizedString($"{ApiConstants.Employee_EmployeeLogin} is abnormal. Please submit an issue", $"{ApiConstants.Employee_EmployeeLogin}+接口服务异常，请提交issue"));
                        return;
                    }

                    ReadEmployeeOutputDto w = response.Data;

                    if (!w.IsNullOrEmpty())
                    {
                        if (w.IsEnable == 0)
                        {
                            NotificationService.ShowError(LocalizationHelper.GetLocalizedString("The account has been disabled, please contact your superiors to unblock it!", "账号已禁用，请联系上级解封！"));
                            return;
                        }

                        LoginInfo.WorkerNo = w.EmployeeId;
                        LoginInfo.WorkerName = w.EmployeeName;
                        LoginInfo.WorkerClub = w.DepartmentName;
                        LoginInfo.WorkerPosition = w.PositionName;
                        LoginInfo.Password = new EncryptLib().Encryption(txtWorkerPwd.Text.Trim(), EncryptionLevel.Enhanced);
                        LoginInfo.SoftwareVersion = ApplicationUtil.GetApplicationVersion().ToString();
                        LoginInfo.UserToken = w.UserToken;

                        if (w.IsInitialize == 0)
                        {
                            NotificationService.ShowError(LocalizationHelper.GetLocalizedString("The initial password for the current account has not been changed, and it will be directed to the change page later", "当前账号未修改初始密码，稍后将引导至修改页面"));
                            FrmAccountSecurity frmAccountSecurity = new FrmAccountSecurity();
                            frmAccountSecurity.ShowDialog();
                        }

                        FrmMain frm = new FrmMain(this);
                        this.Hide();
                        frm.ShowDialog(this);
                    }
                    else
                    {
                        NotificationService.ShowError(LocalizationHelper.GetLocalizedString("Employee number/email or password incorrect", "员工编号/邮箱地址或密码错误！"));
                        txtWorkerPwd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                RecordHelper.Record(LocalizationHelper.GetLocalizedString($"Login error:{ex.Message}", $"登录异常:{ex.Message}"), Common.LogLevel.Critical);
                NotificationService.ShowError(LocalizationHelper.GetLocalizedString("The server is under maintenance, please try again later", "服务器维护中，请稍后再试！"));
            }
        }
        #endregion

    }
}
