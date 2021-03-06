using Microsoft.AspNetCore.Builder;

namespace AnalyticsCore
{
    public static class ExtensionMethods
    {
        public static IApplicationBuilder UseAnalyticsCore(this IApplicationBuilder builder, IDataStore storeProvider)
        {
            //register middleware here
            return builder;
        }
    }
}
