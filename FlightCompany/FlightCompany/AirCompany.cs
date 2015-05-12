using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FlightCompany
{
    
    public class AirCompany : ICollection<IPlane>
    {
        ICollection<IPlane> AirPlanes = new List<IPlane>();

        #region ICollection<IPlane>
        public void Add(IPlane item)
        {
            AirPlanes.Add(item);
        }

        public void Clear()
        {
            AirPlanes.Clear();
        }

        public bool Contains(IPlane item)
        {
            return AirPlanes.Contains(item);
        }

        public void CopyTo(IPlane[] array, int arrayIndex)
        {
            AirPlanes.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return AirPlanes.Count; }
        }

        public bool IsReadOnly
        {
            get { return AirPlanes.IsReadOnly; }
        }

        public bool Remove(IPlane item)
        {
            return AirPlanes.Remove(item);
        }

        public IEnumerator<IPlane> GetEnumerator()
        {
            return AirPlanes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        public void SaveToFile()
        {
            IFormatter formatter = new BinaryFormatter();

            FileStream fs = new FileStream("Aircompany.bin", FileMode.OpenOrCreate);
            formatter.Serialize(fs, AirPlanes);
            fs.Close();
        }

        public void LoadFromfile() 
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("Aircompany.bin", FileMode.Open);
            AirPlanes = (ICollection<IPlane>)formatter.Deserialize(fs);
            fs.Close();
        }

        public void DisplayAllPlanes()
        {
            
        }
    }
}
