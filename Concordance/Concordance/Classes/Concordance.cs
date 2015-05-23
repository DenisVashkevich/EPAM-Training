using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void DisplayWords()
        {
            var wrds = from ww in words orderby ww.Key ascending select ww;
            foreach (KeyValuePair<string, int> w in wrds)
            {
                Console.WriteLine(w.Key + "   " + w.Value.ToString());
            }
        }
    }
}
