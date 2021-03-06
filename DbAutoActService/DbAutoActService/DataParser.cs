﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace DbAutoActService
{
    public abstract class DataParser
    {
        protected char[] Delimiter { get; set; } //ConfigurationManager.AppSettings["FieldSeparator"].ToCharArray();
        protected Stream Source { get; set; }

        public DataParser(char[] delimiter)
        {
            Delimiter = delimiter;
        }

        public IEnumerable<string[]> GetRecords()
        {
            this.Source = GetStream();
            using (StreamReader reader = new StreamReader(Source))
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine().Split(Delimiter, StringSplitOptions.None);
                }
            }

        }

        protected abstract Stream GetStream();
    }
}
