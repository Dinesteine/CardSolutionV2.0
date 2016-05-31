using CardSolutionHost.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSolutionHost.Core
{
    public class SystemConfig
    {
        private static int _MenJinRefreshMinutes = -1;
        public static int MenJinRefreshMinutes
        {
            get
            {
                if (_MenJinRefreshMinutes == -1)
                {
                    _MenJinRefreshMinutes = int.Parse(new ConfigService().GetConfigByConfigName("MenJinRefreshMinutes").ConfigValue);
                }
                return _MenJinRefreshMinutes;
            }
            set
            {
                if (value < 3)
                    throw new Exception("定时刷新时间不可小于3分钟");
                if (_MenJinRefreshMinutes == value)
                    return;
                new ConfigService().SaveEntity(new Entitys.ConfigEntity()
                {
                    ConfigName = "MenJinRefreshMinutes",
                    ConfigValue = value.ToString()
                });
                _MenJinRefreshMinutes = value;
            }
        }
        private static string _MenJinReStartTime;
        public static string MenJinReStartTime
        {
            get
            {
                if (_MenJinReStartTime == null)
                {
                    _MenJinReStartTime = new ConfigService().GetConfigByConfigName("MenJinReStartTime").ConfigValue;
                    if (_MenJinReStartTime == null)
                        throw new Exception("门禁重启时间配置错误");
                }
                return _MenJinReStartTime;
            }
            set
            {
                new ConfigService().SaveEntity(new Entitys.ConfigEntity()
                {
                    ConfigName = "MenJinReStartTime",
                    ConfigValue = value
                });
                _MenJinReStartTime = value;
            }
        }
        private static int _UdpMsgServicePort = -1;
        public static int UdpMsgServicePort
        {
            get
            {
                if (_UdpMsgServicePort == -1)
                {
                    _UdpMsgServicePort = int.Parse(new ConfigService().GetConfigByConfigName("UdpMsgServicePort").ConfigValue);
                }
                return _UdpMsgServicePort;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("端口不正确");
                if (_UdpMsgServicePort == value)
                    return;
                new ConfigService().SaveEntity(new Entitys.ConfigEntity()
                {
                    ConfigName = "UdpMsgServicePort",
                    ConfigValue = value.ToString()
                });
                _UdpMsgServicePort = value;
            }
        }

        private static int _WcfServicePort = -1;
        public static int WcfServicePort
        {
            get
            {
                if (_WcfServicePort == -1)
                {
                    _WcfServicePort = int.Parse(new ConfigService().GetConfigByConfigName("WcfServicePort").ConfigValue);
                }
                return _WcfServicePort;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("端口不正确");
                if (_WcfServicePort == value)
                    return;
                new ConfigService().SaveEntity(new Entitys.ConfigEntity()
                {
                    ConfigName = "WcfServicePort",
                    ConfigValue = value.ToString()
                });
                _WcfServicePort = value;
            }
        }






        //private static string _WCFServiceIpAddress;
        //public static string WCFServiceIpAddress
        //{
        //    get
        //    {
        //        if (_WCFServiceIpAddress == null)
        //        {
        //            _WCFServiceIpAddress = new ConfigService().GetConfigByConfigName("WCFServiceIpAddress").ConfigValue;
        //            if (_WCFServiceIpAddress == null)
        //                throw new Exception("WCFServiceIp配置错误");
        //        }
        //        return _WCFServiceIpAddress;
        //    }
        //    set
        //    {
        //        new ConfigService().SaveEntity(new Entitys.ConfigEntity()
        //        {
        //            ConfigName = "WCFServiceIpAddress",
        //            ConfigValue = value
        //        });
        //        _WCFServiceIpAddress = value;
        //    }
        //}
        //UdpMsgServicePort

        //private static string _SqlConnectionString;
        //public static string SqlConnectionString
        //{
        //    get
        //    {
        //        if (_SqlConnectionString == null)
        //        {
        //            _SqlConnectionString = new ConfigService().GetConfigByConfigName("SqlConnectionString").ConfigValue;
        //            if (_SqlConnectionString == null)
        //                throw new Exception("数据库连接字符串未配置");
        //        }
        //        return _MenJinReStartTime;
        //    }
        //    set
        //    {
        //        new ConfigService().SaveEntity(new Entitys.ConfigEntity()
        //        {
        //            ConfigName = "SqlConnectionString",
        //            ConfigValue = value
        //        });
        //        _SqlConnectionString = value;
        //    }
        //}
    }
}
