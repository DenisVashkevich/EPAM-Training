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
            const int StringsInPage = 3;

            string fp = "d:\\The Hunger Games.txt";
            Concordance words = new Concordance();
            try
            {
                using (StreamReader sr = new StreamReader(fp))
                {
                    int stringCounter = 0;
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        stringCounter++;
                        string[] sar = s.Split(new char[] { '-','(',')','+','$','/','?','"',' ', ',', '.', ':', '!', ';', '\t', 
                                                            '{','}','1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
                        foreach (string ss in sar)
                        {
                            if (ss.Trim() != "")
                                words.Add(ss.ToLower(), ((stringCounter / StringsInPage)));
                        }
                    }
                }
            }
            catch(FileNotFoundException ex) 
            {
                Console.WriteLine("{0}",ex.Message);
                Console.ReadLine();
            }

            words.SaveReportToFile("D:\\testreport.txt");
        }
    }
}
