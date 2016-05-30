using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CardSolutionHost.Entitys;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CardSolutionHost.Core;

namespace CardSolutionHost.BLL
{
    public class MenJinService : ServiceBase
    {
        const string Sql_GetMachinesEntityDt = "select * from Machines";
        public DataTable GetMachinesEntityDt()
        {
            DbCommand cmd = Database.GetSqlStringCommand(Sql_GetMachinesEntityDt);
            DataSet ds = Database.ExecuteDataSet(cmd);
            return ds.Tables[0];
        }
        const string Sql_MachinesExist = "select top 1 1 from Machines where ID=@ID";
        const string Sql_InsertMachines = "insert into Machines(MachineAlias,ConnectType,IP,SerialPort,Port,Baudrate,MachineNumber,IsHost,Enabled,CommPassword,UILanguage,DateFormat,InOutRecordWarn,Idle,Voice,managercount,usercount,fingercount,SecretCount,FirmwareVersion,ProductType,LockControl,Purpose,DeviceNetmask,DeviceGetway,sn,PhotoStamp) values (@MachineAlias,@ConnectType,@IP,@SerialPort,@Port,@Baudrate,@MachineNumber,@IsHost,@Enabled,@CommPassword,@UILanguage,@DateFormat,@InOutRecordWarn,@Idle,@Voice,@managercount,@usercount,@fingercount,@SecretCount,@FirmwareVersion,@ProductType,@LockControl,@Purpose,@DeviceNetmask,@DeviceGetway,@sn,@PhotoStamp); select @ID=@@IDENTITY";

        const string Sql_GetEnableMachinesEntitys = "select * from Machines where Enabled = 1";
        public List<MachinesEntity> GetEnableMachinesEntitys()
        {
            DbCommand cmd = Database.GetSqlStringCommand(Sql_GetMachinesEntityDt);
            DataSet ds = Database.ExecuteDataSet(cmd);
            return ClassValueCopier.GetArrayFromDataTable<MachinesEntity>(ds.Tables[0]);
        }

        const string Sql_UpdateMachines = "update Machines set MachineAlias=@MachineAlias,ConnectType=@ConnectType,IP=@IP,SerialPort=@SerialPort,Port=@Port,Baudrate=@Baudrate,MachineNumber=@MachineNumber,IsHost=@IsHost,Enabled=@Enabled,CommPassword=@CommPassword,UILanguage=@UILanguage,DateFormat=@DateFormat,InOutRecordWarn=@InOutRecordWarn,Idle=@Idle,Voice=@Voice,managercount=@managercount,usercount=@usercount,fingercount=@fingercount,SecretCount=@SecretCount,FirmwareVersion=@FirmwareVersion,ProductType=@ProductType,LockControl=@LockControl,Purpose=@Purpose,DeviceNetmask=@DeviceNetmask,DeviceGetway=@DeviceGetway,sn=@sn,PhotoStamp=@PhotoStamp where ID=@ID";
        public void SaveMachinesEntitys(List<MachinesEntity> entitys)
        {
            base.UseTran((tran) =>
            {
                foreach (var entity in entitys)
                {
                    DbCommand cmd;
                    if (entity.ID <= 0)
                    {
                        cmd = Database.GetSqlStringCommand(Sql_InsertMachines);
                        AddParameter_InsertMachines(Database, cmd, entity);
                        Database.ExecuteNonQuery(cmd, tran);
                    }
                    cmd = Database.GetSqlStringCommand(Sql_MachinesExist);
                    Database.AddInParameter(cmd, "ID", DbType.Int32, entity.ID);
                    var objExist = Database.ExecuteScalar(cmd);
                    if (objExist == null)
                    {
                        cmd = Database.GetSqlStringCommand(Sql_InsertMachines);
                        AddParameter_InsertMachines(Database, cmd, entity);
                        Database.ExecuteNonQuery(cmd, tran);
                    }
                    else
                    {
                        cmd = Database.GetSqlStringCommand(Sql_UpdateMachines);
                        AddParameter_UpdateMachines(Database, cmd, entity);
                        Database.ExecuteNonQuery(cmd, tran);
                    }
                }
            });
        }

        public void AddParameter_UpdateMachines(Database database, DbCommand cmd, MachinesEntity entity)
        {
            database.AddInParameter(cmd, "ID", DbType.Int32, entity.ID);
            database.AddInParameter(cmd, "MachineAlias", DbType.String, entity.MachineAlias);
            database.AddInParameter(cmd, "ConnectType", DbType.Int32, entity.ConnectType);
            database.AddInParameter(cmd, "IP", DbType.String, entity.IP);
            database.AddInParameter(cmd, "SerialPort", DbType.Int32, entity.SerialPort);
            database.AddInParameter(cmd, "Port", DbType.Int32, entity.Port);
            database.AddInParameter(cmd, "Baudrate", DbType.Int32, entity.Baudrate);
            database.AddInParameter(cmd, "MachineNumber", DbType.Int32, entity.MachineNumber);
            database.AddInParameter(cmd, "IsHost", DbType.Boolean, entity.IsHost);
            database.AddInParameter(cmd, "Enabled", DbType.Boolean, entity.Enabled);
            database.AddInParameter(cmd, "CommPassword", DbType.String, entity.CommPassword);
            database.AddInParameter(cmd, "UILanguage", DbType.Int16, entity.UILanguage);
            database.AddInParameter(cmd, "DateFormat", DbType.Int16, entity.DateFormat);
            database.AddInParameter(cmd, "InOutRecordWarn", DbType.Int16, entity.InOutRecordWarn);
            database.AddInParameter(cmd, "Idle", DbType.Int16, entity.Idle);
            database.AddInParameter(cmd, "Voice", DbType.Int16, entity.Voice);
            database.AddInParameter(cmd, "managercount", DbType.Int16, entity.managercount);
            database.AddInParameter(cmd, "usercount", DbType.Int16, entity.usercount);
            database.AddInParameter(cmd, "fingercount", DbType.Int16, entity.fingercount);
            database.AddInParameter(cmd, "SecretCount", DbType.Int16, entity.SecretCount);
            database.AddInParameter(cmd, "FirmwareVersion", DbType.String, entity.FirmwareVersion);
            database.AddInParameter(cmd, "ProductType", DbType.String, entity.ProductType);
            database.AddInParameter(cmd, "LockControl", DbType.Int16, entity.LockControl);
            database.AddInParameter(cmd, "Purpose", DbType.Int32, entity.Purpose);
            database.AddInParameter(cmd, "DeviceNetmask", DbType.String, entity.DeviceNetmask);
            database.AddInParameter(cmd, "DeviceGetway", DbType.String, entity.DeviceGetway);
            database.AddInParameter(cmd, "sn", DbType.String, entity.sn);
            database.AddInParameter(cmd, "PhotoStamp", DbType.String, entity.PhotoStamp);
        }

        public void AddParameter_InsertMachines(Database database, DbCommand cmd, MachinesEntity entity)
        {
            database.AddOutParameter(cmd, "ID", DbType.Int32, 4);
            database.AddInParameter(cmd, "MachineAlias", DbType.String, entity.MachineAlias);
            database.AddInParameter(cmd, "ConnectType", DbType.Int32, entity.ConnectType);
            database.AddInParameter(cmd, "IP", DbType.String, entity.IP);
            database.AddInParameter(cmd, "SerialPort", DbType.Int32, entity.SerialPort);
            database.AddInParameter(cmd, "Port", DbType.Int32, entity.Port);
            database.AddInParameter(cmd, "Baudrate", DbType.Int32, entity.Baudrate);
            database.AddInParameter(cmd, "MachineNumber", DbType.Int32, entity.MachineNumber);
            database.AddInParameter(cmd, "IsHost", DbType.Boolean, entity.IsHost);
            database.AddInParameter(cmd, "Enabled", DbType.Boolean, entity.Enabled);
            database.AddInParameter(cmd, "CommPassword", DbType.String, entity.CommPassword);
            database.AddInParameter(cmd, "UILanguage", DbType.Int16, entity.UILanguage);
            database.AddInParameter(cmd, "DateFormat", DbType.Int16, entity.DateFormat);
            database.AddInParameter(cmd, "InOutRecordWarn", DbType.Int16, entity.InOutRecordWarn);
            database.AddInParameter(cmd, "Idle", DbType.Int16, entity.Idle);
            database.AddInParameter(cmd, "Voice", DbType.Int16, entity.Voice);
            database.AddInParameter(cmd, "managercount", DbType.Int16, entity.managercount);
            database.AddInParameter(cmd, "usercount", DbType.Int16, entity.usercount);
            database.AddInParameter(cmd, "fingercount", DbType.Int16, entity.fingercount);
            database.AddInParameter(cmd, "SecretCount", DbType.Int16, entity.SecretCount);
            database.AddInParameter(cmd, "FirmwareVersion", DbType.String, entity.FirmwareVersion);
            database.AddInParameter(cmd, "ProductType", DbType.String, entity.ProductType);
            database.AddInParameter(cmd, "LockControl", DbType.Int16, entity.LockControl);
            database.AddInParameter(cmd, "Purpose", DbType.Int32, entity.Purpose);
            database.AddInParameter(cmd, "DeviceNetmask", DbType.String, entity.DeviceNetmask);
            database.AddInParameter(cmd, "DeviceGetway", DbType.String, entity.DeviceGetway);
            database.AddInParameter(cmd, "sn", DbType.String, entity.sn);
            database.AddInParameter(cmd, "PhotoStamp", DbType.String, entity.PhotoStamp);
        }
    }
}
