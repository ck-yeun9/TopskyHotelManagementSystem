using System;
using System.Collections.Generic;
using System.Text;

namespace EOM.TSHotelManagement.Shared
{
    public static class DiscountHelper
    {
        /// <summary>
        /// 计算折扣价格
        /// </summary>
        /// <param name="totalAmount">总消费金额</param>
        /// <param name="additionalAmount">额外金额</param>
        /// <param name="customerType">客户类型</param>
        /// <param name="originalAmount">输出：原始金额</param>
        /// <param name="discountedAmount">输出：折扣后金额</param>
        /// <param name="discountText">输出：折扣信息</param>
        public static void CalculateDiscount(
            decimal totalAmount,
            decimal additionalAmount,
            decimal discount,
            out decimal originalAmount,
            out decimal discountedAmount,
            out string discountText)
        {
            // 计算总金额
            originalAmount = totalAmount + additionalAmount;

            // 计算折扣系数
            decimal discountRate = (discount > 0 && discount < 100)
                ? discount  / 100M
                : 1M;

            // 计算折扣后金额
            discountedAmount = originalAmount * discountRate;

            // 获取折扣文本
            discountText = (discount > 0 && discount < 100)
                ? ToZheString(discount)
                : "无折扣(100%)";
        }
        /// <summary>
        /// 将折扣百分比转换为中文折扣字符串
        /// 例如：20 -> "八折"，25 -> "七五折"
        /// </summary>
        /// <param name="discountPercentage">折扣百分比（如20表示8折，30表示7折）</param>
        /// <returns>中文折扣字符串</returns>
        public static string ToZheString(decimal discountPercentage)
        {
            if (discountPercentage <= 0 || discountPercentage >= 100)
            {
                return "无折扣";
            }

            // 计算实际支付比例（100% - 折扣百分比）
            decimal payPercentage = 100 - discountPercentage;

            // 将支付比例转换为"折"表示
            return ConvertToChineseZhe(payPercentage);
        }

        /// <summary>
        /// 将支付比例转换为中文折扣表示
        /// </summary>
        /// <param name="payPercentage">支付比例（如80表示支付80%，即8折）</param>
        /// <returns>中文折扣字符串</returns>
        private static string ConvertToChineseZhe(decimal payPercentage)
        {
            // 常见折扣的简写
            var commonDiscounts = new Dictionary<decimal, string>
            {
                { 100, "全价" },
                { 95, "九五折" },
                { 90, "九折" },
                { 85, "八五折" },
                { 80, "八折" },
                { 75, "七五折" },
                { 70, "七折" },
                { 65, "六五折" },
                { 60, "六折" },
                { 55, "五五折" },
                { 50, "五折" },
                { 45, "四五折" },
                { 40, "四折" },
                { 35, "三五折" },
                { 30, "三折" },
                { 25, "二五折" },
                { 20, "两折" },
                { 15, "一五折" },
                { 10, "一折" },
                { 5, "半折" }
            };

            // 如果找到常见的折扣，直接返回
            if (commonDiscounts.ContainsKey(payPercentage))
            {
                return commonDiscounts[payPercentage];
            }

            // 对于不常见的折扣，转换为中文数字
            return ConvertPercentageToChinese(payPercentage) + "折";
        }

        /// <summary>
        /// 将百分比转换为中文数字表示
        /// </summary>
        private static string ConvertPercentageToChinese(decimal percentage)
        {
            // 将百分比除以10得到折数
            decimal zhe = percentage / 10;

            // 中文数字数组
            string[] chineseDigits = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            string[] chineseUnits = { "", "十", "百", "千" };

            // 处理常见的小数折扣
            if (zhe == (int)zhe)
            {
                // 整数折扣
                return ConvertIntegerToChinese((int)zhe, chineseDigits, chineseUnits);
            }
            else
            {
                // 小数折扣（如8.5折）
                return ConvertDecimalToChinese(zhe, chineseDigits);
            }
        }

        /// <summary>
        /// 将整数折扣转换为中文
        /// </summary>
        private static string ConvertIntegerToChinese(int number, string[] digits, string[] units)
        {
            if (number == 10) return "十";
            if (number < 10) return digits[number];

            // 处理10-99之间的数字
            string result = "";
            int tens = number / 10;
            int ones = number % 10;

            if (tens > 1) result += digits[tens];
            result += "十";
            if (ones > 0) result += digits[ones];

            return result;
        }

        /// <summary>
        /// 将小数折扣转换为中文
        /// </summary>
        private static string ConvertDecimalToChinese(decimal number, string[] digits)
        {
            // 处理一位小数的情况（如8.5 -> 八五）
            string str = number.ToString("0.0");
            string[] parts = str.Split('.');

            int integerPart = int.Parse(parts[0]);
            int decimalPart = int.Parse(parts[1]);

            string result = ConvertIntegerToChinese(integerPart, digits, new string[] { "", "十", "百", "千" });

            if (decimalPart > 0)
            {
                result += digits[decimalPart];
            }

            return result;
        }
    }
}
