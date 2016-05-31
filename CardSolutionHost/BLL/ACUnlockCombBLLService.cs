using System.Collections.Generic;
using System.ServiceModel;
using BLL_Service.MenJin;
namespace CardSystem_Service.BLL.MenJin
{
    public class ACUnlockCombBLLService : IACUnlockCombBLLService
    {
        ACUnlockCombBLL bll = new ACUnlockCombBLL();
        public Model_Service.MenJin.ACUnlockComb GetModel(short UnlockCombID)
        {
            return bll.GetModel(UnlockCombID);
        }

        public IList<Model_Service.MenJin.ACUnlockComb> GetList(string where)
        {
            return bll.GetList(where);
        }

        public int Delete(short UnlockCombID)
        {
            return bll.Delete(UnlockCombID);
        }

        public void Update(Model_Service.MenJin.ACUnlockComb model)
        {
            bll.Update(model);
        }

        public short Add(Model_Service.MenJin.ACUnlockComb model)
        {
            return (short)bll.Add(model);
        }

        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }
    }
    [ServiceContract]
    public interface IACUnlockCombBLLService
    {
        [OperationContract]
        System.Data.DataSet GetData(string where);
        [OperationContract]
        Model_Service.MenJin.ACUnlockComb GetModel(short UnlockCombID);
        [OperationContract]
        IList<Model_Service.MenJin.ACUnlockComb> GetList(string where);
        [OperationContract]
        int Delete(short UnlockCombID);
        [OperationContract]
        void Update(Model_Service.MenJin.ACUnlockComb model);
        [OperationContract]
        short Add(Model_Service.MenJin.ACUnlockComb model);
    }
}
