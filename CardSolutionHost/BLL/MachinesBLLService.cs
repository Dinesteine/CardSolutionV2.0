using System.Collections.Generic;
using System.ServiceModel;
using BLL_Service.MenJin;
namespace CardSystem_Service.BLL.MenJin
{
    public class MachinesBLLService : IMachinesBLLService
    {
        private readonly MachinesBLL bll = new MachinesBLL();
        public Model_Service.MenJin.Machine GetModel(int Id)
        {
            return bll.GetModel(Id);
        }

        public IList<Model_Service.MenJin.Machine> GetList(string where)
        {
            return bll.GetList(where);
        }

        public int Delete(int Id)
        {
            return bll.Delete(Id);
        }

        public void Update(Model_Service.MenJin.Machine model)
        {
            bll.Update(model);
        }

        public int Add(Model_Service.MenJin.Machine model)
        {
            return (int)bll.Add(model);
        }

        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }
    }

    [ServiceContract]
    public interface IMachinesBLLService
    {
        [OperationContract]
        System.Data.DataSet GetData(string where);

        [OperationContract]
        Model_Service.MenJin.Machine GetModel(int Id);

        [OperationContract]
        IList<Model_Service.MenJin.Machine> GetList(string where);

        [OperationContract]
        void Update(Model_Service.MenJin.Machine model);

        [OperationContract]
        int Add(Model_Service.MenJin.Machine model);

        [OperationContract]
        int Delete(int Id);
    }
}
