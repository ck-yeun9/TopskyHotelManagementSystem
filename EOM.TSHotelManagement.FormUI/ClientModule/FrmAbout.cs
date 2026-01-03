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
using EOM.TSHotelManagement.Shared;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmAbout : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
        public FrmAbout()
        {
            InitializeComponent();

            whAboutHeader.ApplySettingsWithoutMinimize("关于", string.Empty, (Image)resources.GetObject("FrmAbout.Icon")!);
        }

        #region 记录鼠标和窗体坐标的方法
        private Point mouseOld;//鼠标旧坐标
        private Point formOld;//窗体旧坐标 
        #endregion

        #region 记录移动的窗体坐标
        private void FrmAboutUs_MouseDown(object sender, MouseEventArgs e)
        {
            formOld = this.Location;
            mouseOld = MousePosition;
        }
        #endregion

        #region 记录窗体移动的坐标
        private void FrmAboutUs_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            GetAboutInfo();
        }

        private void GetAboutInfo()
        {
            lblSoftName.Text = $"{ApplicationUtil.GetApplicationName()}";
            lblClientVersionDescriotion.Text = LocalizationHelper.GetLocalizedString("Client Version:", "客户端版本：");
            lblClientVersion.Text = $"{ApplicationUtil.GetApplicationVersion()} ({ApplicationUtil.GetSystemArchitectureViaEnv()})";
            lblServerVersionDescriotion.Text = LocalizationHelper.GetLocalizedString("Server Version:", "服务端版本：");
            lblServerVersion.Text = $"{ApplicationUtil.GetServerVersion()}";
            lblFrameworkVersionDescription.Text = LocalizationHelper.GetLocalizedString("Framework Version:", "框架版本：");
            lblFrameworkVersion.Text = $"{ApplicationUtil.GetApplicationFrameworkVersion()}";
            lblCopyright.Text = $"{LocalizationHelper.GetLocalizedString("Copyright", "版权所有")} © 2021-{DateTime.Now.Year} 易开元(EOM). ";
            lblNotice.Text = $"{LocalizationHelper.GetLocalizedString("All rights reserved", "保留所有权利")}.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
