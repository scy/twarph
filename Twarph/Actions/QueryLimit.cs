using System;

using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Twarph.Actions
{
    public class QueryLimit : Action
    {
        public override int APICallCount
        {
            get { return (0); }
        }

        public override int MinInterval
        {
            get { return (60); }
        }

        public override void Work()
        {
            XmlDocument doc = HTTPXML.Query("account/rate_limit_status", new Dictionary<string, string>(0), this.User, this.Password);
        }
    }
}
