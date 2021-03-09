using Microsoft.AspNetCore.Http;
using System;

namespace AnalyticsCore
{
    public static class HttpContextExtensionMethods
    {
        public static string GetOS(this HttpContext context)
        {
            String userAgent = context.Request.Headers["User-Agent"];
            string os = "";

            if (userAgent.IndexOf("Windows NT 10") > 0)
                os = "Windows 10";
            else if (userAgent.IndexOf("Windows NT 6.3") > 0)
            {
                os = "Windows 8.1";
            }
            else if (userAgent.IndexOf("Windows NT 6.2") > 0)
            {
                os = "Windows 8";
            }
            else if (userAgent.IndexOf("Windows NT 6.1") > 0)
            {
                os = "Windows 7";
            }
            else if (userAgent.IndexOf("Windows NT 6.0") > 0)
            {
                os = "Windows Vista";
            }
            else if (userAgent.IndexOf("Windows NT 5.2") > 0)
            {
                os = "Windows Server 2003; Windows XP x64 Edition";
            }
            else if (userAgent.IndexOf("Windows NT 5.1") > 0)
            {
                os = "Windows XP";
            }
            else if (userAgent.IndexOf("Windows NT 5.01") > 0)
            {
                os = "Windows 2000, Service Pack 1 (SP1)";
            }
            else if (userAgent.IndexOf("Windows NT 5.0") > 0)
            {
                os = "Windows 2000";
            }
            else if (userAgent.IndexOf("Windows NT 4.0") > 0)
            {
                os = "Microsoft Windows NT 4.0";
            }
            else if (userAgent.IndexOf("Win 9x 4.90") > 0)
            {
                os = "Windows Millennium Edition (Windows Me)";
            }
            else if (userAgent.IndexOf("Windows 98") > 0)
            {
                os = "Windows 98";
            }
            else if (userAgent.IndexOf("Windows 95") > 0)
            {
                os = "Windows 95";
            }
            else if (userAgent.IndexOf("Windows CE") > 0)
            {
                os = "Windows CE";
            }
            else
            {
                os = "Others";
            }

            return os;
        }
    }
}
