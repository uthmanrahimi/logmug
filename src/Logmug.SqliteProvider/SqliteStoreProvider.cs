using Logmug.SqliteProvider.Persistence;

using System;
using System.Threading.Tasks;

namespace Logmug.SqliteProvider
{
    public class SqliteStoreProvider : IDataStore
    {
        private string _connectionString;
        private string _tableName = "RequestLog";
        public SqliteStoreProvider(string connectonString)
        {
            _connectionString = connectonString;
        }

        public SqliteStoreProvider TableName(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        public void Save(RequestLog model)
        {
            using (var context = GetDbContext())
            {
                context.Requests.Add(Map(model));
                context.SaveChanges();
            }
        }

        public async Task SaveAsync(RequestLog model)
        {
            using (var context = GetDbContext())
            {
                await context.Requests.AddAsync(Map(model));

                await context.SaveChangesAsync();
            }
        }

        private SqliteDataContext GetDbContext()
        {
            var context = new SqliteDataContext(_connectionString, _tableName);
            context.Database.EnsureCreated();
            return context;
        }

        private Entities.RequestLogEntity Map(RequestLog model)
        {
            return new Entities.RequestLogEntity
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
