// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-19-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="Split.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

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
        /// 字串分割並轉型成正確的集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="Value">擴充字串</param>
        /// <param name="Agrs">分割字元</param>
        /// <returns>返回分割後的集合</returns>
        public static IEnumerable<T> Split<T>(this string Value, params char[] Agrs) where T : IConvertible
        {
            foreach (var item in Value.Split(Agrs, StringSplitOptions.RemoveEmptyEntries))
                yield return (T)Convert.ChangeType(item, typeof(T));
        }

        //public static IEnumerable<T> Split<T>(this string value, char Agrs) where T : IConvertible
        //{
        //    foreach (var item in value.Split(Agrs))
        //        yield return (T)Convert.ChangeType(item, typeof(T));
        //}

        /// <summary>
        /// 字串分割並轉型成正確的集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="Value">擴充字串</param>
        /// <param name="Agrs">分割字串</param>
        /// <returns>返回分割後的集合</returns>
        public static IEnumerable<T> Split<T>(this string Value, params string[] Agrs) where T : IConvertible
        {
            foreach (var item in Value.Split(Agrs, StringSplitOptions.RemoveEmptyEntries))
                yield return (T)Convert.ChangeType(item, typeof(T));
        }
    }
}