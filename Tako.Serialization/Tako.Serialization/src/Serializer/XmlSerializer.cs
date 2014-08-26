// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="XmlSerializer.cs" company="">
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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class XmlSerializer.
    /// </summary>
    public class XmlSerializer : SerializerBase
    {
        /// <summary>
        /// The m_pool
        /// </summary>
        private static Dictionary<Type, System.Xml.Serialization.XmlSerializer> s_pool = new Dictionary<Type, System.Xml.Serialization.XmlSerializer>();

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        public override byte[] Serialize<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            var memory = new MemoryStream();
            this.createXmlSerializer<T>().Serialize(memory, obj);
            memory.Position = 0;
            return memory.ToArray();
        }

        /// <summary>
        /// Deserializes the specified sources.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources">The sources.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        public override T Deserialize<T>(byte[] sources)
        {
            if (sources == null)
            {
                throw new ArgumentNullException("sources");
            }

            using (MemoryStream memory = new MemoryStream(sources))
            {
                object obj = this.createXmlSerializer<T>().Deserialize(memory);
                return (T)obj;
            }
        }

        /// <summary>
        /// Creates the XML serializer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.Xml.Serialization.XmlSerializer.</returns>
        private System.Xml.Serialization.XmlSerializer createXmlSerializer<T>()
        {
            Type t = typeof(T);
            if (!s_pool.ContainsKey(t))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(t);
                s_pool.Add(t, serializer);
                return serializer;
            }
            return s_pool[t];
        }
    }
}