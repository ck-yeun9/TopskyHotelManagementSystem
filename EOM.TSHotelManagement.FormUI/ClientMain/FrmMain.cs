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
using EOM.TSHotelManagement.FormUI.Properties;
using jvncorelib.CodeLib;
using jvncorelib.EntityLib;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmMain : Window
    {
        private FrmLogin returnForm1 = null;
        private LoadingProgress _loadingProgress;

        public FrmMain(FrmLogin F1)
        {
            InitializeComponent();
            _loadingProgress = new LoadingProgress();

            #region 防止背景闪屏方法
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲 
            #endregion
            cpUITheme.ValueChanged += cpUITheme_ValueChanged;
            Control.CheckForIllegalCrossThreadCalls = false;//关闭线程检查
            //Main = this;//储存主窗口实例对象
            // 接受Form1对象
            this.returnForm1 = F1;
            #region 获取添加操作日志所需的信息
            RecordHelper.Record(LoginInfo.WorkerNo + "-" + LoginInfo.WorkerName + "在" + Convert.ToDateTime(DateTime.Now) + "位于" + LoginInfo.SoftwareVersion + "版本登入了系统！", LogLevel.Critical);
            #endregion
            Stop = StopUseExit;
            Start = StartUseExit;
            CloseMy = CloseMine;
        }

        public delegate void StopUseList();
        //定义委托类型的变量
        public static StopUseList Stop;

        public delegate void StarUseList();
        //定义委托类型的变量
        public static StarUseList Start;

        public static StarUseList CloseMy;

        ResponseMsg result = new ResponseMsg();

        public void StopUseExit()
        {
            niClientIcon.Visible = false;
        }

        public void StartUseExit()
        {
            niClientIcon.Visible = true;
        }

        public static string wk_WorkerName;
        public static string wk_WorkerNames;

        #region 记录鼠标和窗体坐标的方法
        private Point mouseOld;//鼠标旧坐标
        private Point formOld;//窗体旧坐标 
        #endregion

        #region 记录移动的窗体坐标
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            formOld = this.Location;
            mouseOld = MousePosition;
        }
        #endregion

        #region 记录窗体移动的坐标
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
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

        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
       IntPtr hwnd,
       int nIndex,
       uint dwNewLong
       );
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
       IntPtr hwnd,
       int nIndex
       );
        /// <summary>
        /// 使窗口有鼠标穿透功能
        /// </summary>
        public void CanPenetrate()
        {
            uint intExTemp = GetWindowLong(this.Handle, GWL_EXSTYLE);
            uint oldGWLEx = SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }

        ListOutputDto<ReadPromotionContentOutputDto> fonts = null;
        int fontn = 0;
        private void LoadFonts()
        {
            #region 从数据库读取文字滚动的内容
            result = HttpHelper.Request(ApiConstants.PromotionContent_SelectPromotionContents);
            var response = HttpHelper.JsonToModel<ListOutputDto<ReadPromotionContentOutputDto>>(result.message);
            if (response.Success == false)
            {
                fonts = null;
            }

            fonts = response;
            #endregion
        }

        #region 定时器：文字滚动间隔
        private void tmrFont_Tick(object sender, EventArgs e)
        {
            if (fonts.Data.Items == null || fonts.Data.Items.Count == 0)
            {
                return;
            }
            fontn++;
            if (fontn >= fonts.Data.Items.Count)
            {
                fontn = 0;
            }
            lblScroll.Text = fonts.Data.Items[fontn].PromotionContentMessage;
        }
        #endregion

        #region 退出当前程序
        private void picClose_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();
            niClientIcon.Dispose();
        }
        #endregion

        #region 窗体最小化
        private void picFormSize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        /// <summary>
        /// 加载导航控件列表
        /// </summary>
        private void LoadNavBar()
        {
            var listData = new List<ReadNavBarOutputDto>();
            #region 菜单导航代码块
            result = HttpHelper.Request(ApiConstants.NavBar_NavBarList);
            var response = HttpHelper.JsonToModel<ListOutputDto<ReadNavBarOutputDto>>(result.message);
            if (response.Success == false)
            {
                AntdUI.Message.error(this, "服务器维护中，请过会再试");
                listData = null;
                return;
            }
            listData = response.Data.Items;
            AntdUI.MenuItem menuItem = null;
            muNavBar.Controls.Clear();
            if (!listData.IsNullOrEmpty())
            {
                foreach (var item in listData)
                {
                    menuItem = new AntdUI.MenuItem
                    {
                        Text = item.NavigationBarName
                    };
                    switch (item.NavigationBarName)
                    {
                        case "客房管理":
                            menuItem.Icon = Resources.picRoom_Image;
                            menuItem.Select = true;
                            break;
                        case "客户管理":
                            menuItem.Icon = Resources.picCustomer_Image;
                            break;
                        case "商品消费":
                            menuItem.Icon = Resources.picCommodity_Image;
                            break;
                    }
                    muNavBar.Items.Add(menuItem);
                }
            }
            else
            {
                AntdUI.Message.error(this, "服务器维护中，请过会再试");
                return;
            }
            #endregion
        }

        AntdUI.IContextMenuStripItem[] menulist =
        [
            new AntdUI.ContextMenuStripItem(UIControlConstant.ChangeAccount).SetIcon(UIControlIconConstant.ChangeAccount),
            new AntdUI.ContextMenuStripItem(UIControlConstant.PersonnalCenter).SetIcon(UIControlIconConstant.PersonnalCenter).SetSub(
                    new AntdUI.ContextMenuStripItem(UIControlConstant.PersonnalInformation).SetIcon(UIControlIconConstant.PersonnalInformation),
                    new AntdUI.ContextMenuStripItem(UIControlConstant.AccountSecurity).SetIcon(UIControlIconConstant.AccountSecurity),
                    new AntdUI.ContextMenuStripItem(UIControlConstant.AccountAvator).SetIcon(UIControlIconConstant.AccountAvator)
                        ),
            new AntdUI.ContextMenuStripItem(UIControlConstant.SystemLock).SetIcon(UIControlIconConstant.SystemLock),
            new AntdUI.ContextMenuStripItem(UIControlConstant.UpdateLog).SetIcon(UIControlIconConstant.Log),
            new AntdUI.ContextMenuStripItem(UIControlConstant.Help).SetIcon(UIControlIconConstant.Help).SetSub(
                    new AntdUI.ContextMenuStripItem(UIControlConstant.VisitOfficial).SetIcon(UIControlIconConstant.Internet)
                        ),
            new AntdUI.ContextMenuStripItem(UIControlConstant.About).SetIcon(UIControlIconConstant.About),
            new AntdUI.ContextMenuStripItem(UIControlConstant.ExitSystem).SetIcon(UIControlIconConstant.Exit)
        ];

        #region 窗体加载事件方法
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();


            btnMinimize.IconSvg = UIControlIconConstant.Minimize;
            btnClose.IconSvg = UIControlIconConstant.Close;
            btnSetting.IconSvg = UIControlIconConstant.Setting;

            lblSoftName.Text = ApplicationUtil.GetApplicationName() + " V" + ApplicationUtil.GetApplicationVersion();

            LoadNavBar();

            LoadFonts();

            DateTime tmCur = DateTime.Now;

            int currentHour = tmCur.Hour;

            if (tmCur.Hour < 8 || tmCur.Hour > 18)
            {
                lbHello.Text = "(*´▽｀)ノノ晚上好 " + LoginInfo.WorkerName;
            }
            else if (tmCur.Hour > 8 && tmCur.Hour < 12)
            {
                lbHello.Text = "(*´▽｀)ノノ上午好 " + LoginInfo.WorkerName;
            }
            else
            {
                lbHello.Text = "(*´▽｀)ノノ下午好 " + LoginInfo.WorkerName;
            }

            pnlCheckInfo.Visible = false;

            niClientIcon.Text = "TS酒店管理系统 - " + LoginInfo.WorkerName + " - 版本号：V" + ApplicationUtil.GetApplicationVersion();
            wk_WorkerName = LoginInfo.WorkerName;

            FrmRoomManager frmRoomManager = new FrmRoomManager
            {
                TopLevel = false
            };
            pnlMID.Controls.Add(frmRoomManager);
            frmRoomManager.Show();

            Dictionary<string, string> user = new Dictionary<string, string>()
            {
                { nameof(ReadEmployeeCheckInputDto.EmployeeId), LoginInfo.WorkerNo}
            };

            var result = HttpHelper.Request(ApiConstants.EmployeeCheck_SelectToDayCheckInfoByWorkerNo, user);
            var response = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeeCheckOutputDto>>(result.message);

            if (response.Success == false)
            {
                AntdUI.Notification.open(new AntdUI.Notification.Config(this, UIMessageConstant.Error, $"打卡接口:{ApiConstants.EmployeeCheck_SelectToDayCheckInfoByWorkerNo}异常：{response.Message}", AntdUI.TType.Error, AntdUI.TAlignFrom.TR, Font)
                {
                    Radius = 10,
                    FontStyleTitle = FontStyle.Bold,
                    ShowInWindow = true
                });
                return;
            }

            bool isMorningShift = currentHour < 12;

            bool shouldHaveChecked = isMorningShift ? response.Data.MorningChecked : response.Data.EveningChecked;
            string shiftName = isMorningShift ? "早班" : "晚班";

            linkLabel1.Text = shouldHaveChecked ? $"{shiftName}已打卡" : $"{shiftName}未打卡";
            linkLabel1.ForeColor = shouldHaveChecked ? Color.Green : Color.Red;
            linkLabel1.LinkColor = shouldHaveChecked ? Color.Green : Color.Red;

            lblCheckDay.Text = Convert.ToString(response.Data.CheckDay);

        }
        #endregion

        private void LeftKey(AntdUI.ContextMenuStripItem it)
        {
            switch (it.Text)
            {
                case UIControlConstant.ChangeAccount:
                    var dr = AntdUI.Modal.open(new AntdUI.Modal.Config(this, UIMessageConstant.Warning, LocalizationHelper.GetLocalizedString("Are you sure you want to switch accounts?", "你确定要切换账号吗？"), AntdUI.TType.Warn)
                    {
                        CancelText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Cancel, UIMessageConstant.Chs_Cancel),
                        OkText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Yes, UIMessageConstant.Chs_Yes)
                    });
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                    }
                    break;
                case UIControlConstant.SystemLock:
                    FrmScreenLock frmScreenLock = new();
                    frmScreenLock.ShowDialog();
                    break;
                case UIControlConstant.UpdateLog:
                    NotificationService.ShowInfo(LoginInfo.SoftwareReleaseLog);
                    break;
                case UIControlConstant.About:
                    FrmAbout frmAbout = new();
                    frmAbout.ShowDialog();
                    break;
                case UIControlConstant.ExitSystem:
                    System.Windows.Forms.Application.Exit();
                    break;
                case UIControlConstant.VisitOfficial:
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://www.oscode.top",
                        UseShellExecute = true
                    });
                    break;
                case UIControlConstant.PersonnalInformation:
                    FrmPersonnelInfo frmPersonnelInfo = new();
                    frmPersonnelInfo.ShowDialog();
                    break;
                case UIControlConstant.AccountSecurity:
                    FrmAccountSecurity frmAccountSecurity = new();
                    frmAccountSecurity.ShowDialog();
                    break;
                case UIControlConstant.AccountAvator:
                    FrmAvator frmAvator = new();
                    frmAvator.ShowDialog();
                    break;
            }
        }

        #region 当窗体关闭后的事件方法
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            niClientIcon.Dispose();
        }
        #endregion

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            niClientIcon.Dispose();
            this.returnForm1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.LinkColor == Color.Green)
            {
                NotificationService.ShowSuccess($"该轮班已打卡，无需重复打卡");
                return;
            }
            checkEmployeeCheckInfo();
        }

        private void checkEmployeeCheckInfo()
        {
            Dictionary<string, string> user = new Dictionary<string, string>()
            {
                { nameof(ReadEmployeeCheckInputDto.EmployeeId), LoginInfo.WorkerNo}
            };

            var result = HttpHelper.Request(ApiConstants.EmployeeCheck_SelectToDayCheckInfoByWorkerNo, user);
            var response = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeeCheckOutputDto>>(result.message);

            if (response.Success == false)
            {
                NotificationService.ShowError($"打卡接口:{ApiConstants.EmployeeCheck_SelectToDayCheckInfoByWorkerNo}异常：{response.Message}");
                return;
            }

            var tmCur = DateTime.Now;
            int currentHour = tmCur.Hour;
            bool isMorningShift = currentHour < 12;

            bool shouldHaveChecked = isMorningShift ? response.Data.MorningChecked : response.Data.EveningChecked;
            string shiftName = isMorningShift ? "早班" : "晚班";

            linkLabel1.Text = shouldHaveChecked ? $"{shiftName}已打卡" : $"{shiftName}未打卡";
            linkLabel1.ForeColor = shouldHaveChecked ? Color.Green : Color.Red;
            linkLabel1.LinkColor = shouldHaveChecked ? Color.Green : Color.Red;
            linkLabel1.LinkVisited = shouldHaveChecked ? true : false;

            if (!shouldHaveChecked)
            {
                var dr = AntdUI.Modal.open(new AntdUI.Modal.Config(this, UIMessageConstant.Information, $"你的{shiftName}还未打卡哦，请先打卡吧！", AntdUI.TType.Info)
                {
                    CancelText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Wait, UIMessageConstant.Chs_Wait),
                    OkText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Yes, UIMessageConstant.Chs_Yes)
                });
                if (dr == DialogResult.OK)
                {
                    CreateEmployeeCheckInputDto workerCheck = new()
                    {
                        CheckNumber = new UniqueCode().GetNewId("CK"),
                        DataInsDate = DateTime.Now,
                        IsDelete = 0,
                        CheckStatus = isMorningShift ? 0 : 1,
                        EmployeeId = LoginInfo.WorkerNo,
                        CheckMethod = "系统界面",
                        CheckTime = DateTime.Now,
                        DataInsUsr = LoginInfo.WorkerNo
                    };

                    result = HttpHelper.Request(ApiConstants.EmployeeCheck_AddCheckInfo, workerCheck.ModelToJson());
                    var checkResult = HttpHelper.JsonToModel<BaseResponse>(result.message);
                    if (checkResult.Success == false)
                    {
                        NotificationService.ShowError($"打卡接口{ApiConstants.EmployeeCheck_AddCheckInfo}异常：{checkResult.Message}");
                        return;
                    }

                    result = HttpHelper.Request(ApiConstants.EmployeeCheck_SelectWorkerCheckDaySumByEmployeeId, user);
                    response = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeeCheckOutputDto>>(result.message);
                    if (response.Success == false)
                    {
                        NotificationService.ShowError($"打卡天数接口{ApiConstants.EmployeeCheck_SelectWorkerCheckDaySumByEmployeeId}异常：{response.Message}");
                        return;
                    }

                    linkLabel1.Text = $"{shiftName}已打卡";
                    linkLabel1.ForeColor = Color.Green;
                    linkLabel1.LinkColor = Color.Green;
                    linkLabel1.LinkVisited = true;
                }
            }
            NotificationService.ShowSuccess($"{shiftName}打卡成功！你已共打卡" + response.Data.CheckDay + "天");
            lblCheckDay.Text = Convert.ToString(response.Data.CheckDay);
            pnlCheckInfo.Visible = true;
            lblCheckDay.Refresh();
            this.Refresh();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            pnlCheckInfo.Visible = false;
        }

        public void CloseMine()
        {
            this.Close();
        }

        private void niClientIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            niClientIcon.Dispose();
        }

        private void cpUITheme_ValueChanged(object sender, ColorEventArgs e)
        {
            AntdUI.Style.SetPrimary(e.Value);
            Refresh();
        }

        private void muNavBar_SelectChanged(object sender, MenuSelectEventArgs e)
        {
            switch (e.Value.Text)
            {
                case "客房管理":
                    pnlMID.Controls.Clear();
                    FrmRoomManager frmRoomManager = new()
                    {
                        TopLevel = false
                    };
                    pnlMID.Controls.Add(frmRoomManager);
                    frmRoomManager.Show();
                    break;
                case "客户管理":
                    pnlMID.Controls.Clear();
                    FrmCustomerManagement frmCustomerManagement = new()
                    {
                        TopLevel = false
                    };
                    pnlMID.Controls.Add(frmCustomerManagement);
                    frmCustomerManagement.Show();
                    break;
                case "商品消费":
                    pnlMID.Controls.Clear();
                    FrmSellThing frmSellThing = new()
                    {
                        TopLevel = false
                    };
                    pnlMID.Controls.Add(frmSellThing);
                    frmSellThing.Show();
                    break;
            }

        }

        private void btnSetting_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AntdUI.ContextMenuStrip.Config config = new AntdUI.ContextMenuStrip.Config(this, LeftKey, menulist);
                config.Font = new Font("Noto Sans SC", 9f, FontStyle.Bold);
                AntdUI.ContextMenuStrip.open(config);
            }
        }

        private void niClientIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                AntdUI.ContextMenuStrip.Config config = new AntdUI.ContextMenuStrip.Config(this, LeftKey, menulist);
                config.Font = new Font("Noto Sans SC", 9f, FontStyle.Bold);
                AntdUI.ContextMenuStrip.open(config);
            }
        }
    }
}
