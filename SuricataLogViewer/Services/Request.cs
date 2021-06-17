using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SuricataLogViewer.Services
{
    public static class Request
    {
        public static string Send(string request)
        {
            string result;
            using (WebClient webClient = new WebClient())
            {
                result = webClient.DownloadString(request);
            }
            return result;
        }
    }
}
