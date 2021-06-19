using Newtonsoft.Json;
using SuricataLogViewer.Model;
using SuricataLogViewer.Models;
using System.Collections.Generic;
using System.IO;

namespace SuricataLogViewer.Services
{
    public class IpService
    {
        private static List<IpInfo> ipInfos;

        static IpService()
        {
            LoadIpInfoList();
        }

        public static void GetIpInfo(List<SuricataEvent> suricataEvents)
        {
            foreach (var suricataEvent in suricataEvents)
            {
                GetIpInfo(suricataEvent);
            }
        }

        public static void GetIpInfo(SuricataEvent suricataEvent)
        {
            suricataEvent.DestinationIpInfo = GetIpInfo(suricataEvent.DestIp);
            suricataEvent.SourceIpInfo = GetIpInfo(suricataEvent.SrcIp);
        }

        public static IpInfo GetIpInfo(string ip)
        {
            try
            {
                if (!IpInfoReceived(ip))
                {
                    var result = Request.Send($"http://ipinfo.io/{ip}");
                    var info = JsonConvert.DeserializeObject<IpInfo>(result);
                    ipInfos.Add(info);
                    SaveToFile();
                    return info;
                }
                else
                    return GetIpInfoFromFile(ip);
            }
            catch
            {
                return null;
            }
        }

        private static IpInfo GetIpInfoFromFile(string ip)
        {
            return ipInfos.Find(e => e.Ip == ip);
        }

        private static bool IpInfoReceived(string ip)
        {         
            if (ipInfos != null)
                return ipInfos.Exists(e => e.Ip == ip);
            return false;
        }

        private static void LoadIpInfoList()
        {
            if (File.Exists(Properties.Resources.IpInfoFilePath))
            {
                try
                {
                    ipInfos = JsonConvert.DeserializeObject<List<IpInfo>>(File.ReadAllText(Properties.Resources.IpInfoFilePath));
                }
                catch
                {

                }
            }
            else
                ipInfos = new List<IpInfo>();
        }

        private static void SaveToFile()
        {
            File.WriteAllText(Properties.Resources.IpInfoFilePath, JsonConvert.SerializeObject(ipInfos, Formatting.Indented));
        }
    }
}
