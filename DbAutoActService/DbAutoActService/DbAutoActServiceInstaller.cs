using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace DbAutoActService
{
    [RunInstaller(true)]
    public partial class DbAutoActServiceInstaller : System.Configuration.Install.Installer
    {
        public DbAutoActServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
