using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

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
            XmlSerializer formatter = new XmlSerializer(typeof(AirPlane));

            using (FileStream fs = new FileStream("C:\\Temp\\Aircompany.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, AirPlanes);
            }
        }

        public void LoadFromfile() 
        {
            XmlSerializer formatter = new XmlSerializer(typeof(AirPlane));

            using(FileStream fs = new FileStream("C:\\Temp\\Aircompany.xml", FileMode.OpenOrCreate))
            {
                AirPlanes = (ICollection<IPlane>)formatter.Deserialize(fs);
            }
        }

        public void DisplayAllPlanes()
        {
        }
    }
}
