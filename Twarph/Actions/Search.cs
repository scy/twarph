using System;

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Twarph.Actions
{
    public class Search : Action
    {
        const string ATOMURI = "http://www.w3.org/2005/Atom";

        static Dictionary<string, int> lastids = new Dictionary<string, int>();

        string query;

        public override int  APICallCount
        {
            get { return (0); }
        }

        public override int MinInterval
        {
            get { return (10); }
        }

        public int LastID
        {
            get { return (lastids[this.Query]); }
        }

        public string Query
        {
            get { return (string.Copy(this.query)); }
            set
            {
                if ((value == null) || (value.Trim() == string.Empty))
                    throw new ArgumentException("Search query may not be empty.");
                this.query = value;
                lock (lastids)
                {
                    if (!lastids.ContainsKey(value))
                        lastids.Add(value, 0);
                }
            }
        }

        public Search(string query)
        {
            this.Query = query;
        }

        static int ParseIDTag(string text)
        {
            string[] split = text.Split(':');
            return (Convert.ToInt32(split[split.Length - 1]));
        }

        public override void Work()
        {
            HttpWebRequest req = HTTPXML.StartRequest("http://search.twitter.com/search.atom?" +
                "q=" + Uri.EscapeDataString(this.Query) +
                "&since_id=" + this.LastID.ToString()
                );
            WebResponse res = req.GetResponse();
            XmlDocument doc = new XmlDocument();
            Stream s = res.GetResponseStream();
            doc.Load(s);
            s.Close();
            int maxid = 0;
            foreach (XmlNode node in doc.GetElementsByTagName("entry", ATOMURI))
            {
                Tweet t = new Tweet();
                foreach (XmlNode entry in node.ChildNodes)
                {
                    if (entry.NamespaceURI != ATOMURI)
                        continue;
                    switch (entry.Name)
                    {
                        case "id":
                            int id = ParseIDTag(entry.InnerText);
                            t.ID = id;
                            if (id > maxid)
                                maxid = id;
                            break;
                        case "title":
                            t.Text = entry.InnerText;
                            break;
                        case "author":
                            foreach (XmlNode authorentry in entry.ChildNodes)
                            {
                                if (entry.NamespaceURI != ATOMURI)
                                    continue;
                                switch (authorentry.Name)
                                {
                                    case "name":
                                        t.Nick = authorentry.InnerText.Split(' ')[0];
                                        break;
                                }
                            }
                            break;
                    }
                }
                Tweets.Add(t);
            }
            lock (lastids)
            {
                if (maxid > lastids[this.Query])
                    lastids[this.Query] = maxid;
            }
            HTTPXML.FinishRequest(req);
        }
    }
}
