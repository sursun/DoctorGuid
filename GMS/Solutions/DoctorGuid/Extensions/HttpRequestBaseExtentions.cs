using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web;

namespace DoctorGuid.Extensions
{
    public static class HttpRequestExtentions
    {
        public static bool IsXmlRequest(this HttpRequest req)
        {
            return !string.IsNullOrEmpty(req.Headers["IsXml"]);

        }
        public static bool IsJson(this HttpRequest req)
        {
            return req.AcceptTypes != null && req.AcceptTypes.Contains("application/json");
        }




        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        /// <summary>
        /// 获取请求机的mac地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetMac(this HttpRequest request)
        {

            string strmac = request.Headers.Get("mac");

            if (strmac.NotNullAndEmpty()) return strmac;

            if (strmac.IsNullOrEmpty())
            {
                var cookie = request.Cookies.Get("mac");
                if (cookie != null)
                    strmac = cookie.Value;
            }
            if (strmac.NotNullAndEmpty()) return strmac;

            if (strmac.IsNull()) strmac = "";


            // IPAddress.Parse(request.UserHostAddress).Address
            Int32 ldest = inet_addr(request.UserHostAddress);//目的地的ip
            Int32 lhost = 0;//本地的ip
            try
            {
                var macinfo = new Byte[6];
                uint length = 6;

                int ii = SendARP(ldest, lhost, macinfo, ref length);


                return macinfo.Aggregate(strmac, (current, item) => current + item.ToString("X2"));
            }
            catch (Exception err)
            {
                return "";
            }
        }
    }
}
}
