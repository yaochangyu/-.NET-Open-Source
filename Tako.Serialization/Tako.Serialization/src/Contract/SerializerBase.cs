// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="SerializerBase.cs" company="">
//     Copyright (c) . 余小章 All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using System.Text;

/// <summary>
/// The Serialization namespace.
/// </summary>
namespace Tako.Serialization
{
    /// <summary>
    /// Class SerializerBase.
    /// </summary>
    public abstract class SerializerBase : ISerializer
    {
        /// <summary>
        /// The _encode
        /// </summary>
        private Encoding _encode = Encoding.UTF8;

        /// <summary>
        /// Gets or sets the encode.
        /// </summary>
        /// <value>The encode.</value>
        public virtual Encoding Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <returns>System.Byte[].</returns>

        public abstract byte[] Serialize<T>(T source);

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The object.</param>
        /// <param name="outputStream">The stream.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentNullException">source
        /// or
        /// outputStream</exception>
        public virtual byte[] Serialize<T>(T source, Stream outputStream)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (outputStream == null)
            {
                throw new ArgumentNullException("outputStream");
            }
            var serializeArray = this.Serialize(source);
            outputStream.Write(serializeArray, 0, serializeArray.Length);
            outputStream.Dispose();
            return serializeArray;
        }

        /// <summary>
        /// Serializes the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="outputFilePath">The output file path.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentNullException">source
        /// or
        /// outputFilePath</exception>
        public virtual byte[] Serialize<T>(T source, string outputFilePath)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                throw new ArgumentNullException("outputFilePath");
            }

            using (var outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                return this.Serialize(source, outputStream);
            }
        }

        /// <summary>
        /// Deserializes the specified sources.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputArray">The sources.</param>
        /// <returns>T.</returns>
        public abstract T Deserialize<T>(byte[] inputArray);

        /// <summary>
        /// Deserializes the specified stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputStream">The stream.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">inputStream</exception>
        public T Deserialize<T>(Stream inputStream)
        {
            if (ReferenceEquals(inputStream, null))
            {
                throw new ArgumentNullException("inputStream");
            }

            using (var memory = new MemoryStream())
            {
                inputStream.CopyTo(memory);
                return this.Deserialize<T>(memory.ToArray());
            }
        }

        /// <summary>
        /// Deserializes the specified file name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputFileName">Name of the file.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">inputFileName</exception>
        public virtual T Deserialize<T>(string inputFileName)
        {
            if (string.IsNullOrWhiteSpace(inputFileName))
            {
                throw new ArgumentNullException("inputFileName");
            }
            using (var inputStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read))
            {
                return this.Deserialize<T>(inputStream);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string ToString<T>(T obj)
        {
            return this.Encode.GetString(this.Serialize(obj));
        }
    }
}