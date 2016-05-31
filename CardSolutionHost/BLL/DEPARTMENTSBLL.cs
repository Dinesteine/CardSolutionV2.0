using System.Collections.Generic;
using System.ServiceModel;
using BLL_Service.Hr;
namespace CardSystem_Service.BLL.Hr
{
    public class DEPARTMENTSBLLService : IDEPARTMENTSBLLService
    {
        private readonly DEPARTMENTSBLL bll = new DEPARTMENTSBLL();
        public Model_Service.Hr.DEPARTMENTS GetModel(int Id)
        {
            return bll.GetModel(Id);
        }

        public IList<Model_Service.Hr.DEPARTMENTS> GetList(string where)
        {
            return bll.GetList(where);
        }

        public void Delete(int Id)
        {
            bll.Delete(Id);
        }

        public void Update(Model_Service.Hr.DEPARTMENTS model)
        {
            bll.Update(model);
        }

        public void Add(Model_Service.Hr.DEPARTMENTS model)
        {
            bll.Add(model);
        }

        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }
    }

    [ServiceContract]
    public interface IDEPARTMENTSBLLService
    {
        [OperationContract]
        System.Data.DataSet GetData(string where);

        [OperationContract]
        Model_Service.Hr.DEPARTMENTS GetModel(int Id);

        [OperationContract]
        IList<Model_Service.Hr.DEPARTMENTS> GetList(string where);

        [OperationContract]
        void Update(Model_Service.Hr.DEPARTMENTS model);

        [OperationContract]
        void Add(Model_Service.Hr.DEPARTMENTS model);

        [OperationContract]
        void Delete(int Id);
    }
}


