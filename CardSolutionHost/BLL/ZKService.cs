using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zkemkeeper;
using System.ServiceModel;
namespace CardSystem_Service.ZKManage
{
    public class ZKService : IZKService
    {
        private CZKEMClass api = null;
        private CZKEMClass GetAPI()
        {
            if (api == null)
            {
                api = new CZKEMClass();
            }
            return api;
        }
        public CZKEMClass API
        {
            get
            {
                return GetAPI();
            }
        }
        #region IZKService 成员

        public bool PlayVoiceByIndex(int voiceIndex)
        {
            return API.PlayVoiceByIndex(voiceIndex);
        }

        public bool ReadAllUserID(int dwMachineNumber)
        {
            return API.ReadAllUserID(dwMachineNumber);
        }

        public bool ACUnlock(int dwMachineNumber, int Delay)
        {
            return API.ACUnlock(dwMachineNumber, Delay);
        }

        public bool GetGeneralLogDataStr(int dwMachineNumber, ref int dwEnrollNumber, ref int dwVerifyMode, ref int dwInOutMode, ref string TimeStr)
        {
            return API.GetGeneralLogDataStr(dwMachineNumber, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref TimeStr);
        }

        public bool ReadGeneralLogData(int dwMachineNumber)
        {
            return API.ReadGeneralLogData(dwMachineNumber);
        }

        public bool GetStrCardNumber(out string ACardNumber)
        {
            return API.GetStrCardNumber(out ACardNumber);
        }

        public bool DeleteEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber)
        {
            return API.DeleteEnrollData(dwMachineNumber, dwEnrollNumber, dwEMachineNumber, dwBackupNumber);
        }

        public bool GetAllUserInfo(int dwMachineNumber, ref int dwEnrollNumber, ref string Name, ref string Password, ref int Privilege, ref bool Enabled)
        {
            return API.GetAllUserInfo(dwMachineNumber, ref dwEnrollNumber, ref Name, ref Password, ref Privilege, ref Enabled);
        }

        public bool SetDeviceInfo(int dwMachineNumber, int dwInfo, int dwValue)
        {
            return API.SetDeviceInfo(dwMachineNumber, dwInfo, dwValue);
        }

        public bool SetDeviceIP(int dwMachineNumber, string IPAddr)
        {
            return API.SetDeviceIP(dwMachineNumber, IPAddr);
        }

        public bool BatchUpdate(int dwMachineNumber)
        {
            return API.BatchUpdate(dwMachineNumber);
        }

        public bool BeginBatchUpdate(int dwMachineNumber, int UpdateFlag)
        {
            return API.BeginBatchUpdate(dwMachineNumber, UpdateFlag);
        }

        public bool SetDeviceTime(int dwMachineNumber)
        {
            return API.SetDeviceTime(dwMachineNumber);
        }

        public bool GetDeviceTime(int dwMachineNumber, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond)
        {
            return API.GetDeviceTime(dwMachineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);
        }

        public bool PowerOffDevice(int dwMachineNumber)
        {
            return API.PowerOffDevice(dwMachineNumber);
        }

        public bool RestartDevice(int dwMachineNumber)
        {
            return API.RestartDevice(dwMachineNumber);
        }

        public bool GetDeviceInfo(int dwMachineNumber, int dwInfo, ref int dwValue)
        {
            return API.GetDeviceInfo(dwMachineNumber, dwInfo, ref  dwValue);
        }

        public bool GetDeviceIP(int dwMachineNumber, ref string IPAddr)
        {
            return API.GetDeviceIP(dwMachineNumber, ref IPAddr);
        }

        public bool EnableDevice(int dwMachineNumber, bool bFlag)
        {
            return API.EnableDevice(dwMachineNumber, bFlag);
        }

        public bool Connect_Net(string IPAdd, int Port)
        {
            return API.Connect_Net(IPAdd, Port);
        }

        public void Disconnect()
        {
            API.Disconnect();
        }

        public bool RefreshData(int dwMachineNumber)
        {
            return API.RefreshData(dwMachineNumber);
        }

        public bool SetTZInfo(int dwMachineNumber, int TZIndex, string TZ)
        {
            return API.SetTZInfo(dwMachineNumber, TZIndex, TZ);
        }

        public bool SetGroupTZStr(int dwMachineNumber, int GroupIndex, string TZs)
        {
            return API.SetGroupTZStr(dwMachineNumber, GroupIndex, TZs);
        }

        public bool SetSysOption(int dwMachineNumber, string Option, string Value)
        {
            return API.SetSysOption(dwMachineNumber, Option, Value);
        }

        public bool SetUnlockGroups(int dwMachineNumber, string Grps)
        {
            return API.SetUnlockGroups(dwMachineNumber, Grps);
        }

        public bool SetUserGroup(int dwMachineNumber, int dwEnrollNumber, int UserGrp)
        {
            return API.SetUserGroup(dwMachineNumber, dwEnrollNumber, UserGrp);
        }

        public bool SetUserTZStr(int dwMachineNumber, int dwEnrollNumber, string TZs)
        {
            return API.SetUserTZStr(dwMachineNumber, dwEnrollNumber, TZs);
        }

        public bool GetUserTZStr(int dwMachineNumber, int dwEnrollNumber, ref string TZs)
        {
            return API.GetUserTZStr(dwMachineNumber, dwEnrollNumber, ref TZs);
        }

        public void GetLastError(ref int dwErrorCode)
        {
            API.GetLastError(ref dwErrorCode);
        }

        public bool ClearGLog(int dwMachineNumber)
        {
            return API.ClearGLog(dwMachineNumber);
        }

        public bool ClearData(int dwMachineNumber, int DataFlag)
        {
            return API.ClearData(dwMachineNumber, DataFlag);
        }

        public bool SetStrCardNumber(string ACardNumber)
        {
            return API.SetStrCardNumber(ACardNumber);
        }

        public bool SetUserInfo(int dwMachineNumber, int dwEnrollNumber, string Name, string Password, int Privilege, bool Enabled)
        {
            return API.SetUserInfo(dwMachineNumber, dwEnrollNumber, Name, Password, Privilege, Enabled);
        }

        public void RegEvent(int dwMachineNumber, int EventMask)
        {
            API.RegEvent(dwMachineNumber, EventMask);
        }

        #endregion
        
        public void BindEvent()
        {
            api.OnHIDNum -= new _IZKEMEvents_OnHIDNumEventHandler(api_OnHIDNum);
            api.OnHIDNum += new _IZKEMEvents_OnHIDNumEventHandler(api_OnHIDNum);
        }

        void api_OnHIDNum(int CardNumber)
        {
            var callerProxy = OperationContext.Current.GetCallbackChannel<I_ZK_Callback>();
            callerProxy.GetCardNo(CardNumber);
        }
    }
}