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
using System.ComponentModel;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmCustomerInfo : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerInfo));
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerNumber { get => customerNumber; set => customerNumber = value; }
        public FrmCustomerInfo(string customerNumber)
        {
            InitializeComponent();
            CustomerNumber = customerNumber;

            ucWindowHeader1.ApplySettingsWithoutMinimize("查看用户信息", string.Empty, (Image)resources.GetObject("FrmCustomerInfo.Icon")!);
        }

        Dictionary<string, string> dic = null;
        ResponseMsg result = null;
        private string customerNumber;

        private void FrmSelectCustoInfo_Load(object sender, EventArgs e)
        {
            dic = new Dictionary<string, string>()
            {
                { nameof(ReadCustomerInputDto.CustomerNumber), CustomerNumber }
            };
            result = HttpHelper.Request(ApiConstants.Customer_SelectCustoByInfo, dic);
            var c = HttpHelper.JsonToModel<SingleOutputDto<ReadCustomerOutputDto>>(result.message);
            if (c.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Customer_SelectCustoByInfo}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            txtCustomerNumber.Text = c.Data.CustomerNumber;
            txtCustomerAddress.Text = c.Data.CustomerAddress;
            txtCustomerName.Text = c.Data.CustomerName;
            txtIdCardNumber.Text = c.Data.IdCardNumber;
            txtTel.Text = c.Data.CustomerPhoneNumber;
            txtCustomerGender.Text = c.Data.CustomerGender == 1 ? "男" : "女";
            txtCustomerType.Text = c.Data.CustomerTypeName;
            txtPassportName.Text = c.Data.PassportName;
            txtDateOfBirth.Text = c.Data.DateOfBirth.ToString("yyyy/MM/dd");
        }
    }
}
