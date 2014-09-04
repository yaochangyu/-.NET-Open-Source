// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-26-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="SortableBindingList.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class SortableBindingList.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortableBindingList<T> : BindingList<T>
    {
        /// <summary>
        /// The _comparer list
        /// </summary>
        private readonly Dictionary<string, PropertyComparer<T>> _comparerList = new Dictionary<string, PropertyComparer<T>>();

        /// <summary>
        /// The _sort direction
        /// </summary>
        private ListSortDirection _sortDirection;

        /// <summary>
        /// The _property
        /// </summary>
        private PropertyDescriptor _property;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        public SortableBindingList()
            : base(new List<T>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        /// <param name="List">The list.</param>
        public SortableBindingList(IList<T> List)
            : base(List)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        /// <param name="Enumerable">The enumerable.</param>
        public SortableBindingList(IEnumerable<T> Enumerable)
            : base(new List<T>(Enumerable))
        {
        }

        /// <summary>
        /// Gets a value indicating whether [supports sorting core].
        /// </summary>
        /// <value><c>true</c> if [supports sorting core]; otherwise, <c>false</c>.</value>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is sorted core.
        /// </summary>
        /// <value><c>true</c> if this instance is sorted core; otherwise, <c>false</c>.</value>
        protected override bool IsSortedCore
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the sort property core.
        /// </summary>
        /// <value>The sort property core.</value>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this._property; }
        }

        /// <summary>
        /// Gets the sort direction core.
        /// </summary>
        /// <value>The sort direction core.</value>
        protected override ListSortDirection SortDirectionCore
        {
            get { return this._sortDirection; }
        }

        //protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection sortDirection)
        //{
        //    List<T> list = (List<T>)this.Items;
        //    var name = property.Name;
        //    PropertyComparer<T> comparer;

        //    if (!this._comparerList.TryGetValue(name, out comparer))
        //    {
        //        comparer = new PropertyComparer<T>(property, sortDirection);
        //        this._comparerList.Add(name, comparer);
        //    }

        //    comparer.SetDirection(sortDirection);
        //    list.Sort(comparer);

        //    this._property = property;
        //    this._sortDirection = sortDirection;
        //    this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        //}

        /// <summary>
        /// Applies the sort core.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="direction">The direction.</param>
        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)this.Items;
            if (property.PropertyType.GetInterface("IComparable") != null)
            {
                itemsList.Sort((x, y) =>
                {
                    if (property.GetValue(x) != null)
                        return ((IComparable)property.GetValue(x)).CompareTo(property.GetValue(y)) *
                               (direction == ListSortDirection.Descending ? -1 : 1);
                    else if (property.GetValue(y) != null)
                        return ((IComparable)property.GetValue(y)).CompareTo(property.GetValue(x)) *
                               (direction == ListSortDirection.Descending ? 1 : -1);
                    else
                        return 0;
                });
            }
            this._property = property;
            this._sortDirection = direction;
        }
    }
}