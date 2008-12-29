using System;

using System.Collections.Generic;
using System.Text;

namespace Twarph.Actions
{
    class UserAccount
    {
        string user;
        string pass;

        PostQueue pq = new PostQueue();
        QueryLimit ql = new QueryLimit();

        public void Post(string text, int inreplyto)
        {
            this.pq.Add(text, inreplyto);
        }

        public void Post(string text)
        {
            this.pq.Add(text);
        }

        void Add(Action action)
        {
            action.User = this.user;
            action.Password = this.pass;
            BackgroundLoop.Add(action);
        }

        public UserAccount(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            this.Add(ql);
            this.Add(pq);
        }

        public void Quit()
        {
            BackgroundLoop.Remove(ql);
            BackgroundLoop.Remove(pq);
        }
    }
}
