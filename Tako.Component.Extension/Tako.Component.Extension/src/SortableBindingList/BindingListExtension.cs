using System.Collections.Generic;

namespace Tako.Component.Extension
{
    public static class BindingListExtension
    {
        public static SortableBindingList<T> AsBindingList<T>(this T source) where T : IEnumerable<T>
        {
            SortableBindingList<T> list = new SortableBindingList<T>(source);
            return list;
        }
    }
}