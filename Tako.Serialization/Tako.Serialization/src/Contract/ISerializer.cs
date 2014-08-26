// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="ISerializer.cs" company="">
//     Copyright (c) .余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

/// <summary>
/// The Serialization namespace.
/// </summary>
namespace Tako.Serialization
{
    /// <summary>
    /// Interface ISerializer
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <returns>System.Byte[].</returns>
        byte[] Serialize<T>(T source);

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <param name="outputFileName">Name of the file.</param>
        /// <returns>System.Byte[].</returns>
        byte[] Serialize<T>(T source, string outputFileName);

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <param name="outputStream">The stream.</param>
        /// <returns>System.Byte[].</returns>
        byte[] Serialize<T>(T source, Stream outputStream);

        /// <summary>
        /// Deserializes the specified sources.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputArray">The sources.</param>
        /// <returns>T.</returns>
        T Deserialize<T>(byte[] inputArray);

        /// <summary>
        /// Deserializes the specified file name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputFileName">Name of the file.</param>
        /// <returns>T.</returns>
        T Deserialize<T>(string inputFileName);

        /// <summary>
        /// Deserializes the specified stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputStream">The stream.</param>
        /// <returns>T.</returns>
        T Deserialize<T>(Stream inputStream);
    }
}