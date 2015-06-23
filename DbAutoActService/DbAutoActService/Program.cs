using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Reflection;

namespace DbAutoActService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            { 
                new DbAutoActualizationService() 
            };

            if(Environment.UserInteractive)
            {
                Type type = typeof(ServiceBase);
                BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
                MethodInfo method = type.GetMethod("OnStart", flags);
                foreach (ServiceBase service in ServicesToRun)
                {
                    method.Invoke(service, new object[] { args });
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
                MethodInfo methodStop = type.GetMethod("OnStop", flags);
                foreach (ServiceBase service in ServicesToRun)
                {
                methodStop.Invoke(service, null);
                }
            }
            else ServiceBase.Run(ServicesToRun); 
        }
    }
}
