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
using EOM.TSHotelManagement.Common.Contract;
using EOM.TSHotelManagement.Shared;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmRoomStateManager : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoomStateManager));
        public FrmRoomStateManager()
        {
            InitializeComponent();
            ucWindowHeader1.ApplySettingsWithoutMinimize("房间状态管理", string.Empty, (Image)resources.GetObject("FrmRoomStateManager.Icon")!);
        }

        Dictionary<string, string> dic = null;
        ResponseMsg result = null;

        #region 窗体加载事件
        private void FrmRoomStateManager_Load(object sender, EventArgs e)
        {

            txtRoomNo.Text = ucRoom.rm_RoomNo;
            result = HttpHelper.Request(ApiConstants.Base_SelectRoomStateAll);
            var datas = HttpHelper.JsonToModel<ListOutputDto<EnumDto>>(result.message);
            if (datas.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectRoomStateAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            cboRoomState.Items.AddRange(datas.Data.Items.Select(item => new AntdUI.SelectItem(item.Description, item.Id)).ToArray());
            cboRoomState.SelectedIndex = 0;
        }
        #endregion
        int selectedValue = 1;
        #region 确定按钮点击事件
        private void btnOk_Click(object sender, EventArgs e)
        {
            var helper = new EnumHelper();
            switch (selectedValue)
            {
                case (int)RoomState.Occupied:
                    NotificationService.ShowWarning("不能设置为已住状态！");
                    break;
                case (int)RoomState.Vacant:
                case (int)RoomState.Maintenance:
                case (int)RoomState.Dirty:
                case (int)RoomState.Reserved:
                    var updateRoom = new UpdateRoomInputDto { RoomNumber = txtRoomNo.Text.Trim(), RoomStateId = Convert.ToInt32(selectedValue) };
                    result = HttpHelper.Request(ApiConstants.Room_UpdateRoomStateByRoomNo, updateRoom.ModelToJson());
                    var response = HttpHelper.JsonToModel<BaseResponse>(result.message);
                    if (response.Success == false)
                    {
                        NotificationService.ShowError($"{ApiConstants.Room_UpdateRoomStateByRoomNo}+接口服务异常，请提交Issue或尝试更新版本！");
                        return;
                    }
                    NotificationService.ShowSuccess("房间" + txtRoomNo.Text + "成功修改为" + cboRoomState.Text);
                    FrmRoomManager.Reload("");
                    FrmRoomManager._RefreshRoomCount();
                    this.Close();
                    break;
                default:
                    NotificationService.ShowWarning("请选择房间状态");
                    break;
            }

        }
        #endregion

        private void cboRoomState_SelectedValueChanged(object sender, ObjectNEventArgs e)
        {
            selectedValue = Convert.ToInt32(e.Value);
        }
    }
}
