// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-19-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="Valid.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Net;
using System.Text.RegularExpressions;

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
        /// 判斷字串內所有字元是否為數字
        /// </summary>
        /// <param name="Value">擴充字串</param>
        /// <returns>返回判斷結果</returns>
        /// 判斷字串內所有字元是否為數字
        public static bool IsAllNumber(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }
            foreach (var ch in source)
            {
                if (!char.IsNumber(ch))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判斷字串是否為數字
        /// </summary>
        /// <param name="source">擴充字串</param>
        /// <returns>返回判斷結果</returns>
        /// 判斷字串是否為數字
        public static bool IsNumeric(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }
            int number;
            return int.TryParse(source, out number);
        }

        /// <summary>
        /// 判斷字串是否為Email
        /// </summary>
        /// <param name="source">擴充字串</param>
        /// <returns>返回判斷結果</returns>
        /// 判斷字串是否為Email
        public static bool IsEmail(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(source);
        }

        /// <summary>
        /// 判斷字串是否為URI
        /// </summary>
        /// <param name="source">擴充字串</param>
        /// <returns>返回判斷結果</returns>
        /// 判斷字串是否為URI
        public static bool IsUri(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return rx.IsMatch(source);
        }

        /// <summary>
        /// 判斷字串是否為Guid
        /// </summary>
        /// <param name="source">擴充字串</param>
        /// <returns>返回判斷結果</returns>
        /// 判斷字串是否為Guid
        public static bool IsGuid(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }
            Guid result;
            if (Guid.TryParse(source, out result))
            {
                return true;
            }
            return false;
            //Regex format = new Regex(
            //    "^[A-Fa-f0-9]{32}$|" +
            //    "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
            //    "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            //Match match = format.Match(source);

            //return match.Success;
        }

        /// <summary>
        /// 判斷字串是否為 IP
        /// </summary>
        /// <param name="Value">擴充字串</param>
        /// <returns>返回判斷結果</returns>
        /// 判斷字串是否為 IP
        public static bool IsIpAddress(this string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return false;
            }

            IPAddress ip = null;
            if (IPAddress.TryParse(Value, out ip))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}