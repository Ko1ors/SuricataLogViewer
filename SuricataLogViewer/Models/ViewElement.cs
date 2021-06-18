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
            result += "AppProto: \n";
            result += "AppProtoTc: \n";
            result += "TxId: \n";
            result += "AppProtoExp: \n";
            result += "AppProtoTs: \n";
            if (surEvent.Alert != null)
            {
                result += "Alert:\n";
                result += "   Action: \n";
                result += "   Gid: \n";
                result += "   Signature id: \n";
                result += "   Rev: \n";
                result += "   Signature: \n";
                result += "   Category: \n";
                result += "   Severity: \n";
            }
            if (surEvent.Flow != null)
            {
                result += "Flow:\n";
                result += "   Pkts to server: \n";
                result += "   Pkts to client: \n";
                result += "   Bytes to server: \n";
                result += "   Bytes to client: \n";
                result += "   Start: \n";
            }
            if (surEvent.Vars != null)
            {
                result += "Vars:\n";
                if (surEvent.Vars.Flowbits != null)
                {
                    result += "   Flowbits:\n";
                    result += "      IsProtoIrc: \n";
                    result += "      ExeNoReferer: \n";
                    result += "      ETMalformedTLSHB: \n";
                    result += "      ETHBRequestCI: \n";
                    result += "      ETHBRequestSI: \n";
                    result += "      ETHBResponseCI: \n";
                    result += "      ETTorIP: \n";
                    result += "      ETHttpBinary: \n";
                    result += "      ETZbotDat: \n";
                    result += "      ETELFDownload: \n";
                    result += "      ETETERNALBLUE: \n";
                    result += "      ETSmbBinary: \n";
                    result += "      ETEvil: \n";
                    result += "      ETBotccIP: \n";
                }
                if (surEvent.Vars.Flowints != null)
                {
                    result += "   Flowints:\n";
                    result += "      TlsAnomalyCount: \n";
                    result += "      SmtpAnomalyCount: \n";
                    result += "      HttpAnomalyCount: \n";
                }
            }
            if (surEvent.Http != null)
            {
                result += "Http:\n";
                result += "   Hostname: \n";
                result += "   Url: \n";
                result += "   HttpUserAgent: \n";
                result += "   HttpContentType: \n";
                result += "   HttpMethod: \n";
                result += "   Protocol: \n";
                result += "   Status: \n";
                result += "   Length: \n";
                result += "   Redirect: \n";
                result += "   HttpRefer: \n";
            }
            if (surEvent.Tls != null)
            {
                result += "Tls:\n";
                result += "   Subject: \n";
                result += "   Issuerdn: \n";
                result += "   Serial: \n";
                result += "   Fingerprint: \n";
                result += "   Version: \n";
                result += "   Notbefore: \n";
                result += "   Notafter: \n";
                result += "   Sni: \n";
            }
            if (surEvent.Smtp != null)
            {
                result += "Smtp:\n";
                result += "   Helo: \n";
                result += "   MailFrom: \n";
                result += "   RcptTo: \n";
            }
            if (surEvent.Email != null)
            {
                result += "Email:\n";
                result += "   Status: \n";
            }
            return result;
        }

        public String outputEl2(int index)
        {
            SuricataEvent surEvent = surList[index];
            String result = (surEvent.Timestamp.ToString() ?? "empty") + "\n";
            result += (surEvent.FlowId ?? "empty") + "\n";
            result += (surEvent.PcapCnt != 0 ? surEvent.PcapCnt.ToString() : "empty") + "\n";
            result += (surEvent.EventType ?? "empty") + "\n";
            result += (surEvent.SrcIp ?? "empty" ) + "\n";
            result += (surEvent.SrcPort != 0 ? surEvent.SrcPort.ToString() : "empty") + "\n";
            result += (surEvent.DestIp ?? "empty") + "\n";
            result += (surEvent.DestPort != 0 ? surEvent.DestPort.ToString() : "empty") + "\n";
            result += (surEvent.Proto ?? "empty") + "\n";
            result += (surEvent.AppProto ?? "empty") + "\n";
            result += (surEvent.AppProtoTc ?? "empty") + "\n";
            result += (surEvent.TxId.HasValue ? surEvent.TxId.ToString() : "empty") + "\n";
            result += (surEvent.AppProtoExpected ?? "empty") + "\n";
            result += (surEvent.AppProtoTs ?? "empty") + "\n";
            if (surEvent.Alert != null)
            {
                result += "\n" + surEvent.Alert.Action.ToString() + "\n";
                result += surEvent.Alert.Gid.ToString() + "\n";
                result += surEvent.Alert.SignatureId.ToString() + "\n";
                result += surEvent.Alert.Rev.ToString() + "\n";
                result += surEvent.Alert.Signature.ToString() + "\n";
                result += surEvent.Alert.Category.ToString() + "\n";
                result += surEvent.Alert.Severity.ToString() + "\n";
            }
            if (surEvent.Flow != null)
            {
                result += "\n" + surEvent.Flow.PktsToserver.ToString() + "\n";
                result += surEvent.Flow.PktsToclient.ToString() + "\n";
                result += surEvent.Flow.BytesToserver.ToString() + "\n";
                result += surEvent.Flow.BytesToclient.ToString() + "\n";
                result += surEvent.Flow.Start.ToString() + "\n";
            }
            return result;
        }
    }
}
