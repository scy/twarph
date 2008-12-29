using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;

using Twarph.Actions;

namespace Twarph
{
    public static class BackgroundLoop
    {
        struct QueueEntry
        {
            public Action Action;
            public DateTime LastStart;
        }

        static Queue<QueueEntry> queue = new Queue<QueueEntry>();
        static List<Action> todelete = new List<Action>();

        public static void Fork()
        {
            Thread me = new Thread(Run);
            me.Start();
        }

        static void Run()
        {
            int tweetcount = 0;
            while (true)
            {
                Thread.Sleep(1000);
                if (queue.Count < 1)
                    continue;
                QueueEntry qe = queue.Dequeue();
                if (todelete.Contains(qe.Action))
                {
                    todelete.Remove(qe.Action);
                    continue;
                }
                if (qe.LastStart.AddSeconds(qe.Action.MinInterval) <= DateTime.Now)
                {
                    qe.LastStart = DateTime.Now;
                    try
                    {
                        System.Diagnostics.Debug.WriteLine(DateTime.Now + ": Running " + qe.Action.ToString());
                        qe.Action.Work();
                        if (Tweets.Count != tweetcount)
                        {
                            tweetcount = Tweets.Count;
                            DisplayManager.UpdateContainer();
                        }
                    }
                    catch (Exception e)
                    {
                        e = e;
                        // Ignore.
                    }
                }
                queue.Enqueue(qe);
            }
        }

        public static void Add(Action action)
        {
            QueueEntry qe = new QueueEntry();
            qe.Action = action;
            qe.LastStart = new DateTime(1983, 11, 15);
            queue.Enqueue(qe);
        }

        public static void Remove(Action action)
        {
            todelete.Add(action);
        }
    }
}
