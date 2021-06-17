using SuricataLogViewer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuricataLogViewer.Services
{
    public class SuricataService
    {

        public List<SuricataEvent> GetLog(string url)
        {
            try
            {
                var result = Request.Send(url);
                return JsonConvert.DeserializeObject<List<SuricataEvent>>(result);
            }
            catch
            {
                return null;
            }
        }
    }
}
