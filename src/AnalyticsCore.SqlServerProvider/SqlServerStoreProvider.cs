using AnalyticsCore.SqlServerProvider.Entities;
using AnalyticsCore.SqlServerProvider.Persistence;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AnalyticsCore.SqlServerProvider
{
    public class SqlServerStoreProvider : IDataStore
    {
        private readonly SqlServerDataContext _dataContext;

        public SqlServerStoreProvider(SqlServerDataContext dataContext)
        {
            _dataContext = dataContext;
            RegisterAutomapperProfiles();
        }

        public void Save(RequestLog model)
        {
            var log = new RequestLogEntity();
            _dataContext.RequestLogs.Add(log);
            _dataContext.SaveChanges();
        }

        public async Task SaveAsync(RequestLog model)
        {
            var log = new RequestLogEntity();
            await _dataContext.RequestLogs.AddAsync(log);
            await _dataContext.SaveChangesAsync();
        }

        private void RegisterAutomapperProfiles()
        {
            var config = new MapperConfiguration(cf =>
            {
                cf.CreateMap<RequestLog, RequestLogEntity>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(d => DateTime.Now));
            });
        }
    }
}
