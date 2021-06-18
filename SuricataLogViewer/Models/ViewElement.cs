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
                result += "   Status: \n\n\n";
            }

            

            return result;
        }

        public String outputEl2(int index)
        {
            SuricataEvent surEvent = surList[index];
            String result = (surEvent.Timestamp.HasValue ? surEvent.Timestamp.ToString() : "empty") + "\n";
            result += (surEvent.FlowId ?? "empty") + "\n";
            result += (surEvent.PcapCnt.HasValue ? surEvent.PcapCnt.ToString() : "empty") + "\n";
            result += (surEvent.EventType ?? "empty") + "\n";
            result += (surEvent.SrcIp ?? "empty" ) + "\n";
            result += (surEvent.SrcPort.HasValue ? surEvent.SrcPort.ToString() : "empty") + "\n";
            result += (surEvent.DestIp ?? "empty") + "\n";
            result += (surEvent.DestPort.HasValue ? surEvent.DestPort.ToString() : "empty") + "\n";
            result += (surEvent.Proto ?? "empty") + "\n";
            result += (surEvent.AppProto ?? "empty") + "\n";
            result += (surEvent.AppProtoTc ?? "empty") + "\n";
            result += (surEvent.TxId.HasValue ? surEvent.TxId.ToString() : "empty") + "\n";
            result += (surEvent.AppProtoExpected ?? "empty") + "\n";
            result += (surEvent.AppProtoTs ?? "empty") + "\n";
            if (surEvent.Alert != null)
            {
                result += "\n" + (surEvent.Alert.Action ?? "empty") + "\n";
                result += (surEvent.Alert.Gid.HasValue ? surEvent.Alert.Gid.ToString() : "empty") + "\n";
                result += (surEvent.Alert.SignatureId.HasValue ? surEvent.Alert.SignatureId.ToString() : "empty") + "\n";
                result += (surEvent.Alert.Rev.HasValue ? surEvent.Alert.Rev.ToString() : "empty") + "\n";
                result += (surEvent.Alert.Signature ?? "empty") + "\n";
                result += (surEvent.Alert.Category ?? "empty") + "\n";
                result += (surEvent.Alert.Severity.HasValue ? surEvent.Alert.Severity.ToString() : "empty") + "\n";
            }
            if (surEvent.Flow != null)
            {
                result += "\n" + (surEvent.Flow.PktsToserver.HasValue ? surEvent.Flow.PktsToserver.ToString() : "empty") + "\n";
                result += (surEvent.Flow.PktsToclient.HasValue ? surEvent.Flow.PktsToclient.ToString() : "empty") + "\n";
                result += (surEvent.Flow.BytesToserver.HasValue ? surEvent.Flow.BytesToserver.ToString() : "empty") + "\n";
                result += (surEvent.Flow.BytesToclient.HasValue ? surEvent.Flow.BytesToclient.ToString() : "empty") + "\n";
                result += (surEvent.Flow.Start.HasValue ? surEvent.Flow.Start.ToString() : "empty") + "\n";
            }
            if (surEvent.Vars != null)
            {
                result += "\n";
                if (surEvent.Vars.Flowbits != null)
                {
                    result += "\n" + (surEvent.Vars.Flowbits.IsProtoIrc.HasValue ? surEvent.Vars.Flowbits.IsProtoIrc.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ExeNoReferer.HasValue ? surEvent.Vars.Flowbits.ExeNoReferer.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETMalformedTLSHB.HasValue ? surEvent.Vars.Flowbits.ETMalformedTLSHB.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETHBRequestCI.HasValue ? surEvent.Vars.Flowbits.ETHBRequestCI.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETHBRequestSI.HasValue ? surEvent.Vars.Flowbits.ETHBRequestSI.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETHBResponseCI.HasValue ? surEvent.Vars.Flowbits.ETHBResponseCI.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETTorIP.HasValue ? surEvent.Vars.Flowbits.ETTorIP.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETHttpBinary.HasValue ? surEvent.Vars.Flowbits.ETHttpBinary.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETZbotDat.HasValue ? surEvent.Vars.Flowbits.ETZbotDat.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETELFDownload.HasValue ? surEvent.Vars.Flowbits.ETELFDownload.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETETERNALBLUE.HasValue ? surEvent.Vars.Flowbits.ETETERNALBLUE.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETSmbBinary.HasValue ? surEvent.Vars.Flowbits.ETSmbBinary.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETEvil.HasValue ? surEvent.Vars.Flowbits.ETEvil.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowbits.ETBotccIP.HasValue ? surEvent.Vars.Flowbits.ETBotccIP.ToString() : "empty") + "\n";
                }
                if (surEvent.Vars.Flowints != null)
                {
                    result += "\n" + (surEvent.Vars.Flowints.TlsAnomalyCount.HasValue ? surEvent.Vars.Flowints.TlsAnomalyCount.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowints.SmtpAnomalyCount.HasValue ? surEvent.Vars.Flowints.SmtpAnomalyCount.ToString() : "empty") + "\n";
                    result += (surEvent.Vars.Flowints.HttpAnomalyCount.HasValue ? surEvent.Vars.Flowints.HttpAnomalyCount.ToString() : "empty") + "\n";
                }
            }
            if (surEvent.Http != null)
            {
                result += "\n" + (surEvent.Http.Hostname ?? "empty") + "\n";
                result += (surEvent.Http.Url ?? "empty") + "\n";
                result += (surEvent.Http.HttpUserAgent ?? "empty") + "\n";
                result += (surEvent.Http.HttpContentType ?? "empty") + "\n";
                result += (surEvent.Http.HttpMethod ?? "empty") + "\n";
                result += (surEvent.Http.Protocol ?? "empty") + "\n";
                result += (surEvent.Http.Status.HasValue ? surEvent.Http.Status.ToString() : "empty") + "\n";
                result += (surEvent.Http.Length.HasValue ? surEvent.Http.Length.ToString() : "empty") + "\n";
                result += (surEvent.Http.Redirect ?? "empty") + "\n";
                result += (surEvent.Http.HttpRefer ?? "empty") + "\n";
            }
            if (surEvent.Tls != null)
            {
                result += "\n" + (surEvent.Tls.Subject ?? "empty") + "\n";
                result += (surEvent.Tls.Issuerdn ?? "empty") + "\n";
                result += (surEvent.Tls.Serial ?? "empty") + "\n";
                result += (surEvent.Tls.Fingerprint ?? "empty") + "\n";
                result += (surEvent.Tls.Version ?? "empty") + "\n";
                result += (surEvent.Tls.Notbefore.HasValue ? surEvent.Tls.Notbefore.ToString() : "empty") + "\n";
                result += (surEvent.Tls.Notafter.HasValue ? surEvent.Tls.Notafter.ToString() : "empty") + "\n";
                result += (surEvent.Tls.Sni ?? "empty") + "\n";
            }
            if (surEvent.Smtp != null)
            {
                result += "\n" + (surEvent.Smtp.Helo ?? "empty") + "\n";
                result += (surEvent.Smtp.MailFrom ?? "empty") + "\n";
                result += "[";
                for (int i = 0; i < surEvent.Smtp.RcptTo.Count; i++)
                {
                    if (i != surEvent.Smtp.RcptTo.Count - 1)
                        result += surEvent.Smtp.RcptTo[i] + ", ";
                    else
                    {
                        result += surEvent.Smtp.RcptTo[i];
                    }
                }
                result += "]\n";
            }
            if (surEvent.Email != null)
            {
                result += "\n" + (surEvent.Email.Status ?? "empty") + "\n";
            }
            return result;
        }
    }
}
