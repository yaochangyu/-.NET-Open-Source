using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tako.Collections.Generic
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private readonly Dictionary<Type, PropertyComparer<T>> _comparerList = new Dictionary<Type, PropertyComparer<T>>();
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _property;

        public SortableBindingList()
            : base(new List<T>())
        {
        }

        public SortableBindingList(IList<T> List)
            : base(List)
        {
        }

        public SortableBindingList(IEnumerable<T> Enumerable)
            : base(new List<T>(Enumerable))
        {
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return true; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this._property; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return this._sortDirection; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> list = (List<T>)this.Items;

            Type propertyType = property.PropertyType;
            PropertyComparer<T> comparer;

            if (!this._comparerList.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<T>(property, direction);
                this._comparerList.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndSortDirection(property, direction);
            list.Sort(comparer);

            this._property = property;
            this._sortDirection = direction;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }
}