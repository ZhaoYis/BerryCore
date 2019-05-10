using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BerryCore.Extensions;
using BerryCore.Log;
using BerryCore.WCF.BaseBehavior;
using BerryCore.WCF.BaseBehavior.MessageInspector;
using BerryCore.WCF.DataContract;

namespace BerryCore.WCF.Service
{
    /// <summary>
    /// wcf服务帮助类
    /// </summary>
    public class OpenWcfServiceHelper : CustomConsole
    {
        /// <summary>
        /// 服务列表
        /// </summary>
        private static List<ServiceHost> serviceHosts = new List<ServiceHost>();

        /// <summary>
        /// 开启WCF服务
        /// </summary>
        public void InitWcfService(List<WcfServiceCanRunMember> canRunMembers)
        {
            string serviceAddress = "http://127.0.0.1:4421";

            foreach (WcfServiceCanRunMember item in canRunMembers)
            {
                string serviceName = item.ServiceBehavior.Name;
                Uri baseAddress = new Uri(string.Format("{0}/{1}", serviceAddress, serviceName));

                //ServiceHost
                ServiceHost serviceHost = new ServiceHost(item.ServiceBehavior, baseAddress);
                //// 设置自定义验证器
                //serviceHost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
                //serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustomUserNamePasswordValidator();
                //// 设置证书
                //serviceHost.Credentials.ServiceCertificate.SetCertificate("CN=WCFCert", StoreLocation.LocalMachine, StoreName.My);

                //BasicHttpBinding
                //this.BasicHttpBinding(serviceHost, item.ServiceContract, baseAddress);

                //WSHttpBinding
                //this.WSHttpBinding(serviceHost, item.ServiceContract, baseAddress);

                if (item.CanHttp)
                {
                    //WebHttpBinding
                    this.WebHttpBinding(serviceHost, item.ServiceContract, baseAddress);
                }

                //把自定义的IEndPointBehavior插入到终结点中
                foreach (ServiceEndpoint endpoint in serviceHost.Description.Endpoints)
                {
                    endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());
                }

                //启动服务监听
                this.StartMonitor(serviceHost, baseAddress, item.Name);
            }
        }

        /// <summary>
        /// 启动服务监听
        /// </summary>
        private void StartMonitor(ServiceHost serviceHost, Uri baseAddress, string serverName)
        {
            serviceHost.Opened += delegate
            {
                StringBuilder builder = new StringBuilder(string.Format("\r\n【{0}】已启动,服务地址：{1}", serverName, string.Format("{0}", baseAddress.AbsoluteUri)));
                foreach (ServiceEndpoint se in serviceHost.Description.Endpoints)
                {
                    string msg = string.Format("\r\n[终结点]: {0}\r\n\t [A-地址]: {1} \r\n\t [B-绑定]: {2} \r\n\t [C-协定]: {3}",
                        se.Name, se.Address, se.Binding.Name, se.Contract.Name);
                    builder.Append(msg);
                }
                this.WriteInfo(this.GetType(), builder.ToString());
            };
            serviceHost.Closing += delegate
            {
                this.WriteInfo(this.GetType(), "serviceHost.Closing");
            };
            serviceHost.Closed += delegate
            {
                this.WriteInfo(this.GetType(), "serviceHost.Closed");
            };

            serviceHost.Faulted += delegate
            {
                this.WriteInfo(this.GetType(), "serviceHost.Faulted");
            };

            serviceHost.Open(TimeSpan.FromSeconds(30));
            serviceHosts.Add(serviceHost);
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public void CloseService()
        {
            foreach (ServiceHost t in serviceHosts)
            {
                if (t.State == CommunicationState.Opened)
                {
                    t.Close();
                }
            }
        }

        /// <summary>
        /// BasicHttpBinding
        /// </summary>
        private void BasicHttpBinding(ServiceHost serviceHost, Type serviceContract, Uri baseAddress)
        {
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                ReceiveTimeout = TimeSpan.FromSeconds(30),
                SendTimeout = TimeSpan.FromSeconds(30),
                MaxReceivedMessageSize = int.MaxValue,
                //Security = new BasicHttpSecurity
                //{
                //    Mode = BasicHttpSecurityMode.Message,
                //    Message = new BasicHttpMessageSecurity
                //    {
                //        ClientCredentialType = BasicHttpMessageCredentialType.UserName
                //    },
                //    Transport = new HttpTransportSecurity
                //    {
                //        ClientCredentialType = HttpClientCredentialType.Windows
                //    }
                //}
            };
            serviceHost.AddServiceEndpoint(serviceContract, basicHttpBinding, baseAddress + "/basic");
            ServiceMetadataBehavior behavior = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            {
                if (behavior == null)
                {
                    behavior = new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true,
                        HttpGetUrl = baseAddress
                    };
                    serviceHost.Description.Behaviors.Add(behavior);
                }
                else
                {
                    behavior.HttpGetEnabled = true;
                }
            }
            //定义mex终结点
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
        }

        /// <summary>
        /// WebHttpBinding
        /// </summary>
        private void WebHttpBinding(ServiceHost serviceHost, Type serviceContract, Uri baseAddress)
        {
            WebHttpBinding webHttpBinding = new WebHttpBinding(WebHttpSecurityMode.None)
            {
                ReceiveTimeout = TimeSpan.FromSeconds(30),
                SendTimeout = TimeSpan.FromSeconds(30),
                MaxReceivedMessageSize = int.MaxValue,
                MaxBufferPoolSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                Security = new WebHttpSecurity()
                {
                    Mode = WebHttpSecurityMode.None
                },
                ContentTypeMapper = new JsonContentTypeMapper()
            };
            ServiceEndpoint endpoint = serviceHost.AddServiceEndpoint(serviceContract, webHttpBinding, baseAddress + "/web");
            endpoint.Behaviors.Add(new WebHttpBehavior());
        }

        /// <summary>
        /// WSHttpBinding
        /// </summary>
        private void WSHttpBinding(ServiceHost serviceHost, Type serviceContract, Uri baseAddress)
        {
            WSHttpBinding wsHttpBinding = new WSHttpBinding();
            serviceHost.AddServiceEndpoint(serviceContract, wsHttpBinding, baseAddress + "/ws");
        }

        /// <summary>
        /// 从配置文件中加载服务项目
        /// </summary>
        /// <returns></returns>
        public List<WcfServiceCanRunMember> GetServiceTypes()
        {
            List<WcfServiceCanRunMember> canRunMembers = new List<WcfServiceCanRunMember>();
            List<WcfServiceConfigEntity> config = this.InitServiceConfig();
            if (config.Count > 0)
            {
                //过滤掉不开启的服务
                config = config.Where(c => c.Enabled == "1").ToList();
                foreach (WcfServiceConfigEntity entity in config)
                {
                    if (!string.IsNullOrEmpty(entity.ServiceBehaviorNamespace) &&
                        !string.IsNullOrEmpty(entity.ServiceContractNamespace))
                    {
                        Type serviceBehaviorType = Type.GetType(entity.ServiceBehaviorNamespace, true, true);
                        Type serviceContractType = Type.GetType(entity.ServiceContractNamespace, true, true);
                        canRunMembers.Add(new WcfServiceCanRunMember
                        {
                            Name = entity.Name,
                            ServiceContract = serviceContractType,
                            ServiceBehavior = serviceBehaviorType,
                            CanHttp = entity.CanHttp == "1"
                        });
                    }
                }
            }
            return canRunMembers;
        }

        /// <summary>
        /// 初始化服务配置文件
        /// </summary>
        /// <returns></returns>
        private List<WcfServiceConfigEntity> InitServiceConfig()
        {
            List<WcfServiceConfigEntity> res = new List<WcfServiceConfigEntity>();
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "XmlConfig\\WcfServiceConfig.xml";
            if (File.Exists(filePath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                res = doc.ConvertXmlToObject<WcfServiceConfigEntity>("BerryCoreWcfServiceSettings");
            }
            return res;
        }
    }
}