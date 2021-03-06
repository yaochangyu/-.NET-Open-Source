﻿// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-26-2014
//
// Last Modified By : 余小章
// Last Modified On : 09-12-2014
// ***********************************************************************
// <copyright file="GenericObjectExtensions.cs" company="余小章">
//     Copyright (c) 余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class GenericObjectExtensions.
    /// </summary>
    public static partial class GenericObjectExtensions
    {
        /// <summary>
        /// Deeps the clone.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>T.</returns>
        public static T Clone<T>(this T source) where T : new()
        {
            if (source != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    var result = (T)formatter.Deserialize(stream);
                    return result;
                }
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// The s_migration
        /// </summary>
        private static Migration s_migration = new Migration();

        /// <summary>
        /// Migrates the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="UTarget">The type of the u target.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>U.</returns>
        public static UTarget Migrate<TSource, UTarget>(this Type type, TSource source, UTarget target)
            where TSource : new()
            where UTarget : new()
        {
            return s_migration.Migrate(type, source, target);
        }
    }
}