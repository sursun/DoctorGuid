using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace DoctorGuid
{
    public class HKNetwork
    {
        public static string GetLocalIp()
        {
            string strIp = "";

            string hostname = Dns.GetHostName();//得到本机名
            IPHostEntry localhost = Dns.GetHostEntry(hostname);

            foreach (var localaddr in localhost.AddressList)
            {
                if (localaddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    strIp = localaddr.ToString();

                    Console.WriteLine(String.Format("IP======{0}", strIp));

                    break;
                }
            }

            return strIp;
        }

        public static string GetMac()
        {
            string strMac = "";
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    strMac = ni.GetPhysicalAddress().ToString();

                    Console.WriteLine(String.Format("MAC======{0}", strMac));

                    break;
                }

            }

            return strMac;
        }
    }
}
