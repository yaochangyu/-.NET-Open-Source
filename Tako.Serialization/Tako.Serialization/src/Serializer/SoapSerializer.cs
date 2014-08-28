// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="SoapSerializer.cs" company="">
//     Copyright (c) .余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

/// <summary>
/// The Serialization namespace.
/// </summary>
namespace Tako.Serialization
{
    /// <summary>
    /// Class SoapSerializer.
    /// </summary>
    public class SoapSerializer : SerializerBase
    {
        /// <summary>
        /// The s_pool
        /// </summary>
        private static Dictionary<Type, SoapFormatter> s_pool = new Dictionary<Type, SoapFormatter>();

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        public override byte[] Serialize<T>(T source)
        {
            using (var memory = new MemoryStream())
            {
                this.cretaeBinaryFormatter<T>().Serialize(memory, source);
                return memory.ToArray();
            }
        }

        /// <summary>
        /// Deserializes the specified sources.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputArray">The sources.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">stream</exception>
        public override T Deserialize<T>(byte[] inputArray)
        {
            var memory = new MemoryStream(inputArray);
            object obj = this.cretaeBinaryFormatter<T>().Deserialize(memory);
            if (obj == null)
            {
                return default(T);
            }
            else
            {
                return (T)obj;
            }
        }

        /// <summary>
        /// Cretaes the binary formatter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>SoapFormatter.</returns>
        private SoapFormatter cretaeBinaryFormatter<T>()
        {
            Type type = typeof(T);
            if (!s_pool.ContainsKey(type))
            {
                var serializer = new SoapFormatter();
                s_pool.Add(type, serializer);
                return serializer;
            }
            else
            {
                return s_pool[type];
            }
        }
    }
}