using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace AutoActApp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(ConfigurationManager.AppSettings["WatchPath"]);
            FSNotifier fsn = new FSNotifier(ConfigurationManager.AppSettings["Delimiter"].ToCharArray());
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
        public BL.DataProcessor dataProcessor;

        public FSNotifier(char[] delimiter)
        {
            dataProcessor = new BL.DataProcessor(delimiter);
        }

        public void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogPath"], FileMode.Append)))
            {
                sw.WriteLine("File {0} Created at " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), e.Name);
            }

            dataProcessor.StartProcessing(e.FullPath);
        }

    }
}
