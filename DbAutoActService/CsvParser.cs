using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAutoActService
{
    public class CsvParser : DataParser
    {
        public string FilePath { get; set; }

        protected override System.IO.Stream GetStream()
        {
            return new System.IO.FileStream(FilePath, System.IO.FileMode.Open);
        }

        public CsvParser(string filePath, char[] delimiter)
            : base(delimiter)
        {
            this.FilePath = filePath;
        }
    }
}
