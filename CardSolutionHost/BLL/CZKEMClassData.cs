using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zkemkeeper;

namespace CardSystem_Service.ZKManage
{
    public class CZKEMClassData
    {
        public I_ZK_Callback ZK_Callback;
        public CZKEMClass API { get; set; }
        public string StrIp { get; set; }
        public List<OnHIDNumData> listOnHIDNums = new List<OnHIDNumData>();
        public void AddOnHIDNum()
        {
            this.API.OnHIDNum -= API_OnHIDNum;
            this.API.OnHIDNum += API_OnHIDNum;
        }

        void API_OnHIDNum(int CardNumber)
        {
            foreach (var item in listOnHIDNums)
            {
                if (item.MyDelOnHIDNum != null)
                    item.MyDelOnHIDNum(CardNumber);
            }
            if (this.ZK_Callback != null)
                this.ZK_Callback.GetCardNo(CardNumber);
        }
    }

    public class OnHIDNumData
    {
        public DelOnHIDNum MyDelOnHIDNum;
        public string StrIp;
        //public OnHIDNumData(string StrIp, DelOnHIDNum MyDelOnHIDNum)
        //{
        //    this.StrIp = StrIp;
        //    this.MyDelOnHIDNum = MyDelOnHIDNum;
        //}
    }
}
