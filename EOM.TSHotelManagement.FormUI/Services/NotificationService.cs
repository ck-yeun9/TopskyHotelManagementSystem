using AntdUI;
using EOM.TSHotelManagement.Common;
using EOM.TSHotelManagement.Shared;

namespace EOM.TSHotelManagement.FormUI
{
    public static class NotificationService
    {
        public static void ShowSuccess(string message)
        {
            Modal.open(new Modal.Config(UIMessageConstant.Success, message, TType.Success)
            {
                Draggable = true,
                CancelText = null,
                OkText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Ok, UIMessageConstant.Chs_Ok),
                OnButtonStyle = (id, btn) =>
                {
                    btn.Shape = TShape.Round;
                },
            });
        }

        public static void ShowError(string message)
        {
            Modal.open(new Modal.Config(UIMessageConstant.Error, message, TType.Error)
            {
                Draggable = true,
                CancelText = null,
                OkText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Ok, UIMessageConstant.Chs_Ok),
                OnButtonStyle = (id, btn) =>
                {
                    btn.Shape = TShape.Round;
                },
            });
        }

        public static void ShowInfo(string message)
        {
            Modal.open(new Modal.Config(UIMessageConstant.Information, message, TType.Info)
            {
                Draggable = true,
                CancelText = null,
                OkText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Ok, UIMessageConstant.Chs_Ok),
                OnButtonStyle = (id, btn) =>
                {
                    btn.Shape = TShape.Round;
                },
            });
        }

        public static void ShowWarning(string message)
        {
            Modal.open(new Modal.Config(UIMessageConstant.Warning, message, TType.Warn)
            {
                Draggable = true,
                CancelText = null,
                OkText = LocalizationHelper.GetLocalizedString(UIMessageConstant.Eng_Ok, UIMessageConstant.Chs_Ok),
                OnButtonStyle = (id, btn) =>
                {
                    btn.Shape = TShape.Round;
                },
            });
        }
    }
}
