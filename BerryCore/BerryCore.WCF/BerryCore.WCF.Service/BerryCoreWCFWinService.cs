using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BerryCore.WCF.DataContract;

namespace BerryCore.WCF.Service
{
    partial class BerryCoreWCFWinService : ServiceBase
    {
        /// <summary>
        /// 操作wcf服务帮助类
        /// </summary>
        private static OpenWcfServiceHelper openWcfServiceHelper = new OpenWcfServiceHelper();

        public BerryCoreWCFWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。

            //开启基础服务
            List<WcfServiceCanRunMember> canRunMembers = openWcfServiceHelper.GetServiceTypes();
            openWcfServiceHelper.InitWcfService(canRunMembers);
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。

            openWcfServiceHelper.CloseService();
        }
    }
}
