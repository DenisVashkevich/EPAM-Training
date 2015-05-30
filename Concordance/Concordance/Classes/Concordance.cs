using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Concordance
{
    public class Concordance
    {
        private class ValueClass
        {
            public int count;
            private List<int> pages = new List<int>();
            
            public ValueClass(int page)
            {
                this.count = 1;
                this.AddPage(page);
            }

            public void AddPage(int page)
            {
                if (!pages.Contains(page)) pages.Add(page);
            }

            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                foreach(int p in pages)
                {
                    str.Append(p.ToString());
                    str.Append(" "); 
                }
                return str.ToString().TrimEnd();
            }
        }

        private Dictionary<string, ValueClass> words = new Dictionary<string, ValueClass>();

        public void Add(string wrd, int page)
        {
            ValueClass val;

            if(words.TryGetValue(wrd, out val))
            {
                words[wrd].count++;
                words[wrd].AddPage(page);
            }
            else
            {
                words.Add(wrd, new ValueClass(page));
            }
        }

        public void AddRange()
        {

        }
        
        public void SaveReportToFile(string filePath)
        {
            string firstLetter = " ";

            var wrds = from ww in words orderby ww.Key ascending select ww;

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (KeyValuePair<string, ValueClass> w in wrds)
                    {
                        if (!w.Key.StartsWith(firstLetter))
                        {
                            firstLetter = w.Key.Substring(0, 1);
                            sw.WriteLine("{0}", firstLetter.ToUpper());
                        }
                        sw.WriteLine(new StringBuilder().Append(w.Key).ToString().PadRight(25, '.') + "{0}: {1}", w.Value.count, w.Value.ToString());
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
            }
            catch (Exception ex) 
            { 
            }
        }
    }
}
