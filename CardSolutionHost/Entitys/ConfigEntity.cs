using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSolutionHost.Entitys
{
    public class ConfigEntity : BaseEntity
    {
        public static ConfigEntity CreateEntity()
        {
            return new ConfigEntity()
            {
                ConfigName = string.Empty,
                ConfigValue = string.Empty
            };
        }
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }
    }
}
