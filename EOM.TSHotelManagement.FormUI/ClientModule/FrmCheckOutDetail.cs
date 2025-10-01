using AntdUI;
using EOM.TSHotelManagement.Common;
using EOM.TSHotelManagement.Common.Contract;
using EOM.TSHotelManagement.Shared;
using jvncorelib.EntityLib;
using System.Data;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmCheckOutDetail : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckOutDetail));
        public FrmCheckOutDetail()
        {
            InitializeComponent();

            ucWindowHeader1.ApplySettingsWithoutMinimize("房间结算", string.Empty, (Image)resources.GetObject("FrmCheckOutDetail.Icon")!);
        }

        ResponseMsg result = null;
        Dictionary<string, string> dic = null;
        public static CreateEnergyManagementInputDto w;
        public static decimal TotalConsumptionAmount = 0M;

        private void FrmCheckOutDetail_Load(object sender, EventArgs e)
        {
            decimal sum = 0;
            CustoNo.Text = ucRoom.rm_CustoNo;
            txtRoomNo.Text = ucRoom.rm_RoomNo;
            CustoName.Text = ucRoom.co_CustoName;

            dic = new Dictionary<string, string>()
            {
                { nameof(ReadRoomInputDto.RoomNumber) , txtRoomNo.Text.ToString()}
            };

            result = HttpHelper.Request(ApiConstants.Room_SelectRoomByRoomNo, dic);
            var roomInfo = HttpHelper.JsonToModel<SingleOutputDto<ReadRoomOutputDto>>(result.message);
            if (roomInfo.Success == false)
            {
                NotificationService.ShowError("SelectRoomByRoomNo+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }

            ReadRoomOutputDto room = roomInfo.Data;

            if (room.LastCheckInTime == null)
            {
                dtpCheckTime.Text = Convert.ToDateTime(DateTime.Now).ToString("yyyy/MM/dd");
            }
            else
            {
                dtpCheckTime.Text = Convert.ToDateTime(room.LastCheckInTime).ToString("yyyy/MM/dd");
            }
            dic = new Dictionary<string, string>()
            {
                { nameof(ReadRoomInputDto.RoomNumber) , txtRoomNo.Text}
            };
            result = HttpHelper.Request(ApiConstants.Room_DayByRoomNo, dic);
            var stayDays = HttpHelper.JsonToModel<SingleOutputDto<ReadRoomOutputDto>>(result.message);
            if (stayDays.Success == false)
            {
                NotificationService.ShowError("DayByRoomNo+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }

            sum = Convert.ToDecimal(Convert.ToString(Convert.ToInt32(stayDays.Data.StayDays) * room.RoomRent));

            lblDay.Text = Convert.ToString(Convert.ToInt32(stayDays.Data.StayDays));

            w = new CreateEnergyManagementInputDto()
            {
                PowerUsage = Convert.ToDecimal(Convert.ToInt32(stayDays.Data.StayDays) * 3 * 1),
                WaterUsage = Convert.ToDecimal(Convert.ToDouble(stayDays.Data.StayDays) * 80 * 0.002)
            };

            #region 加载消费信息

            var dataCount = 0;
            btnPg.PageSizeOptions = new int[] { 15, 30, 50, 100 };
            dgvSpendList.Spin("正在加载中...", config =>
            {
                TableComHelper tableComHelper = new TableComHelper();
                dgvSpendList.Columns = tableComHelper.ConvertToAntdColumns(tableComHelper.GenerateDataColumns<ReadSpendOutputDto>());
                dgvSpendList.DataSource = GetPageData(btnPg.Current, btnPg.PageSize, ref dataCount);
                btnPg.PageSize = 15;
                btnPg.Current = 1;
                btnPg.Total = dataCount;
            }, () =>
            {
                System.Diagnostics.Debug.WriteLine("加载结束");
            });

            #endregion

            dic = new Dictionary<string, string>()
            {
                { nameof(ReadCustomerInputDto.CustomerNumber), CustoNo.Text.Trim() }
            };
            var request = HttpHelper.Request(ApiConstants.Customer_SelectCustoByInfo, dic);
            var customerResponse = HttpHelper.JsonToModel<SingleOutputDto<ReadCustomerOutputDto>>(request.message);
            if (customerResponse.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Spend_SumConsumptionAmount}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            var customer = customerResponse.Data;

            dic = new Dictionary<string, string>()
            {
                { nameof(ReadCustoTypeInputDto.CustomerType), customer.CustomerType.ToString() }
            };
            request = HttpHelper.Request(ApiConstants.CustoType_SelectCustoTypeByTypeId, dic);
            var customerTypeResponse = HttpHelper.JsonToModel<SingleOutputDto<ReadCustoTypeOutputDto>>(request.message);
            if (customerTypeResponse.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Spend_SumConsumptionAmount}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }

            var customerType = customerTypeResponse.Data;

            //计算消费总额
            //dic = new Dictionary<string, string>()
            //{
            //    { nameof(ReadSpendInputDto.RoomNumber), txtRoomNo.Text.Trim() },
            //    { nameof(ReadSpendInputDto.CustomerNumber), CustoNo.Text.Trim() },
            //};
            //result = HttpHelper.Request(ApiConstants.Spend_SumConsumptionAmount, dic);
            //var spendResponse = HttpHelper.JsonToModel<SingleOutputDto<ReadSpendOutputDto>>(result.message);
            //if (spendResponse.Success == false)
            //{
            //    NotificationService.ShowError($"{ApiConstants.Spend_SumConsumptionAmount}+接口服务异常，请提交Issue或尝试更新版本！");
            //    return;
            //}
            decimal total = TotalConsumptionAmount;
            decimal m = total + sum;
            decimal discount = (customerType != null && customerType.Discount > 0 && customerType.Discount < 100)
                ? customerType.Discount / 100M
                : 1M;
            lblGetReceipts.Text = m.ToString("#,##0.00");
            lblVIPPrice.Text = (m * discount).ToString("#,##0.00");
            lblVIP.Text = (discount < 1M) ? DiscountHelper.ToZheString(customerType.Discount) : "无折扣(100%)";
        }

        object GetPageData(int current, int pageSize, ref int totalCount)
        {
            string RoomNo = txtRoomNo.Text;
            dic = new Dictionary<string, string>()
            {
                { nameof(ReadSpendInputDto.CustomerNumber) , CustoNo.Text.Trim() },
                { nameof(ReadSpendInputDto.SettlementStatus) , ConsumptionConstant.UnSettle.Code },
                { nameof(ReadSpendInputDto.RoomNumber) , RoomNo },
                { nameof(ReadAdministratorInputDto.IgnorePaging) , "true" }
            };
            result = HttpHelper.Request(ApiConstants.Spend_SelectSpendByRoomNo, dic);
            var spendInfo = HttpHelper.JsonToModel<ListOutputDto<ReadSpendOutputDto>>(result.message);
            if (spendInfo.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Spend_SelectSpendByRoomNo}+接口服务异常，请提交Issue或尝试更新版本！");
            }

            List<ReadSpendOutputDto> spends = spendInfo.Data.Items;
            totalCount = spendInfo.Data.TotalCount;
            var listTableData = new List<AntdUI.AntItem[]>();

            spends = spends.OrderBy(a => a.SpendNumber).ToList();

            TableComHelper tableComHelper = new TableComHelper();
            listTableData = tableComHelper.ConvertToAntdItems(spends);

            TotalConsumptionAmount = spends.Count() == 0 ? 0 : spends.DefaultIfEmpty().Sum(a => a!.ConsumptionAmount);

            return listTableData;
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceipts.Text) && Convert.ToDecimal(txtReceipts.Text) > Convert.ToDecimal(lblVIPPrice.Text))//判断实收金额是否为空以及是否小于应收金额
            {
                var model = new CheckoutRoomDto
                {
                    RoomNumber = txtRoomNo.Text.Trim(),
                    CustomerNumber = CustoNo.Text.Trim(),
                    DataChgDate = DateTime.Now,
                    DataChgUsr = LoginInfo.WorkerNo,
                    ElectricityUsage = w.PowerUsage,
                    WaterUsage = w.WaterUsage
                };
                result = HttpHelper.Request(ApiConstants.Room_CheckoutRoom, model.ModelToJson());
                var response = HttpHelper.JsonToModel<BaseResponse>(result.message);
                if (response.Success == false)
                {
                    NotificationService.ShowError($"{ApiConstants.Room_CheckoutRoom}+接口服务异常，请提交Issue或尝试更新版本！");
                    return;
                }
                NotificationService.ShowSuccess("结算成功！");
                FrmRoomManager.Reload("");
                FrmRoomManager._RefreshRoomCount();

                #region 获取添加操作日志所需的信息
                RecordHelper.Record(LoginInfo.WorkerClub + "-" + LoginInfo.WorkerPosition + "-" + LoginInfo.WorkerName + "于" + Convert.ToDateTime(DateTime.Now) + "帮助" + CustoNo.Text + "进行了退房结算操作！", LogLevel.Critical);
                #endregion
                this.Close();
            }
            else
            {
                NotificationService.ShowWarning("实收金额不能为空或实收金额不能小于应付金额！");
                return;
            }
        }

        private void btnPg_ValueChanged(object sender, PagePageEventArgs e)
        {
            var dataCount = 0;
            dgvSpendList.Spin("正在加载中...", config =>
            {
                dgvSpendList.DataSource = GetPageData(e.Current, e.PageSize, ref dataCount);
                btnPg.Total = dataCount;
            }, () =>
            {
                System.Diagnostics.Debug.WriteLine("加载结束");
            });
        }

        private string btnPg_ShowTotalChanged(object sender, PagePageEventArgs e)
        {
            return $"{e.PageSize} / {e.Total}条 共{e.PageTotal}页";
        }

        private void txtReceipts_TextChanged(object sender, EventArgs e)
        {
            if (txtReceipts.Text != "")
            {
                try
                {
                    double receipt = Convert.ToDouble(Convert.ToDecimal(txtReceipts.Text));
                    double vipPrice = Convert.ToDouble(Convert.ToDecimal(lblVIPPrice.Text));
                    lblChange.Text = Decimal.Parse((receipt - vipPrice).ToString()).ToString("#,##0.00");
                }
                catch
                {
                    NotificationService.ShowWarning("非法输入，请重新输入！");
                    txtReceipts.Clear();
                    txtReceipts.Focus();
                    return;
                }
            }
            else
            {
                lblChange.Text = "-" + lblGetReceipts.Text;
                return;
            }
        }
    }
}
