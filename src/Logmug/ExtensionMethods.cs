using Microsoft.AspNetCore.Builder;

namespace Logmug
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
