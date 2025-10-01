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
    public partial class FrmChangeRoom : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangeRoom));
        public FrmChangeRoom()
        {
            InitializeComponent();

            ucWindowHeader1.ApplySettingsWithoutMinimize("转换房间", string.Empty, (Image)resources.GetObject("FrmChangeRoom.Icon")!);
        }

        ResponseMsg result = null;
        Dictionary<string, string> dic = null;

        private void FrmChangeRoom_Load(object sender, EventArgs e)
        {
            result = HttpHelper.Request(ApiConstants.Room_SelectCanUseRoomAll);
            var datas = HttpHelper.JsonToModel<ListOutputDto<ReadRoomOutputDto>>(result.message);
            if (!datas.Success)
            {
                NotificationService.ShowError($"{ApiConstants.Room_SelectCanUseRoomAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            this.cboRoomList.Items.AddRange(datas.Data.Items.Select(item => new AntdUI.SelectItem(item.RoomNumber, item.RoomNumber)).ToArray());
        }

        private void btnChangeRoom_Click(object sender, EventArgs e)
        {
            string rno = ucRoom.co_RoomNo.ToString();
            string nrno = cboRoomList.Text;

            try
            {
                #region 发起转房和转移消费以及添加消费的请求

                var transferRoom = new TransferRoomDto
                {
                    OriginalRoomNumber = rno,
                    TargetRoomNumber = nrno,
                    CustomerNumber = ucRoom.CustoNo,
                    DataChgUsr = LoginInfo.WorkerNo,
                    DataChgDate = Convert.ToDateTime(DateTime.Now)
                };
                result = HttpHelper.Request(ApiConstants.Room_TransferRoom, transferRoom.ModelToJson());
                var response = HttpHelper.JsonToModel<BaseResponse>(result.message!);
                if (!response.Success)
                {
                    NotificationService.ShowError($"{ApiConstants.Room_TransferRoom}+接口服务异常，请提交Issue或尝试更新版本！");
                    return;
                }

                #endregion

                FrmRoomManager.Reload("");
                FrmRoomManager._RefreshRoomCount();
                #region 获取添加操作日志所需的信息
                RecordHelper.Record(LoginInfo.WorkerNo + "-" + LoginInfo.WorkerName + "在" + transferRoom.DataChgDate + "位于" + LoginInfo.SoftwareVersion + "执行：" + transferRoom.CustomerNumber + "于" + transferRoom.DataChgDate + "进行了换房！", LogLevel.Warning);
                #endregion
                NotificationService.ShowSuccess("转房成功");
                this.Close();
            }
            catch (Exception)
            {
                NotificationService.ShowError("转房失败");
            }
        }

        private void cboRoomList_TextChanged(object sender, EventArgs e)
        {
            string str = cboRoomList.SelectedValue.IsNullOrEmpty() ? string.Empty : cboRoomList.SelectedValue.ToString();
            if (string.IsNullOrEmpty(str))
            {
                lblRoomType.Text = string.Empty;
                return;
            }

            dic = new Dictionary<string, string>()
            {
                { nameof(ReadRoomTypeInputDto.RoomNumber) , str }
            };
            result = HttpHelper.Request(ApiConstants.RoomType_SelectRoomTypeByRoomNo, dic);
            var data = HttpHelper.JsonToModel<SingleOutputDto<ReadRoomTypeOutputDto>>(result.message);
            if (data.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.RoomType_SelectRoomTypeByRoomNo}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            var roomType = data.Data;
            lblRoomType.Text = roomType.RoomTypeName;
        }
    }
}
