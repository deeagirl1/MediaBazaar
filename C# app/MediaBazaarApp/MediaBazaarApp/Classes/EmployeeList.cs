using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class EmployeeList : IList<ShopWorker>
    {
        readonly IList<ShopWorker> _list = new List<ShopWorker>();

        public ShopWorker this[int index] { get => _list[index]; set => _list[index] = value; }

        public int Count => _list.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public void Add(ShopWorker item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(ShopWorker item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(ShopWorker[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ShopWorker> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(ShopWorker item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, ShopWorker item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(ShopWorker item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
