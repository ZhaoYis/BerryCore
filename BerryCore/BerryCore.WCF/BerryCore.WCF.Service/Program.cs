using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BerryCore.WCF.DataContract;

namespace BerryCore.WCF.Service
{
    class Program
    {
        /// <summary>
        /// 操作wcf服务帮助类
        /// </summary>
        private static OpenWcfServiceHelper openWcfServiceHelper = new OpenWcfServiceHelper();

        static void Main(string[] args)
        {

            Console.Title = @"BerryCore.WCF服务器";

#if !DEBUG
            ServiceBase[] servicesToRun = new ServiceBase[]
            {
                new BerryCoreWCFWinService()
            };
            ServiceBase.Run(servicesToRun);
#elif DEBUG

            //开启基础服务
            List<WcfServiceCanRunMember> canRunMembers = openWcfServiceHelper.GetServiceTypes();
            openWcfServiceHelper.InitWcfService(canRunMembers);

            Console.ReadKey();
#endif
        }
    }
}