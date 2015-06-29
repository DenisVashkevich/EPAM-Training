using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace DbAutoActService
{
    public class DataProcessor
    {
        private string FilePath { get; set; }
        private char[] Delimiter { get; set; }

        public DataProcessor(string filePath, char[] delimiter)
        {
            this.FilePath = filePath;
            this.Delimiter = delimiter;
        }

        public Task StartProcessing()
        {
            Task task = new Task(ProcessingTask);
            task.Start();
            return task;
        }

        private void ProcessingTask()
        {
            FileStream stream = new FileStream(FilePath, FileMode.Open);
            CsvParser csvParser = new CsvParser(FilePath, Delimiter);

            DAL.IRepository<DAL.Models.Client> clientRepository = new DAL.ClientRepository();
            DAL.IRepository<DAL.Models.Manager> managerRepository = new DAL.ManagerRepository();
            DAL.IRepository<DAL.Models.Goods> goodsRepository = new DAL.GoodsRepository();
            DAL.IRepository<DAL.Models.Sales> salesRepository = new DAL.SalesRepository();

            var rows = csvParser.GetRecords().Select(r => new ImportedDataRow() { Date = DateTime.Parse(r[0]), Client = r[1], Goods = r[2], Total = double.Parse(r[3]) });

        }
    }
}
