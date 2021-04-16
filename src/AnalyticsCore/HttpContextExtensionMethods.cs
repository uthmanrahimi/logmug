using Microsoft.AspNetCore.Http;

using System;

namespace Logmug
{
    public static class HttpContextExtensionMethods
    {
        public static string GetOS(this HttpContext context)
        {
            String userAgent = context.Request.Headers["User-Agent"].ToString().ToLower();
            string os = string.Empty;

            if (userAgent.IndexOf("windows nt") > 0)
                os = "Windows";
            else if (userAgent.IndexOf("macintosh") > 0)
                os = "Macintosh";
            else if (userAgent.IndexOf("android") > 0)
                os = "Android";
            else if (userAgent.IndexOf("mac os") > 0)
                os = "Mac OS";
            else if (userAgent.IndexOf("iPhone") > 0)
                os = "IPhone";
            else if (userAgent.IndexOf("iPad") > 0)
                os = "IPad";
            else if (userAgent.IndexOf("linux") > 0)
                os = "Linux";
            else
            {
                os = "Others";
            }

            return os;
        }
    }
}
