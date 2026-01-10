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
using EOM.TSHotelManagement.FormUI.Properties;
using jvncorelib.EntityLib;
using EOM.TSHotelManagement.Shared;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmRoomManager : Form
    {


        public delegate void ReLoadRoomList(int typeId);

        public delegate void ReadRoomInfo();

        public delegate void RefreshRoomCount();

        //定义委托类型的变量
        public static ReadRoomInfo ReadInfo;
        public static ReLoadRoomList Reload;
        public static RefreshRoomCount _RefreshRoomCount;

        private LoadingProgress loadingProgress;
        public FrmRoomManager()
        {
            InitializeComponent();
            loadingProgress = new LoadingProgress();
            ReadInfo = LoadRoomInfo;
            Reload = LoadData;
            _RefreshRoomCount = LoadRoomTypesAndStates;
        }

        Dictionary<string, string> dic = null;
        ResponseMsg result = null;

        List<ReadRoomOutputDto> romsty = null;
        ucRoom room = null;


        public static int EmptyCount = 0;
        public static int OccupiedCount = 0;
        public static int DirtyCount = 0;
        public static int UnderRepairCount = 0;
        public static int ReservedCount = 0;

        private void FrmRoomManager_Load(object sender, EventArgs e)
        {
            LoadRoomInfo();
            LoadRoomTypesAndStates();
            LoadRoomTypes();
            LoadData();
        }
        private void LoadRoomTypesAndStates()
        {
            try
            {
                EmptyCount = 0;
                OccupiedCount = 0;
                DirtyCount = 0;
                UnderRepairCount = 0;
                ReservedCount = 0;

                var statusCounts = new Dictionary<string, int>
                {
                    [nameof(EmptyCount)] = 0,
                    [nameof(OccupiedCount)] = 0,
                    [nameof(DirtyCount)] = 0,
                    [nameof(UnderRepairCount)] = 0,
                    [nameof(ReservedCount)] = 0
                };

                var requestConfigs = new[]
                {
                    (ApiConstants.Room_SelectCanUseRoomAllByRoomState, nameof(RoomState.Vacant), nameof(EmptyCount)),
                    (ApiConstants.Room_SelectNotUseRoomAllByRoomState, nameof(RoomState.Occupied), nameof(OccupiedCount)),
                    (ApiConstants.Room_SelectNotClearRoomAllByRoomState, nameof(RoomState.Dirty), nameof(DirtyCount)),
                    (ApiConstants.Room_SelectFixingRoomAllByRoomState, nameof(RoomState.Maintenance), nameof(UnderRepairCount)),
                    (ApiConstants.Room_SelectReservedRoomAllByRoomState, nameof(RoomState.Reserved), nameof(ReservedCount))
                };

                foreach (var (url, propertyName, targetVar) in requestConfigs)
                {
                    try
                    {
                        var httpResponse = HttpHelper.Request(url);

                        var response = HttpHelper.JsonToModel<SingleOutputDto<ReadRoomOutputDto>>(httpResponse.message);

                        if (response.Success == false)
                        {
                            AntdUI.Notification.open(new AntdUI.Notification.Config(this, UIMessageConstant.Error, $"{url} 请求失败，状态码：{response.Code}", AntdUI.TType.Error, AntdUI.TAlignFrom.TR, Font)
                            {
                                Radius = 10,
                                FontStyleTitle = FontStyle.Bold,
                                ShowInWindow = true
                            });
                        }

                        var propertyInfo = typeof(ReadRoomOutputDto).GetProperty(propertyName);
                        if (propertyInfo == null)
                        {
                            AntdUI.Notification.open(new AntdUI.Notification.Config(this, UIMessageConstant.Error, $"ReadRoomOutputDto 中未找到 {propertyName} 属性", AntdUI.TType.Error, AntdUI.TAlignFrom.TR, Font)
                            {
                                Radius = 10,
                                FontStyleTitle = FontStyle.Bold,
                                ShowInWindow = true
                            });
                        }

                        if (propertyInfo.GetValue(response.Data) is int countValue)
                        {
                            statusCounts[targetVar] = countValue;
                        }
                        else
                        {
                            throw new InvalidCastException($"{propertyName} 值类型不匹配");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new AggregateException($"处理 {url} 时发生错误", ex);
                    }
                }

                EmptyCount = statusCounts[nameof(EmptyCount)];
                OccupiedCount = statusCounts[nameof(OccupiedCount)];
                DirtyCount = statusCounts[nameof(DirtyCount)];
                UnderRepairCount = statusCounts[nameof(UnderRepairCount)];
                ReservedCount = statusCounts[nameof(ReservedCount)];

                LoadRoomState();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.open(new AntdUI.Notification.Config(this, UIMessageConstant.Error, $"接口服务异常，请提交Issue或尝试更新版本！: {ex.Message}", AntdUI.TType.Error, AntdUI.TAlignFrom.TR, Font)
                {
                    Radius = 10,
                    FontStyleTitle = FontStyle.Bold,
                    ShowInWindow = true
                });
            }
        }

        private void LoadRoomState()
        {
            muRoomState.Items.Clear();

            var stateList = Enum.GetValues(typeof(RoomState))
            .Cast<RoomState>()
            .Select(e => new EnumDto
            {
                Id = (int)e,
                Name = e.ToString(),
                Description = new EnumHelper().GetEnumDescription(e)
            })
            .ToList();
            AntdUI.MenuItem? menuItem = null;
            if (!stateList.IsNullOrEmpty())
            {
                foreach (var item in stateList)
                {
                    menuItem = new AntdUI.MenuItem
                    {
                        Text = item.Description + GetRoomCountText(item.Name),
                        ID = item.Id.ToString(),
                    };

                    var roomState = new EnumHelper().GetEnumValue(item.Id);
                    if (roomState != null)
                    {
                        menuItem.Icon = GetRoomCountIcon(roomState);
                    }

                    muRoomState.Items.Add(menuItem);
                }
            }
        }

        private string GetRoomCountText(string code)
        {
            return code switch
            {
                var c when c == RoomState.Vacant.ToString() => $"({EmptyCount})",
                var c when c == RoomState.Occupied.ToString() => $"({OccupiedCount})",
                var c when c == RoomState.Maintenance.ToString() => $"({UnderRepairCount})",
                var c when c == RoomState.Dirty.ToString() => $"({DirtyCount})",
                var c when c == RoomState.Reserved.ToString() => $"({ReservedCount})",
                _ => string.Empty
            };
        }

        private Bitmap? GetRoomCountIcon(int code)
        {
            return code switch
            {
                var c when c == new EnumHelper().GetEnumValue(RoomState.Vacant) => Resources.可住状态,
                var c when c == new EnumHelper().GetEnumValue(RoomState.Occupied) => Resources.已住状态,
                var c when c == new EnumHelper().GetEnumValue(RoomState.Maintenance) => Resources.维修状态,
                var c when c == new EnumHelper().GetEnumValue(RoomState.Dirty) => Resources.脏房状态,
                var c when c == new EnumHelper().GetEnumValue(RoomState.Reserved) => Resources.预约状态,
                _ => null
            };
        }

        private void LoadRoomTypes()
        {
            try
            {
                var dic = new Dictionary<string, string>
                {
                    { nameof(ReadRoomTypeInputDto.IsDelete), "0" },
                    { nameof(ReadRoomTypeInputDto.IgnorePaging), "true"}
                };
                var result = HttpHelper.Request(ApiConstants.RoomType_SelectRoomTypesAll, dic);
                var response = HttpHelper.JsonToModel<ListOutputDto<ReadRoomTypeOutputDto>>(result.message);
                if (response.Success == false)
                {
                    NotificationService.ShowError($"{ApiConstants.RoomType_SelectRoomTypesAll}+接口服务异常");
                }

                var listRoomTypes = response.Data.Items;

                if (listRoomTypes == null)
                {
                    NotificationService.ShowError($"房间类型列表为空");
                    return;
                }

                flpRoomTypes.Controls.Clear();

                AddRoomTypeButton("全部房间", "btnAll", btnAll_Click, 0);
                foreach (var type in listRoomTypes)
                {
                    AddRoomTypeButton(type.RoomTypeName, Convert.ToString(type.RoomTypeName), btnRoomType_Click, type.RoomTypeId);
                }
            }
            catch (Exception ex)
            {
                NotificationService.ShowError($"接口服务异常，请提交Issue或尝试更新版本！: {ex.Message}");
            }
        }

        private void AddRoomTypeButton(string text, string name, EventHandler clickEvent, int id)
        {
            var ucRoomType = new ucRoomType();
            ucRoomType.btnRoomType.Text = text;
            ucRoomType.btnRoomType.Name = name;
            ucRoomType.btnRoomType.Tag = id;
            ucRoomType.btnRoomType.Click += clickEvent;
            flpRoomTypes.Controls.Add(ucRoomType);
        }

        private void btnRoomType_Click(object? sender, EventArgs e)
        {
            if (sender is AntdUI.Button button)
            {
                var typeId = button.Tag != null ? (int)button.Tag : 0;
                LoadData(typeId);
            }
        }

        private void btnAll_Click(object? sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadRoomInfo()
        {
            lblRoomNo.Text = ucRoom.co_RoomNo;
            lblCustoName.Text = ucRoom.co_CustoName;
            lblRoomPosition.Text = ucRoom.co_RoomPosition;
            lblCheckTime.Text = ucRoom.co_CheckTime == null || ucRoom.co_CheckTime == new DateTime(1900, 1, 1) ? ""
                : Convert.ToDateTime(ucRoom.co_CheckTime).ToString("yyyy-MM-dd");
            lblRoomState.Text = ucRoom.co_RoomState;
        }

        private void LoadData(int typeId = 0)
        {
            flpRoom.Controls.Clear();
            dic = new Dictionary<string, string>
            {
                { nameof(ReadRoomInputDto.IsDelete), "0" },
                { nameof(ReadRoomInputDto.IgnorePaging), "true" }
            };
            if (typeId > 0)
            {
                dic = new Dictionary<string, string>
                {
                    { nameof(ReadRoomInputDto.IsDelete), "0" },
                    { nameof(ReadRoomInputDto.IgnorePaging), "true" },
                    { nameof(ReadRoomInputDto.RoomTypeId), typeId.ToString() }
                };
            }
            result = HttpHelper.Request(ApiConstants.Room_SelectRoomAll, dic);
            var response = HttpHelper.JsonToModel<ListOutputDto<ReadRoomOutputDto>>(result.message);
            if (response.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Room_SelectRoomAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            romsty = response.Data.Items;
            
            for (int i = 0; i < romsty.Count; i++)
            {
                room = new ucRoom(this);
                room.btnRoom.Text = string.Format("{0}\n\n{1}\n\n{2}", romsty[i].RoomName, romsty[i].RoomNumber, romsty[i].CustomerName ?? "      ");
                room.RomRoomInfo = romsty[i];
                room.RomCustoInfo = new ReadCustomerOutputDto { CustomerNumber = romsty[i].CustomerNumber, CustomerName = romsty[i].CustomerName };
                flpRoom.Controls.Add(room);
            }
            lblRoomNo.Text = "";
            lblRoomPosition.Text = "";
            lblRoomState.Text = "";
            lblCustoName.Text = "";
            lblCheckTime.Text = "";
            LoadRoomInfo();
        }

        private void LoadRoomByState(int stateid)
        {
            flpRoom.Controls.Clear();
            dic = new Dictionary<string, string>
            {
                { nameof(ReadRoomInputDto.IsDelete), "0" },
                { nameof(ReadRoomInputDto.IgnorePaging), "true" },
                { nameof(ReadRoomInputDto.RoomStateId), stateid.ToString() }
            };
            result = HttpHelper.Request(ApiConstants.Room_SelectRoomByRoomState, dic);
            var response = HttpHelper.JsonToModel<ListOutputDto<ReadRoomOutputDto>>(result.message);
            if (response.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Room_SelectRoomByRoomState}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            romsty = response.Data.Items;
            for (int i = 0; i < romsty.Count; i++)
            {
                room = new ucRoom(this);
                room.btnRoom.Text = string.Format("{0}\n\n{1}\n\n{2}", romsty[i].RoomName, romsty[i].RoomNumber, romsty[i].CustomerName);
                room.RomRoomInfo = romsty[i];
                room.RomCustoInfo = new ReadCustomerOutputDto { CustomerNumber = romsty[i].CustomerNumber, CustomerName = romsty[i].CustomerName };
                flpRoom.Controls.Add(room);
            }
            lblRoomNo.Text = "";
            lblRoomPosition.Text = "";
            lblRoomState.Text = "";
            lblCustoName.Text = "";
            lblCheckTime.Text = "";
        }

        private void muRoomState_SelectChanged(object sender, MenuSelectEventArgs e)
        {
            flpRoom.Controls.Clear();

            var roomState = new EnumHelper().GetEnumValue(Convert.ToInt32(e.Value.ID));

            if (roomState != null)
            {
                switch (roomState)
                {
                    case var code when code == (int)RoomState.Vacant:
                        LoadRoomByState((int)RoomState.Vacant);
                        break;
                    case var code when code == (int)RoomState.Occupied:
                        LoadRoomByState((int)RoomState.Occupied);
                        break;
                    case var code when code == (int)RoomState.Maintenance:
                        LoadRoomByState((int)RoomState.Maintenance);
                        break;
                    case var code when code == (int)RoomState.Dirty:
                        LoadRoomByState((int)RoomState.Dirty);
                        break;
                    case var code when code == (int)RoomState.Reserved:
                        LoadRoomByState((int)RoomState.Reserved);
                        break;
                }
            }
        }
    }
}