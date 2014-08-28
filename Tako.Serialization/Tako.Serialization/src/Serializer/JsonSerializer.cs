// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="JsonSerializer.cs" company="">
//     Copyright (c) .余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using System;

/// <summary>
/// The Serialization namespace.
/// </summary>
namespace Tako.Serialization
{
    /// <summary>
    /// Class JsonSerializer.
    /// </summary>
    public class JsonSerializer : SerializerBase
    {
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        public override byte[] Serialize<T>(T source)
        {
            var json = JsonConvert.SerializeObject(source);
            return this.Encode.GetBytes(json);
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
            var json = this.Encode.GetString(inputArray);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}