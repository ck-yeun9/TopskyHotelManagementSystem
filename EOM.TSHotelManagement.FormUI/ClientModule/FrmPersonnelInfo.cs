using AntdUI;
using EOM.TSHotelManagement.Common;
using EOM.TSHotelManagement.Contract;
using jvncorelib.EntityLib;
using System.Data;
using EOM.TSHotelManagement.Shared;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmPersonnelInfo : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonnelInfo));
        private readonly LoadingProgress _loadingProgress;
        public FrmPersonnelInfo()
        {
            InitializeComponent();
            _loadingProgress = new LoadingProgress();
            ucWindowHeader1.ApplySettingsWithoutMinimize("我的信息", string.Empty, (Image)resources.GetObject("FrmPersonnelInfo.Icon")!);
        }
        ReadEmployeeOutputDto currentEmployee;
        private void FrmPersonnelInfo_Load(object sender, EventArgs e)
        {

            //加载民族信息
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                { nameof(ReadNationInputDto.IsDelete), "0" },
                { nameof(ReadNationInputDto.IgnorePaging), "true" }
            };
            var result = HttpHelper.Request(ApiConstants.Base_SelectNationAll, dic);
            var nations = HttpHelper.JsonToModel<ListOutputDto<ReadNationOutputDto>>(result.message);
            if (nations.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectNationAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            cboEmployeeNation.Items.AddRange(nations.Data.Items.Select(item => new AntdUI.SelectItem(item.NationName, item.NationNumber)).ToArray());
            //加载性别信息
            result = HttpHelper.Request(ApiConstants.Base_SelectGenderTypeAll);
            var genderTypes = HttpHelper.JsonToModel<ListOutputDto<EnumDto>>(result.message);
            if (genderTypes.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectGenderTypeAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            cboGender.Items.AddRange(genderTypes.Data.Items.Select(item => new AntdUI.SelectItem(item.Description, item.Id)).ToArray());
            //加载部门信息
            result = HttpHelper.Request(ApiConstants.Base_SelectDeptAllCanUse);
            var depts = HttpHelper.JsonToModel<ListOutputDto<ReadDepartmentOutputDto>>(result.message);
            if (depts.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectDeptAllCanUse}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            cboEmployeeDepartment.Items.AddRange(depts.Data.Items.Select(item => new AntdUI.SelectItem(item.DepartmentName, item.DepartmentNumber)).ToArray());
            //加载职位信息
            dic = new Dictionary<string, string>
            {
                { nameof(ReadPositionInputDto.IsDelete), "0" },
                { nameof(ReadPositionInputDto.IgnorePaging), "true" }
            };
            result = HttpHelper.Request(ApiConstants.Base_SelectPositionAll, dic);
            var positions = HttpHelper.JsonToModel<ListOutputDto<ReadPositionOutputDto>>(result.message);
            if (positions.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Base_SelectPositionAll}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            cboEmployeePosition.Items.AddRange(positions.Data.Items.Select(item => new AntdUI.SelectItem(item.PositionName, item.PositionNumber)).ToArray());

            LoadPersonnelInfo();
        }

        private void LoadPersonnelInfo()
        {
            var dic = new Dictionary<string, string>
            {
                { nameof(ReadEmployeeInputDto.EmployeeId) , LoginInfo.WorkerNo }
            };
            var result = HttpHelper.Request(ApiConstants.Employee_SelectEmployeeInfoByEmployeeId, dic);
            var employees = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeeOutputDto>>(result.message);
            if (employees.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.Employee_SelectEmployeeInfoByEmployeeId}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            currentEmployee = employees.Data;
            if (!currentEmployee.IsNullOrEmpty())
            {
                txtEmployeeId.Text = currentEmployee.EmployeeId;
                txtEmployeeName.Text = currentEmployee.EmployeeName;
                cboGender.SelectedValue = currentEmployee.Gender;
                cboEmployeePosition.Text = currentEmployee.PositionName;
                cboEmployeePosition.SelectedValue = currentEmployee.Position;
                cboEmployeeDepartment.Text = currentEmployee.DepartmentName;
                cboEmployeeDepartment.SelectedValue = currentEmployee.Department;
                cboEmployeeNation.Text = currentEmployee.EthnicityName;
                cboEmployeeNation.SelectedValue = currentEmployee.Ethnicity;
                txtEmployeeAddress.Text = currentEmployee.Address;
                txtEmailAddress.Text = currentEmployee.EmailAddress;
                txtEmployeeTel.Text = currentEmployee.PhoneNumber;
            }
            Refresh();
        }

        public bool CheckInput(UpdateEmployeeInputDto worker)
        {
            if (string.IsNullOrWhiteSpace(worker.EmployeeId))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(worker.EmployeeName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(worker.Gender + ""))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(worker.Ethnicity))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(worker.PhoneNumber))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(worker.Address))
            {
                return false;
            }
            return true;
        }

        ResponseMsg result = new ResponseMsg();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _loadingProgress.Show();
            UpdateEmployeeInputDto employee = new UpdateEmployeeInputDto()
            {
                Id = currentEmployee.Id,
                EmployeeId = txtEmployeeId.Text.Trim(),
                EmployeeName = txtEmployeeName.Text.Trim(),
                Gender = cboGender.Text == "男" ? 1 : 0,
                Ethnicity = cboEmployeeNation.SelectedValue.ToString(),
                PhoneNumber = txtEmployeeTel.Text.Trim(),
                Address = txtEmployeeAddress.Text.Trim(),
                EmailAddress = txtEmailAddress.Text.Trim(),
                PoliticalAffiliation = currentEmployee.PoliticalAffiliation,
                Position = currentEmployee.Position,
                Department = currentEmployee.Department,
                HireDate = DateOnly.FromDateTime(currentEmployee.HireDate),
                IdCardNumber = currentEmployee.IdCardNumber,
                EducationLevel = currentEmployee.EducationLevel,
                DateOfBirth = DateOnly.FromDateTime(currentEmployee.DateOfBirth),
                IsEnable = currentEmployee.IsEnable,
                IsDelete = currentEmployee.IsDelete,
                IdCardType = currentEmployee.IdCardType,
                Password = currentEmployee.Password,
                OldPassword = currentEmployee.Password,
                IsInitialize = currentEmployee.IsInitialize,
                DataChgUsr = LoginInfo.WorkerNo,
                DataChgDate = DateTime.Now
            };

            if (CheckInput(employee))
            {
                result = HttpHelper.Request(ApiConstants.Employee_UpdateEmployee, employee.ModelToJson());
                var response = HttpHelper.JsonToModel<BaseResponse>(result.message);
                if (response.Success == false)
                {
                    NotificationService.ShowError($"{ApiConstants.Employee_UpdateEmployee}+接口服务异常，请提交Issue或尝试更新版本！");
                    return;
                }
                _loadingProgress.Close();
                NotificationService.ShowSuccess("修改成功！");
                #region 获取添加操作日志所需的信息
                RecordHelper.Record(LoginInfo.WorkerNo + "-" + LoginInfo.WorkerName + "在" + Convert.ToDateTime(DateTime.Now) + "位于" + LoginInfo.SoftwareVersion + "执行：" + "修改个人信息操作！", LogLevel.Warning);
                #endregion
                LoadPersonnelInfo();
                return;
            }
        }
    }
}
