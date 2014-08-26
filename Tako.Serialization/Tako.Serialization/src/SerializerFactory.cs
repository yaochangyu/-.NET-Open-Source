// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="SerializerFactory.cs" company="">
//     Copyright (c) .余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Serialization namespace.
/// </summary>
namespace Tako.Serialization
{
    /// <summary>
    /// Class SerializerFactory.
    /// </summary>
    public class SerializerFactory
    {
        /// <summary>
        /// Creates the serializer.
        /// </summary>
        /// <param name="serializerType">The mode.</param>
        /// <returns>SerializerBase.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Mode</exception>
        public virtual ISerializer CreateSerializer(EnumSerializerType serializerType)
        {
            ISerializer serializerBase = null;
            switch (serializerType)
            {
                case EnumSerializerType.XML:
                    serializerBase = new XmlSerializer();
                    break;

                case EnumSerializerType.JSON:
                    serializerBase = new JsonSerializer();
                    break;

                case EnumSerializerType.Binary:
                    serializerBase = new BinarySerializer();
                    break;

                case EnumSerializerType.SOAP:
                    serializerBase = new SoapSerializer();
                    break;
            }
            return serializerBase;
        }
    }
}