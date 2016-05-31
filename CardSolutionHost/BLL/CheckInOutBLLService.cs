using System.Collections.Generic;
using System;
using System.ServiceModel;
using BLL_Service.MenJin;
namespace CardSystem_Service.BLL.MenJin
{
    public class CheckInOutBLLService : ICheckInOutBLLService
    {
        CheckInOutBLL bll = new CheckInOutBLL();
        public Model_Service.MenJin.CheckInOut GetModel(int UserId, DateTime CheckTime)
        {
            return bll.GetModel(UserId, CheckTime);
        }

        public IList<Model_Service.MenJin.CheckInOut> GetList(string where)
        {
            return bll.GetList(where);
        }

        public int Delete(int UserId, DateTime CheckTime)
        {
            return bll.Delete(UserId, CheckTime);
        }

        public void Update(Model_Service.MenJin.CheckInOut model)
        {
            bll.Update(model);
        }

        public Model_Service.MenJin.CheckInOutId Add(Model_Service.MenJin.CheckInOut model)
        {
            return (Model_Service.MenJin.CheckInOutId)bll.Add(model);
        }

        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }
    }
    [ServiceContract]
    public interface ICheckInOutBLLService
    {
        [OperationContract]
        System.Data.DataSet GetData(string where);

        [OperationContract]
        Model_Service.MenJin.CheckInOut GetModel(int UserId, System.DateTime CheckTime);

        [OperationContract]
        IList<Model_Service.MenJin.CheckInOut> GetList(string where);

        [OperationContract]
        void Update(Model_Service.MenJin.CheckInOut model);

        [OperationContract]
        Model_Service.MenJin.CheckInOutId Add(Model_Service.MenJin.CheckInOut model);

        [OperationContract]
        int Delete(int UserId, System.DateTime CheckTime);
    }
}
