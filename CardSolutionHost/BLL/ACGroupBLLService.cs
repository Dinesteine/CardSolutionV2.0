using System.Collections.Generic;
using System.ServiceModel;
using BLL_Service.MenJin;
namespace CardSystem_Service.BLL.MenJin
{
    public class ACGroupBLLService : IACGroupBLLService
    {
        private readonly ACGroupBLL bll = new ACGroupBLL();
        public IList<Model_Service.MenJin.ACGroup> GetList(string where)
        {
            return bll.GetList(where);
        }

        public int Delete(short Id)
        {
            return bll.Delete(Id);
        }

        public Model_Service.MenJin.ACGroup GetModel(short GroupID)
        {
            return bll.GetModel(GroupID);
        }

        public void Update(Model_Service.MenJin.ACGroup model)
        {
            bll.Update(model);
        }

        public short Add(Model_Service.MenJin.ACGroup model)
        {
            return (short)bll.Add(model);
        }

        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }
    }


    [ServiceContract]
    public interface IACGroupBLLService
    {
        [OperationContract]
        IList<Model_Service.MenJin.ACGroup> GetList(string where);
        [OperationContract]
        int Delete(short Id);
        [OperationContract]
        Model_Service.MenJin.ACGroup GetModel(short GroupID);
        [OperationContract]
        short Add(Model_Service.MenJin.ACGroup model);
        [OperationContract]
        System.Data.DataSet GetData(string where);
    }
}
