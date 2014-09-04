// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-19-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="GenericObjectExtensions.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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

        private static Migration s_migration = new Migration();

        public static U Migrate<T, U>(this T source, U target)
            where T : new()
            where U : new()
        {
            return s_migration.Migrate(source, target);
        }
    }
}