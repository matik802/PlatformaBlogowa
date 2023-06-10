using PlatformaBlogowa.Models;
using System.Net;

namespace PlatformaBlogowa.Utilities
{
	public class ClientIp
	{
		public static string GetClientIp()
		{
			string Ip = "";
			string hostName = string.Empty;
			hostName = Dns.GetHostName();
			IPHostEntry myIP = Dns.GetHostEntry(hostName);
			IPAddress[] address = myIP.AddressList;
			for (int i = 0; i < address.Length; i++)
			{
				Ip += address[i];
				Ip += " ";
			}
			return Ip;
		}
	}
}
