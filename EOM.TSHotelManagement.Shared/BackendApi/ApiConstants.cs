namespace EOM.TSHotelManagement.Shared
{
    public static class ApiConstants
    {
        public const string Default_Version = "version";
        public const string Common_GetCsrfToken = "Login/GetCsrfToken";
        public const string Common_RefreshCsrfToken = "Login/RefreshCSRFToken";

        // Base URLs
        public const string Base_SelectNationAll = "Base/SelectNationAll";
        public const string Base_SelectGenderTypeAll = "Base/SelectGenderTypeAll";
        public const string Base_SelectDeptAllCanUse = "Base/SelectDeptAllCanUse";
        public const string Base_SelectPositionAll = "Base/SelectPositionAll";
        public const string Base_SelectCustoTypeAllCanUse = "Base/SelectCustoTypeAllCanUse";
        public const string Base_SelectPassPortTypeAllCanUse = "Base/SelectPassPortTypeAllCanUse";
        public const string Base_SelectRoomStateAll = "Base/SelectRoomStateAll";

        // Employee URLs
        public const string Employee_SelectEmployeeInfoByEmployeeId = "Employee/SelectEmployeeInfoByEmployeeId";
        public const string Employee_UpdateEmployee = "Employee/UpdateEmployee";
        public const string Employee_SelectEmployeeInfoByEmployeeIdAndEmployeePwd = "Employee/SelectEmployeeInfoByEmployeeIdAndEmployeePwd";
        public const string Employee_UpdateEmployeeAccountPassword = "Employee/UpdateEmployeeAccountPassword";

        // EmployeePhoto URLs
        public const string EmployeePhoto_EmployeePhoto = "EmployeePhoto/EmployeePhoto";
        public const string EmployeePhoto_DeleteWorkerPhoto = "EmployeePhoto/DeleteWorkerPhoto";
        public const string EmployeePhoto_InsertWorkerPhoto = "EmployeePhoto/InsertWorkerPhoto";

        // EmployeeCheck
        public const string EmployeeCheck_SelectToDayCheckInfoByWorkerNo = "EmployeeCheck/SelectToDayCheckInfoByWorkerNo";
        public const string EmployeeCheck_SelectWorkerCheckDaySumByEmployeeId = "EmployeeCheck/SelectWorkerCheckDaySumByEmployeeId";
        public const string EmployeeCheck_AddCheckInfo = "EmployeeCheck/AddCheckInfo";

        // Room URLs
        public const string Room_SelectRoomAll = "Room/SelectRoomAll";
        public const string Room_SelectRoomByRoomNo = "Room/SelectRoomByRoomNo";
        public const string Room_DayByRoomNo = "Room/DayByRoomNo";
        public const string Room_SelectCanUseRoomAll = "Room/SelectCanUseRoomAll";
        public const string Room_UpdateRoomInfo = "Room​/UpdateRoomInfo";
        public const string Room_UpdateRoomInfoWithReser = "Room​/UpdateRoomInfoWithReser";
        public const string Room_SelectRoomByTypeName = "Room/SelectRoomByTypeName";
        public const string Room_SelectRoomByRoomState = "Room/SelectRoomByRoomState";
        public const string Room_UpdateRoomStateByRoomNo = "Room/UpdateRoomStateByRoomNo";
        public const string Room_SelectCanUseRoomAllByRoomState = "Room/SelectCanUseRoomAllByRoomState";
        public const string Room_SelectNotUseRoomAllByRoomState = "Room/SelectNotUseRoomAllByRoomState";
        public const string Room_SelectNotClearRoomAllByRoomState = "Room/SelectNotClearRoomAllByRoomState";
        public const string Room_SelectFixingRoomAllByRoomState = "Room/SelectFixingRoomAllByRoomState";
        public const string Room_SelectReservedRoomAllByRoomState = "Room/SelectReservedRoomAllByRoomState";
        public const string Room_TransferRoom = "Room/TransferRoom";
        public const string Room_CheckoutRoom = "Room/CheckoutRoom";
        public const string Room_CheckinRoomByReservation = "Room/CheckinRoomByReservation";

        // Reser URLs
        public const string Reser_SelectReserAll = "Reser/SelectReserAll";
        public const string Reser_DeleteReserInfo = "Reser/DeleteReserInfo";
        public const string Reser_InsertReserInfo = "Reser​/InserReserInfo";
        public const string Reser_SelectReserInfoByRoomNo = "Reser/SelectReserInfoByRoomNo";
        public const string Reser_SelectReserTypeAll = "Reser/SelectReserTypeAll";

        // Room Type URLs
        public const string RoomType_SelectRoomTypeByRoomNo = "RoomType/SelectRoomTypeByRoomNo";
        public const string RoomType_SelectRoomTypesAll = "RoomType/SelectRoomTypesAll";

        // Customer URLs
        public const string Customer_SelectCustoByInfo = "Customer/SelectCustoByInfo";
        public const string Customer_SelectCustomers = "Customer/SelectCustomers";
        public const string Customer_UpdCustomerTypeByCustoNo = "Customer/UpdCustomerTypeByCustoNo";
        public const string Customer_UpdCustomerInfo = "Customer/UpdCustomerInfo";
        public const string Customer_InsertCustomerInfo = "Customer/InsertCustomerInfo";

        // Customer Type URLs
        public const string CustoType_SelectCustoTypeByTypeId = "Base/SelectCustoTypeByTypeId";

        // Spend URLs
        public const string Spend_SelectSpendByRoomNo = "Spend/SelectSpendByRoomNo";
        public const string Spend_SumConsumptionAmount = "Spend/SumConsumptionAmount";
        public const string Spend_AddCustomerSpend = "Spend​/AddCustomerSpend";
        public const string Spend_SeletHistorySpendInfoAll = "Spend/SeletHistorySpendInfoAll";
        public const string Spend_UndoCustomerSpend = "Spend/UndoCustomerSpend";

        // PromotionContent
        public const string PromotionContent_SelectPromotionContents = "PromotionContent/SelectPromotionContents";

        // NavBar
        public const string NavBar_NavBarList = "NavBar/NavBarList";

        // VipLevelRule URLs
        public const string VipLevelRule_SelectVipRuleList = "VipRule/SelectVipRuleList";

        // SellThing
        public const string Sellthing_SelectSellThingAll = "Sellthing/SelectSellThingAll";
        public const string Sellthing_UpdateSellthingInfo = "Sellthing/UpdateSellthing";
        public const string Sellthing_SelectSellThingByNameAndPrice = "Sellthing/SelectSellThingByNameAndPrice";

        // Utility
        public const string Utility_SelectCardCode = "Utility/SelectCardCode";
        public const string Utility_AddLog = "Utility/AddLog";
    }
}
