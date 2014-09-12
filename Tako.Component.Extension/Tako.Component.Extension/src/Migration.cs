// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 09-04-2014
//
// Last Modified By : 余小章
// Last Modified On : 09-12-2014
// ***********************************************************************
// <copyright file="Migration.cs" company="余小章">
//     Copyright (c) 余小章. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class Migration.
    /// </summary>
    public class Migration
    {
        /// <summary>
        /// The s_ property infos
        /// </summary>
        private static Dictionary<string, List<PropertyInfo>> s_PropertyInfos = new Dictionary<string, List<PropertyInfo>>();

        //public UTarget Migrate<TSource, UTarget>(TSource source, UTarget target)
        //{
        //    if (source == null)
        //        throw new ArgumentNullException("source");
        //    if (target == null)
        //        throw new ArgumentNullException("target");

        //    List<PropertyInfo> propertyInfos = null;

        //    var sourceType = typeof(TSource);
        //    Type[] sourceInterfaceTypes = sourceType.GetInterfaces();
        //    var typeName = sourceType.FullName;

        //    if (sourceInterfaceTypes.Length != 0)
        //    {
        //        propertyInfos = GetPropertyInfos(typeName, sourceInterfaceTypes);
        //        SetPropertyValue(source, target, propertyInfos);
        //        return target;
        //    }
        //    else if (sourceType.BaseType.FullName != "System.Object")
        //    {
        //        var baseType = sourceType.BaseType;
        //        var baseTypeName = baseType.Name;
        //        propertyInfos = GetPropertyInfos(baseTypeName, baseType);
        //        SetPropertyValue(source, target, propertyInfos);
        //        return target;
        //    }
        //    else
        //    {
        //        propertyInfos = GetPropertyInfos(typeName, sourceType);
        //        SetPropertyValue(source, target, propertyInfos);
        //    }
        //    return default(UTarget);
        //}

        /// <summary>
        /// Migrates the specified type.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="UTarget">The type of the u target.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>UTarget.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// type
        /// or
        /// source
        /// or
        /// target
        /// </exception>
        public UTarget Migrate<TSource, UTarget>(Type type, TSource source, UTarget target)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (source == null)
                throw new ArgumentNullException("source");

            if (target == null)
                throw new ArgumentNullException("target");
            var typeName = type.FullName;

            var propertyInfos = GetPropertyInfos(typeName, type);
            SetPropertyValue(source, target, propertyInfos);

            return target;
        }

        /// <summary>
        /// Gets the property infos.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="interfaceTypes">The interface types.</param>
        /// <returns>List&lt;PropertyInfo&gt;.</returns>
        private List<PropertyInfo> GetPropertyInfos(string name, Type[] interfaceTypes)
        {
            var propertyInfos = new List<PropertyInfo>();
            if (!s_PropertyInfos.ContainsKey(name))
            {
                foreach (var interfaceType in interfaceTypes)
                {
                    foreach (var property in interfaceType.GetProperties())
                    {
                        propertyInfos.Add(property);
                    }
                }
                s_PropertyInfos.Add(name, propertyInfos);
            }
            else
            {
                propertyInfos = s_PropertyInfos[name];
            }
            return propertyInfos;
        }

        /// <summary>
        /// Gets the property infos.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns>List&lt;PropertyInfo&gt;.</returns>
        private List<PropertyInfo> GetPropertyInfos(string name, Type sourceType)
        {
            List<PropertyInfo> propertyInfos = null;
            if (!s_PropertyInfos.ContainsKey(name))
            {
                propertyInfos = sourceType.GetProperties().ToList();
                s_PropertyInfos.Add(name, propertyInfos);
            }
            else
            {
                propertyInfos = s_PropertyInfos[name];
            }
            return propertyInfos;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <param name="propertyInfos">The property infos.</param>
        private void SetPropertyValue<T, U>(T source, U target, List<PropertyInfo> propertyInfos)
        {
            foreach (var property in propertyInfos)
            {
                //var name = property.Name;
                var data = property.GetValue(source, null);
                property.SetValue(target, data, null);
            }
        }
    }
}