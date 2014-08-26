// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-19-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="Mask.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text;

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
        /// 字串遮蔽
        /// </summary>
        /// <param name="Value">擴充字串</param>
        /// <param name="Exposed">遮蔽長度</param>
        /// <returns>返回遮蔽結果</returns>
        /// 字串遮蔽
        public static string Mask(this string Value, int Exposed)
        {
            return Mask(Value, '*', Exposed);
        }

        /// <summary>
        /// 字串遮蔽
        /// </summary>
        /// <param name="Value">擴充字串</param>
        /// <param name="MaskChar">遮蔽字元</param>
        /// <param name="Exposed">遮蔽長度</param>
        /// <returns>返回遮蔽結果</returns>
        /// 字串遮蔽
        public static string Mask(this string Value, char MaskChar, int Exposed)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return string.Empty;
            }

            if (MaskChar == ' ')
            {
                MaskChar = '*';
            }

            StringBuilder builder = new StringBuilder(Value.Length);
            int index = Value.Length - Exposed;
            builder.Append(MaskChar, index);
            builder.Append(Value.Substring(index));
            return builder.ToString();
        }
    }
}