using System;

using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;

namespace Twarph.Actions
{
    public class BlindlyAccept : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return (true);
        }
    }

    public class BasicAuth : ICredentials
    {
        string user;
        string pass;

        public BasicAuth(string user, string pass)
        {
            if (user != null)
                this.user = user;
            if (pass != null)
                this.pass = pass;
        }

        public NetworkCredential GetCredential(Uri uri, string authType)
        {
            return (new NetworkCredential(this.user, this.pass));
        }
    }

    public static class HTTPXML
    {
        static ICertificatePolicy oldpol = null;

        public static XmlDocument Query(string method, Dictionary<string, string> data, string user, string pass)
        {
            string[] parameters = new string[data.Count];
            int i = 0;
            foreach (KeyValuePair<string, string> kvp in data)
            {
                parameters[i++] = Uri.EscapeDataString(kvp.Key) + "=" + Uri.EscapeDataString(kvp.Value);
            }
            string jointparams = string.Join("&", parameters);
            HttpWebRequest req = StartRequest("https://twitter.com/" + method + ".xml?" + jointparams);
            req.Credentials = new BasicAuth(user, pass);
            XmlDocument doc = new XmlDocument();
            Stream s = req.GetResponse().GetResponseStream();
            doc.Load(XmlReader.Create(s));
            s.Close();
            FinishRequest(req);
            return (doc);
        }

        public static void SetRequest(HttpWebRequest req)
        {
            req.AllowWriteStreamBuffering = true;
            req.Timeout = 10000;
            req.UserAgent = "Twarph alpha";
        }

        public static HttpWebRequest StartRequest(string url)
        {
            if (oldpol == null)
                oldpol = ServicePointManager.CertificatePolicy;
            ServicePointManager.CertificatePolicy = new BlindlyAccept();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            SetRequest(req);
            return (req);
        }

        public static void FinishRequest(HttpWebRequest req)
        {
            ServicePointManager.CertificatePolicy = oldpol;
        }
    }
}
