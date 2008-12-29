using System;

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Twarph
{
    public static class Tweets
    {
        static SortedList<int, Tweet> tweets = new SortedList<int, Tweet>(new RecentTweetFirst());

        public static void Add(Tweet tweet)
        {
            lock (tweets)
            {
                if (!tweets.ContainsKey(tweet.ID))
                    tweets.Add(tweet.ID, tweet);
            }
        }

        public static int Count
        {
            get { return (tweets.Count); }
        }

        public static List<Tweet> Last(int count)
        {
            lock (tweets)
            {
                count = Math.Min(count, tweets.Count);
                List<Tweet> ret = new List<Tweet>(count);
                IEnumerator<KeyValuePair<int,Tweet>> enumr = tweets.GetEnumerator();
                for (int i = 0; i < count; i++)
                {
                    enumr.MoveNext();
                    ret.Add(enumr.Current.Value);
                }
                return (ret);
            }
        }

        public static void Fill(ContainerControl container)
        {
            int top = 0;
            lock (tweets)
            {
                foreach (KeyValuePair<int,Tweet> tweet in tweets)
                {
                    TweetItem ti = new TweetItem(tweet.Value);
                    container.Controls.Add(ti);
                    ti.Left = 0;
                    ti.Width = container.Width;
                    ti.Top = top;
                    top += ti.Height + 1;
                }
            }
        }
    }

    public class RecentTweetFirst : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return (y - x); 
        }
    }
}
