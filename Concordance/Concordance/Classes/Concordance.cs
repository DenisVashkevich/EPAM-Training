using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Concordance
{
    public class Concordance
    {
        private Dictionary<string, int> words = new Dictionary<string, int>();

        public void Add(string wrd)
        {
            int val;

            if(words.TryGetValue(wrd, out val))
            {
                words[wrd]++;
            }
            else
            {
                words.Add(wrd, 1);
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
                    foreach (KeyValuePair<string, int> w in wrds)
                    {
                        if (!w.Key.StartsWith(firstLetter))
                        {
                            firstLetter = w.Key.Substring(0, 1);
                            sw.WriteLine("");
                            sw.WriteLine("{0}", firstLetter.ToUpper());
                        }

                        sw.WriteLine("{0}  {1}", w.Key, w.Value);
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
