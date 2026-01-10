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
using jvncorelib.EntityLib;
using System.Runtime.InteropServices;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmCustomerManagement : Window
    {
        public static int cm_CustoId;
        public static string cm_CustoNo;
        public static string cm_CustoName;
        public static int cm_CustoSex;
        public static string cm_CustoTel;
        public static int cm_PassportType;
        public static string cm_CustoIdCardNumber;
        public static string cm_CustoAddress;
        public static DateTime cm_CustoBirth;
        public static int cm_CustoType;

        public delegate void ReloadCustomerList(bool onlyVip);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

        //定义委托类型的变量
        public static ReloadCustomerList ReloadCustomer;

        private LoadingProgress _loadingProgress;
        public FrmCustomerManagement()
        {
            InitializeComponent();
            _loadingProgress = new LoadingProgress();
            ReloadCustomer = LoadCustomer;
        }

        Dictionary<string, string> dic = null;
        ResponseMsg result = null;

        TableComHelper helper = new TableComHelper();

        #region 用户管理界面加载事件方法
        private void FrmCustomerManagement_Load(object sender, EventArgs e)
        {
            btnClear.IconSvg = UIControlIconConstant.Clear;
            this.btnPg.PageSize = 15;
            LoadCustomer();
        }
        #endregion

        #region 加载用户信息列表
        private void LoadCustomer(bool onlyVip = false)
        {
            var dataCount = 0;
            btnPg.PageSizeOptions = new int[] { 15, 30, 50, 100 };
            dgvCustomerList.Spin("正在加载中...", config =>
            {
                TableComHelper tableComHelper = new TableComHelper();
                dgvCustomerList.Columns = tableComHelper.ConvertToAntdColumns(tableComHelper.GenerateDataColumns<ReadCustomerOutputDto>());
                dgvCustomerList.DataSource = GetPageData(btnPg.Current, btnPg.PageSize, ref dataCount);
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
                { nameof(ReadCustomerInputDto.Page), current <= 0 ? "1":current.ToString() },
                { nameof(ReadCustomerInputDto.PageSize), pageSize.ToString() },
                { nameof(ReadCustomerInputDto.IsDelete), "0" }
            };
            if (!txtCustoName.Text.Trim().IsNullOrEmpty())
            {
                dic.Add(nameof(ReadCustomerInputDto.CustomerName), txtCustoName.Text.Trim());
            }
            if (!txtCustoNo.Text.Trim().IsNullOrEmpty())
            {
                dic.Add(nameof(ReadCustomerInputDto.CustomerNumber), txtCustoNo.Text.Trim());
            }
            result = HttpHelper.Request(ApiConstants.Customer_SelectCustomers, dic);
            var customers = HttpHelper.JsonToModel<ListOutputDto<ReadCustomerOutputDto>>(result.message);
            if (customers.Success == false)
            {
                AntdUI.Message.error(this, "SelectCustomers+接口服务异常，请提交Issue或尝试更新版本！");
                return null!;
            }
            List<ReadCustomerOutputDto> custos = customers.Data.Items;
            totalCount = customers.Data.TotalCount;
            var listTableData = new List<AntdUI.AntItem[]>();

            custos = custos.OrderBy(a => a.CustomerNumber).ThenBy(a => a.CustomerName).ToList();

            TableComHelper tableComHelper = new TableComHelper();
            listTableData = tableComHelper.ConvertToAntdItems(custos);

            return listTableData;
        }

        #endregion

        int count = 0;
        private void btnSerach_BtnClick(object sender, EventArgs e)
        {
            var custos = new List<ReadCustomerOutputDto>();
            var response = new ListOutputDto<ReadCustomerOutputDto>();
            dic = new Dictionary<string, string>
            {
                { nameof(ReadCustomerInputDto.Page), "1" },
                { nameof(ReadCustomerInputDto.PageSize), "15" },
                { nameof(ReadCustomerInputDto.IsDelete), "0" }
            };
            if (!txtCustoNo.Text.IsNullOrEmpty())
            {
                dic.Add(nameof(ReadCustomerInputDto.CustomerNumber), txtCustoNo.Text.Trim());
            }
            if (!txtCustoName.Text.IsNullOrEmpty())
            {
                dic.Add(nameof(ReadCustomerInputDto.CustomerName), txtCustoName.Text.Trim());
            }
            result = HttpHelper.Request(ApiConstants.Customer_SelectCustomers, dic);
            response = HttpHelper.JsonToModel<ListOutputDto<ReadCustomerOutputDto>>(result.message);
            if (response.Success == false)
            {
                AntdUI.Message.error(this, $"{ApiConstants.Customer_SelectCustomers}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }

            custos = response.Data.Items;
            var totalCount = response.Data.TotalCount;
            var listTableData = new List<AntdUI.AntItem[]>();
            btnPg.Total = totalCount;
            custos = custos.OrderBy(a => a.CustomerNumber).ThenBy(a => a.CustomerName).ToList();

            TableComHelper tableComHelper = new TableComHelper();
            listTableData = tableComHelper.ConvertToAntdItems(custos);

            dgvCustomerList.Columns = tableComHelper.ConvertToAntdColumns(tableComHelper.GenerateDataColumns<ReadCustomerOutputDto>());
            dgvCustomerList.DataSource = listTableData;
        }

        private void btnAddCusto_BtnClick(object sender, EventArgs e)
        {
            FrmEditInputs frmInputs = new FrmEditInputs();
            frmInputs.ShowDialog();
        }

        private void btnUpdCustomer_Click(object sender, EventArgs e)
        {

            if (dgvCustomerList.SelectedIndex < 0)
            {
                AntdUI.Message.error(this, "未选中客户，无法继续操作！");
                return;
            }
            //cm_CustoId = cm_CustoId;
            //cm_CustoNo = cm_CustoNo;
            //cm_CustoName = cm_CustoName;
            //cm_CustoAddress = cm_CustoAddress.IsNullOrEmpty() ? "" : cm_CustoAddress.ToString();
            //cm_CustoType = Convert.ToInt32(cm_CustoType);
            //cm_CustoSex = Convert.ToInt32(cm_CustoSex);
            //cm_PassportType = Convert.ToInt32(cm_PassportType);
            //cm_CustoBirth = Convert.ToDateTime(cm_CustoBirth);
            //cm_CustoID = cm_CustoID;
            //cm_CustoTel = cm_CustoTel;
            FrmEditInputs frmInputs = new FrmEditInputs();
            frmInputs.Text = "修改客户信息";
            frmInputs.ShowDialog();
        }

        private void tsmiCustoNo_Click(object sender, EventArgs e)
        {
            if (!cm_CustoNo.IsNullOrEmpty())
            {
                ClipboardHelper.SetTextToClipboard(cm_CustoNo);
                AntdUI.Message.success(this, "复制完成！");
            }
        }

        private void dgvCustomerList_CellClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (e.Record is IList<AntdUI.AntItem> data)
            {
                cm_CustoId = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.Id)));
                cm_CustoNo = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerNumber));
                cm_CustoName = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerName));
                cm_CustoSex = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerGender)));
                cm_CustoTel = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerPhoneNumber));
                cm_CustoBirth = Convert.ToDateTime(helper.GetValue(data, nameof(ReadCustomerOutputDto.DateOfBirth)));
                cm_CustoType = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerType)));
                cm_PassportType = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.PassportId)));
                cm_CustoIdCardNumber = helper.GetValue(data, nameof(ReadCustomerOutputDto.IdCardNumber));
                cm_CustoAddress = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerAddress));
                btnUpdCustomer.Enabled = true;
            }
        }

        private string btnPg_ShowTotalChanged(object sender, AntdUI.PagePageEventArgs e)
        {
            return $"{e.PageSize} / {e.Total}条 共{e.PageTotal}页";
        }

        private void btnPg_ValueChanged(object sender, AntdUI.PagePageEventArgs e)
        {
            var dataCount = 0;
            dgvCustomerList.Spin("正在加载中...", config =>
            {
                dgvCustomerList.DataSource = GetPageData(e.Current, e.PageSize, ref dataCount);
                btnPg.Total = dataCount;
            }, () =>
            {
                System.Diagnostics.Debug.WriteLine("加载结束");
            });
        }

        private void dgvCustomerList_CellDoubleClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (e.Record is IList<AntdUI.AntItem> data)
            {
                cm_CustoId = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.Id)));
                cm_CustoNo = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerNumber));
                cm_CustoName = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerName));
                cm_CustoSex = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerGender)));
                cm_CustoTel = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerPhoneNumber));
                cm_CustoBirth = Convert.ToDateTime(helper.GetValue(data, nameof(ReadCustomerOutputDto.DateOfBirth)));
                cm_CustoType = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerType)));
                cm_PassportType = Convert.ToInt32(helper.GetValue(data, nameof(ReadCustomerOutputDto.PassportId)));
                cm_CustoIdCardNumber = helper.GetValue(data, nameof(ReadCustomerOutputDto.IdCardNumber));
                cm_CustoAddress = helper.GetValue(data, nameof(ReadCustomerOutputDto.CustomerAddress));

                FrmEditInputs frmInputs = new FrmEditInputs(_loadingProgress);
                frmInputs.Text = "修改客户信息";
                frmInputs.ShowDialog();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustoName.Clear();
            txtCustoNo.Clear();
            LoadCustomer();
        }
    }

}
