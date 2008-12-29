using System;

using System.Collections.Generic;
using System.Text;

using Twarph.Actions;

namespace Twarph
{
    public class PostQueue : Action
    {
        Queue<Post.PostData> queue = new Queue<Post.PostData>();

        public override int APICallCount
        {
            get { return (0); }
        }

        public override int MinInterval
        {
            get { return (10); }
        }

        public void Add(string text, int inreplyto)
        {
            Post.PostData pd = new Twarph.Actions.Post.PostData(this.User, this.Password, text, inreplyto);
            lock (this.queue)
            {
                this.queue.Enqueue(pd);
            }
        }

        public void Add(string text)
        {
            this.Add(text, 0);
        }

        public override void Work()
        {
            Post.PostData pd;
            lock (this.queue)
            {
                if (this.queue.Count < 1)
                    return;
                pd = queue.Dequeue();
            }
            try
            {
                Post.PostUpdate(pd);
            }
            catch (Exception e)
            {
                this.queue.Enqueue(pd);
            }
        }
    }
}
