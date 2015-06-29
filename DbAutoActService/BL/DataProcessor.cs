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
        private object syncObj = new object();

        public Task StartProcessing(string filePath, char[] delimiter)
        {
            Task task = new Task()
            task.Start();
            return task;
        }

        private void ProcessingTask(string filePath, char[] delimiter)
        {
            CsvParser csvParser = new CsvParser(FilePath, Delimiter);

            DAL.IRepository<DAL.Models.Client> clientRepository = new DAL.ClientRepository();
            DAL.IRepository<DAL.Models.Manager> managerRepository = new DAL.ManagerRepository();
            DAL.IRepository<DAL.Models.Goods> goodsRepository = new DAL.GoodsRepository();
            DAL.IRepository<DAL.Models.Sales> salesRepository = new DAL.SalesRepository();

            var managerSecondName = Path.GetFileName(FilePath).Split(new char[] { '_' })[0];
            var manager = managerRepository.Items.FirstOrDefault(x => x.SecondName == managerSecondName);
            if (manager == null)
            {
                return;
            }

            var rows = csvParser.GetRecords().Select(r => new ImportedDataRow() { Date = DateTime.Parse(r[0]), Client = r[1], Goods = r[2], Total = double.Parse(r[3]) });

            foreach (var r in rows)
            {
                lock (syncObj)
                {
                    var c = clientRepository.Items.FirstOrDefault(x => x.Name == r.Client);
                    var g = goodsRepository.Items.FirstOrDefault(x => x.Name == r.Goods);
                    if (c == null)
                    {
                        clientRepository.Add(new DAL.Models.Client() { Name = r.Client });
                        clientRepository.SaveChanges();
                    }

                    if (g == null)
                    {
                        goodsRepository.Add(new DAL.Models.Goods() { Name = r.Goods });
                        goodsRepository.SaveChanges();
                    }

                    salesRepository.Add(new DAL.Models.Sales()
                    {
                        Date = r.Date,
                        Manager = manager,
                        Client = clientRepository.Items.FirstOrDefault(x => x.Name == r.Client),
                        Goodds = goodsRepository.Items.FirstOrDefault(x => x.Name == r.Goods),
                        Cost = r.Total
                    });
                    salesRepository.SaveChanges();
                }
            }
        }
    }
}
