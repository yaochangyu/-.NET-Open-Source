// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-26-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="PropertyComparer.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class PropertyComparer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyComparer<T> : IComparer<T>
    {
        /// <summary>
        /// The _comparer
        /// </summary>
        private IComparer _comparer;

        /// <summary>
        /// The _property
        /// </summary>
        private PropertyDescriptor _property;

        /// <summary>
        /// The _sort direction
        /// </summary>
        private ListSortDirection _sortDirection;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyComparer{T}"/> class.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="sortDirection">The sort direction.</param>
        public PropertyComparer(PropertyDescriptor property, ListSortDirection sortDirection)
        {
            this._property = property;
            this._sortDirection = sortDirection;

            //Type comparerPropertyType = typeof(Comparer<>).MakeGenericType(property.PropertyType);

            //this._comparer = (IComparer)comparerPropertyType.InvokeMember("Default",
            //                                            BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public,
            //                                            null,
            //                                            null,
            //                                            null);
            this._comparer = Comparer.Default;
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.</returns>
        public int Compare(T x, T y)
        {
            var reverse = this._sortDirection == ListSortDirection.Ascending ? 1 : -1;
            return reverse * this._comparer.Compare(this._property.GetValue(x), this._property.GetValue(y));
        }

        /// <summary>
        /// Sets the direction.
        /// </summary>
        /// <param name="sortDirection">The sort direction.</param>
        public void SetDirection(ListSortDirection sortDirection)
        {
            this._sortDirection = sortDirection;
        }
    }
}