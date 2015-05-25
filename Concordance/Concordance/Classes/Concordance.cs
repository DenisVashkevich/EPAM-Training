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
            private int[] pages = new int[100];

            public int[] Pages { get { return pages; } }

            public ValueClass(int page)
            {
                this.count = 1;
                this.AddPage(page);
            }

            public void AddPage(int page)
            {
                if ((page != 0) && !pages.Contains(page)) 
                    this.pages[1] = page;
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
                words.Add(wrd, new ValueClass(1));
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

                        sw.WriteLine("{0}  {1}  {2}", w.Key, w.Value.count, w.Value.Pages[1]);
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
