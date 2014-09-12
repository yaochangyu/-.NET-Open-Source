// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-14-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="TransparentDynamicObjectExtensions.cs" company="余小章">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

/// <summary>
/// The DynamicObjectExtension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class TransparentDynamicObjectExtensions.
    /// </summary>
    public static partial class TransparentDynamicObjectExtensions
    {
        /// <summary>
        /// Ases the transparent dynamic object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o">The o.</param>
        /// <returns>dynamic.</returns>
        public static dynamic AsTransparentDynamicObject<T>(this T o)
        {
            return new GenericTransparentDynamicObject<T>(o);
        }

        /// <summary>
        /// Ases the transparent dynamic object.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>dynamic.</returns>
        public static dynamic AsTransparentDynamicObject(Type type)
        {
            return new StaticClassTransparentDynamicObject(type);
        }
    }
}