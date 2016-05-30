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
    }
}
