using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace DbAutoActService
{
    public partial class DbAutoActualizationService : ServiceBase
    {
        public DbAutoActualizationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            FileSystemWatcher.Path = ConfigurationManager.AppSettings["WatchPath"];

            //this.FileSystemWatcher.Changed += this.FileSystemWatcher_Changed;
            this.FileSystemWatcher.Created += this.FileSystemWatcher_Created;
            //this.FileSystemWatcher.Deleted += this.FileSystemWatcher_Deleted;
            //this.FileSystemWatcher.Renamed += this.FileSystemWatcher_Renamed;

            using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
            {
                sw.WriteLine("DbAutoActualizationService started at "+ DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                sw.WriteLine("Directory watched : " + FileSystemWatcher.Path);
            }
        }

        protected override void OnStop()
        {
            //this.FileSystemWatcher.Changed -= this.FileSystemWatcher_Changed;
            this.FileSystemWatcher.Created -= this.FileSystemWatcher_Created;
            //this.FileSystemWatcher.Deleted -= this.FileSystemWatcher_Deleted;
            //this.FileSystemWatcher.Renamed -= this.FileSystemWatcher_Renamed;

            using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
            {
                sw.WriteLine("DbAutoActualizationService is stoped at " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            }
        }

        //private void FileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        //{
        //    using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
        //    {
        //        sw.WriteLine("File {0} changed at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
        //    }
        //}

        private void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            DAL.IRepository<DAL.Models.Client> clientRepository = new DAL.ClientRepository();

            using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
            {
                sw.WriteLine("File {0} Created at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }

            FileStream stream = new FileStream(e.FullPath, FileMode.Open);
            CsvParser csvParser = new CsvParser(e.FullPath, ConfigurationManager.AppSettings["Delimiter"].ToCharArray());

            var rows = csvParser.GetRecords().Select(r => new ImportedDataRow() { Date = DateTime.Parse(r[0]), Client = r[1], Goods = r[2], Total = double.Parse(r[3]) });

            foreach (var r in rows)
            {
                var c = clientRepository.Items.FirstOrDefault(x => x.Name == r.Client);
                if (c==null)
                {
                    clientRepository.Add(new DAL.Models.Client() { Name = r.Client });
                    clientRepository.SaveChanges();
                }

            }

        }

        //private void FileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        //{
        //    using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
        //    {
        //        sw.WriteLine("File {0} deleted at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
        //    }

        //}

        //private void FileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        //{
        //    using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
        //    {
        //        sw.WriteLine("File {0} Renamed at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
        //    }

        //}

    }
}
