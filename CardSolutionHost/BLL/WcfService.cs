using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Description;
using System;
using System.Linq;
using CardSolutionHost.Core;

namespace Host.Services
{
    public class WcfService
    {
        private ServiceHost hostZKService = null;
        public void StartHost()
        {
            try
            {
                #region 启动门禁服务
                if (hostZKService == null)
                {
                    hostZKService = new ServiceHost(typeof(CardSystem_Service.ZKManage.ZKService));
                    System.ServiceModel.Channels.Binding binding = new NetTcpBinding(SecurityMode.None);
                    string strUrl = string.Format("net.tcp://{0}:{1}/ZK/ZKService", SystemConfig.WCFServiceIpAddress, SystemConfig.WcfServicePort);
                    hostZKService.AddServiceEndpoint(typeof(CardSystem_Service.ZKManage.IZKService), binding, strUrl);
                    if (hostZKService.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                    {
                        System.ServiceModel.Channels.BindingElement elemnt = new System.ServiceModel.Channels.TcpTransportBindingElement();
                        System.ServiceModel.Channels.CustomBinding bind = new System.ServiceModel.Channels.CustomBinding(elemnt);
                        hostZKService.Description.Behaviors.Add(new System.ServiceModel.Description.ServiceMetadataBehavior());
                        hostZKService.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), bind, strUrl + "/Mex");
                    }
                }
                if (hostZKService.State != CommunicationState.Opened)
                    hostZKService.Open();
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
