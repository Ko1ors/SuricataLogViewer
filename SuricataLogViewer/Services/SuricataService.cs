using Newtonsoft.Json;
using SuricataLogViewer.Model;
using SuricataLogViewer.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuricataLogViewer.Services
{
    public class SuricataService
    {
        private static List<SuricataEvent> log;
        private static string path;

        public static List<SuricataEvent> GetLog()
        {
            try
            {            
                if (log != null && path.Equals(AppSettings.Default.LogPath))
                    return log;
                return GetLog(AppSettings.Default.LogPath);
            }
            catch
            {
                return null;
            }
        }

        public static List<SuricataEvent> GetLog(string url)
        {
            try
            {               
                if (log != null && path.Equals(url))
                    return log;
                return LoadLog(url);
            }
            catch
            {
                return null;
            }
        }

        public static List<SuricataEvent> LoadLog(string url)
        {
            try
            {
                var result = Request.Send(url);
                log = JsonConvert.DeserializeObject<List<SuricataEvent>>(result);
                path = url;
                return log;
            }
            catch
            {
                return null;
            }
        }
    }
}
