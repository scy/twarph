using System;

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Twarph
{
    public static class DisplayManager
    {
        static Control cont;

        delegate void Invoker();
        delegate void ControlAdder(Control c);

        public static Control Container
        {
            set { cont = value; }
        }

        public static void UpdateContainer()
        {
            if (cont == null)
                return;
            if (cont.InvokeRequired)
            {
                cont.Invoke(new Invoker(DisplayManager.UpdateContainer));
                return;
            }
            List<Tweet> tweets = Tweets.Last(5);
            cont.Controls.Clear();
            int y = 0;
            foreach (Tweet tweet in tweets)
            {
                TweetItem ti = new TweetItem(tweet);
                cont.Controls.Add(ti);
                ti.Top = y;
                ti.Width = cont.Width;
                y += ti.Height + 1;
            }
        }
    }
}
