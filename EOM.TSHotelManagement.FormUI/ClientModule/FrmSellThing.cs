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
using EOM.TSHotelManagement.Common.Util;
using EOM.TSHotelManagement.Shared;
using jvncorelib.EntityLib;
using System.Transactions;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmSellThing : Window
    {
        static string roomNo;

        Dictionary<string, string> dic = null;
        ResponseMsg result = null;
        ReadRoomOutputDto r = null;

        private static ReadSpendOutputDto spend = null;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSellThing));

        private LoadingProgress loadingProgress;
        public FrmSellThing()
        {
            InitializeComponent();
            loadingProgress = new LoadingProgress();

            ucWindowHeader1.ApplySettingsWithoutMinimize("商品消费", string.Empty, (Image)resources.GetObject("FrmSellThing.Icon")!);
        }

        #region 窗体加载事件
        private void FrmSellThing_Load(object sender, EventArgs e)
        {
            LoadSellThingInfo();

        }
        #endregion

        #region 查询事件
        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadThingByName(txtFind.Text);
        }
        #endregion

        #region 查询文本框更改事件

        private void LoadThingByName(string sellthing)
        {
            dic = new Dictionary<string, string>()
            {
                { nameof(ReadSellThingInputDto.ProductName) , sellthing.Trim() },
                { nameof(ReadSellThingInputDto.IsDelete) , "0" }
            };
            result = HttpHelper.Request(ApiConstants.Sellthing_SelectSellThingAll, dic);
            var response = HttpHelper.JsonToModel<ListOutputDto<ReadSellThingOutputDto>>(result.message);
            if (response.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Sellthing_SelectSellThingAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }

            var listTableData = new List<AntdUI.AntItem[]>();

            List<ReadSellThingOutputDto> lstData = response.Data.Items;

            TableComHelper tableComHelper = new TableComHelper();
            listTableData = tableComHelper.ConvertToAntdItems(lstData);

            dgvSellthing.Spin("正在加载中...", config =>
            {
                this.dgvSellthing.Columns = tableComHelper.ConvertToAntdColumns(tableComHelper.GenerateDataColumns<ReadSellThingOutputDto>());
                this.dgvSellthing.DataSource = listTableData;
            }, () =>
            {
                System.Diagnostics.Debug.WriteLine("加载结束");
            });
        }
        #endregion

        #region 根据客户编号加载消费信息的方法
        private void LoadSpendInfoByRoomNo(ReadRoomOutputDto room)
        {
            dgvRoomSell.Spin("正在加载中...", config =>
            {
                dic = new Dictionary<string, string>()
                {
                    { nameof(ReadSpendInputDto.CustomerNumber), room.CustomerNumber },
                    { nameof(ReadSpendInputDto.RoomNumber), room.RoomNumber },
                    { nameof(ReadSpendInputDto.SettlementStatus) , ConsumptionConstant.UnSettle.Code },
                };
                result = HttpHelper.Request(ApiConstants.Spend_SelectSpendByRoomNo, dic);
                var response = HttpHelper.JsonToModel<ListOutputDto<ReadSpendOutputDto>>(result.message);
                if (response.Success == false)
                {
                    NotificationService.ShowError($"{ApiConstants.Spend_SelectSpendByRoomNo}+接口服务异常，请提交Issue或尝试更新版本！");
                    return;
                }
                List<ReadSpendOutputDto> lstData = response.Data.Items;
                TableComHelper tableComHelper = new TableComHelper();
                dgvRoomSell.Columns = tableComHelper.ConvertToAntdColumns(tableComHelper.GenerateDataColumns<ReadSpendOutputDto>());
                dgvRoomSell.DataSource = tableComHelper.ConvertToAntdItems(lstData);
            }, () =>
            {
                System.Diagnostics.Debug.WriteLine("加载结束");
            });
        }
        #endregion

        #region 商品加载事件方法
        public void LoadSellThingInfo()
        {
            var dataCount = 0;
            btnPg.PageSizeOptions = new int[] { 15, 30, 50, 100 };
            dgvSellthing.Spin("正在加载中...", config =>
            {
                TableComHelper tableComHelper = new TableComHelper();
                dgvSellthing.Columns = tableComHelper.ConvertToAntdColumns(tableComHelper.GenerateDataColumns<ReadSellThingOutputDto>());
                dgvSellthing.DataSource = GetPageData(btnPg.Current, btnPg.PageSize, ref dataCount);
                btnPg.PageSize = 15;
                btnPg.Current = 1;
                btnPg.Total = dataCount;
            });

        }

        object GetPageData(int current, int pageSize, ref int totalCount)
        {
            dic = new Dictionary<string, string>()
            {
                { nameof(ReadSellThingInputDto.Page), current.ToString() },
                { nameof(ReadSellThingInputDto.PageSize), pageSize.ToString() },
                { nameof(ReadSellThingInputDto.IsDelete), "0"}
            };
            result = HttpHelper.Request(ApiConstants.Sellthing_SelectSellThingAll, dic);
            var response = HttpHelper.JsonToModel<ListOutputDto<ReadSellThingOutputDto>>(result.message);
            if (response.Success == false)
            {
                AntdUI.Message.error(this, $"{ApiConstants.Sellthing_SelectSellThingAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return null!;
            }
            List<ReadSellThingOutputDto> lstData = response.Data.Items;
            totalCount = lstData.Count;
            var listTableData = new List<AntdUI.AntItem[]>();

            TableComHelper tableComHelper = new TableComHelper();
            listTableData = tableComHelper.ConvertToAntdItems(lstData);

            return listTableData;
        }

        #endregion

        #region 判断输入的完整性的方法
        public bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtRoomNo.Text))
            {
                NotificationService.ShowWarning("消费房间不能为空");
                txtRoomNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSellNo.Text))
            {
                NotificationService.ShowWarning("商品编号不能为空");
                txtSellNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSellName.Text))
            {
                NotificationService.ShowWarning("商品名称不能为空");
                txtSellName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                NotificationService.ShowWarning("商品单价不能为空");
                txtPrice.Focus();
                return false;
            }
            if (nudNum.Value <= 0)
            {
                NotificationService.ShowWarning("数量不能小于或等于0");
                txtPrice.Focus();
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 添加消费事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lblState.Visible == false)
            {
                NotificationService.ShowWarning("请先输入消费的房间！");
                return;
            }
            if (nudNum.Value <= 0)
            {
                NotificationService.ShowWarning("请输入消费数量！");
                return;
            }
            if (lblState.Text == "该房间可消费")
            {
                if (!CheckInput()) return;

                try
                {
                    var customerSpend = new AddCustomerSpendInputDto
                    {
                        RoomNumber = txtRoomNo.Text.Trim(),
                        ProductNumber = txtSellNo.Text.Trim(),
                        ProductName = txtSellName.Text.Trim(),
                        Quantity = (int)nudNum.Value,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        WorkerNo = LoginInfo.WorkerNo,
                        SoftwareVersion = LoginInfo.SoftwareVersion
                    };
                    var result = HttpHelper.Request(ApiConstants.Spend_AddCustomerSpend, customerSpend.ModelToJson());
                    var response = HttpHelper.JsonToModel<BaseResponse>(result.message!);
                    if (response.Success == false)
                    {
                        NotificationService.ShowError(response.Message ?? "添加消费记录失败");
                        return;
                    }
                    NotificationService.ShowSuccess("添加成功");

                    LoadSpendInfoByRoomNo(r);
                    LoadSellThingInfo();
                }
                catch (Exception ex)
                {
                    NotificationService.ShowError($"接口调用异常: {ex.Message}");
                    return;
                }
            }
        }

        /// <summary>
        /// 撤回消费事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lblState.Visible == false)
            {
                NotificationService.ShowWarning("请先输入消费的房间！");
                return;
            }
            if (!spend.IsNullOrEmpty())
            {
                if (spend.ConsumptionType == SpendType.Room.Code || spend.ConsumptionType == SpendType.Other.Code)
                {
                    NotificationService.ShowError($"此条消费记录非{SpendType.Product.Description}记录，无法删除！");
                    return;
                }
                var dr = AntdUI.Modal.open(new AntdUI.Modal.Config(this, UIMessageConstant.Information, $"你确定要撤回该消费记录吗？", AntdUI.TType.Info)
                {
                    CancelText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Wait, UIMessageConstant.Chs_Wait),
                    OkText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Yes, UIMessageConstant.Chs_Yes)
                });
                if (dr == DialogResult.OK)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        dic = new Dictionary<string, string>()
                        {
                            { nameof(ReadSellThingInputDto.ProductNumber) , spend.ProductNumber },
                            { nameof(ReadSellThingInputDto.ProductName) , spend.ProductName },
                            { nameof(ReadSellThingInputDto.ProductPrice) , Decimal.Parse(spend.ProductPrice.ToString()).ToString("#,##0.00").ToString() }
                        };
                        result = HttpHelper.Request(ApiConstants.Sellthing_SelectSellThingByNameAndPrice, dic);
                        var response = HttpHelper.JsonToModel<SingleOutputDto<ReadSellThingOutputDto>>(result.message);
                        if (response.Success == false)
                        {
                            NotificationService.ShowError($"{ApiConstants.Sellthing_SelectSellThingByNameAndPrice}+接口服务异常，请提交Issue或尝试更新版本！");
                            return;
                        }
                        ReadSellThingOutputDto s = response.Data;
                        int num = spend.ConsumptionQuantity;
                        int inboundStock = (s.Stock + num);
                        var model = new UpdateSpendInputDto { SpendNumber = spend.SpendNumber };
                        result = HttpHelper.Request(ApiConstants.Spend_UndoCustomerSpend, model.ModelToJson());
                        var undoSpendResponse = HttpHelper.JsonToModel<BaseResponse>(result.message);
                        if (undoSpendResponse.Success == false)
                        {
                            NotificationService.ShowError($"{ApiConstants.Spend_UndoCustomerSpend}+接口服务异常，请提交Issue或尝试更新版本！");
                            return;
                        }
                        var sellThing = new UpdateSellThingInputDto { ProductName = s.ProductName, ProductPrice = s.ProductPrice, Stock = inboundStock, ProductNumber = s.ProductNumber, Specification = s.Specification };
                        result = HttpHelper.Request(ApiConstants.Sellthing_UpdateSellthingInfo, sellThing.ModelToJson());
                        var updateResponse = HttpHelper.JsonToModel<BaseResponse>(result.message);
                        if (updateResponse.Success == false)
                        {
                            RecordHelper.Record($"接口异常。Message：\n{updateResponse.Message}", LogLevel.Critical);
                            NotificationService.ShowError($"{ApiConstants.Sellthing_UpdateSellthingInfo}+接口服务异常，请提交Issue或尝试更新版本！");
                            return;
                        }
                        NotificationService.ShowSuccess("撤销成功！");
                        #region 获取添加操作日志所需的信息
                        RecordHelper.Record(LoginInfo.WorkerNo + "-" + LoginInfo.WorkerName + "在" + Convert.ToDateTime(DateTime.Now) + "位于" + LoginInfo.SoftwareVersion + "执行：" + "帮助" + spend.CustomerNumber + "撤销了消费商品:" + txtSellName.Text + "操作！", LogLevel.Warning);
                        #endregion
                        LoadSpendInfoByRoomNo(r);
                        LoadSellThingInfo();
                        nudNum.Value = 0;
                        scope.Complete();
                        dgvRoomSell.SelectedIndex = 0;
                        spend = null;
                        txtSellNo.Text = string.Empty;
                        txtSellName.Text = string.Empty;
                        txtPrice.Text = string.Empty;
                        nudNum.Value = 0;
                    }
                }
                else
                {
                    NotificationService.ShowWarning("操作取消！");
                }
            }
            else
            {
                NotificationService.ShowWarning("请选择要删除的消费记录！");
            }
        }

        private void txtRoomNo_Validated(object sender, EventArgs e)
        {

        }

        private void txtRoomNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string room = txtRoomNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(room) == true)
            {
                NotificationService.ShowWarning("请输入消费房间号！");
                return;
            }
            dic = new Dictionary<string, string>()
            {
                { nameof(ReadSpendInputDto.RoomNumber) , room },
            };
            result = HttpHelper.Request(ApiConstants.Room_SelectRoomByRoomNo, dic);
            var checkResponse = HttpHelper.JsonToModel<SingleOutputDto<ReadRoomOutputDto>>(result.message);
            if (checkResponse.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Room_SelectRoomByRoomNo}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            r = checkResponse.Data;
            if (txtRoomNo.Text == "")
            {
                lblState.Text = "";
            }
            else if (r == null)
            {
                lblState.Visible = true;
                lblState.Text = "该房间不存在";
                lblState.ForeColor = Color.Red;
            }
            else if (!r.IsNullOrEmpty())
            {
                if (r.RoomStateId == new EnumHelper().GetEnumValue(RoomState.Occupied))
                {
                    lblState.Visible = true;
                    lblState.Text = "该房间可消费";
                    lblState.ForeColor = Color.Black;
                    LoadSpendInfoByRoomNo(r);
                }
                else
                {
                    lblState.Visible = true;
                    lblState.Text = "该房间不可消费";
                    lblState.ForeColor = Color.Red;
                }
            }
        }

        TableComHelper helper = new TableComHelper();
        private void dgvSellthing_CellClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (lblState.Visible == false)
            {
                NotificationService.ShowWarning("请先输入消费的房间！");
                return;
            }
            if (e.Record is IList<AntdUI.AntItem> data)
            {
                txtSellNo.Text = helper.GetValue(data, nameof(ReadSellThingOutputDto.ProductNumber));
                txtSellName.Text = helper.GetValue(data, nameof(ReadSellThingOutputDto.ProductName));
                txtPrice.Text = helper.GetValue(data, nameof(ReadSellThingOutputDto.ProductPrice));
            }
        }

        private void dgvRoomSell_CellClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (e.Record is IList<AntdUI.AntItem> data)
            {
                spend = new ReadSpendOutputDto
                {
                    ProductNumber = helper.GetValue(data, nameof(ReadSpendOutputDto.ProductNumber)),
                    SettlementStatus = helper.GetValue(data, nameof(ReadSpendOutputDto.SettlementStatus)),
                    SpendNumber = helper.GetValue(data, nameof(ReadSpendOutputDto.SpendNumber)),
                    RoomNumber = helper.GetValue(data, nameof(ReadSpendOutputDto.RoomNumber)),
                    CustomerNumber = helper.GetValue(data, nameof(ReadSpendOutputDto.CustomerNumber)),
                    ProductName = helper.GetValue(data, nameof(ReadSpendOutputDto.ProductName)),
                    ConsumptionQuantity = Convert.ToInt32(helper.GetValue(data, nameof(ReadSpendOutputDto.ConsumptionQuantity))),
                    ProductPrice = Convert.ToDecimal(helper.GetValue(data, nameof(ReadSpendOutputDto.ProductPrice))),
                    ConsumptionAmount = Convert.ToDecimal(helper.GetValue(data, nameof(ReadSpendOutputDto.ConsumptionAmount))),
                    ConsumptionTime = Convert.ToDateTime(helper.GetValue(data, nameof(ReadSpendOutputDto.ConsumptionTime)))
                };
            }
        }
    }
}
