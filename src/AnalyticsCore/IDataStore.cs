using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsCore
{
    public interface IDataStore
    {
        void Save(RequestLog model);
        Task SaveAsync(RequestLog model);
    }
}
