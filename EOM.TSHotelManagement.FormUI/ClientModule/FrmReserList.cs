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
using EOM.TSHotelManagement.Contract;
using EOM.TSHotelManagement.Shared;
using jvncorelib.CodeLib;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmReserList : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReserList));
        public FrmReserList()
        {
            InitializeComponent();

            ucWindowHeader1.ApplySettingsWithoutMinimize("预约列表", string.Empty, (Image)resources.GetObject("FrmReserList.Icon")!);
        }

        ResponseMsg result = new ResponseMsg();
        Dictionary<string, string> dic = null;

        public static string RoomNumber { get; set; } = string.Empty;
        public static string ReservationId { get; set; } = string.Empty;

        TableComHelper helper = new TableComHelper();

        private void LoadReserData()
        {
            var dataCount = 0;
            btnPg.PageSizeOptions = new int[] { 15, 30, 50, 100 };
            dgvReserList.Spin("正在加载中...", config =>
            {
                TableComHelper tableComHelper = new TableComHelper();
                dgvReserList.Columns = tableComHelper.ConvertToAntdColumns(tableComHelper.GenerateDataColumns<ReadReserOutputDto>());
                dgvReserList.DataSource = GetPageData(btnPg.Current, btnPg.PageSize, ref dataCount);
                btnPg.PageSize = 15;
                btnPg.Current = 1;
                btnPg.Total = dataCount;
            }, () =>
            {
                System.Diagnostics.Debug.WriteLine("加载结束");
            });
        }

        object GetPageData(int current, int pageSize, ref int totalCount)
        {
            dic = new Dictionary<string, string>()
            {
                { nameof(ReadReserInputDto.Page), current <= 0 ? "1":current.ToString() },
                { nameof(ReadReserInputDto.PageSize), pageSize.ToString() },
                { nameof(ReadReserInputDto.IsDelete), "0" }
            };
            result = HttpHelper.Request(ApiConstants.Reser_SelectReserAll, dic);
            var resers = HttpHelper.JsonToModel<ListOutputDto<ReadReserOutputDto>>(result.message);
            if (resers.Success == false)
            {
                AntdUI.Message.error(this, $"{ApiConstants.Reser_SelectReserAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return null!;
            }
            List<ReadReserOutputDto> reserDataSource = resers.Data.Items;
            totalCount = resers.Data.TotalCount;
            var listTableData = new List<AntdUI.AntItem[]>();

            reserDataSource = reserDataSource.OrderBy(a => a.ReservationId).ThenBy(a => a.CustomerName).ToList();

            TableComHelper tableComHelper = new TableComHelper();
            listTableData = tableComHelper.ConvertToAntdItems(reserDataSource);

            return listTableData;
        }

        private string btnPg_ShowTotalChanged(object sender, AntdUI.PagePageEventArgs e)
        {
            return $"{e.PageSize} / {e.Total}条 共{e.PageTotal}页";
        }

        private void btnPg_ValueChanged(object sender, AntdUI.PagePageEventArgs e)
        {
            var dataCount = 0;
            dgvReserList.Spin("正在加载中...", config =>
            {
                dgvReserList.DataSource = GetPageData(e.Current, e.PageSize, ref dataCount);
                btnPg.Total = dataCount;
            }, () =>
            {
                System.Diagnostics.Debug.WriteLine("加载结束");
            });
        }

        private void FrmReserList_Load(object sender, EventArgs e)
        {
            LoadReserData();

            #region 加载客户类型信息
            result = HttpHelper.Request(ApiConstants.Base_SelectCustoTypeAllCanUse);
            var customerTypeDataSource = HttpHelper.JsonToModel<ListOutputDto<ReadCustoTypeOutputDto>>(result.message);
            if (customerTypeDataSource.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectCustoTypeAllCanUse}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            List<ReadCustoTypeOutputDto> lstDataGrid = customerTypeDataSource.Data.Items;
            this.cboCustomerType.Items.AddRange(lstDataGrid.Select(item => new AntdUI.SelectItem(item.CustomerTypeName, item.CustomerType)).ToArray());
            #endregion

            #region 加载证件类型信息
            result = HttpHelper.Request(ApiConstants.Base_SelectPassPortTypeAllCanUse);
            var passportDataSource = HttpHelper.JsonToModel<ListOutputDto<ReadPassportTypeOutputDto>>(result.message);
            if (passportDataSource.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectPassPortTypeAllCanUse}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            List<ReadPassportTypeOutputDto> passPorts = passportDataSource.Data.Items;
            this.cboPassportType.Items.AddRange(passPorts.Select(item => new AntdUI.SelectItem(item.PassportName, item.PassportId)).ToArray());
            #endregion

            #region 加载性别信息
            result = HttpHelper.Request(ApiConstants.Base_SelectGenderTypeAll);
            var genderTypeDataSource = HttpHelper.JsonToModel<ListOutputDto<EnumDto>>(result.message);
            if (genderTypeDataSource.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectGenderTypeAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            List<EnumDto> listSexType = genderTypeDataSource.Data.Items;
            this.cboGender.Items.AddRange(listSexType.Select(item => new AntdUI.SelectItem(item.Description, item.Id)).ToArray());
            #endregion
        }

        private void dgvReserList_CellClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (e.Record is IList<AntdUI.AntItem> data)
            {
                ReservationId = helper.GetValue(data, nameof(ReadReserOutputDto.ReservationId));
                RoomNumber = helper.GetValue(data, nameof(ReadReserOutputDto.ReservationRoomNumber));
                string custoNo = new UniqueCode().GetNewId("TS-");
                txtCustomerId.Text = custoNo;
                txtCustomerName.Text = helper.GetValue(data, nameof(ReadReserOutputDto.CustomerName));
                txtCustomerTel.Text = helper.GetValue(data, nameof(ReadReserOutputDto.ReservationPhoneNumber));
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var reser = new CheckinRoomByReservationDto
            {
                ReservationId = ReservationId,
                RoomNumber = RoomNumber,
                CustomerNumber = txtCustomerId.Text.Trim(),
                CustomerName = txtCustomerName.Text.Trim(),
                CustomerType = Convert.ToInt32(cboCustomerType.SelectedValue),
                CustomerPhoneNumber = txtCustomerTel.Text.Trim(),
                CustomerAddress = txtCustomerAddress.Text.Trim(),
                IdCardNumber = txtCustomerCardID.Text.Trim(),
                PassportId = Convert.ToInt32(cboPassportType.SelectedValue),
                CustomerGender = Convert.ToInt32(cboGender.SelectedValue),
                DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(dtpDateOfBirth.Value)),
                IsDelete = 0,
                DataInsUsr = LoginInfo.WorkerNo,
                DataChgUsr = LoginInfo.WorkerNo,
                DataInsDate = DateTime.Now,
                DataChgDate = DateTime.Now
            };
            result = HttpHelper.Request(ApiConstants.Room_CheckinRoomByReservation, reser.ModelToJson());
            var response = HttpHelper.JsonToModel<BaseResponse>(result.message);
            if (response.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Room_CheckinRoomByReservation}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }

            NotificationService.ShowSuccess("操作成功");
            LoadReserData();
            FrmRoomManager.Reload("");
            FrmRoomManager._RefreshRoomCount();
            this.Close();
        }

        private void txtCardID_Validated(object sender, EventArgs e)
        {
            //获取得到输入的身份证号码
            string identityCard = txtCustomerCardID.Text.Trim();

            if (string.IsNullOrEmpty(identityCard))
            {
                //身份证号码不能为空，如果为空返回
                NotificationService.ShowWarning("身份证号码不能为空！");
                if (txtCustomerCardID.CanFocus)
                {
                    txtCustomerCardID.Focus();//设置当前输入焦点为txtCardID_identityCard
                }
                return;
            }
            else
            {
                //身份证号码只能为15位或18位其它不合法
                if (identityCard.Length != 15 && identityCard.Length != 18)
                {
                    NotificationService.ShowWarning("身份证号码为15位或18位，请检查！");
                    if (txtCustomerCardID.CanFocus)
                    {
                        txtCustomerCardID.Focus();
                    }
                    return;
                }
            }

            if (identityCard.Length == 18)
            {
                var result = ApplicationUtil.SearchCode(identityCard);
                if (string.IsNullOrEmpty(result.message)) //如果没有错误消息输出，则代表成功
                {
                    try
                    {
                        cboGender.SelectedValue = result.sex;
                        txtCustomerAddress.Text = result.address;
                        dtpDateOfBirth.Value = Convert.ToDateTime(result.birthday);
                    }
                    catch
                    {
                        NotificationService.ShowError("请正确输入证件号码！");
                        return;
                    }
                }
                else
                {
                    NotificationService.ShowError(result.message);
                    return;
                }
            }
            return;

        }
    }
}
