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
            String result = "  Time: " + surEvent.Timestamp.ToString() + "\n";
            result += "  Flow id: " + surEvent.FlowId.ToString() + "\n";
            result += "  Pcap count: " + surEvent.PcapCnt.ToString() + "\n";
            result += "  Event type: " + surEvent.EventType.ToString() + "\n";
            result += "  Source ip: " + surEvent.SrcIp.ToString() + "\n";
            result += "  Source port: " + surEvent.SrcPort.ToString() + "\n";
            result += "  Destiny ip: " + surEvent.DestIp.ToString() + "\n";
            result += "  Destiny port: " + surEvent.DestPort.ToString() + "\n";
            result += "  Protocol: " + surEvent.Proto.ToString() + "\n";
            result += "  Alert:\n";
            result += "\tAction: " + surEvent.Alert.Action.ToString() + "\n";
            result += "\tGid: " + surEvent.Alert.Gid.ToString() + "\n";
            result += "\tSignature id: " + surEvent.Alert.SignatureId.ToString() + "\n";
            result += "\tRev: " + surEvent.Alert.Rev.ToString() + "\n";
            result += "\tSignature: " + surEvent.Alert.Signature.ToString() + "\n";
            result += "\tCategory: " + surEvent.Alert.Category.ToString() + "\n";
            result += "\tSeverity: " + surEvent.Alert.Severity.ToString() + "\n";
            result += "  Flow:\n";
            result += "\tPackets to server: " + surEvent.Flow.PktsToserver.ToString() + "\n";
            result += "\tPackets to client: " + surEvent.Flow.PktsToclient.ToString() + "\n";
            result += "\tBytes to server: " + surEvent.Flow.BytesToserver.ToString() + "\n";
            result += "\tBytes to client: " + surEvent.Flow.BytesToclient.ToString() + "\n";
            result += "\tStart: " + surEvent.Flow.Start.ToString() + "";
            return result;
        }  
    }
}
