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

        public String outputEl1(int index)
        {
            SuricataEvent surEvent = surList[index];
            String result = "Time: \n";
            result += "Flow id: \n";
            result += "Pcap count: \n";
            result += "Event type: \n";
            result += "Source ip: \n";
            result += "Source port: \n";
            result += "Destiny ip: \n";
            result += "Destiny port: \n";
            result += "Protocol: \n";
            result += "Alert:\n";
            result += "   Action: \n";
            result += "   Gid: \n";
            result += "   Signature id: \n";
            result += "   Rev: \n";
            result += "   Signature: \n";
            result += "   Category: \n";
            result += "   Severity: \n";
            result += "Flow:\n";
            result += "   Packets to server: \n";
            result += "   Packets to client: \n";
            result += "   Bytes to server: \n";
            result += "   Bytes to client: \n";
            result += "   Start: \n";
            result += "App proto: \n";
            return result;
        }

        public String outputEl2(int index)
        {
            SuricataEvent surEvent = surList[index];
            String result = surEvent.Timestamp.ToString() + "\n";
            result += surEvent.FlowId.ToString() + "\n";
            result += surEvent.PcapCnt.ToString() + "\n";
            result += surEvent.EventType.ToString() + "\n";
            result += surEvent.SrcIp.ToString() + "\n";
            result += surEvent.SrcPort.ToString() + "\n";
            result += surEvent.DestIp.ToString() + "\n";
            result += surEvent.DestPort.ToString() + "\n";
            result += surEvent.Proto.ToString() + "\n";
            result += "\n";
            result += surEvent.Alert.Action.ToString() + "\n";
            result += surEvent.Alert.Gid.ToString() + "\n";
            result += surEvent.Alert.SignatureId.ToString() + "\n";
            result += surEvent.Alert.Rev.ToString() + "\n";
            result += surEvent.Alert.Signature.ToString() + "\n";
            result += surEvent.Alert.Category.ToString() + "\n";
            result += surEvent.Alert.Severity.ToString() + "\n";
            result += "\n";
            result += surEvent.Flow.PktsToserver.ToString() + "\n";
            result += surEvent.Flow.PktsToclient.ToString() + "\n";
            result += surEvent.Flow.BytesToserver.ToString() + "\n";
            result += surEvent.Flow.BytesToclient.ToString() + "\n";
            result += surEvent.Flow.Start.ToString() + "\n";
            result += surEvent.AppProto ?? "empty";
            result += "\n";
            return result;
        }
    }
}
