using System;
using System.Collections;
using System.Collections.Generic;

namespace AggregateRoot.Core.Extensions
{
    public static class CollectionExtension
    {
        public static IReadOnlyList<T> AsReadOnly<T>(this IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            return list as IReadOnlyList<T> ?? new ReadOnlyWrapper<T>(list);
        }

        private sealed class ReadOnlyWrapper<T> : IReadOnlyList<T>
        {
            private readonly IList<T> _list;

            public ReadOnlyWrapper(IList<T> list) => _list = list;

            public int Count => _list.Count;

            public T this[int index] => _list[index];

            public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
