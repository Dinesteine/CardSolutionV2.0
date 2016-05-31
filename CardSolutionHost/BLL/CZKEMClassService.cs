using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSystem_Service.ZKManage
{
    public static class CZKEMClassService
    {
        public static List<CZKEMClassData> APIs = new List<CZKEMClassData>();

        private static CZKEMClassData GetAPI(string IPAdd)
        {
            var api = APIs.FirstOrDefault(t => t.StrIp == IPAdd);
            if (api == null)
            {
                api = new CZKEMClassData() { API = new zkemkeeper.CZKEMClass() };
                APIs.Add(api);
            }
            return api;
        }

        public static bool Connect_Net(string IPAdd, int Port)
        {
            bool result = false;
            //api.API.on
            try
            {
                var api = GetAPI(IPAdd);
                result = api.API.Connect_Net(IPAdd, Port);
                if (System.ServiceModel.OperationContext.Current != null)
                {
                    api.ZK_Callback = System.ServiceModel.OperationContext.Current.GetCallbackChannel<I_ZK_Callback>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool PlayVoiceByIndex(int voiceIndex, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.PlayVoiceByIndex(voiceIndex);
        }

        public static void GetLastError(ref int dwErrorCode, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            api.API.GetLastError(ref dwErrorCode);
        }

        public static bool ClearGLog(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.PlayVoiceByIndex(dwMachineNumber);
        }

        public static bool ClearData(int dwMachineNumber, int DataFlag, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.ClearData(dwMachineNumber, DataFlag);
        }

        public static bool SetStrCardNumber(string ACardNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetStrCardNumber(ACardNumber);
        }

        public static bool SetUserInfo(int dwMachineNumber, int dwEnrollNumber, string Name, string Password, int Privilege, bool Enabled, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetUserInfo(dwMachineNumber, dwEnrollNumber, Name, Password, Privilege, Enabled);
        }

        public static bool EnableDevice(int dwMachineNumber, bool bFlag, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.EnableDevice(dwMachineNumber, bFlag);
        }

        public static void Disconnect(string IPAdd)
        {
            var api = GetAPI(IPAdd);
            api.API.Disconnect();
        }

        public static bool RefreshData(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.RefreshData(dwMachineNumber);
        }

        public static bool SetTZInfo(int dwMachineNumber, int TZIndex, string TZ, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetTZInfo(dwMachineNumber, TZIndex, TZ);
        }

        public static bool SetGroupTZStr(int dwMachineNumber, int GroupIndex, string TZs, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetGroupTZStr(dwMachineNumber, GroupIndex, TZs);
        }

        public static bool SetSysOption(int dwMachineNumber, string Option, string Value, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetSysOption(dwMachineNumber, Option, Value);
        }

        public static bool SetUnlockGroups(int dwMachineNumber, string Grps, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetUnlockGroups(dwMachineNumber, Grps);
        }

        public static bool SetUserGroup(int dwMachineNumber, int dwEnrollNumber, int UserGrp, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetUserGroup(dwMachineNumber, dwEnrollNumber, UserGrp);
        }

        public static bool GetUserTZStr(int dwMachineNumber, int dwEnrollNumber, ref string TZs, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.GetUserTZStr(dwMachineNumber, dwEnrollNumber, ref TZs);
        }

        public static void RegEvent(int dwMachineNumber, int EventMask, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            api.API.RegEvent(dwMachineNumber, EventMask);
        }

        public static bool BatchUpdate(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.BatchUpdate(dwMachineNumber);
        }

        public static bool BeginBatchUpdate(int dwMachineNumber, int UpdateFlag, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.BeginBatchUpdate(dwMachineNumber, UpdateFlag);
        }

        public static bool SetDeviceTime(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetDeviceTime(dwMachineNumber);
        }

        public static bool GetDeviceTime(int dwMachineNumber, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.GetDeviceTime(dwMachineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);
        }

        public static bool PowerOffDevice(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.PowerOffDevice(dwMachineNumber);
        }

        public static bool RestartDevice(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.RestartDevice(dwMachineNumber);
        }

        public static bool GetDeviceInfo(int dwMachineNumber, int dwInfo, ref int dwValue, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.GetDeviceInfo(dwMachineNumber, dwInfo, ref dwValue);
        }

        public static bool GetDeviceIP(int dwMachineNumber, ref string IPAddr, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.GetDeviceIP(dwMachineNumber, ref IPAddr);
        }

        public static bool ReadAllUserID(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.ReadAllUserID(dwMachineNumber);
        }

        public static bool GetGeneralLogDataStr(int dwMachineNumber, ref int dwEnrollNumber, ref int dwVerifyMode, ref int dwInOutMode, ref string TimeStr, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.GetGeneralLogDataStr(dwMachineNumber, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref TimeStr);
        }

        public static bool ReadGeneralLogData(int dwMachineNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.ReadGeneralLogData(dwMachineNumber);
        }

        public static bool GetStrCardNumber(out string ACardNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.GetStrCardNumber(out ACardNumber);
        }

        public static bool DeleteEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.DeleteEnrollData(dwMachineNumber, dwEnrollNumber, dwMachineNumber, dwBackupNumber);
        }

        public static bool GetAllUserInfo(int dwMachineNumber, ref int dwEnrollNumber, ref string Name, ref string Password, ref int Privilege, ref bool Enabled, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.GetAllUserInfo(dwMachineNumber, ref dwEnrollNumber, ref Name, ref Password, ref Privilege, ref Enabled);
        }

        public static bool SetDeviceInfo(int dwMachineNumber, int dwInfo, int dwValue, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetDeviceInfo(dwMachineNumber, dwInfo, dwValue);
        }

        public static bool SetDeviceIP(int dwMachineNumber, string IPAddr, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.SetDeviceIP(dwMachineNumber, IPAddr);
        }

        public static bool ACUnlock(int dwMachineNumber, int Delay, string IPAdd)
        {
            var api = GetAPI(IPAdd);
            return api.API.ACUnlock(dwMachineNumber, Delay);
        }
    }
}
