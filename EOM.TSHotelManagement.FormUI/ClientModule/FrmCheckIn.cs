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
using System.Transactions;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmCheckIn : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckIn));
        public FrmCheckIn()
        {
            InitializeComponent();

            ucWindowHeader1.ApplySettingsWithoutMinimize("入住房间", string.Empty, (Image)resources.GetObject("FrmCheckIn.Icon")!);
        }

        ResponseMsg result = new ResponseMsg();

        private void FrmCheckIn_Load(object sender, EventArgs e)
        {
            txtRoomNo.Text = ucRoom.rm_RoomNo;
            Dictionary<string, string> pairs = new Dictionary<string, string>
            {
                { nameof(ReadRoomInputDto.RoomNumber), txtRoomNo.Text.Trim()! }
            };
            result = HttpHelper.Request(ApiConstants.Room_SelectRoomByRoomNo, pairs);
            var response = HttpHelper.JsonToModel<SingleOutputDto<ReadRoomOutputDto>>(result.message!);
            if (response.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Room_SelectRoomByRoomNo}+接口服务异常，请提交issue");
                return;
            }
            ReadRoomOutputDto r = response.Data;
            result = HttpHelper.Request(ApiConstants.RoomType_SelectRoomTypeByRoomNo, pairs);
            var roomTypeResponse = HttpHelper.JsonToModel<SingleOutputDto<ReadRoomTypeOutputDto>>(result.message!);
            if (roomTypeResponse.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.RoomType_SelectRoomTypeByRoomNo}+接口服务异常，请提交issue");
                return;
            }
            ReadRoomTypeOutputDto t = roomTypeResponse.Data;
            txtRoomType.Text = t.RoomTypeName;
            txtRent.Text = r.RoomRent.ToString();
            txtRoomPosition.Text = r.RoomLocation;
            txtState.Text = r.RoomState;
            txtDeposit.Text = r.RoomDeposit.ToString();
        }

        private void txtCustoNo_Validated(object sender, EventArgs e)
        {
            try
            {
                ValidateAndUpdateCustomerInfo();
            }
            catch (Exception ex)
            {
                NotificationService.ShowError($"接口服务异常，请提交issue: {ex.Message}");
            }
        }

        private void ValidateAndUpdateCustomerInfo()
        {
            // 获取会员规则列表
            var dic = new Dictionary<string, string>
            {
                { nameof(ReadVipLevelRuleInputDto.IgnorePaging), "true" },
                { nameof(ReadVipLevelRuleInputDto.IsDelete), "0" }
            };
            var result = HttpHelper.Request(ApiConstants.VipLevelRule_SelectVipRuleList, dic);
            var response = HttpHelper.JsonToModel<ListOutputDto<ReadVipLevelRuleOutputDto>>(result.message!);
            if (response.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.VipLevelRule_SelectVipRuleList}+接口服务异常，请提交issue: {response.Message}");
            }

            var listVipRule = response.Data.Items
                .OrderBy(a => a.RuleValue)
                .Distinct()
                .ToList();

            // 查询用户消费记录
            var user = new Dictionary<string, string> { { nameof(ReadSpendInputDto.CustomerNumber), txtCustomerNo.Text.Trim() } };
            result = HttpHelper.Request(ApiConstants.Spend_SeletHistorySpendInfoAll, user);
            var customerSpends = HttpHelper.JsonToModel<ListOutputDto<ReadSpendOutputDto>>(result.message!);
            if (customerSpends.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Spend_SeletHistorySpendInfoAll}+接口服务异常，请提交issue: {response.Message}");
            }

            var listCustoSpend = customerSpends.Data.Items;
            if (!listCustoSpend.IsNullOrEmpty())
            {
                var spendAmount = listCustoSpend.Sum(a => a.ConsumptionAmount);
                var new_type = listVipRule
                    .Where(vipRule => spendAmount >= vipRule.RuleValue)
                            .OrderByDescending(vipRule => vipRule.RuleValue)
                            .ThenByDescending(vipRule => vipRule.VipLevelId)
                            .FirstOrDefault()?.VipLevelId ?? 0;

                // 如果会员等级有变，更新会员等级
                if (new_type != 0)
                {
                    var customer = new UpdateCustomerInputDto { CustomerNumber = txtCustomerNo.Text.Trim(), CustomerType = new_type };
                    result = HttpHelper.Request(ApiConstants.Customer_UpdCustomerTypeByCustoNo, customer.ModelToJson());
                    var updateResponse = HttpHelper.JsonToModel<BaseResponse>(result.message!);
                    if (updateResponse.Success == false)
                    {
                        throw new Exception($"{ApiConstants.Customer_UpdCustomerTypeByCustoNo}+接口服务异常");
                    }
                }
            }

            // 获取用户卡片信息
            if (!string.IsNullOrEmpty(txtCustomerNo.Text))
            {
                user = new Dictionary<string, string> { { nameof(ReadCustomerInputDto.CustomerNumber), txtCustomerNo.Text.Trim() } };
                result = HttpHelper.Request(ApiConstants.Customer_SelectCustoByInfo, user);
                var customerResponse = HttpHelper.JsonToModel<SingleOutputDto<ReadCustomerOutputDto>>(result.message!);
                if (customerResponse.Success == false)
                {
                    throw new Exception($"{ApiConstants.Customer_SelectCustoByInfo}+接口服务异常");
                }

                var custo = customerResponse.Data;
                txtCustomerName.Text = custo?.CustomerName ?? "";
                txtCustomerTel.Text = custo?.CustomerPhoneNumber ?? "";
                txtCustomerLevel.Text = custo?.CustomerTypeName ?? "";
            }
        }

        private void FrmCheckIn_ButtonOkClick(object sender, EventArgs e)
        {
            var user = new Dictionary<string, string> { { nameof(ReadCustomerInputDto.CustomerNumber), txtCustomerNo.Text.Trim() } };
            result = HttpHelper.Request(ApiConstants.Customer_SelectCustoByInfo, user);
            var customerResponse = HttpHelper.JsonToModel<SingleOutputDto<ReadCustomerOutputDto>>(result.message!);
            if (customerResponse.Success == false)
            {
                throw new Exception($"{ApiConstants.Customer_SelectCustoByInfo}+接口服务异常");
            }

            var custo = customerResponse.Data;
            if (!custo.IsNullOrEmpty())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    UpdateRoomInputDto r = new UpdateRoomInputDto()
                    {
                        LastCheckInTime = DateOnly.FromDateTime(DateTime.Now),
                        CustomerNumber = txtCustomerNo.Text,
                        RoomStateId = (int)RoomState.Occupied,
                        RoomNumber = txtRoomNo.Text,
                        DataChgUsr = LoginInfo.WorkerNo,
                        DataChgDate = DateTime.Now
                    };
                    result = HttpHelper.Request(ApiConstants.Room_UpdateRoomInfo, r.ModelToJson());
                    var response = HttpHelper.JsonToModel<BaseResponse>(result.message!);
                    if (response.Success == false)
                    {
                        NotificationService.ShowError($"{ApiConstants.Room_UpdateRoomInfo}+接口服务异常，请提交issue");
                        return;
                    }
                    NotificationService.ShowSuccess("登记入住成功！");
                    txtCustomerNo.Text = "";
                    FrmRoomManager.Reload("");
                    FrmRoomManager._RefreshRoomCount();
                    #region 获取添加操作日志所需的信息
                    RecordHelper.Record(LoginInfo.WorkerClub + "-" + LoginInfo.WorkerPosition + "-" + LoginInfo.WorkerName + "于" + Convert.ToDateTime(DateTime.Now) + "帮助" + r.CustomerNumber + "进行了入住操作！", LogLevel.Normal);
                    #endregion
                    scope.Complete();
                    this.Close();
                    return;
                }
            }
            else
            {
                NotificationService.ShowError("所选客户不存在！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
