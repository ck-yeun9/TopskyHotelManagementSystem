using EOM.TSHotelManagement.Common.Contract;
using EOM.TSHotelManagement.Shared;
using jvncorelib.CodeLib;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManagement.Common
{
    /// <summary>
    /// 日志记录助手
    /// </summary>
    public class RecordHelper
    {
        /// <summary>
        /// 记录信息集合
        /// </summary>
        /// <param name="OperationLog"></param>
        /// <param name="level"></param>
        public static void Record(string operationLog, LogLevel level)
        {
            string api = ApiConstants.Utility_AddLog;
            var logDetail = new CreateOperationLogInputDto
            {
                OperationId = new UniqueCode().GetNewId("OP-"),
                OperationTime = Convert.ToDateTime(DateTime.Now),
                LogContent = operationLog,
                OperationAccount = LoginInfo.WorkerNo,
                LogLevel = level,
                SoftwareVersion = LoginInfo.SoftwareVersion,
                IsDelete = 0,
                DataInsUsr = LoginInfo.WorkerNo,
                DataInsDate = Convert.ToDateTime(DateTime.Now)
            };
            HttpHelper.Request(api, logDetail.ModelToJson());
        }

    }
}
