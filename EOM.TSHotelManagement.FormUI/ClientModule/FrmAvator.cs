using AntdUI;
using EOM.TSHotelManagement.Common;
using EOM.TSHotelManagement.Contract;
using EOM.TSHotelManagement.Shared;
using jvncorelib.EntityLib;
using System.ComponentModel;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmAvator : Window
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAvator));
        public FrmAvator()
        {
            InitializeComponent();

            ucWindowHeader1.ApplySettingsWithoutMinimize("账号头像", string.Empty, (Image)resources.GetObject("FrmAvator.Icon")!);
        }

        private void FrmAvator_Load(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, string>
            {
                { nameof(ReadEmployeePhotoInputDto.EmployeeId) , LoginInfo.WorkerNo }
            };
            result = HttpHelper.Request(ApiConstants.EmployeePhoto_EmployeePhoto, dic);
            var workerPic = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeePhotoOutputDto>>(result.message);
            if (workerPic.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.EmployeePhoto_EmployeePhoto}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            var workerPicData = workerPic.Data;
            if (workerPicData != null && !string.IsNullOrEmpty(workerPicData.PhotoPath))
            {
                picWorkerPic.BackgroundImage = null;
                if (!string.IsNullOrEmpty(workerPicData.PhotoPath)) picWorkerPic.Load(workerPicData.PhotoPath);
            }
        }


        public void PicHandler()
        {
            Dictionary<string, string> additionalParams = new Dictionary<string, string>
            {
                { nameof(CreateEmployeePhotoInputDto.EmployeeId), LoginInfo.WorkerNo }
            };

            var workerPic = new CreateEmployeePhotoInputDto
            {
                EmployeeId = LoginInfo.WorkerNo.Trim(),
                PhotoUrl = null,
            };
            var requestResult = HttpHelper.UploadFile(ApiConstants.EmployeePhoto_InsertWorkerPhoto, openPic.FileName, additionalParams);
            var response = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeePhotoOutputDto>>(requestResult.message);
            if (response.Success == false)
            {
                NotificationService.ShowError($"{response.Message}:{ApiConstants.EmployeePhoto_InsertWorkerPhoto}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            NotificationService.ShowSuccess("头像上传成功！稍等将会加载头像哦..");
            picWorkerPic.Load(response.Data.PhotoPath);
        }

        private void picWorkerPic_Click(object sender, EventArgs e)
        {
            openPic.ShowDialog();
        }

        ResponseMsg result = new ResponseMsg();
        private void openPic_FileOk(object sender, CancelEventArgs e)
        {
            var dic = new Dictionary<string, string>
            {
                { nameof(ReadEmployeePhotoInputDto.EmployeeId) , LoginInfo.WorkerNo }
            };
            result = HttpHelper.Request(ApiConstants.EmployeePhoto_EmployeePhoto, dic);
            var workerPic = HttpHelper.JsonToModel<SingleOutputDto<ReadEmployeePhotoOutputDto>>(result.message);
            if (workerPic.Success == false)
            {
                NotificationService.ShowError($"{ApiConstants.EmployeePhoto_EmployeePhoto}+接口服务异常，请提交Issue或尝试更新版本！");
                return;
            }
            var workerPicData = workerPic.Data;
            if (!workerPicData.IsNullOrEmpty() && !string.IsNullOrEmpty(workerPicData.PhotoPath))
            {
                result = HttpHelper.Request(ApiConstants.EmployeePhoto_DeleteWorkerPhoto, workerPic.ModelToJson());
                var response = HttpHelper.JsonToModel<BaseResponse>(result.message);
                if (response.Success == false)
                {
                    NotificationService.ShowError($"{ApiConstants.EmployeePhoto_DeleteWorkerPhoto}+接口服务异常，请提交Issue或尝试更新版本！");
                    return;
                }
                PicHandler();
            }
            else
            {
                PicHandler();
            }

        }

    }
}
