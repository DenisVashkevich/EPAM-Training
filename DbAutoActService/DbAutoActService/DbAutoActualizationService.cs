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

            this.FileSystemWatcher.Created += this.FileSystemWatcher_Created;
            using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
            {
                sw.WriteLine("DbAutoActualizationService started at "+ DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                sw.WriteLine("Directory watched : " + FileSystemWatcher.Path);
            }
        }

        protected override void OnStop()
        {
            this.FileSystemWatcher.Created -= this.FileSystemWatcher_Created;

            using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
            {
                sw.WriteLine("DbAutoActualizationService is stoped at " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            }
        }

        private void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
            {
                sw.WriteLine("File {0} Created at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }



        }
    }
}
