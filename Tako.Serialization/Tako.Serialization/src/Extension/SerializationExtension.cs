// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : S01YAO
// Created          : 08-26-2014
//
// Last Modified By : S01YAO
// Last Modified On : 08-28-2014
// ***********************************************************************
// <copyright file="SerializationExtension.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// The Serialization namespace.
/// </summary>
using System.IO;

namespace Tako.Serialization
{
    /// <summary>
    /// Class SerializationExtension.
    /// </summary>
    public static partial class SerializationExtension
    {
        /// <summary>
        /// The s_ binary serializer
        /// </summary>
        private static BinarySerializer s_BinarySerializer = new BinarySerializer();

        /// <summary>
        /// The s_ XML serializer
        /// </summary>
        private static XmlSerializer s_XmlSerializer = new XmlSerializer();

        /// <summary>
        /// The s_ SOAP serializer
        /// </summary>
        private static SoapSerializer s_SoapSerializer = new SoapSerializer();

        /// <summary>
        /// The s_ json serializer
        /// </summary>
        private static JsonSerializer s_JsonSerializer = new JsonSerializer();

        /// <summary>
        /// Serializes the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">serializerType</exception>
        public static byte[] Serialize<T>(this T source, EnumSerializerType serializerType = EnumSerializerType.Binary) where T : new()
        {
            switch (serializerType)
            {
                case EnumSerializerType.XML:
                    return s_XmlSerializer.Serialize(source);
                    break;

                case EnumSerializerType.JSON:
                    return s_JsonSerializer.Serialize(source);
                    break;

                case EnumSerializerType.Binary:
                    return s_BinarySerializer.Serialize(source);

                    break;

                case EnumSerializerType.SOAP:
                    return s_SoapSerializer.Serialize(source);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("serializerType");
            }
        }

        /// <summary>
        /// Serializes the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="outputStream">The output stream.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">serializerType</exception>
        public static byte[] Serialize<T>(this T source, Stream outputStream, EnumSerializerType serializerType = EnumSerializerType.Binary) where T : new()
        {
            byte[] serializeArray = null;
            switch (serializerType)
            {
                case EnumSerializerType.XML:
                    serializeArray = s_XmlSerializer.Serialize(source);
                    break;

                case EnumSerializerType.JSON:
                    serializeArray = s_JsonSerializer.Serialize(source);
                    break;

                case EnumSerializerType.Binary:
                    serializeArray = s_BinarySerializer.Serialize(source);

                    break;

                case EnumSerializerType.SOAP:
                    serializeArray = s_SoapSerializer.Serialize(source);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("serializerType");
            }
            outputStream.Write(serializeArray, 0, serializeArray.Length);
            return serializeArray;
        }

        /// <summary>
        /// Deserializes the specified serialize array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializeArray">The serialize array.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">serializerType</exception>
        public static T Deserialize<T>(this byte[] serializeArray, EnumSerializerType serializerType = EnumSerializerType.Binary) where T : new()
        {
            switch (serializerType)
            {
                case EnumSerializerType.XML:
                    return s_XmlSerializer.Deserialize<T>(serializeArray);
                    break;

                case EnumSerializerType.JSON:
                    return s_JsonSerializer.Deserialize<T>(serializeArray);
                    break;

                case EnumSerializerType.Binary:
                    return s_BinarySerializer.Deserialize<T>(serializeArray);
                    break;

                case EnumSerializerType.SOAP:
                    return s_SoapSerializer.Deserialize<T>(serializeArray);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("serializerType");
            }
        }

        /// <summary>
        /// Deserializes the specified input stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">serializerType</exception>
        public static T Deserialize<T>(this Stream inputStream, EnumSerializerType serializerType = EnumSerializerType.Binary) where T : new()
        {
            var memory = new MemoryStream();
            inputStream.CopyTo(memory);
            var serializeArray = memory.ToArray();
            switch (serializerType)
            {
                case EnumSerializerType.XML:
                    return s_XmlSerializer.Deserialize<T>(serializeArray);
                    break;

                case EnumSerializerType.JSON:
                    return s_JsonSerializer.Deserialize<T>(serializeArray);
                    break;

                case EnumSerializerType.Binary:
                    return s_BinarySerializer.Deserialize<T>(serializeArray);
                    break;

                case EnumSerializerType.SOAP:
                    return s_SoapSerializer.Deserialize<T>(serializeArray);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("serializerType");
            }
        }
    }
}