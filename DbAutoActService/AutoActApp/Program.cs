using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutoActApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"d:\OrdersData");
            FSNotifier fsn = new FSNotifier();
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.csv";
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = ((System.IO.NotifyFilters)((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)));
            watcher.Created += fsn.FileSystemWatcher_Created;

            Console.ReadLine();

            watcher.Created -= fsn.FileSystemWatcher_Created;
        }
    }

    class FSNotifier
    {

        public void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            //DAL.IRepository<DAL.Models.Client> clientRepository = new DAL.ClientRepository();
            //DAL.IRepository<DAL.Models.Manager> managerRepository = new DAL.ManagerRepository();
            //DAL.IRepository<DAL.Models.Goods> goodsRepository = new DAL.GoodsRepository();
            //DAL.IRepository<DAL.Models.Sales> salesRepository = new DAL.SalesRepository();

            using (StreamWriter sw = new StreamWriter(new FileStream("log.txt", FileMode.Append)))
            {
                sw.WriteLine("File {0} Created at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }

            //Console.WriteLine(e.FullPath);

            var managerSecondName = e.Name.Split(new char[] { '_' })[0];

            var man = managerRepository.Items.FirstOrDefault(x => x.SecondName == managerSecondName);
            if (man == null)
            {
                Console.WriteLine("Manager with second name {0} does not exist, sales data not imported.", managerSecondName);
                return;
            }

            DbAutoActService.CsvParser csvParser = new DbAutoActService.CsvParser(e.FullPath, new char[] { ';' });

            var rows = csvParser.GetRecords().Select(r => new DbAutoActService.ImportedDataRow() { Date = DateTime.Parse(r[0]), Client = r[1], Goods = r[2], Total = double.Parse(r[3]) });

            Console.WriteLine("Imported DataRpws :");
            foreach (var r in rows)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}", r.Date, r.Client, r.Goods, r.Total);
            }
            Console.WriteLine();

            int count = rows.Count();
            using (StreamWriter sw = new StreamWriter(new FileStream("log.txt", FileMode.Append)))
            {
                sw.WriteLine("Imported {0} records", count);
            }

            foreach (var r in rows)
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
                    Manager = man,
                    Client = clientRepository.Items.FirstOrDefault(x => x.Name == r.Client),
                    Goodds = goodsRepository.Items.FirstOrDefault(x => x.Name == r.Goods),
                    Cost = r.Total
                });
                salesRepository.SaveChanges();
            }
        }

    }
}
