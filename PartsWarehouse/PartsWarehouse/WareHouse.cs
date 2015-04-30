using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class WareHouse:ICollection<Part>
    {

        private ICollection<Part> Parts = new List<Part>();

        #region ICollection<Parts>
        public void Add(Part item)
        {
            Parts.Add(item);
        }

        public void Clear()
        {
            Parts.Clear();
        }

        public bool Contains(Part item)
        {
            return Parts.Contains(item);
        }

        public void CopyTo(Part[] array, int arrayIndex)
        {
            Parts.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Parts.Count; }
        }

        public bool IsReadOnly
        {
            get { return Parts.IsReadOnly; }
        }

        public bool Remove(Part item)
        {
            return Parts.Remove(item);
        }

        public IEnumerator<Part> GetEnumerator()
        {
            return Parts.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion ICollection<Parts>


        protected void Sort(IComparer<Part> Comparer)
        {
            var sortedPartList = Parts.ToList();
            sortedPartList.Sort(Comparer);
            Parts = sortedPartList;
        }

    }
}
