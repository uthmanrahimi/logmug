using System.Threading.Tasks;

namespace Logmug
{
    public interface IDataStore
    {
        void Save(RequestLog model);
        Task SaveAsync(RequestLog model);
    }
}
