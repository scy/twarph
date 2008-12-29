using System;

using System.Collections.Generic;
using System.Text;

namespace Twarph.Actions
{
    public abstract class Action
    {
        string user;
        string pass;

        public abstract int APICallCount { get; }

        public abstract int MinInterval { get; }

        public string User
        {
            get { return ((this.user == null) ? (null) : (string.Copy(this.user))); }
            set { this.user = value; }
        }

        public string Password
        {
            get { return ((this.pass == null) ? (null) : (string.Copy(this.pass))); }
            set { this.pass = value; }
        }

        public abstract void Work();
    }
}
