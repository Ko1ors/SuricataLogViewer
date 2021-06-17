using Newtonsoft.Json;
using SuricataLogViewer.Model;
using SuricataLogViewer.Properties;
using System.Collections.Generic;

namespace SuricataLogViewer.Services
{
    public class SuricataService
    {
        private static List<SuricataEvent> log;

        public List<SuricataEvent> GetLog()
        {
            try
            {
                if (log != null)
                    return log;
                return LoadLog(Resources.SuricataSampleLogUrl);
            }
            catch
            {
                return null;
            }
        }

        public List<SuricataEvent> GetLog(string url)
        {
            try
            {
                if (log != null)
                    return log;
                return LoadLog(url);
            }
            catch
            {
                return null;
            }
        }

        public List<SuricataEvent> LoadLog(string url)
        {
            try
            {
                var result = Request.Send(url);
                log = JsonConvert.DeserializeObject<List<SuricataEvent>>(result);
                return log;
            }
            catch
            {
                return null;
            }
        }
    }
}
