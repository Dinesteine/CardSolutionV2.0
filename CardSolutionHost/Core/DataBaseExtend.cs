using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace CardSolutionHost.Core
{
    public static class DataBaseExtend
    {
        public static List<T> GetEntitys<T>(this Database Database, DbCommand cmd)
        {
            DataSet ds = Database.ExecuteDataSet(cmd);
            var results = new List<T>();
            if (ds == null || ds.Tables.Count <= 0)
                return results;
            var ps = typeof(T).GetProperties();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var dr = ds.Tables[0].Rows[i];
                T t = (T)Activator.CreateInstance(typeof(T));
                foreach (var p in ps)
                {
                    if (ds.Tables[0].Columns.Contains(p.Name))
                        p.SetValue(t, dr[p.Name], null);
                }
                results.Add(t);
            }
            return results;

        }

        private const int DefaultPriority = -1;
        private const int DefaultEventId = 1;
        private static readonly ICollection<string> emptyCategoriesList = new string[0];
        public static void Write(this LogWriter logwriter, object message, TraceEventType severity = TraceEventType.Error)
        {
            logwriter.Write(message, emptyCategoriesList, DefaultPriority, DefaultEventId, severity);
        }
    }
}
