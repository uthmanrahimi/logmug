using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AnalyticsCore
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDataStore _storeProvider;

        public RequestLoggerMiddleware(RequestDelegate next, IDataStore storeProvider)
        {
            _next = next;
            _storeProvider = storeProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            await _storeProvider.SaveAsync(new RequestLog
            {
                Browser = context.Request.Headers["User-Agent"],
                HttpMethod = context.Request.Method,
                IPAddress = context.Connection.RemoteIpAddress.ToString(),
                OperationSystem = context.GetOS(),
                Referer = context.Request.Headers["Referer"]
            });
        }
    }
}
