// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="BinarySerializer.cs" company="">
//     Copyright (c) .余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// The Serialization namespace.
/// </summary>
namespace Tako.Serialization
{
    /// <summary>
    /// Class BinarySerializer.
    /// </summary>
    public class BinarySerializer : SerializerBase
    {
        /// <summary>
        /// The s_pool
        /// </summary>
        private static Dictionary<Type, BinaryFormatter> s_pool = new Dictionary<Type, BinaryFormatter>();

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        public override byte[] Serialize<T>(T source)
        {
            var memory = new MemoryStream();
            this.initialBinaryFormatter<T>().Serialize(memory, source);
            memory.Position = 0;
            return memory.ToArray();
        }

        /// <summary>
        /// Deserializes the specified sources.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputArray">The sources.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">inputArray</exception>
        public override T Deserialize<T>(byte[] inputArray)
        {
            var memory = new MemoryStream(inputArray);
            object obj = this.initialBinaryFormatter<T>().Deserialize(memory);
            return (T)obj;
        }

        /// <summary>
        /// Initials the binary formatter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>BinaryFormatter.</returns>
        private BinaryFormatter initialBinaryFormatter<T>()
        {
            Type type = typeof(T);
            if (!s_pool.ContainsKey(type))
            {
                var serializer = new BinaryFormatter();
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