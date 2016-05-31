using CardSolutionHost.Core;
using CardSolutionHost.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace CardSolutionHost.BLL
{
    [ServiceContract]
    public interface IMenJinControlerService
    {
        [OperationContract]
        void RunRefreshMachine();
        [OperationContract]
        void RunReloadMachine();
    }
    public class MenJinControlerService : IMenJinControlerService
    {
        public void RunRefreshMachine()
        {
            try
            {
                ServiceLoader.LoadService<IMenJinControler>().RunRefreshMachine();
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }

        public void RunReloadMachine()
        {
            try
            {
                ServiceLoader.LoadService<IMenJinControler>().RunReloadMachine();
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }
    }
}
