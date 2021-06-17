using SuricataLogViewer.Model;
using SuricataLogViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuricataLogViewer.Models
{
    class ViewElement
    {
        List<SuricataEvent> surList = new SuricataService().GetLog("https://raw.githubusercontent.com/FrankHassanabad/suricata-sample-data/master/samples/wrccdc-2018/alerts-only.json");

        public String outputEl(int index)
        {
            SuricataEvent surEvent = surList[index];
            String result = "Time: " + surEvent.Timestamp.ToString() + "\n";
            result += "Flow id: " + surEvent.FlowId.ToString() + "\n";
            result += "Pcap count: " + surEvent.PcapCnt.ToString() + "\n";
            result += "Event type: " + surEvent.EventType.ToString() + "\n";
            result += "Source ip: " + surEvent.SrcIp.ToString() + "\n";
            result += "Source port: " + surEvent.SrcPort.ToString() + "\n";
            result += "Destiny ip: " + surEvent.DestIp.ToString() + "\n";
            result += "Destiny port: " + surEvent.DestPort.ToString() + "\n";
            result += "Protocol: " + surEvent.Proto.ToString() + "\n";
            result += "Alert: [";
            result += "action: " + surEvent.Alert.Action.ToString() + ", ";
            result += "gid: " + surEvent.Alert.Gid.ToString() + ",";
            result += "signature id: " + surEvent.Alert.SignatureId.ToString() + ", ";
            result += "rev: " + surEvent.Alert.Rev.ToString() + ",";
            result += "signature: " + surEvent.Alert.Signature.ToString() + ", ";
            result += "category: " + surEvent.Alert.Category.ToString() + ", ";
            result += "severity: " + surEvent.Alert.Severity.ToString() + "]\n";
            result += "Flow: [";
            result += "pkts to server: " + surEvent.Flow.PktsToserver.ToString() + ", ";
            result += "pkts to client: " + surEvent.Flow.PktsToclient.ToString() + ", ";
            result += "bytes to server: " + surEvent.Flow.BytesToserver.ToString() + ", ";
            result += "bytes to client: " + surEvent.Flow.BytesToclient.ToString() + ", ";
            result += "start: " + surEvent.Flow.Start.ToString() + "]";
            return result;
        }  
    }
}
