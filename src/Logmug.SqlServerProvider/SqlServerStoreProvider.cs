
using Logmug.SqlServerProvider.Entities;
using Logmug.SqlServerProvider.Persistence;

using System;
using System.Threading.Tasks;

namespace Logmug.SqlServerProvider
{
    public class SqlServerStoreProvider : IDataStore
    {
        private readonly string _connectionString;
        private string _tableName = "RequestLog";
     
        public SqlServerStoreProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlServerStoreProvider TableName(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        private SqlServerDataContext GetDbContext()
        {
            var context = new SqlServerDataContext(_connectionString, _tableName);
            context.Database.EnsureCreated();
            return context;
        }

        public void Save(RequestLog model)
        {
            using (var context = GetDbContext())
            {
                var log = Map(model);
                context.RequestLogs.Add(log);
                context.SaveChanges();
            }

        }

        public async Task SaveAsync(RequestLog model)
        {
            using (var context = GetDbContext())
            {
                var log =Map(model);
                await context.RequestLogs.AddAsync(log);
                await context.SaveChangesAsync();
            }

        }

        private RequestLogEntity Map(RequestLog model)
        {
            return new RequestLogEntity
            {
                Browser = model.Browser,
                HttpMethod = model.HttpMethod,
                IPAddress = model.IPAddress,
                OperationSystem = model.OperationSystem,
                Referer = model.Referer,
                Timestamp = DateTime.Now
            };
        }
    }
}
