using System;

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Twarph.Actions
{
    public class Post
    {
        public struct PostData
        {
            public string User;
            public string Password;
            public string Text;
            public int InReplyTo;

            public PostData(string user, string pass, string text, int inreplyto)
            {
                this.User = user;
                this.Password = pass;
                this.Text = text;
                this.InReplyTo = inreplyto;
            }
        }

        public static void PostUpdate(PostData data)
        {
            string rstring = "status=" + Uri.EscapeDataString(data.Text);
            if (data.InReplyTo > 0)
                rstring += "&in_reply_to_status_id=" + data.InReplyTo.ToString();
            HttpWebRequest req = HTTPXML.StartRequest("https://twitter.com/statuses/update.xml");
            req.Credentials = new BasicAuth(data.User, data.Password);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] bytes = Encoding.ASCII.GetBytes(rstring);
            req.ContentLength = bytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            XmlDocument doc = new XmlDocument();
            Stream s = req.GetResponse().GetResponseStream();
            doc.Load(XmlReader.Create(s));
            s.Close();
            HTTPXML.FinishRequest(req);
        }
    }
}
