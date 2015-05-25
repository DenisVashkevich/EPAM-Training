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
            string fp = "d:\\test.txt";
            Concordance wwords = new Concordance();
            try
            {
                using (StreamReader sr = new StreamReader(fp))
                {
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        string[] sar = s.Split(new char[] { ' ', ',', '.', ':', '!', ';', '\t' });
                        foreach (string ss in sar)
                        {
                            if (ss.Trim() != "")
                                wwords.Add(ss.ToLower());
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
