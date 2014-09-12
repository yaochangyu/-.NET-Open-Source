// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-26-2014
//
// Last Modified By : 余小章
// Last Modified On : 09-04-2014
// ***********************************************************************
// <copyright file="BindingListExtension.cs" company="余小章">
//     Copyright (c) 余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class BindingListExtension.
    /// </summary>
    public static class BindingListExtension
    {
        /// <summary>
        /// Ases the binding list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>SortableBindingList&lt;T&gt;.</returns>
        public static SortableBindingList<T> AsBindingList<T>(this T source) where T : IEnumerable<T>
        {
            SortableBindingList<T> list = new SortableBindingList<T>(source);
            return list;
        }
    }
}