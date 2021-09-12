using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Collection<T> : ICollection<T>
    {
        private T[] _array = Array.Empty<T>();
        private bool isReadOnly = false;

        public int Count
        {
            get
            {
                return _array.Length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                isReadOnly = value;
            }
        }

        public T this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public void Add(T value)
        {
            List<T> list = new List<T>(_array);
            list.Add(value);

            _array = list.ToArray();
        }

        public void Add(T value, int index)
        {
            T[] tempArray = new T[_array.Length + 1];
            for (int i = 0; i < _array.Length; i++)
            {
                if (i == index)
                {
                    tempArray[i] = value;
                }
                else
                {
                    tempArray[i] = _array[i];
                }
            }
            _array = tempArray;
        }

        public void Clear()
        {
            Array.Clear(_array, 0, _array.Length);
            Array.Resize(ref _array, 0);
        }

        public bool Contains(T item)
        {
            return _array.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _array.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (!_array.Contains(item))
            {
                return false;
            }
            else
            {
                int indexToRemove = Array.IndexOf(_array, item);
                _array = _array.Where((source, index) => index != indexToRemove).ToArray();
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }
    }
}
