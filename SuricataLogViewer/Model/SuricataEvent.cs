using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuricataLogViewer.Model
{
        public class Alert
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("gid")]
            public int Gid { get; set; }

            [JsonProperty("signature_id")]
            public int SignatureId { get; set; }

            [JsonProperty("rev")]
            public int Rev { get; set; }

            [JsonProperty("signature")]
            public string Signature { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("severity")]
            public int Severity { get; set; }
        }

        public class Flow
        {
            [JsonProperty("pkts_toserver")]
            public int PktsToserver { get; set; }

            [JsonProperty("pkts_toclient")]
            public int PktsToclient { get; set; }

            [JsonProperty("bytes_toserver")]
            public int BytesToserver { get; set; }

            [JsonProperty("bytes_toclient")]
            public int BytesToclient { get; set; }

            [JsonProperty("start")]
            public DateTime Start { get; set; }
        }

        public class Flowbits
        {
            [JsonProperty("is_proto_irc")]
            public bool IsProtoIrc { get; set; }

            [JsonProperty("exe.no.referer")]
            public bool? ExeNoReferer { get; set; }

            [JsonProperty("ET.MalformedTLSHB")]
            public bool? ETMalformedTLSHB { get; set; }

            [JsonProperty("ET.HB.Request.CI")]
            public bool? ETHBRequestCI { get; set; }

            [JsonProperty("ET.HB.Request.SI")]
            public bool? ETHBRequestSI { get; set; }

            [JsonProperty("ET.HB.Response.CI")]
            public bool? ETHBResponseCI { get; set; }

            [JsonProperty("ET.TorIP")]
            public bool? ETTorIP { get; set; }

            [JsonProperty("ET.http.binary")]
            public bool? ETHttpBinary { get; set; }

            [JsonProperty("ET.zbot.dat")]
            public bool? ETZbotDat { get; set; }

            [JsonProperty("ET.ELFDownload")]
            public bool? ETELFDownload { get; set; }

            [JsonProperty("ET.ETERNALBLUE")]
            public bool? ETETERNALBLUE { get; set; }

            [JsonProperty("ET.smb.binary")]
            public bool? ETSmbBinary { get; set; }

            [JsonProperty("ET.Evil")]
            public bool? ETEvil { get; set; }

            [JsonProperty("ET.BotccIP")]
            public bool? ETBotccIP { get; set; }
        }

        public class Flowints
        {
            [JsonProperty("tls.anomaly.count")]
            public int TlsAnomalyCount { get; set; }

            [JsonProperty("smtp.anomaly.count")]
            public int? SmtpAnomalyCount { get; set; }

            [JsonProperty("http.anomaly.count")]
            public int? HttpAnomalyCount { get; set; }
        }

        public class Vars
        {
            [JsonProperty("flowbits")]
            public Flowbits Flowbits { get; set; }

            [JsonProperty("flowints")]
            public Flowints Flowints { get; set; }
        }

        public class Http
        {
            [JsonProperty("hostname")]
            public string Hostname { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("http_user_agent")]
            public string HttpUserAgent { get; set; }

            [JsonProperty("http_content_type")]
            public string HttpContentType { get; set; }

            [JsonProperty("http_method")]
            public string HttpMethod { get; set; }

            [JsonProperty("protocol")]
            public string Protocol { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            [JsonProperty("length")]
            public int Length { get; set; }

            [JsonProperty("redirect")]
            public string Redirect { get; set; }

            [JsonProperty("http_refer")]
            public string HttpRefer { get; set; }
        }

        public class Tls
        {
            [JsonProperty("subject")]
            public string Subject { get; set; }

            [JsonProperty("issuerdn")]
            public string Issuerdn { get; set; }

            [JsonProperty("serial")]
            public string Serial { get; set; }

            [JsonProperty("fingerprint")]
            public string Fingerprint { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("notbefore")]
            public DateTime Notbefore { get; set; }

            [JsonProperty("notafter")]
            public DateTime Notafter { get; set; }

            [JsonProperty("sni")]
            public string Sni { get; set; }
        }

        public class Smtp
        {
            [JsonProperty("helo")]
            public string Helo { get; set; }

            [JsonProperty("mail_from")]
            public string MailFrom { get; set; }

            [JsonProperty("rcpt_to")]
            public List<string> RcptTo { get; set; }
        }

        public class Email
        {
            [JsonProperty("status")]
            public string Status { get; set; }
        }

        public class SuricataEvent
        {
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; set; }

            [JsonProperty("flow_id")]
            public object FlowId { get; set; }

            [JsonProperty("pcap_cnt")]
            public int PcapCnt { get; set; }

            [JsonProperty("event_type")]
            public string EventType { get; set; }

            [JsonProperty("src_ip")]
            public string SrcIp { get; set; }

            [JsonProperty("src_port")]
            public int SrcPort { get; set; }

            [JsonProperty("dest_ip")]
            public string DestIp { get; set; }

            [JsonProperty("dest_port")]
            public int DestPort { get; set; }

            [JsonProperty("proto")]
            public string Proto { get; set; }

            [JsonProperty("alert")]
            public Alert Alert { get; set; }

            [JsonProperty("flow")]
            public Flow Flow { get; set; }

            [JsonProperty("vars")]
            public Vars Vars { get; set; }

            [JsonProperty("app_proto")]
            public string AppProto { get; set; }

            [JsonProperty("app_proto_tc")]
            public string AppProtoTc { get; set; }

            [JsonProperty("tx_id")]
            public int? TxId { get; set; }

            [JsonProperty("http")]
            public Http Http { get; set; }

            [JsonProperty("tls")]
            public Tls Tls { get; set; }

            [JsonProperty("smtp")]
            public Smtp Smtp { get; set; }

            [JsonProperty("app_proto_expected")]
            public string AppProtoExpected { get; set; }

            [JsonProperty("email")]
            public Email Email { get; set; }

            [JsonProperty("app_proto_ts")]
            public string AppProtoTs { get; set; }
        }
}
