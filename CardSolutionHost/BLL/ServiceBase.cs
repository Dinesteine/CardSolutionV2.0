using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CardSolutionHost.BLL
{
    public abstract class ServiceBase
    {
        private Database database;
        public virtual Database Database
        {
            get
            {
                if (database == null)
                    database = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                return database;
            }
        }
        protected void UseTran(Action<DbTransaction> action)
        {
            using (DbConnection connection = this.Database.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    action(transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        protected T UseTran<T>(Func<DbTransaction, T> func)
        {
            using (DbConnection connection = this.Database.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    T result = func(transaction);
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
    public abstract class ConfigServiceBase: ServiceBase
    {
        private Database database;
        public override Database Database
        {
            get
            {
                if (database == null)
                    database = EnterpriseLibraryContainer.Current.GetInstance<Database>("ConfigConnection");
                return database;
            }
        }
    }
}
