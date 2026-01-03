using EOM.TSHotelManagement.Contract;
using jvncorelib.EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOM.TSHotelManagement.Shared
{
    public static class CsrfTokenHelper
    {
        public static string GetCsrfToken()
        {
            var apiResponse = HttpHelper.Request(ApiConstants.Common_GetCsrfToken, string.Empty);
            var response = HttpHelper.JsonToModel<SingleOutputDto<CsrfTokenDto>>(apiResponse.message);
            if (response.Success && response.Data != null)
            {
                LoginInfo.CsrfToken = response.Data.Token;
                LoginInfo.NeedRefreshCsrfToken = response.Data.NeedsRefresh;
            }

            return LoginInfo.CsrfToken ?? string.Empty;
        }

        public static string RefreshCsrfToken()
        {
            var apiResponse = HttpHelper.Request(ApiConstants.Common_RefreshCsrfToken, string.Empty);
            var response = HttpHelper.JsonToModel<SingleOutputDto<CsrfTokenDto>>(apiResponse.message);
            if (response.Success && response.Data != null)
            {
                LoginInfo.CsrfToken = response.Data.Token;
                LoginInfo.NeedRefreshCsrfToken = response.Data.NeedsRefresh;
            }

            return LoginInfo.CsrfToken ?? string.Empty;
        }
    }
}
