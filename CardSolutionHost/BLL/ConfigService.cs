using CardSolutionHost.Entitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CardSolutionHost.Core;
namespace CardSolutionHost.BLL
{
    public class ConfigService : ConfigServiceBase
    {
        const string Sql_GetConfigByConfigName = "select * from T_Config where ConfigName=$ConfigName";
        public ConfigEntity GetConfigByConfigName(string ConfigName)
        {
            DbCommand cmd = Database.GetSqlStringCommand(Sql_GetConfigs);
            DataSet ds = Database.ExecuteDataSet(cmd);
            if (ds == null || ds.Tables.Count <= 0)
                return null;
            if (ds.Tables[0].Rows.Count <= 0)
                return null;
            var result = ConfigEntity.CreateEntity();
            ClassValueCopier.CopyValueFromDataRow(result, ds.Tables[0].Rows[0]);
            return result;
        }
        const string Sql_GetConfigs = "select * from T_Config";
        public List<ConfigEntity> GetConfigs()
        {
            DbCommand cmd = Database.GetSqlStringCommand(Sql_GetConfigs);
            DataSet ds = Database.ExecuteDataSet(cmd);
            if (ds == null || ds.Tables.Count <= 0)
                return new List<ConfigEntity>();
            return ClassValueCopier.GetArrayFromDataTable<ConfigEntity>(ds.Tables[0]);
        }
        const string Sql_SaveEntity = "update T_Config set ConfigValue=$ConfigValue where ConfigName=$ConfigName";
        public void SaveEntitys(List<ConfigEntity> entitys)
        {
            base.UseTran((tran) =>
            {
                foreach (var entity in entitys)
                {
                    DbCommand cmd = Database.GetSqlStringCommand(Sql_SaveEntity);
                    Database.AddInParameter(cmd, "ConfigName", DbType.String, entity.ConfigName);
                    Database.AddInParameter(cmd, "ConfigValue", DbType.String, entity.ConfigValue);
                    int rowcount = Database.ExecuteNonQuery(cmd, tran);
                    if (rowcount == 0)
                        throw new Exception("保存失败");
                }
            });
        }
        public void SaveEntity(ConfigEntity entity)
        {
            if (entity == null)
                throw new Exception("保存对象不可为空");
            SaveEntitys(new List<ConfigEntity>() { entity });
        }


    }
}
