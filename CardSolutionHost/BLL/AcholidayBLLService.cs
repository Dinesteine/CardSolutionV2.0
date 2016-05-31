using System.Collections.Generic;
using System.ServiceModel;
using BLL_Service.MenJin;
namespace CardSystem_Service.BLL.MenJin
{
    public class AcholidayBLLService : IAcholidayBLLService
    {
        private readonly AcholidayBLL bll = new AcholidayBLL();
        public Model_Service.MenJin.Acholiday GetModel(int primaryid)
        {
            return bll.GetModel(primaryid);
        }

        public IList<Model_Service.MenJin.Acholiday> GetList(string where)
        {
            return bll.GetList(where);
        }

        public void Update(Model_Service.MenJin.Acholiday model)
        {
            bll.Update(model);
        }

        public int Add(Model_Service.MenJin.Acholiday model)
        {
            return (int)bll.Add(model);
        }

        public int Delete(int Id)
        {
            return bll.Delete(Id);
        }
        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }
        public IList<Model_Service.MenJin.Acholiday> GetInStatusList(System.DateTime dateTime)
        {
            return bll.GetInStatusList(dateTime);
        }
    }
    [ServiceContract]
    public interface IAcholidayBLLService
    {
        [OperationContract]
        System.Data.DataSet GetData(string where);

        [OperationContract]
        Model_Service.MenJin.Acholiday GetModel(int primaryid);

        [OperationContract]
        IList<Model_Service.MenJin.Acholiday> GetList(string where);

        [OperationContract]
        void Update(Model_Service.MenJin.Acholiday model);

        [OperationContract]
        int Add(Model_Service.MenJin.Acholiday model);

        int Delete(int primaryid);

        IList<Model_Service.MenJin.Acholiday> GetInStatusList(System.DateTime dateTime);
    }
}
