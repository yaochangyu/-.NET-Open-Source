// ***********************************************************************
// Assembly         : Tako.Serialization
// Author           : 余小章
// Created          : 01-23-2014
//
// Last Modified By : 余小章B
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="EnumSerializer.cs" company="">
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
    /// Enum EnumSerializer
    /// </summary>
    public enum EnumSerializerType
    {
        /// <summary>
        /// The XML
        /// </summary>
        XML,

        /// <summary>
        /// The json
        /// </summary>
        JSON,

        /// <summary>
        /// The binary
        /// </summary>
        Binary,

        /// <summary>
        /// The SOAP
        /// </summary>
        SOAP
    }
}