using System.Collections.Generic;
using System.ServiceModel;
using BLL_Service.MenJin;
namespace CardSystem_Service.BLL.MenJin
{
    public class ACTimeZoneBLLService : IACTimeZoneBLLService
    {
        ACTimeZoneBLL bll = new ACTimeZoneBLL();
        public IList<Model_Service.MenJin.ACTimeZone> GetList(string where)
        {
            return bll.GetList(where);
        }

        public int Delete(short Id)
        {
            return bll.Delete(Id);
        }

        public Model_Service.MenJin.ACTimeZone GetModel(short TimeZoneID)
        {
            return bll.GetModel(TimeZoneID);
        }

        public void Update(Model_Service.MenJin.ACTimeZone model)
        {
            bll.Update(model);
        }

        public short Add(Model_Service.MenJin.ACTimeZone model)
        {
            return (short)bll.Add(model);
        }

        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }
    }
    [ServiceContract]
    public interface IACTimeZoneBLLService
    {
        [OperationContract]
        System.Data.DataSet GetData(string where);

        [OperationContract]
        IList<Model_Service.MenJin.ACTimeZone> GetList(string where);

        [OperationContract]
        int Delete(short Id);

        [OperationContract]
        Model_Service.MenJin.ACTimeZone GetModel(short TimeZoneID);

        [OperationContract]
        void Update(Model_Service.MenJin.ACTimeZone model);

        [OperationContract]
        short Add(Model_Service.MenJin.ACTimeZone model);
    }
}
