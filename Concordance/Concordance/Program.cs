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
            const int StringsInPage = 30;
            string fp = "2001SpaceOdyssey.txt";
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
                        string[] splittedString = s.Split(new char[] { '_','–','-','(',')','+','$','/','?','"',' ','\'', ',', '.', ':', '!', ';', '\t', '@',
                                                                       '°','{','}','<','>','^','#','*','1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
                        foreach (string ss in splittedString)
                        {
                            if (ss.Trim() != "")
                                words.Add(ss.ToLower(), (int)(stringCounter / StringsInPage)+1);
                        }
                    }
                }
            }
            catch(FileNotFoundException ex) 
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            words.SaveReportToFile("report.txt");
        }
    }
}
