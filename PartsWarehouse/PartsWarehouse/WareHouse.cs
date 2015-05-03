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
            get { return Parts.IsReadOnly;}
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

        public void SortByStock()
        {
            this.Sort(new PartsCompareByStock());
        }

        public void SortByDateStockModified()
        {
            this.Sort(new PartsCompareByStockModified());
        }

        private Part GetPartByPN(uint partnum)
        {

            foreach (var p in Parts)
            {
                if (p.PartNumber == partnum)
                {
                    return p;
                }
            }
            return null;
        }

        uint pn;

        private bool FindByPN(Part prt)
        {

            if (prt.PartNumber == pn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StockAdd(uint partnum, int num)
        {
            pn = partnum;
            var newList = Parts.ToList();
            int ind = newList.FindIndex(FindByPN);
            if (ind >= 0)
            {
                newList[ind].StockAdd(num);
                Parts = newList;
                return true;
            }
            else return false;
        }

        public bool StockRemove(uint partnum, int num)
        {
            pn = partnum;
            var newList = Parts.ToList();
            int ind = newList.FindIndex(FindByPN);

            if (ind >= 0)
            {
                try
                {
                    newList[ind].StockRemove(num);
                    Parts = newList;
                    return true;
                }
                catch (OutOfStockException ex)
                {
                    return false;
                }
            }
            else return false;
        }
    }
}
