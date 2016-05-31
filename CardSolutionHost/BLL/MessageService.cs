using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CardSolutionHost.BLL
{
    public class MessageService : ServiceBase
    {
        const string Sql_GetMessageToSend = "select Id, MessageType, Theme from Sys_Message where datediff(n, StartDate, getdate()) >= 0 and datediff(n, EndDate, getdate())<= 0  order by OPDate desc";
        public DataSet GetMessageToSend()
        {
            DbCommand cmd = Database.GetSqlStringCommand(Sql_GetMessageToSend);
            return Database.ExecuteDataSet(cmd);
        }

        public object GetLastSendTime()
        {
            DbCommand cmd = Database.GetSqlStringCommand("select dbo.[GetLastSendTime]() ");
            return Database.ExecuteScalar(cmd);
        }
    }
}
