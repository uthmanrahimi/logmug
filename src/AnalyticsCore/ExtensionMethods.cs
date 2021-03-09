using Microsoft.AspNetCore.Builder;

namespace AnalyticsCore
{
    public static class ExtensionMethods
    {
        public static IApplicationBuilder UseAnalyticsCore(this IApplicationBuilder builder, IDataStore storeProvider)
        {
            builder.UseMiddleware<RequestLoggerMiddleware>(storeProvider);
            return builder;
        }
      
    }
}
