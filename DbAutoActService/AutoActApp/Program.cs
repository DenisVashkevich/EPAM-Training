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
            watcher.Changed += fsn.FileSystemWatcher_Changed;
            watcher.Created += fsn.FileSystemWatcher_Created;
            watcher.Deleted += fsn.FileSystemWatcher_Deleted;
            watcher.Renamed += fsn.FileSystemWatcher_Renamed;

            Console.ReadLine();

            watcher.Changed -= fsn.FileSystemWatcher_Changed;
            watcher.Created -= fsn.FileSystemWatcher_Created;
            watcher.Deleted -= fsn.FileSystemWatcher_Deleted;
            watcher.Renamed -= fsn.FileSystemWatcher_Renamed;
        }
    }

    class FSNotifier
    {
        public void FileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("log.txt", FileMode.Append)))
            {
                sw.WriteLine("File {0} changed at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }
        }

        public void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            DAL.IRepository<DAL.Models.Client> clientRepository = new DAL.ClientRepository();
            DAL.IRepository<DAL.Models.Manager> managerRepository = new DAL.ManagerRepository();

            using (StreamWriter sw = new StreamWriter(new FileStream("log.txt", FileMode.Append)))
            {
                sw.WriteLine("File {0} Created at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }

            //Console.WriteLine(e.FullPath);

            var managerSecondName = e.Name.Split(new char[] { '_' })[0];

            Console.WriteLine(managerSecondName);
            var man = 
            return;
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
                if (c == null)
                {
                    clientRepository.Add(new DAL.Models.Client() { Name = r.Client });
                    clientRepository.SaveChanges();
                }

            }


        }

        public void FileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("log.txt", FileMode.Append)))
            {
                sw.WriteLine("File {0} deleted at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }

        }

        public void FileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("log.txt", FileMode.Append)))
            {
                sw.WriteLine("File {0} Renamed at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }

        }
    }
}
