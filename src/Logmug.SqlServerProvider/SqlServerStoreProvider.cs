using AutoMapper;

using Logmug.SqlServerProvider.Entities;
using Logmug.SqlServerProvider.Persistence;

using System;
using System.Threading.Tasks;

namespace Logmug.SqlServerProvider
{
    public class SqlServerStoreProvider : IDataStore
    {
        private readonly string _connectionString;
        private readonly string _tableName = "RequestLog";
        private static readonly IMapper _mapper;
        static SqlServerStoreProvider()
        {
            var config = new MapperConfiguration(cf =>
            {
                cf.CreateMap<RequestLog, RequestLogEntity>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(d => DateTime.Now));
            });

            _mapper = config.CreateMapper();

        }
        public SqlServerStoreProvider(string connectionString)
        {
            _connectionString = connectionString;
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
                var log = _mapper.Map<RequestLogEntity>(model);
                context.RequestLogs.Add(log);
                context.SaveChanges();
            }

        }

        public async Task SaveAsync(RequestLog model)
        {
            using (var context = GetDbContext())
            {
                var log = _mapper.Map<RequestLogEntity>(model);
                await context.RequestLogs.AddAsync(log);
                await context.SaveChangesAsync();
            }

        }
    }
}
