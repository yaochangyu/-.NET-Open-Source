using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tako.Collections.Generic
{
    public class PropertyComparer<T> : IComparer<T>
    {
        private IComparer _comparer;
        private PropertyDescriptor _property;
        private ListSortDirection _sortDirection;

        public PropertyComparer(PropertyDescriptor property, ListSortDirection sortDirection)
        {
            this._property = property;
            this._sortDirection = sortDirection;

            Type type = typeof(Comparer<>).MakeGenericType(property.PropertyType);

            this._comparer = (IComparer)type.InvokeMember("Default",
                                                        BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public,
                                                        null,
                                                        null,
                                                        null);
        }

        public int Compare(T x, T y)
        {
            var reverse = this._sortDirection == ListSortDirection.Ascending ? 1 : -1;
            return reverse * this._comparer.Compare(this._property.GetValue(x), this._property.GetValue(y));
        }

        public void SetPropertyAndSortDirection(PropertyDescriptor property, ListSortDirection sortDirection)
        {
            this._property = property;
            this._sortDirection = sortDirection;
        }
    }
}