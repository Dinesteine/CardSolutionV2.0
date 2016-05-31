using System.ServiceModel;
using System.Data;
using BLL_Service.MenJin;
namespace CardSystem_Service.BLL.MenJin
{
    public class UserACPrivilegeBLLService : IUserACPrivilegeBLLService
    {
        private readonly UserACPrivilegeBLL bll = new UserACPrivilegeBLL();
        public Model_Service.MenJin.UserACPrivilege GetModel(int DeviceID, int UserID)
        {
            return bll.GetModel(DeviceID, UserID);
        }

        public System.Collections.Generic.IList<Model_Service.MenJin.UserACPrivilege> GetList(string where)
        {
            return bll.GetList(where);
        }

        public int Delete(int DeviceID, int UserID)
        {
            return bll.Delete(DeviceID, UserID);
        }

        public void Update(Model_Service.MenJin.UserACPrivilege model)
        {
            bll.Update(model);
        }

        public System.Data.DataSet GetData(string where)
        {
            return bll.GetData(where);
        }

        public System.Data.DataSet GetDataWithUserInfoAndDeptInfo(string where)
        {
            return bll.GetDataWithUserInfoAndDeptInfo(where);
        }

        public int AddUserACPrivilege(System.Collections.Generic.IList<Model_Service.MenJin.UserACPrivilege> list)
        {
            return bll.AddUserACPrivilege(list);
        }

        public int DelUserACPrivilege(System.Collections.Generic.IList<Model_Service.MenJin.UserACPrivilege> list)
        {
            return bll.DelUserACPrivilege(list);
        }

        public System.Data.DataSet GetDataWithUserInfoAndMachineInfo(string where)
        {
            return bll.GetDataWithUserInfoAndMachineInfo(where);
        }
        /// <summary>
        /// 根据假日规则获取正确的用户权限
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<Model_Service.MenJin.UserACPrivilege> GetListByJRGZ(System.Collections.Generic.List<Model_Service.MenJin.UserACPrivilege> list)
        {
            return bll.GetListByJRGZ(list);
        }

        public Model_Service.MenJin.UserACPrivilegeId Add(Model_Service.MenJin.UserACPrivilege model)
        {
            return bll.Add(model);
        }
    }

    [ServiceContract]
    public interface IUserACPrivilegeBLLService
    {
        [OperationContract]
        System.Data.DataSet GetData(string where);

        [OperationContract]
        Model_Service.MenJin.UserACPrivilege GetModel(int DeviceID, int UserID);

        [OperationContract]
        System.Collections.Generic.IList<Model_Service.MenJin.UserACPrivilege> GetList(string where);

        [OperationContract]
        void Update(Model_Service.MenJin.UserACPrivilege model);

        [OperationContract]
        Model_Service.MenJin.UserACPrivilegeId Add(Model_Service.MenJin.UserACPrivilege model);

        [OperationContract]
        int Delete(int DeviceID, int UserID);

        [OperationContract]
        DataSet GetDataWithUserInfoAndDeptInfo(string where);

        [OperationContract]
        int AddUserACPrivilege(System.Collections.Generic.IList<Model_Service.MenJin.UserACPrivilege> list);

        [OperationContract]
        DataSet GetDataWithUserInfoAndMachineInfo(string where);

        [OperationContract]
        System.Collections.Generic.List<Model_Service.MenJin.UserACPrivilege> GetListByJRGZ(System.Collections.Generic.List<Model_Service.MenJin.UserACPrivilege> list);
        [OperationContract]
        int DelUserACPrivilege(System.Collections.Generic.IList<Model_Service.MenJin.UserACPrivilege> list);
    }
}
