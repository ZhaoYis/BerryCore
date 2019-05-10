using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace BerryCore.WCF.Service
{
    [RunInstaller(true)]
    public partial class BerryCoreWCFProjectInstaller : System.Configuration.Install.Installer
    {
        public BerryCoreWCFProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
