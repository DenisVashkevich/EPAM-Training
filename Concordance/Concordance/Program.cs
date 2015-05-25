using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
 

namespace Concordance
{
    class Program
    {
        static void Main(string[] args)
        {
            const int StringsInPage = 60;

            string fp = "d:\\test.txt";
            Concordance wwords = new Concordance();
            try
            {
                using (StreamReader sr = new StreamReader(fp))
                {
                    int stringCounter = 0;
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        stringCounter++;
                        string[] sar = s.Split(new char[] { ' ', ',', '.', ':', '!', ';', '\t' });
                        foreach (string ss in sar)
                        {
                            if (ss.Trim() != "")
                                wwords.Add(ss.ToLower(), ((stringCounter / StringsInPage)+1));
                        }
                    }
                }
            }
            catch(FileNotFoundException ex) 
            { 
            }

            wwords.SaveReportToFile(@"D:\\testreport.txt");
            Console.ReadLine();
        }
    }
}
