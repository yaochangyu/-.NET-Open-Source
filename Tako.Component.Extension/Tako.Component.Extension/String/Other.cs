// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-19-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="Other.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// 依長度，由右至左取得字串
        /// </summary>
        /// <param name="Value">字串</param>
        /// <param name="Length">長度</param>
        /// <returns>回傳字串</returns>
        /// 依長度，由右至左取得字串
        public static string Left(this string Value, int Length)
        {
            if (string.IsNullOrEmpty(Value))
            {
                //throw new ArgumentException("An empty string value cannot be encrypted.");
                return Value;
            }
            Length = Math.Max(Length, 0);

            if (Value.Length > Length)
            {
                return Value.Substring(0, Length);
            }
            else
            {
                return Value;
            }
        }

        /// <summary>
        /// 依長度，由左至右取得字串
        /// </summary>
        /// <param name="Value">字串</param>
        /// <param name="Length">長度</param>
        /// <returns>回傳字串</returns>
        /// 依長度，由左至右取得字串
        public static string Right(this string Value, int Length)
        {
            if (string.IsNullOrEmpty(Value))
            {
                //throw new ArgumentException("An empty string value cannot be encrypted.");
                return Value;
            }
            Length = Math.Max(Length, 0);

            if (Value.Length > Length)
            {
                return Value.Substring(Value.Length - Length, Length);
            }
            else
            {
                return Value;
            }
        }

        /// <summary>
        /// 字串轉型
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="Value">字串</param>
        /// <returns>回傳正確型別</returns>
        public static T Parse<T>(this string Value)
        {
            T result = default(T);

            if (string.IsNullOrEmpty(Value))
            {
                return result;
            }
            else
            {
                TypeConverter convert = TypeDescriptor.GetConverter(typeof(T));
                result = (T)convert.ConvertFrom(Value);
                return result;
            }
        }

        /// <summary>
        /// 字串字首轉大寫
        /// </summary>
        /// <param name="Value">擴充字串</param>
        /// <returns>回傳轉大寫結果</returns>
        public static string ToTitleCase(this string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return string.Empty;
            }
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            TextInfo info = culture.TextInfo;
            return info.ToTitleCase(Value);
        }

        /// <summary>
        /// 字串切短
        /// </summary>
        /// <param name="Value">擴充字串</param>
        /// <param name="MaxLength">顯示長度</param>
        /// <returns>回傳切短結果</returns>
        public static string Truncate(this string Value, int MaxLength)
        {
            const string suffix = "...";
            if (string.IsNullOrEmpty(Value))
            {
                return Value;
            }
            if (MaxLength <= 0)
            {
                return Value;
            }
            int strLength = MaxLength - suffix.Length;

            if (strLength <= 0)
                return Value;

            if (Value == null || Value.Length <= MaxLength)
                return Value;

            Value = Value.Substring(0, strLength);
            Value = Value.TrimEnd();
            Value += suffix;
            return Value;
        }

        /// <summary>
        /// 兩個日期差距
        /// </summary>
        /// <param name="StartDate">擴充DateTime類別</param>
        /// <param name="DatePart">設定差距旗標</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns>返回兩個日期差</returns>
        /// <exception cref="System.Exception"></exception>
        public static Int64 DateDiff(this DateTime StartDate, string DatePart, DateTime EndDate)
        {
            Int64 DateDiffVal = 0;
            Calendar calendar = Thread.CurrentThread.CurrentCulture.Calendar;
            TimeSpan ts = new TimeSpan(EndDate.Ticks - StartDate.Ticks);

            switch (DatePart.ToLower().Trim())
            {
                case "year":
                case "yy":
                case "yyyy":
                    DateDiffVal = (Int64)(calendar.GetYear(EndDate) - calendar.GetYear(StartDate));
                    break;

                case "quarter":
                case "qq":
                case "q":
                    DateDiffVal = (Int64)((((calendar.GetYear(EndDate) -
                                             calendar.GetYear(StartDate)) * 4) +
                                           ((calendar.GetMonth(EndDate) - 1) / 3)) -
                                          ((calendar.GetMonth(StartDate) - 1) / 3));
                    break;

                case "month":
                case "mm":
                case "m":
                    DateDiffVal = (Int64)(((calendar.GetYear(EndDate) -
                                            calendar.GetYear(StartDate)) * 12 +
                                           calendar.GetMonth(EndDate)) -
                                          calendar.GetMonth(StartDate));
                    break;

                case "day":
                case "d":
                case "dd":
                    DateDiffVal = (Int64)ts.TotalDays;
                    break;

                case "week":
                case "wk":
                case "ww":
                    DateDiffVal = (Int64)(ts.TotalDays / 7);
                    break;

                case "hour":
                case "hh":
                    DateDiffVal = (Int64)ts.TotalHours;
                    break;

                case "minute":
                case "mi":
                case "n":
                    DateDiffVal = (Int64)ts.TotalMinutes;
                    break;

                case "second":
                case "ss":
                case "s":
                    DateDiffVal = (Int64)ts.TotalSeconds;
                    break;

                case "millisecond":
                case "ms":
                    DateDiffVal = (Int64)ts.TotalMilliseconds;
                    break;

                default:
                    throw new Exception(String.Format("DatePart \"{0}\" is unknown", DatePart));
            }
            return DateDiffVal;
        }
    }
}